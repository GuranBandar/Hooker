using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Hooker_GUI
{
    public partial class KoderInfo : FormBas
    {
        #region Händelsehanterare
        private void Koder_Load(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            InitieraTexter();
            this.MdiParent = MdiMain;
            FormEvent();
            FormsUppdaterad = false;

            if (NyKodArgument)
            {
                txtArgument.Focus();
            }
            else if (NyKodtyp)
            {
                txtVarde.Focus();
            }
            else
            {
                txtVarde.Focus();
            }
            Timglas.DefaultCursor();
        }

        private void FormEvent()
        {
            foreach (var control in Controls.OfType<Control>())
            {
                control.Click += Koder_Changed;
                control.TextChanged += Koder_Changed;
            }
            foreach (var control in gbxKoder.Controls.OfType<Control>())
            {
                control.TextChanged += Koder_Changed;
            }
        }

        private void Koder_Changed(object sender, EventArgs e)
        {
            FormsUppdaterad = true;
            knappkontroller1.btnKnapp1.Enabled = true;
            knappkontroller1.btnKnapp2.Enabled = true;
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
        ///     Hantera Spara-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            Hooker.Affärslager.KoderAktivitet koderAktivitet;

            try
            {
                Timglas.WaitCurson();
                if (AllaFältOK())
                {
                    koderAktivitet = new Hooker.Affärslager.KoderAktivitet();

                    if (NyKodArgument | NyKodtyp)
                    {
                        koderAktivitet.Spara(koder, true, ref FelID, ref Feltext);
                    }
                    else
                    {
                        koderAktivitet.Spara(koder, false, ref FelID, ref Feltext);
                    }

                    VisaMeddelande("Information_OK");

                    //Nu visar vi Koden som den ser ut i databasen
                    if (NyKodArgument | NyKodtyp)
                    {
                        Argument = koder.Argument.ToString();
                        this.NyKodtyp = false;
                        this.NyKodArgument = false;
                        knappkontroller1.btnKnapp3.Enabled = true;
                    }

                    VisaKoder();
                }
                else
                {
                    knappkontroller1.btnKnapp1.Enabled = false;
                    knappkontroller1.btnKnapp2.Enabled = false;
                }
                Timglas.DefaultCursor();
            }
            catch (HookerException)
            {
                knappkontroller1.btnKnapp1.Enabled = false;
                knappkontroller1.btnKnapp2.Enabled = false;
                VisaFelmeddelande(FelID, Feltext);
            }
        }

        /// <summary>
        ///     Hanterar Ta bort-Knappen
        /// </summary>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            string svar;
            Hooker.Affärslager.KoderAktivitet koderAktivitet;

            try
            {
                svar = VisaFråga("Varning_TABORTKOD");

                if (svar.Equals("Ja"))
                {
                    koderAktivitet = new Hooker.Affärslager.KoderAktivitet();
                    koderAktivitet.TaBort(koder, ref FelID, ref Feltext);
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
        ///     Hanterar Avbryt-Knappen
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
    }
}
