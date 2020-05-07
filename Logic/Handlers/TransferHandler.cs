using Helper;
using Logic.ValidateDateInStorage;
using Service.Items;
using Service.Services;

namespace Logic.Handler
{
    public class TransferHandler
    {
        private IAccountService _accountService;

        public TransferHandler(AccountService accountService)
        {
            _accountService = accountService;
        }

        public void Handle(TransferMoney transferMoney, int id)
        {
            var validate = new ValidateIdAndAccountNamber(_accountService);
            validate.Validate(id, transferMoney.Sender);
            _accountService.TransferMoney(transferMoney.Sender,transferMoney.Recipient,transferMoney.sum);
        }
    }
}