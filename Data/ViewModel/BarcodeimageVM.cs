using System;
using System.Collections.Generic;

namespace Data.ViewModel
{
    public partial class BarcodeimageVM
    {
        public int BarcodeImageId { get; set; }
        public int ReceiptTicketId { get; set; }
        public string ImagePath { get; set; } = null!;
        public string BarcodeString { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
