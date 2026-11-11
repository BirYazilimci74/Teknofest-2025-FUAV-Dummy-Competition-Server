using Microsoft.AspNetCore.Mvc;
using YarismaSunucusu.DBContext;
using YarismaSunucusu.Model;
using YarismaSunucusu.Repository;

namespace YarismaSunucusu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class kamikaze_bilgisiController : ControllerBase
    {
        private readonly YarismaSunucusuDBContext _context;
        private readonly KamikazeBilgisiRepository _kamikazeBilgisiRepository;

        public kamikaze_bilgisiController(YarismaSunucusuDBContext context)
        {
            _context = context;
            _kamikazeBilgisiRepository = new KamikazeBilgisiRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<List<KamikazeBilgisiDTO>>> GetKamikazeBilgisiAsync()
        {
            var kamikaze = await _kamikazeBilgisiRepository.GetKamikazeBilgisiAsync();
            return Ok(kamikaze);
        }

        [HttpPost]
        public ActionResult PostAsync([FromBody] KamikazeBilgisiDTO kamikaze )
        {
            _kamikazeBilgisiRepository.AddKamikazeBilgisi(kamikaze);
            return Ok();
        }
        
    }
}