using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hooker_GUI
{
    /// <summary>
    /// Klass för eventhandling för Runda
    /// </summary>
    public partial class RundaInfo : FormBas
    {
        private Point firstPoint;

        private void Runda_Load(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            InitieraTexter();
            this.MdiParent = MdiMain;
            FormEvent();
            dtpDatum.Focus();
            FormsLaddar = false;
            Timglas.DefaultCursor();
        }

        /// <summary>
        /// Hanterar Visa Rondgraf-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp0Click(object sender, EventArgs e)
        {
            if (Runda != null)
            {
                fönsterhanterare1.HanteraVisaRondgraf(Runda);
            }
        }

        /// <summary>
        /// Hanterar Spara & stäng-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp1Click(object sender, EventArgs e)
        {
            this.knappkontroller1_OnKnapp2Click(sender, e);
            this.Close();
        }

        /// <summary>
        /// Hanterar Spara-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            Hooker.Affärslager.RundaAktivitet rundaAktivitet;
            Hooker.Affärslager.RedovisningAktivitet redovisningAktivitet;

            try
            {
                Timglas.WaitCurson();
                if (AllaFältIRundaOK() && AllaFältIRundaHalOK() && AllaFältIRedovisningOK())
                {
                    rundaAktivitet = new Hooker.Affärslager.RundaAktivitet();
                    rundaAktivitet.Spara(Runda, NyRunda, ref FelID, ref Feltext);

                    if (Runda.HarRedovisningar())
                    {
                        redovisningAktivitet = new RedovisningAktivitet();
                        redovisningAktivitet.Spara(Runda, ref FelID, ref Feltext);
                    }
                    Timglas.DefaultCursor();

                    if (cbxHcprond.Checked.Equals(true))
                    {
                        // Den här ska inte användas efter att nya hcp-systemet tagits 
                        //i bruk
                        //UppdateraHcp();
                    }

                    VisaMeddelande("Information_OK");

                    //Nu visar vi rundan som den ser ut i databasen
                    if (NyRunda)
                    {
                        RundaNr = Runda.RundaNr;
                        this.NyRunda = false;
                    }
                    knappkontroller1.btnKnapp0.Enabled = true;

                    if (AppUser.Epostmeddelande == "1")
                    {
                        SendMail();
                        fönsterhanterare1.HanteraVisaRunda(RundaNr.ToString());
                    }
                    else
                    {
                        VisaRunda();
                    }
                }
                else
                {
                    //Om fel returnerades ska objektet städas vid nyupplägg
                    if (NyRunda)
                    {
                        this.Runda = null;
                    }
                }
            }
            catch (HookerException)
            {
                if (NyRunda)
                {
                    this.Runda = null;
                }
                VisaFelmeddelande(FelID, Feltext);
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hanterar Ta bort-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            Hooker.Affärslager.RundaAktivitet rundaAktivitet = new Hooker.Affärslager.RundaAktivitet();
            string svar;

            try
            {
                //Kolla först om rundan ska tas bort 
                svar = VisaFråga("Varning_TABORTRUNDA");

                if (svar.Equals("Ja"))
                {
                    rundaAktivitet.TaBort(Runda, ref FelID, ref Feltext);
                    VisaMeddelande("Information_OK");
                    this.Close();
                }
            }
            catch (HookerException)
            {
                VisaFelmeddelande(FelID, Feltext);
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hanterar Avbryt-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            string svar;

            if (FormsUppdaterad)
            {
                svar = VisaFråga("Varning_UppdateringGjord");
                if (svar.Equals("Ja"))
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// Användaren har fipplat i combon för Bana.
        /// </summary>
        private void cboBana_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Kolla att bana är vald först
            if (((ComboBoxPar)cboBana.SelectedItem).Identifier > 0)
            {
                BanaNr = ((ComboBoxPar)cboBana.SelectedItem).Identifier;
                FyllBanaHal(BanaNr);
                RaknaUtErhallnaSlag();
            }
        }

        /// <summary>
        /// Användaren har fipplat i combon för Spelare.
        /// </summary>
        private void cboSpelare_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Spelare aktuellSpelare;
            //Kolla att gubbe är vald först
            if (((ComboBoxPar)cboSpelare.SelectedItem).Identifier > 0)
            {
                Spelare = (Spelare)((ComboBoxPar)cboSpelare.SelectedItem).Data;
                txtExaktHcp.Text = Spelare.ExaktHcp.ToString();
                RaknaUtErhallnaSlag();
            }
        }

        /// <summary>
        /// Användaren har fipplat i combon för Markör.
        /// </summary>
        private void cboMarkor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBoxPar)cboMarkor.SelectedItem).Identifier > 0)
            {
                Spelare = (Spelare)((ComboBoxPar)cboMarkor.SelectedItem).Data;
                txtFederationNo.Text = Spelare.FederationNo.ToString();
            }
        }

        private void FormEvent()
        {
            foreach (var control in gbxRondinformation.Controls.OfType<Control>())
            {
                control.Click += Runda_Changed;
                control.TextChanged += Runda_Changed;
            }
            foreach (var radioButton in gbxRondinformation.Controls.OfType<RadioButton>())
            {
                radioButton.CheckedChanged += Runda_Changed;
            }
            foreach (var control in gbxKostnader.Controls.OfType<Control>())
            {
                control.Click += Runda_Changed;
                control.TextChanged += Runda_Changed;
            }
            foreach (var control in gbxUt.Controls.OfType<Control>())
            {
                control.Click += Runda_Changed;
                control.TextChanged += Runda_Changed;
                if (control.Name.StartsWith("txtPuttar"))
                {
                    control.TextChanged += GRIDCheckBox_Checked;
                }
            }
            foreach (var control in gbxIn.Controls.OfType<Control>())
            {
                control.Click += Runda_Changed;
                control.TextChanged += Runda_Changed;
                if (control.Name.StartsWith("txtPuttar"))
                {
                    control.TextChanged += GRIDCheckBox_Checked;
                }
            }
            foreach (var control in gbxUt.Controls.OfType<Control>())
            {
                control.Click += Runda_Changed;
                control.TextChanged += Runda_Changed;
                if (control.Name.StartsWith("txtSlag"))
                {
                    control.TextChanged += SlagTextBox_Changed;
                }
            }
            foreach (var control in gbxIn.Controls.OfType<Control>())
            {
                control.Click += Runda_Changed;
                control.TextChanged += Runda_Changed;
                if (control.Name.StartsWith("txtSlag"))
                {
                    control.TextChanged += SlagTextBox_Changed;
                }
            }
        }

        private void Runda_Changed(object sender, EventArgs e)
        {
            FormsUppdaterad = true;
            knappkontroller1.btnKnapp1.Enabled = true;
            knappkontroller1.btnKnapp2.Enabled = true;
        }

        private void GRIDCheckBox_Checked(object sender, EventArgs e)
        {
            TextBox txtPuttar = (TextBox)sender;
            string cc = txtPuttar.Name;

            if (AppUser.GIR.Equals("M"))
            {
                return;
            }
            else
            {
                this.SattGIRCheckBox(cc);
            }
        }

        private void SlagTextBox_Changed(object sender, EventArgs e)
        {
            TextBox txtSlag = (TextBox)sender;
            string cc = txtSlag.Name;
            this.SattPoangTextBox(cc);
        }

        private void rbnGul_Click(object sender, EventArgs e)
        {
            RaknaUtErhallnaSlag();
        }

        private void rbnRod_Click(object sender, EventArgs e)
        {
            RaknaUtErhallnaSlag();
        }

        private void cbxTavlingsrond_CheckedChanged(object sender, EventArgs e)
        {
            txtPlacering.Enabled = true;
        }

        private void cboGolfklubb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NyRunda)
            {
                Runda = new Runda();
            }

            if (!FormsLaddar)
            {
                BanaNr = 0;
            }

            GolfklubbNr = ((ComboBoxPar)cboGolfklubb.SelectedItem).Identifier;
            FyllBanorCombo();
        }

        /// <summary>
        /// Högerklick öppnar fönster för noteringar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RundaInfo_MouseDownEvent(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        if (Runda == null)
                        {
                            Runda = new Runda();
                        };
                        RundaNotering rundaNotering = new RundaNotering(Runda);
                        rundaNotering.Show(); //places the Window at the pointer position
                    }
                    break;
            }
        }

        /// <summary>
        /// Skapa mail om registrerad runda
        /// </summary>
        private void SendMail()
        {
            string resultat;
            StringBuilder email = new StringBuilder();
            try
            {
                Mail Mailet = new Mail
                {
                    MailFrom = Systemvariabel.MailFrom,
                    Password = Systemvariabel.MailPassword,
                    MailTo = AppUser.Epostadress,
                    IsHTML = true,
                    SmtpHost = Systemvariabel.SmtpHost,
                    Port = Int32.Parse(Systemvariabel.Port),
                    Subject = "Registrerad golfrond"
                };

                email.Append("<b>Hej " + AppUser.Anvandarnamn + "</b><br/><br/>");
                email.Append("Du har registerat en golfrunda, " + Runda.Notering.ToString());
                email.Append(", med " + cboMarkor.SelectedItem + " som markör." + "<br/>");
                email.Append("Poängen uppgick till " + txtSummaPoang.Text + ".<br/>");
                email.Append("<br/>");
                email.Append("Speldatum: " + dtpDatum.Value.ToShortDateString() + "<br/>");
                email.Append("Golklubb: " + cboGolfklubb.SelectedItem.ToString() + "<br/>");
                email.Append("Bana: " + cboBana.SelectedItem.ToString() + "<br/>");
                Mailet.Body = email.ToString();

                Timglas.WaitCurson();
                resultat = Mailet.Skicka_Mail();

                if (resultat == "OK")
                {
                    VisaMeddelande("Skicka_OK");
                }
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
