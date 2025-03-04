using Data.Models;
using Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;


namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransporterController : ControllerBase
    {
        private ITransporterService _itransporterservice;

        public TransporterController(ITransporterService itransporterservice)
        {
            _itransporterservice = itransporterservice;
        }
        [HttpGet]
        [Route("GetTransporter")]

        public ActionResult<Transport> GetTransporter()
        {
            var transporter = _itransporterservice.GetTransporter();
            if (transporter == null)
            {
                return NotFound();
            }
            return Ok(transporter);
        }
        [HttpGet]
        [Route("GetTransporter_by_TransporterName")]
        public async Task<ActionResult<Transport>> SearchTransporter(string Name)
        {
            var name = _itransporterservice.SearchTransporter(Name);
            if (name == null)
            {
                return NotFound();
            }
            else
                return Ok(name);
        }

        [HttpPost]
        public ActionResult InsertTransporter(Transport transporter)
        {

            transporter.CreatedBy = User.Identity.Name;
            var add = _itransporterservice.InsertTransporter(transporter);
            if (add == 0)
                return BadRequest("Transporter already exists");
            return Ok($"Transporter created with : {add}");
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetTransporter_by_TransporterId(int id)
        {
            var Transporter = _itransporterservice.GetTransporter_by_TransporterId(id);
            if (Transporter == null)
            {
                return NotFound();
            }
            return Ok(Transporter);
        }
        [HttpPut]
        public ActionResult EditTransporter(TransportVM TransporterVM)
        {
            TransporterVM.UpdateTime = DateTime.Now;
            TransporterVM.UpdateBy = User.Identity.Name;
            var Transporter1 = _itransporterservice.EditTransporter(TransporterVM);
            if (Transporter1 == 0)
                return BadRequest();
            return Ok("Transporter info updates successfully");
        }

        [HttpPatch]
        [Route("activate")]
        public ActionResult ActivateTransporter(int id)
        {
            var Transporter1 = _itransporterservice.ActivateTransporter(id);
            if (Transporter1 == null)
            {
                return NotFound("Transporter not found");
            }
            return Ok();
        }
    }
}
