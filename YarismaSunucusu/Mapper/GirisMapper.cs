using YarismaSunucusu.DTOs;
using YarismaSunucusu.Model;

namespace YarismaSunucusu.Mapper
{
    public static class GirisMapper
    {
        public static GirisDTO toGirisDTO(this Giris giris)
        {
            return new GirisDTO{
                kadi = giris.kadi,
                sifre = giris.sifre,
            };
        }
    }
}