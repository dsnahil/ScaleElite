using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;


namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TemplatePermission : ControllerBase
    {
        private readonly ITemplatePermissionService _iTemplatePermissionService;
        public TemplatePermission(ITemplatePermissionService iTemplatePermissionService)
        {
            _iTemplatePermissionService = iTemplatePermissionService;
        }
        [HttpGet]
        public IActionResult GetAllTemplatePermission()
        {
            var templatepermission = _iTemplatePermissionService.GetAllTemplatePermission();
            if (templatepermission == null)
            {
                return NotFound();
            }
            else
                return Ok(templatepermission);
        }
        [HttpPut]
        public IActionResult UpdateTemplatePermission(TemplatepermissionVM templatepermission,int feature_id,int templateid)
        {
            templatepermission.UpdateBy= User.Identity.Name;
            var templatepermission1 = _iTemplatePermissionService.UpdateTemplatePermission(templatepermission, feature_id, templateid);
            if (templatepermission1 == null)
            {
                return NotFound();
            }
            else
                return Ok(templatepermission);
        }
    }
}
