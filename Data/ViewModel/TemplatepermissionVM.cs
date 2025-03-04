namespace Data.Models
{
    public partial class TemplatepermissionVM
    {
        public int TemplatePermissionId { get; set; }
        public int IsCreate { get; set; }
        public int IsRead { get; set; }
        public int IsUpdate { get; set; }
        public int IsDelete { get; set; }
        public int IsExecute { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
