 using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Services;
using Microsoft.AspNetCore.Authorization;
using Data.ViewModel;


namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GateController : ControllerBase
    {
        private readonly IGateService _igateservice;

        public GateController(IGateService igateservice)
        {
            _igateservice = igateservice;
        }
        [HttpGet]
        public ActionResult GetGate()
        {
            var gate = _igateservice.GetGate();
            if (gate == null)
            {
                return NotFound();
            }
            return Ok(gate);
        }
        [HttpPost]
        public ActionResult AddGate(Gate gate)
        {
            gate.CreatedBy = User.Identity.Name;
            var gate1 = _igateservice.InsertGate(gate);
            if (gate1 == 0)
                return BadRequest("Gate already exists");
            return Ok($"Gate added successfully with GateID: {gate1}");
        }
      
        [HttpGet]
        [Route("GetGate_by_GateId")]
        public ActionResult GetGate_by_GateId(int id)
        {
            var gate = _igateservice.GetGate_by_GateId(id);
            if (gate == null)
            {
                return NotFound();
            }
            return Ok(gate);
        }

        [HttpPut]
        public ActionResult EditGate(GateVM gateVM)
        {
            gateVM.UpdatedTime = DateTime.Now;
            gateVM.UpdatedBy = User.Identity.Name;
            var gate1 = _igateservice.EditGate(gateVM);
            if (gate1 == 0)
                return BadRequest();
            return Ok("Gate information updated successfully");
        }

        [HttpGet("GateName")]
        public ActionResult GetGate(string Name)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                List<Gate> name = _igateservice.SearchGate(Name);
                if (name != null)
                {
                    return Ok(name);
                }
                return BadRequest();
            }
            else
                return BadRequest();
        }
        [HttpPatch]
        [Route("activate")]
        public ActionResult ActivateGate(int id)
        {
            var id1 = _igateservice.ActivateGate(id);
            if (id1 == null)
            {
                return NotFound("Gate not found");
            }
            return Ok();
        }

    }

}
