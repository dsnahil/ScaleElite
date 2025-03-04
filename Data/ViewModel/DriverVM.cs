namespace Data.ViewModel
{
    public partial class DriverVM
    {
        public int DriverId { get; set; }
        public string DriverName { get; set; } = null!;
        public string? Photo { get; set; }
        public string? Notes { get; set; }
        public int? AccountId { get; set; }
        public string? IdproofScan { get; set; }
        public string? IdproofType { get; set; }
        public string? IdproofNo { get; set; }
        public int Active { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
