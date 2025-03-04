using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Customfield
    {
        public int CustomFieldId { get; set; }
        public string? FieldName { get; set; }
        public string? DisplayName { get; set; }
        public int IsRequired { get; set; }
        public int? MaxLength { get; set; }
        public int IsVisible { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
