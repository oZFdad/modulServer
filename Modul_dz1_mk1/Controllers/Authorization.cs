using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Service.Services;
using Logic.Handler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.Items;

namespace Modul_dz1_mk1.Controllers
{
    [ApiController]
    [Route("Authorization")]
    public class Authorization : Controller
    {
        [HttpPost]
        public IActionResult AuthorisateUser(AuthorizatInfo authorizatInfo)
        {
            var authorisateRequestHandler = new AuthorisateRequestHandler(new UserService());
            var id = authorisateRequestHandler.Handle(authorizatInfo);
            
            var now = DateTime.UtcNow;
            
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: new []
                {
                    new Claim("id", id.ToString()),
                },
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var JwtString = new JwtSecurityTokenHandler().WriteToken(jwt);
            return Json(JwtString);
        }
    }
}