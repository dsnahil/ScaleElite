using Data.Models;
using System;

namespace Services
{
    public class TransactionReportService
    {
        private readonly endel_weighbridgeContext _context;
        public TransactionReportService(endel_weighbridgeContext context)
        {
            _context = context;
        }
        public Transactiondetail GetTransactionReport()
        {
            return _context.Transactiondetails.FirstOrDefault();
        }
        /*public Transactiondetail GetTransactionReport_by_TransactionDate(DateTime a, DateTime b)
        {
            return _context.Transactiondetails.FirstOrDefault(x => x.TransactionDetailId == id);
        }*/
    }
}
