using System.ComponentModel.DataAnnotations;

namespace YarismaSunucusu.Model
{
    public class TelemetriCevabi
    {
        [Key]
        public int Id { get; set; }
        public required SunucuSaati sunucusaati { get; set; }
        public required List<KonumBilgisi> konumBilgileri { get; set; }
    }
}