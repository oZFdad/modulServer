using Service.Services;
using Logic.Handler;
using Microsoft.AspNetCore.Mvc;
using Service.Items;

namespace Modul_dz1_mk1.Controllers
{
    [ApiController]
    [Route("Registration")]
    public class Registration : Controller
    {
        [HttpPost]
        public void RegisterUser(RegistrInfo registrInfo)
        {
            var regInfoRequestHandler = new RegInfoRequestHandler(new UserService());
            regInfoRequestHandler.Handle(registrInfo);
        }
    }
    
}