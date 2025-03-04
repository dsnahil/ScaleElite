using Data.Models;
using Data.ViewModel;

namespace Services
{
    public interface IMasterFieldService
    {
        List<Masterfield> GetMasterField();
        List<Masterfield> UpdateMasterFields(List<MasterfieldVM> appsettingList,string name);
    }
}