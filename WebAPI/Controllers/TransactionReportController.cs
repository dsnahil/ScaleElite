using Data.Models;
using Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionReportController : ControllerBase
    {
        private readonly ITransactionReportService _itransactionreportservice;

        public TransactionReportController(ITransactionReportService itransactionreportservice)
        {
            _itransactionreportservice = itransactionreportservice;
        }
        [HttpGet]
        public ActionResult<Transactiondetail> GetTransactionReport()
        {
            var transactionreport = _itransactionreportservice.GetTransactionReport();
            if (transactionreport == null)
            {
                return NotFound();
            }
            return Ok(transactionreport);
        }
        [HttpGet]
        [Route("/id")]
        public ActionResult GetTransactionReport_by_TransactionDate(TransactionReportVM report)
        {
            var transactionreport = _itransactionreportservice.GetTransactionReport_by_TransactionDate(a, b);
            if (transactionreport == null)
            {
                return NotFound();
            }
            return Ok(transactionreport);
        }
    }
}
