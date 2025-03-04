namespace Services
{
    public interface IChangePassword
    {
        int ChangePasswordTo(string UserName,string current_password, string userpassword, string cnfrmpas);
    }
}