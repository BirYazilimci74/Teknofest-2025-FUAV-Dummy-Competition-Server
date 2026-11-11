using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YarismaSunucusu.DBContext;
using YarismaSunucusu.Model;
using YarismaSunucusu.Repository;

namespace YarismaSunucusu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class telemetri_cevabiController : ControllerBase
    {
        private readonly YarismaSunucusuDBContext _context;
        private readonly SunucuSaatiRepository _sunucuSaatiRepository;
        private readonly TelemetriCevabiRepository _telemetriCevabiRepository;

        public telemetri_cevabiController(YarismaSunucusuDBContext context)
        {
            _context = context;
            _sunucuSaatiRepository = new SunucuSaatiRepository(_context);
            _telemetriCevabiRepository = new TelemetriCevabiRepository(_context);
        }
        
        [HttpGet]
        public async Task<ActionResult<TelemetriCevabiDTO>> GetTelemetri()
        {
            var telemetriCevabi = await _telemetriCevabiRepository.GetTelemetriCevabiDTOAsync();
            return Ok(telemetriCevabi);
        }

        /*
        For Initial TelemetriCevabi
        [HttpPost]
        public async Task<ActionResult> PostInitial()
        {
            var sunucuSaati = await _sunucuSaatiRepository.GetSunucuSaatiAsync();
            await _context.TelemetriCevabis.AddAsync(new TelemetriCevabi(){
                sunucusaati = sunucuSaati.Value,
                konumBilgileri = new List<KonumBilgisi>()
            });
            await _context.SaveChangesAsync();
            return Ok();
        }
        */
    }
}