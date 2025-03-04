using Data.Models;
using Data.ViewModel;

namespace Services
{
  public interface ITransporterService
  {
    List<Transport> GetTransporter();
    public List<Transport> SearchTransporter(string TransporterName);
    int InsertTransporter(Transport Transport);
    int EditTransporter(TransportVM TransportVM);
    Transport GetTransporter_by_TransporterId(int id);
    Transport ActivateTransporter(int TransporterId);


  }
}
