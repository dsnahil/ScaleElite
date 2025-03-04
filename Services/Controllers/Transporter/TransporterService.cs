using Data.Models;
using Data.ViewModel;

namespace Services
{
    public class TransporterService : ITransporterService
    {
        private readonly endel_weighbridgeContext _context;
        public TransporterService(endel_weighbridgeContext context)
        {
            _context = context;
        }
        public int InsertTransporter(Transport Transport)
        {
            Transport.CreatedTime = DateTime.Now;
            Transport.Active = 1;
            _context.Transports.Add(Transport);
            _context.SaveChanges();
            return Transport.TransporterId;
        }
        public int EditTransporter(TransportVM TransportVM)
        {
            var transp = _context.Transports.FirstOrDefault(p => p.TransporterId == TransportVM.TransporterId);
            if (transp == null)
                return 0;
            transp.TransporterName = TransportVM.TransporterName;
            transp.TransporterCode = TransportVM.TransporterCode;
            transp.CompanyName = TransportVM.CompanyName;
            transp.ContactNo = TransportVM.ContactNo;
            transp.Email = TransportVM.Email;
            transp.Address = TransportVM.Address;
            transp.City = TransportVM.City;
            transp.Pincode = TransportVM.Pincode;
            transp.Notes = TransportVM.Notes;
            transp.UpdateTime = TransportVM.UpdateTime;
            transp.UpdateBy = TransportVM.UpdateBy;

            _context.SaveChanges();
            return transp.TransporterId;
        }
        public List<Transport> SearchTransporter(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var Transports = _context.Transports.Where(t => t.TransporterName == name).ToList();
                if (Transports.Count > 0)
                    return Transports;
            }
            return null;
        }
        public List<Transport> GetTransporter()
        {
            return _context.Transports.ToList();
        }
        public Transport GetTransporter_by_TransporterId(int id)
        {
            if (id != 0)
            {
                var Transport = _context.Transports.Where(p => p.TransporterId == id).ToList();
                if (Transport.Count > 0)
                    return Transport.FirstOrDefault();
            }
            return null;
        }
        public Transport ActivateTransporter(int id)
        {
            var transport = _context.Transports.Where(p => p.TransporterId == id).FirstOrDefault();
            if (transport == null)
                return null;
            else
            {
                if (transport.Active == 1)
                {
                    transport.Active = 0;
                }
                else
                {
                    transport.Active = 1;
                }
            }
            _context.SaveChanges();
            return transport;
        }
    }
}
