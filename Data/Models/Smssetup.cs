using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Smssetup
    {
        public int SmssetupId { get; set; }
        public string ScheduleName { get; set; } = null!;
        public string? ScheduleDescription { get; set; }
        public int IsEnable { get; set; }
        public string Smstype { get; set; } = null!;
        public string Smsto { get; set; } = null!;
        public string? Smssubject { get; set; }
        public string? Smsbody { get; set; }
        public string? ColumnSelection { get; set; }
        public string? ScheduleType { get; set; }
        public string? ScheduleTime { get; set; }
        public DateTime? NextRunTime { get; set; }
        public string? FilterDetail { get; set; }
        public string? WhereClause { get; set; }
        public string? Filterstring { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Template { get; set; } = null!;
    }
}
