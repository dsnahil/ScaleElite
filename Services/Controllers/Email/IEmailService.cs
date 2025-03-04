using Data.Models;
using Data.ViewModel;

namespace Services
{
    public interface IEmailService
    {
        int AddEmailSchedule(Emailsetup Emailsetup);
        int ActivateEmailSchedule(int id);
        int DeleteEmailSchedule(int id);
        int EditEmailSchedule(EmailsetupVM Emailsetup);
        Emailsetup SearchRecord(string email);
        Emailsetup GetEmail();
    }
}
