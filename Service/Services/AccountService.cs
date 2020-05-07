using Dapper;
using Npgsql;

namespace Service.Services
{
    public interface IAccountService
    {
        public void CreateAccount(int id);
        public void DeleteAccount(string accountNumber);
        public void TransferMoney(string sender, string recipient, decimal sum);
        public void ReplenishBalanceMoney(string accountNumber, decimal sum);
        public int GetUserIdWhereSetAccountNumber(string accountNumber);
    }
    
    public class AccountService : IAccountService
    {
        private string _connent = ServerParameters.ServerAdres;

        public void CreateAccount(int id)
        {
            decimal balans = 0;
            var sqlGetAccountNumberRequest = "SELECT nextval('accountNumber');";
            var sqlInsertNewAccount = @"INSERT INTO public.account_ref
                                        (AccountNumber, UserId, MoneyBalans)
                                        VALUES(@AccountNumber, @UserId, @MoneyBalans);";
            using (var connect = new NpgsqlConnection(_connent))
            {
                var accountNumber = connect.QuerySingle<long>(sqlGetAccountNumberRequest).ToString();
                connect.Execute(sqlInsertNewAccount, new {accountNumber, userId = id, moneyBalans = balans});
            }
        }

        public void DeleteAccount(string accountNumber)
        {
            throw new System.NotImplementedException();
        }

        public void TransferMoney(string sender, string recipient, decimal sum)
        {
            var sqlTransferMoneySender = @"update public.account_ref set moneybalans = moneybalans - @moneybalans
                                    where accountnumber = @accountnumber;";
            var sqlsqlTransferMoneyRecipient = @"update public.account_ref set moneybalans = moneybalans + @moneybalans
                        where accountnumber = @accountnumber;";
            using (var connect = new NpgsqlConnection(_connent))
            {
                connect.Open();
                using (var transaction = connect.BeginTransaction())
                {
                    connect.Execute(sqlTransferMoneySender, new {accountnumber = sender, moneybalans = sum});
                    //throw new Exception("test");
                    connect.Execute(sqlsqlTransferMoneyRecipient, new {accountnumber = recipient, moneybalans = sum});
                    transaction.Commit();
                }
            }
        }

        public void ReplenishBalanceMoney(string accountNumber, decimal sum)
        {
            var sqlReplenishBalanceMoney = @"update public.account_ref set moneybalans = moneybalans + @moneybalans
                                            where accountnumber = @accountnumber;";
            using (var connect = new NpgsqlConnection(_connent))
            {
                connect.Execute(sqlReplenishBalanceMoney, new {accountnumber = accountNumber, moneybalans = sum});
            }
        }

        public int GetUserIdWhereSetAccountNumber(string accountNumber)
        {
            int id;
            var sqlValidate = @"SELECT userid
                         FROM public.account_ref
                         where accountnumber = @accountNumber;";
            using (var connect = new NpgsqlConnection(_connent))
            {
                id = connect.QuerySingle<int>(sqlValidate);
            }

            return id;
        }
    }
}