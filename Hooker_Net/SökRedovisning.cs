using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Collections.Generic;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönster för Sök Redovisning
    /// </summary>
    public partial class SökRedovisning : FormBas
    {
        #region "Medlemsvariabler"
        private int _spelarID;
        private string _redovisningstyp;
        List<Redovisning> _redovisning;
        private bool _sokningGjord = false;
        #endregion

        #region Egenskaper
        /// <summary>
        /// SpelarID
        /// </summary>
        public int SpelarID
        {
            get
            {
                return _spelarID;
            }
            set
            {
                _spelarID = value;
            }
        }

        /// <summary>
        /// Objekt för Redovisning
        /// </summary>
        public List<Redovisning> Redovisning
        {
            get
            {
                return _redovisning;
            }
            set
            {
                _redovisning = value;
            }
        }

        /// <summary>
        /// Redovisningstyp
        /// </summary>
        private string Redovisningstyp
        {
            get
            {
                return _redovisningstyp;
            }
            set
            {
                _redovisningstyp = value;
            }
        }

        private DateTime FromDatum { get; set; }

        private DateTime TomDatum { get; set; }
        #endregion

        /// <summary>
        /// Defaultkonstruktor
        /// </summary>
        public SökRedovisning()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initerar texter
        /// </summary>
        private void InitieraTexter()
        {
            this.Text = Översätt("Text", this.Text);
            gbxRedovisningstyper.Text = FormBas.Översätt("Text", gbxRedovisningstyper.Text);
            lblTyp.Text = FormBas.Översätt("Text", lblTyp.Text);
            lblFromDatum.Text = FormBas.Översätt("Text", lblFromDatum.Text);
            lblSpelare.Text = FormBas.Översätt("Text", lblSpelare.Text);
            lblTomDatum.Text = FormBas.Översätt("Text", lblTomDatum.Text);

            //Datum från årets början
            int dagnr = DateTime.Today.DayOfYear;
            dtpFromDatum.Text = DateTime.Today.AddDays(1 - dagnr).ToShortDateString();
            int year = DateTime.Today.Year;
            if (DateTime.IsLeapYear(year))
            {
                dtpTomDatum.Text = DateTime.Today.AddDays(366 - dagnr).ToShortDateString();
            }
            else
            {
                dtpTomDatum.Text = DateTime.Today.AddDays(365 - dagnr).ToShortDateString();
            }

            for (int i = 0; i < dgwSökRedovisning.Columns.Count; i++)
            {
                dgwSökRedovisning.Columns[i].HeaderText = Översätt("Text", dgwSökRedovisning.Columns[i].HeaderText);
            }

            knappkontroller1.btnKnapp0.Visible = false;
            knappkontroller1.btnKnapp1.Text = Översätt("Text", "Knapp_Ny");
            knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_Öppna");
            knappkontroller1.btnKnapp2.Enabled = false;
            knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_Sök");
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");

            //Hämta spelarinfo från inloggningen
            Anvandare anvandare = FormBas.GetAppUser();
            SpelarID = anvandare.SpelarID;
        }

        /// <summary>
        /// Hämta alla Spelare och fyll droppisen.
        /// </summary>
        private void FyllSpelareDropDown()
        {
            Hooker.Affärslager.SpelareAktivitet spelareAktivitet = new Hooker.Affärslager.SpelareAktivitet();

            try
            {
                List<Spelare> spelare = spelareAktivitet.SökSpelare("", "");

                if (spelare.Count > 0)
                {
                    ddnSpelare.Items.Clear();
                    ddnSpelare.Items.Add(new ComboBoxPar(0, "Alla spelare", ""));
                    for (int i = 0; i < spelare.Count; i++)
                    {
                        ddnSpelare.Items.Add(new ComboBoxPar(spelare[i].AktuelltSpelarID,
                            spelare[i].Namn, spelare[i]));
                    }

                    ddnSpelare.SelectedItem = SpelarID;
                    ddnSpelare.DisplayMember = "visa";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Visar sökt urval i datagridden
        /// </summary>
        private void VisaResultat()
        {
            RedovisningAktivitet redovisningAktivitet = new RedovisningAktivitet();

            try
            {
                Timglas.WaitCurson();
                if ((ComboBoxKod)ddnRedovisningstyper.SelectedItem != null)
                {
                    Redovisningstyp = ((ComboBoxKod)ddnRedovisningstyper.SelectedItem).Kod.ToString();
                }

                dgwSökRedovisning.Rows.Clear();
                _sokningGjord = true;
                knappkontroller1.btnKnapp2.Enabled = false;
                Redovisning = redovisningAktivitet.SökRedovisning(Redovisningstyp, SpelarID.ToString(),
                    FromDatum, TomDatum);

                if (Redovisning != null)
                {
                    for (int i = 0; i <= Redovisning.Count - 1; i++)
                    {
                        dgwSökRedovisning.Rows.Add();
                        dgwSökRedovisning.Rows[i].Cells[0].Value = Redovisning[i].TransNr.ToString();
                        dgwSökRedovisning.Rows[i].Cells[1].Value = Redovisning[i].RundaNr.ToString();
                        dgwSökRedovisning.Rows[i].Cells[2].Value = Redovisning[i].Typnamn.ToString();
                        dgwSökRedovisning.Rows[i].Cells[3].Value = ("STD").Formatera(Redovisning[i].Datum);
                        dgwSökRedovisning.Rows[i].Cells[4].Value = ("").Formatera(Redovisning[i].Belopp);
                        dgwSökRedovisning.Rows[i].Cells[5].Value = Redovisning[i].Notering.ToString();
                    }
                    dgwSökRedovisning.Rows[0].Cells[0].DataGridView.Focus();
                    knappkontroller1.btnKnapp2.Enabled = true;
                }
                else
                {
                    VisaFelmeddelande("REDPOSTERMISSING");
                }
                Timglas.DefaultCursor();
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        #region Händelsehanterare
        private void SökRedovisning_Load(object sender, EventArgs e)
        {
            this.InitieraTexter();
            this.MdiParent = MdiMain;
            this.FyllSpelareDropDown();
            FyllComboBoxKod(ddnRedovisningstyper, Kodtabell.Redovisningstyper, "00", true);
            this.VisaResultat();
            ddnRedovisningstyper.Focus();

        }

        private void SökRedovisning_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Hantera Ny-knappen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void knappkontroller1_OnKnapp1Click(object sender, EventArgs e)
        {
            fönsterhanterare1.HanteraNyRedovisning();
        }

        /// <summary>
        /// Användaren har tryckt på knappen "Öppna", och förhoppningsvis också markerat en rad.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            string transNr = null;
            string rundaNr = null;

            try
            {
                if (dgwSökRedovisning.CurrentRow.Selected || dgwSökRedovisning.CurrentCell.Selected)
                {
                    if (!dgwSökRedovisning.CurrentRow.Cells["RundaNr"].Value.Equals("0"))
                    {
                        rundaNr = dgwSökRedovisning.CurrentRow.Cells["RundaNr"].Value.ToString();
                    }
                    else if (dgwSökRedovisning.CurrentRow.Cells["TransNr"].Value != null)
                    {
                        transNr = dgwSökRedovisning.CurrentRow.Cells["TransNr"].Value.ToString();
                    }
                }

                //Om RundaNr = 0 är ingen runda markerad
                if (!string.IsNullOrEmpty(transNr))
                {
                    fönsterhanterare1.HanteraVisaRedovisning(transNr);
                }
                else if (!string.IsNullOrEmpty(rundaNr))
                {
                    fönsterhanterare1.HanteraVisaRunda(rundaNr);
                }
                else
                {
                    VisaFelmeddelande("INGENRADMARKERAD");
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hantera Sök-knappen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            this.VisaResultat();
        }

        /// <summary>
        /// Hantera Avbryt-knappen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ddnRedovisningstyper_SelectedIndexChanged(object sender, EventArgs e)
        {
            Redovisningstyp = ((ComboBoxKod)ddnRedovisningstyper.SelectedItem).Kod;
            VisaResultat();
        }

        private void ddnSpelare_SelectedIndexChanged(object sender, EventArgs e)
        {
            SpelarID = ((ComboBoxPar)ddnSpelare.SelectedItem).Identifier;
        }

        private void dtpFromDatum_ValueChanged(object sender, EventArgs e)
        {
            FromDatum = dtpFromDatum.Value;
        }

        private void dtpTomDatum_ValueChanged(object sender, EventArgs e)
        {
            TomDatum = dtpTomDatum.Value;
        }

        private void dgwSökRedovisning_DoubleClick(object sender, EventArgs e)
        {
            if (!dgwSökRedovisning.CurrentRow.Cells["RundaNr"].Value.Equals("0"))
            {
                fönsterhanterare1.HanteraVisaRunda(dgwSökRedovisning.CurrentRow.Cells["RundaNr"].Value.ToString());
            }
            else if (dgwSökRedovisning.CurrentRow.Cells["TransNr"].Value != null)
            {
                fönsterhanterare1.HanteraVisaRedovisning(dgwSökRedovisning.CurrentRow.Cells["TransNr"].Value.ToString());
            }
        }

        /// <summary>
        /// Aktiveras när fönstret visas. Har det visats förut, och sökning gjord, kör sökningen igen.
        /// Finns post i gridden som tagits bort försvinner den nu.
        /// </summary>
        private void SökRedovisning_Activated(object sender, EventArgs e)
        {
            if (_sokningGjord)
            {
                VisaResultat();
            }
        }
        #endregion
    }
}
