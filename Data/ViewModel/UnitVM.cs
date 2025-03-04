using System;
using System.Collections.Generic;

namespace Data.ViewModel
{
    public partial class UnitVM
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; } = null!;
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
