using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönsterklass för Rondnalysen
    /// </summary>
    public partial class Rondanalys : FormBas
    {
        private DataSet RondanalysDS { get; set; }
        private bool _sokningGjord = false;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public Rondanalys()
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
                lblAntal.Text = Översätt("Text", lblAntal.Text);
                txtScore.Text = Översätt("Text", txtScore.Text);
                txtPoang.Text = Översätt("Text", txtPoang.Text);
                txtResultat.Text = Översätt("Text", txtResultat.Text);

                //snurra igenom vilka kontroller som ska visas repektive döljas
                foreach (System.Windows.Forms.Control cc in statistikHuvudKontroll1.Controls)
                {
                    if (cc.Name.Equals("gbxSpelarinfo"))
                    {
                        for (int i = 0; i < cc.Controls.Count; i++)
                        {
                            switch (cc.Controls[i].Name)
                            {
                                case "lblBana":
                                    cc.Controls[i].Show();
                                    break;
                                case "cboBana":
                                    cc.Controls[i].Show();
                                    break;
                                case "lblTyp":
                                    cc.Controls[i].Hide();
                                    break;
                                case "ddnRedovisningstyper":
                                    cc.Controls[i].Hide();
                                    break;
                            }
                        }
                    }
                    else if (cc.Name.Equals("gbxRondTyp"))
                    {
                        cc.Show();
                    }
                    else if (cc.Name.Equals("gbxRedovisningsinfo"))
                    {
                        cc.Hide();
                    }
                }

                for (int i = 0; i < dgwRondanalys.Columns.Count; i++)
                {
                    if (string.IsNullOrEmpty(dgwRondanalys.Columns[i].HeaderText))
                    {
                        dgwRondanalys.Columns[i].HeaderText = "";
                    }
                    else
                    {
                        dgwRondanalys.Columns[i].HeaderText = Översätt("Text", dgwRondanalys.Columns[i].HeaderText);
                    }
                }

                knappkontroller1.btnKnapp0.Text = Översätt("Text", "Knapp_Formkurva");
                knappkontroller1.btnKnapp0.Enabled = false;
                knappkontroller1.btnKnapp1.Text = Översätt("Text", "Knapp_Rondgraf");
                knappkontroller1.btnKnapp1.Enabled = false;
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
        /// Visar resulatet för sökta rundor
        /// </summary>
        private void VisaResultat()
        {
            decimal snittSlagTot = 0;
            decimal snittSlagUt = 0;
            decimal snittSlagIn = 0;
            decimal snittPoangTot = 0;
            decimal snittPoangUt = 0;
            decimal snittPoangIn = 0;
            var rowIndex = 0;
            int rowNr;

            try
            {
                knappkontroller1.btnKnapp0.Enabled = false;
                knappkontroller1.btnKnapp1.Enabled = false;
                knappkontroller1.btnKnapp2.Enabled = false;
                //Antalet rundor
                txtAntal.Text = RondanalysDS.Tables["Rondanalys"].Rows.Count.ToString();
                dgwRondanalys.Rows.Clear();

                if (RondanalysDS.Tables["Rondanalys"].Rows.Count > 0)
                {
                    //Borja med att räkna ut alla snittresultat
                    for (int i = 0; i <= RondanalysDS.Tables["Rondanalys"].Rows.Count - 1; i++)
                    {
                        snittSlagTot += int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Slag"].ToString());
                        snittSlagUt += int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Slag Ut"].ToString());
                        snittSlagIn += int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Slag In"].ToString());
                        snittPoangTot += int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Poäng"].ToString());
                        snittPoangUt += int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Poäng Ut"].ToString());
                        snittPoangIn += int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Poäng In"].ToString());
                    }
                    dgwRondanalys.Rows.Add();
                    dgwRondanalys.Rows[0].Cells["RundaNr"].Value = "0";
                    dgwRondanalys.Rows[0].Cells["GolfklubbNr"].Value = "0";
                    dgwRondanalys.Rows[0].Cells["Bana"].Value = "Snitt";
                    dgwRondanalys.Rows[0].Cells["Bana"].Style.ForeColor = Color.Blue;
                    dgwRondanalys.Rows[0].Cells["SummaSlag"].Value =
                        ("ND1").Formatera(snittSlagTot / decimal.Parse(RondanalysDS.Tables["Rondanalys"].Rows.Count.ToString()));
                    dgwRondanalys.Rows[0].Cells["SummaSlag"].Style.ForeColor = Color.Blue;
                    dgwRondanalys.Rows[0].Cells["SummaSlag"].Style.Alignment =
                        System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                    dgwRondanalys.Rows[0].Cells["SlagUt"].Value =
                        ("ND1").Formatera(snittSlagUt / decimal.Parse(RondanalysDS.Tables["Rondanalys"].Rows.Count.ToString()));
                    dgwRondanalys.Rows[0].Cells["SlagUt"].Style.ForeColor = Color.Blue;
                    dgwRondanalys.Rows[0].Cells["SlagUt"].Style.Alignment =
                        System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                    dgwRondanalys.Rows[0].Cells["SlagIn"].Value =
                        ("ND1").Formatera(snittSlagIn / decimal.Parse(RondanalysDS.Tables["Rondanalys"].Rows.Count.ToString()));
                    dgwRondanalys.Rows[0].Cells["SlagIn"].Style.ForeColor = Color.Blue;
                    dgwRondanalys.Rows[0].Cells["SlagIn"].Style.Alignment =
                        System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                    dgwRondanalys.Rows[0].Cells["Separator1"].Style.BackColor = Color.LightGray;
                    dgwRondanalys.Rows[0].Cells["SummaPoang"].Value =
                        ("ND1").Formatera(snittPoangTot / decimal.Parse(RondanalysDS.Tables["Rondanalys"].Rows.Count.ToString()));
                    dgwRondanalys.Rows[0].Cells["SummaPoang"].Style.ForeColor = Color.Blue;
                    dgwRondanalys.Rows[0].Cells["SummaPoang"].Style.Alignment =
                        System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                    dgwRondanalys.Rows[0].Cells["PoangUt"].Value =
                        ("ND1").Formatera(snittPoangUt / decimal.Parse(RondanalysDS.Tables["Rondanalys"].Rows.Count.ToString()));
                    dgwRondanalys.Rows[0].Cells["PoangUt"].Style.ForeColor = Color.Blue;
                    dgwRondanalys.Rows[0].Cells["PoangUt"].Style.Alignment =
                        System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                    dgwRondanalys.Rows[0].Cells["PoangIn"].Value =
                        ("ND1").Formatera(snittPoangIn / decimal.Parse(RondanalysDS.Tables["Rondanalys"].Rows.Count.ToString()));
                    dgwRondanalys.Rows[0].Cells["PoangIn"].Style.ForeColor = Color.Blue;
                    dgwRondanalys.Rows[0].Cells["PoangIn"].Style.Alignment =
                        System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                    dgwRondanalys.Rows[0].Cells["Separator2"].Style.BackColor = Color.LightGray;
                    dgwRondanalys.Rows[0].Frozen = true;

                    for (int i = 0; i <= RondanalysDS.Tables["Rondanalys"].Rows.Count - 1; i++)
                    {
                        dgwRondanalys.Rows.Add();
                        dgwRondanalys.Rows[i + 1].Cells["RundaNr"].Value = RondanalysDS.Tables["Rondanalys"].Rows[i]["RundaNr"].ToString();
                        dgwRondanalys.Rows[i + 1].Cells["GolfklubbNr"].Value = RondanalysDS.Tables["Rondanalys"].Rows[i]["GolfklubbNr"].ToString();
                        dgwRondanalys.Rows[i + 1].Cells["Datum"].Value = ("STD").Formatera(DateTime.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Datum"].ToString()));
                        dgwRondanalys.Rows[i + 1].Cells["Bana"].Value = RondanalysDS.Tables["Rondanalys"].Rows[i]["Golfklubb"].ToString()
                            + ", " + RondanalysDS.Tables["Rondanalys"].Rows[i]["BanaNamn"].ToString();
                        dgwRondanalys.Rows[i + 1].Cells["SummaSlag"].Value = RondanalysDS.Tables["Rondanalys"].Rows[i]["Slag"].ToString();
                        dgwRondanalys.Rows[i + 1].Cells["SummaSlag"].Style.Alignment =
                            System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                        dgwRondanalys.Rows[i + 1].Cells["SlagUt"].Value = RondanalysDS.Tables["Rondanalys"].Rows[i]["Slag Ut"].ToString();
                        dgwRondanalys.Rows[i + 1].Cells["SlagUt"].Style.Alignment =
                            System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                        dgwRondanalys.Rows[i + 1].Cells["SlagIn"].Value = RondanalysDS.Tables["Rondanalys"].Rows[i]["Slag In"].ToString();
                        dgwRondanalys.Rows[i + 1].Cells["SlagIn"].Style.Alignment =
                            System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                        dgwRondanalys.Rows[i + 1].Cells["SummaPoang"].Value = RondanalysDS.Tables["Rondanalys"].Rows[i]["Poäng"].ToString();
                        dgwRondanalys.Rows[i + 1].Cells["SummaPoang"].Style.Alignment =
                            System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                        dgwRondanalys.Rows[i + 1].Cells["PoangUt"].Value = RondanalysDS.Tables["Rondanalys"].Rows[i]["Poäng Ut"].ToString();
                        dgwRondanalys.Rows[i + 1].Cells["PoangUt"].Style.Alignment =
                            System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                        dgwRondanalys.Rows[i + 1].Cells["PoangIn"].Value = RondanalysDS.Tables["Rondanalys"].Rows[i]["Poäng In"].ToString();
                        dgwRondanalys.Rows[i + 1].Cells["PoangIn"].Style.Alignment =
                            System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

                        dgwRondanalys.Rows[i + 1].Cells["Separator1"].Style.BackColor = Color.LightGray;

                        //Sätter lite färg på texten för att göra listan överskådligare
                        if (int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Poäng"].ToString()) < 33)
                        {
                            dgwRondanalys.Rows[i + 1].Cells["SummaPoang"].Style.ForeColor = Color.Blue;
                        }
                        else if (int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Poäng"].ToString()) > 36)
                        {
                            dgwRondanalys.Rows[i + 1].Cells["SummaPoang"].Style.ForeColor = Color.Red;
                        }
                        dgwRondanalys.Rows[i + 1].Cells["Separator2"].Style.BackColor = Color.LightGray;

                        dgwRondanalys.Rows[i + 1].Cells["ResEfter3"].Value =
                            6 - int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Res efter 3"].ToString());
                        dgwRondanalys.Rows[i + 1].Cells["ResEfter3"].Style.Alignment =
                            System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                        if (6 - int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Res efter 3"].ToString()) < 0)
                        {
                            dgwRondanalys.Rows[i + 1].Cells["ResEfter3"].Style.ForeColor = Color.Red;
                        }
                        else if (6 - int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Res efter 3"].ToString()) > 0)
                        {
                            dgwRondanalys.Rows[i + 1].Cells["ResEfter3"].Style.ForeColor = Color.Blue;
                        }

                        dgwRondanalys.Rows[i + 1].Cells["ResEfter6"].Value =
                             12 - int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Res efter 6"].ToString());
                        dgwRondanalys.Rows[i + 1].Cells["ResEfter6"].Style.Alignment =
                            System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                        if (12 - int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Res efter 6"].ToString()) < 0)
                        {
                            dgwRondanalys.Rows[i + 1].Cells["ResEfter6"].Style.ForeColor = Color.Red;
                        }
                        else if (12 - int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Res efter 6"].ToString()) > 0)
                        {
                            dgwRondanalys.Rows[i + 1].Cells["ResEfter6"].Style.ForeColor = Color.Blue;
                        }

                        dgwRondanalys.Rows[i + 1].Cells["ResEfter9"].Value =
                            18 - int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Res efter 9"].ToString());
                        dgwRondanalys.Rows[i + 1].Cells["ResEfter9"].Style.Alignment =
                            System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                        if (18 - int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Res efter 9"].ToString()) < 0)
                        {
                            dgwRondanalys.Rows[i + 1].Cells["ResEfter9"].Style.ForeColor = Color.Red;
                        }
                        else if (18 - int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Res efter 9"].ToString()) > 0)
                        {
                            dgwRondanalys.Rows[i + 1].Cells["ResEfter9"].Style.ForeColor = Color.Blue;
                        }

                        dgwRondanalys.Rows[i + 1].Cells["ResEfter12"].Value =
                            24 - int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Res efter 12"].ToString());
                        dgwRondanalys.Rows[i + 1].Cells["ResEfter12"].Style.Alignment =
                            System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                        if (24 - int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Res efter 12"].ToString()) < 0)
                        {
                            dgwRondanalys.Rows[i + 1].Cells["ResEfter12"].Style.ForeColor = Color.Red;
                        }
                        else if (24 - int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Res efter 12"].ToString()) > 0)
                        {
                            dgwRondanalys.Rows[i + 1].Cells["ResEfter12"].Style.ForeColor = Color.Blue;
                        }

                        dgwRondanalys.Rows[i + 1].Cells["ResEfter15"].Value =
                            30 - int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Res efter 15"].ToString());
                        dgwRondanalys.Rows[i + 1].Cells["ResEfter15"].Style.Alignment =
                            System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                        if (30 - int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Res efter 15"].ToString()) < 0)
                        {
                            dgwRondanalys.Rows[i + 1].Cells["ResEfter15"].Style.ForeColor = Color.Red;
                        }
                        else if (30 - int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Res efter 15"].ToString()) > 0)
                        {
                            dgwRondanalys.Rows[i + 1].Cells["ResEfter15"].Style.ForeColor = Color.Blue;
                        }

                        dgwRondanalys.Rows[i + 1].Cells["ResEfter18"].Value =
                            36 - int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Res efter 18"].ToString());
                        dgwRondanalys.Rows[i + 1].Cells["ResEfter18"].Style.Alignment =
                            System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                        if (36 - int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Res efter 18"].ToString()) < 0)
                        {
                            dgwRondanalys.Rows[i + 1].Cells["ResEfter18"].Style.ForeColor = Color.Red;
                        }
                        else if (36 - int.Parse(RondanalysDS.Tables["Rondanalys"].Rows[i]["Res efter 18"].ToString()) > 0)
                        {
                            dgwRondanalys.Rows[i + 1].Cells["ResEfter18"].Style.ForeColor = Color.Blue;
                        }

                        if (RondanalysDS.Tables["Rondanalys"].Rows[i]["Aktuell"].ToString().Equals("0"))
                        {
                            rowNr = rowIndex.FindMatchingRow(dgwRondanalys, RondanalysDS.Tables["Rondanalys"].Rows[i]["RundaNr"].ToString());
                            dgwRondanalys.Rows[rowNr].DefaultCellStyle.BackColor = Color.AntiqueWhite;
                        }
                    }
                    dgwRondanalys.Rows[1].Cells[0].DataGridView.Focus();
                    knappkontroller1.btnKnapp0.Enabled = true;
                    knappkontroller1.btnKnapp1.Enabled = true;
                    knappkontroller1.btnKnapp2.Enabled = true;
                }
                else
                {
                    VisaFelmeddelande("RNDSMISSING");
                }
            }
            catch (HookerException hex)
            {
                HanteraUndantag(hex);
            }
        }
        #endregion

        #region "Händelsehanterare"
        private void Rondanalys_Load(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            InitieraTexter();
            this.MdiParent = MdiMain;
            statistikHuvudKontroll1.Focus();
            FormsLaddar = false;
            Timglas.DefaultCursor();
        }

        private void knappkontroller1_OnKnapp0Click(object sender, EventArgs e)
        {
            if (RondanalysDS != null)
            {
                hanteraFönster1.HanteraVisaFormkurva(RondanalysDS);
            }
        }

        /// <summary>
        /// Hanterar Rondgraf-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp1Click(object sender, EventArgs e)
        {
            string rundaNr = "";
            try
            {
                if (dgwRondanalys.CurrentRow.Selected || dgwRondanalys.CurrentCell.Selected)
                {
                    if (dgwRondanalys.CurrentRow.Cells["RundaNr"].Value != null)
                    {
                        rundaNr = dgwRondanalys.CurrentRow.Cells["RundaNr"].Value.ToString();
                    }
                }

                //Om RundaNr = 0 är ingen runda markerad
                if (rundaNr == "0" || rundaNr == "")
                {
                    VisaFelmeddelande("INGENRADMARKERAD");
                }
                else
                {
                    hanteraFönster1.HanteraVisaRondgraf(rundaNr);
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hanterar Öppna-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            string rundaNr = "";
            try
            {
                if (dgwRondanalys.CurrentRow.Selected || dgwRondanalys.CurrentCell.Selected)
                {
                    if (dgwRondanalys.CurrentRow.Cells["RundaNr"].Value != null)
                    {
                        rundaNr = dgwRondanalys.CurrentRow.Cells["RundaNr"].Value.ToString();
                    }
                }

                //Om RundaNr = 0 är ingen runda markerad
                if (rundaNr == "0" || rundaNr == "")
                {
                    VisaFelmeddelande("INGENRADMARKERAD");
                }
                else
                {
                    hanteraFönster1.HanteraVisaRunda(rundaNr,
                        dgwRondanalys.CurrentRow.Cells["GolfklubbNr"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hanterar Sök-knappen
        /// 
        /// Användaren måste ha valt spelare för att statistiken ska visas.
        /// </summary>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            int spelarID;
            string golfklubbNr;
            string banaNr;
            DateTime fromDatum;
            DateTime tomDatum;
            bool hcprond = false;
            bool niohalsrond = false;
            bool sallskapsrond = false;
            bool tavlingsrond = false;
            Hooker.Affärslager.Statistik statistik;

            try
            {
                if (statistikHuvudKontroll1.SpelarID == 0)
                {
                    VisaFelmeddelande("SPELAREMISSING");
                }
                else
                {
                    Timglas.WaitCurson();
                    statistik = new Hooker.Affärslager.Statistik();
                    spelarID = statistikHuvudKontroll1.SpelarID;
                    _sokningGjord = true;

                    if (statistikHuvudKontroll1.GolfklubbNr.ToString().Equals("0"))
                    {
                        golfklubbNr = "";
                    }
                    else
                    {
                        golfklubbNr = statistikHuvudKontroll1.GolfklubbNr.ToString();
                    }

                    if (statistikHuvudKontroll1.BanaNr.ToString().Equals("0"))
                    {
                        banaNr = "";
                    }
                    else
                    {
                        banaNr = statistikHuvudKontroll1.BanaNr.ToString();
                    }

                    fromDatum = statistikHuvudKontroll1.FromDatum;
                    tomDatum = statistikHuvudKontroll1.TomDatum;

                    if (statistikHuvudKontroll1.HcpronderVald)
                    {
                        hcprond = true;
                    }
                    else if (statistikHuvudKontroll1.NiohalsronderVald)
                    {
                        niohalsrond = true;
                    }
                    else if (statistikHuvudKontroll1.SallskapsronderVald)
                    {
                        sallskapsrond = true;
                    }
                    else if (statistikHuvudKontroll1.TavlingsronderVald)
                    {
                        tavlingsrond = true;
                    }

                    RondanalysDS = statistik.Rondanalys(golfklubbNr, banaNr, spelarID.ToString(), fromDatum, tomDatum,
                        hcprond, niohalsrond, sallskapsrond, tavlingsrond);

                    VisaResultat();
                    Timglas.DefaultCursor();
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
        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Användaren har dubbelklickat på en rad, då ska Rundan visas 
        /// </summary>
        private void dgwRondanalys_DoubleClick(object sender, EventArgs e)
        {
            if (dgwRondanalys.CurrentRow.Cells["RundaNr"].Value != null &&
                (string)dgwRondanalys.CurrentRow.Cells["RundaNr"].Value != "0")
            {
                hanteraFönster1.HanteraVisaRunda(dgwRondanalys.CurrentRow.Cells["RundaNr"].Value.ToString(),
                    dgwRondanalys.CurrentRow.Cells["GolfklubbNr"].Value.ToString());
            }
        }

        /// <summary>
        /// Aktiveras när fönstret visas. Har det visats förut, och sökning gjord, kör sökningen igen.
        /// Finns runda i gridden som tagits bort försvinner den nu.
        /// </summary>
        private void Rondanalys_Enter(object sender, EventArgs e)
        {
            if (_sokningGjord)
            {
                VisaResultat();
            }
        }

        private void statistikHuvudKontroll1_OnCboSpelareSelect(object sender, EventArgs e)
        {
            if (!FormsLaddar)
            {
                this.knappkontroller1_OnKnapp3Click(sender, e);
            }
        }

        private void statistikHuvudKontroll1_OnDtpFromDatumChanged(object sender, EventArgs e)
        {
            //if (!FormsLaddar)
            //{
            //    this.knappkontroller1_OnKnapp3Click(sender, e);
            //}
        }

        private void statistikHuvudKontroll1_OnDtpTomDatumChanged(object sender, EventArgs e)
        {
            //if (!FormsLaddar)
            //{
            //    this.knappkontroller1_OnKnapp3Click(sender, e);
            //}
        }

        private void statistikHuvudKontroll1_OnCboHemmabanaSelect(object sender, EventArgs e)
        {
            if (!FormsLaddar)
            {
                this.knappkontroller1_OnKnapp3Click(sender, e);
            }
        }

        private void statistikHuvudKontroll1_OnCboGolfklubbSelect(object sender, EventArgs e)
        {
            if (!FormsLaddar)
            {
                if (statistikHuvudKontroll1.BanaNr != 0)
                    this.knappkontroller1_OnKnapp3Click(sender, e);
            }
        }

        /// <summary>
        /// Visar Rundanotering vid högerklick på rad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgwRondanalys_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            string rundaNr = "";
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        try
                        {
                            if (dgwRondanalys.CurrentRow.Selected || dgwRondanalys.CurrentCell.Selected)
                            {
                                if (dgwRondanalys.CurrentRow.Cells["RundaNr"].Value != null)
                                {
                                    rundaNr = dgwRondanalys.CurrentRow.Cells["RundaNr"].Value.ToString();
                                }
                            }

                            //Om RundaNr = 0 är ingen runda markerad
                            if (rundaNr == "0" || rundaNr == "")
                            {
                                VisaFelmeddelande("INGENRADMARKERAD");
                            }
                            else
                            {
                                hanteraFönster1.HanteraVisaRundaNotering(rundaNr);
                            }
                        }
                        catch (Exception ex)
                        {
                            HanteraUndantag(ex);
                        }
                    }
                    break;
            }
        }
        #endregion
    }
}
