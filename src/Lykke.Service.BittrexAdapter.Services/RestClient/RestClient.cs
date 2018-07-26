using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Log;
using Lykke.Common.ExchangeAdapter.Server;
using Lykke.Common.Log;

namespace Lykke.Service.BittrexAdapter.Services.RestClient
{
    public sealed class RestClient
    {
        private readonly HttpClient _client;
        private readonly ILog _log;

        public RestClient(ILogFactory logFactory)
        {
            _log = logFactory.CreateLog(this);

            _client = new HttpClient(new LoggingHandler(_log, new HttpClientHandler(), "/api/v1.1/public/getorderbook"))
            {
                BaseAddress = new Uri("https://bittrex.com/api/v1.1/public/")
            };
        }

        public async Task<IReadOnlyCollection<MarketInfo>> GetMarketInfo(
            CancellationToken ct = default(CancellationToken))
        {
            using (var msg = await _client.GetAsync("getMarkets", ct))
            {
                return await ReadAsBittrexResponse<IReadOnlyCollection<MarketInfo>>(msg, ct);
            }
        }

        private async Task<T> ReadAsBittrexResponse<T>(HttpResponseMessage msg, CancellationToken ct)
        {
            msg.EnsureSuccessStatusCode();

            var content = await msg.Content.ReadAsAsync<BittrexResponse<T>>(ct);

            if (!content.Success)
            {
                throw new BittrexApiException(content.Message);
            }

            return content.Result;
        }

        public async Task<BittrexOrderBook> GetOrderBook(string marketName, CancellationToken ct)
        {
            using (var msg = await _client.GetAsync(
                $"getorderbook?market={WebUtility.UrlEncode(marketName)}&type=both",
                ct))
            {
                return await ReadAsBittrexResponse<BittrexOrderBook>(msg, ct);
            }
        }
    }
}
