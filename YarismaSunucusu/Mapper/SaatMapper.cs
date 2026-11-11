using YarismaSunucusu.DTOs;
using YarismaSunucusu.Model;

namespace YarismaSunucusu.Mapper
{
    public static class SaatMapper
    {
        public static SaatDTO toSaatDTO(this Saat saat)
        {
            return new SaatDTO{
                saat = saat.saat,
                dakika = saat.dakika,
                saniye = saat.saniye,
                milisaniye = saat.milisaniye,
            };
        }

        public static SaatDTO toSaatDTO(this SunucuSaati sunucuSaati)
        {
            return new SaatDTO{
                saat = sunucuSaati.saat,
                dakika = sunucuSaati.dakika,
                saniye = sunucuSaati.saniye,
                milisaniye = sunucuSaati.milisaniye
            };
        }

        public static Saat toSaat(this SaatDTO saatDTO)
        {
            return new Saat{
                saat = saatDTO.saat,
                dakika = saatDTO.dakika,
                saniye = saatDTO.saniye,
                milisaniye = saatDTO.milisaniye
            };
        }

        public static SunucuSaatiDTO toSunucuSaatiDTO(this SunucuSaati sunucuSaati)
        {
            return new SunucuSaatiDTO{
                gun = sunucuSaati.gun,
                saat = sunucuSaati.saat,
                dakika = sunucuSaati.dakika,
                saniye = sunucuSaati.saniye,
                milisaniye = sunucuSaati.milisaniye
            };
        }

        public static SunucuSaati toSunucuSaati(this SunucuSaatiDTO sunucuSaatiDTO)
        {
            return new SunucuSaati{
                gun = sunucuSaatiDTO.gun,
                saat = sunucuSaatiDTO.saat,
                dakika = sunucuSaatiDTO.dakika,
                saniye = sunucuSaatiDTO.saniye,
                milisaniye = sunucuSaatiDTO.milisaniye
            };
        }
    }
}