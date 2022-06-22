using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker_GUI.Kontroller;
using System;
using System.Collections.Generic;

namespace Hooker_GUI
{
    /// <summary>
    ///     Fönsterklass för Sök Spelare
    /// </summary>
    public partial class SökSpelare : FormBas
    {
        /// <summary>
        ///     Konstruktor
        /// </summary>
        public SökSpelare()
        {
            InitializeComponent();
        }

        #region "Publika metoder"

        #endregion

        #region "Privata metoder"
        private void InitieraTexter()
        {
            this.Text = Översätt("Text", this.Text);
            lblNamn.Text = Översätt("Text", lblNamn.Text);
            lblGolfID.Text = Översätt("Text", lblGolfID.Text);

            for (int i = 0; i < dgwSokSpelare.Columns.Count; i++)
            {
                dgwSokSpelare.Columns[i].HeaderText = Översätt("Text", dgwSokSpelare.Columns[i].HeaderText);
            }

            knappkontroller1.btnKnapp0.Visible = false;
            knappkontroller1.btnKnapp1.Text = Översätt("Text", "Knapp_Ny");
            knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_Öppna");
            knappkontroller1.btnKnapp2.Enabled = false;
            knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_Sök");
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
        }

        /// <summary>
        /// Visar sökresultatet
        /// </summary>
        private void VisaResultat()
        {
            SpelareAktivitet spelareAktivitet = new SpelareAktivitet();
            string golfID = "";

            try
            {
                Timglas.WaitCurson();
                if (txtGolfID.Text.Length > 0)
                {
                    golfID = txtGolfID.Text + txtLopnr.Text;
                }
                dgwSokSpelare.Rows.Clear();
                knappkontroller1.btnKnapp2.Enabled = false;
                List<Spelare> spelare = spelareAktivitet.SökSpelare(txtNamn.Text.ToString().Trim(), golfID);

                if (spelare != null)
                {
                    for (int i = 0; i <= spelare.Count - 1; i++)
                    {
                        dgwSokSpelare.Rows.Add();
                        dgwSokSpelare.Rows[i].Cells["SpelarID"].Value = spelare[i].AktuelltSpelarID;
                        dgwSokSpelare.Rows[i].Cells["Namn"].Value = spelare[i].Namn;
                        if (spelare[i].AktuelltSpelarID != 0 && spelare[i].GolfID != string.Empty)
                        {
                            dgwSokSpelare.Rows[i].Cells["GolfID"].Value =
                                spelare[i].GolfID.Substring(0, 6) + "-" +
                                spelare[i].GolfID.Substring(6, 3);
                        }
                        dgwSokSpelare.Rows[i].Cells["Hcp"].Value = spelare[i].ExaktHcp.ToString();
                        dgwSokSpelare.Rows[i].Cells["Golfklubb"].Value = spelare[i].Golfklubbnamn;
                        dgwSokSpelare.Rows[i].Cells["Hemmabana"].Value = spelare[i].Hemmabana;
                    }
                    dgwSokSpelare.Rows[0].Cells[0].DataGridView.Focus();
                    knappkontroller1.btnKnapp2.Enabled = true;
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
        private void SökSpelare_Load(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            InitieraTexter();
            this.MdiParent = MdiMain;
            txtNamn.Focus();
            Timglas.DefaultCursor();
        }

        ///// <summary>
        ///// Hanterar Ny-knappen
        ///// </summary>
        //private void knappkontroller1_OnKnapp1Click(object sender, EventArgs e)
        //{
        //    hanteraFönster1.HanteraNySpelare();
        //}

        ///// <summary>
        ///// Hanterar Öppna-knappen
        ///// </summary>
        //private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        //{
        //    hanteraFönster1.HanteraVisaSpelare(dgwSokSpelare.CurrentRow.Cells["SpelarID"].Value.ToString());
        //}

        ///// <summary>
        ///// Hanterar Sök-Knappen
        ///// </summary>
        //private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        //{
        //    VisaResultat();
        //}

        ///// <summary>
        ///// Hanterar Avbryt-Knappen
        ///// </summary>
        //private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        /// <summary>
        /// Användaren har dubbelklickat på en rad, då ska Spelaren visas 
        /// </summary>
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            hanteraFönster1.HanteraVisaSpelare(dgwSokSpelare.CurrentRow.Cells["SpelarID"].Value.ToString());
        }
        #endregion

        private void Knappkontroller1_OnKnapp0Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Hanterar Öppna-knappen
        /// </summary>
        private void Knappkontroller1_OnKnapp1Click_1(object sender, EventArgs e)
        {
            hanteraFönster1.HanteraNySpelare();
        }

        /// <summary>
        /// Hanterar Öppna-knappen
        /// </summary>
        private void Knappkontroller1_OnKnapp2Click_1(object sender, EventArgs e)
        {
            hanteraFönster1.HanteraVisaSpelare(dgwSokSpelare.CurrentRow.Cells["SpelarID"].Value.ToString());
        }

        /// <summary>
        /// Hanterar Sök-Knappen
        /// </summary>
        private void Knappkontroller1_OnKnapp3Click_1(object sender, EventArgs e)
        {
            VisaResultat();
        }

        /// <summary>
        /// Hanterar Avbryt-Knappen
        /// </summary>
        private void Knappkontroller1_OnKnapp4Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
