using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Applicationsetting
    {
        public int SettingId { get; set; }
        public string ModuleName { get; set; } = null!;
        public string SettingName { get; set; } = null!;
        public string SettingType { get; set; } = null!;
        public string SettingValue { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
