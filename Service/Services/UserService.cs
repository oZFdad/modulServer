using System;
using Dapper;
using Npgsql;
using Service.Items;

namespace Helper

{
    public interface IUserService
    {
        public User GetSaltAndHashPassFromTableUser(string email);
        public int InsertNewUser(User user);
    }
    public class UserService : IUserService
    {
        private string _connent = "Server=192.168.1.4;Port=5432;User Id=postgres;Password=1;Database=modulbankdb;";
        public User GetSaltAndHashPassFromTableUser(string email)
        {
            email = email.ToLower();
            var sql = @"SELECT ID, Email, Salt, HashPass
                         FROM public.User_ref
                         where Email = @email;";
            User result;
            using (var connect = new NpgsqlConnection(_connent))
            {
                try
                {
                    result = connect.QueryFirst<User>(sql, new { email = email });
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            return result;
        }

        public int InsertNewUser(User user) // не сделано
        {
            var sql = @"INSERT INTO public.User_ref
                        (Email, Salt, HashPass)
                        VALUES(@email, @salt, @hashpass)
                        returning id;";
            int id;
            using (var connent = new NpgsqlConnection(_connent))
            {
                id = connent.QueryFirst<int>(sql, new{email = user.Email, salt = user.Salt, hashpass = user.HashPass});
            }

            return id;
        }
    }
}