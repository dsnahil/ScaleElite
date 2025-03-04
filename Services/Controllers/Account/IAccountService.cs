using Data.Models;
using Data.ViewModels;

namespace Services
{
    public interface IAccountService
    {
        List<Account> GetAccount();
        public List<Account> SearchAccount(string AccountName);
        int InsertAccount(Account Account);
        int EditAccount(AccountVM accountVM);
        Account GetAccount_by_AccountId(int id);
        Account ActivateAccount(int AccountId);

    }
}
