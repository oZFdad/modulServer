using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Modul_dz1_mk1.Controllers
{
    [ApiController]
    [Route("Cash")]
    public class CashAccountAction : Controller
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetOK()
        {
            var id = HttpContext.User.Claims.First(c => c.Type == "id").Value;
            return Json(id);
        }
    }
}