using System;
using System.Security.Cryptography;
using System.Text;

namespace Helper
{
    public class Password
    {
        public string Salt { get; }
        public string HashPass { get; }
        
        public Password(string password)
        {
            Salt = Guid.NewGuid().ToString().Substring(0, 8);
            using (MD5 md5 = MD5.Create())
            {
                byte[] input = Encoding.ASCII.GetBytes(string.Concat(password, Salt));
                byte[] hash = md5.ComputeHash(input);
                var s1 = new StringBuilder();
                foreach (var b in hash)
                {
                    s1.Append(b.ToString("X2"));
                }

                HashPass = s1.ToString();
            }
        }

        public static bool IsPasswordTrue(string password, string testUserSalt, string testUserPassword)
        {
            throw new NotImplementedException();
        }
    }
}