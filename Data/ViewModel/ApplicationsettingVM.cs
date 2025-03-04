
namespace Data.ViewModels
{
    public partial class ApplicationsettingVM
    {
        public int SettingId { get; set; }
        public string ModuleName { get; set; } = null!;
        public string SettingName { get; set; } = null!;
        public string SettingValue { get; set; } = null!;
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
