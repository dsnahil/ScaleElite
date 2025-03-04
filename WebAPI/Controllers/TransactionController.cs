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
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpPost("InsertTransaction")]
        public ActionResult InsertTransaction(Transactiondatum Transaction)
        {
            Transaction.TransactionCreatedBy = User.Identity.Name;
            var result = _transactionService.InsertTransaction(Transaction);
            if (result == 0)
                return BadRequest("Transaction already exists");
            return Ok(result);
        }
        [HttpPut("EditTransaction")]
        public ActionResult EditTransaction(TransactiondatumVM Transaction)
        {
            Transaction.UpdateTime = DateTime.Now;
            Transaction.UpdateBy = User.Identity.Name;
            var result = _transactionService.EditTransaction(Transaction);
            if (result == 0)
                return BadRequest("Transaction does not exist");
            return Ok(result);
        }
        [HttpGet("SearchTransaction")]
        public ActionResult SearchTransaction(string name)
        {
            var result = _transactionService.SearchTransaction(name);
            if (result == null)
                return BadRequest("Transaction does not exist");
            return Ok(result);
        }
        [HttpGet("GetTransaction")]
        public ActionResult GetTransaction()
        {
            var result = _transactionService.GetTransaction();
            if (result == null)
                return BadRequest("Transaction does not exist");
            return Ok(result);
        }
        [HttpGet("GetTransactionById")]
        public ActionResult GetTransactionById(int id)
        {
            var result = _transactionService.GetTransactionById(id);
            if (result == null)
                return BadRequest("Transaction does not exist");
            return Ok(result);
        }
        [HttpGet("GetTransactionByTicketId")]
        public ActionResult GetTransactionByTicketId(int id)
        {
            var result = _transactionService.GetTransaction_by_TicketID(id);
            if (result == null)
                return BadRequest("Transaction does not exist");
            return Ok(result);
        }
        
        [HttpGet("GetTransactionByVehicleId")]
        public ActionResult GetTransactionByVehicleId(int id)
        {
            var result = _transactionService.GetLatestTransaction_by_VehicleID(id);
            if (result == null)
                return BadRequest("Transaction does not exist");
            return Ok(result);
        }
         
       /* [HttpGet]
        [Route("GetActiveTransactionByReceiptTicketId")]
        public ActionResult GetActiveTransactionByReceiptTicketId(int id)
        {
            var result = _transactionService.GetActiveTransaction_by_ReceiptTicketID(id);
            if (result == null)
                return BadRequest("Transaction does not exist");
            return Ok(result);
        }*/

    }
}
