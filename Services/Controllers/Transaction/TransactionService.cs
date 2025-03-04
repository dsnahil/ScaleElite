using Data.Models;
using Data.ViewModel;

namespace Services
{
    public class TransactionService : ITransactionService
    {
        private readonly endel_weighbridgeContext _context;
        public TransactionService(endel_weighbridgeContext context)
        {
            _context = context;
        }
        public int InsertTransaction(Transactiondatum Transaction)
        {

            Transaction.CreationTime = DateTime.Now;
            int maxTicketId = _context.Transactiondata.Max(p => p.TicketId);
            Transaction.DisplayTicketId = maxTicketId + 1;
            Guid receipt = Guid.NewGuid();
            Transaction.ReceiptTicketId = Convert.ToString(receipt);
            _context.Transactiondata.Add(Transaction);
            _context.SaveChanges();
            return Transaction.TicketId;
        }
        public Transactiondatum GetTransactionById(int id)
        {
            if (id != 0)
            {
                var transaction = _context.Transactiondata.Where(p => p.TicketId == id).ToList();
                if (transaction.Count > 0)
                    return transaction.FirstOrDefault();
            }
            return null;
        }
        public int EditTransaction(TransactiondatumVM transaction)
        {
            var transac = _context.Transactiondata.FirstOrDefault(p => p.TicketId == transaction.TicketId);
            if (transac == null)
                return 0;
            transac.ProductName = transaction.ProductName;
            transac.Charges = transaction.Charges;
            transac.UpdateTime = transaction.UpdateTime;
            transac.UpdateBy = transaction.UpdateBy;

            _context.SaveChanges();
            return transac.TicketId;

        }
        public List<Transactiondatum> SearchTransaction(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var Transactions = _context.Transactiondata.Where(p => p.TransactionType == name || p.TransactionMode == name).ToList();
                if (Transactions.Count > 0)
                    return Transactions;
            }
            return null;
        }
        public List<Transactiondatum> GetTransaction()
        {
            var Transactions = _context.Transactiondata.ToList();
            if (Transactions.Count > 0)
                return Transactions;
            return null;
        }

        public Transactiondatum GetLatestTransaction_by_VehicleID(int VehicleID)
        {
            if (VehicleID != 0)
            {
                var transactionDatas = _context.Transactiondata.Where(p => p.VehicleId == VehicleID).ToList();
                if (transactionDatas.Count > 0)
                    return transactionDatas.FirstOrDefault();
            }
            return null;
        }
        public Transactiondatum GetTransaction_by_TicketID(int TicketID)
        {
            if (TicketID != 0)
            {
                var transactionDatas = _context.Transactiondata.Where(p => p.TicketId == TicketID).ToList();
                if (transactionDatas.Count > 0)
                    return transactionDatas.FirstOrDefault();
            }
            return null;
        }

        /*        public Transactiondatum GetActiveTransactionData_by_ReceiptTicketID(int ReceiptTicketID)
        {
            if (ReceiptTicketID != null)
            {
                var transactionDatas = _context.Transactiondata.Where(p => p.ReceiptTicketId == ReceiptTicketID).ToList();
                if (transactionDatas.Count > 0)
                {
                    var result = new List<Transactiondatum>(transactionDatas.Select(x => new Transactiondatum
                    {
                        TicketID = x.TicketID,
                        DriverID = x.DriverID,
                        VehicleID = x.VehicleID,
                        Status = x.Status,
                        TransactionMode = x.TransactionMode,
                        AccountID = x.AccountID,
                        TransporterID = x.TransporterID,
                        ReceiptTicketID = x.ReceiptTicketID,
                        Charges = x.Charges,
                        TransactionType = x.TransactionType,
                        CreationTime = x.CreationTime,
                        CreatedBy = x.CreatedBy
                    }).ToList());

                    var _transaction = result.FirstOrDefault();

                    if (transactionDatas.FirstOrDefault().TransactionDetails.Where(p => p.TareWeight != null).Count() > 0)
                    {
                        _transaction.TareWeight = transactionDatas.FirstOrDefault().TransactionDetails.Where(p => p.TareWeight != null).FirstOrDefault().TareWeight;
                        _transaction.TareTime = transactionDatas.FirstOrDefault().TransactionDetails.Where(p => p.TareTime != null).FirstOrDefault().TareTime;
                    }

                    if (transactionDatas.FirstOrDefault().TransactionDetails.Where(p => p.GrossWeight != null).Count() > 0)
                    {
                        _transaction.GrossWeight = transactionDatas.FirstOrDefault().TransactionDetails.Where(p => p.GrossWeight != null).FirstOrDefault().GrossWeight;
                        _transaction.GrossTime = transactionDatas.FirstOrDefault().TransactionDetails.Where(p => p.GrossTime != null).FirstOrDefault().GrossTime;
                    }

                    if (transactionDatas.FirstOrDefault().TransactionDetails.Where(p => p.NetWeight != null).Count() > 0)
                    {
                        _transaction.NetWeight = transactionDatas.FirstOrDefault().TransactionDetails.Where(p => p.NetWeight != null).FirstOrDefault().NetWeight;
                    }

                    return _transaction;
                }
            }
            return null;
        }
*/


    }
}
