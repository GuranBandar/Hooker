using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönsterklass för hantering av Golfklubb
    /// </summary>
    public partial class GolfklubbInfo : FormBas
    {
        #region Egenskapeer
        /// <summary>
        /// GolfklubbNr
        /// </summary>
        public int GolfklubbNr { get; set; }

        /// <summary>
        /// Objekt för Golfklubb
        /// </summary>
        public Golfklubb Golfklubb { get; set; }

        /// <summary>
        /// Ny Golfklubb
        /// </summary>
        public bool NyGolfklubb { get; set; }
        #endregion

        public GolfklubbInfo()
        {
            FormsUppdaterad = false;
            FormsLaddar = true;
            InitializeComponent();
            KeyPreview = true;
        }

        #region "Publika metoder"
        /// <summary>
        /// Ny Golfklubb initieras
        /// </summary>
        public void InitieraNyGolfklubb()
        {
            try
            {
                NyGolfklubb = true;
                FyllComboBoxKod(cboLand, Kodtabell.Land, "01");
                knappkontroller1.btnKnapp0.Enabled = false;
                knappkontroller1.btnKnapp1.Enabled = false;
                knappkontroller1.btnKnapp2.Enabled = false;
                knappkontroller1.btnKnapp3.Enabled = false;
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hämta info i databasen och presentera
        /// </summary>
        public void VisaGolfklubb()
        {
            GolfklubbAktivitet golfklubbAktivitet = new GolfklubbAktivitet();
            try
            {
                Golfklubb = golfklubbAktivitet.HämtaGolfklubb(GolfklubbNr);

                if (Golfklubb != null)
                {
                    FyllBild();
                    FyllComboBoxKod(cboLand, Kodtabell.Land, Golfklubb.Landkod);
                    FyllComboBoxKod(cboDistrikt, Kodtabell.Distrikt, Golfklubb.Distriktkod);
                    knappkontroller1.btnKnapp0.Enabled = true;
                    knappkontroller1.btnKnapp2.Enabled = false;
                    knappkontroller1.btnKnapp3.Enabled = true;
                    FormsLaddar = false;
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }
        #endregion

        #region "Privata metoder"
        /// <summary>
        /// Alla texter hämtas och knapparna initieras
        /// </summary>
        private void InitieraTexter()
        {
            this.Text = Översätt("Text", this.Text);

            lblBanaNamn.Text = Översätt("Text", lblBanaNamn.Text);
            lblLand.Text = Översätt("Text", lblLand.Text);
            lblDistrikt.Text = Översätt("Text", lblDistrikt.Text);
            lblAdress.Text = Översätt("Text", lblAdress.Text);
            lblBokningen.Text = Översätt("Text", lblBokningen.Text);
            lblEpost.Text = Översätt("Text", lblEpost.Text);
            lblHemsida.Text = Översätt("Text", lblHemsida.Text);
            lblKansli.Text = Översätt("Text", lblKansli.Text);
            lblTelefonnr.Text = Översätt("Text", lblTelefonnr.Text);
            gbxAdressinfo.Text = Översätt("Text", gbxAdressinfo.Text);
            gbxBanor.Text = Översätt("Text", gbxBanor.Text);
            lnkHemsida.Text = Översätt("Text", lnkHemsida.Text);

            if (NyGolfklubb)
            {
                lnkHemsida.Visible = false;
            }

            foreach (System.Windows.Forms.Control cc in gbxAdressinfo.Controls)
            {

                if (cc.Name.StartsWith("lbl"))
                {
                    //då ska vi flytta lite till textboxen

                    cc.Text = Översätt("Text", cc.Text);
                }
            }

            for (int i = 0; i < dgwBanor.Columns.Count; i++)
            {
                dgwBanor.Columns[i].HeaderText = Översätt("Text", dgwBanor.Columns[i].HeaderText);
            }

            knappkontroller1.btnKnapp0.Text = Översätt("Text", "Knapp_Ny_Bana");
            knappkontroller1.btnKnapp1.Text = Översätt("Text", "Knapp_Spara_o_Stäng");
            knappkontroller1.btnKnapp1.Enabled = false;
            knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_Spara");
            knappkontroller1.btnKnapp2.Enabled = false;
            knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_TaBort");
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
        }

        /// <summary>
        /// Bilden fylls med banans data från databasen
        /// </summary>
        private void FyllBild()
        {
            DataSet banaDS = null;
            BanaAktivitet banaAktivitet = new BanaAktivitet();

            txtGolfklubbNamn.Text = Golfklubb.GolfklubbNamn;
            txtAdressBesok.Text = Golfklubb.AdressBesok;
            txtAdressOrt.Text = Golfklubb.AdressOrt;
            txtEpost.Text = Golfklubb.Epost;
            txtHemsida.Text = Golfklubb.Hemsida;

            if (txtHemsida.Text.Length > 0)
            {
                lnkHemsida.Visible = true;
            }
            else
            {
                lnkHemsida.Visible = false;
            }

            txtTelBokning.Text = Golfklubb.TelBokning;
            txtTelKansli.Text = Golfklubb.TelKansli;
            txtNotering.Text = Golfklubb.Notering;

            banaDS = banaAktivitet.HämtaBanorMedGolfklubbNr(Golfklubb.GolfklubbNr);

            if (banaDS != null && banaDS.Tables[0].Rows.Count > 0)
            {
                dgwBanor.Rows.Clear();
                dgwBanor.Rows.Add(banaDS.Tables[0].Rows.Count);
                for (int i = 0; i <= banaDS.Tables[0].Rows.Count - 1; i++)
                {
                    //dgwBanor.Rows.Add();
                    dgwBanor.Rows[i].Cells[0].Value = banaDS.Tables[0].Rows[i]["BanaNr"];
                    dgwBanor.Rows[i].Cells[1].Value = banaDS.Tables[0].Rows[i]["Namn"];
                    if (banaDS.Tables[0].Rows[i]["Aktuell"].ToString() == "1")
                    {
                        dgwBanor.Rows[i].Cells[2].Value = true;
                    }
                    else
                    {
                        dgwBanor.Rows[i].Cells[2].Value = false;
                    }
                    dgwBanor.Rows[i].Cells[3].Value = Functions.ToStr(banaDS.Tables[0].Rows[i]["Par"]);
                    dgwBanor.Rows[i].Cells[4].Value = Functions.ToStr(banaDS.Tables[0].Rows[i]["LangdGul"]);
                    dgwBanor.Rows[i].Cells[5].Value = Functions.ToStr(banaDS.Tables[0].Rows[i]["LangdRod"]);
                }
                knappkontroller1.btnKnapp2.Enabled = true;
            }
        }

        /// <summary>
        /// Hämta aktuella distriktkoder och fyll combon.
        /// </summary>
        private void FyllDistriktCombo(string landkod)
        {
            List<Koder> koder = null;
            Hooker.Affärslager.KoderAktivitet koderAktivitet = new Hooker.Affärslager.KoderAktivitet();

            try
            {
                //Typ = 1 är Distriktkoder
                koder = koderAktivitet.SökKoder((int)Kodtabell.Distrikt, landkod);

                if (koder.Count > 0)
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
        /// Gå igenom alla fält i bilden för Golfklubb innan uppdatering
        /// </summary>
        /// <returns>True om OK annars false</returns>
        private bool AllaFältIGolfklubbOK()
        {
            try
            {
                if (NyGolfklubb)
                {
                    Golfklubb = new Golfklubb();
                }

                //Alla fält från bilden flyttas till objektet
                Golfklubb.GolfklubbNamn = txtGolfklubbNamn.Text.ToString().Trim();
                if (cboLand.SelectedIndex != -1)
                {
                    Golfklubb.Landkod = ((ComboBoxKod)cboLand.SelectedItem).Kod.ToString();
                }
                else
                {
                    Golfklubb.Landkod = "00";
                }
                if (cboDistrikt.SelectedIndex != -1)
                {
                    Golfklubb.Distriktkod = ((ComboBoxKod)cboDistrikt.SelectedItem).Kod.ToString();
                }
                else
                {
                    Golfklubb.Distriktkod = "0000";
                }
                Golfklubb.AdressBesok = txtAdressBesok.Text.ToString().Trim();
                Golfklubb.AdressOrt = txtAdressOrt.Text.ToString().Trim();
                Golfklubb.Epost = txtEpost.Text.ToString().Trim();
                Golfklubb.Hemsida = txtHemsida.Text.ToString().Trim();
                Golfklubb.Notering = txtNotering.Text.ToString().Trim();
                Golfklubb.TelBokning = txtTelBokning.Text.ToString().Trim();
                Golfklubb.TelKansli = txtTelKansli.Text.ToString().Trim();
                Golfklubb.Notering = txtNotering.Text.ToString().Trim();
                Golfklubb.UppdatDatum = DateTime.Today;
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }

            return true;
        }
        #endregion
    }
}
