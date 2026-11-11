using Microsoft.EntityFrameworkCore;
using YarismaSunucusu.DBContext;
using YarismaSunucusu.Mapper;
using YarismaSunucusu.Model;

namespace YarismaSunucusu.Repository
{
    public class KilitlenmeBilgisiRepository
    {
        private readonly YarismaSunucusuDBContext _context;

        public KilitlenmeBilgisiRepository(YarismaSunucusuDBContext context)
        {
            _context = context;
        }

        public void AddKilitlenmeBilgisi(KilitlenmeBilgisiDTO kilitlenme)
        {
            var newKilitlenme = new KilitlenmeBilgisi{
                kilitlenmeBaslangicZamani = kilitlenme.kilitlenmeBaslangicZamani.toSaat(),
                kilitlenmeBitisZamani = kilitlenme.kilitlenmeBitisZamani.toSaat(),
                otonom_kilitlenme = kilitlenme.otonom_kilitlenme
            };

            _context.KilitlenmeBilgis.Add(newKilitlenme);
            _context.SaveChanges();
        }

        public async Task<List<KilitlenmeBilgisiDTO>> GetKilitlenmeAsync()
        {
            var kilitlenme = await _context.KilitlenmeBilgis
            .Include(k => k.kilitlenmeBaslangicZamani)
            .Include(k => k.kilitlenmeBitisZamani)
            .ToListAsync();

            var kilitlenmeDTO = kilitlenme.Select(k => k.toKilitlenmeBilgisiDTO()).ToList();

            return kilitlenmeDTO;
        }
    }
}