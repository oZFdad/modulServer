using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Modul_dz1_mk1
{
    public class AuthOptions
    {
        public const string ISSUER = "localhost"; // издатель токена
        public const string AUDIENCE = "localhost"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
        public const int LIFETIME = 30; // время жизни токена min
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}