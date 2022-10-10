using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Hooker_GUI
{
    public partial class AnvandareInfo : FormBas
    {
        #region Egenskaper
        public Anvandare Anvandare { get; set; }
        public Spelare Spelare { get; set; }
        public int AnvandarID { get; set; }
        public bool NyAnvandare { get; set; }
        private bool NyLosen { get; set; }
        #endregion

        public AnvandareInfo()
        {
            FormsLaddar = true;
            InitializeComponent();
        }

        #region publika metoder
        /// <summary>
        /// Ny Användare initieras
        /// </summary>
        public void InitieraNyAnvandare()
        {
            try
            {
                NyAnvandare = true;
                FyllSpelareCombo();
                FyllComboBoxKod(cboAnvandargrupp, Kodtabell.Anvandargrupper, "01");
                FyllComboBoxKod(cboWebBrowser, Kodtabell.WebBrowsers, "01");
                knappkontroller1.btnKnapp0.Enabled = false;
                knappkontroller1.btnKnapp1.Enabled = false;
                knappkontroller1.btnKnapp2.Enabled = false;
                knappkontroller1.btnKnapp3.Enabled = false;
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Visa användare
        /// </summary>
        public void VisaAnvandare()
        {
            AnvandareAktivitet anvandarAktivitet = new AnvandareAktivitet();
            //if (!NyAnvandare)
            //{
            //    Anvandare = (Anvandare)AppUser;
            //    Spelare = (Spelare)AppUser;
            //}
            try
            {
                Anvandare = anvandarAktivitet.HämtaAnvandare(AnvandarID);

                if (Anvandare != null)
                {
                    NyLosen = false;
                    FyllBild();
                    knappkontroller1.btnKnapp0.Enabled = true;
                    knappkontroller1.btnKnapp2.Enabled = false;
                    knappkontroller1.btnKnapp3.Enabled = true;
                    FormsLaddar = false;
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        #endregion

        #region Privata metoder
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

            foreach (System.Windows.Forms.Control cc in gbxGIR.Controls)
            {
                if (cc.Name.StartsWith("rbn"))
                {
                    cc.Text = Översätt("Text", cc.Text);
                }
            }

            knappkontroller1.btnKnapp0.Visible = false;
            knappkontroller1.btnKnapp1.Enabled = true;
            knappkontroller1.btnKnapp2.Enabled = false;
            knappkontroller1.btnKnapp3.Enabled = false;
            knappkontroller1.btnKnapp1.Text = Översätt("Text", "Knapp_SendMail");
            knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_Spara");
            knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_TaBort");
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
        }

        /// <summary>
        /// Hämta alla Spelare och fyll combon.
        /// </summary>
        private void FyllSpelareCombo()
        {
            SpelareAktivitet spelareAktivitet = new SpelareAktivitet();

            try
            {
                List<Spelare> spelarLista = spelareAktivitet.SökSpelare("", "");

                if (spelarLista.Count > 0)
                {
                    if (cboSpelare.Items.Count == 0)
                    {
                        cboSpelare.Items.Clear();
                        cboSpelare.Items.Add(new ComboBoxPar(0, "", ""));
                        for (int i = 0; i < spelarLista.Count; i++)
                        {
                            cboSpelare.Items.Add(new ComboBoxPar(spelarLista[i].AktuelltSpelarID,
                                spelarLista[i].Namn, spelarLista[i]));
                        }
                    }

                    if (!NyAnvandare)
                    {
                        cboSpelare.SelectedItem = AppUser.SpelarID;
                    }
                    cboSpelare.DisplayMember = "visa";
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Bilden fylls med användarens data från databasen
        /// </summary>
        private void FyllBild()
        {
            //Spelare = null;
            //SpelareAktivitet spelareAktivitet = new SpelareAktivitet();
            //Spelare = spelareAktivitet.HämtaSpelare(Anvandare.AktuelltSpelarID);

            txtAnvandarnamn.Text = Anvandare.Anvandarnamn;

            //if (Spelare.Namn != null)
            //{
            //    txtSpelare.Text = Spelare.Namn;
            //}
            FyllSpelareCombo();
            FyllComboBoxKod(cboAnvandargrupp, Kodtabell.Anvandargrupper, Anvandare.Anvandargrupp);
            FyllComboBoxKod(cboWebBrowser, Kodtabell.WebBrowsers, Anvandare.WebBrowser);
            FyllComboBoxKod(cboSprakkod, Kodtabell.Sprakkod, Anvandare.Sprakkod);
            txtEpostadress.Text = Anvandare.Epostadress;
            txtLosenord.Text = Anvandare.Losenord;
            txtLosenord.PasswordChar = '\u25CF';
            txtKonfirmera.Text = string.Empty;
            txtKonfirmera.Enabled = false;
            cboSpelare.SelectedItem = Anvandare.SpelarID;

            switch (Anvandare.GIR)
            {
                case "U":
                    rbnUtanHcp.Checked = true;
                    break;
                case "H":
                    rbnMedHcp.Checked = true;
                    break;
                case "M":
                    rbnManuell.Checked = true;
                    break;
                default:
                    rbnManuell.Checked = true;
                    break;
            }

            switch (Anvandare.Epostmeddelande)
            {
                case "0":
                    cbxEpost.Checked = false;
                    break;
                case "1":
                    cbxEpost.Checked = true;
                    break;
            }

            if (string.IsNullOrEmpty(Anvandare.SenastInloggadDatum) ||
                Anvandare.SenastInloggadDatum == DateTime.MinValue.ToString())
            {
                dtpInloggadSenast.CustomFormat = " ";
                dtpInloggadSenast.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtpInloggadSenast.Value = Convert.ToDateTime(Anvandare.SenastInloggadDatum);
                dtpInloggadSenast.CustomFormat = Anvandare.SenastInloggadDatum;
            }

            if (string.IsNullOrEmpty(Anvandare.SenastByttLosenordDatum) ||
                Anvandare.SenastByttLosenordDatum == DateTime.MinValue.ToString())
            {
                dtpSenastByttLosen.CustomFormat = " ";
                dtpSenastByttLosen.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtpSenastByttLosen.Value = Convert.ToDateTime(Anvandare.SenastByttLosenordDatum);
                dtpSenastByttLosen.CustomFormat = Anvandare.SenastByttLosenordDatum;
            }
            txtAnvandarnamn.Focus();
            knappkontroller1.btnKnapp2.Enabled = false;
            knappkontroller1.btnKnapp3.Enabled = false;
            FormsUppdaterad = false;
        }

        /// <summary>
        /// Gå igenom alla fält i bilden för Anvandare innan uppdatering
        /// </summary>
        /// <returns>True om OK annars false</returns>
        private bool AllaFältOK()
        {
            bool nyLosenOK;
            try
            {
                if (NyAnvandare)
                {
                    Anvandare = new Anvandare
                    {
                        SenastByttLosenordDatum = string.Empty
                    };
                }
                else
                {
                    Anvandare = Anvandare;
                }

                //Alla fält från bilden flyttas till objektet
                Anvandare.Anvandarnamn = txtAnvandarnamn.Text.ToString().Trim();

                if (cboSpelare.SelectedIndex != -1)
                {
                    Anvandare.SpelarID = ((ComboBoxPar)cboSpelare.SelectedItem).Identifier;
                }
                else
                {
                    Anvandare.SpelarID = 0;
                }

                if (cboAnvandargrupp.SelectedIndex != -1)
                {
                    Anvandare.Anvandargrupp = ((ComboBoxKod)cboAnvandargrupp.SelectedItem).Kod;
                }

                if (NyLosen)
                {
                    nyLosenOK = this.KollaNyLosen(txtLosenord.Text, txtKonfirmera.Text);
                    if (!nyLosenOK)
                    {
                        return false;
                    }
                    Anvandare.SenastByttLosenordDatum = DateTime.Now.ToString("yyyy-MM-dd");
                }
                Anvandare.Losenord = txtLosenord.Text.ToString();
                Anvandare.Epostadress = txtEpostadress.Text.ToString();

                if (rbnUtanHcp.Checked)
                {
                    Anvandare.GIR = "U";
                }
                else if (rbnMedHcp.Checked)
                {
                    Anvandare.GIR = "H";
                }
                else if (rbnManuell.Checked)
                {
                    Anvandare.GIR = "M";
                }
                else
                {
                    Anvandare.GIR = string.Empty;
                }

                if (NyLosen)
                {
                    Anvandare.SenastByttLosenordDatum = DateTime.Today.ToString("yyyy-MM-dd");
                }

                if (cboWebBrowser.SelectedIndex != -1)
                {
                    Anvandare.WebBrowser = ((ComboBoxKod)cboWebBrowser.SelectedItem).Kod;
                }
                else
                {
                    Anvandare.WebBrowser = string.Empty;
                }

                if (cboSprakkod.SelectedIndex != -1)
                {
                    Anvandare.Sprakkod = ((ComboBoxKod)cboSprakkod.SelectedItem).Kod;
                }
                else
                {
                    Anvandare.Sprakkod = string.Empty;
                }

                if (cbxEpost.Checked)
                {
                    Anvandare.Epostmeddelande = "1";
                }
                else
                {
                    Anvandare.Epostmeddelande = "0";
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Kollar att nytt lösen är korrekt
        /// </summary>
        /// <param name="losen"></param>
        /// <param name="konfirmera"></param>
        /// <returns>True eller false</returns>
        private bool KollaNyLosen(string losen, string konfirmera)
        {
            bool result = false;

            if (losen.Equals(konfirmera))
            {
                result = true;
            }
            else
            {
                VisaFelmeddelande("FELLOSEN");
            }

            return result;
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
                    MailTo = Anvandare.Epostadress,
                    IsHTML = true,
                    SmtpHost = Systemvariabel.SmtpHost,
                    Port = Int32.Parse(Systemvariabel.Port),
                    Subject = "Registrerade användaruppgifter"
                };

                email.Append("<b>Hej " + Anvandare.Anvandarnamn + "</b><br/><br/>");
                email.Append("<p>Du har följande användaruppgifter registrerade i " +
                    "bokningswebben https://quintagolfers.hardelin.nu:");
                email.Append("<br><br>");
                email.Append("Anändarnamn: " + Anvandare.Anvandarnamn + "<br/>");
                email.Append("Epostadress: " + Anvandare.Epostadress + "<br/>");
                email.Append("Lösenord: " + Anvandare.Losenord + "</p>");
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
        #endregion
    }
}
