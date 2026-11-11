using YarismaSunucusu.DTOs;
using YarismaSunucusu.Model;

namespace YarismaSunucusu.Mapper
{
    public static class TelemetriPaketiMapper
    {
        public static TelemetriPaketiDTO toTelemetriPaketiDTO(this TelemetriPaketi telemetriPaketi)
        {
            return new TelemetriPaketiDTO{
                takim_numarasi = telemetriPaketi.takim_numarasi,
                iha_enlem = telemetriPaketi.iha_enlem,
                iha_boylam = telemetriPaketi.iha_boylam,
                iha_irtifa = telemetriPaketi.iha_irtifa,
                iha_dikilme = telemetriPaketi.iha_dikilme,
                iha_yonelme = telemetriPaketi.iha_yonelme,
                iha_yatis = telemetriPaketi.iha_yatis,
                iha_hiz = telemetriPaketi.iha_hiz,
                iha_batarya = telemetriPaketi.iha_batarya,
                iha_otonom = telemetriPaketi.iha_otonom,
                iha_kilitlenme = telemetriPaketi.iha_kilitlenme,
                hedef_merkez_X = telemetriPaketi.hedef_merkez_X,
                hedef_merkez_Y = telemetriPaketi.hedef_merkez_Y,
                hedef_genislik = telemetriPaketi.hedef_genislik,
                hedef_yukseklik = telemetriPaketi.hedef_yukseklik,
                gps_saati = telemetriPaketi.gps_saati.toSaatDTO(),
            };
        }

        public static TelemetriPaketi toTelemetriPaketi(this TelemetriPaketiDTO telemetriPaketiDTO)
        {
            return new TelemetriPaketi{
                takim_numarasi = telemetriPaketiDTO.takim_numarasi,
                iha_enlem = telemetriPaketiDTO.iha_enlem,
                iha_boylam = telemetriPaketiDTO.iha_boylam,
                iha_irtifa = telemetriPaketiDTO.iha_irtifa,
                iha_dikilme = telemetriPaketiDTO.iha_dikilme,
                iha_yonelme = telemetriPaketiDTO.iha_yonelme,
                iha_yatis = telemetriPaketiDTO.iha_yatis,
                iha_hiz = telemetriPaketiDTO.iha_hiz,
                iha_batarya = telemetriPaketiDTO.iha_batarya,
                iha_otonom = telemetriPaketiDTO.iha_otonom,
                iha_kilitlenme = telemetriPaketiDTO.iha_kilitlenme,
                hedef_merkez_X = telemetriPaketiDTO.hedef_merkez_X,
                hedef_merkez_Y = telemetriPaketiDTO.hedef_merkez_Y,
                hedef_genislik = telemetriPaketiDTO.hedef_genislik,
                hedef_yukseklik = telemetriPaketiDTO.hedef_yukseklik,
                gps_saati = telemetriPaketiDTO.gps_saati.toSaat()
            };
        }
    }
}