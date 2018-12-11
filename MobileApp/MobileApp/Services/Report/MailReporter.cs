using Models.Cars;
using System.Net;
using System.Net.Mail;
using Models.Messages;

namespace MobileApp.Services.Report
{
    public class MailReporter : IReporter
    {
        private MailMessageGenerator generator = new MailMessageGenerator();
        private readonly SmtpClient smtpServer = new SmtpClient("smtp.gmail.com"); //Nurodom, iš kur siųsim laiškus

        private MailAddress sender;
        private const string recipient = "mappuab@gmail.com";
        private const string subject = "Automobilio vagyste";

        public MailReporter()
        {
            smtpServer.Port = 587;              //gmail port
            smtpServer.Credentials = new NetworkCredential("mappuab@gmail.com", "ProgramuSistemos");     //Mūsų gmail
            smtpServer.EnableSsl = true;        //Secure socket layer (SSL) naudojimas
            InitializeDefaults();
        }

        private void InitializeDefaults()
        {
            sender = new MailAddress("mappuab@gmail.com");
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
