using Microsoft.AspNetCore.Mvc;
using YarismaSunucusu.DBContext;
using YarismaSunucusu.DTOs;
using YarismaSunucusu.Model;
using YarismaSunucusu.Repository;

namespace YarismaSunucusu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sunucusaatiController : ControllerBase
    {
        private readonly YarismaSunucusuDBContext _context;
        private readonly SunucuSaatiRepository _sunucuSaatiRepository;

        public sunucusaatiController(YarismaSunucusuDBContext context)
        {
            _context = context;
            _sunucuSaatiRepository = new SunucuSaatiRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<SunucuSaatiDTO>> GetSunucuSaatiAsync()
        {
            return await _sunucuSaatiRepository.GetSunucuSaatiAsync();
        }

        /*
        I execute this method once to add time to database.
        Now the time data is updating.
        No need new one.
        
        [HttpPost]
        public async Task<ActionResult> PostSunucuSaatiAsync()
        {
            return await _sunucuSaatiRepository.PostSunucuSaatiAsync();
        }
        */
        
        [HttpPut]
        public async Task<ActionResult> UpdateTimeAsync(int gun, int saat, int dakika, int saniye, int milisaniye)
        {
            return await _sunucuSaatiRepository.UpdateTimeAsync(gun, saat, dakika, saniye, milisaniye);
        }
    }
}