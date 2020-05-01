using System;
using System.Security.Cryptography;
using System.Text;

namespace Logic
{
    public class Password
    {
        public static string GetSalt()
        {
            var salt = Guid.NewGuid().ToString().Substring(0, 8);
            return salt;
        }

        public static string GetHashPass(string salt, string password)
        {
            string hashString;
            using (MD5 md5 = MD5.Create())
            {
                var input = Encoding.ASCII.GetBytes(string.Concat(password, salt));
                var hash = md5.ComputeHash(input);
                var s = new StringBuilder();
                foreach (var b in hash)
                {
                    s.Append(b.ToString("X2"));
                }

                hashString = s.ToString();
            }

            return hashString;
        }
    }
}