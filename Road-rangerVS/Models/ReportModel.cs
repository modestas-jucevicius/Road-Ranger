
using System.Net.Mail;

namespace Road_rangerVS.Models
{
	class ReportModel
	{
		private readonly SmtpClient smtpServer = new SmtpClient("smtp.gmail.com"); //Nurodom, iš kur siųsim laiškus
		private readonly MailAddress mailAddress = new MailAddress("mappuab@gmail.com");
		public ReportModel() {
			smtpServer.Port = 587; //gmail port
			smtpServer.Credentials = new System.Net.NetworkCredential("mappuab@gmail.com", "ProgramuSistemos"); //Mūsų gmail
			smtpServer.EnableSsl = true; //Secure socket layer (SSL) naudojimas
		}

		public void sendMail(string recipient, string subject, string body)
		{
			MailMessage mail = new MailMessage();
			mail.From = mailAddress; //Mūsų gmail laikinas, iš kurio siunčia
			mail.To.Add(recipient); //adresas iš textbox
			mail.Subject = subject; //Tema
			mail.Body = body; //Tekstas
			smtpServer.Send(mail); //siunčiam

		}
	}
}
