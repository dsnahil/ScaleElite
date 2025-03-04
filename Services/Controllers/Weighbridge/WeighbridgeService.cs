using Data.Models;
using Data.ViewModel;
using Microsoft.EntityFrameworkCore;


namespace Services
{
    public class WeighbridgeService : IWeighbridgeService
    {
        private readonly endel_weighbridgeContext _context;
        public WeighbridgeService(endel_weighbridgeContext context)
        {
            _context = context;
        }
        public int InsertWeighbridge(Weighbridge Weighbridge)
        {
            var weigh = _context.Weighbridges.Where(p => p.ScaleName == Weighbridge.ScaleName).FirstOrDefault();
            if (weigh != null)
                return 0;
            else
            {
                Weighbridge.CreatedTime = DateTime.Now;
                Weighbridge.IsActive = 1;
                _context.Weighbridges.Add(Weighbridge);
                _context.SaveChanges();
                return Weighbridge.WeighbridgeId;
            }
        }
        public int EditWeighbridge(WeighbridgeVM Weighbridge)
        {
            /* if (existingWeighbridge == null)
             {
                 return NotFound("Weighbridge not found");
             }
             existingWeighbridge.ScaleName = updatedWeighbridge.ScaleName;
             existingWeighbridge.MaxCapacity = updatedWeighbridge.MaxCapacity;
             existingWeighbridge.IsActive = updatedWeighbridge.IsActive;
             existingWeighbridge.Unit = updatedWeighbridge.Unit;
             existingWeighbridge.ConnectionType = updatedWeighbridge.ConnectionType;
             existingWeighbridge.SerialPort = updatedWeighbridge.SerialPort;
             existingWeighbridge.DataBits = updatedWeighbridge.DataBits;
             existingWeighbridge.BaudRate = updatedWeighbridge.BaudRate;
             existingWeighbridge.StopBits = updatedWeighbridge.StopBits;
             existingWeighbridge.Parity = updatedWeighbridge.Parity;
             existingWeighbridge.TotalStringLength = updatedWeighbridge.TotalStringLength;
             existingWeighbridge.Format = updatedWeighbridge.Format;
             existingWeighbridge.StartStringCharacter = updatedWeighbridge.StartStringCharacter;
             existingWeighbridge.NewLine = updatedWeighbridge.NewLine;
             existingWeighbridge.IsDecimalCharacterInString = updatedWeighbridge.IsDecimalCharacterInString;
             existingWeighbridge.WeightStartFrom = updatedWeighbridge.WeightStartFrom;
             existingWeighbridge.ReverseString = updatedWeighbridge.ReverseString;
             existingWeighbridge.WeightLength = updatedWeighbridge.WeightLength;
             existingWeighbridge.Handshake = updatedWeighbridge.Handshake;
             existingWeighbridge.IndicatorId = updatedWeighbridge.IndicatorId;*/

            var weigh = _context.Weighbridges.FirstOrDefault(p => p.WeighbridgeId == Weighbridge.WeighbridgeId);
            if (weigh == null)
                return 0;
            weigh.ScaleName = Weighbridge.ScaleName;
            weigh.MaxCapacity = Weighbridge.MaxCapacity;
            weigh.IncrementSize = Weighbridge.IncrementSize;
            weigh.UnitId = Weighbridge.UnitId;
            weigh.IsActive = Weighbridge.IsActive;
            weigh.ConnectionType = Weighbridge.ConnectionType;
            weigh.Ipaddress = Weighbridge.Ipaddress;
            weigh.Ipport = Weighbridge.Ipport;
            weigh.Comport = Weighbridge.Comport;
            weigh.BaudRate = Weighbridge.BaudRate;
            weigh.DataBits = Weighbridge.DataBits;
            weigh.StopBits = Weighbridge.StopBits;
            weigh.Parity = Weighbridge.Parity;
            weigh.TotalStringLength = Weighbridge.TotalStringLength;
            weigh.StartStringChar = Weighbridge.StartStringChar;
            weigh.Format = Weighbridge.Format;
            weigh.StringStartingValue = Weighbridge.StringStartingValue;
            weigh.IsDecimalInString = Weighbridge.IsDecimalInString;
            weigh.DecimalPointLocation = Weighbridge.DecimalPointLocation;
            weigh.IsReverseString = Weighbridge.IsReverseString;
            weigh.WeightStartFrom = Weighbridge.WeightStartFrom;
            weigh.WeightLength = Weighbridge.WeightLength;
            weigh.Handshake = Weighbridge.Handshake;
            weigh.IndicatorId = Weighbridge.IndicatorId;
            weigh.UpdateTime = Weighbridge.UpdateTime;
            weigh.UpdateBy = Weighbridge.UpdateBy;

            _context.SaveChanges();
            return Weighbridge.WeighbridgeId;

        }
        public Weighbridge GetWeighbridge_by_WeighbridgeId(int id)
        {
            if (id != 0)
            {
                var Weighbridges = _context.Weighbridges.Where(p => p.WeighbridgeId == id).ToList();
                if (Weighbridges.Count > 0)
                    return Weighbridges.FirstOrDefault();
            }
            return null;
        }

        public List<Weighbridge> GetWeighbridge()
        {
            return _context.Weighbridges.ToList();
        }
        public Weighbridge ActivateWeighbridge(int id)
        {
            var Weighbridge = _context.Weighbridges.Where(p => p.WeighbridgeId == id).FirstOrDefault();
            if (Weighbridge == null)
            {
                return null;
            }
            else if (Weighbridge.IsActive == 1)
            {
                Weighbridge.IsActive = 0;
            }
            else
            {
                Weighbridge.IsActive = 1;
            }
            _context.SaveChanges();
            return Weighbridge;
        }

    }
}
