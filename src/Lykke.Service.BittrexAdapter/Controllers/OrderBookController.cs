using Lykke.Common.ExchangeAdapter.Server;
using Lykke.Service.BittrexAdapter.Services;

namespace Lykke.Service.BittrexAdapter.Controllers
{
    public class OrderBookController : OrderBookControllerBase
    {
        public OrderBookController(OrderBookPublishingService obService)
        {
            Session = obService.Session;
        }

        protected override OrderBooksSession Session { get; }
    }
}
