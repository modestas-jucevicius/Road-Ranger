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
				presenter.sendMail(addressBox.Text, subjectText.Text, textEmail.Text);
				Close(); //uždarom formą
            }
        }
    }
}
