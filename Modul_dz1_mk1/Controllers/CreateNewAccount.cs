using System;
using System.Linq;
using Service.Services;
using Logic.Handler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Modul_dz1_mk1.Controllers
{
    [ApiController]
    [Route("NewAcc")]
    public class CreateNewAccount : Controller
    {
        [Authorize]
        [HttpGet]
        public IActionResult CreateAccount()
        {
            var id = HttpContext.User.Claims.First(c => c.Type == "id").Value;
            var createAccountHandler = new CreateNewAccountHandler(new AccountService());
            createAccountHandler.Handle(Convert.ToInt32(id));
            return null;
        }
    }
}