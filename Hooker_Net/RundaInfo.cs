using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönsterklass för Runda
    /// </summary>
    public partial class RundaInfo : FormBas
    {
        #region "Egenskaper"
        /// <summary>
        /// RundaNr
        /// </summary>
        public int RundaNr { get; set; }

        /// <summary>
        /// BanaNr
        /// </summary>
        public int BanaNr { get; set; }

        /// <summary>
        /// GolfklubbNr
        /// </summary>
        public int GolfklubbNr { get; set; }

        /// <summary>
        /// Objekt för Runda, RundaHal och Redovisning
        /// </summary>
        public Runda Runda { get; set; }

        /// <summary>
        /// Objektet Bana
        /// </summary>
        public Bana Bana { get; set; }

        /// <summary>
        /// Objekt för Spelare
        /// </summary>
        public Spelare Spelare { get; set; }

        /// <summary>
        /// Ny Runda
        /// </summary>
        public bool NyRunda { get; set; }
        #endregion

        /// <summary>
        /// Konstruktor
        /// </summary>
        public RundaInfo()
        {
            FormsLaddar = true;
            FormsUppdaterad = false;
            InitializeComponent();
        }

        #region "Publika metoder"
        /// <summary>
        /// Ny runda initieras
        /// </summary>
        public void InitieraNyRunda()
        {
            RundaAktivitet rundaAktivitet = new RundaAktivitet();

            try
            {
                NyRunda = true;
                Timglas.WaitCurson();

                //Rundans nummer hämtas med en Max(RundaNr)
                //RundaNr = rundaAktivitet.HämtaMaxRundaNr() + 1;
                //Runda = rundaAktivitet.HämtaRundaRundaHalRedovisning(RundaNr);
                dtpDatum.Text = ("STD").Formatera(DateTime.Today);
                FyllSpelareCombo();

                //Hämta Spelarensinfo med SpelarID från Användarobjektet
                SpelareAktivitet spelareAktivitet = new SpelareAktivitet();
                Spelare = spelareAktivitet.HämtaSpelare(AppUser.SpelarID);
                if (Spelare != null)
                {
                    if (Spelare.Kön == "M")
                    {
                        rbnGul.Checked = true;
                    }
                    else if (Spelare.Kön == "K")
                    {
                        rbnRod.Checked = true;
                    }

                    GolfklubbNr = Spelare.GolfklubbNr;
                    BanaNr = Spelare.HemmabanaNr;
                    txtExaktHcp.Text = Spelare.ExaktHcp.ToString();
                    FyllBanaHal(Spelare.HemmabanaNr);
                }

                FyllGolfklubbCombo();
                txtPlacering.Enabled = false;
                knappkontroller1.btnKnapp0.Enabled = false;
                knappkontroller1.btnKnapp1.Enabled = false;
                knappkontroller1.btnKnapp2.Enabled = false;
                knappkontroller1.btnKnapp3.Enabled = false;
                BanaNr = 0;
                Runda.Notering = string.Empty;
                txtSummaPoangUt.Text = "0";
                txtSummaSlagUt.Text = "0";
                txtSummaPoangIn.Text = "0";
                txtSummaSlagIn.Text = "0";
                txtSummaPoang.Text = "0";
                txtSummaSlag.Text = "0";
                Timglas.DefaultCursor();
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hämta info i databasen och presentera
        /// </summary>
        public void VisaRunda()
        {
            RundaAktivitet rundaAktivitet = new RundaAktivitet();
            try
            {
                Timglas.WaitCurson();
                Runda = rundaAktivitet.HämtaRundaRundaHalRedovisning(RundaNr);

                if (Runda != null)
                {
                    FyllSpelareCombo();
                    HämtaBana(Runda.BanaNr);
                    FyllGolfklubbCombo();
                    FyllBanorCombo();
                    FyllBanaHal(Runda.BanaNr);
                    FyllBild();
                    knappkontroller1.btnKnapp1.Enabled = false;
                    knappkontroller1.btnKnapp2.Enabled = false;
                    FormsLaddar = false;
                    FormsUppdaterad = false;
                    knappkontroller1.btnKnapp3.Enabled = true;
                    dtpDatum.Focus();
                    Timglas.DefaultCursor();
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
            gbxRondinformation.Text = Översätt("Text", gbxRondinformation.Text);
            gbxKostnader.Text = Översätt("Text", gbxKostnader.Text);
            gbxUt.Text = Översätt("Text", gbxUt.Text);
            gbxIn.Text = Översätt("Text", gbxIn.Text);
            lblTotal.Text = Översätt("Text", lblTotal.Text);
            gbxRondstatistik.Text = Översätt("Text", gbxRondstatistik.Text);

            foreach (System.Windows.Forms.Control cc in gbxRondinformation.Controls)
            {
                if (cc.Name.StartsWith("lbl"))
                {
                    //då ska vi flytta lite till textboxen
                    cc.Text = Översätt("Text", cc.Text);
                }
                if (cc.Name.StartsWith("rbn"))
                {
                    cc.Text = Översätt("Text", cc.Text);
                }
                if (cc.Name.StartsWith("cbx"))
                {
                    cc.Text = Översätt("Text", cc.Text);
                }
            }

            foreach (System.Windows.Forms.Control cc in gbxKostnader.Controls)
            {
                if (cc.Name.StartsWith("lbl"))
                {
                    cc.Text = Översätt("Text", cc.Text);
                }
            }

            foreach (System.Windows.Forms.Control cc in gbxUt.Controls)
            {
                if (cc.Name.StartsWith("lbl"))
                {
                    cc.Text = Översätt("Text", cc.Text);
                }
            }

            foreach (System.Windows.Forms.Control cc in gbxIn.Controls)
            {
                if (cc.Name.StartsWith("lbl"))
                {
                    cc.Text = Översätt("Text", cc.Text);
                }
            }

            foreach (System.Windows.Forms.Control cc in gbxRondstatistik.Controls)
            {
                if (cc.Name.StartsWith("lbl"))
                {
                    cc.Text = Översätt("Text", cc.Text);
                }
            }

            knappkontroller1.btnKnapp0.Text = Översätt("Text", "Knapp_Rondgraf");
            knappkontroller1.btnKnapp1.Text = Översätt("Text", "Knapp_Spara_o_Stäng");
            knappkontroller1.btnKnapp1.Enabled = false;
            knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_Spara");
            knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_TaBort");
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
        }

        /// <summary>
        /// Hämta alla Spelare och fyll combon.
        /// </summary>
        private void FyllSpelareCombo()
        {
            Hooker.Affärslager.SpelareAktivitet spelareAktivitet = new Hooker.Affärslager.SpelareAktivitet();

            try
            {
                List<Spelare> spelarLista = spelareAktivitet.SökSpelare("", "");

                if (spelarLista.Count > 0)
                {
                    if (cboSpelare.Items.Count == 0)
                    {
                        cboSpelare.Items.Clear();
                        cboMarkor.Items.Clear();
                        cboSpelare.Items.Add(new ComboBoxPar(0, "", ""));
                        cboMarkor.Items.Add(new ComboBoxPar(0, "", ""));
                        for (int i = 0; i < spelarLista.Count; i++)
                        {
                            cboSpelare.Items.Add(new ComboBoxPar(spelarLista[i].AktuelltSpelarID,
                                spelarLista[i].Namn, spelarLista[i]));
                            cboMarkor.Items.Add(new ComboBoxPar(spelarLista[i].AktuelltSpelarID,
                                spelarLista[i].Namn, spelarLista[i]));
                        }
                    }

                    if (NyRunda)
                    {
                        cboSpelare.SelectedItem = AppUser.SpelarID;
                        cboMarkor.SelectedItem = AppUser.SpelarID;
                    }
                    else
                    {
                        cboSpelare.SelectedItem = Convert.ToInt32(Runda.SpelarID.ToString());
                        cboMarkor.SelectedItem = Convert.ToInt32(Runda.Markor.ToString());
                    }
                    cboSpelare.DisplayMember = "visa";
                    cboMarkor.DisplayMember = "visa";
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        private void HämtaBana(int banaNr)
        {
            BanaAktivitet banaAktivitet = new BanaAktivitet();
            Bana = banaAktivitet.HämtaBana(banaNr);
            GolfklubbNr = Bana.GolfklubbNr;
        }

        /// <summary>
        /// Hämta alla Golfklubbar och fyll combon. Aktuell Golfklubb väljs i combon.
        /// </summary>
        private void FyllGolfklubbCombo()
        {
            List<Golfklubb> golfklubb = null;
            GolfklubbAktivitet golfklubbAktivitet = new GolfklubbAktivitet();

            try
            {
                golfklubb = golfklubbAktivitet.HämtaGolfklubb("");

                if (golfklubb != null)
                {
                    cboGolfklubb.Items.Clear();
                    cboGolfklubb.Items.Add(new ComboBoxPar(0, "", ""));
                    foreach (Golfklubb rad in golfklubb)
                    {
                        cboGolfklubb.Items.Add(new ComboBoxPar(int.Parse(rad.GolfklubbNr.ToString()),
                            rad.GolfklubbNamn.ToString(), rad));
                    }

                    cboGolfklubb.SelectedItem = int.Parse(GolfklubbNr.ToString());
                    cboGolfklubb.DisplayMember = "visa";
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hämta alla Banor och fyll combon.
        /// </summary>
        private void FyllBanorCombo()
        {
            List<Bana> banaLista = null;
            BanaAktivitet banaAktivitet = new BanaAktivitet();

            try
            {
                if (GolfklubbNr != 0)
                {
                    banaLista = banaAktivitet.HämtaAktuellaBanorMedGolfklubbNr(GolfklubbNr);

                    if (banaLista != null && banaLista.Count > 0)
                    {
                        cboBana.Items.Clear();
                        //cboBana.Items.Add(new ComboBoxPar(0, "", ""));
                        for (int i = 0; i <= banaLista.Count - 1; i++)
                        {
                            cboBana.Items.Add(new ComboBoxPar(banaLista[i].BanaNr,
                                banaLista[i].BanaNamn, banaLista[i]));
                        }

                        if (BanaNr != 0)
                        {
                            cboBana.SelectedItem = int.Parse(BanaNr.ToString());
                        }
                        else if (Functions.ToInt(Runda.BanaNr) != 0)
                        {
                            cboBana.SelectedItem = int.Parse(Runda.BanaNr.ToString());
                        }
                        else
                        {
                            cboBana.SelectedItem = int.Parse(banaLista[0].BanaNr.ToString());
                            BanaNr = int.Parse(banaLista[0].BanaNr.ToString());
                        }

                        cboBana.DisplayMember = "visa";
                    }
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hämtar aktuell bana och banahal för att fylla "scorekortet"
        /// </summary>
        private void FyllBanaHal(int banaNr)
        {
            Hooker.Affärslager.BanaAktivitet banaAktivitet = new Hooker.Affärslager.BanaAktivitet();
            int halnr;
            int parUt = 0;
            int parIn = 0;
            try
            {
                BanaNr = banaNr;
                Bana = banaAktivitet.HämtaBanaBanaHal(banaNr);

                //Börja med hålen ut
                foreach (System.Windows.Forms.Control cc in gbxUt.Controls)
                {
                    //if (cc.Name.StartsWith("lblHal
                    //{
                    //    this.HanteraAntalHal(cc);
                    //}

                    if (cc.Name.StartsWith("txtParHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(9, 1));
                        this.HanteraAntalHal(halnr, cc);
                        cc.Text = Bana.BanaHal[halnr - 1].Par.ToString();
                        parUt += int.Parse(Bana.BanaHal[halnr - 1].Par.ToString());
                    }
                    if (cc.Name.StartsWith("txtHcpHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(9, 1));
                        this.HanteraAntalHal(halnr, cc);
                        cc.Text = Bana.BanaHal[halnr - 1].Hcp.ToString();
                    }
                    if (cc.Name.StartsWith("txtSlagHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(10, 1));
                        this.HanteraAntalHal(halnr, cc);
                    }
                    if (cc.Name.StartsWith("txtPuttarHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(12, 1));
                        this.HanteraAntalHal(halnr, cc);
                    }
                    if (cc.Name.StartsWith("txtPoangHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(11, 1));
                        this.HanteraAntalHal(halnr, cc);
                    }
                    if (cc.Name.StartsWith("txtPliktHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(11, 1));
                        this.HanteraAntalHal(halnr, cc);
                    }
                    if (cc.Name.StartsWith("cbxFWHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(8, 1));
                        this.HanteraAntalHal(halnr, cc);
                    }
                    if (cc.Name.StartsWith("cbxGRHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(8, 1));
                        this.HanteraAntalHal(halnr, cc);
                    }
                }

                //och fortsätt sedan med hålen in
                foreach (System.Windows.Forms.Control cc in gbxIn.Controls)
                {
                    if (cc.Name.StartsWith("txtParHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(9, 2));
                        this.HanteraAntalHal(halnr, cc);
                        cc.Text = Bana.BanaHal[halnr - 1].Par.ToString();
                        parIn += int.Parse(Bana.BanaHal[halnr - 1].Par.ToString());
                    }
                    if (cc.Name.StartsWith("txtHcpHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(9, 2));
                        this.HanteraAntalHal(halnr, cc);
                        cc.Text = Bana.BanaHal[halnr - 1].Hcp.ToString();
                    }
                    if (cc.Name.StartsWith("txtSlagHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(10, 2));
                        this.HanteraAntalHal(halnr, cc);
                    }
                    if (cc.Name.StartsWith("txtPuttarHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(12, 2));
                        this.HanteraAntalHal(halnr, cc);
                    }
                    if (cc.Name.StartsWith("txtPoangHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(11, 2));
                        this.HanteraAntalHal(halnr, cc);
                    }
                    if (cc.Name.StartsWith("txtPliktHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(11, 2));
                        this.HanteraAntalHal(halnr, cc);
                    }
                    if (cc.Name.StartsWith("cbxFWHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(8, 2));
                        this.HanteraAntalHal(halnr, cc);
                    }
                    if (cc.Name.StartsWith("cbxGRHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(8, 2));
                        this.HanteraAntalHal(halnr, cc);
                    }
                }

                txtSummaParUt.Text = parUt.ToString();
                txtSummaParIn.Text = parIn.ToString();
                txtSummaPar.Text = (parUt + parIn).ToString();
            }
            catch (HookerException)
            {
                VisaFelmeddelande(FelID);
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hantera bana med olika antal hål
        /// </summary>
        /// <param name="cc"></param>
        private void HanteraAntalHal(int halnr, System.Windows.Forms.Control cc)
        {
            bool niohal = false;
            bool tolvhal = false;
            bool artonhal = false;

            switch (Bana.AntalHal)
            {
                case "9":
                    niohal = true;
                    break;
                case "12":
                    tolvhal = true;
                    break;
                case "18":
                    artonhal = true;
                    break;
            }

            if (artonhal)
            {
                //Gör ingenting
                return;
            }
            else if (niohal && halnr < 10)
            {
                //Samma här
                return;
            }
            else if (niohal && halnr > 9)
            {
                if (cc.GetType() == typeof(TextBox))
                {
                    TextBox textBox = cc as TextBox;
                    textBox.BackColor = Color.AntiqueWhite;
                    textBox.Enabled = false;
                }
                if (cc.GetType() == typeof(CheckBox))
                {
                    CheckBox checkBox = cc as CheckBox;
                    checkBox.BackColor = Color.AntiqueWhite;
                    checkBox.Enabled = false;
                }
            }
            //else if (tolvhal && halnr < 13)
            //{
            //    //cc.Text = ("D").Formatera(langd);
            //}
            else if (tolvhal && halnr > 12)
            {
                if (cc.GetType() == typeof(TextBox))
                {
                    TextBox textBox = cc as TextBox;
                    textBox.BackColor = Color.AntiqueWhite;
                    textBox.Enabled = false;
                }
                if (cc.GetType() == typeof(CheckBox))
                {
                    CheckBox checkBox = cc as CheckBox;
                    checkBox.BackColor = Color.AntiqueWhite;
                    checkBox.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Bilden fylls med Rundans data från databasen
        /// </summary>
        private void FyllBild()
        {
            decimal summa = 0;
            int halnr;
            int slagUt = 0;
            int poangUt = 0;
            decimal puttarUt = 0;
            decimal fwUt = 0;
            decimal grUt = 0;
            int pliktUt = 0;
            int slagIn = 0;
            int poangIn = 0;
            decimal puttarIn = 0;
            decimal fwIn = 0;
            decimal grIn = 0;
            int pliktIn = 0;
            int antalTrippel = 0;
            int antalDubbel = 0;
            int antalBogies = 0;
            int antalPar = 0;
            int antalBirdies = 0;
            int antalEagles = 0;

            try
            {
                dtpDatum.Text = ("STD").Formatera(DateTime.Parse(Runda.Datum.ToShortDateString()));
                txtErhallnaSlag.Text = ("N").Formatera(Runda.ErhallnaSlag);
                txtExaktHcp.Text = ("ND1").Formatera(Runda.ExaktHcp);
                //txtNotering.Text = Runda.Notering.ToString();
                txtPlacering.Text = ("D").Formatera(Runda.Placering);

                switch (Runda.Tee)
                {
                    case "V":
                        rbnVit.Checked = true;
                        break;
                    case "G":
                        rbnGul.Checked = true;
                        break;
                    case "S":
                        rbnSvart.Checked = true;
                        break;
                    case "B":
                        rbnBla.Checked = true;
                        break;
                    case "R":
                        rbnRod.Checked = true;
                        break;
                }

                if (Runda.Hcprond == "X")
                {
                    cbxHcprond.Checked = true;
                }

                if (Runda.Tavlingsrond == "X")
                {
                    cbxTavlingsrond.Checked = true;
                }

                if (Runda.Sallskapsrond == "X")
                {
                    cbxSallskapsrond.Checked = true;
                }

                //Redovisningsposterna, men först ska fälten rensas på ev gammalt skräp
                txtBett.Text = "";
                txtBollar.Text = "";
                txtGreenfee.Text = "";
                txtStartavgift.Text = "";
                txtSumma.Text = "";
                if (Runda.HarRedovisningar())
                {
                    for (int i = 0; i < Runda.Redovisning.Length; i++)
                    {
                        switch (Runda.Redovisning[i].Typ.Trim())
                        {
                            case "1":
                                txtBett.Text = ("D").Formatera(Runda.Redovisning[i].Belopp);
                                summa = summa + Runda.Redovisning[i].Belopp;
                                break;
                            case "2":
                                txtBollar.Text = ("D").Formatera(Runda.Redovisning[i].Belopp);
                                summa = summa + Runda.Redovisning[i].Belopp;
                                break;
                            case "4":
                                txtGreenfee.Text = ("D").Formatera(Runda.Redovisning[i].Belopp);
                                summa = summa + Runda.Redovisning[i].Belopp;
                                break;
                            case "12":
                                txtStartavgift.Text = ("D").Formatera(Runda.Redovisning[i].Belopp);
                                summa = summa + Runda.Redovisning[i].Belopp;
                                break;
                        }
                    }
                    txtSumma.Text = ("T").Formatera(summa);
                }

                //Börja med hålen ut
                foreach (System.Windows.Forms.Control cc in gbxUt.Controls)
                {
                    if (cc.Name.StartsWith("txtSlagHal"))
                    {
                        //då ska vi flytta lite till textboxen
                        //Hålnr hämtas från kontrollens namn
                        halnr = int.Parse(cc.Name.Substring(10, 1));
                        cc.Text = ("N").Formatera(Runda.RundaHal[halnr - 1].AntalSlag);
                        slagUt += int.Parse(Runda.RundaHal[halnr - 1].AntalSlag.ToString());

                        //Sätt blå färg om sämre än par, röd om bättre än par
                        cc.ForeColor = (Runda.RundaHal[halnr - 1].AntalSlag.SättFärg(Bana.BanaHal[halnr - 1].Par, true));

                        // och räkna antalet par, birdies etc
                        if (Runda.RundaHal[halnr - 1].AntalSlag >
                            Bana.BanaHal[halnr - 1].Par + 2)
                        {
                            antalTrippel++;
                        }
                        else if (Runda.RundaHal[halnr - 1].AntalSlag >
                            Bana.BanaHal[halnr - 1].Par + 1)
                        {
                            antalDubbel++;
                        }
                        else if (Runda.RundaHal[halnr - 1].AntalSlag >
                            Bana.BanaHal[halnr - 1].Par)
                        {
                            antalBogies++;
                        }
                        else if (Runda.RundaHal[halnr - 1].AntalSlag ==
                            Bana.BanaHal[halnr - 1].Par)
                        {
                            antalPar++;
                        }
                        else if (Runda.RundaHal[halnr - 1].AntalSlag <
                            Bana.BanaHal[halnr - 1].Par - 1)
                        {
                            antalEagles++;
                        }
                        else if (Runda.RundaHal[halnr - 1].AntalSlag <
                            Bana.BanaHal[halnr - 1].Par)
                        {
                            antalBirdies++;
                        }
                    }
                    if (cc.Name.StartsWith("txtPoangHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(11, 1));
                        cc.Text = ("N").Formatera(Runda.RundaHal[halnr - 1].AntalPoang);
                        poangUt += int.Parse(Runda.RundaHal[halnr - 1].AntalPoang.ToString());
                    }
                    if (cc.Name.StartsWith("txtPuttarHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(12, 1));
                        cc.Text = ("N").Formatera(Runda.RundaHal[halnr - 1].AntalPuttar);
                        puttarUt += int.Parse(Runda.RundaHal[halnr - 1].AntalPuttar.ToString());
                    }
                    if (cc.Name.StartsWith("cbxFWHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(8, 1));
                        if (Runda.RundaHal[halnr - 1].FwTraff == "X")
                        {
                            ((System.Windows.Forms.CheckBox)cc).Checked = true;
                            fwUt++;
                        }
                    }
                    if (cc.Name.StartsWith("cbxGRHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(8, 1));
                        if (Runda.RundaHal[halnr - 1].GrTraff == "X")
                        {
                            ((System.Windows.Forms.CheckBox)cc).Checked = true;
                            grUt++;
                        }
                    }
                    if (cc.Name.StartsWith("txtPliktHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(11, 1));
                        cc.Text = ("D").Formatera(Runda.RundaHal[halnr - 1].AntalPlikt);
                        pliktUt += int.Parse(Runda.RundaHal[halnr - 1].AntalPlikt.ToString());
                    }
                }

                txtSummaFWUt.Text = ("N").Formatera(fwUt);
                txtSummaGRUt.Text = ("N").Formatera(grUt);
                txtSummaPliktUt.Text = ("N").Formatera(pliktUt);
                txtSummaPoangUt.Text = ("N").Formatera(poangUt);
                txtSummaPuttarUt.Text = ("N").Formatera(puttarUt);
                txtSummaSlagUt.Text = ("N").Formatera(slagUt);

                // och fortrsätt med hålen in
                foreach (System.Windows.Forms.Control cc in gbxIn.Controls)
                {
                    if (cc.Name.StartsWith("txtSlagHal"))
                    {
                        //då ska vi flytta lite till textboxen
                        //Hålnr hämtas från kontrollens namn
                        halnr = int.Parse(cc.Name.Substring(10, 2));
                        cc.Text = ("N").Formatera(Runda.RundaHal[halnr - 1].AntalSlag);
                        slagIn += int.Parse(Runda.RundaHal[halnr - 1].AntalSlag.ToString());

                        //Sätt blå färg om sämre än par, röd om bättre än par
                        cc.ForeColor = (Runda.RundaHal[halnr - 1].AntalSlag.SättFärg(Bana.BanaHal[halnr - 1].Par, true));

                        // och räkna antalet par, birdies etc
                        if (Runda.RundaHal[halnr - 1].AntalSlag >
                            Bana.BanaHal[halnr - 1].Par + 2)
                        {
                            antalTrippel++;
                        }
                        else if (Runda.RundaHal[halnr - 1].AntalSlag >
                            Bana.BanaHal[halnr - 1].Par + 1)
                        {
                            antalDubbel++;
                        }
                        else if (Runda.RundaHal[halnr - 1].AntalSlag >
                            Bana.BanaHal[halnr - 1].Par)
                        {
                            antalBogies++;
                        }
                        else if (Runda.RundaHal[halnr - 1].AntalSlag ==
                            Bana.BanaHal[halnr - 1].Par)
                        {
                            antalPar++;
                        }
                        else if (Runda.RundaHal[halnr - 1].AntalSlag <
                            Bana.BanaHal[halnr - 1].Par - 1)
                        {
                            antalEagles++;
                        }
                        else if (Runda.RundaHal[halnr - 1].AntalSlag <
                            Bana.BanaHal[halnr - 1].Par)
                        {
                            antalBirdies++;
                        }
                    }
                    if (cc.Name.StartsWith("txtPoangHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(11, 2));
                        cc.Text = ("N").Formatera(Runda.RundaHal[halnr - 1].AntalPoang);
                        poangIn += int.Parse(Runda.RundaHal[halnr - 1].AntalPoang.ToString());
                    }
                    if (cc.Name.StartsWith("txtPuttarHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(12, 2));
                        cc.Text = ("N").Formatera(Runda.RundaHal[halnr - 1].AntalPuttar);
                        puttarIn += int.Parse(Runda.RundaHal[halnr - 1].AntalPuttar.ToString());
                    }
                    if (cc.Name.StartsWith("cbxFWHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(8, 2));
                        if (Runda.RundaHal[halnr - 1].FwTraff == "X")
                        {
                            ((System.Windows.Forms.CheckBox)cc).Checked = true;
                            fwIn++;
                        }
                    }
                    if (cc.Name.StartsWith("cbxGRHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(8, 2));
                        if (Runda.RundaHal[halnr - 1].GrTraff == "X")
                        {
                            ((System.Windows.Forms.CheckBox)cc).Checked = true;
                            grIn++;
                        }
                    }
                    if (cc.Name.StartsWith("txtPliktHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(11, 2));
                        cc.Text = ("D").Formatera(Runda.RundaHal[halnr - 1].AntalPlikt);
                        pliktIn += int.Parse(Runda.RundaHal[halnr - 1].AntalPlikt.ToString());
                    }
                }

                txtSummaFWIn.Text = ("N").Formatera(fwIn);
                txtSummaGRIn.Text = ("N").Formatera(grIn);
                txtSummaPliktIn.Text = ("N").Formatera(pliktIn);
                txtSummaPoangIn.Text = ("N").Formatera(poangIn);
                txtSummaPuttarIn.Text = ("N").Formatera(puttarIn);
                txtSummaSlagIn.Text = ("N").Formatera(slagIn);

                // och summera till totalen
                txtSummaFW.Text = ("N").Formatera(fwUt + fwIn);
                txtSummaGR.Text = ("N").Formatera(grUt + grIn);
                txtSummaPlikt.Text = ("N").Formatera(pliktUt + pliktIn);
                if (poangUt + poangIn > 36)
                {
                    txtSummaPoang.ForeColor = Color.Red;
                }
                else if (poangUt + poangIn < 36)
                {
                    txtSummaPoang.ForeColor = Color.Blue;
                }
                txtSummaPoang.Text = ("N").Formatera(poangUt + poangIn);
                txtSummaPuttar.Text = ("N").Formatera(puttarUt + puttarIn);
                txtSummaSlag.Text = ("N").Formatera(slagUt + slagIn);
                txtResultat.Text = ("N").Formatera(slagUt + slagIn - Runda.ErhallnaSlag);

                // samt avsluta med Rondstatistiken
                txtAntalBirdies.Text = ("N").Formatera(antalBirdies);
                txtAntalBogies.Text = ("N").Formatera(antalBogies);
                txtAntalDubbel.Text = ("N").Formatera(antalDubbel);
                txtAntalEagles.Text = ("N").Formatera(antalEagles);
                txtAntalPar.Text = ("N").Formatera(antalPar);
                txtAntalTrippel.Text = ("N").Formatera(antalTrippel);
                txtAntalFWTraffar.Text = ("N").Formatera(fwUt + fwIn);
                txtAntalGRTraffar.Text = ("N").Formatera(grUt + grIn);
                txtAntalPuttar.Text = ("N").Formatera(puttarUt + puttarIn);
                txtProcentFWTraffar.Text = ("ND1").Formatera(((fwUt + fwIn) / 18) * 100);
                txtProcentGRTraffar.Text = ("ND1").Formatera(((grUt + grIn) / 18) * 100);
                txtSnittPuttar.Text = ("ND1").Formatera((puttarUt + puttarIn) / 18);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Räkna ut antalet erhållna slag
        /// </summary>
        private void RaknaUtErhallnaSlag()
        {
            Spelare aktuellSpelare;
            //Kolla först att spelare och bana är inläst
            if (Bana != null && Spelare != null)
            {
                // och att både spelare och bana är vald
                if (((ComboBoxPar)cboSpelare.SelectedItem).Identifier > 0 &&
                    ((ComboBoxPar)cboBana.SelectedItem).Identifier > 0)
                {
                    aktuellSpelare = (Spelare)((ComboBoxPar)cboSpelare.SelectedItem).Data;
                    if (rbnGul.Checked && aktuellSpelare.Kön.Equals("M"))
                    {
                        txtErhallnaSlag.Text = Slope.RäknaUtErhållnaSlag(Bana.CrHerrarGul, Bana.SlopeHerrarGul,
                            int.Parse(txtSummaPar.Text), aktuellSpelare.ExaktHcp,
                            ref Feltext).ToString();
                    }
                    if (rbnRod.Checked && aktuellSpelare.Kön.Equals("M"))
                    {
                        txtErhallnaSlag.Text = Slope.RäknaUtErhållnaSlag(Bana.CrHerrarRod, Bana.SlopeHerrarRod,
                            int.Parse(txtSummaPar.Text), aktuellSpelare.ExaktHcp,
                            ref Feltext).ToString();
                    }
                    if (rbnGul.Checked && aktuellSpelare.Kön.Equals("K"))
                    {
                        txtErhallnaSlag.Text = Slope.RäknaUtErhållnaSlag(Bana.CrDamerGul, Bana.SlopeDamerGul,
                            int.Parse(txtSummaPar.Text), aktuellSpelare.ExaktHcp,
                            ref Feltext).ToString();
                    }
                    if (rbnRod.Checked && aktuellSpelare.Kön.Equals("K"))
                    {
                        txtErhallnaSlag.Text = Slope.RäknaUtErhållnaSlag(Bana.CrDamerRod, Bana.SlopeDamerRod,
                            int.Parse(txtSummaPar.Text), aktuellSpelare.ExaktHcp,
                            ref Feltext).ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Gå igenom alla fält i bilden för Runda innan uppdatering
        /// </summary>
        /// <returns>True om OK annars false</returns>
        private bool AllaFältIRundaOK()
        {
            try
            {
                if (NyRunda)
                {
                    Runda.RundaNr = RundaNr;
                }

                //Alla fält från bilden flyttas till objektet
                Runda.Datum = dtpDatum.Value;

                if (cboSpelare.SelectedIndex != -1)
                {
                    Runda.SpelarID = ((ComboBoxPar)cboSpelare.SelectedItem).Identifier;
                }
                else
                {
                    Runda.SpelarID = 0;
                }

                if (cboMarkor.SelectedIndex != -1)
                {
                    Runda.Markor = ((ComboBoxPar)cboMarkor.SelectedItem).Identifier;
                }
                else
                {
                    Runda.Markor = 0;
                }

                if (cboBana.SelectedIndex != -1)
                {
                    Runda.BanaNr = ((ComboBoxPar)cboBana.SelectedItem).Identifier;
                }
                else
                {
                    Runda.BanaNr = 0;
                }

                if ((txtErhallnaSlag.Text).ÄrEnInt())
                {
                    Runda.ErhallnaSlag = int.Parse(txtErhallnaSlag.Text);
                }
                else
                {
                    VisaFelmeddelande("NOTNUMERIC");
                    txtErhallnaSlag.Focus();
                    return false;
                }

                if (((txtExaktHcp.Text).BytUtPunkt().ÄrEnIckeNegativDecimal()))
                {
                    Runda.ExaktHcp = decimal.Parse(txtExaktHcp.Text);
                }
                else
                {
                    VisaFelmeddelande("NOTNUMERIC");
                    txtExaktHcp.Focus();
                    return false;
                }

                if (cbxHcprond.Checked)
                {
                    Runda.Hcprond = "X";
                }
                else
                {
                    Runda.Hcprond = "";
                }

                if (cbxNiohalsrond.Checked)
                {
                    Runda.Niohalsrond = "X";
                }
                else
                {
                    Runda.Niohalsrond = "";
                }

                if (cbxSallskapsrond.Checked)
                {
                    Runda.Sallskapsrond = "X";
                }
                else
                {
                    Runda.Sallskapsrond = "";
                }

                if (cbxTavlingsrond.Checked)
                {
                    Runda.Tavlingsrond = "X";
                }
                else
                {
                    Runda.Tavlingsrond = "";
                }

                if (rbnBla.Checked)
                {
                    Runda.Tee = "B";
                }
                else if (rbnGul.Checked)
                {
                    Runda.Tee = "G";
                }
                else if (rbnRod.Checked)
                {
                    Runda.Tee = "R";
                }
                else if (rbnVit.Checked)
                {
                    Runda.Tee = "V";
                }
                else if (rbnSvart.Checked)
                {
                    Runda.Tee = "S";
                }

                //Runda.Notering = txtNotering.Text;

                if (txtPlacering.Text.Length > 0)
                {
                    if ((txtPlacering.Text).ÄrEnInt())
                    {
                        Runda.Placering = int.Parse(txtPlacering.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtPlacering.Focus();
                        return false;
                    }
                }
                else
                {
                    Runda.Placering = 0;
                }

                if (string.IsNullOrEmpty(Runda.Notering))
                {
                    VisaMeddelande("Notering_Saknas");
                    knappkontroller1.btnKnapp1.Enabled = false;
                    knappkontroller1.btnKnapp2.Enabled = true;
                    return false;
                }

                Runda.UppdatDatum = DateTime.Today;
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gå igenom alla fält i bilden för Bana innan uppdatering
        /// </summary>
        /// <returns>True om OK annars false</returns>
        private bool AllaFältIRundaHalOK()
        {
            int halnr;
            bool result = false;

            try
            {
                //Om ny Runda ska nya rader skapas för RundaHal. Den här kontrollen ligger först
                if (NyRunda)
                {
                    InitieraRundaHal();
                }
                //Börja med hålen ut
                foreach (System.Windows.Forms.Control cc in gbxUt.Controls)
                {
                    if (cc.Name.StartsWith("txtSlagHal"))
                    {
                        //då ska vi kolla textboxen och, om OK, flytta till objektet
                        //Hålnr hämtas från kontrollens namn
                        halnr = int.Parse(cc.Name.Substring(10, 1));
                        if (cc.Text.Trim().Length == 0)
                        {
                            VisaFelmeddelande("RNDHOLESLAGMISSING");
                            cc.Focus();
                            return result;
                        }
                        else
                        {
                            if ((cc.Text).ÄrEnInt())
                            {
                                Runda.RundaHal[halnr - 1].AntalSlag = int.Parse(cc.Text);
                                Runda.RundaHal[halnr - 1].AntalPoang =
                                    Slope.RäknaUtAntalPoäng(int.Parse(txtErhallnaSlag.Text),
                                    int.Parse(cc.Text),
                                    Bana.BanaHal[halnr - 1].Par,
                                    Bana.BanaHal[halnr - 1].Hcp,
                                    ref Feltext);
                            }
                            else
                            {
                                VisaFelmeddelande("NOTNUMERIC");
                                cc.Focus();
                                return result;
                            }
                        }
                    }
                    if (cc.Name.StartsWith("txtPuttarHal"))
                    {
                        //då ska vi kolla textboxen och, om OK, flytta till objektet
                        //Hålnr hämtas från kontrollens namn
                        halnr = int.Parse(cc.Name.Substring(12, 1));
                        if (cc.Text.Trim().Length == 0)
                        {
                            Runda.RundaHal[halnr - 1].AntalPuttar = 0;
                        }
                        else
                        {
                            if ((cc.Text).ÄrEnInt())
                            {
                                Runda.RundaHal[halnr - 1].AntalPuttar = int.Parse(cc.Text);
                            }
                            else
                            {
                                VisaFelmeddelande("NOTNUMERIC");
                                cc.Focus();
                                return result;
                            }
                        }
                    }
                    if (cc.Name.StartsWith("txtPliktHal"))
                    {
                        //då ska vi kolla textboxen och, om OK, flytta till objektet
                        //Hålnr hämtas från kontrollens namn
                        halnr = int.Parse(cc.Name.Substring(11, 1));
                        if (cc.Text.Trim().Length == 0)
                        {
                            Runda.RundaHal[halnr - 1].AntalPlikt = 0;
                        }
                        else
                        {
                            if ((cc.Text).ÄrEnInt())
                            {
                                Runda.RundaHal[halnr - 1].AntalPlikt = int.Parse(cc.Text);
                            }
                            else
                            {
                                VisaFelmeddelande("NOTNUMERIC");
                                cc.Focus();
                                return result;
                            }
                        }
                    }
                    if (cc.Name.StartsWith("cbxFWHal"))
                    {
                        //då ska vi kolla textboxen och, om OK, flytta till objektet
                        //Hålnr hämtas från kontrollens namn
                        halnr = int.Parse(cc.Name.Substring(8, 1));
                        if (((System.Windows.Forms.CheckBox)cc).Checked)
                        {
                            Runda.RundaHal[halnr - 1].FwTraff = "X";
                        }
                        else
                        {
                            Runda.RundaHal[halnr - 1].FwTraff = "";
                        }
                    }
                    if (cc.Name.StartsWith("cbxGRHal"))
                    {
                        //då ska vi kolla textboxen och, om OK, flytta till objektet
                        //Hålnr hämtas från kontrollens namn
                        halnr = int.Parse(cc.Name.Substring(8, 1));
                        if (((System.Windows.Forms.CheckBox)cc).Checked)
                        {
                            Runda.RundaHal[halnr - 1].GrTraff = "X";
                        }
                        else
                        {
                            Runda.RundaHal[halnr - 1].GrTraff = "";
                        }
                    }
                }

                // och fortsätt med hålen in
                foreach (System.Windows.Forms.Control cc in gbxIn.Controls)
                {
                    if (cc.Name.StartsWith("txtSlagHal"))
                    {
                        //då ska vi kolla textboxen och, om OK, flytta till objektet
                        //Hålnr hämtas från kontrollens namn
                        halnr = int.Parse(cc.Name.Substring(10, 2));
                        this.AntalSlagEjArtonbHal(halnr, cc);
                        if (cc.Text.Trim().Length == 0)
                        {
                            VisaFelmeddelande("RNDHOLESLAGMISSING");
                            cc.Focus();
                            return result;
                        }
                        else
                        {
                            if ((cc.Text).ÄrEnInt())
                            {
                                Runda.RundaHal[halnr - 1].AntalSlag = int.Parse(cc.Text);
                                Runda.RundaHal[halnr - 1].AntalPoang =
                                    Slope.RäknaUtAntalPoäng(int.Parse(txtErhallnaSlag.Text),
                                    int.Parse(cc.Text),
                                    Bana.BanaHal[halnr - 1].Par,
                                    Bana.BanaHal[halnr - 1].Hcp,
                                    ref Feltext);
                            }
                            else
                            {
                                VisaFelmeddelande("NOTNUMERIC");
                                cc.Focus();
                                return result;
                            }
                        }
                    }
                    if (cc.Name.StartsWith("txtPuttarHal"))
                    {
                        //då ska vi kolla textboxen och, om OK, flytta till objektet
                        //Hålnr hämtas från kontrollens namn
                        halnr = int.Parse(cc.Name.Substring(12, 2));
                        if (cc.Text.Trim().Length == 0)
                        {
                            Runda.RundaHal[halnr - 1].AntalPuttar = 0;
                        }
                        else
                        {
                            if ((cc.Text).ÄrEnInt())
                            {
                                Runda.RundaHal[halnr - 1].AntalPuttar = int.Parse(cc.Text);
                            }
                            else
                            {
                                VisaFelmeddelande("NOTNUMERIC");
                                cc.Focus();
                                return result;
                            }
                        }
                    }
                    if (cc.Name.StartsWith("txtPliktHal"))
                    {
                        //då ska vi kolla textboxen och, om OK, flytta till objektet
                        //Hålnr hämtas från kontrollens namn
                        halnr = int.Parse(cc.Name.Substring(11, 2));
                        if (cc.Text.Trim().Length == 0)
                        {
                            Runda.RundaHal[halnr - 1].AntalPlikt = 0;
                        }
                        else
                        {
                            if ((cc.Text).ÄrEnInt())
                            {
                                Runda.RundaHal[halnr - 1].AntalPlikt = int.Parse(cc.Text);
                            }
                            else
                            {
                                VisaFelmeddelande("NOTNUMERIC");
                                cc.Focus();
                                return result;
                            }
                        }
                    }
                    if (cc.Name.StartsWith("cbxFWHal"))
                    {
                        //då ska vi kolla textboxen och, om OK, flytta till objektet
                        //Hålnr hämtas från kontrollens namn
                        halnr = int.Parse(cc.Name.Substring(8, 2));
                        if (((System.Windows.Forms.CheckBox)cc).Checked)
                        {
                            Runda.RundaHal[halnr - 1].FwTraff = "X";
                        }
                        else
                        {
                            Runda.RundaHal[halnr - 1].FwTraff = "";
                        }
                    }
                    if (cc.Name.StartsWith("cbxGRHal"))
                    {
                        //då ska vi kolla textboxen och, om OK, flytta till objektet
                        //Hålnr hämtas från kontrollens namn
                        halnr = int.Parse(cc.Name.Substring(8, 2));
                        if (((System.Windows.Forms.CheckBox)cc).Checked)
                        {
                            Runda.RundaHal[halnr - 1].GrTraff = "X";
                        }
                        else
                        {
                            Runda.RundaHal[halnr - 1].GrTraff = "";
                        }
                    }
                }
                this.RaknaSummor();
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
                return false;
            }
            result = true;
            return result;
        }

        /// <summary>
        /// Fixa till antal slag för banaor ej arton hål. 11 poäng ska delas ut och slag ska vara
        /// enligt hcp. Sätter sista hålet med slag till +2, då blir det en med 1 poäng.
        /// </summary>
        private void AntalSlagEjArtonbHal(int halNr, System.Windows.Forms.Control cc)
        {
            bool niohal = false;
            bool tolvhal = false;
            bool artonhal = false;
            int halIndex = Bana.BanaHal[halNr - 1].Hcp;
            int erhallnaSlag = Runda.ErhallnaSlag;
            int par = Bana.BanaHal[halNr - 1].Par;

            switch (Bana.AntalHal)
            {
                case "9":
                    niohal = true;
                    break;
                case "12":
                    tolvhal = true;
                    break;
                case "18":
                    artonhal = true;
                    break;
            }

            if (artonhal)
            {
                //Gör ingenting
                return;
            }
            else if (niohal && halNr < 10)
            {
                //Samma här
                return;
            }
            else if (niohal && halNr > 9)
            {
                if (cc.GetType() == typeof(TextBox))
                {
                    TextBox textBox = cc as TextBox;
                    if (erhallnaSlag > 18)
                    {
                        par += 1;
                        erhallnaSlag -= 18;
                    }
                    if (halIndex == erhallnaSlag)
                    {
                        textBox.Text = (par + 1).ToString();
                    }
                    else if (halIndex < erhallnaSlag)
                    {
                        textBox.Text = (par + 1).ToString();
                    }
                    if (halIndex > erhallnaSlag)
                    {
                        textBox.Text = par.ToString();
                    }
                    if (halNr == 10)
                    {
                        int number = Convert.ToInt32(textBox.Text);
                        number += 1;
                        textBox.Text = number.ToString();
                    }
                }
            }
            //else if (tolvhal && halnr < 13)
            //{
            //    //cc.Text = ("D").Formatera(langd);
            //}
            else if (tolvhal && halNr > 12)
            {
                if (cc.GetType() == typeof(TextBox))
                {
                    TextBox textBox = cc as TextBox;
                    //Mer erhållna slag än 18, börja med att lägga till ett slag per hål som är kvar.
                    //Dra sedan 18 från antal erhållna slag.
                    if (erhallnaSlag > 18)
                    {
                        par += 1;
                        erhallnaSlag -= 18;
                    }
                    if (halIndex == erhallnaSlag)
                    {
                        textBox.Text = (par + 1).ToString();
                    }
                    else if (halIndex < erhallnaSlag)
                    {
                        textBox.Text = (par + 1).ToString();
                    }
                    if (halIndex > erhallnaSlag)
                    {
                        textBox.Text = par.ToString();
                    }
                    if (halNr == 13)
                    {
                        int number = Convert.ToInt32(textBox.Text);
                        number += 1;
                        textBox.Text = number.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Tabellen RundaHal initieras om ny Runda, kontrollerna på scorekortet kommer lite hur som helst
        /// varför det inte går (?) att lösa på ett smidigare sätt.
        /// </summary>
        private void InitieraRundaHal()
        {
            RundaHal rundaHal;
            try
            {
                for (int i = 0; i < 18; i++)
                {
                    rundaHal = new RundaHal();
                    rundaHal.RundaNr = Runda.RundaNr;
                    rundaHal.HalNr = i + 1;
                    rundaHal.AntalSlag = 0;
                    rundaHal.AntalPoang = 0;
                    rundaHal.AntalPuttar = 0;
                    rundaHal.AntalPlikt = 0;
                    rundaHal.FwTraff = "";
                    rundaHal.GrTraff = "";
                    Runda.AddRundaHal(rundaHal);
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Gå igenom alla fält i bilden för Redovisning innan uppdatering
        /// 
        /// Aktuella transtyper är:
        ///     
        ///     1   =   Bett
        ///     2   =   Bollar
        ///     4   =   Greenfee
        ///     12  =   Startavgift
        ///     
        /// </summary>
        /// <returns>True om OK annars false</returns>
        private bool AllaFältIRedovisningOK()
        {
            bool result = false;
            Redovisning redovisning;

            try
            {
                //Börja med att ta bort alla redovisningar som finns
                // och lägg upp de som finns i bilden
                Runda.TaBortRedovisning();

                //Finns Bett att redovisa?
                if (txtBett.Text.Trim().Length > 0)
                {
                    if ((txtBett.Text).ÄrEnDecimal())
                    {
                        redovisning = new Redovisning();
                        redovisning.Typ = "1";
                        redovisning.Datum = dtpDatum.Value;
                        redovisning.RundaNr = Runda.RundaNr;
                        if (cboSpelare.SelectedIndex != -1)
                        {
                            redovisning.SpelarID = ((ComboBoxPar)cboSpelare.SelectedItem).Identifier;
                        }
                        else
                        {
                            redovisning.SpelarID = 0;
                        }
                        redovisning.Belopp = decimal.Parse(txtBett.Text);
                        redovisning.Notering = "";
                        redovisning.UppdatDatum = dtpDatum.Value;
                        Runda.AddRedovisning(redovisning);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtBett.Focus();
                        return result;
                    }
                }

                //Finns Bollar att redovisa?
                if (txtBollar.Text.Trim().Length > 0)
                {
                    if ((txtBollar.Text).ÄrEnDecimal())
                    {
                        redovisning = new Redovisning();
                        redovisning.Typ = "2";
                        redovisning.Datum = dtpDatum.Value;
                        redovisning.RundaNr = RundaNr;
                        if (cboSpelare.SelectedIndex != -1)
                        {
                            redovisning.SpelarID = ((ComboBoxPar)cboSpelare.SelectedItem).Identifier;
                        }
                        else
                        {
                            redovisning.SpelarID = 0;
                        }
                        redovisning.Belopp = decimal.Parse(txtBollar.Text);
                        redovisning.Notering = "";
                        redovisning.UppdatDatum = dtpDatum.Value;
                        Runda.AddRedovisning(redovisning);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtBollar.Focus();
                        return result;
                    }
                }

                //Finns Greenfee att redovisa?
                if (txtGreenfee.Text.Trim().Length > 0)
                {
                    if ((txtGreenfee.Text).ÄrEnDecimal())
                    {
                        redovisning = new Redovisning();
                        redovisning.Typ = "4";
                        redovisning.Datum = dtpDatum.Value;
                        redovisning.RundaNr = RundaNr;
                        if (cboSpelare.SelectedIndex != -1)
                        {
                            redovisning.SpelarID = ((ComboBoxPar)cboSpelare.SelectedItem).Identifier;
                        }
                        else
                        {
                            redovisning.SpelarID = 0;
                        }
                        redovisning.Belopp = decimal.Parse(txtGreenfee.Text);
                        redovisning.Notering = "";
                        redovisning.UppdatDatum = dtpDatum.Value;
                        Runda.AddRedovisning(redovisning);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtGreenfee.Focus();
                        return result;
                    }
                }

                //Finns Startavgift att redovisa?
                if (txtStartavgift.Text.Trim().Length > 0)
                {
                    if ((txtStartavgift.Text).ÄrEnDecimal())
                    {
                        redovisning = new Redovisning();
                        redovisning.Typ = "12";
                        redovisning.Datum = dtpDatum.Value;
                        redovisning.RundaNr = RundaNr;
                        if (cboSpelare.SelectedIndex != -1)
                        {
                            redovisning.SpelarID = ((ComboBoxPar)cboSpelare.SelectedItem).Identifier;
                        }
                        else
                        {
                            redovisning.SpelarID = 0;
                        }
                        redovisning.Belopp = decimal.Parse(txtStartavgift.Text);
                        redovisning.Notering = "";
                        redovisning.UppdatDatum = dtpDatum.Value;
                        Runda.AddRedovisning(redovisning);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtStartavgift.Focus();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
                return false;
            }

            result = true;
            return result;
        }

        /// <summary>
        /// Sätt checkboxen GIR automatiskt
        /// </summary>
        /// <param name="kontroll">Aktuell kontroll</param>
        private void SattGIRCheckBox(string kontroll)
        {
            //först kolla vilket hål
            string halNr = kontroll.Substring(12, kontroll.Length - 12);
            int slag;
            int puttar;
            int par;
            int hcp;

            try
            {
                //Hämta nu antal slag och puttar på hålet
                TextBox txtSlagHal = Controls.Find("txtSlagHal" + halNr, true).FirstOrDefault() as TextBox;
                slag = string.IsNullOrEmpty(txtSlagHal.Text) ? 0 : Convert.ToInt32(txtSlagHal.Text);

                TextBox txtPuttarHal = Controls.Find("txtPuttarHal" + halNr, true).FirstOrDefault() as TextBox;
                puttar = string.IsNullOrEmpty(txtPuttarHal.Text) ? 0 : Convert.ToInt32(txtPuttarHal.Text);

                if (puttar == 0)
                {
                    return;
                }

                TextBox txtParHal = Controls.Find("txtParHal" + halNr, true).FirstOrDefault() as TextBox;
                par = string.IsNullOrEmpty(txtParHal.Text) ? 0 : Convert.ToInt32(txtParHal.Text);

                TextBox txtHcpHal = Controls.Find("txtHcpHal" + halNr, true).FirstOrDefault() as TextBox;
                hcp = string.IsNullOrEmpty(txtHcpHal.Text) ? 0 : Convert.ToInt32(txtHcpHal.Text);

                CheckBox cbxFWHal = Controls.Find("cbxFWHal" + halNr, true).FirstOrDefault() as CheckBox;
                cbxFWHal.Focus();

                CheckBox cbxGRHal = Controls.Find("cbxGRHal" + halNr, true).FirstOrDefault() as CheckBox;
                if (cbxGRHal == null)
                    return;
                else
                {
                    cbxGRHal.Checked = false;
                }

                //Om det ska kontrolleras mot hcp så måste "mitt" par först räknas ut
                if (AppUser.GIR == "H" & (slag != 0) & (puttar != 0))
                {
                    par = this.BerakningMittPar(Convert.ToInt32(txtErhallnaSlag.Text), hcp, par);
                }

                //Om slag minus puttar är lika med eller mindre än par minus två så har vi en GIR
                if ((slag - puttar) <= (par - 2))
                {
                    cbxGRHal.Checked = true;
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Sätt poäng på hålet automatiskt
        /// </summary>
        /// <param name="kontroll">Aktuell kontroll</param>
        private void SattPoangTextBox(string kontroll)
        {
            //först kolla vilket hål
            string halNr = kontroll.Substring(10, kontroll.Length - 10);
            int slag;
            int poang;
            int par;
            int hcp;

            try
            {
                //Hämta nu antal slag och puttar på hålet
                TextBox txtSlagHal = Controls.Find("txtSlagHal" + halNr, true).FirstOrDefault() as TextBox;
                slag = string.IsNullOrEmpty(txtSlagHal.Text) ? 0 : Convert.ToInt32(txtSlagHal.Text);

                TextBox txtParHal = Controls.Find("txtParHal" + halNr, true).FirstOrDefault() as TextBox;
                par = string.IsNullOrEmpty(txtParHal.Text) ? 0 : Convert.ToInt32(txtParHal.Text);

                TextBox txtHcpHal = Controls.Find("txtHcpHal" + halNr, true).FirstOrDefault() as TextBox;
                hcp = string.IsNullOrEmpty(txtHcpHal.Text) ? 0 : Convert.ToInt32(txtHcpHal.Text);

                TextBox txtPoangHal = Controls.Find("txtPoangHal" + halNr, true).FirstOrDefault() as TextBox;
                if (txtPoangHal == null)
                    return;
                else
                {
                    poang = Slope.RäknaUtAntalPoäng(int.Parse(txtErhallnaSlag.Text),
                        slag, par, hcp, ref Feltext);
                    txtPoangHal.Text = poang.ToString();
                }

                TextBox txtPuttarHal = Controls.Find("txtPuttarHal" + halNr, true).FirstOrDefault() as TextBox;
                this.RaknaSummor();
                txtPuttarHal.Focus();
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Beräkna "mitt" par för användare kontrollerat mot hålets hcp
        /// </summary>
        /// <param name="erhallnaSlag">Erhållna slag på banan</param>
        /// <param name="hcp">Hålets hcp</param>
        /// <param name="par">Hålets par</param>
        /// <returns>"Mitt" par</returns>
        private int BerakningMittPar(int erhallnaSlag, int hcp, int par)
        {
            if (erhallnaSlag > 36)
            {
                par = par + 2;
                if ((erhallnaSlag - 36) >= hcp)
                {
                    par = par + 1;
                }
            }
            else if (erhallnaSlag > 18)
            {
                par = par + 1;
                if ((erhallnaSlag - 18) >= hcp)
                {
                    par = par + 1;
                }
            }
            else if ((erhallnaSlag) >= hcp)
            {
                par = par + 1;
            }

            return par;
        }

        /// <summary>
        /// Räkna fram alla summor och totaler
        /// </summary>
        private void RaknaSummor()
        {
            int slag = 0;
            int poang = 0;
            int poangIn = 0;
            int poangUt = 0;
            int slagIn = 0;
            int slagUt = 0;
            int poangTot = 0;
            int slagTot = 0;

            for (int i = 1; i < 19; i++)
            {
                slag = 0;
                poang = 0;
                TextBox txtSlagHal = Controls.Find("txtSlagHal" + i, true).FirstOrDefault() as TextBox;
                slag = string.IsNullOrEmpty(txtSlagHal.Text) ? 0 : Convert.ToInt32(txtSlagHal.Text);
                TextBox txtPoangHal = Controls.Find("txtPoangHal" + i, true).FirstOrDefault() as TextBox;
                poang = string.IsNullOrEmpty(txtPoangHal.Text) ? 0 : Convert.ToInt32(txtPoangHal.Text);

                if (i > 9)
                {
                    slagIn = slagIn + slag;
                    poangIn = poangIn + poang;
                }
                else
                {
                    slagUt = slagUt + slag;
                    poangUt = poangUt + poang;
                }

                slagTot = slagTot + slag;
                poangTot = poangTot + poang;
            }
            txtSummaPoangUt.Text = ("N").Formatera(poangUt);
            txtSummaSlagUt.Text = ("N").Formatera(slagUt);
            txtSummaPoangIn.Text = ("N").Formatera(poangIn);
            txtSummaSlagIn.Text = ("N").Formatera(slagIn);
            txtSummaPoang.Text = ("N").Formatera(poangTot);
            txtSummaSlag.Text = ("N").Formatera(slagTot);
            Runda.SummaAntalPoang = poangTot;
            Runda.SummaAntalSlag = slagTot;
        }

        /// <summary>
        /// Den här ska inte användas efter att nya hcp-systemet tagits i bruk
        /// </summary>
        private void UppdateraHcp()
        {
            KoderAktivitet koderAktivitet = new KoderAktivitet();
            string svar;
            Koder buffertzon;
            Koder hcpAndring;
            int poangTotalt;
            bool isBetween;
            SpelareAktivitet spelareAktivitet;

            //Kolla först om spelarens Hcp ska uppdateras
            svar = VisaFråga("Varning_UPPDATERA_HCP");

            if (svar.Equals("Ja"))
            {
                //Räkna ut nytt Hcp
                //Först hämta hcp-grupp för spelaren
                buffertzon = koderAktivitet.HämtaKoder(20, Spelare.Klass);
                poangTotalt = Runda.SummaAntalPoang;

                //Kolla sen om uppdatering ska göras
                isBetween = poangTotalt.IsWithin(buffertzon.IntervallMin, buffertzon.IntervallMax);

                if (isBetween)
                    return;

                //Gör sedan höjning eller sänkning
                hcpAndring = koderAktivitet.HämtaKoder(21, Spelare.Klass);

                if (poangTotalt < buffertzon.IntervallMin)
                {
                    Spelare.ExaktHcp = Spelare.ExaktHcp + hcpAndring.IntervallMin;
                }

                if (poangTotalt > buffertzon.IntervallMax)
                {
                    Spelare.ExaktHcp = Spelare.ExaktHcp - ((poangTotalt - buffertzon.IntervallMax)
                        * hcpAndring.IntervallMax);
                }

                spelareAktivitet = new SpelareAktivitet();
                Spelare.Revisionsdatum = DateTime.Today;
                Spelare.UppdatDatum = DateTime.Today;
                spelareAktivitet.Spara(Spelare, false, ref FelID, ref Feltext);
            }
        }
        #endregion
    }
}
