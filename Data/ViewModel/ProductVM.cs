namespace Data.ViewModel
{
    public partial class ProductVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? ProductCode { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public int IsActive { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
