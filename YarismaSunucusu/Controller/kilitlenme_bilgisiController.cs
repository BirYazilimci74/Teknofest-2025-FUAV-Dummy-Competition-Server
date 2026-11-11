using Microsoft.AspNetCore.Mvc;
using YarismaSunucusu.DBContext;
using YarismaSunucusu.Model;
using YarismaSunucusu.Repository;

namespace YarismaSunucusu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class kilitlenme_bilgisiController : ControllerBase
    {
        private readonly YarismaSunucusuDBContext _context;
        private readonly KilitlenmeBilgisiRepository _kilitlenmeBilgisiRepository;

        public kilitlenme_bilgisiController(YarismaSunucusuDBContext context)
        {
            _context = context;
            _kilitlenmeBilgisiRepository = new KilitlenmeBilgisiRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<List<KilitlenmeBilgisiDTO>>> GetKilitlenmeAsync()
        {
            var kilitlenme = await _kilitlenmeBilgisiRepository.GetKilitlenmeAsync();
            return Ok(kilitlenme);
        }
        
        [HttpPost]
        public ActionResult AddKilitlenmeBilgisi([FromBody] KilitlenmeBilgisiDTO kilitlenme)
        {
            _kilitlenmeBilgisiRepository.AddKilitlenmeBilgisi(kilitlenme);
            return Ok();
        }
    }
}