using System.ComponentModel.DataAnnotations;

namespace YarismaSunucusu.Model
{
    public class SaatDTO
    {
        public int saat { get; set; }
        public int dakika { get; set; }
        public int saniye { get; set; }
        public int milisaniye { get; set; }
    }
}