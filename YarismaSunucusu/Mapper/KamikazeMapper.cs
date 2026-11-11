using YarismaSunucusu.DTOs;
using YarismaSunucusu.Model;

namespace YarismaSunucusu.Mapper
{
    public static class KamikazeBilgisiMapper
    {
        public static KamikazeBilgisiDTO toKamikazeBilgisiDTO(this KamikazeBilgisi kamikazeBilgisi)
        {
            return new KamikazeBilgisiDTO{
                kamikazeBaslangicZamani = kamikazeBilgisi.kamikazeBaslangicZamani.toSaatDTO(),
                kamikazeBitisZamani = kamikazeBilgisi.kamikazeBitisZamani.toSaatDTO(),
                qrMetni = kamikazeBilgisi.qrMetni
            };
        }
    }
}