using Data.Models;

namespace Services
{
    public interface IUserRoleService
    {
        int ActivateUserRole(Template template);
        List<Template> GetAllUserRole();
        int AddUserRole(Template Template);
        int EditUserRole(Template Template,string name);
    }
}