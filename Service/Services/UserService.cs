using System;
using Dapper;
using Npgsql;
using Service;
using Service.Items;

namespace Helper

{
    public interface IUserService
    {
        public User GetUserFromTableUser(string email);
        public int InsertNewUser(User user);
    }
    public class UserService : IUserService
    {
        private string _connent = ServerParameters.ServerAdres;
        public User GetUserFromTableUser(string email)
        {
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

        public int InsertNewUser(User user)
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