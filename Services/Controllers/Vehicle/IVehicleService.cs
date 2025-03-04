using Data.Models;
using Data.ViewModel;


namespace Services
{
    public interface IVehicleService
    {
        Vehicle GetVehicle_by_VehicleNumber(string VehicleNumber);
        int InsertVehicle(Vehicle vehicle);
        int EditVehicle(VehicleVM vehicle);
        List<Vehicle> GetVehicle();
        Vehicle ActivateVehicle(int id);
        Vehicle GetVehicle(int id);

    }
}
