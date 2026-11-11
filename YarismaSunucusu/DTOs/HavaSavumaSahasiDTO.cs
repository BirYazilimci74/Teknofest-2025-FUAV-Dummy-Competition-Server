using System.ComponentModel.DataAnnotations;
using YarismaSunucusu.DTOs;

namespace YarismaSunucusu.Model
{
    public class HavaSavumaSahasiDTO
    {
        public required SunucuSaatiDTO sunucusaati { get; set; }
        public required List<HssKoordinat> hss_koordinat_bilgileri { get; set; }
    }
}