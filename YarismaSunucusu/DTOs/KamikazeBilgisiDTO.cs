using System.ComponentModel.DataAnnotations;

namespace YarismaSunucusu.Model
{
    public class KamikazeBilgisiDTO
    {
        public required SaatDTO kamikazeBaslangicZamani { get; set; }
        public required SaatDTO kamikazeBitisZamani { get; set; }
        public required string qrMetni { get; set; }
    }
}