namespace Helper
{
    public class User
    {
        private Password _password;
        public string Username { get; set; }

        public string Password => _password.HashPass;
        public string Salt => _password.Salt;

        public User(string username, string password)
        {
            Username = username;
            _password=new Password(password);
        }
    }
}