using Data.Models;
using Data.ViewModel;

namespace Services
{
    public interface IWeighbridgeService
    {
        List<Weighbridge> GetWeighbridge();
        Weighbridge GetWeighbridge_by_WeighbridgeId(int WeighbridgeId);
        int InsertWeighbridge(Weighbridge Weighbridge);
        int EditWeighbridge(WeighbridgeVM Weighbridge);
        Weighbridge ActivateWeighbridge(int WeighbridgeId);

    }
}
