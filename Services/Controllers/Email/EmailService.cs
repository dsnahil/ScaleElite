using Data.Models;
using Data.ViewModel;

namespace Services
{
    public class EmailService:IEmailService
    {
        private readonly endel_weighbridgeContext _context;

        public EmailService(endel_weighbridgeContext context)
        {
            _context = context;
        }
        public Emailsetup GetEmail()
        {
            var email = _context.Emailsetups;
            if (email == null)
                return null;
            return email.FirstOrDefault();
        }
        public int AddEmailSchedule(Emailsetup Emailsetup)
        {
            Emailsetup.CreatedTime = DateTime.Now;
            _context.Emailsetups.Add(Emailsetup);
            _context.SaveChanges();
            return Emailsetup.EmailSetupId;
        }
        public int ActivateEmailSchedule(int id)
        {
            var email = _context.Emailsetups.FirstOrDefault(p => p.EmailSetupId == id);
            if (email == null)
                return 0;
            email.IsEnable = 1;
            _context.SaveChanges();
            return email.EmailSetupId;
        }
        public int DeleteEmailSchedule(int id)
        {
            var email=_context.Emailsetups.FirstOrDefault(p => p.EmailSetupId == id);
            if (email == null)
                return 0;
            _context.Emailsetups.Remove(email);
            _context.SaveChanges();
            return email.EmailSetupId;
        }
        public int EditEmailSchedule(EmailsetupVM Emailsetup)
        {
            var email = _context.Emailsetups.FirstOrDefault(p => p.EmailSetupId == Emailsetup.EmailSetupId);
            if (email == null)
                return 0;
            email.EmailTo = Emailsetup.EmailTo;
            email.ScheduleName = Emailsetup.ScheduleName;
            email.ScheduleDescription = Emailsetup.ScheduleDescription;
            email.EmailSubject = Emailsetup.EmailSubject;
            email.EmailBody = Emailsetup.EmailBody;
            email.EmailType = Emailsetup.EmailType;
            email.EmailBodyEnding = Emailsetup.EmailBodyEnding;
            email.ColumnSelection = Emailsetup.ColumnSelection;
            email.ScheduleType = Emailsetup.ScheduleType;
            email.ScheduleTime = Emailsetup.ScheduleTime;
            email.NextRunTime = Emailsetup.NextRunTime;
            email.FilterDetail = Emailsetup.FilterDetail;
            email.WhereClause = Emailsetup.WhereClause;
            email.Filterstring = Emailsetup.Filterstring;
            email.UpdateBy = Emailsetup.UpdateBy;
            email.UpdateTime = Emailsetup.UpdateTime;
            _context.SaveChanges();
            return email.EmailSetupId;
        }
        public Emailsetup SearchRecord(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                var emails = _context.Emailsetups.Where(p => p.EmailType == email || p.ScheduleName==email).ToList();
                if (emails.Count > 0)
                    return emails.FirstOrDefault();
            }
            return null;
        }
    }
}
