namespace Data.ViewModel
{
    public partial class MasterfieldVM
    {
        public int MasterFieldId { get; set; }
        public string FieldName { get; set; } = null!;
        public int Isvisible { get; set; }
        public int IsRequired { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
