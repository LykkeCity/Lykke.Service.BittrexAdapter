namespace Lykke.Service.BittrexAdapter.Services.RestClient
{
    public struct LykkeInstrument
    {
        public readonly string Value;

        public LykkeInstrument(string value)
        {
            Value = value.Replace("-", "");
        }
    }
}
