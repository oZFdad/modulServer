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
        private string _connent = "Server=192.168.1.4;Port=5432;User Id=postgres;Password=1;Database=modulbankdb;";
        
        public void CreateAccount(int id)
        {
            
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