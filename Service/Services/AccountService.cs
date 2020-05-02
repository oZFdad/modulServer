using Dapper;
using Npgsql;
using Service;
using System;

namespace Helper
{
    public interface IAccountService
    {
        public void CreateAccount(int id);
        public void DeleteAccount(string accountNumber);
        public void TransferMoney(string sender, string recipient, decimal sum);
    }
    
    public class AccountService : IAccountService
    {
        private string _connent = ServerParameters.ServerAdres;

        public void CreateAccount(int id)
        {
            var sqlGetAccountNumberRequest = @"SELECT nextval('accountNumber');";
            var sqlInsertNewAccount = @"INSERT INTO public.account_ref
                                        (AccountNumber, UserId, MoneyBalans)
                                        VALUES(@AccountNumber, @UserId, @MoneyBalans);";
            using (var connect = new NpgsqlConnection(_connent))
            {
                var accountNumber = Convert.ToString(connect.QueryFirst(sqlGetAccountNumberRequest));
                connect.Execute(sqlInsertNewAccount,{ });
            }
        }

        public void DeleteAccount(string accountNumber)
        {
            throw new System.NotImplementedException();
        }

        public void TransferMoney(string sender, string recipient, decimal sum)
        {
            throw new System.NotImplementedException();
        }
    }
}