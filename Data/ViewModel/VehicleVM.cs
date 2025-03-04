namespace Data.ViewModel
{
    public partial class VehicleVM
    {
        public int VehicleId { get; set; }
        public string VehicleNumber { get; set; } = null!;
        public string? VehicleType { get; set; }
        public decimal? TareWeight { get; set; }
        public DateTime? TareTime { get; set; }
        public string? Notes { get; set; }
        public int? AccountId { get; set; }
        public decimal? MinWeight { get; set; }
        public decimal? MaxWeight { get; set; }
        public int IsActive { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdateTime { get; set; }

    }
}