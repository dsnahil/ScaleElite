using Data.Models;

namespace Services
{
    public class TemplatePermissionService:ITemplatePermissionService
    {
        private readonly endel_weighbridgeContext _context;
        public TemplatePermissionService(endel_weighbridgeContext context)
        {
            _context = context;
        }
        public List<Templatepermission> GetAllTemplatePermission()
        {
            return _context.Templatepermissions.ToList();
        }
        public Templatepermission UpdateTemplatePermission(TemplatepermissionVM templatepermission, int feature_id, int templateid)
        {
            templatepermission.UpdateTime = DateTime.Now;
            var newtemp= _context.Templatepermissions.Where(x => x.FeatureId == feature_id && x.TemplateId == templateid).FirstOrDefault();
            if (newtemp == null)
            {
                return null;
            }
            else
            {
                newtemp.IsCreate = templatepermission.IsCreate;
                newtemp.IsDelete = templatepermission.IsDelete;
                newtemp.IsRead = templatepermission.IsRead;
                newtemp.IsUpdate = templatepermission.IsUpdate;
                newtemp.IsExecute = templatepermission.IsExecute;
                newtemp.IsDelete = templatepermission.IsDelete;              
                newtemp.UpdateBy = templatepermission.UpdateBy;
                newtemp.UpdateTime = templatepermission.UpdateTime;
                _context.Templatepermissions.Update(newtemp);
                _context.SaveChanges();
                return newtemp;
            }
        }
    }
}
