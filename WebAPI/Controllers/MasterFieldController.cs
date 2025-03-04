using Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MasterFieldController : ControllerBase
    {
        private readonly IMasterFieldService _imasterfieldservice;
        public MasterFieldController(IMasterFieldService imasterfieldservice)
        {
            _imasterfieldservice = imasterfieldservice;
        }
        [HttpGet]
        public ActionResult GetMasterField()
        {
            var masterfield = _imasterfieldservice.GetMasterField();
            if (masterfield == null)
                return NotFound();
            else
                return Ok(masterfield);
        }
        [HttpPut]
        public ActionResult UpdateMasterFields(List<MasterfieldVM> appsetting)
        {
            string name = User.Identity.Name;
            var masterfield = _imasterfieldservice.UpdateMasterFields(appsetting, name);
            if (masterfield == null)
                return NotFound();
            else
                return Ok(masterfield);
        }
    }
}
