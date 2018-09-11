using System;
using System.Linq;
using Lykke.Common.ExchangeAdapter.Contracts;
using Newtonsoft.Json;

namespace Lykke.Service.BittrexAdapter.Services.RestClient
{
    public sealed class BittrexOrderBook
    {
        [JsonProperty("buy")]
        public BittrexOrderBookItem[] Buy { get; set; }

        [JsonProperty("sell")]
        public BittrexOrderBookItem[] Sell { get; set; }

        public OrderBook ToContractsOrderBook(LykkeInstrument instrument)
        {
            return new OrderBook(
                "bittrex",
                instrument.Value,
                DateTime.UtcNow,
                asks: Sell.Select(x => new OrderBookItem(x.Rate, x.Quantity)),
                bids: Buy.Select(x => new OrderBookItem(x.Rate, x.Quantity)));
        }
    }
}
