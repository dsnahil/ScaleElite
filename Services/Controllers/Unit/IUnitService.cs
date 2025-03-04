using Data.Models;
using Data.ViewModel;

namespace Services
{
    public interface IUnitService
    {
        List<Unit> GetUnit();
        int InsertUnit(Unit Unit);
        public List<Unit> SearchUnit(string UnitName);
        int EditUnit(UnitVM UnitVM);
        Unit GetUnit_by_UnitId(int id);
    }
}
