using Newtonsoft.Json;

namespace Lykke.Service.BittrexAdapter.Services.RestClient
{
    public sealed class BittrexResponse<T>
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("result")]
        public T Result { get; set; }
    }
}
