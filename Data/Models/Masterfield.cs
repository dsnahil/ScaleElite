using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Masterfield
    {
        public int MasterFieldId { get; set; }
        public string FieldName { get; set; } = null!;
        public int Isvisible { get; set; }
        public int IsRequired { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
