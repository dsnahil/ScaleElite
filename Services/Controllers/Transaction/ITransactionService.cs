using Data.Models;
using Data.ViewModel;

namespace Services
{
    public interface ITransactionService
    {
        int EditTransaction(TransactiondatumVM transaction);
        Transactiondatum GetLatestTransaction_by_VehicleID(int VehicleID);
        List<Transactiondatum> GetTransaction();
        Transactiondatum GetTransactionById(int id);
        Transactiondatum GetTransaction_by_TicketID(int TicketID);
        int InsertTransaction(Transactiondatum Transaction);
        List<Transactiondatum> SearchTransaction(string name);
    }
}