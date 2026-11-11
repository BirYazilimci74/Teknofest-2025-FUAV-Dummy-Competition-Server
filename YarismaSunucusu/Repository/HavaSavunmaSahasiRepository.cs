using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YarismaSunucusu.DBContext;
using YarismaSunucusu.DTOs;
using YarismaSunucusu.Mapper;
using YarismaSunucusu.Model;

namespace YarismaSunucusu.Repository
{
    public class HavaSavunmaSahasiRepository
    {
        private readonly YarismaSunucusuDBContext _context;
        private readonly SunucuSaatiRepository _sunucuSaatiRepository;
        private readonly HssKoordinatlariRepository _hssKoordinatlariRepository;

        public HavaSavunmaSahasiRepository(YarismaSunucusuDBContext context)
        {
            _context = context;
            _sunucuSaatiRepository = new SunucuSaatiRepository(_context);
            _hssKoordinatlariRepository = new HssKoordinatlariRepository(_context);
        }

        public async Task<ActionResult<HavaSavumaSahasiDTO>> GetHavaSavunmaSahasiAsync()
        {
            var havaSavumaSahasi = await _context.HavaSavumaSahasis
            .Include(hss => hss.sunucusaati)
            .Include(hss => hss.hss_koordinat_bilgileri)
            .FirstOrDefaultAsync(hss => hss.Id == 1);
            
            var havaSavumaSahasiDTO = havaSavumaSahasi?.toHavaSavunmaSahasiDTO();

            if (havaSavumaSahasiDTO == null)
            {
                var saat = await _sunucuSaatiRepository.GetSunucuSaatiAsync();
                var defaultTime = new SunucuSaatiDTO{
                    gun = DateTime.Now.Day,
                    saat = DateTime.Now.Hour,
                    dakika = DateTime.Now.Minute,
                    saniye = DateTime.Now.Second,
                    milisaniye = DateTime.Now.Millisecond
                };
                
                return new HavaSavumaSahasiDTO(){
                    sunucusaati = saat?.Value ?? defaultTime,
                    hss_koordinat_bilgileri = await _hssKoordinatlariRepository.GetHssKoordinatAsync()
                };
            }
            return havaSavumaSahasiDTO;
        }

        public async Task AddNewCoordinateToHssAsync(HssKoordinat koordinat)
        {
            var hss = await GetHavaSavunmaSahasiAsync();
            var newCoordinate = new HssKoordinat{
                hssEnlem = koordinat.hssEnlem,
                hssBoylam = koordinat.hssBoylam,
                hssYaricap = koordinat.hssYaricap
            };

            hss?.Value?.hss_koordinat_bilgileri.Add(newCoordinate);
            await _context.SaveChangesAsync();
        }
    }
}