using Data.Models;
using Data.ViewModel;
using Microsoft.EntityFrameworkCore;
using WebAPI;

namespace Services
{
    public class UserService : IUsermasterService
    {
        private readonly endel_weighbridgeContext _context;
        private IEncryptionService _encryptionService;
        public UserService(endel_weighbridgeContext context)
        {
            _context = context;
            _encryptionService = new EncryptionService();
        }

        public List<Usermaster> GetUser()
        {
            return _context.Usermasters.ToList();
        }
        public Usermaster GetUser_by_UserId(int id)
        {
            var User = _context.Usermasters.Where(p => p.UserId == id).ToList();
            if (User == null)
                return null;
            return User.FirstOrDefault();
        }
        public Usermaster GetUser_by_UserName(string UserName)
        {
            try
            {
                var users = _context.Usermasters.Where(p => p.UserName == UserName).ToList();
                if (users != null && users.Count > 0)
                    return users.FirstOrDefault();
                else
                    return null;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
        public List<Usermaster> SearchUser(string Username)
        {
            if (!string.IsNullOrEmpty(Username))
            {
                var Users = _context.Usermasters.Where(p => p.UserName == Username).ToList();
                if (Users.Count > 0)
                    return Users;
                else
                    return null;
            }
            return null;
        }
        public int InsertUser(Usermaster User)
        {
            var use= _context.Usermasters.Where(p => p.UserName == User.UserName).FirstOrDefault();
            if (use != null)
                return 0;
            else
            {
                User.UserName = User.UserName.Trim();
                string userpassword = User.Password;
                User.Password = _encryptionService.EncryptData(userpassword);
                User.Salt = _encryptionService.createSalt(User.UserName, userpassword);
                User.CreatedTime = DateTime.Now;
                User.Active = 1;
                _context.Usermasters.Add(User);
                _context.SaveChanges();
                return User.UserId;
            }
            
        }
        public int EditUser(UsermasterVM User)
        {
            var use = _context.Usermasters.FirstOrDefault(p => p.UserId == User.UserId);
            if (use == null)
                return 0;
            use.FirstName = User.FirstName;
            use.LastName = User.LastName;
            use.ContactNo = User.ContactNo;
            use.Email = User.Email;
            use.Address = User.Address;
            use.Notes = User.Notes;
            use.UserName = User.UserName;
            use.Active = User.Active;
            use.UpdateTime=User.UpdateTime;
            use.UpdatedBy = User.UpdatedBy;

            User.UpdateTime = DateTime.Now;
            _context.SaveChanges();
            return User.UserId;
        }
        
        public UsermasterVM Authenticate(UserLoginRequest loginRequest)
        {
            if (loginRequest == null)
                return null;

            var user = _context.Usermasters.SingleOrDefault(x => x.UserName == loginRequest.UserName);

            // return null if user not found
            if (user == null)
                return null;

            // check if password is correct
            if (!_encryptionService.IsSaltMatch(loginRequest.UserName, loginRequest.Password, user.Salt)) 
                return null;

            // authentication successful
            return new UsermasterVM
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ContactNo = user.ContactNo,
                Email = user.Email,
                Address = user.Address,
                Notes = user.Notes,
                UserName = user.UserName,
                Active = user.Active,
                TemplateId = user.TemplateId,
                FailedLoginAttempt = user.FailedLoginAttempt,
                CannotLoginUntilDate = user.CannotLoginUntilDate,
                LastLoginDate = user.LastLoginDate
                // Populate other properties of UsermasterVM as needed
            };
        }
        public Usermaster ActivateUser(int id)
        {
            var User = _context.Usermasters.Where(p => p.UserId == id).FirstOrDefault();
            if (User == null)
                return null;
            else
            {
                if (User.Active == 1)
                {
                    User.Active = 0;
                }
                else
                {
                    User.Active = 1;
                }
            }
            _context.SaveChanges();
            return User;
        }
    }
}
