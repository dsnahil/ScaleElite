using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Unit
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
