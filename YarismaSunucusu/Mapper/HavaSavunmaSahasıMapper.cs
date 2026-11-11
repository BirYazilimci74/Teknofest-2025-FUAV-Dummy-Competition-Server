using YarismaSunucusu.DTOs;
using YarismaSunucusu.Model;

namespace YarismaSunucusu.Mapper
{
    public static class HavaSavumaSahasiMapper
    {
        public static HavaSavumaSahasiDTO toHavaSavunmaSahasiDTO(this HavaSavumaSahasi havaSavumaSahasi)
        {
            return new HavaSavumaSahasiDTO{
                sunucusaati = havaSavumaSahasi.sunucusaati.toSunucuSaatiDTO(),
                hss_koordinat_bilgileri = havaSavumaSahasi.hss_koordinat_bilgileri
            };
        }
    }
}