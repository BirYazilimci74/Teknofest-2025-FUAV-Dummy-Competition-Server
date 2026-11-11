using Microsoft.AspNetCore.Mvc;
using YarismaSunucusu.DBContext;
using YarismaSunucusu.DTOs;
using YarismaSunucusu.Model;
using YarismaSunucusu.Repository;

namespace YarismaSunucusu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class qr_koordinatiController : ControllerBase
    {
        private readonly YarismaSunucusuDBContext _context;
        private readonly QRKoordinatlariRepository _qrKoordinatleriRepository;

        public qr_koordinatiController(YarismaSunucusuDBContext context)
        {
            _context = context;
            _qrKoordinatleriRepository = new QRKoordinatlariRepository(_context);
            
        }

        [HttpGet]
        public async Task<ActionResult<QRKoordinatlariDTO>> GetQrKoordinatiAsync()
        {
            var qr = await _qrKoordinatleriRepository.GetQrKoordinatiAsync();
            return qr;
        }

        //executed once
        //no need any more
        /*
        [HttpPost]
        public async Task PostQRCoordinateAsync()
        {
            await _qrKoordinatleriRepository.PostQRCoordinateAsync();
        }
        */
    }
}