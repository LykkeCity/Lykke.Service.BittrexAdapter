using System;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Log;
using Lykke.Common.ExchangeAdapter.Contracts;
using Lykke.Common.ExchangeAdapter.Server;
using Lykke.Common.Log;
using Lykke.Service.BittrexAdapter.Services.RestClient;
using Microsoft.Extensions.Hosting;

namespace Lykke.Service.BittrexAdapter.Services
{
    public sealed class OrderBookPublishingService : IHostedService
    {
        private readonly ILogFactory _lf;
        private readonly BittrexOrderBookPublishingSettings _settings;
        private ILog _log;

        private readonly RestClient.RestClient _client;
        private IDisposable _subscription;

        public OrderBooksSession Session { get; private set; }

        public OrderBookPublishingService(ILogFactory lf, BittrexOrderBookPublishingSettings settings)
        {
            _lf = lf;
            _settings = settings;
            _log = lf.CreateLog(this);
            _client = new RestClient.RestClient(lf);
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var marketInfo = await _client.GetMarketInfo(cancellationToken);

            var ob = marketInfo
                .Where(x => x.IsActive)
                .Select(x => x.MarketName)
                .Select(PullOrderBook)
                .Merge();

            Session = OrderBooksSession.FromRawOrderBooks(ob, _settings, _lf);

            _subscription = new CompositeDisposable(
                Session.Worker.Subscribe(),
                Session);
        }

        private IObservable<OrderBook> PullOrderBook(string marketName)
        {
            return Observable.Create<OrderBook>(async (obs, ct) =>
            {
                while (!ct.IsCancellationRequested)
                {
                    var ob = await _client.GetOrderBook(marketName, ct);

                    obs.OnNext(ob.ToContractsOrderBook(new LykkeInstrument(marketName)));

                    await Task.Delay(_settings.TimeoutBetweenQueries, ct);
                }
            });
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _subscription?.Dispose();
            return Task.CompletedTask;
        }
    }
}
