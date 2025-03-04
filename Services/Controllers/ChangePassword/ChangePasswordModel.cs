namespace Data.Models
{
    public class ChangePasswordModel
    {
        public string UserName { get; set; }
        public string CurrentPassword { get; set; }
        public string UserPassword { get; set; }
        public string ConfirrmPasssword { get; set; }
    }
}