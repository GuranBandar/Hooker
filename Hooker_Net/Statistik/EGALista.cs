using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Hooker_GUI
{
    public partial class EGALista : FormBas
    {
        private DataSet EGAListaDS { get; set; }
        private List<Spelare> spelarLista { get; set; }
        private Spelare Spelare { get; set; }
        private int SpelarID { get; set; }

        public EGALista()
        {
            Timglas.WaitCurson();
            FormsLaddar = true;
            InitializeComponent();
            Timglas.DefaultCursor();
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
                lblSpelarNamn.Text = Översätt("Text", lblSpelarNamn.Text);
                lblExaktHcp.Text = Översätt("Text", lblExaktHcp.Text);
                lblPrognosEGA.Text = Översätt("Text", lblPrognosEGA.Text);

                for (int i = 0; i < dgwEGALista.Columns.Count; i++)
                {
                    if (string.IsNullOrEmpty(dgwEGALista.Columns[i].HeaderText))
                    {
                        dgwEGALista.Columns[i].HeaderText = "";
                    }
                    else
                    {
                        dgwEGALista.Columns[i].HeaderText = Översätt("Text", dgwEGALista.Columns[i].HeaderText);
                    }
                }
                knappkontroller1.btnKnapp0.Visible = false;
                knappkontroller1.btnKnapp1.Enabled = false;
                knappkontroller1.btnKnapp2.Enabled = false;
                knappkontroller1.btnKnapp3.Enabled = false;
                knappkontroller1.btnKnapp1.Text = Översätt("Text", "Knapp_VisaIgen");
                knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_Öppna");
                knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_Kör");
                knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }
        #endregion

        #region "Händelsehanterare"
        private void EGALista_Load(object sender, EventArgs e)
        {
            Timglas.WaitCurson();

            InitieraTexter();
            this.MdiParent = MdiMain;
            FormsLaddar = false;
            FyllSpelareCombo();
            //SpelarID = AppUser.SpelarID;
            VisaLista();
            cboSpelare.Focus();
            Timglas.DefaultCursor();
        }

        /// <summary>
        /// Hämta de senaste 20 rundorna och lista dem
        /// </summary>
        private void VisaLista()
        {
            EGAListaDS = new DataSet();
            Statistik statistik = new Statistik();
            EGAListaDS = statistik.EGALista(SpelarID.ToString());
            dgwEGALista.Rows.Clear();
            int rowNr = 0;
            int i = 0;
            decimal hcpres = 0;

            txtExaktHcp.Text = Spelare.ExaktHcp.ToString();
            //EGAPrognos eGAPrognos = new EGAPrognos();
            //eGAPrognos.SpelarID = Spelare.AktuelltSpelarID;
            //txtPrognosEGA.Text = ("ND1").Formatera(eGAPrognos.UtförHcpPrognos());

            List<DataRow> egaListRows = EGAListaDS.Tables["EGALista"].Rows.Cast<DataRow>().
                Take(25).ToList();

            //Formeln för Hcpresultat = (113 / Slopevärde) * (Par + Spelhcp - 
            // (Poäng - 36) - CR - 0)

            if (egaListRows.Count > 0)
            //if (EGAListaDS.Tables["EGALista"].Rows.Count > 0)
            {
                foreach (DataRow row in egaListRows)
                {
                    if ((Convert.ToDecimal(row["Slope Herrar"]) == 0 ||
                        (Convert.ToDecimal(row["CR Herrar"]) == 0 ||
                        (Convert.ToDecimal(row["Slope Damer"]) == 0 ||
                        (Convert.ToDecimal(row["CR Damer"]) == 0)))))
                    {
                        hcpres = 0;
                    }
                    else
                    {
                        if (Spelare.Kön.Equals("M"))
                        {
                            hcpres = (113 / Convert.ToDecimal(row["Slope Herrar"])) *
                                (Convert.ToInt32(row["Par"]) + Convert.ToInt32(row["Spelhcp"]) -
                                (Convert.ToInt32(row["Poäng"]) - 36) -
                                Convert.ToDecimal(row["CR Herrar"]) - 0);
                        }
                        else
                        {
                            hcpres = (113 / Convert.ToDecimal(row["Slope Damer"])) *
                                (Convert.ToInt32(row["Par"]) + Convert.ToInt32(row["Spelhcp"]) -
                                (Convert.ToInt32(row["Poäng"]) - 36) -
                                Convert.ToDecimal(row["CR Damer"]) - 0);
                        }
                    }
                    dgwEGALista.Rows.Add();
                    rowNr++;
                    if (rowNr > 20)
                    {
                        dgwEGALista.Rows[i].DefaultCellStyle.BackColor = Color.Azure;
                    }
                    dgwEGALista.Rows[i].Cells["RundaNr"].Value = row["RundaNr"];
                    dgwEGALista.Rows[i].Cells["Nr"].Value = rowNr;
                    dgwEGALista.Rows[i].Cells["Datum"].Value =
                        ("STD").Formatera(DateTime.Parse(row["Datum"].ToString()));
                    dgwEGALista.Rows[i].Cells["Bana"].Value = row["Bana"].ToString();
                    dgwEGALista.Rows[i].Cells["Slope"].Value =
                        ("ND1").Formatera(decimal.Parse(row["Slope Herrar"].ToString()));
                    dgwEGALista.Rows[i].Cells["CR"].Value =
                        ("ND1").Formatera(decimal.Parse(row["CR Herrar"].ToString()));
                    dgwEGALista.Rows[i].Cells["Hcprond"].Value =
                        (row["Hcp"].ToString() == "X" ? "Ja" : "Nej");
                    dgwEGALista.Rows[i].Cells["Par"].Value =
                        ("N").Formatera(int.Parse(row["Par"].ToString()));
                    dgwEGALista.Rows[i].Cells["Spelhcp"].Value =
                        ("N").Formatera(int.Parse(row["Spelhcp"].ToString()));
                    dgwEGALista.Rows[i].Cells["Poang"].Value =
                        ("N").Formatera(int.Parse(row["Poäng"].ToString()));
                    dgwEGALista.Rows[i].Cells["Hcpres"].Value = ("ND1").Formatera(hcpres);
                    i++;
                }
                knappkontroller1.btnKnapp2.Enabled = true;
                knappkontroller1.btnKnapp3.Enabled = true;
            }
        }
        #endregion

        private void knappkontroller1_OnKnapp0Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Visa listan igen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void knappkontroller1_OnKnapp1Click(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            this.VisaLista();
            Timglas.DefaultCursor();
        }

        /// <summary>
        /// Hantera Öppna-knappen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            string rundaNr = "";
            try
            {
                if (dgwEGALista.CurrentRow.Selected || dgwEGALista.CurrentCell.Selected)
                {
                    if (dgwEGALista.CurrentRow.Cells["RundaNr"].Value != null)
                    {
                        rundaNr = dgwEGALista.CurrentRow.Cells["RundaNr"].Value.ToString();
                    }
                }

                //Om RundaNr = 0 är ingen runda markerad
                if (rundaNr == "0" || rundaNr == "")
                {
                    VisaFelmeddelande("INGENRADMARKERAD");
                }
                else
                {
                    hanteraFönster1.HanteraVisaRunda(rundaNr);
                    knappkontroller1.btnKnapp1.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hanterar Kör-knappen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            EGAPrognos eGAPrognos = new EGAPrognos();
            decimal hcpResultat = 0;
            int rowNr;
            var rowIndex = 0;
            DataTable topEight = eGAPrognos.TopDataRow(EGAListaDS.Tables["EGALista"]);
            for (int i = 0; i < 8; i++)
            {
                rowNr = rowIndex.FindMatchingRow(dgwEGALista, topEight.Rows[i]["RundaNr"].ToString());
                dgwEGALista.Rows[rowNr].DefaultCellStyle.BackColor = Color.PaleTurquoise;
                hcpResultat += decimal.Parse(dgwEGALista.Rows[rowNr].Cells["Hcpres"].Value.ToString());
            }
            txtPrognosEGA.Text = ("ND1").Formatera(hcpResultat / 8);
        }

        /// <summary>
        /// Hanterar Avbryt-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Hämta alla Spelare och fyll combon.
        /// </summary>
        private void FyllSpelareCombo()
        {
            SpelareAktivitet spelareAktivitet = new SpelareAktivitet();

            try
            {
                spelarLista = spelareAktivitet.SökSpelareAnvandare();

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

                    cboSpelare.SelectedItem = AppUser.SpelarID;
                    cboSpelare.DisplayMember = "visa";
                    SpelarID = AppUser.SpelarID;
                    txtExaktHcp.Text = Spelare.ExaktHcp.ToString();
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Användaren har markerat en rad och tryckt höger musknapp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgwEGALista_MouseDown(object sender, MouseEventArgs e)
        {
            string rundaNr = "";
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        try
                        {
                            if (dgwEGALista.CurrentRow.Selected || dgwEGALista.CurrentCell.Selected)
                            {
                                if (dgwEGALista.CurrentRow.Cells["RundaNr"].Value != null)
                                {
                                    rundaNr = dgwEGALista.CurrentRow.Cells["RundaNr"].Value.ToString();
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

        private void cboSpelare_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormsUppdaterad = true;
            knappkontroller1.btnKnapp2.Enabled = true;
            if (cboSpelare.Items.Count > 0)
            {
                SpelarID = ((ComboBoxPar)cboSpelare.SelectedItem).Identifier;
                Spelare = spelarLista.Where(s => s.AktuelltSpelarID == SpelarID).
                    FirstOrDefault();
            }
        }
    }
}
