using Microsoft.EntityFrameworkCore;
using YarismaSunucusu.DBContext;
using YarismaSunucusu.Model;

namespace YarismaSunucusu.Repository
{
    public class HssKoordinatlariRepository
    {
        private readonly YarismaSunucusuDBContext _context;

        public HssKoordinatlariRepository(YarismaSunucusuDBContext context)
        {
            _context = context;
        }

        public async Task<List<HssKoordinat>> GetHssKoordinatAsync()
        {
            var hss = await _context.HssKoordinats.ToListAsync();
            return hss;
        }

        public async Task<HssKoordinat> GetByIdAsync(int id)
        {
            var koordinat = await _context.HssKoordinats.FindAsync(id);
            return koordinat;
        }

        public void AddNewCoordinate(HssKoordinat koordinat)
        {
            var newCoordinate = new HssKoordinat(){
                hssEnlem = koordinat.hssEnlem,
                hssBoylam = koordinat.hssBoylam,
                hssYaricap = koordinat.hssYaricap
            };
            _context.HssKoordinats.Add(newCoordinate);
            _context.SaveChanges();
        }
    }
}