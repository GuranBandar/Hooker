using Hooker.Affärslager;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Hooker_GUI
{
    public partial class RedovisningInfo : FormBas
    {
        #region "Händelsehanterare"
        private void RedovisningInfo_Load(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            this.InitieraTexter();
            this.MdiParent = MdiMain;
            FormEvent();
            FormsUppdaterad = false;
            cboRedovisningtyper.Focus();
            Timglas.DefaultCursor();
        }

        private void FormEvent()
        {
            foreach (var control in Controls.OfType<Control>())
            {
                control.Click += Redovisning_Changed;
                control.TextChanged += Redovisning_Changed;
            }
            foreach (var control in gbxRedovisning.Controls.OfType<Control>())
            {
                control.TextChanged += Redovisning_Changed;
            }
        }

        /// <summary>
        /// Om värden är ändrat, aktivera Spara-knappen
        /// </summary>
        private void Redovisning_Changed(object sender, EventArgs e)
        {
            FormsUppdaterad = true;
            knappkontroller1.btnKnapp2.Enabled = true;
            knappkontroller1.btnKnapp3.Enabled = true;
        }

        /// <summary>
        /// Hantera Spara och stäng-knappen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            RedovisningAktivitet redovisningAktivitet;
            int nyttTransNr;

            try
            {
                Timglas.WaitCurson();
                if (AllaFältOK())
                {
                    redovisningAktivitet = new RedovisningAktivitet();
                    nyttTransNr = redovisningAktivitet.Spara(Redovisning, NyRedovisning, ref FelID, ref Feltext);
                    VisaMeddelande("Information_OK");

                    //Nu visar vi Redovisning som den ser ut i databasen
                    if (NyRedovisning)
                    {
                        this.NyRedovisning = false;
                        this.TransNr = nyttTransNr;
                        knappkontroller1.btnKnapp1.Enabled = true;
                        knappkontroller1.btnKnapp3.Enabled = true;
                    }

                    VisaRedovisning();
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
            RedovisningAktivitet redovisningAktivitet;

            try
            {
                svar = VisaFråga("Varning_TABORTREDOVISNING");

                if (svar.Equals("Ja"))
                {
                    redovisningAktivitet = new RedovisningAktivitet();
                    redovisningAktivitet.TaBort(Redovisning, ref FelID, ref Feltext);
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
