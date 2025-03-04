using System;
using System.Collections.Generic;

namespace Data.ViewModel
{
    public partial class FeatureVM
    {
        public int FeatureId { get; set; }
        public string FeatureName { get; set; } = null!;
        public string Action { get; set; } = null!;
        public decimal SortOrder { get; set; }
        public int? ParentFeatureId { get; set; }
        public int IsMaster { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
