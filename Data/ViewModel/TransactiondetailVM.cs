using System;
using System.Collections.Generic;

namespace Data.ViewModel
{
    public partial class TransactiondetailVM
    {
        public int TransactionDetailId { get; set; }
        public int WeightBridgeId { get; set; }
        public string WeightBridgeName { get; set; } = null!;
        public sbyte SequenceNo { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal? GrossWeight { get; set; }
        public DateTime? GrossTime { get; set; }
        public decimal? TareWeight { get; set; }
        public DateTime? TareTime { get; set; }
        public string? WeighmentType { get; set; }
        public int? GateId { get; set; }
        public string? GateName { get; set; }
        public decimal? CaptureWeight { get; set; }
        public DateTime? CaptureTime { get; set; }
        public decimal? NetWeight { get; set; }
        public string? WeightUnit { get; set; }
        public int IsTareManual { get; set; }
        public int IsGrossManual { get; set; }
        public int IsCapturedManual { get; set; }
        public int ReceiptTicketId { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
