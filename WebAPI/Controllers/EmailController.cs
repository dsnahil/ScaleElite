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
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _iemailservice;

        public EmailController(IEmailService iemailservice)
        {
            _iemailservice = iemailservice;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var email = _iemailservice.GetEmail();
            if(email == null)
                return NotFound();
            else
                return Ok(email);
        }
        [HttpPost]
        public ActionResult AddEmailSchedule(Emailsetup emailsetup)
        {
            emailsetup.CreatedTime = DateTime.Now;
            emailsetup.IsEnable = 1;
            var email = _iemailservice.AddEmailSchedule(emailsetup);
            if (email == 0)
                return BadRequest();
            else
                return Ok($"Email Schedule created successfully with ID: {email}");
        }


        [HttpPatch]
        public ActionResult ActivateEmailSchedule(int id)
        {
            var email = _iemailservice.ActivateEmailSchedule(id);
            if(email == 0)
                return BadRequest("Email does not exist");
            else
                return Ok($"Email Schedule activated successfully with ID: {email}");
        }
        [HttpDelete]
        public ActionResult DeleteEmailSchedule(int id)
        {
            var email = _iemailservice.DeleteEmailSchedule(id);
            if (email == 0)
                return BadRequest();
            else
                return Ok($"Email Schedule deleted successfully with ID: {email}");
        }
        [HttpPut]
        public ActionResult EditEmailSchedule(EmailsetupVM emailsetup)
        {
            var email = _iemailservice.EditEmailSchedule(emailsetup);
            if (email == 0)
                return BadRequest();
            else
                return Ok($"Email Schedule updated successfully with ID: {email}");
        }

        [HttpGet]
        public ActionResult SearchEmailSchedule(string email)
        {
            var localemail = _iemailservice.SearchRecord(email);
            if (localemail == null)
                return NotFound("Record not found");
            else
                return Ok(email);
        }
    }
}