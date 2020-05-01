using Microsoft.AspNetCore.Mvc;

namespace Modul_dz1_mk1.Controllers
{
    [ApiController]
    [Route("Authorization")]
    public class Authorization : Controller
    {
        [HttpPost]
        public string Set(AuthorizatInfo authorizatInfo)
        {
            return "";
        }
    }

    public class AuthorizatInfo
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}