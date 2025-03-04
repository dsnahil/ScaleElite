using Data.Models;

namespace Services
{
    public interface ITemplatePermissionService
    {
        public List<Templatepermission> GetAllTemplatePermission();
        public Templatepermission UpdateTemplatePermission(TemplatepermissionVM templatepermission,int feature_id,int templateid);
    }
}
