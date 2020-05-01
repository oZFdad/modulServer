
using System;
using Logic.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Modul_dz1_mk1.Controllers
{
    [ApiController]
    [Route("Registration")]
    public class Registration : Controller
    {
        [HttpPost]
        
        public string Set(RegistrInfo registrInfo)
        {
            if (!IsEmailValid(registrInfo.Email)) throw new IncorrectRequestException("плохой адрес");
            if (string.IsNullOrEmpty(registrInfo.Name))  throw new Exception("нет имени");
            if (string.IsNullOrEmpty(registrInfo.Password)) throw new IncorrectRequestException("нет пароля");
            if (string.IsNullOrEmpty(registrInfo.RePassword)) throw new IncorrectRequestException("нет второго пароля");
            if (!string.Equals(registrInfo.Password, registrInfo.RePassword)) throw new IncorrectRequestException("не совпадают пароли");
                
            return "все ОК";
        }

        private bool IsEmailValid(string email)
        {
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public class RegistrInfo
        {
            public string Email { get; set; }
            public string Name { get; set; }
            public string Password { get; set; }
            public string RePassword { get; set; }
        }
    }
}