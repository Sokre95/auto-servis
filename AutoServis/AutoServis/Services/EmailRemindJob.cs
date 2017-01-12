using System.Net.Mail;
using Quartz;

namespace AutoServis.Services
{
    public class EmailRemindJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var dataMap = context.JobDetail.JobDataMap;
            var message = new MailMessage();
            message.To.Add(new MailAddress(dataMap.GetString("emailTo")));
            message.From = new MailAddress("najbolji.mehanicar.noreply@gmail.com");
            message.Subject = "Podsjetnik za termin popravka";
            message.Body = dataMap.GetString("message");
            message.IsBodyHtml = true;
            var mailer = Mailer.Create("smtp.gmail.com", 587, "serviserinfo1@gmail.com", "serviser123", true);
            mailer.SendMail(message);
        }
    }
}