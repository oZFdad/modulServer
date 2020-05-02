using System;
using Helper;
using Logic.Exceptions;
using Service.Items;

namespace Logic.Handler
{
    public class RegInfoRequestHandler
    {
        private bool RegValidate(RegistrInfo registrInfo)
        {
            if (!IsEmailValid(registrInfo.Email)) throw new IncorrectRequestException("плохой адрес");
            if (string.IsNullOrEmpty(registrInfo.Name)) throw new IncorrectRequestException("нет имени");
            if (string.IsNullOrEmpty(registrInfo.Password)) throw new IncorrectRequestException("нет пароля");
            if (string.IsNullOrEmpty(registrInfo.RePassword)) throw new IncorrectRequestException("нет второго пароля");
            if (!string.Equals(registrInfo.Password, registrInfo.RePassword))
                throw new IncorrectRequestException("не совпадают пароли");
            return true;
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

        public Guid Handle(RegistrInfo registrInfo)
        {
            // Validate
            RegValidate(registrInfo);
            
            // Handle
            var userService = new UserService();
            
            int id;
            var user = userService.GetSaltAndHashPassFromTableUser(registrInfo.Email);
            if (user != null)
            {
                throw new IncorrectRequestException("Пользователь уже существует");
            }
            else
            {
                user = new User();
                user.Email = registrInfo.Email;
                user.Salt = Password.GetSalt();
                user.HashPass = Password.GetHashPass(user.Salt, registrInfo.Password);
                id = userService.InsertNewUser(user);
            }
            // Return result
            var token = new Token();
            var tokenService = new TokenService();
            tokenService.InsertToken(token, id);
            return token.KeyToken;
        }
    }
}