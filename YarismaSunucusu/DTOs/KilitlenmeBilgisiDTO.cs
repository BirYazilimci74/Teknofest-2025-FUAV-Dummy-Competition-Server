using System.ComponentModel.DataAnnotations;

namespace YarismaSunucusu.Model
{
    public class KilitlenmeBilgisiDTO
    {
        public required SaatDTO kilitlenmeBaslangicZamani { get; set; }
        public required SaatDTO kilitlenmeBitisZamani { get; set; }
        public int otonom_kilitlenme { get; set; }
    }
}