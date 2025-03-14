﻿namespace Data.ViewModels
{
    public partial class AccountVM
    {
        public int AccountId { get; set; }
        public string? AccountCode { get; set; }
        public string AccountName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? ContactNo { get; set; }
        public string? Email { get; set; }
        public string? Notes { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Pincode { get; set; }
        public string? Gstno { get; set; }
        public int Active { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }

    }
}
