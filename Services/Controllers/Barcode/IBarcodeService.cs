using Data.Models;
using Data.ViewModel;

namespace Services
{
    public interface IBarcodeService
    {
        List<Barcodesetting> GenerateBarcode();
        List<Barcodesetting> UpdateBarcode(List<BarcodesettingVM> appsetting, string name);
    }
}