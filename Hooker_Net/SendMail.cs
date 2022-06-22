using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Hooker_GUI
{
    public partial class SendMail : FormBas
    {
        public SendMail()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Alla texter hämtas och knapparna initieras
        /// </summary>
        private void InitieraTexter()
        {
            this.Text = Översätt("Text", this.Text);

            foreach (System.Windows.Forms.Control cc in this.Controls)
            {
                if (cc.Controls.Count == 0)
                {
                    if (cc.Name.StartsWith("lbl") | cc.Name.StartsWith("gbx") | cc.Name.StartsWith("btn"))
                    {
                        cc.Text = Översätt("Text", cc.Text);
                    }
                }
                else
                {
                    if (cc.Name.StartsWith("gbx"))
                    {
                        cc.Text = Översätt("Text", cc.Text);
                    }
                    for (int i = 0; i < cc.Controls.Count; i++)
                    {
                        if (cc.Controls[i].Name.StartsWith("lbl"))
                        {
                            cc.Controls[i].Text = Översätt("Text", cc.Controls[i].Text);
                        }
                    }
                }
            }

            knappkontroller1.btnKnapp0.Visible = false;
            knappkontroller1.btnKnapp1.Visible = false;
            knappkontroller1.btnKnapp2.Visible = false;
            knappkontroller1.btnKnapp3.Visible = false;
            knappkontroller1.btnKnapp4.Enabled = false;
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_SendMail");
        }

        private void SendMail_Load(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            InitieraTexter();
            this.MdiParent = MdiMain;
            this.FormEvent();
            txtMailToAddress.Focus();
            FormsLaddar = true;
            Timglas.DefaultCursor();
        }

        private void FormEvent()
        {
            foreach (var control in Controls.OfType<Control>())
            {
                control.Click += SendMail_Changed;
                control.TextChanged += SendMail_Changed;
            }
        }

        private void SendMail_Changed(object sender, EventArgs e)
        {
            FormsUppdaterad = true;
            knappkontroller1.btnKnapp4.Enabled = true;
        }

        /// <summary>
        /// Sänd mail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            try
            {
                Mail mail = new Mail();
                mail.MailFrom = Systemvariabel.MailFrom;
                mail.Password = Systemvariabel.MailPassword;
                mail.MailTo = txtMailToAddress.Text;
                mail.Subject = txtMailSubject.Text;
                mail.Body = rtbMailBody.Text;

                Timglas.WaitCurson();
                mail.SendMail();
                VisaMeddelande("Skicka_OK");
                this.Close();
                Timglas.DefaultCursor();
            }
            catch (HookerException)
            {
                VisaFelmeddelande(FelID, Feltext);
            }
        }
    }
}
