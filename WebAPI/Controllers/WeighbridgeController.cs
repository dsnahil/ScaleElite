using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using Services;
using Microsoft.AspNetCore.Authorization;
using Data.ViewModel;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WeighbridgeController : ControllerBase
    {
        private readonly IWeighbridgeService _iweighbridgeservice;
        public WeighbridgeController(IWeighbridgeService iweighbridgeservice)
        {
            _iweighbridgeservice = iweighbridgeservice;
        }

        [HttpGet]
        public ActionResult GetWeighbridge()
        {
            var weighbridge = _iweighbridgeservice.GetWeighbridge();
            if (weighbridge == null)
            {
                return NotFound();
            }
            return Ok(weighbridge);
        }

        [HttpGet("{id}")]
        public ActionResult GetWeighbridge(int id)
        {
            var weighbridge = _iweighbridgeservice.GetWeighbridge_by_WeighbridgeId(id);
            if (weighbridge == null)
            {
                return NotFound();
            }
            return Ok(weighbridge);
        }

        [HttpPost]
        public ActionResult AddWeighbridge([FromBody] Weighbridge weighbridge)
        {
            if (weighbridge == null)
                return BadRequest("Weighbridge data is required.");
            try
            {
                weighbridge.CreatedBy = User.Identity.Name;
                var add = _iweighbridgeservice.InsertWeighbridge(weighbridge);
                if (add == 0)
                    return BadRequest("Weighbridge already exists.");

                return Ok($"Weighbridge created successfully with ID: {add}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateWeighbridge(WeighbridgeVM weighbridge)
        {
            weighbridge.UpdateBy = User.Identity.Name;
            weighbridge.UpdateTime = DateTime.Now;
            var weighbridge1 = _iweighbridgeservice.EditWeighbridge(weighbridge);
            if (weighbridge1 == 0)
            {
                return BadRequest("Invalid ID");
            }
            return Ok();
        }
        [HttpPatch("{id}/activate")]
        public ActionResult ActivateWeighbridge(int id)
        {
            var weighbridge = _iweighbridgeservice.ActivateWeighbridge(id);
            if (weighbridge == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
