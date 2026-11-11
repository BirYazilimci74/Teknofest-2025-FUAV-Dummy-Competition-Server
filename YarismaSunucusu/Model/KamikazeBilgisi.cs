using System.ComponentModel.DataAnnotations;

namespace YarismaSunucusu.Model
{
    public class KamikazeBilgisi
    {
        [Key]
        public int Id { get; set; }
        public required Saat kamikazeBaslangicZamani { get; set; }
        public required Saat kamikazeBitisZamani { get; set; }
        public required string qrMetni { get; set; }
    }
}