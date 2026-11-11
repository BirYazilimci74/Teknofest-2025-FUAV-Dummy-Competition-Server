using System.ComponentModel.DataAnnotations;

namespace YarismaSunucusu.Model
{
    public class HssKoordinat
    {
        [Key]
        public int id { get; set; } 
        public double hssEnlem { get; set; }
        public double hssBoylam { get; set; }
        public double hssYaricap { get; set; }
    }
}