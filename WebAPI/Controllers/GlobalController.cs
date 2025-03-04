using Microsoft.AspNetCore.Mvc;
using Services;
using Microsoft.AspNetCore.Authorization;
using Data.ViewModels;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalController : ControllerBase
    {
        private readonly IGlobalService _iglobalservice;
        public GlobalController(IGlobalService iglobalservice)
        {
            _iglobalservice = iglobalservice;
        }
        [HttpGet]
        public ActionResult GetGlobal()
        {
            var global = _iglobalservice.GetGlobalSetting();
            if (global == null)
                return NotFound();
            else
                return Ok(global);
        }
        [HttpPut]
        public ActionResult EditGlobalSettings(List<ApplicationsettingVM> appsetting)
        {
            if(appsetting != null)
            {
                string name = User.Identity.Name;
                var global = _iglobalservice.EditGlobalSetting(appsetting, name);
                if (global == null)
                    return NotFound();
                else
                    return Ok(global);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}