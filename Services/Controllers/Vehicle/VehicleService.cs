using Data.Models;
using Data.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace Services
{
    public class VehicleService : IVehicleService
    {
        private readonly endel_weighbridgeContext _context;

        public VehicleService(endel_weighbridgeContext context)
        {
            _context = context;
        }
        public int InsertVehicle(Vehicle Vehicle)
        {
            Vehicle.VehicleNumber = Vehicle.VehicleNumber.Trim();
            Vehicle.IsActive=1;
            Vehicle.CreatedTime = DateTime.Now;
            if (!string.IsNullOrEmpty(Vehicle.VehicleNumber))
            {
                Vehicle.VehicleNumber = Vehicle.VehicleNumber.Replace(" ", "").ToUpper();
                var VehicleNumber = _context.Vehicles.Where(p => p.VehicleNumber == Vehicle.VehicleNumber).ToList();
                if (VehicleNumber.Count > 0)
                {
                    return 0;
                }
                else
                {
                    Vehicle.TareWeight = Vehicle.TareWeight?.ToString().Replace(" ", "") != null
                         ? (decimal?)double.Parse(Vehicle.TareWeight.ToString().Replace(" ", ""))
                         : (decimal?)null;

                    Vehicle.TareWeight = Vehicle.TareWeight != null
                         ? (decimal?)double.Parse(Vehicle.TareWeight.ToString().Replace(" ", ""))
                         : (decimal?)null;


                    string decimalAsString = Vehicle.TareWeight.ToString();
                    string digitsOnly = RemoveNonDigits(decimalAsString);
                    static string RemoveNonDigits(string input)
                    {
                        return Regex.Replace(input, @"[^\d]", "");
                    }
                    _context.Vehicles.Add(Vehicle);
                    _context.SaveChanges();
                    return Vehicle.VehicleId;
                }
            }
            else
            {
                return 0;
            }
        }
        public int EditVehicle(VehicleVM Vehicle)
        {
            var vahi=_context.Vehicles.FirstOrDefault(p=>p.VehicleId== Vehicle.VehicleId);
            if(vahi==null)
                return 0;
            vahi.VehicleNumber = Vehicle.VehicleNumber;
            vahi.VehicleType = Vehicle.VehicleType;
            vahi.TareWeight = Vehicle.TareWeight;
            vahi.TareTime = Vehicle.TareTime;
            vahi.AccountId = Vehicle.AccountId;
            vahi.Notes = Vehicle.Notes;
            vahi.MinWeight = Vehicle.MinWeight;
            vahi.MaxWeight = Vehicle.MaxWeight;
            vahi.UpdateTime = Vehicle.UpdateTime;
            vahi.UpdateBy = Vehicle.UpdatedBy;
            _context.SaveChanges();
            return Vehicle.VehicleId;
        }
        public Vehicle GetVehicle_by_VehicleNumber(string VehicleNumber)
        {
            if (!string.IsNullOrEmpty(VehicleNumber))
            {
                var Vehicles = _context.Vehicles.Where(p => p.VehicleNumber == VehicleNumber).ToList();
                if (Vehicles.Count > 0)
                    return Vehicles.FirstOrDefault();
            }
            return null;
        }
        public List<Vehicle> GetVehicle()
        {
            return _context.Vehicles.ToList();
        }
        public Vehicle ActivateVehicle(int id)
        {
            Vehicle Vehicle = _context.Vehicles.Where(p => p.VehicleId == id).FirstOrDefault();
            if (Vehicle == null)
                return null;
            else if (Vehicle.IsActive == 1)
                Vehicle.IsActive = 0;
            else
                Vehicle.IsActive = 1;
            _context.SaveChanges();
            return Vehicle;
        }
        public Vehicle GetVehicle(int id)
        {
            if (id != 0)
            {
                var vehicle = _context.Vehicles.Where(p => p.VehicleId == id).ToList();
                return vehicle.FirstOrDefault();
            }
            return null;
        }
    }
}
