
using System;
using System.Collections.Generic;

namespace Data.ViewModel
{
    public partial class CustomfieldVM
    {
        public int CustomFieldId { get; set; }
        public string? FieldName { get; set; }
        public string? DisplayName { get; set; }
        public int IsRequired { get; set; }
        public int? MaxLength { get; set; }
        public int IsVisible { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
