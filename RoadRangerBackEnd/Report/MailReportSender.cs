﻿using RoadRangerBackEnd.Cars;
using System.Net.Mail;
using Road_rangerVS.Cars;

namespace RoadRangerBackEnd.Report
{
    public class MailReportSender : IReportSender
    {
        private MailReportMessageGenerator generator = new MailReportMessageGenerator();
        private readonly SmtpClient smtpServer = new SmtpClient("smtp.gmail.com"); //Nurodom, iš kur siųsim laiškus
        private readonly MailAddress mailAddress = new MailAddress("mappuab@gmail.com");

        private readonly string defaultRecipient = "mappuab@gmail.com";
        private readonly string defaultSubject = "Car theft";

        public MailReportSender()
        {
            smtpServer.Port = 587; //gmail port
            smtpServer.Credentials = new System.Net.NetworkCredential("mappuab@gmail.com", "ProgramuSistemos"); //Mūsų gmail
            smtpServer.EnableSsl = true; //Secure socket layer (SSL) naudojimas
        }

        public void SendGeneretedMail(Car car)
        {
            string message = generator.GenerateMessage(car);
            this.SendMail(defaultSubject, message);
        }

        public void SendMail(string subject, string body)
        {
			MailMessage mail = new MailMessage
			{
				From = mailAddress    //Mūsų gmail laikinas, iš kurio siunčia
			};
			mail.To.Add(defaultRecipient);     //adresas iš textbox
            mail.Subject = subject;     //Tema
            mail.Body = body;           //Tekstas
            smtpServer.Send(mail);      //siunčiam
        }
    }
}
