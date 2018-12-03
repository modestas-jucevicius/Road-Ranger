using Models.Cars;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using Models.Messages;

namespace Services.Report
{
    public class MailReporter : IReporter
    {
        private MailMessageGenerator generator = new MailMessageGenerator();
        private readonly SmtpClient smtpServer = new SmtpClient("smtp.gmail.com"); //Nurodom, iš kur siųsim laiškus

        private MailAddress sender;
        private string recipient;
        private string subject;

        public MailReporter()
        {
            smtpServer.Port = 587;              //gmail port
            var username = ConfigurationSettings.AppSettings["username"];
            var password = ConfigurationSettings.AppSettings["password"];
            smtpServer.Credentials = new NetworkCredential(username, password);     //Mūsų gmail
            smtpServer.EnableSsl = true;        //Secure socket layer (SSL) naudojimas
            InitializeDefaults();
        }

        private void InitializeDefaults()
        {
            sender = new MailAddress(ConfigurationSettings.AppSettings["username"]);
            recipient = ConfigurationSettings.AppSettings["recipient"];
            subject = ConfigurationSettings.AppSettings["subject"];
        }

        public void SendGeneretedMail(Car car)
        {
            SendMail(new Message
            {
                Subject = subject,
                Body = generator.GenerateMessage(car)
            });
        }

        public void SendMail(Message message)
        {
            MailMessage mail = new MailMessage
            {
                From = sender           //Mūsų gmail laikinas, iš kurio siunčia
            };
            mail.To.Add(recipient);     //adresas iš textbox
            mail.Subject = message.Subject;     //Tema
            mail.Body = message.Body;           //Tekstas
            smtpServer.Send(mail);              //siunčiam
        }
    }
}
