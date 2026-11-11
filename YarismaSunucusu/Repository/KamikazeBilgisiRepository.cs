using Microsoft.EntityFrameworkCore;
using YarismaSunucusu.DBContext;
using YarismaSunucusu.Mapper;
using YarismaSunucusu.Model;

namespace YarismaSunucusu.Repository
{
    public class KamikazeBilgisiRepository
    {
        private readonly YarismaSunucusuDBContext _context;

        public KamikazeBilgisiRepository(YarismaSunucusuDBContext context)
        {
            _context = context;
        }       

        public void AddKamikazeBilgisi(KamikazeBilgisiDTO kamikaze)
        {
            var newKamikaze = new KamikazeBilgisi{
                kamikazeBaslangicZamani = kamikaze.kamikazeBaslangicZamani.toSaat(),
                kamikazeBitisZamani = kamikaze.kamikazeBitisZamani.toSaat(),
                qrMetni = kamikaze.qrMetni,
            };

            _context.KamikazeBilgisis.Add(newKamikaze);
            _context.SaveChanges();
        }

        public async Task<List<KamikazeBilgisiDTO>> GetKamikazeBilgisiAsync()
        {
            var kamikaze = await _context.KamikazeBilgisis
            .Include(k => k.kamikazeBaslangicZamani)
            .Include(k => k.kamikazeBitisZamani)
            .ToListAsync();

            var kamikazeDTO = kamikaze.Select(k => k.toKamikazeBilgisiDTO()).ToList();
            return kamikazeDTO;
        }
    }
}