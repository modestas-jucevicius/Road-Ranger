using Models.Cars;
using System.Net;
using System.Net.Mail;
using Models.Messages;

namespace MobileApp.Services.Report
{
    public class MailReporter : IReporter
    {
        private MailMessageGenerator generator = new MailMessageGenerator();

        public MailReporter()
        {
        }

        public void SendGeneretedMail(Car car)
        {
            SendMail(new Message
            {
                Subject = "Automobilio vagyste",
                Body = generator.GenerateMessage(car)
            });
        }

        public void SendMail(Message message)
        {
            MailMessage mail = new MailMessage("mappuab@gmail.com", 
                "mappuab@gmail.com", message.Subject, message.Body);

            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com"); //Nurodom, iš kur siųsim laiškus
            smtpServer.UseDefaultCredentials = false;
            smtpServer.Port = 587;              //gmail port
            smtpServer.Credentials = new NetworkCredential("mappuab@gmail.com", "ProgramuSistemos");     //Mūsų gmail
            smtpServer.EnableSsl = true;        //Secure socket layer (SSL) naudojimas
            smtpServer.Send(mail);              //siunčiam
        }
    }
}
