using System.ComponentModel.DataAnnotations;

namespace YarismaSunucusu.Model
{
    public class Giris
    {
        [Key]
        public int Id { get; set; }
        public required string kadi { get; set; }
        public required string sifre { get; set; }
    }
}