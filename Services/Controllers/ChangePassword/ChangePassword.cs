using Data.Models;
using Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class ChangePassword : IChangePassword
    {
        private readonly endel_weighbridgeContext _context;
        private IEncryptionService _encryptionService;

        public ChangePassword(endel_weighbridgeContext context)
        {
            _context = context;
            _encryptionService = new EncryptionService();

        }
        public int ChangePasswordTo(string UserName, string current_password, string userpassword, string cnfrmpas)
        {
            if (userpassword == cnfrmpas)
            {
                userpassword = _encryptionService.EncryptData(userpassword);
                string CurrentPassword = _encryptionService.EncryptData(current_password);
                var user = _context.Usermasters.Where(x => x.UserName == UserName && x.Password == CurrentPassword).FirstOrDefault();
                if (user != null)
                {
                    user.Password = userpassword;
                    _context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
                return 0;
        }
    }
}
