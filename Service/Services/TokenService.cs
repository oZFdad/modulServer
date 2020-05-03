using System;
using Dapper;
using Npgsql;
using Service;
using Service.Items;

namespace Helper
{
    public interface ITokenService // заморожено до лучших времен
    {
        public User GetUserIfTokenAlive(Token token);
        public void InsertToken(Token token, int id);
        public void DeleteToken(Token token);
    }
    
    public class TokenService : ITokenService
    {
        private string _connent = ServerParameters.ServerAdres;

        public User GetUserIfTokenAlive(Token token)
        {
            var time = DateTime.Now;
            var sql = @"SELECT keytoken, lifetime, userid
                         FROM public.token
                         where keytoken = @keytoken;";
            var user = new User();
            using (var connect = new NpgsqlConnection(_connent))
            {
                try
                {
                    token = connect.QueryFirst<Token>(sql, new { keytoken = token.KeyToken });
                }
                catch (Exception e)
                {
                    return null; // нет токена
                }
            }

            if (time > token.LifeTime)
            {
                DeleteToken(token);
                return null; // токен умер
            }

            user.Id = token.UserID;
            return user;
        }

        public void InsertToken(Token token, int id)
        {
            var time = DateTime.Now.AddMinutes(30);
            var sql = @"INSERT INTO public.tokens
                        (KeyToken, LifeTime, UserID)
                        VALUES(@KeyToken, @LifeTime, @UserID);";
            using (var connent = new NpgsqlConnection(_connent))
            {
                connent.Execute(sql, new{KeyToken = token.KeyToken, LifeTime = time, UserID = id});
            }
        }

        public void DeleteToken(Token token) // не проверена работоспособность
        {
            var sql = @"delete from tokens 
                        where KeyToken = @KeyToken;";
            using (var connent = new NpgsqlConnection(_connent))
            {
                connent.Execute(sql, new{KeyToken = token.KeyToken});
            }
        }
    }
}