using System.ComponentModel.DataAnnotations;

namespace YarismaSunucusu.Model
{
    public class KilitlenmeBilgisi
    {
        [Key]
        public int Id { get; set; }
        public required Saat kilitlenmeBaslangicZamani { get; set; }
        public required Saat kilitlenmeBitisZamani { get; set; }
        public int otonom_kilitlenme { get; set; }
    }
}