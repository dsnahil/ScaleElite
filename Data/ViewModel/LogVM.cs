using System;
using System.Collections.Generic;

namespace Data.ViewModel
{
    public partial class LogVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Thread { get; set; } = null!;
        public string Level { get; set; } = null!;
        public string Logger { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string? Exception { get; set; }
        public string CreatedBy { get; set; } = null!;
        public int CreatedTime { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
