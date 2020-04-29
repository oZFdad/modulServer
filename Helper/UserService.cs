namespace Helper
{
    public interface IUserService
    {
        public bool IsValidateUser(string username, string password);
    }
    public class UserService : IUserService
    {
        public bool IsValidateUser(string username, string password)
        {
            var testUser = new User(username, password);
            return Password.IsPasswordTrue(password, testUser.Salt, testUser.Password);
        }
    }
}