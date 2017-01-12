using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;

namespace AutoServis.Services
{
    public class Mailer
    {
        private static Mailer _instance;
        private readonly SmtpClient _smtp;

        private Mailer(string host, int port, string username, string password, bool enableSsl)
        {
            _smtp = new SmtpClient();

            var credential = new NetworkCredential
            {
                UserName = username,
                Password = password
            };
            _smtp.Credentials = credential;
            _smtp.Host = host;
            _smtp.Port = port;
            _smtp.EnableSsl = enableSsl;
        }

        public static Mailer Create(string host, int port, string username, string password, bool enableSsl)
        {
            return _instance ?? (_instance = new Mailer(host, port, username, password, enableSsl));
        }

        public void SendMail(MailMessage message)
        {
            _smtp.Send(message);
        }
    }
}