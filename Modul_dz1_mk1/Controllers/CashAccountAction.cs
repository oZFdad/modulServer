using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Modul_dz1_mk1.Controllers
{
    [ApiController]
    [Route("Cash")]
    
    public class CashAccountAction
    {
        [Authorize]
        [HttpGet]
        public string Get()
        {
            return "ok";
        }
    }
}