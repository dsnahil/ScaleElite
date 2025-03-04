using Data.Models;
using Data.ViewModel;

namespace Services
{
    public class UnitService : IUnitService
    {
        private readonly endel_weighbridgeContext _context;
        public UnitService(endel_weighbridgeContext context)
        {
            _context = context;
        }
        public int InsertUnit(Unit Unit)
        {
            Unit.UnitName = Unit.UnitName.Trim();
            _context.Units.Add(Unit);
            _context.SaveChanges();
            return Unit.UnitId;
        }
        public int EditUnit(UnitVM UnitVM)
        {
            var uni=_context.Units.FirstOrDefault(p=>p.UnitId== UnitVM.UnitId);
            if(uni==null)
                return 0;
            uni.UnitName = UnitVM.UnitName;
            uni.UpdateBy = UnitVM.UpdateBy;
            uni.UpdateTime = UnitVM.UpdateTime;
            _context.SaveChanges();
            return uni.UnitId;

        }
        public List<Unit> SearchUnit(string UnitName)
        {
            if (!string.IsNullOrEmpty(UnitName))
            {
                var Unit = _context.Units.Where(p => p.UnitName.Contains(UnitName)).ToList();
                if (Unit.Count > 0)
                    return Unit;
                else
                    return null;
            }
            return null;
        }
        public List<Unit> GetUnit()
        {
            return _context.Units.ToList();
        }

        public Unit GetUnit_by_UnitId(int id)
        {
            if(id!=0)
            {
                var Unit = _context.Units.Where(p => p.UnitId == id).ToList();
                return Unit.FirstOrDefault();
            }
                return null;
        }
    }
}
