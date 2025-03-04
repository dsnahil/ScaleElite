using Data.Models;
using Data.ViewModel;
using Data.ViewModels;

namespace Services
{
    public class BarcodeService : IBarcodeService
    {
        private readonly endel_weighbridgeContext _context;

        public BarcodeService(endel_weighbridgeContext context)
        {
            _context = context;
        }
        public List<Barcodesetting> GenerateBarcode()
        {
            var barcode = _context.Barcodesettings.ToList();
            return barcode;
        }
        public List<Barcodesetting> UpdateBarcode(List<BarcodesettingVM> appsetting, string name)
        {
            List<Barcodesetting> updatedBarcodesettings = new List<Barcodesetting>();
            foreach (var item in appsetting)
            {
                var edit = _context.Barcodesettings.Where(p => p.BarcodeFieldName == item.BarcodeFieldName).FirstOrDefault();
                if (edit != null)
                {
                    edit.UpdateTime = DateTime.Now;
                    edit.UpdateBy = name;
                    edit.BarcodeDisplayName = item.BarcodeDisplayName;
                    edit.IsSelected = item.IsSelected;
                    _context.SaveChanges();
                    updatedBarcodesettings.Add(edit);
                }
            }
            return updatedBarcodesettings;
        }
    }
}
