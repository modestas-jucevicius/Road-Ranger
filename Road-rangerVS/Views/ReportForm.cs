using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using Road_rangerVS.Presenters;

namespace Road_rangerVS
{
    public partial class ReportForm : Form
    {

		private ReportPresenter presenter;

		public ReportForm()
        {
            InitializeComponent();
    presenter = new ReportPresenter();

        }

        private void ReportForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(subjectText.Text) || string.IsNullOrWhiteSpace(addressBox.Text) ||
                string.IsNullOrWhiteSpace(textEmail.Text))
            {
                MessageBox.Show("Missing fields!", "Mistake");
            }
            else
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com"); //Nurodom, iš kur siųsim laiškus
                mail.From = new MailAddress("mappuab@gmail.com");//Mūsų gmail laikinas, iš kurio siunčia
                mail.To.Add(addressBox.Text); //adresas iš textbox
                mail.Subject = subjectText.Text; //Tema
                mail.Body = textEmail.Text; //Tekstas

                SmtpServer.Port = 587; //gmail port
                SmtpServer.Credentials = new System.Net.NetworkCredential("mappuab@gmail.com", "ProgramuSistemos"); //Mūsų gmail
                SmtpServer.EnableSsl = true; //Secure socket layer (SSL) naudojimas
                SmtpServer.Send(mail); //siunčiam
                Close(); //uždarom formą
            }
        }
    }
}
