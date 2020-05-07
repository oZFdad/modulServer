using Helper;
using Service.Services;

namespace Logic.Handler
{
    public class CreateNewAccountHandler
    {
        private IAccountService _accountService;

        public CreateNewAccountHandler(AccountService accountService)
        {
            _accountService = accountService;
        }

        public void Handle(int id)
        {
            _accountService.CreateAccount(id);
        }
    }
}