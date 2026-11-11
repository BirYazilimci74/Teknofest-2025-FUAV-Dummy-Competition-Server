using System.ComponentModel.DataAnnotations;
using YarismaSunucusu.DTOs;

namespace YarismaSunucusu.Model
{
    public class TelemetriCevabiDTO
    {
        public required SunucuSaatiDTO sunucusaati { get; set; }
        public required List<KonumBilgisiDTO> konumBilgileri { get; set; }
    }
}