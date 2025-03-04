using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Weighbridge
    {
        public int WeighbridgeId { get; set; }
        public string ScaleName { get; set; } = null!;
        public string? MaxCapacity { get; set; }
        public string? IncrementSize { get; set; }
        public int? UnitId { get; set; }
        public int IsActive { get; set; }
        public string? ConnectionType { get; set; }
        public string? Ipaddress { get; set; }
        public string? Ipport { get; set; }
        public string? Comport { get; set; }
        public string? BaudRate { get; set; }
        public sbyte? DataBits { get; set; }
        public string? StopBits { get; set; }
        public string? Parity { get; set; }
        public short? TotalStringLength { get; set; }
        public string? StartStringChar { get; set; }
        public string? Format { get; set; }
        public string? StringStartingValue { get; set; }
        public int? IsDecimalInString { get; set; }
        public short? DecimalPointLocation { get; set; }
        public int? IsReverseString { get; set; }
        public string? WeightStartFrom { get; set; }
        public string? WeightLength { get; set; }
        public string? Handshake { get; set; }
        public int? IndicatorId { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
