using Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomFieldController : ControllerBase
    {
        private readonly ICustomFieldService _icustomfieldservice;
        public CustomFieldController(ICustomFieldService icustomfieldservice)
        {
            _icustomfieldservice = icustomfieldservice;
        }
        [HttpGet]
        public ActionResult GetCustomField()
        {
            var customfield = _icustomfieldservice.GetCustomField();
            if (customfield == null)
                return NotFound();
            else
                return Ok(customfield);
        }
        [HttpPut]
        public ActionResult EditCustomField(List<CustomfieldVM> appsetting)
        {
            string name = User.Identity.Name;
            var customfield = _icustomfieldservice.EditCustomField(appsetting, name);
            if (customfield == null)
                return NotFound();
            else
                return Ok(customfield);
        }
    }
}
