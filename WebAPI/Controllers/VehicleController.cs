using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Services;
using Microsoft.AspNetCore.Authorization;
using Data.ViewModel;

namespace WebAPI.Controller
{
    [Authorize]
    [ApiController]
    [Route("api/vehicle")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _ivehicleservice;

        public VehicleController(IVehicleService ivehicleservice)
        {
            _ivehicleservice = ivehicleservice;
        }
        [HttpPost]
        public string AddVehicle([FromBody] Vehicle vehicle)
        {
            vehicle.CreatedBy = User.Identity.Name;
            int vehicleid = _ivehicleservice.InsertVehicle(vehicle);
            if(vehicleid > 0)
            {
                return "Data inserted";
            }
            return "Vehicle Number already exists";
        }
        [HttpGet]
        public ActionResult GetVehicle()
        {
            var vehicle = _ivehicleservice.GetVehicle();
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpGet]
        [Route("GetVehiclebyID")]
        public ActionResult GetVehicles(int id)
        {
            var vehicle = _ivehicleservice.GetVehicle(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }
        [HttpPut]
        public ActionResult EditVehicle(VehicleVM vehicle)
        {
            vehicle.UpdatedBy = User.Identity.Name;
            vehicle.UpdateTime = DateTime.Now;
            var vehicle1 = _ivehicleservice.EditVehicle(vehicle);
            if (vehicle1 == 0)
                return BadRequest();
            return Ok("Vehicle info updated successfully");
        }

        [HttpGet]
        [Route("GetVehiclebyVehicleNumber")]
        public async Task<ActionResult> GetVehicle(string VehicleNumber)
        {
            var vehicle = _ivehicleservice.GetVehicle_by_VehicleNumber(VehicleNumber);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }
        [HttpPatch("{id}/activate")]
        public async Task<ActionResult<Vehicle>> ActivateVehicle(int id)
        {
            var vehicle = _ivehicleservice.ActivateVehicle(id);
            if (vehicle == null)
            {
                return NotFound("Vehicle not found");
            }
            else
            {
                return Ok(vehicle);
            }
        }
    }
}
