namespace Data.ViewModel
{
    public partial class GateVM
    {
        public int GateId { get; set; }
        public string GateName { get; set; } = null!;
        public string GateType { get; set; } = null!;
        public string? Notes { get; set; }
        public int Active { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
