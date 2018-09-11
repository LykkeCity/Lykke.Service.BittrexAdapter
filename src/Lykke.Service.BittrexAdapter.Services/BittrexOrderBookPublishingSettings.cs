using System;
using Lykke.Common.ExchangeAdapter.Server.Settings;

namespace Lykke.Service.BittrexAdapter.Services
{
    public sealed class BittrexOrderBookPublishingSettings : OrderBookProcessingSettings
    {
        public TimeSpan TimeoutBetweenQueries { get; set; }
    }
}
