using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Usermaster
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? ContactNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Notes { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Active { get; set; }
        public int TemplateId { get; set; }
        public string Salt { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedTime { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int FailedLoginAttempt { get; set; }
        public DateTime? CannotLoginUntilDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
