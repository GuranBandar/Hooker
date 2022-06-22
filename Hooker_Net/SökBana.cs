using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Collections.Generic;

namespace Hooker_GUI
{
    /// <summary>
    ///     Fönsterklass för hantering av SökBana
    /// </summary>
    public partial class SökBana : FormBas
    {
        private bool _sökningGjord = false;

        private string TypAvSökning { get; set; }

        /// <summary>
        ///     Konstruktor
        /// </summary>
        public SökBana(string typAvSökning)
        {
            TypAvSökning = typAvSökning;
            InitializeComponent();
        }

        /// <summary>
        ///     Initierar alla texter på kontrollerna
        /// </summary>
        private void InitieraTexter()
        {
            this.Text = Översätt("Text", this.Text);
            gbxBana.Text = Översätt("Text", gbxBana.Text);
            lblNamn.Text = Översätt("Text", lblNamn.Text);
            lblLand.Text = Översätt("Text", lblLand.Text);
            lblOrt.Text = Översätt("Text", lblOrt.Text);
            lblDistrikt.Text = Översätt("Text", lblDistrikt.Text);
            lblAntal.Text = Översätt("Text", lblAntal.Text);

            for (int i = 0; i < dgwSökBana.Columns.Count; i++)
            {
                dgwSökBana.Columns[i].HeaderText = Översätt("Text", dgwSökBana.Columns[i].HeaderText);
            }

            knappkontroller1.btnKnapp0.Visible = false;
            knappkontroller1.btnKnapp1.Text = Översätt("Text", "Knapp_Ny");
            knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_Öppna");
            knappkontroller1.btnKnapp2.Enabled = false;
            knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_Sök");
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
        }

        /// <summary>
        /// Hämta aktuella distriktkoder och fyll combon.
        /// </summary>
        private void FyllDistriktCombo(string landkod)
        {
            List<Koder> koder;
            Hooker.Affärslager.KoderAktivitet koderAktivitet = new Hooker.Affärslager.KoderAktivitet();

            try
            {
                //Typ = 1 är Distriktkoder
                koder = koderAktivitet.SökKoder((int)Kodtabell.Distrikt, landkod);

                if (koder != null)
                {
                    cboDistrikt.Items.Clear();
                    cboDistrikt.Items.Add(new ComboBoxKod("00", "", ""));
                    foreach (Koder kodrad in koder)
                    {
                        cboDistrikt.Items.Add(new ComboBoxKod(kodrad.Argument, kodrad.Varde.ToString(),
                            kodrad));
                    }
                    cboDistrikt.DisplayMember = "visa";
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        ///     Visar sökt urval i datagridden
        /// </summary>
        private void VisaResultat()
        {
            List<Bana> bana = null;
            Hooker.Affärslager.BanaAktivitet banaAktivitet = new Hooker.Affärslager.BanaAktivitet();
            string landkod = "";
            string distriktkod = "";

            try
            {
                if ((ComboBoxKod)cboLand.SelectedItem != null)
                {
                    landkod = ((ComboBoxKod)cboLand.SelectedItem).Kod.ToString();
                }

                if ((ComboBoxKod)cboDistrikt.SelectedItem != null)
                {
                    distriktkod = ((ComboBoxKod)cboDistrikt.SelectedItem).Kod.ToString();
                }

                dgwSökBana.Rows.Clear();
                knappkontroller1.btnKnapp2.Enabled = false;
                Timglas.WaitCurson();
                bana = banaAktivitet.SökBana(txtNamn.Text.ToString().Trim(),
                    txtOrt.Text.ToString().Trim(), landkod, distriktkod);

                if (bana != null)
                {
                    txtAntal.Text = bana.Count.ToString();
                    for (int i = 0; i <= bana.Count - 1; i++)
                    {
                        dgwSökBana.Rows.Add();
                        dgwSökBana.Rows[i].Cells["BanaNr"].Value = bana[i].BanaNr;
                        dgwSökBana.Rows[i].Cells["GolfklubbNr"].Value = bana[i].GolfklubbNr;
                        dgwSökBana.Rows[i].Cells["Golfklubb"].Value = Functions.ToStr(bana[i].GolfklubbNamn);
                        dgwSökBana.Rows[i].Cells["Namn"].Value = bana[i].BanaNamn;
                        if (bana[i].Aktuell == "1")
                        {
                            dgwSökBana.Rows[i].Cells["Aktuell"].Value = true;
                        }
                        else
                        {
                            dgwSökBana.Rows[i].Cells["Aktuell"].Value = false;
                        }
                        dgwSökBana.Rows[i].Cells["Notering"].Value = Functions.ToStr(bana[i].Notering);
                        dgwSökBana.Rows[i].Cells["Distrikt"].Value = Functions.ToStr(bana[i].Distrikt);
                        dgwSökBana.Rows[i].Cells["Land"].Value = Functions.ToStr(bana[i].Land);
                    }
                    dgwSökBana.Rows[0].Cells[0].DataGridView.Focus();
                    knappkontroller1.btnKnapp2.Enabled = true;
                }
                else
                {
                    VisaFelmeddelande("BANAMISSING");
                }
                Timglas.DefaultCursor();
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        #region "Händelsehanterare"
        /// <summary>
        ///     Hanterar Ny-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp1Click(object sender, EventArgs e)
        {
            fönsterhanterare1.HanteraNyBana();
        }

        /// <summary>
        /// Användaren har tryckt på knappen "Öppna", och förhoppningsvis också markerat en rad.
        /// </summary>
        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            string banaNr = string.Empty;
            string golfklubbNr = string.Empty;
            Timglas.WaitCurson();

            try
            {
                if (dgwSökBana.CurrentRow.Selected || dgwSökBana.CurrentCell.Selected)
                {
                    if (dgwSökBana.CurrentRow.Cells["BanaNr"].Value != null &&
                        dgwSökBana.CurrentRow.Cells["BanaNr"].Value.ToString() != "0")
                    {
                        banaNr = dgwSökBana.CurrentRow.Cells["BanaNr"].Value.ToString();
                    }
                    if (dgwSökBana.CurrentRow.Cells["GolfklubbNr"].Value != null)
                    {
                        golfklubbNr = dgwSökBana.CurrentRow.Cells["GolfklubbNr"].Value.ToString();
                    }
                }

                if (TypAvSökning.Equals("Bana") && banaNr != string.Empty)
                {
                    fönsterhanterare1.HanteraVisaBana(banaNr);
                }
                else if (TypAvSökning.Equals("Bana") && golfklubbNr != string.Empty)
                {
                    fönsterhanterare1.HanteraVisaGolfklubb(golfklubbNr);
                }
                else if (TypAvSökning.Equals("Klubb") && golfklubbNr != string.Empty)
                {
                    fönsterhanterare1.HanteraVisaGolfklubb(golfklubbNr);
                }
                else
                {
                    VisaFelmeddelande("INGENRADMARKERAD");
                }
                Timglas.DefaultCursor();
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        ///     Hanterar Sök-Knappen
        /// </summary>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            _sökningGjord = true;
            VisaResultat();
        }

        /// <summary>
        ///     Hanterar Avbryt-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            _sökningGjord = false;
            this.Close();
        }

        /// <summary>
        /// Användaren har fipplat i combon för land, visa då landets distrikt
        /// </summary>
        private void cboLand_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgwSökBana.Rows.Clear();
            FyllDistriktCombo(((ComboBoxKod)cboLand.SelectedItem).Kod.ToString());
        }

        /// <summary>
        ///     Användaren har dubbelklickat på en rad, då ska Banan visas 
        /// </summary>
        private void dgwSökBana_DoubleClick(object sender, EventArgs e)
        {
            if (dgwSökBana.CurrentRow.Cells["BanaNr"].Value != null)
            {
                fönsterhanterare1.HanteraVisaBana(dgwSökBana.CurrentRow.Cells["BanaNr"].Value.ToString());
            }
        }

        private void SökBana_Load(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            FyllComboBoxKod(cboLand, Kodtabell.Land, "00", true);
            InitieraTexter();
            this.MdiParent = MdiMain;
            txtNamn.Focus();
            Timglas.DefaultCursor();
        }

        /// <summary>
        /// Visa resultat igen om sökning är gjord tidigare, kan vara så att bana är borttagen.
        /// Då behöver ny lista skapas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SökBana_Activated(object sender, EventArgs e)
        {
            if (_sökningGjord)
            {
                VisaResultat();
            }
        }
        #endregion
    }
}
