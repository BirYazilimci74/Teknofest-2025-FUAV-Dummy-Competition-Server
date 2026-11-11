using YarismaSunucusu.DTOs;
using YarismaSunucusu.Model;

namespace YarismaSunucusu.Mapper
{
    public static class TelemetriCevabiMapper
    {
        public static TelemetriCevabiDTO toTelemetriCevabiDTO(this TelemetriCevabi telemetriCevabi)
        {
            return new TelemetriCevabiDTO{
                sunucusaati = telemetriCevabi.sunucusaati.toSunucuSaatiDTO(),
                konumBilgileri = telemetriCevabi.konumBilgileri.Select(k => k.toKonumBilgisiDTO()).ToList()
            };
        }
    }
}