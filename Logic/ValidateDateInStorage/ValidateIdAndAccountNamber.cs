using Logic.Exceptions;
using Service.Services;

namespace Logic.ValidateDateInStorage
{
    public class ValidateIdAndAccountNamber
    {
        private IAccountService _accountService;

        public ValidateIdAndAccountNamber(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public void Validate(int id, string accountNumber)
        {
            var chekId = _accountService.GetUserIdWhereSetAccountNumber(accountNumber);
            if (id!=chekId)
            {
                throw new IncorrectRequestException("Счет не пренадлежит авторизованому пользователю");
            }
        }
    }
}