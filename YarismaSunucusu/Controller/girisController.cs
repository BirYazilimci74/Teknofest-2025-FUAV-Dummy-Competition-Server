using System.Net.WebSockets;
using Microsoft.AspNetCore.Mvc;
using YarismaSunucusu.Model;

namespace YarismaSunucusu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class girisController : ControllerBase
    {
        [HttpPost]
        public ActionResult GetTakimNumarasi([FromBody] LoginInfo info)
        {
            var response = new {TakimNumarasi = 1};
            return Ok(response);
        }
    }

    public class LoginInfo
    {
        public required string kadi { get; set; }
        public required string sifre { get; set;}
    }
}