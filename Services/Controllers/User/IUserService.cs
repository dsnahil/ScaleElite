using Data.ViewModel;
using Data.Models;
using WebAPI;

namespace Services
{
    public interface IUsermasterService
    {
        List<Usermaster> GetUser();
        Usermaster GetUser_by_UserId(int UserId);
        Usermaster GetUser_by_UserName(string UserName);
        List<Usermaster> SearchUser(string UserName);
        int InsertUser(Usermaster User);
        int EditUser(UsermasterVM User);
        UsermasterVM Authenticate(UserLoginRequest loginRequest);
        Usermaster ActivateUser(int UserId);
    }
}
