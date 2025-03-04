using Data.Models;
using Data.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class GateService : IGateService
    {
        private readonly endel_weighbridgeContext _context;
        public GateService(endel_weighbridgeContext context)
        {
            _context = context;
        }
        public int InsertGate(Gate gate)
        {
            var gat= _context.Gates.Where(p => p.GateName == gate.GateName).FirstOrDefault();
            if (gat != null)
                return 0;
            else
            {
                gate.Active = 1;
                gate.CreatedTime = DateTime.Now;
                gate.GateName = gate.GateName.Trim();
                _context.Gates.Add(gate);
                _context.SaveChanges();
                return gate.GateId;
            }
            
        }
        public int EditGate(GateVM gateVM)
        {
            var gat= _context.Gates.FirstOrDefault(p => p.GateId == gateVM.GateId);
            if (gat == null)
                return 0;
            gat.GateName = gateVM.GateName;
            gat.Active = gateVM.Active;
            gat.GateType = gateVM.GateType;
            gat.Notes = gateVM.Notes;
            gat.UpdatedTime=gateVM.UpdatedTime;
            gat.UpdatedBy=gateVM.UpdatedBy;

            _context.SaveChanges();
            return gat.GateId;
        }
        public List<Gate> SearchGate(string GateName)
        {
            if (!string.IsNullOrEmpty(GateName))
            {
                var gate = _context.Gates.Where(p => p.GateName.Contains(GateName)).ToList();
                if (gate.Count > 0)
                    return gate;
                else
                    return null;
            }
            return null;
        }

        public List<Gate> GetGate()
        {
            return _context.Gates.ToList();
        }

        public Gate GetGate_by_GateId(int id)
        {
            var gate = _context.Gates.Where(p => p.GateId == id).FirstOrDefault();
            if (gate == null)
                return null;
            return gate;
        }
        public Gate ActivateGate(int id)
        {
            var gate = _context.Gates.Where(p => p.GateId == id).FirstOrDefault();
            if (gate == null)
            {
                return null;
            }
            else if (gate.Active == 1)
            {
                gate.Active = 0;
            }
            else
            {
                gate.Active = 1;
            }
            return gate;
        }


        //public ActivateGateResponse ActivateGate(int id)
        //{
        //    var gate = _context.Gates.Where(p => p.GateId == id).FirstOrDefault();
        //    if (id1 == null)
        //    {
        //        return NotFound("Gate not found");
        //    }
        //    else if (id1.Active == 1)
        //    {
        //        id1.Active = 0;
        //    }
        //    else
        //    {
        //        id1.Active = 1;
        //    }
        //    if (gate == null)
        //        return "Gate Deactivated";
        //    return "Gate Activated";
        //}
    }
}
