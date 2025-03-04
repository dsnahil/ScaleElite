using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Services;
using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _iaccountservice;

        public AccountController(IAccountService iaccountservice)
        {
            _iaccountservice = iaccountservice;
        }

        [HttpGet]
        public ActionResult<Account> GetAccount()
        {                
            var account = _iaccountservice.GetAccount();
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }
        [HttpGet]
        [Route("/id")]
        public ActionResult GetAccount(int id)
        {
            var account = _iaccountservice.GetAccount_by_AccountId(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }
        [HttpGet]
        [Route("GetAccountbyAccountName")]
        public async Task<ActionResult<Account>> SearchAccount(string Name)
        {
            var name = _iaccountservice.SearchAccount(Name);
            if (name == null)
            {
                return NotFound();
            }
            else
                return Ok(name);
        }

        [HttpPost]
        public ActionResult AddAccount(Account account)
        {
            if (account == null)
                return BadRequest("Account data is required.");
            try
            {              
                account.CreatedBy = User.Identity.Name;
                var accountId = _iaccountservice.InsertAccount(account);
                if (accountId == 0)
                    return BadRequest("Account already exists.");

                return Ok($"Account created successfully with ID: {accountId}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("EditAccount")]
        public ActionResult EditAccount(AccountVM accountVM)
        {
            accountVM.UpdateBy = User.Identity.Name;
            accountVM.UpdateTime = DateTime.Now;
            var account1 = _iaccountservice.EditAccount(accountVM);
            if (account1 == 0)
                return BadRequest();
            return Ok("Account information updated successfully");
        }

        [HttpPatch]
        public async Task<ActionResult<Account>> ActivateAcccount(int id)
        {
            var account = _iaccountservice.ActivateAccount(id);
            if (account == null)
            {
                return NotFound("Account not found");
            }
            return Ok();
        }

    }
}
