using System;
using Newtonsoft.Json;

namespace Lykke.Service.BittrexAdapter.Services.RestClient
{
    public sealed class MarketInfo
    {
        [JsonProperty("MarketCurrency")]
        public string MarketCurrency { get; set; }

        [JsonProperty("BaseCurrency")]
        public string BaseCurrency { get; set; }

        [JsonProperty("MarketCurrencyLong")]
        public string MarketCurrencyLong { get; set; }

        [JsonProperty("BaseCurrencyLong")]
        public string BaseCurrencyLong { get; set; }

        [JsonProperty("MinTradeSize")]
        public double MinTradeSize { get; set; }

        [JsonProperty("MarketName")]
        public string MarketName { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }

        [JsonProperty("Created")]
        public DateTimeOffset Created { get; set; }
    }
}