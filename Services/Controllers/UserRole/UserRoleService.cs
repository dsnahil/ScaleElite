using Data.Models;

namespace Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly endel_weighbridgeContext _context;
        public UserRoleService(endel_weighbridgeContext context)
        {
            _context = context;
        }
        public List<Template> GetAllUserRole()
        {
            return _context.Templates.ToList();
        }
        public int ActivateUserRole(Template template)
        {
            var temp = _context.Templates.Where(p => p.TemplateName == template.TemplateName).FirstOrDefault();
            if (temp == null)
                return 0;
            else
            {
                template.Active = 1;
                template.CreatedTime = DateTime.Now;
                _context.Templates.Add(template);
                _context.SaveChanges();
                return template.TemplateId;
            }
        }

        public int AddUserRole(Template Template)
        {
            var temp = _context.Templates.Where(p => p.TemplateName == Template.TemplateName).FirstOrDefault();
            if (temp != null)
                return 0;
            else
            {
                Template.CreatedTime = DateTime.Now;
                Template.Active = 1;
                _context.Templates.Add(Template);
                _context.SaveChanges();
                return Template.TemplateId;
            }
        }
        public int EditUserRole(Template Template, string name)
        {
            Template.UpdateBy = name;
            Template.UpdateTime = DateTime.Now;
            _context.Templates.Update(Template);
            _context.SaveChanges();
            return Template.TemplateId;
        }

    }
}
