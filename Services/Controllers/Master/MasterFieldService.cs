using Data.Models;
using Data.ViewModel;
namespace Services
{
    public class MasterFieldService :  IMasterFieldService
    {
        private readonly endel_weighbridgeContext _context;
        public MasterFieldService(endel_weighbridgeContext context)
        {
            _context = context;
        }
        public List<Masterfield> GetMasterField()
        {
            var master = _context.Masterfields.ToList();
            return master;
        }
        public List<Masterfield> UpdateMasterFields(List<MasterfieldVM> appsettingList,string name)
        {
            List<Masterfield> updatedMasterfields = new List<Masterfield>();
            foreach (var appsetting in appsettingList)
            {
                var edit = _context.Masterfields.FirstOrDefault(p => p.MasterFieldId == appsetting.MasterFieldId);

                if (edit != null)
                {
                    edit.UpdateTime = DateTime.Now;
                    edit.UpdateBy = name;
                    edit.Isvisible = appsetting.Isvisible;
                    edit.IsRequired = appsetting.IsRequired;
                    _context.SaveChanges();
                    updatedMasterfields.Add(edit); 
                }
            }
            return updatedMasterfields;
        }
    }
}
