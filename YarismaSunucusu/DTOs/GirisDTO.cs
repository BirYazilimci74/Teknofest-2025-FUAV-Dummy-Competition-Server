using System.ComponentModel.DataAnnotations;

namespace YarismaSunucusu.Model
{
    public class GirisDTO
    {
        public required string kadi { get; set; }
        public required string sifre { get; set; }
    }
}