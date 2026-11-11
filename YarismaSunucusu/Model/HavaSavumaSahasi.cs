using System.ComponentModel.DataAnnotations;

namespace YarismaSunucusu.Model
{
    public class HavaSavumaSahasi
    {
        [Key]
        public int Id { get; set; }
        public required SunucuSaati sunucusaati { get; set; }
        public required List<HssKoordinat> hss_koordinat_bilgileri { get; set; }
    }
}