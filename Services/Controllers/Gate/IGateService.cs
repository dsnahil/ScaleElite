using Data.Models;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IGateService
    {
        List<Gate> GetGate();
        Gate GetGate_by_GateId(int GateId);
        List<Gate> SearchGate(string GateName);
        int InsertGate(Gate Gate);
        int EditGate(GateVM GateVM);
        Gate ActivateGate(int GateId);

    }
}
