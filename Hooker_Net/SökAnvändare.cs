using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker_GUI.Kontroller;
using System;
using System.Collections.Generic;

namespace Hooker_GUI
{
    public partial class SökAnvändare : FormBas
    {
        /// <summary>
        /// Objekt för Användare
        /// </summary>
        public Anvandare Anvandare { get; set; }

        public SökAnvändare()
        {
            InitializeComponent();
        }

        #region "Publika metoder"

        #endregion

        #region "Privata metoder"
        /// <summary>
        /// Fixa till alla texterna
        /// </summary>
        private void InitieraTexter()
        {
            this.Text = Översätt("Text", this.Text);
            lblAnvandarnamn.Text = Översätt("Text", lblAnvandarnamn.Text);
            lblAnvandarnamn.Text = Översätt("Text", lblSpelare.Text);
            lblAnvandargrupp.Text = Översätt("Text", lblAnvandargrupp.Text);

            for (int i = 0; i < dgwSokAnvandare.Columns.Count; i++)
            {
                dgwSokAnvandare.Columns[i].HeaderText = Översätt("Text", dgwSokAnvandare.Columns[i].HeaderText);
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
            AnvandareAktivitet anvandareAktivitet = new AnvandareAktivitet();
            string anvandarGrupp = cboAnvandargrupp.SelectedItem == null ?
                string.Empty : cboAnvandargrupp.SelectedItem.ToString();

            try
            {
                Timglas.WaitCurson();
                dgwSokAnvandare.Rows.Clear();
                knappkontroller1.btnKnapp2.Enabled = false;
                List<Anvandare> Anvandare = anvandareAktivitet.
                    SökAnvandare(txtAnvandarnamn.Text.ToString().Trim(), anvandarGrupp);

                if (Anvandare.Count > 0)
                {
                    for (int i = 0; i <= Anvandare.Count - 1; i++)
                    {
                        anvandarGrupp = cboAnvandargrupp.GetItemText(Anvandare[i].Anvandargrupp);
                        dgwSokAnvandare.Rows.Add();
                        dgwSokAnvandare.Rows[i].Cells["AnvandarID"].Value = Anvandare[i].AnvandarID;
                        dgwSokAnvandare.Rows[i].Cells["Anvandarnamn"].Value = Anvandare[i].Anvandarnamn;
                        dgwSokAnvandare.Rows[i].Cells["Spelare"].Value = Anvandare[i].SpelarID;
                        dgwSokAnvandare.Rows[i].Cells["Epostadress"].Value = Anvandare[i].Epostadress;
                        //dgwSokAnvandare.Rows[i].Cells["Anvandargrupp"].Value = anvandargrupp.;
                    }
                    dgwSokAnvandare.Rows[0].Cells[0].DataGridView.Focus();
                    knappkontroller1.btnKnapp2.Enabled = true;
                }
                else
                {
                    VisaFelmeddelande("ANVANDAREMISSING");
                }
                Timglas.DefaultCursor();
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }
        #endregion
    }
}
