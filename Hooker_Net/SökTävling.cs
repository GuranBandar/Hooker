using Hooker.Affärslager;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Data;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönster för Sök Tävling
    /// </summary>
    public partial class SökTävling : FormBas
    {
        #region "Medlemsvariabler"
        private bool _sokningGjord = false;
        #endregion

        #region Egenskaper
        /// <summary>
        /// DataSet för Tävling
        /// </summary>
        public DataSet TavlingDS { get; set; }

        private DateTime FromDatum { get; set; }

        private DateTime TomDatum { get; set; }
        #endregion

        /// <summary>
        /// Defaultkonstruktor
        /// </summary>
        public SökTävling()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initerar texter
        /// </summary>
        private void InitieraTexter()
        {
            this.Text = Översätt("Text", this.Text);

            foreach (System.Windows.Forms.Control cc in this.Controls)
            {
                if (cc.Controls.Count == 0)
                {
                    if (cc.Name.StartsWith("lbl") | cc.Name.StartsWith("gbx"))
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

            for (int i = 0; i < dgwSökTävling.Columns.Count; i++)
            {
                dgwSökTävling.Columns[i].HeaderText = Översätt("Text", dgwSökTävling.Columns[i].HeaderText);
            }

            knappkontroller1.btnKnapp0.Text = Översätt("Text", "Knapp_Rondresultat");
            knappkontroller1.btnKnapp0.Enabled = false;
            knappkontroller1.btnKnapp1.Text = Översätt("Text", "Knapp_Ny");
            knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_Öppna");
            knappkontroller1.btnKnapp2.Enabled = false;
            knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_Sök");
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");

            //Hämta spelarinfo från inloggningen
            //Anvandare anvandare = FormBas.GetAppUser();
        }

        /// <summary>
        /// Visar sökt urval i datagridden
        /// </summary>
        private void VisaResultat()
        {
            TavlingAktivitet tavlingAktivitet = new TavlingAktivitet();
            string spelsatt = "00";
            string speltyp = "00";
            string tavlingNamn = string.Empty;

            try
            {
                Timglas.WaitCurson();
                if (txtTavlingNamn.Text != string.Empty)
                {
                    tavlingNamn = txtTavlingNamn.Text;
                }

                if ((ComboBoxKod)cboSpelsatt.SelectedItem != null)
                {
                    spelsatt = ((ComboBoxKod)cboSpelsatt.SelectedItem).Kod;
                }

                if ((ComboBoxKod)cboSpeltyper.SelectedItem != null)
                {
                    speltyp = ((ComboBoxKod)cboSpeltyper.SelectedItem).Kod;
                }

                dgwSökTävling.Rows.Clear();
                _sokningGjord = true;
                knappkontroller1.btnKnapp0.Enabled = false;
                knappkontroller1.btnKnapp2.Enabled = false;
                TavlingDS = tavlingAktivitet.SökTavling(tavlingNamn, spelsatt, speltyp, FromDatum, TomDatum);

                if (TavlingDS.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= TavlingDS.Tables[0].Rows.Count - 1; i++)
                    {
                        dgwSökTävling.Rows.Add();
                        dgwSökTävling.Rows[i].Cells["TavlingID"].Value = TavlingDS.Tables["Tavling"].Rows[i]["TavlingID"].ToString();
                        dgwSökTävling.Rows[i].Cells["Datum"].Value = ("STD").Formatera((DateTime)TavlingDS.Tables["Tavling"].Rows[i]["StartDatum"]);
                        dgwSökTävling.Rows[i].Cells["Namn"].Value = TavlingDS.Tables["Tavling"].Rows[i]["TavlingNamn"].ToString();
                        dgwSökTävling.Rows[i].Cells["Notering"].Value = TavlingDS.Tables["Tavling"].Rows[i]["Notering"].ToString();
                        dgwSökTävling.Rows[i].Cells["Spelform"].Value = TavlingDS.Tables["Tavling"].Rows[i]["Spelform"].ToString();
                        dgwSökTävling.Rows[i].Cells["Status"].Value = TavlingDS.Tables["Tavling"].Rows[i]["Status"].ToString();
                    }
                    dgwSökTävling.Rows[0].Cells[0].DataGridView.Focus();
                    knappkontroller1.btnKnapp0.Enabled = true;
                    knappkontroller1.btnKnapp2.Enabled = true;
                }
                else
                {
                    VisaFelmeddelande("TVLPOSTERMISSING");
                }
                Timglas.DefaultCursor();
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        #region Händelsehanterare
        private void SökTävling_Load(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            this.InitieraTexter();
            this.MdiParent = MdiMain;
            FyllComboBoxKod(cboSpeltyper, Kodtabell.Speltyper, "00", true);
            FyllComboBoxKod(cboSpelsatt, Kodtabell.Spelsätt, "00", true);
            _sokningGjord = false;
            txtTavlingNamn.Focus();
            Timglas.DefaultCursor();
        }

        /// <summary>
        /// Hantera Rondresultat-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp0Click(object sender, EventArgs e)
        {
            fönsterhanterare1.HanteraVisaRondResultat(dgwSökTävling.CurrentRow.Cells["TavlingID"].Value.ToString(), FromDatum, TomDatum);
        }

        /// <summary>
        /// Hantera Ny-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp1Click(object sender, EventArgs e)
        {
            fönsterhanterare1.HanteraNyTavling();
        }

        /// <summary>
        /// Användaren har tryckt på knappen "Öppna", och förhoppningsvis också markerat en rad.
        /// </summary>
        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            fönsterhanterare1.HanteraVisaTavling(dgwSökTävling.CurrentRow.Cells["TavlingID"].Value.ToString());
        }

        /// <summary>
        /// Hantera Sök-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            this.VisaResultat();
        }

        /// <summary>
        /// Hantera Avbryt-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpFromDatum_ValueChanged(object sender, EventArgs e)
        {
            FromDatum = dtpFromDatum.Value;
        }

        private void dtpTomDatum_ValueChanged(object sender, EventArgs e)
        {
            TomDatum = dtpTomDatum.Value;
        }

        private void cboBana_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_sokningGjord)
            {
                this.VisaResultat();
            }
        }

        private void dgwSökTävling_DoubleClick(object sender, EventArgs e)
        {
            fönsterhanterare1.HanteraVisaTavling(dgwSökTävling.CurrentRow.Cells["TavlingID"].Value.ToString());
        }
        #endregion

        /// <summary>
        /// Aktiveras när fönstret visas. Har det visats förut, och sökning gjord, kör sökningen igen.
        /// Finns post i gridden som tagits bort försvinner den nu.
        /// </summary>
        private void SökTävling_Activated(object sender, EventArgs e)
        {
            if (_sokningGjord)
            {
                VisaResultat();
            }
        }
    }
}
