using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Templatepermission
    {
        public int TemplatePermissionId { get; set; }
        public int FeatureId { get; set; }
        public int TemplateId { get; set; }
        public int IsCreate { get; set; }
        public int IsRead { get; set; }
        public int IsUpdate { get; set; }
        public int IsDelete { get; set; }
        public int IsExecute { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
