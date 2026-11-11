using Microsoft.AspNetCore.Mvc;
using YarismaSunucusu.DBContext;
using YarismaSunucusu.Model;
using YarismaSunucusu.Repository;

namespace YarismaSunucusu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class hss_koordinatlariController : ControllerBase
    {
        private readonly YarismaSunucusuDBContext _context;
        private readonly HavaSavunmaSahasiRepository _havaSavumaSahasiRepository;

        public hss_koordinatlariController(YarismaSunucusuDBContext context)
        {
            _context = context;
            _havaSavumaSahasiRepository = new HavaSavunmaSahasiRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<HavaSavumaSahasiDTO>> GetHavaSavunmaSahasiAsync()
        {
            var hss = await _havaSavumaSahasiRepository.GetHavaSavunmaSahasiAsync();
            return hss;
        }

        [HttpPost]
        public async Task<ActionResult> AddNewCoordinateAsync([FromBody] HssKoordinat koordinat)
        {
            await _havaSavumaSahasiRepository.AddNewCoordinateToHssAsync(koordinat);
            return Ok();
        }

        /*
        [HttpDelete]
        public async Task DeleteHssKoordinatAsync(int id)
        {
            var DeleteHssKoordinat = await _hssKoordinatlariRepository.GetByIdAsync(id);
            _context.HssKoordinats.Remove(DeleteHssKoordinat);
            await _context.SaveChangesAsync();
        }*/
    }
}