using System;
using System.Data;
using System.Drawing;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönsterklass för Ekonomianalysen
    /// </summary>
    public partial class EkonomiAnalys : FormBas
    {
        private DataSet _ekonomiAnalysDS = new DataSet();

        /// <summary>
        /// Defaultkonstruktor
        /// </summary>
        public EkonomiAnalys()
        {
            FormsLaddar = true;
            InitializeComponent();
        }
        
        #region "Privata metoder"
        /// <summary>
        /// Initierar alla texter på kontrollerna
        /// </summary>
        private void InitieraTexter()
        {
            try
            {
                this.Text = Översätt("Text", this.Text);
                statistikHuvudKontroll1.InitieraSidhuvud();

                //snurra igenom vilka kontroller som ska visas repektive döljas
                foreach (System.Windows.Forms.Control cc in statistikHuvudKontroll1.Controls)
                {
                    if (cc.Name.Equals("gbxSpelarinfo"))
                    {
                        for (int i = 0; i < cc.Controls.Count; i++)
                        {
                            switch (cc.Controls[i].Name)
                            {
                                case "lblGolfklubb":
                                    cc.Controls[i].Hide();
                                    break;
                                case "cboGolfklubb":
                                    cc.Controls[i].Hide();
                                    break;
                                case "cboHemmabana":
                                    cc.Controls[i].Hide();
                                    break;
                                case "lblTyp":
                                    cc.Controls[i].Show();
                                    break;
                                case "ddnRedovisningstyper":
                                    cc.Controls[i].Show();
                                    break;
                            }
                        }
                    }
                    else if (cc.Name.Equals("gbxRondTyp"))
                    {
                        cc.Hide();
                    }
                    else if (cc.Name.Equals("gbxRedovisningsinfo"))
                    {
                        cc.Show();
                    }
                }

                for (int i = 0; i < dgwEkonomiAnalys.Columns.Count; i++)
                {
                    dgwEkonomiAnalys.Columns[i].HeaderText = Översätt("Text", dgwEkonomiAnalys.Columns[i].HeaderText);
                }

                knappkontroller1.btnKnapp0.Visible = false;
                knappkontroller1.btnKnapp1.Visible = false;
                knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_Öppna");
                knappkontroller1.btnKnapp2.Enabled = false;
                knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_Sök");
                knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Visar sökt urval i datagridden
        /// </summary>
        private void VisaResultat()
        {
            decimal beloppTotal = 0;
            decimal beloppSumma = 0;
            string redovisningsTyp = null;
            int radnr = 0;
            dgwEkonomiAnalys.Rows.Clear();

            //Summera först totalt belopp
            foreach (DataRow rad in _ekonomiAnalysDS.Tables["Ekonomianalys"].Rows)
            {
                beloppSumma += (decimal)rad["Belopp"];
            }
            if (beloppSumma != 0)
            {
                //dags att skriva totalbeloppsraden
                dgwEkonomiAnalys.Rows.Add();
                dgwEkonomiAnalys.Rows[radnr].Cells["TransNr"].Value = null;
                dgwEkonomiAnalys.Rows[radnr].Cells["RundaNr"].Value = "0";
                dgwEkonomiAnalys.Rows[radnr].Cells["Typ"].Value = "Summa";
                dgwEkonomiAnalys.Rows[radnr].Cells["Typ"].Style.ForeColor = Color.Red;
                dgwEkonomiAnalys.Rows[radnr].Cells["Belopp"].Value = ("NT").Formatera(beloppSumma);
                dgwEkonomiAnalys.Rows[radnr].Cells["Belopp"].Style.ForeColor = Color.Red;
                dgwEkonomiAnalys.Rows[radnr].Cells["Notering"].Value = "Totalt belopp för sökt urval";
                dgwEkonomiAnalys.Rows[radnr].Cells["Notering"].Style.ForeColor = Color.Red;
                radnr++;
            }

            if (statistikHuvudKontroll1.DetaljeradRedovisningVald)
            {
                redovisningsTyp = _ekonomiAnalysDS.Tables["Ekonomianalys"].Rows[0]["Typnamn"].ToString();

                for (int i = 0; i <= _ekonomiAnalysDS.Tables["Ekonomianalys"].Rows.Count - 1; i++)
                {
                    if (redovisningsTyp.Equals(_ekonomiAnalysDS.Tables["Ekonomianalys"].Rows[i]["Typnamn"].ToString()))
                    {
                        beloppTotal += (decimal)_ekonomiAnalysDS.Tables["Ekonomianalys"].Rows[i]["Belopp"];
                    }
                    else
                    {
                        //dags att skriva totalbeloppsraden
                        dgwEkonomiAnalys.Rows.Add();
                        dgwEkonomiAnalys.Rows[radnr].Cells["TransNr"].Value = null;
                        dgwEkonomiAnalys.Rows[radnr].Cells["RundaNr"].Value = "0";
                        dgwEkonomiAnalys.Rows[radnr].Cells["Typ"].Value = redovisningsTyp;
                        dgwEkonomiAnalys.Rows[radnr].Cells["Typ"].Style.ForeColor = Color.Blue;
                        dgwEkonomiAnalys.Rows[radnr].Cells["Belopp"].Value = ("NT").Formatera(beloppTotal);
                        dgwEkonomiAnalys.Rows[radnr].Cells["Belopp"].Style.ForeColor = Color.Blue;
                        dgwEkonomiAnalys.Rows[radnr].Cells["Notering"].Value = "Totalt belopp per redovisningstyp";
                        dgwEkonomiAnalys.Rows[radnr].Cells["Notering"].Style.ForeColor = Color.Blue;
                        redovisningsTyp = _ekonomiAnalysDS.Tables["Ekonomianalys"].Rows[i]["Typnamn"].ToString();
                        beloppTotal = (decimal)_ekonomiAnalysDS.Tables["Ekonomianalys"].Rows[i]["Belopp"];
                        radnr++;
                    }

                    dgwEkonomiAnalys.Rows.Add();
                    dgwEkonomiAnalys.Rows[radnr].Cells["TransNr"].Value = _ekonomiAnalysDS.Tables["Ekonomianalys"].Rows[i]["TransNr"].ToString();
                    dgwEkonomiAnalys.Rows[radnr].Cells["RundaNr"].Value = _ekonomiAnalysDS.Tables["Ekonomianalys"].Rows[i]["RundaNr"].ToString();
                    dgwEkonomiAnalys.Rows[radnr].Cells["Typ"].Value = _ekonomiAnalysDS.Tables["Ekonomianalys"].Rows[i]["Typnamn"].ToString();
                    dgwEkonomiAnalys.Rows[radnr].Cells["Datum"].Value = ("STD").Formatera((DateTime)_ekonomiAnalysDS.Tables["Ekonomianalys"].Rows[i]["Datum"]);
                    dgwEkonomiAnalys.Rows[radnr].Cells["Belopp"].Value = ("NT").Formatera((decimal)_ekonomiAnalysDS.Tables["Ekonomianalys"].Rows[i]["Belopp"]);
                    dgwEkonomiAnalys.Rows[radnr].Cells["Spelare"].Value = _ekonomiAnalysDS.Tables["Ekonomianalys"].Rows[i]["Namn"];
                    dgwEkonomiAnalys.Rows[radnr].Cells["Notering"].Value = _ekonomiAnalysDS.Tables["Ekonomianalys"].Rows[i]["Notering"];
                    radnr++;
                }
                //dags att skriva den sista totalbeloppsraden
                dgwEkonomiAnalys.Rows.Add();
                dgwEkonomiAnalys.Rows[radnr].Cells["TransNr"].Value = null;
                dgwEkonomiAnalys.Rows[radnr].Cells["RundaNr"].Value = "0";
                dgwEkonomiAnalys.Rows[radnr].Cells["Typ"].Value = redovisningsTyp;
                dgwEkonomiAnalys.Rows[radnr].Cells["Typ"].Style.ForeColor = Color.Blue;
                dgwEkonomiAnalys.Rows[radnr].Cells["Belopp"].Value = ("NT").Formatera(beloppTotal);
                dgwEkonomiAnalys.Rows[radnr].Cells["Belopp"].Style.ForeColor = Color.Blue;
                dgwEkonomiAnalys.Rows[radnr].Cells["Notering"].Value = "Totalt belopp per redovisningstyp";
                dgwEkonomiAnalys.Rows[radnr].Cells["Notering"].Style.ForeColor = Color.Blue;
                knappkontroller1.btnKnapp2.Enabled = true;
            }
            else
            {
                for (int i = 0; i <= _ekonomiAnalysDS.Tables["Ekonomianalys"].Rows.Count - 1; i++)
                {
                    dgwEkonomiAnalys.Rows.Add();
                    dgwEkonomiAnalys.Rows[radnr].Cells["Typ"].Value = _ekonomiAnalysDS.Tables["Ekonomianalys"].Rows[i]["Typnamn"].ToString();
                    dgwEkonomiAnalys.Rows[radnr].Cells["Belopp"].Value = ("NT").Formatera((decimal)_ekonomiAnalysDS.Tables["Ekonomianalys"].Rows[i]["Belopp"]);
                    dgwEkonomiAnalys.Rows[radnr].Cells["Spelare"].Value = _ekonomiAnalysDS.Tables["Ekonomianalys"].Rows[i]["Namn"];
                    dgwEkonomiAnalys.Rows[radnr].Cells["Notering"].Value = "Summa per redovisningstyp och spelare";
                    radnr++;
                }
                knappkontroller1.btnKnapp2.Enabled = false;
            }
            dgwEkonomiAnalys.Rows[0].Cells[0].DataGridView.Focus();
        }
        #endregion

        private void EkonomiAnalys_Load(object sender, EventArgs e)
        {
            this.InitieraTexter();
            this.MdiParent = MdiMain;
            statistikHuvudKontroll1.Focus();
            FormsLaddar = false;
        }

        private void knappkontroller1_OnKnapp1Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Hanterar Öppna-knappen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            string transNr = null;
            string rundaNr = null;

            try
            {
                if (dgwEkonomiAnalys.CurrentRow.Selected || dgwEkonomiAnalys.CurrentCell.Selected)
                {
                    if (!dgwEkonomiAnalys.CurrentRow.Cells["RundaNr"].Value.Equals("0"))
                    {
                        rundaNr = dgwEkonomiAnalys.CurrentRow.Cells["RundaNr"].Value.ToString();
                    }
                    else if (dgwEkonomiAnalys.CurrentRow.Cells["TransNr"].Value != null)
                    {
                        transNr = dgwEkonomiAnalys.CurrentRow.Cells["TransNr"].Value.ToString();
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
        /// Hanterar Sök-knappen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            Hooker.Affärslager.Statistik statistik;

            try
            {
                statistik = new Hooker.Affärslager.Statistik();

                _ekonomiAnalysDS = statistik.Ekonomianalys(statistikHuvudKontroll1.Redovisningstyp,
                    statistikHuvudKontroll1.SpelarID.ToString(), statistikHuvudKontroll1.FromDatum,
                    statistikHuvudKontroll1.TomDatum, statistikHuvudKontroll1.DetaljeradRedovisningVald,
                    statistikHuvudKontroll1.SummeradRedovisningVald);

                if (_ekonomiAnalysDS.Tables["Ekonomianalys"].Rows.Count > 0)
                {
                    VisaResultat();
                }
                else
                {
                    dgwEkonomiAnalys.Rows.Clear();
                    VisaFelmeddelande("REDPOSTERMISSING");
                }
            }
            catch (HookerException hex)
            {
                HanteraUndantag(hex);
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hanterar Avbryt-knappen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgwEkonomiAnalys_DoubleClick(object sender, EventArgs e)
        {
            if (statistikHuvudKontroll1.DetaljeradRedovisningVald)
            {
                if (!dgwEkonomiAnalys.CurrentRow.Cells["RundaNr"].Value.Equals("0"))
                {
                    fönsterhanterare1.HanteraVisaRunda(dgwEkonomiAnalys.CurrentRow.Cells["RundaNr"].Value.ToString());
                }
                else if (dgwEkonomiAnalys.CurrentRow.Cells["TransNr"].Value != null)
                {
                    fönsterhanterare1.HanteraVisaRedovisning(dgwEkonomiAnalys.CurrentRow.Cells["TransNr"].Value.ToString());
                }
                else
                {
                    VisaFelmeddelande("REDPOSTERMISSING");
                }
            }
            else
            {
                VisaFelmeddelande("REDPOSTERMISSING");
            }
        }

        private void statistikHuvudKontroll1_OnCboSpelareSelect(object sender, EventArgs e)
        {
            this.knappkontroller1_OnKnapp3Click(sender, e);
        }

        private void statistikHuvudKontroll1_OnDdnRedovisningsSelect(object sender, EventArgs e)
        {
            if (!FormsLaddar)
            {
                this.knappkontroller1_OnKnapp3Click(sender, e);
            }
        }

        private void statistikHuvudKontroll1_OnDtpFromDatumChanged(object sender, EventArgs e)
        {
            if (!FormsLaddar)
            {
                this.knappkontroller1_OnKnapp3Click(sender, e);
            }
        }

        private void statistikHuvudKontroll1_OnDtpTomDatumChanged(object sender, EventArgs e)
        {
            if (!FormsLaddar)
            {
                this.knappkontroller1_OnKnapp3Click(sender, e);
            }
        }
    }
}
