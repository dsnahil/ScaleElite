using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleNumber { get; set; } = null!;
        public string? VehicleType { get; set; }
        public decimal? TareWeight { get; set; }
        public DateTime? TareTime { get; set; }
        public string? Notes { get; set; }
        public int? AccountId { get; set; }
        public decimal? MinWeight { get; set; }
        public decimal? MaxWeight { get; set; }
        public int IsActive { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
