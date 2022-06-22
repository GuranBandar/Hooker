using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönsterklass för Sök Runda
    /// </summary>
    public partial class SökRunda : FormBas
    {
        private bool _sokningGjord = false;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public SökRunda()
        {
            InitializeComponent();
        }

        #region "Privata metoder"
        /// <summary>
        /// Initierar alla texter på kontrollerna
        /// </summary>
        private void InitieraTexter()
        {
            this.Text = Översätt("Text", this.Text);
            statistikHuvudKontroll1.InitieraSidhuvud();
            lblAntal.Text = Översätt("Text", lblAntal.Text);

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

            for (int i = 0; i < dgwSökRunda.Columns.Count; i++)
            {
                dgwSökRunda.Columns[i].HeaderText = Översätt("Text", dgwSökRunda.Columns[i].HeaderText);
            }

            knappkontroller1.btnKnapp0.Visible = false;
            knappkontroller1.btnKnapp1.Text = Översätt("Text", "Knapp_Ny");
            knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_Öppna");
            knappkontroller1.btnKnapp2.Enabled = false;
            knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_Sök");
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
        }

        ///// <summary>
        ///// Hitta matchande RundNr för aktuell rad
        ///// </summary>
        ///// <param name="dgv"></param>
        ///// <param name="searchValue"></param>
        ///// <returns></returns>
        //private static int FindMatchingRow(DataGridView dgv, string searchValue)
        //{
        //    int rowIndex = -1;

        //    DataGridViewRow row = dgv.Rows.Cast<DataGridViewRow>()
        //        .Where(r => r.Cells["RundaNr"].Value.ToString().Equals(searchValue))
        //        .First();

        //    rowIndex = row.Index;
        //    return rowIndex;
        //}

        /// <summary>
        ///     Visar sökresultatet
        /// </summary>
        private void VisaResultat()
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
            var rowIndex = 0;
            int rowNr;
            List<Runda> runda = null;
            RundaAktivitet rundaAktivitet = new RundaAktivitet();

            try
            {
                Timglas.WaitCurson();
                if (statistikHuvudKontroll1.SpelarID == 0)
                {
                    VisaFelmeddelande("SPELAREMISSING");
                }
                else
                {
                    spelarID = statistikHuvudKontroll1.SpelarID;
                    golfklubbNr = statistikHuvudKontroll1.GolfklubbNr.ToString();
                    banaNr = statistikHuvudKontroll1.BanaNr.ToString();
                    _sokningGjord = true;
                    if (banaNr.Equals("0"))
                    {
                        banaNr = "";
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

                    dgwSökRunda.Rows.Clear();
                    _sokningGjord = true;
                    knappkontroller1.btnKnapp2.Enabled = false;

                    if (string.IsNullOrEmpty(banaNr))
                    {
                        runda = rundaAktivitet.SökRundaGolfklubb(spelarID.ToString(),
                            golfklubbNr, fromDatum, tomDatum,
                            tavlingsrond, sallskapsrond, hcprond, niohalsrond);
                    }
                    else
                    {
                        runda = rundaAktivitet.SökRunda(spelarID.ToString(), banaNr,
                                fromDatum, tomDatum, tavlingsrond, sallskapsrond, hcprond,
                                niohalsrond);
                    }
                }
                if (runda != null)
                {
                    txtAntal.Text = runda.Count.ToString();
                    for (int i = 0; i <= runda.Count - 1; i++)
                    {
                        dgwSökRunda.Rows.Add();
                        dgwSökRunda.Rows[i].Cells["RundaNr"].Value = runda[i].RundaNr;
                        dgwSökRunda.Rows[i].Cells["Datum"].Value = ("STD").Formatera(runda[i].Datum);
                        dgwSökRunda.Rows[i].Cells["Spelare"].Value = runda[i].SpelareNamn;
                        dgwSökRunda.Rows[i].Cells["Bana"].Value = runda[i].BanaNamn;
                        dgwSökRunda.Rows[i].Cells["Poäng"].Value = runda[i].SummaAntalPoang.ToString();
                        dgwSökRunda.Rows[i].Cells["Poäng"].Style.Alignment =
                            System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                        dgwSökRunda.Rows[i].Cells["Slag"].Value = runda[i].SummaAntalSlag.ToString();
                        dgwSökRunda.Rows[i].Cells["Slag"].Style.Alignment =
                            System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                        dgwSökRunda.Rows[i].Cells["Notering"].Value = runda[i].Notering;

                        //Sätter lite färg på texten för att göra listan överskådligare
                        if (int.Parse(runda[i].SummaAntalPoang.ToString()) < 33)
                        {
                            dgwSökRunda.Rows[i].Cells["Poäng"].Style.ForeColor = Color.Blue;
                        }
                        else if (int.Parse(runda[i].SummaAntalPoang.ToString()) > 36)
                        {
                            dgwSökRunda.Rows[i].Cells["Poäng"].Style.ForeColor = Color.Red;
                        }

                        if (runda[i].Aktuell.Equals("0"))
                        {
                            rowNr = rowIndex.FindMatchingRow(dgwSökRunda, runda[i].RundaNr.ToString());
                            dgwSökRunda.Rows[rowNr].DefaultCellStyle.BackColor = Color.AntiqueWhite;
                        }
                    }
                    dgwSökRunda.Rows[0].Cells[0].DataGridView.Focus();
                    knappkontroller1.btnKnapp2.Enabled = true;
                }
                else
                {
                    VisaFelmeddelande("RNDSMISSING");
                }
                Timglas.DefaultCursor();
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }
        #endregion

        #region "Händelsehanterare"
        private void SökRunda_Load(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            InitieraTexter();
            this.MdiParent = MdiMain;
            statistikHuvudKontroll1.Focus();
            FormsLaddar = false;
            Timglas.DefaultCursor();
        }

        /// <summary>
        /// Hanterar Ny-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp1Click(object sender, EventArgs e)
        {
            hanteraFönster1.HanteraNyRunda();
        }

        /// <summary>
        /// Användaren har tryckt på knappen "Öppna", och förhoppningsvis också markerat en rad.
        /// </summary>
        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            string rundaNr = "";
            string golfklubbNr = statistikHuvudKontroll1.GolfklubbNr.ToString();
            try
            {
                if (dgwSökRunda.CurrentRow.Selected || dgwSökRunda.CurrentCell.Selected)
                {
                    if (dgwSökRunda.CurrentRow.Cells["RundaNr"].Value != null)
                    {
                        rundaNr = dgwSökRunda.CurrentRow.Cells["RundaNr"].Value.ToString();
                    }
                }

                //Om RundaNr = 0 är ingen runda markerad
                if (rundaNr == "")
                {
                    VisaFelmeddelande("INGENRADMARKERAD");
                }
                else
                {
                    hanteraFönster1.HanteraVisaRunda(rundaNr, golfklubbNr);
                    //dgwSökRunda.CurrentRow.Cells["GolfklubbNr"].Value.ToString());
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
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            VisaResultat();
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
        private void dgwSökRunda_DoubleClick(object sender, EventArgs e)
        {
            if (dgwSökRunda.CurrentRow.Cells["RundaNr"].Value != null)
            {
                hanteraFönster1.HanteraVisaRunda(dgwSökRunda.CurrentRow.Cells["RundaNr"].Value.ToString(),
                    dgwSökRunda.CurrentRow.Cells["GolfklubbNr"].Value.ToString());
            }
        }

        /// <summary>
        /// Aktiveras när fönstret visas. Har det visats förut, och sökning gjord, kör sökningen igen.
        /// Finns runda i gridden som tagits bort försvinner den nu.
        /// </summary>
        private void SökRunda_Activated(object sender, EventArgs e)
        {
            if (_sokningGjord)
            {
                VisaResultat();
            }
        }
        #endregion
    }
}
