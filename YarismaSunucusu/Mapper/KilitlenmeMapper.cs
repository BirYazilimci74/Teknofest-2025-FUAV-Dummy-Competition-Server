using YarismaSunucusu.Model;

namespace YarismaSunucusu.Mapper
{
    public static class KilitlenmeBilgisiMapper
    {
        public static KilitlenmeBilgisiDTO toKilitlenmeBilgisiDTO(this KilitlenmeBilgisi kilitlenmeBilgisi)
        {
            return new KilitlenmeBilgisiDTO{
                kilitlenmeBaslangicZamani = kilitlenmeBilgisi.kilitlenmeBaslangicZamani.toSaatDTO(),
                kilitlenmeBitisZamani = kilitlenmeBilgisi.kilitlenmeBitisZamani.toSaatDTO(),
                otonom_kilitlenme = kilitlenmeBilgisi.otonom_kilitlenme
            };
        }
    }
}