using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönsterklass för hantering av Bana
    /// </summary>
    public partial class BanaInfo : FormBas
    {
        #region Egenskapeer
        /// <summary>
        /// BanaNr
        /// </summary>
        public int BanaNr { get; set; }

        /// <summary>
        /// Objekt för Bana
        /// </summary>
        public Bana Bana { get; set; }

        /// <summary>
        /// Objekt för Golfklubb
        /// </summary>
        public Golfklubb Golfklubb { get; set; }

        /// <summary>
        /// Ny Bana
        /// </summary>
        public bool NyBana { get; set; }

        public string GolfklubbNr { get; private set; }
        #endregion

        /// <summary>
        /// Konstruktor
        /// </summary>
        public BanaInfo(string golfklubbNr)
        {
            FormsLaddar = true;
            FormsUppdaterad = false;
            GolfklubbNr = golfklubbNr;
            InitializeComponent();
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public BanaInfo()
        {
            FormsLaddar = true;
            FormsUppdaterad = false;
            InitializeComponent();
        }

        #region "Publika metoder"
        /// <summary>
        /// Ny bana initieras
        /// </summary>
        public void InitieraNyBana()
        {
            BanaAktivitet banaAktivitet = new BanaAktivitet();
            Bana = new Bana();
            GolfklubbAktivitet golfklubbAktivitet = new GolfklubbAktivitet();

            try
            {
                //Banans nummer hämtas med en Max(BanaNr)
                BanaNr = banaAktivitet.HämtaMaxBanNr() + 1;
                Bana.BanaNr = BanaNr;
                if (!string.IsNullOrEmpty(GolfklubbNr))
                {
                    Bana.GolfklubbNr = int.Parse(GolfklubbNr);
                    Golfklubb = golfklubbAktivitet.HämtaGolfklubb(Bana.GolfklubbNr);
                    if (Golfklubb != null)
                    {
                        FyllComboBoxKod(cboLand, Kodtabell.Land, Golfklubb.Landkod);
                        FyllComboBoxKod(cboDistrikt, Kodtabell.Distrikt, Golfklubb.Distriktkod);
                        //Om golfklubbsnummer finns ska Comboboxar för golfklubb skrivskyddas
                        cboGolfklubb.Enabled = false;
                        cboDistrikt.Enabled = false;
                        cboLand.Enabled = false;
                    }
                }
                else
                {
                    FyllComboBoxKod(cboLand, Kodtabell.Land, "01");
                }
                FyllGolfklubbCombo();
                knappkontroller1.btnKnapp0.Enabled = false;
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
        public void VisaBana()
        {
            BanaAktivitet banaAktivitet = new BanaAktivitet();
            GolfklubbAktivitet golfklubbAktivitet = new GolfklubbAktivitet();
            try
            {
                Bana = banaAktivitet.HämtaBanaBanaHal(BanaNr);
                FyllGolfklubbCombo();
                Golfklubb = golfklubbAktivitet.HämtaGolfklubb(Bana.GolfklubbNr);

                if (Bana != null)
                {
                    FyllBild();
                    if (Golfklubb != null)
                    {
                        FyllComboBoxKod(cboLand, Kodtabell.Land, Golfklubb.Landkod);
                        FyllComboBoxKod(cboDistrikt, Kodtabell.Distrikt, Golfklubb.Distriktkod);
                        cboGolfklubb.Enabled = false;
                    }
                    FormsLaddar = false;
                    FormsUppdaterad = false;
                    knappkontroller1.btnKnapp3.Enabled = true;
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
            tabScorekort.Text = Översätt("Text", tabScorekort.Text);
            tabUppgifter.Text = Översätt("Text", tabUppgifter.Text);

            lblBanaNamn.Text = Översätt("Text", lblBanaNamn.Text);
            lblLand.Text = Översätt("Text", lblLand.Text);
            lblDistrikt.Text = Översätt("Text", lblDistrikt.Text);
            gbxUt.Text = Översätt("Text", gbxUt.Text);
            gbxIn.Text = Översätt("Text", gbxIn.Text);
            txtParUt.Text = Översätt("Text", txtParUt.Text);
            txtHcpUt.Text = Översätt("Text", txtHcpUt.Text);
            txtParIn.Text = Översätt("Text", txtParIn.Text);
            txtHcpIn.Text = Översätt("Text", txtHcpIn.Text);
            lblSumma.Text = Översätt("Text", lblSumma.Text);
            btnBeraknaSlag.Text = Översätt("Text", btnBeraknaSlag.Text);
            lnkHemsida.Text = Översätt("Text", lnkHemsida.Text);
            lblAktuell.Text = Översätt("Text", lblAktuell.Text);
            gbxAntalHal.Text = Översätt("Text", gbxAntalHal.Text);

            if (NyBana)
            {
                lnkHemsida.Visible = false;
            }

            foreach (System.Windows.Forms.Control cc in gbxAntalHal.Controls)
            {
                if (cc.Name.StartsWith("rbn"))
                {
                    //då ska vi flytta lite till textboxen

                    cc.Text = Översätt("Text", cc.Text);
                }
            }

            foreach (System.Windows.Forms.Control cc in gbxUt.Controls)
            {

                if (cc.Name.StartsWith("lbl"))
                {
                    //då ska vi flytta lite till textboxen

                    cc.Text = Översätt("Text", cc.Text);
                }
            }

            foreach (System.Windows.Forms.Control cc in gbxIn.Controls)
            {

                if (cc.Name.StartsWith("lbl"))
                {
                    //då ska vi flytta lite till textboxen

                    cc.Text = Översätt("Text", cc.Text);
                }
            }

            foreach (System.Windows.Forms.Control cc in tabUppgifter.Controls)
            {

                if (cc.Name.StartsWith("lbl"))
                {
                    //då ska vi flytta lite till textboxen

                    cc.Text = Översätt("Text", cc.Text);
                }
                if (cc.Name.StartsWith("gbx"))
                {
                    //då ska vi flytta lite till textboxen

                    cc.Text = Översätt("Text", cc.Text);
                }
            }

            foreach (System.Windows.Forms.Control cc in gbxSlopekalkylator.Controls)
            {

                if (cc.Name.StartsWith("lbl"))
                {
                    //då ska vi flytta lite till textboxen

                    cc.Text = Översätt("Text", cc.Text);
                }
                if (cc.Name.StartsWith("rbn"))
                {
                    //då ska vi flytta lite till textboxen

                    cc.Text = Översätt("Text", cc.Text);
                }
            }

            foreach (System.Windows.Forms.Control cc in gbxSlope.Controls)
            {

                if (cc.Name.StartsWith("lbl"))
                {
                    //då ska vi flytta lite till textboxen

                    cc.Text = Översätt("Text", cc.Text);
                }
            }

            foreach (System.Windows.Forms.Control cc in gbxRanking.Controls)
            {

                if (cc.Name.StartsWith("lbl"))
                {
                    //då ska vi flytta lite till textboxen

                    cc.Text = Översätt("Text", cc.Text);
                }
            }

            knappkontroller1.btnKnapp0.Text = Översätt("Text", "Knapp_Visa_Golfklubb");
            knappkontroller1.btnKnapp1.Text = Översätt("Text", "Knapp_Kopiera");

            if (NyBana)
                knappkontroller1.btnKnapp1.Enabled = false;
            else
                knappkontroller1.btnKnapp1.Enabled = true;

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
            int halnr;
            int langd = 0;
            int langdVitSa = 0;
            int langdGulSa = 0;
            int langdBlaSa = 0;
            int langdRodSa = 0;
            int parSa = 0;
            int langdVitTot = 0;
            int langdGulTot = 0;
            int langdBlaTot = 0;
            int langdRodTot = 0;
            int parTot = 0;

            txtBanaNamn.Text = Bana.BanaNamn;

            if (Golfklubb != null)
            {
                txtAdressBesok.Text = Functions.ToStr(Golfklubb.AdressBesok);
                txtAdressOrt.Text = Functions.ToStr(Golfklubb.AdressOrt);
                txtEpost.Text = Functions.ToStr(Golfklubb.Epost);
                txtHemsida.Text = Functions.ToStr(Golfklubb.Hemsida);
                txtTelBokning.Text = Functions.ToStr(Golfklubb.TelBokning);
                txtTelKansli.Text = Functions.ToStr(Golfklubb.TelKansli);
            }

            txtDamerCRGul.Text = ("").Formatera(Bana.CrDamerGul);
            txtDamerCRRod.Text = ("").Formatera(Bana.CrDamerRod);
            txtDamerSlopeGul.Text = ("D").Formatera(Bana.SlopeDamerGul);
            txtDamerSlopeRod.Text = ("D").Formatera(Bana.SlopeDamerRod);

            if (txtHemsida.Text.Length > 0)
            {
                lnkHemsida.Visible = true;
            }
            else
            {
                lnkHemsida.Visible = false;
            }

            txtHerrarCRGul.Text = ("").Formatera(Bana.CrHerrarGul);
            txtHerrarCRRod.Text = ("").Formatera(Bana.CrHerrarRod);
            txtHerrarSlopeGul.Text = ("D").Formatera(Bana.SlopeHerrarGul);
            txtHerrarSlopeRod.Text = ("D").Formatera(Bana.SlopeHerrarRod);
            txtNotering.Text = Bana.Notering;
            txtLayout.Text = ("D").Formatera(Bana.RankLayout);
            txtEtikett.Text = ("D").Formatera(Bana.RankEtikett);
            txtNatur.Text = ("D").Formatera(Bana.RankNatur);
            txtRange.Text = ("D").Formatera(Bana.RankRange);
            txtSkick.Text = ("D").Formatera(Bana.RankSkick);
            txtStrategi.Text = ("D").Formatera(Bana.RankStrategi);

            if (Bana.Aktuell == "1")
            {
                cbxAktuell.Checked = true;
            }

            //Börja med hålen ut
            foreach (System.Windows.Forms.Control cc in gbxUt.Controls)
            {
                if (cc.Name.StartsWith("txtLangdVitHal"))
                {
                    //då ska vi flytta lite till textboxen
                    //Hålnr hämtas från kontrollens namn
                    halnr = int.Parse(cc.Name.Substring(14, 1));
                    langd = Bana.BanaHal[halnr - 1].LangdVit;
                    this.FyllLangdPerHal(halnr, langd, cc);
                    //cc.Text = ("D").Formatera(Bana.BanaHal[halnr - 1].LangdVit);
                    langdVitSa = langdVitSa + langd;
                    //int.Parse(Bana.BanaHal[halnr - 1].LangdVit.ToString());
                }
                if (cc.Name.StartsWith("txtLangdGulHal"))
                {
                    halnr = int.Parse(cc.Name.Substring(14, 1));
                    langd = Bana.BanaHal[halnr - 1].LangdGul;
                    this.FyllLangdPerHal(halnr, langd, cc);
                    //cc.Text = ("D").Formatera(Bana.BanaHal[halnr - 1].LangdGul);
                    langdGulSa = langdGulSa + langd;
                    //int.Parse(Bana.BanaHal[halnr - 1].LangdGul.ToString());
                }
                if (cc.Name.StartsWith("txtLangdBlaHal"))
                {
                    halnr = int.Parse(cc.Name.Substring(14, 1));
                    langd = Bana.BanaHal[halnr - 1].LangdBla;
                    this.FyllLangdPerHal(halnr, langd, cc);
                    //cc.Text = ("D").Formatera(Bana.BanaHal[halnr - 1].LangdBla);
                    langdBlaSa = langdBlaSa + langd;
                        //int.Parse(Bana.BanaHal[halnr - 1].LangdBla.ToString());
                }
                if (cc.Name.StartsWith("txtLangdRodHal"))
                {
                    halnr = int.Parse(cc.Name.Substring(14, 1));
                    langd = Bana.BanaHal[halnr - 1].LangdRod;
                    this.FyllLangdPerHal(halnr, langd, cc);
                    //cc.Text = ("D").Formatera(Bana.BanaHal[halnr - 1].LangdRod);
                    langdRodSa = langdRodSa + langd;
                        //int.Parse(Bana.BanaHal[halnr - 1].LangdRod.ToString());
                }
                if (cc.Name.StartsWith("txtParHal"))
                {
                    halnr = int.Parse(cc.Name.Substring(9, 1));
                    cc.Text = Bana.BanaHal[halnr - 1].Par.ToString();
                    parSa = parSa +
                        int.Parse(Bana.BanaHal[halnr - 1].Par.ToString());
                }
                if (cc.Name.StartsWith("txtHcpHal"))
                {
                    halnr = int.Parse(cc.Name.Substring(9, 1));
                    cc.Text = Bana.BanaHal[halnr - 1].Hcp.ToString();
                }
            }

            // och fortrsätt med hålen in
            txtLangdVitUtSa.Text = ("T").Formatera(langdVitSa);
            txtLangdGulUtSa.Text = ("T").Formatera(langdGulSa);
            txtLangdBlaUtSa.Text = ("T").Formatera(langdBlaSa);
            txtLangdRodUtSa.Text = ("T").Formatera(langdRodSa);
            txtParUtSa.Text = parSa.ToString();

            //Dags att visa uppgifterna för hålen in
            langdVitTot = langdVitTot + langdVitSa;
            langdGulTot = langdGulTot + langdGulSa;
            langdBlaTot = langdBlaTot + langdBlaSa;
            langdRodTot = langdRodTot + langdRodSa;
            parTot = parTot + parSa;
            langdVitSa = 0;
            langdGulSa = 0;
            langdBlaSa = 0;
            langdRodSa = 0;
            parSa = 0;

            foreach (System.Windows.Forms.Control cc in gbxIn.Controls)
            {
                if (cc.Name.StartsWith("txtLangdVitHal"))
                {
                    //då ska vi flytta lite till textboxen
                    //Hålnr hämtas från kontrollens namn
                    halnr = int.Parse(cc.Name.Substring(14, 2));
                    langd = Bana.BanaHal[halnr - 1].LangdVit;
                    this.FyllLangdPerHal(halnr, langd, cc);
                    //cc.Text = ("D").Formatera(Bana.BanaHal[halnr - 1].LangdVit);
                    langdVitSa = langdVitSa + langd;
                        //int.Parse(Bana.BanaHal[halnr - 1].LangdVit.ToString());
                }
                if (cc.Name.StartsWith("txtLangdGulHal"))
                {
                    halnr = int.Parse(cc.Name.Substring(14, 2));
                    langd = Bana.BanaHal[halnr - 1].LangdGul;
                    this.FyllLangdPerHal(halnr, langd, cc);
                    //cc.Text = ("D").Formatera(Bana.BanaHal[halnr - 1].LangdGul);
                    langdGulSa = langdGulSa + langd;
                        //int.Parse(Bana.BanaHal[halnr - 1].LangdGul.ToString());
                }
                if (cc.Name.StartsWith("txtLangdBlaHal"))
                {
                    halnr = int.Parse(cc.Name.Substring(14, 2));
                    langd = Bana.BanaHal[halnr - 1].LangdBla;
                    this.FyllLangdPerHal(halnr, langd, cc);
                    //cc.Text = ("D").Formatera(Bana.BanaHal[halnr - 1].LangdBla);
                    langdBlaSa = langdBlaSa + langd;
                        //int.Parse(Bana.BanaHal[halnr - 1].LangdBla.ToString());
                }
                if (cc.Name.StartsWith("txtLangdRodHal"))
                {
                    halnr = int.Parse(cc.Name.Substring(14, 2));
                    langd = Bana.BanaHal[halnr - 1].LangdRod;
                    this.FyllLangdPerHal(halnr, langd, cc);
                    //cc.Text = ("D").Formatera(Bana.BanaHal[halnr - 1].LangdRod);
                    langdRodSa = langdRodSa + langd;
                        //int.Parse(Bana.BanaHal[halnr - 1].LangdRod.ToString());
                }
                if (cc.Name.StartsWith("txtParHal"))
                {
                    halnr = int.Parse(cc.Name.Substring(9, 2));
                    cc.Text = Bana.BanaHal[halnr - 1].Par.ToString();
                    parSa = parSa +
                        int.Parse(Bana.BanaHal[halnr - 1].Par.ToString());
                }
                if (cc.Name.StartsWith("txtHcpHal"))
                {
                    halnr = int.Parse(cc.Name.Substring(9, 2));
                    cc.Text = Bana.BanaHal[halnr - 1].Hcp.ToString();
                }
            }

            txtLangdVitInSa.Text = ("T").Formatera(langdVitSa);
            txtLangdGulInSa.Text = ("T").Formatera(langdGulSa);
            txtLangdBlaInSa.Text = ("T").Formatera(langdBlaSa);
            txtLangdRodInSa.Text = ("T").Formatera(langdRodSa);
            txtParInSa.Text = parSa.ToString();

            langdVitTot += langdVitSa;
            langdGulTot = langdGulTot + langdGulSa;
            langdBlaTot = langdBlaTot + langdBlaSa;
            langdRodTot = langdRodTot + langdRodSa;
            parTot = parTot + parSa;

            txtLangdVitSa.Text = ("T").Formatera(langdVitTot);
            txtLangdGulSa.Text = ("T").Formatera(langdGulTot);
            txtLangdBlaSa.Text = ("T").Formatera(langdBlaTot);
            txtLangdRodSa.Text = ("T").Formatera(langdRodTot);
            txtParSa.Text = parTot.ToString();
        }

        private void FyllLangdPerHal(int halnr, int langd, 
            System.Windows.Forms.Control cc)
        {
            bool niohal = false;
            bool tolvhal = false;
            bool artonhal = false;

            switch (Bana.AntalHal)
            {
                case "9":
                    rbn9Hal.Checked = true;
                    niohal = true;
                    break;
                case "12":
                    rbn12Hal.Checked = true;
                    tolvhal = true;
                    break;
                case "18":
                    rbn18Hal.Checked = true;
                    artonhal = true;
                    break;
            }

            if (artonhal)
            {
                cc.Text = ("D").Formatera(langd);
            }
            else if (niohal && halnr < 10)
            {
                cc.Text = ("D").Formatera(langd);
            }
            else if (niohal && halnr > 9)
            {
                cc.Enabled = false;
            }
            else if (tolvhal && halnr < 13)
            {
                cc.Text = ("D").Formatera(langd);
            }
            else if (tolvhal && halnr > 12)
            {
                cc.Enabled = false;
            }
        }

        /// <summary>
        /// Hämta alla Golfklubbar och fyll combon.
        /// </summary>
        private void FyllGolfklubbCombo()
        {
            List<Golfklubb> golfklubbar = null;
            GolfklubbAktivitet golfklubbAktivitet = new GolfklubbAktivitet();

            try
            {
                golfklubbar = golfklubbAktivitet.SökGolfklubb("", "", "", "");

                if (golfklubbar != null)
                {
                    cboGolfklubb.Items.Clear();
                    cboGolfklubb.Items.Add(new ComboBoxPar(0, "", ""));
                    for (int i = 0; i <= golfklubbar.Count - 1; i++)
                    {
                        cboGolfklubb.Items.Add(new ComboBoxPar(golfklubbar[i].GolfklubbNr,
                            golfklubbar[i].GolfklubbNamn, golfklubbar[i]));
                    }

                    if (Functions.ToStr(Bana.GolfklubbNr) != string.Empty)
                    {
                        cboGolfklubb.SelectedItem = int.Parse(Bana.GolfklubbNr.ToString());
                    }

                    cboGolfklubb.DisplayMember = "visa";
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
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
        /// Gå igenom alla fält i bilden för Bana innan uppdatering
        /// </summary>
        /// <returns>True om OK annars false</returns>
        private bool AllaFältIBanaOK()
        {
            try
            {
                if (NyBana)
                {
                    Bana = new Bana();
                    Bana.BanaNr = BanaNr;
                }

                //Alla fält från bilden flyttas till objektet
                Bana.GolfklubbNr = ((ComboBoxPar)cboGolfklubb.SelectedItem).Identifier;
                Bana.BanaNamn = txtBanaNamn.Text.ToString().Trim();
                Bana.Notering = string.IsNullOrEmpty(txtNotering.Text.ToString()) ? string.Empty : txtNotering.Text.ToString().Trim();

                if (cbxAktuell.Checked)
                {
                    Bana.Aktuell = "1";
                }
                else
                {
                    Bana.Aktuell = "0";
                }

                if (rbn9Hal.Checked)
                {
                    Bana.AntalHal = "9";
                }
                else if (rbn12Hal.Checked)
                {
                    Bana.AntalHal = "12";
                }
                else if (rbn18Hal.Checked)
                {
                    Bana.AntalHal = "18";
                }

                if (!string.IsNullOrEmpty(txtEtikett.Text))
                {
                    Bana.RankEtikett = int.Parse(txtEtikett.Text);
                }

                if (!string.IsNullOrEmpty(txtLayout.Text))
                {
                    Bana.RankLayout = int.Parse(txtLayout.Text);
                }

                if (!string.IsNullOrEmpty(txtNatur.Text))
                {
                    Bana.RankNatur = int.Parse(txtNatur.Text);
                }

                if (!string.IsNullOrEmpty(txtRange.Text))
                {
                    Bana.RankRange = int.Parse(txtRange.Text);
                }

                if (!string.IsNullOrEmpty(txtSkick.Text))
                {
                    Bana.RankSkick = int.Parse(txtSkick.Text);
                }

                if (!string.IsNullOrEmpty(txtStrategi.Text))
                {
                    Bana.RankStrategi = int.Parse(txtStrategi.Text);
                }

                if (string.IsNullOrEmpty(txtDamerCRGul.Text.Trim()))
                {
                    Bana.CrDamerGul = 0;
                }
                else
                {
                    if (((txtDamerCRGul.Text).BytUtPunkt().ÄrEnIckeNegativDecimal()))
                    {
                        Bana.CrDamerGul = decimal.Parse(txtDamerCRGul.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        tabBanuppgifter.SelectedTab = tabUppgifter;
                        txtDamerCRGul.Focus();
                        return false;
                    }
                }
                if (string.IsNullOrEmpty(txtDamerCRRod.Text.Trim()))
                {
                    //Bana.CrDamerRod = 0;
                    VisaFelmeddelande("CRSLOPEMISSING");
                }
                else
                {
                    if (((txtDamerCRRod.Text).BytUtPunkt().ÄrEnIckeNegativDecimal()))
                    {
                        Bana.CrDamerRod = decimal.Parse(txtDamerCRRod.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        tabBanuppgifter.SelectedTab = tabUppgifter;
                        txtDamerCRRod.Focus();
                        return false;
                    }
                }
                if (string.IsNullOrEmpty(txtHerrarCRGul.Text.Trim()))
                {
                    //Bana.CrHerrarGul = 0;
                    VisaFelmeddelande("CRSLOPEMISSING");
                }
                else
                {
                    if (((txtHerrarCRGul.Text).BytUtPunkt().ÄrEnIckeNegativDecimal()))
                    {
                        Bana.CrHerrarGul = decimal.Parse(txtHerrarCRGul.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        tabBanuppgifter.SelectedTab = tabUppgifter;
                        txtHerrarCRGul.Focus();
                        return false;
                    }
                }
                if (string.IsNullOrEmpty(txtHerrarCRRod.Text.Trim()))
                {
                    Bana.CrHerrarRod = 0;
                }
                else
                {
                    if (((txtHerrarCRRod.Text).BytUtPunkt().ÄrEnIckeNegativDecimal()))
                    {
                        Bana.CrHerrarRod = decimal.Parse(txtHerrarCRRod.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        tabBanuppgifter.SelectedTab = tabUppgifter;
                        txtHerrarCRRod.Focus();
                        return false;
                    }
                }

                if (string.IsNullOrEmpty(txtDamerSlopeGul.Text.Trim()))
                {
                    Bana.SlopeDamerGul = 0;
                }
                else
                {
                    if ((txtDamerSlopeGul.Text).ÄrEnInt())
                    {
                        Bana.SlopeDamerGul = int.Parse(txtDamerSlopeGul.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        tabBanuppgifter.SelectedTab = tabUppgifter;
                        txtDamerSlopeGul.Focus();
                        return false;
                    }
                }
                if (string.IsNullOrEmpty(txtDamerSlopeRod.Text.Trim()))
                {
                    //Bana.SlopeDamerRod = 0;
                    VisaFelmeddelande("CRSLOPEMISSING");
                }
                else
                {
                    if ((txtDamerSlopeRod.Text).ÄrEnInt())
                    {
                        Bana.SlopeDamerRod = int.Parse(txtDamerSlopeRod.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        tabBanuppgifter.SelectedTab = tabUppgifter;
                        txtDamerSlopeRod.Focus();
                        return false;
                    }
                }
                if (string.IsNullOrEmpty(txtHerrarSlopeGul.Text.Trim()))
                {
                    //Bana.SlopeHerrarGul = 0;
                    VisaFelmeddelande("CRSLOPEMISSING");
                }
                else
                {
                    if ((txtHerrarSlopeGul.Text).ÄrEnInt())
                    {
                        Bana.SlopeHerrarGul = int.Parse(txtHerrarSlopeGul.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        tabBanuppgifter.SelectedTab = tabUppgifter;
                        txtHerrarSlopeGul.Focus();
                        return false;
                    }
                }
                if (string.IsNullOrEmpty(txtHerrarSlopeRod.Text.Trim()))
                {
                    Bana.SlopeHerrarRod = 0;
                }
                else
                {
                    if ((txtHerrarSlopeRod.Text).ÄrEnInt())
                    {
                        Bana.SlopeHerrarRod = int.Parse(txtHerrarSlopeRod.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        tabBanuppgifter.SelectedTab = tabUppgifter;
                        txtHerrarSlopeRod.Focus();
                        return false;
                    }
                }
                Bana.UppdatDatum = DateTime.Today;
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }

            return true;
        }

        /// <summary>
        /// Gå igenom alla fält i bilden för Bana innan uppdatering
        /// </summary>
        /// <returns>True om OK annars false</returns>
        private bool AllaFältIBanaHalOK()
        {
            int halnr;
            bool result = false;
            tabBanuppgifter.SelectedTab = tabScorekort;

            try
            {
                //Om ny Bana ska nya rader skapas för BanaHal. Den här kontrollen ligger först
                if (NyBana)
                {
                    InitieraBanaHal();
                }

                //Börja med hålen ut
                foreach (System.Windows.Forms.Control cc in gbxUt.Controls)
                {
                    if (cc.Name.StartsWith("txtLangdVitHal"))
                    {
                        //då ska vi kolla textboxen och, om OK, flytta till objektet
                        //Hålnr hämtas från kontrollens namn
                        halnr = int.Parse(cc.Name.Substring(14, 1));
                        if (cc.Text.Trim().Length == 0)
                        {
                            Bana.BanaHal[halnr - 1].LangdVit = 0;
                        }
                        else
                        {
                            if ((cc.Text).ÄrEnInt())
                            {
                                Bana.BanaHal[halnr - 1].LangdVit = int.Parse(cc.Text);
                            }
                            else
                            {
                                VisaFelmeddelande("NOTNUMERIC");
                                cc.Focus();
                                return result;
                            }
                        }
                    }
                    if (cc.Name.StartsWith("txtLangdGulHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(14, 1));
                        if (cc.Text.Trim().Length == 0)
                        {
                            Bana.BanaHal[halnr - 1].LangdGul = 0;
                        }
                        else
                        {
                            if ((cc.Text).ÄrEnInt())
                            {
                                Bana.BanaHal[halnr - 1].LangdGul = int.Parse(cc.Text);
                            }
                            else
                            {
                                VisaFelmeddelande("NOTNUMERIC");
                                cc.Focus();
                                return result;
                            }
                        }
                    }
                    if (cc.Name.StartsWith("txtLangdBlaHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(14, 1));
                        if (cc.Text.Trim().Length == 0)
                        {
                            Bana.BanaHal[halnr - 1].LangdBla = 0;
                        }
                        else
                        {
                            if ((cc.Text).ÄrEnInt())
                            {
                                Bana.BanaHal[halnr - 1].LangdBla = int.Parse(cc.Text);
                            }
                            else
                            {
                                VisaFelmeddelande("NOTNUMERIC");
                                cc.Focus();
                                return result;
                            }
                        }
                    }
                    if (cc.Name.StartsWith("txtLangdRodHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(14, 1));
                        if (cc.Text.Trim().Length == 0)
                        {
                            Bana.BanaHal[halnr - 1].LangdRod = 0;
                        }
                        else
                        {
                            if ((cc.Text).ÄrEnInt())
                            {
                                Bana.BanaHal[halnr - 1].LangdRod = int.Parse(cc.Text);
                            }
                            else
                            {
                                VisaFelmeddelande("NOTNUMERIC");
                                cc.Focus();
                                return result;
                            }
                        }
                    }
                    if (cc.Name.StartsWith("txtParHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(9, 1));
                        if (cc.Text.Trim().Length > 0)
                        {
                            if ((cc.Text).ÄrEnInt())
                            {
                                Bana.BanaHal[halnr - 1].Par = int.Parse(cc.Text);
                            }
                            else
                            {
                                VisaFelmeddelande("NOTNUMERIC");
                                cc.Focus();
                                return result;
                            }
                        }
                    }
                    if (cc.Name.StartsWith("txtHcpHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(9, 1));
                        if (cc.Text.Trim().Length > 0)
                        {
                            if ((cc.Text).ÄrEnInt())
                            {
                                Bana.BanaHal[halnr - 1].Hcp = int.Parse(cc.Text);
                            }
                            else
                            {
                                VisaFelmeddelande("NOTNUMERIC");
                                cc.Focus();
                                return result;
                            }
                        }

                    }
                }

                //och sedan hålen in
                foreach (System.Windows.Forms.Control cc in gbxIn.Controls)
                {
                    if (cc.Name.StartsWith("txtLangdVitHal"))
                    {
                        //då ska vi kolla textboxen och, om OK, flytta till objektet
                        //Hålnr hämtas från kontrollens namn
                        halnr = int.Parse(cc.Name.Substring(14, 2));
                        if (cc.Text.Trim().Length == 0)
                        {
                            Bana.BanaHal[halnr - 1].LangdVit = 0;
                        }
                        else
                        {
                            if ((cc.Text).ÄrEnInt())
                            {
                                Bana.BanaHal[halnr - 1].LangdVit = int.Parse(cc.Text);
                            }
                            else
                            {
                                VisaFelmeddelande("NOTNUMERIC");
                                cc.Focus();
                                return result;
                            }
                        }
                    }
                    if (cc.Name.StartsWith("txtLangdGulHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(14, 2));
                        if (cc.Text.Trim().Length == 0)
                        {
                            Bana.BanaHal[halnr - 1].LangdGul = 0;
                        }
                        else
                        {
                            if ((cc.Text).ÄrEnInt())
                            {
                                Bana.BanaHal[halnr - 1].LangdGul = int.Parse(cc.Text);
                            }
                            else
                            {
                                VisaFelmeddelande("NOTNUMERIC");
                                cc.Focus();
                                return result;
                            }
                        }
                    }
                    if (cc.Name.StartsWith("txtLangdBlaHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(14, 2));
                        if (cc.Text.Trim().Length == 0)
                        {
                            Bana.BanaHal[halnr - 1].LangdBla = 0;
                        }
                        else
                        {
                            if ((cc.Text).ÄrEnInt())
                            {
                                Bana.BanaHal[halnr - 1].LangdBla = int.Parse(cc.Text);
                            }
                            else
                            {
                                VisaFelmeddelande("NOTNUMERIC");
                                cc.Focus();
                                return result;
                            }
                        }
                    }
                    if (cc.Name.StartsWith("txtLangdRodHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(14, 2));
                        if (cc.Text.Trim().Length == 0)
                        {
                            Bana.BanaHal[halnr - 1].LangdRod = 0;
                        }
                        else
                        {
                            if ((cc.Text).ÄrEnInt())
                            {
                                Bana.BanaHal[halnr - 1].LangdRod = int.Parse(cc.Text);
                            }
                            else
                            {
                                VisaFelmeddelande("NOTNUMERIC");
                                cc.Focus();
                                return result;
                            }
                        }
                    }
                    if (cc.Name.StartsWith("txtParHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(9, 2));
                        if (cc.Text.Trim().Length > 0)
                        {
                            if ((cc.Text).ÄrEnInt())
                            {
                                Bana.BanaHal[halnr - 1].Par = int.Parse(cc.Text);
                            }
                            else
                            {
                                VisaFelmeddelande("NOTNUMERIC");
                                cc.Focus();
                                return result;
                            }
                        }
                    }
                    if (cc.Name.StartsWith("txtHcpHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(9, 2));
                        if (cc.Text.Trim().Length > 0)
                        {
                            if ((cc.Text).ÄrEnInt())
                            {
                                Bana.BanaHal[halnr - 1].Hcp = int.Parse(cc.Text);
                            }
                            else
                            {
                                VisaFelmeddelande("NOTNUMERIC");
                                cc.Focus();
                                return result;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
            result = true;
            return result;
        }

        /// <summary>
        /// Tabellen BanaHal initieras om ny bana, kontrollerna på scorekortet kommer lite hur som helst
        /// varför det inte går (?) att lösa på ett smidigare sätt.
        /// </summary>
        private void InitieraBanaHal()
        {
            BanaHal banaHal;
            try
            {
                for (int i = 0; i < 18; i++)
                {
                    banaHal = new BanaHal();
                    banaHal.BanaNr = Bana.BanaNr;
                    banaHal.HalNr = i + 1;
                    banaHal.LangdVit = 0;
                    banaHal.LangdBla = 0;
                    banaHal.LangdGul = 0;
                    banaHal.LangdRod = 0;
                    banaHal.Par = 0;
                    banaHal.Hcp = 0;
                    Bana.AddBanaHal(banaHal);
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }
        #endregion
    }
}
