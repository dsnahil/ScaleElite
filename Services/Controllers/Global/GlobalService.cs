using Data.Models;
using Data.ViewModels;


namespace Services
{
    public class GlobalService : IGlobalService
    {
        private readonly endel_weighbridgeContext _context;
        public GlobalService(endel_weighbridgeContext context)
        {
            _context = context;
        }
        public List<Applicationsetting> GetGlobalSetting()
        {
            var global = _context.Applicationsettings.Where(p => p.ModuleName == "GlobalSetting").ToList();

            var value = global.Where(p => p.ModuleName == "GlobalSetting").ToList();
            return value;
        }
        public List<Applicationsetting> EditGlobalSetting(List<ApplicationsettingVM> appsetting,string name)
        {
            List<Applicationsetting> updatedAppsetting = new List<Applicationsetting>();
            foreach (var app in appsetting)
            {
                var edit = _context.Applicationsettings.FirstOrDefault(p => p.SettingName == app.SettingName);
                if (edit != null)
                {
                    edit.UpdateBy = name;
                    edit.UpdateTime = DateTime.Now;
                    edit.SettingValue = app.SettingValue;
                    edit.SettingName = app.SettingName;
                    _context.SaveChanges();
                    updatedAppsetting.Add(edit);
                }
            }
            return updatedAppsetting;
        }
      
    }
}
