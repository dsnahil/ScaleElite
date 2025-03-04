using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Gate
    {
        public int GateId { get; set; }
        public string GateName { get; set; } = null!;
        public string GateType { get; set; } = null!;
        public string? Notes { get; set; }
        public int Active { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
