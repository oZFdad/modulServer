using System;
using Helper;
using Logic.Exceptions;
using Service.Items;

namespace Logic.Handler
{
    public class AuthorisateRequestHandler
    {
        public int Handle(AuthorizatInfo authorizatInfo)
        {
            authorizatInfo.Email = authorizatInfo.Email.ToLower();
            var userService = new UserService();
            var user = userService.GetUserFromTableUser(authorizatInfo.Email);
            if (user == null)
            {
                throw new IncorrectRequestException("Пользователя не существует");
            }
            var verifiedUserHash = Password.GetHashPass(user.Salt, authorizatInfo.Password);
            var coincidence = string.Equals(verifiedUserHash, user.HashPass);
            if (!coincidence)
            {
                throw new IncorrectRequestException("Плохой пароль");
            }

            return user.Id;
        }
    }
}