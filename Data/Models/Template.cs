using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Template
    {
        public int TemplateId { get; set; }
        public string TemplateName { get; set; } = null!;
        public int Active { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
