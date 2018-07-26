using JetBrains.Annotations;
using Lykke.Sdk.Settings;

namespace Lykke.Service.BittrexAdapter.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings : BaseAppSettings
    {
        public BittrexAdapterSettings BittrexAdapterService { get; set; }        
    }
}
