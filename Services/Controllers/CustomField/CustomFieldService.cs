using Data.Models;
using Data.ViewModel;

namespace Services
{
    public class CustomFieldService : ICustomFieldService
    {
        private readonly endel_weighbridgeContext _context;
        public CustomFieldService(endel_weighbridgeContext context)
        {
            _context = context;
        }
        public List<Customfield> GetCustomField()
        {
            var custom = _context.Customfields.ToList();
            return custom;
        }
        public List<Customfield> EditCustomField(List<CustomfieldVM> Customfield,string name)
        {
            List<Customfield> updatedCustomfields = new List<Customfield>();
            foreach (var appsetting in Customfield)
            {
                var flag = _context.Customfields.FirstOrDefault(p => p.CustomFieldId == appsetting.CustomFieldId);
                if (flag != null)
                {
                    appsetting.UpdateBy = name;
                    flag.UpdateTime = DateTime.Now;
                    flag.UpdateBy = appsetting.UpdateBy;
                    flag.IsVisible = appsetting.IsVisible;
                    flag.IsRequired = appsetting.IsRequired;
                    flag.MaxLength = appsetting.MaxLength;
                    flag.DisplayName = appsetting.DisplayName;
                    _context.SaveChanges();
                    updatedCustomfields.Add(flag);
                }
                else
                    return null;
            }
            return updatedCustomfields;
        }
    }
}
