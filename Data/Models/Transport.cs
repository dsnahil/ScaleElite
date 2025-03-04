using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Transport
    {
        public int TransporterId { get; set; }
        public string? TransporterName { get; set; }
        public int? TransporterCode { get; set; }
        public string CompanyName { get; set; } = null!;
        public long? ContactNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Pincode { get; set; }
        public string? Gstno { get; set; }
        public string? Notes { get; set; }
        public ulong Active { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
