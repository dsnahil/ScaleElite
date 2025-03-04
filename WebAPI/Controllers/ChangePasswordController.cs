using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChangePasswordController : ControllerBase
    {
        private readonly IChangePassword _ichangepassword;
        public ChangePasswordController(IChangePassword ichangepassword)
        {
            _ichangepassword = ichangepassword;
        }

        [HttpPost]
        public ActionResult ChangePassword([FromBody] ChangePasswordModel model)
        {
            var user1 = _ichangepassword.ChangePasswordTo(model.UserName, model.CurrentPassword, model.UserPassword, model.ConfirrmPasssword);
            if(user1==1)
                return Ok("Password updation done");
            else
                return BadRequest("Password does not match");
        }
    }
}
