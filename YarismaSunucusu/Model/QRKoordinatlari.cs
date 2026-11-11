using System.ComponentModel.DataAnnotations;

namespace YarismaSunucusu.Model
{
    public class QRKoordinatlari
    {
        [Key]
        public int Id { get; set; }
        public double qrEnlem { get; set; }
        public double qrBoylam { get; set; }
    }
}