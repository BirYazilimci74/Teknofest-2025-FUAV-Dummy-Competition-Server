using YarismaSunucusu.DTOs;
using YarismaSunucusu.Model;

namespace YarismaSunucusu.Mapper
{
    public static class KonumBilgisiMapper
    {
        public static KonumBilgisiDTO toKonumBilgisiDTO(this KonumBilgisi konumBilgisi)
        {
            return new KonumBilgisiDTO{
                takim_numarasi = konumBilgisi.takim_numarasi,
                iha_enlem = konumBilgisi.iha_enlem,
                iha_boylam = konumBilgisi.iha_boylam,
                iha_irtifa = konumBilgisi.iha_irtifa,
                iha_dikilme = konumBilgisi.iha_dikilme,
                iha_yonelme = konumBilgisi.iha_yonelme,
                iha_yatis = konumBilgisi.iha_yatis,
                iha_hizi = konumBilgisi.iha_hizi,
                zaman_farki = konumBilgisi.zaman_farki
            };
        }
    }
}