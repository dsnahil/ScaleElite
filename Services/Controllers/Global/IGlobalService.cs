using Data.Models;
using Data.ViewModels;

namespace Services
{
    public interface IGlobalService
    {
        List<Applicationsetting> EditGlobalSetting(List<ApplicationsettingVM> appsetting, string name);
        List<Applicationsetting> GetGlobalSetting();
    }
}