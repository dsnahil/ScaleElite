using Data.Models;
using Data.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class DriverService : IDriverService
    {
        private readonly endel_weighbridgeContext _context;

        public DriverService(endel_weighbridgeContext context)
        {
            _context = context;
        }

        public int InsertDriver(Driver driver)
        {
            driver.CreatedTime = DateTime.Now;
            driver.UpdateTime = null;
            driver.Active = 1;
            _context.Drivers.Add(driver);
            _context.SaveChanges();
            return driver.DriverId;
        }
        public int EditDriver(DriverVM driverVM)
        {
            var drive = _context.Drivers.FirstOrDefault(p => p.DriverId == driverVM.DriverId);
            if (drive == null)
                return 0;
            drive.DriverName = driverVM.DriverName;
            drive.Photo = driverVM.Photo;
            drive.Notes = driverVM.Notes;
            drive.AccountId = driverVM.AccountId;
            drive.IdproofScan = driverVM.IdproofScan;
            drive.IdproofType = driverVM.IdproofType;
            drive.IdproofNo = driverVM.IdproofNo;
            drive.UpdateTime=driverVM.UpdateTime;
            drive.UpdateBy=driverVM.UpdateBy;
    
            _context.SaveChanges();
            return drive.DriverId;

        }
        public Driver GetDriver_by_DriverId(int id)
        {
            if (id != 0)
            {
                var Drivers = _context.Drivers.Where(p => p.DriverId == id).ToList();
                if (Drivers.Count > 0)
                    return Drivers.FirstOrDefault();
            }
            return null;
        }

        public List<Driver> GetDriver()
        {
            return _context.Drivers.ToList();
        }

        public List<Driver> DriverSearch(string driver)
        {
            if (!string.IsNullOrEmpty(driver))
            {
                var drivers = _context.Drivers.Where(p => p.DriverName == driver).ToList();
                if (drivers.Count > 0)
                    return drivers;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }
        public Driver ActivateDriver(int id)
        {
            var driver = _context.Drivers.Where(p => p.DriverId == id).FirstOrDefault();
            if (driver == null)
                return null;
            else
            {
                if (driver.Active == 1)
                {
                    driver.Active = 0;
                }
                else
                {
                    driver.Active = 1;
                }
            }
            _context.SaveChanges();
            return driver;
        }


    }
}
