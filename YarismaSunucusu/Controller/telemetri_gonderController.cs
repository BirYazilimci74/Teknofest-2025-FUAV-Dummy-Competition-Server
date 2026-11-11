using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YarismaSunucusu.DBContext;
using YarismaSunucusu.Model;
using YarismaSunucusu.Repository;

namespace YarismaSunucusu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class telemetri_gonderController : ControllerBase
    {
        private readonly YarismaSunucusuDBContext _context;
        private readonly TelemetriPaketiRepository _telemetriPaketiRepository;
        private readonly SunucuSaatiRepository _sunucuSaatiRepository;
        private readonly TelemetriCevabiRepository _telemetriCevabiRepository;

        public telemetri_gonderController(YarismaSunucusuDBContext context)
        {
            _context = context;
            _telemetriPaketiRepository = new TelemetriPaketiRepository(_context);
            _sunucuSaatiRepository = new SunucuSaatiRepository(_context);
            _telemetriCevabiRepository = new TelemetriCevabiRepository(_context);
        }
        
        [HttpGet]
        public async Task<ActionResult<List<TelemetriPaketiDTO>>> GetTelemetriPaketiAsync()
        {
            var telemetriPaketi = await _telemetriPaketiRepository.GetTelemetriPaketiAsync();
            return Ok(telemetriPaketi);
        }
        
        [HttpPost]
        public async Task<ActionResult> AddTelemetriPaketi(TelemetriPaketi newTelemetriPaketi)
        {
            var sunucuSaati = await _sunucuSaatiRepository.GetSunucuSaatiAsync();

            //New Telemetry Package to send
            newTelemetriPaketi.gps_saati = new Saat{
                saat = sunucuSaati.Value.saat,
                dakika = sunucuSaati.Value.dakika,
                saniye = sunucuSaati.Value.saniye,
                milisaniye = sunucuSaati.Value.milisaniye
            };
            await _telemetriPaketiRepository.SendTelemetriPaketiAsync(newTelemetriPaketi);

            var telemetriCevabi = await _telemetriCevabiRepository.GetTelemetriCevabiDTOAsync();
            return Ok(telemetriCevabi);
        }
    }
}