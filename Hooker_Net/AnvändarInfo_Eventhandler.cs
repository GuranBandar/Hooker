using Hooker.Affärslager;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Hooker_GUI
{
    public partial class AnvandareInfo : FormBas
    {
        #region "Händelsehanterare"

        private void AnvandareInfo_Load(object sender, EventArgs e)
        {
            InitieraTexter();
            this.MdiParent = MdiMain;
            FormEvent();
            txtAnvandarnamn.Focus();
        }

        /// <summary>
        /// Hantera Send mail knappen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void knappkontroller1_OnKnapp1Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Anvandare.Epostadress))
            {
                SendMail();
            }
        }

        /// <summary>
        /// Hantera Spara-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            AnvandareAktivitet anvandarAktivitet;
            int nyttAnvandarID;
            try
            {
                Timglas.WaitCurson();
                if (AllaFältOK())
                {
                    anvandarAktivitet = new AnvandareAktivitet();
                    nyttAnvandarID = anvandarAktivitet.Spara(Anvandare, NyAnvandare, ref FelID, ref Feltext);
                    VisaMeddelande("Information_OK");

                    //Nu visar vi Spelaren som den ser ut i databasen
                    if (NyAnvandare)
                    {
                        AnvandarID = nyttAnvandarID;
                        this.NyAnvandare = false;
                        knappkontroller1.btnKnapp3.Enabled = true;
                    }

                    VisaAnvandare();
                }
                else
                {
                    //Om fel returnerades ska objektet städas vid nyupplägg
                    if (NyAnvandare)
                    {
                        Anvandare = null;
                    }
                }
                Timglas.DefaultCursor();
            }
            catch (HookerException)
            {
                if (NyAnvandare)
                {
                    Anvandare = null;
                }
                VisaFelmeddelande(FelID, Feltext);
            }

        }

        /// <summary>
        /// Hantera Ta bort-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            string svar;
            AnvandareAktivitet anvandareAktivitet;

            try
            {
                svar = VisaFråga("Varning_TABORTANVÄNDARE");

                if (svar.Equals("Ja"))
                {
                    anvandareAktivitet = new AnvandareAktivitet();
                    anvandareAktivitet.TaBort(Anvandare, ref FelID, ref Feltext);
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
        /// Hantera Avbryt-knappen
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
        #endregion

        private void FormEvent()
        {
            foreach (var control in Controls.OfType<Control>())
            {
                control.Click += Anvandare_Changed;
                control.TextChanged += Anvandare_Changed;
            }
            foreach (var radioButton in gbxGIR.Controls.OfType<RadioButton>())
            {
                radioButton.CheckedChanged += Anvandare_Changed;
            }
        }

        private void Anvandare_Changed(object sender, EventArgs e)
        {
            FormsUppdaterad = true;
            knappkontroller1.btnKnapp2.Enabled = true;
            knappkontroller1.btnKnapp3.Enabled = true;
        }

        /// <summary>
        /// Nu har användaren ändrat lösenord, aktivera textboxen för Konfirmera lösenord
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLosenord_TextChanged(object sender, EventArgs e)
        {
            txtKonfirmera.Enabled = true;
            txtKonfirmera.PasswordChar = '\u25CF';

            if (!FormsLaddar)
            {
                NyLosen = true;
            }
        }
    }
}
