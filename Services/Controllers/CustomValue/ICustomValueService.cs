using Data.Models;
using Data.ViewModel;

namespace Services
{
    public interface ICustomValueService
    {
        void AddCustomValue(Customvalue customvalue);
        void DeleteCustomValue(int id);
        List<CustomvalueVM> EditCustomValue(List<CustomvalueVM> custom, string name);
        List<Customvalue> GetCustomValue();
    }
}