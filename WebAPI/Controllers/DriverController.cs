using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Services;
using Microsoft.AspNetCore.Authorization;
using Data.ViewModel;

namespace WebAPI.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _idriverservice;

        public DriverController(IDriverService idriverservice)
        {
            _idriverservice = idriverservice;
        }

        [HttpGet]
        public ActionResult GetDriver()
        {
            var driver = _idriverservice.GetDriver();
            if (driver == null)
            {
                return NotFound();
            }
            return Ok(driver);
        }

        [HttpPost]
        public  ActionResult AddDriver(Driver driver)
        {
            driver.CreatedBy = User.Identity.Name;
            driver.CreatedTime = DateTime.Now;
            driver.Active = 1;
            var drive = _idriverservice.InsertDriver(driver);
            return Ok($"Driver created successfully with ID: {drive}");
        }

        [HttpPut]
        public ActionResult EditDriver(DriverVM driverVM)
        {
            driverVM.UpdateBy = User.Identity.Name;
            driverVM.UpdateTime = DateTime.Now;
            var drive = _idriverservice.EditDriver(driverVM);
            if (drive == 0)
                return BadRequest();
            return Ok("Driver info updated successfully");
        }

        [HttpGet]
        [Route("/GetDriverbyID")]
        public ActionResult GetDriver(int id)
        {
            var driver = _idriverservice.GetDriver_by_DriverId(id);
            if (driver == null)
            {
                return NotFound();
            }
            return Ok(driver);
        }
        [HttpPatch("activate")]
        public ActionResult ActivateDriver(int id)
        {
            var driver = _idriverservice.ActivateDriver(id);
            if (driver == null)
            {
                return NotFound("Driver not found");
            }
            return Ok();
        }
        [HttpGet("Search")]

        public ActionResult DriverSearch(String name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                List<Driver> driver = _idriverservice.DriverSearch(name);

                if (driver != null)
                {
                    return Ok(driver);
                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }
    }
}
