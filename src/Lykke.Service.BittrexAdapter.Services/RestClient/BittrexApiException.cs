using System;

namespace Lykke.Service.BittrexAdapter.Services.RestClient
{
    public class BittrexApiException : Exception
    {
        public BittrexApiException(string message) : base(message)
        {
        }
    }
}
