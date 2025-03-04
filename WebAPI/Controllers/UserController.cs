using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Services;
using Data.ViewModel;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsermasterService _iuserservice;
        public UserController(IUsermasterService iuserservice)
        {
            _iuserservice = iuserservice;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<Usermaster> GetUser()
        {
            var user = _iuserservice.GetUser();
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        [Authorize]
        [Route("id")]
        public async Task<ActionResult> GetUser(int id)
        {
            var user = _iuserservice.GetUser_by_UserId(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("{UserName}")]
        [Authorize]
        public ActionResult GetUser(string UserName)
        {
            var user = _iuserservice.SearchUser(UserName);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Usermaster> AddUser(Usermaster user)
        {
            if (user == null)
            {
                return BadRequest("User data is required.");
            }
            else
            {
                user.CreatedBy = User.Identity.Name;
                var user1 = _iuserservice.InsertUser(user);
                if (user1 == 0)
                    return BadRequest("User already exists");
                return Ok($"User created with user id:{user1}");
            }
            
        }

        [Authorize]
        [HttpPut]
        public ActionResult<Usermaster> EditUser(UsermasterVM user)
        {
            user.UpdatedBy = User.Identity.Name;
            user.UpdateTime = DateTime.Now;
            var user1 = _iuserservice.EditUser(user);
            if (user1 == 0)
                return BadRequest();
            return Ok("User info updated successfully");
        }

        [HttpPost("login")]
        public IActionResult Authenticate(UserLoginRequest loginRequest)
        {
            if (loginRequest == null)
                return Ok(new Response { ErrorMessage = "Username and password are required", Status = HttpStatusCode.BadRequest });

            if (string.IsNullOrEmpty(loginRequest.UserName))
                return Ok(new Response { ErrorMessage = "Username is required", Status = HttpStatusCode.BadRequest });

            if (string.IsNullOrEmpty(loginRequest.Password))
                return Ok(new Response { ErrorMessage = "Password is required", Status = HttpStatusCode.BadRequest });

            var user = _iuserservice.Authenticate(loginRequest);

            if (user == null)
                return Ok(new Response { ErrorMessage = "Username or password is incorrect", Status = HttpStatusCode.BadRequest });

            return Ok(new Response { Data = user, Message = "Login Success", Status = HttpStatusCode.OK });

        }

        [Authorize]
        [HttpPatch("{id}/activate")]
        public ActionResult<Usermaster> ActivateUser(int id)
        {
            var user = _iuserservice.ActivateUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
