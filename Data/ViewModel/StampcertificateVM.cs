namespace Data.ViewModel
{
    public partial class StampcertificateVM
    {
        public int StampId { get; set; }
        public string StampName { get; set; } = null!;
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string? IssuedAuth { get; set; }
        public int? StampCreatedBy { get; set; }
        public byte[]? StampPdf { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
