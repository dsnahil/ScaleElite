using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Services;
using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Data.ViewModel;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomValueController : ControllerBase
    {
        private readonly ICustomValueService _icustomvalueservice;
        public CustomValueController(ICustomValueService icustomvalueservice)
        {
            _icustomvalueservice = icustomvalueservice;
        }

        [HttpGet]
        public ActionResult GetCustomValue()
        {
            var customvalue = _icustomvalueservice.GetCustomValue();
            if (customvalue == null)
                return NotFound();
            else
                return Ok(customvalue);
        }
        [HttpPut]
        public ActionResult EditCustomValue(List<CustomvalueVM> appsetting)
        {
            string name = User.Identity.Name;

            var customvalue = _icustomvalueservice.EditCustomValue(appsetting, name);
            if (customvalue == null)
                return NotFound();
            else
                return Ok(customvalue);
        }
        [HttpPost]
        public ActionResult AddCustomValue(Customvalue customvalue)
        {
            if (customvalue == null)
                return BadRequest("CustomValue data is required.");
            try
            {

                customvalue.CreatedBy = User.Identity.Name;
                _icustomvalueservice.AddCustomValue(customvalue);
                return Ok("CustomValue added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public ActionResult DeleteCustomValue(int id)
        {
            if (id <= 0)
                return BadRequest("CustomValue Id is required.");
            try
            {
                _icustomvalueservice.DeleteCustomValue(id);
                return Ok("CustomValue deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
