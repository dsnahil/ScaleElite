using Data.Models;
using Data.ViewModel;

namespace Services
{
    public interface IDriverService
    {
        int EditDriver(DriverVM driverVM);
        List<Driver> GetDriver();
        Driver GetDriver_by_DriverId(int id);
        int InsertDriver(Driver driver);
        List<Driver> DriverSearch(string driver);
        Driver ActivateDriver(int id);

    }
}