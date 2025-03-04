using Data.Models;
using Data.ViewModels;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly endel_weighbridgeContext _context;
        public AccountService(endel_weighbridgeContext context)
        {
            _context = context;
        }
        public int InsertAccount(Account Account)
        {
            var account = _context.Accounts.Where(p => p.AccountName == Account.AccountName).FirstOrDefault();
            if(account != null)
                return 0;
            else
            {
                Account.CreatedTime = DateTime.Now;
                Account.Active = 1;
                _context.Accounts.Add(Account);
                _context.SaveChanges();
                return Account.AccountId;
            }
        }
        public int EditAccount(AccountVM accountVM)
        {
            var account = _context.Accounts.FirstOrDefault(p => p.AccountId == accountVM.AccountId);
            if (account == null)
                return 0;
            account.AccountName = accountVM.AccountName;
            account.FirstName = accountVM.FirstName;
            account.LastName = accountVM.LastName;
            account.ContactNo = accountVM.ContactNo;
            account.Email = accountVM.Email;
            account.Notes = accountVM.Notes;
            account.Address = accountVM.Address;
            account.City = accountVM.City;
            account.Pincode = accountVM.Pincode;
            account.Gstno = accountVM.Gstno;
            account.Active = accountVM.Active;
            account.UpdateTime = accountVM.UpdateTime;
            account.UpdateBy = accountVM.UpdateBy;
            _context.SaveChanges();
            return account.AccountId; 
        }
        public List<Account> SearchAccount(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var Accounts = _context.Accounts.Where(p => p.AccountName == name || p.FirstName == name || p.LastName == name).ToList();
                if (Accounts.Count > 0)
                    return Accounts;
            }
            return null;
        }
        public List<Account> GetAccount()
        {
            return _context.Accounts.ToList();
        }
        public Account GetAccount_by_AccountId(int id)
        {
            if (id != 0)
            {
                var account = _context.Accounts.Where(p => p.AccountId == id).ToList();
                if (account.Count > 0)
                    return account.FirstOrDefault();
            }
            return null;
        }
        public Account ActivateAccount(int id)
        {
            var account = _context.Accounts.Where(p => p.AccountId == id).FirstOrDefault();
            if (account == null)
                return null;
            else
            {
                if (account.Active == 1)
                {
                    account.Active = 0;
                }
                else
                {
                    account.Active = 1;
                }
            }
            _context.SaveChanges();
            return account;
        }
    }
}
