using Microsoft.EntityFrameworkCore;
using YarismaSunucusu.Model;

namespace YarismaSunucusu.DBContext
{
    public class YarismaSunucusuDBContext: DbContext
    {
        public YarismaSunucusuDBContext(DbContextOptions<YarismaSunucusuDBContext> options)
        : base(options)
        {
            
        }
        public DbSet<Giris> Girises { get; set; }
        public DbSet<HavaSavumaSahasi> HavaSavumaSahasis { get; set; }
        public DbSet<HssKoordinat> HssKoordinats{ get; set; }
        public DbSet<KamikazeBilgisi> KamikazeBilgisis { get; set; }
        public DbSet<KilitlenmeBilgisi> KilitlenmeBilgis { get; set; }
        public DbSet<KonumBilgisi> KonumBilgisis{ get; set; }
        public DbSet<QRKoordinatlari> QRKoordinatlaris { get; set;}
        public DbSet<SunucuSaati> SunucuSaatis { get; set; }
        public DbSet<Saat> Saats { get; set; }
        public DbSet<TelemetriCevabi> TelemetriCevabis { get; set; }
        public DbSet<TelemetriPaketi> TelemetriPaketis { get; set; }
    }
}