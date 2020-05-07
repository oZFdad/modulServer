using Helper;
using Service.Items;
using Service.Services;

namespace Logic.Handler
{
    public class ReplanishBalansHandler
    {
        private IAccountService _accountService;

        public ReplanishBalansHandler(AccountService accountService)
        {
            _accountService = accountService;
        }

        public void Handle(ReplenishBalance deposit)
        {
            _accountService.ReplenishBalanceMoney(deposit.AccauntNumber,deposit.Sum);
        }
    }
}