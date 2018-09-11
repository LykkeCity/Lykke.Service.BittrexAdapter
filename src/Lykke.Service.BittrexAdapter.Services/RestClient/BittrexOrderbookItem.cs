using Newtonsoft.Json;

namespace Lykke.Service.BittrexAdapter.Services.RestClient
{
    public sealed class BittrexOrderBookItem
    {
        [JsonProperty("Quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty("Rate")]
        public decimal Rate { get; set; }
    }
}
