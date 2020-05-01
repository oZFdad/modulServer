using System;
using Helper;
using Logic.Exceptions;
using Service.Items;

namespace Logic.Handler
{
    public class AuthorisateRequestHandler
    {
        public Guid Handle(AuthorizatInfo authorizatInfo)
        {
            // Validate
            var userService = new UserService();
            var user = userService.GetSaltAndHashPassFromTableUser(authorizatInfo.Email);
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
            // Handle
            // Return result
            var token = new Token();
            var tokenService = new TokenService();
            tokenService.InsertToken(token, user.Id);
            
            return token.KeyToken;
        }
    }
}