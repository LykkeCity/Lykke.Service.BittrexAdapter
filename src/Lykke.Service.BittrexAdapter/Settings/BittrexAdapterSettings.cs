using JetBrains.Annotations;
using Lykke.Service.BittrexAdapter.Services;
using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.BittrexAdapter.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class BittrexAdapterSettings
    {
        public DbSettings Db { get; set; }
        public BittrexOrderBookPublishingSettings OrderBooks { get; set; }
    }
}
