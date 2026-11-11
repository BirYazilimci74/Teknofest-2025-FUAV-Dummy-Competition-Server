using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YarismaSunucusu.Controllers;
using YarismaSunucusu.DBContext;
using YarismaSunucusu.DTOs;
using YarismaSunucusu.Mapper;
using YarismaSunucusu.Model;

namespace YarismaSunucusu.Repository
{
    public class SunucuSaatiRepository
    {
        private readonly YarismaSunucusuDBContext _context;
        public SunucuSaatiRepository(YarismaSunucusuDBContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<SunucuSaatiDTO>> GetSunucuSaatiAsync()
        {
            var sunucuSaati = await _context.SunucuSaatis.FirstOrDefaultAsync();
            var sunucuSaatiDTO = sunucuSaati?.toSunucuSaatiDTO();

            if (sunucuSaatiDTO == null)
            {
                return new SunucuSaatiDTO(){
                    gun = DateTime.Now.Day,
                    saat = DateTime.Now.Hour,
                    dakika = DateTime.Now.Minute,
                    saniye = DateTime.Now.Second,
                    milisaniye = DateTime.Now.Millisecond
                };
            }
            return sunucuSaatiDTO;
        }

        public async Task<ActionResult> PostSunucuSaatiAsync()
        {
            try
            {
                var currentTime = DateTime.Now;
                
                var sunucuSaati = new SunucuSaati
                {
                    gun = currentTime.Day,
                    saat = currentTime.Hour,
                    dakika = currentTime.Minute,
                    saniye = currentTime.Second,
                    milisaniye = currentTime.Millisecond
                };

                await UpdateTimeAsync(currentTime.Day, currentTime.Hour, currentTime.Minute, currentTime.Second, currentTime.Millisecond);
                await _context.SunucuSaatis.AddAsync(sunucuSaati);
                await _context.SaveChangesAsync();

                return new OkObjectResult(sunucuSaati);
            }
            catch (Exception ex)
            {
                return new ObjectResult(new { Message = "Sunucu saati kaydedilemedi.", Error = ex.Message })
                {
                    StatusCode = 500
                };
            }
        }

        public async Task<ActionResult> UpdateTimeAsync(int gun, int saat, int dakika, int saniye, int milisaniye)
        {
            try
            {
                var sunucuSaati = await _context.SunucuSaatis.FirstOrDefaultAsync();

                if (sunucuSaati == null)
                {
                    return new NotFoundResult();
                }

                sunucuSaati.gun = gun;
                sunucuSaati.saat = saat;
                sunucuSaati.dakika = dakika;
                sunucuSaati.saniye = saniye;
                sunucuSaati.milisaniye = milisaniye;

                _context.SunucuSaatis.Update(sunucuSaati);
                await _context.SaveChangesAsync();

                return new OkResult();
            }
            catch (Exception ex)
            {
                return new ObjectResult(new { Message = "Sunucu saati güncellenemedi.", Error = ex.Message })
                {
                    StatusCode = 500
                };
            }
        }

        public async Task PeriodicUpdateTimeAsync(CancellationToken cancellationToken, TimeSpan interval)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var currentTime = DateTime.Now;
                    
                    await UpdateTimeAsync(currentTime.Day, currentTime.Hour, currentTime.Minute, currentTime.Second, currentTime.Millisecond);
                    await Task.Delay(interval, cancellationToken);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}