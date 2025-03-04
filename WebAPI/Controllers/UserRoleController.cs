using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _iuserRoleService;
        public UserRoleController(IUserRoleService iuserRoleService)
        {
            _iuserRoleService = iuserRoleService;
        }

        [HttpGet]
        public ActionResult GetUserRole()
        {
            var userrole = _iuserRoleService.GetAllUserRole();
            if (userrole == null)
                return NotFound();
            else
                return Ok(userrole);
        }
        
        [HttpPost]
        public ActionResult AddUserRole([FromBody] Template Template)
        {
            if (!ModelState.IsValid)
            {
                // If the model state is not valid, return BadRequest with model state errors
                return BadRequest(ModelState);
            }

            // At this point, the model state is valid
            Template.CreatedBy = User.Identity.Name;
            var userrole = _iuserRoleService.AddUserRole(Template);

            if (userrole == null)
            {
                return NotFound("Already exists");
            }
            else
            {
                return Ok($"User created successfully: {userrole}");
            }
            //if (Template == null)
            //    return BadRequest("UserRole data is required.");
            //else
            //{
            //    Template.CreatedBy = User.Identity.Name;
            //    var userrole = _iuserRoleService.AddUserRole(Template);
            //    if (userrole == null)
            //        return NotFound("Already exists");
            //    else
            //        return Ok($"User created successfully :{userrole}");
            //}
        }
        [HttpPut]
        public ActionResult UpdateUserRole(Template Template)
        {
            var name = User.Identity.Name;
            var userrole = _iuserRoleService.EditUserRole(Template, name);
            if (userrole == null)
                return NotFound();
            else
                return Ok(userrole);
        }
        [HttpPatch]
        public ActionResult ActivateUserRole(Template template)
        {
            var role = _iuserRoleService.ActivateUserRole(template);
            if (role != null)
            {
                return Ok(role);
            }
            else
                return BadRequest("UserRole Not Found");
        }
    }
}
