using System;
using System.Linq;
using Logic.Handler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Items;
using Service.Services;

namespace Modul_dz1_mk1.Controllers
{
    [ApiController]
    [Route("Transfer")]
    public class Transfer : Controller
    {
        [Authorize]
        [HttpPost]
        public IActionResult TransferNoney(TransferMoney transferMoney)
        {
            var transferHandler = new TransferHandler(new AccountService());
            var id = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == "id").Value);
            transferHandler.Handle(transferMoney, id);
            return null;
        }
    }
}