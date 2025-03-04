using System;
using System.Collections.Generic;

namespace Data.ViewModel
{
    public partial class BarcodesettingVM
    {
        public int BarcodeSettingId { get; set; }
        public string BarcodeFieldName { get; set; } = null!;
        public string BarcodeDisplayName { get; set; } = null!;
        public int IsSelected { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
