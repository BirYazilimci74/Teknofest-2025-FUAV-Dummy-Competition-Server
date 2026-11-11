using System.ComponentModel.DataAnnotations;

namespace YarismaSunucusu.Model
{
    public class SunucuSaati
    {
        [Key]
        public int Id { get; set; }
        public int gun { get; set; }
        public int saat { get; set; }
        public int dakika { get; set; }
        public int saniye { get; set; }
        public int milisaniye { get; set; }
    }
}