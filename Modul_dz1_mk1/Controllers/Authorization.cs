using System;
using Helper;
using Logic.Handler;
using Microsoft.AspNetCore.Mvc;
using Service.Items;

namespace Modul_dz1_mk1.Controllers
{
    [ApiController]
    [Route("Authorization")]
    public class Authorization : Controller
    {
        [HttpPost]
        public Guid AuthorisateUser(AuthorizatInfo authorizatInfo)
        {
            var authorisateRequestHandler = new AuthorisateRequestHandler();
            return authorisateRequestHandler.Handle(authorizatInfo);
        }
    }
}