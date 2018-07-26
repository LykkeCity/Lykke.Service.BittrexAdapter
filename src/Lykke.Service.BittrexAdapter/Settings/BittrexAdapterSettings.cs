using JetBrains.Annotations;
using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.BittrexAdapter.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class BittrexAdapterSettings
    {
        public DbSettings Db { get; set; }
    }
}
