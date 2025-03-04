using Data.Models;
using Data.ViewModel;

namespace Services
{
    public interface ICustomFieldService
    {
        List<Customfield> EditCustomField(List<CustomfieldVM> Customfield, string name);
        List<Customfield> GetCustomField();
    }
}