using System;
using System.Collections.Generic;

namespace Data.ViewModel
{
    public partial class CustomvalueVM
    {
        public int CustomValueId { get; set; }
        public int CustomFieldId { get; set; }
        public string CustomValue1 { get; set; } = null!;
        public string ReceiptTicketId { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public string? UpdatedBy { get; set; }
        public string? UpdatedTime { get; set; }
    }
}
