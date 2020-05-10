using Logic.Handler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Items;
using Service.Services;

namespace Modul_dz1_mk1.Controllers
{
    [ApiController]
    [Route("ReplanishAcc")]
    public class ReplanishAccount : Controller
    {
        [Authorize]
        [HttpPost]
        public IActionResult Deposit(ReplenishBalance deposit)
        {
            var replanishAccauntHandler = new ReplanishBalansHandler(new AccountService());
            replanishAccauntHandler.Handle(deposit);
            return Ok();
        }
    }
}