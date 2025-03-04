﻿using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Transactiondatum
    {
        public int TicketId { get; set; }
        public int DisplayTicketId { get; set; }
        public int? DriverId { get; set; }
        public string? DriverName { get; set; }
        public int? VehicleId { get; set; }
        public string VehicleNumber { get; set; } = null!;
        public string? Status { get; set; }
        public string? TransactionMode { get; set; }
        public int? AccountId { get; set; }
        public string? AccountName { get; set; }
        public int? TransporterId { get; set; }
        public string? TransporterName { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string ReceiptTicketId { get; set; } = null!;
        public decimal? Charges { get; set; }
        public string? TransactionType { get; set; }
        public decimal? FirstWeight { get; set; }
        public DateTime? FirstTime { get; set; }
        public string? FirstWb { get; set; }
        public decimal? SecondWeight { get; set; }
        public DateTime? SecondTime { get; set; }
        public string? SecondWb { get; set; }
        public decimal? TareWeight { get; set; }
        public decimal? GrossWeight { get; set; }
        public DateTime? TareTime { get; set; }
        public DateTime? Grosstime { get; set; }
        public DateTime CreationTime { get; set; }
        public string? TransactionCreatedBy { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
