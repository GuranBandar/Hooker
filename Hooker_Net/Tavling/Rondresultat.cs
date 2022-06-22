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
    /// Fönsterklass för hantering av Rondresultat
    /// </summary>
    public partial class Rondresultat : FormBas
    {
        #region Egenskapeer
        /// <summary>
        /// TavlingID
        /// </summary>
        public int TavlingID { get; set; }


        /// <summary>
        /// Klass
        /// </summary>
        public string Klass { get; set; }

        /// <summary>
        /// RondID
        /// </summary>
        public int RondID { get; set; }

        /// <summary>
        /// RondNr
        /// </summary>
        public int RondNr { get; set; }

        /// <summary>
        /// RondStatus
        /// </summary>
        public string RondStatus { get; set; }

        /// <summary>
        /// SpelarID
        /// </summary>
        public int SpelarID { get; set; }

        /// <summary>
        /// Tavlingobjektet
        /// </summary>
        public Tavling Tavling { get; set; }

        private TavlingRond TavlingRond { get; set; }

        private TavlingStartlista TavlingStartlista { get; set; }

        /// <summary>
        /// TavlingRondResultatobjektet
        /// </summary>
        public List<TavlingRondResultat> TavlingRondResultat { get; set; }

        /// <summary>
        /// Banaobjektet
        /// </summary>
        public Bana Bana { get; set; }

        public DateTime FromDatum { get; set; }

        public DateTime TomDatum { get; set; }

        public bool TavlingStartad { get; set; }
        #endregion

        /// <summary>
        /// Defaultkonstruktor
        /// </summary>
        public Rondresultat()
        {
            FormsLaddar = true;
            InitializeComponent();
            InitieraDatum();
        }

        /// <summary>
        /// Konstruktor med inparametrar
        /// </summary>
        public Rondresultat(int tavlingID, DateTime fromDatum, DateTime tomDatum)
        {
            FormsLaddar = true;
            InitializeComponent();
            TavlingID = tavlingID;
            FromDatum = fromDatum;
            TomDatum = tomDatum;
            InitieraDatum();
            VisaRondResultat();
        }

        #region "Publika metoder"
        /// <summary>
        /// Visa Rondresultatet
        /// </summary>
        public void VisaRondResultat()
        {
            Timglas.WaitCurson();
            FyllKlasserCombo();

            if (TavlingStartad)
            {
                FyllRonderCombo();
                FyllSpelareCombo();
                FyllRondResultat();
            }
            Timglas.DefaultCursor();
        }

        #endregion

        #region "Privata metoder"
        /// <summary>
        ///     Alla texter hämtas och knapparna initieras
        /// </summary>
        private void InitieraTexter()
        {
            this.Text = Översätt("Text", this.Text);

            foreach (System.Windows.Forms.Control cc in this.Controls)
            {
                if (cc.Controls.Count == 0)
                {
                    if (cc.Name.StartsWith("lbl") | cc.Name.StartsWith("gbx") | cc.Name.StartsWith("btn") |
                        cc.Name.StartsWith("rbn"))
                    {
                        cc.Text = Översätt("Text", cc.Text);
                    }
                }
                else
                {
                    if (cc.Name.StartsWith("gbx"))
                    {
                        cc.Text = Översätt("Text", cc.Text);
                    }
                    for (int i = 0; i < cc.Controls.Count; i++)
                    {
                        if (cc.Controls[i].Name.StartsWith("lbl"))
                        {
                            cc.Controls[i].Text = Översätt("Text", cc.Controls[i].Text);
                        }
                    }
                }
            }
            knappkontroller1.btnKnapp0.Visible = false;
            knappkontroller1.btnKnapp1.Text = Översätt("Text", "Knapp_VisaTävling");
            knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_Spara");
            knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_TaBort");
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
            knappkontroller1.btnKnapp2.Enabled = false;
        }

        private void InitieraDatum()
        {
            FyllTavlingCombo();
            cboTavling.Focus();
        }

        /// <summary>
        /// Hämta alla Tävlingar och fyll combon.
        /// </summary>
        private void FyllTavlingCombo()
        {
            TavlingAktivitet tavlingAktivitet = new TavlingAktivitet();
            List<Tavling> tavling = null;

            if (FromDatum.Equals(DateTime.MinValue))
            {
                FromDatum = Convert.ToDateTime(DateTime.Today.Year + "-01-01");
            }

            if (TomDatum.Equals(DateTime.MinValue))
            {
                TomDatum = Convert.ToDateTime(DateTime.Today.Year + "-12-31");
            }

            try
            {
                tavling = tavlingAktivitet.HämtaAllaStartadeEllerKlaraTavlingar(FromDatum, TomDatum);

                if (tavling != null)
                {
                    cboTavling.Items.Clear();

                    foreach (Tavling row in tavling)
                    {
                        cboTavling.Items.Add(new ComboBoxPar(row.TavlingID, row.Namn, row));
                    }

                    if (TavlingID != 0)
                    {
                        cboTavling.SelectedItem = TavlingID;
                        //VisaBanaValdTävling();
                    }
                    else
                    {
                        cboTavling.SelectedItem = tavling[0].TavlingID;
                    }

                    cboTavling.DisplayMember = "visa";
                }
                else
                {
                    VisaFelmeddelande("TVLSTARTMISSING");
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hämta vald Tävlings klasser och fyll combon.
        /// </summary>
        private void FyllKlasserCombo()
        {
            TavlingAktivitet tavlingAktivitet = new TavlingAktivitet();
            Tavling = null;

            try
            {
                Tavling = tavlingAktivitet.HämtaTavlingAllt(TavlingID);

                if (Tavling != null)
                {
                    TavlingStartad = Tavling.HarTavlingStartlista() ? true : false;

                    if (!TavlingStartad)
                    {
                        VisaFelmeddelande("TVLEJSTARTLISTA");
                        return;
                    }

                    if (Tavling.HarTavlingKlass())
                    {
                        cboKlass.Items.Clear();

                        foreach (TavlingKlass row in Tavling.TavlingKlass)
                        {
                            cboKlass.Items.Add(new ComboBoxKod(row.Klass, row.KlassNamn, row));
                        }

                        if (Klass != null)
                        {
                            cboKlass.SelectedItem = Klass;
                        }
                        else
                        {
                            cboKlass.SelectedItem = Tavling.TavlingKlass[0].Klass;
                        }
                        cboKlass.DisplayMember = "visa";
                    }
                }
                else
                {
                    VisaFelmeddelande("TVLPOSTERMISSING");
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hämta vald Tävlings bana och visa namn.
        /// </summary>
        private void VisaBanaValdTävling()
        {
            BanaAktivitet banaAktivitet = new BanaAktivitet();
            GolfklubbAktivitet golfklubbAktivitet = new GolfklubbAktivitet();
            Golfklubb golfklubb;

            try
            {
                TavlingRond tavlingRond = Tavling.TavlingRond.Single(p => p.RondNr == RondNr);
                Bana = banaAktivitet.HämtaBanaBanaHal(tavlingRond.BanaNr);
                txtDatum.Text = tavlingRond.Datum.ToShortDateString();

                if (Bana != null)
                {
                    golfklubb = golfklubbAktivitet.HämtaGolfklubb(Bana.GolfklubbNr);
                    txtGolfklubb.Text = golfklubb.GolfklubbNamn;
                    txtBana.Text = Bana.BanaNamn;
                }
                else
                {
                    VisaFelmeddelande("BANAMISSING");
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hämta vald Tävlingsklassronder och fyll combon.
        /// </summary>
        private void FyllRonderCombo()
        {
            try
            {
                if (Tavling.HarTavlingRond())
                {
                    cboRondnr.Items.Clear();
                    foreach (TavlingRond row in Tavling.TavlingRond)
                    {
                        cboRondnr.Items.Add(new ComboBoxPar(row.RondId, row.RondNr.ToString(), row));
                    }

                    if (RondID != 0)
                    {
                        cboRondnr.SelectedItem = RondID;
                    }
                    else
                    {
                        RondNr = Tavling.TavlingRond[0].RondNr;
                        RondID = Tavling.TavlingRond[0].RondId;
                    }
                    cboRondnr.DisplayMember = "visa";
                }
                else
                {
                    VisaFelmeddelande("TVLPOSTERMISSING");
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hämta spelare för vald Tävlingsrond och fyll alla combos med deltagare.
        /// </summary>
        private void FyllSpelareCombo()
        {
            SpelareAktivitet spelareAktivitet = new SpelareAktivitet();
            string spelarNamn;
            try
            {
                if (Tavling.HarTavlingStartlista())
                {
                    cboSpelare.Items.Clear();
                    cboNearest.Items.Clear();
                    cboLongest.Items.Clear();

                    foreach (TavlingStartlista tavlingStartlista in Tavling.TavlingStartlista)
                    {
                        if (tavlingStartlista.RondID == RondID)
                        {
                            spelarNamn = spelareAktivitet.HämtaSpelare(tavlingStartlista.SpelareID).Namn;
                            cboNearest.Items.Add(new ComboBoxPar(0, "Ingen", tavlingStartlista));
                            cboNearest.Items.Add(new ComboBoxPar(tavlingStartlista.SpelareID, spelarNamn, tavlingStartlista));
                            cboLongest.Items.Add(new ComboBoxPar(0, "Ingen", tavlingStartlista));
                            cboLongest.Items.Add(new ComboBoxPar(tavlingStartlista.SpelareID, spelarNamn, tavlingStartlista));
                            cboSpelare.Items.Add(new ComboBoxPar(tavlingStartlista.SpelareID, spelarNamn, tavlingStartlista));
                        }
                    }

                    if (SpelarID != 0)
                    {
                        cboSpelare.SelectedItem = SpelarID;
                    }
                    else
                    {
                        cboSpelare.SelectedItem = Tavling.TavlingDeltagare[0].SpelarID;
                    }

                    SättNearestOchLongest();
                    cboNearest.DisplayMember = "visa";
                    cboLongest.DisplayMember = "visa";
                    cboSpelare.DisplayMember = "visa";
                }
                else
                {
                    VisaFelmeddelande("TVLPOSTERMISSING");
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        private void SättNearestOchLongest()
        {
            if (Tavling.TavlingRond[RondNr - 1].SpelarIDNearest != 0)
            {
                cboNearest.SelectedItem = Tavling.TavlingRond[RondNr - 1].SpelarIDNearest;
            }
            else
            {
                cboNearest.SelectedIndex = 0;
                cboNearest.SelectedIndex = -1;
            }

            if (Tavling.TavlingRond[RondNr - 1].SpelarIDLongest != 0)
            {
                cboLongest.SelectedItem = Tavling.TavlingRond[RondNr - 1].SpelarIDLongest;
            }
            else
            {
                cboLongest.SelectedIndex = 0;
                cboLongest.SelectedIndex = -1;
            }
        }

        private void FyllRondResultat()
        {
            BanaAktivitet banaAktivitet = new BanaAktivitet();
            TavlingRondResultatAktivitet tavlingRondResultatAktivitet = new TavlingRondResultatAktivitet();
            int halnr;
            int parUt = 0;
            int parIn = 0;
            int slagUt = 0;
            int poangUt = 0;
            int slagIn = 0;
            int poangIn = 0;
            FormsUppdaterad = false;
            TavlingRond tavlingRond = new TavlingRond();

            try
            {
                if (Bana == null)
                {
                    return;
                }

                if (Tavling.HarTavlingRondResultat())
                {
                    Tavling.TaBortTavlingRondResultat();
                }

                TavlingRondResultat = tavlingRondResultatAktivitet.HämtaTavlingRondResultat(RondID, SpelarID);

                for (int i = 0; i < Tavling.TavlingRond.Length; i++)
                {
                    if (Tavling.TavlingRond[i].RondId == RondID)
                    {
                        tavlingRond = Tavling.TavlingRond[i];
                    }
                }

                SättNearestOchLongest();

                if (tavlingRond.ÄrPågående())
                {
                    cboNearest.Enabled = true;
                    cboNearest.BackColor = Color.White;
                    cboLongest.Enabled = true;
                    cboLongest.BackColor = Color.White;
                }
                else
                {
                    cboNearest.Enabled = false;
                    cboNearest.BackColor = Color.LightYellow;
                    cboLongest.Enabled = false;
                    cboLongest.BackColor = Color.LightYellow;
                }

                //Hämta par och index för hålen, börja med hålen ut
                foreach (System.Windows.Forms.Control cc in gbxUt.Controls)
                {
                    if (cc.Name.StartsWith("txtParHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(9, 1));
                        cc.Text = Bana.BanaHal[halnr - 1].Par.ToString();
                        parUt = parUt +
                            int.Parse(Bana.BanaHal[halnr - 1].Par.ToString());
                    }
                    if (cc.Name.StartsWith("txtHcpHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(9, 1));
                        cc.Text = Bana.BanaHal[halnr - 1].Hcp.ToString();
                    }
                }

                //och fortsätt sedan med hålen in
                foreach (System.Windows.Forms.Control cc in gbxIn.Controls)
                {
                    if (cc.Name.StartsWith("txtParHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(9, 2));
                        cc.Text = Bana.BanaHal[halnr - 1].Par.ToString();
                        parIn = parIn +
                            int.Parse(Bana.BanaHal[halnr - 1].Par.ToString());
                    }
                    if (cc.Name.StartsWith("txtHcpHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(9, 2));
                        cc.Text = Bana.BanaHal[halnr - 1].Hcp.ToString();
                    }
                }

                txtSummaParUt.Text = parUt.ToString();
                txtSummaParIn.Text = parIn.ToString();
                txtSummaPar.Text = (parUt + parIn).ToString();

                //Lägg sedan ut resultatet, börja med hålen ut
                foreach (System.Windows.Forms.Control cc in gbxUt.Controls)
                {
                    if (cc.Name.StartsWith("txtSlagHal"))
                    {
                        //då ska vi flytta lite till textboxen
                        //Hålnr hämtas från kontrollens namn
                        halnr = int.Parse(cc.Name.Substring(10, 1));
                        if (TavlingRondResultat != null)
                        {
                            cc.Text = ("D").Formatera(TavlingRondResultat[halnr - 1].AntalSlag);
                            slagUt = slagUt +
                                int.Parse(TavlingRondResultat[halnr - 1].AntalSlag.ToString());

                            //Sätt blå färg om sämre än par, röd om bättre än par
                            cc.ForeColor = (TavlingRondResultat[halnr - 1].AntalSlag.SättFärg(Bana.BanaHal[halnr - 1].Par, true));

                            if (tavlingRond.ÄrPågående())
                            {
                                cc.BackColor = Color.White;
                                cc.Enabled = true;
                            }
                            else
                            {
                                cc.BackColor = Color.LightYellow;
                                cc.Enabled = false;
                            }
                        }
                        else
                        {
                            cc.Text = ("D").Formatera(0);
                            cc.ForeColor = Color.Black;
                        }
                    }
                    if (cc.Name.StartsWith("txtPoangHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(11, 1));
                        if (TavlingRondResultat != null)
                        {
                            if (TavlingRondResultat[halnr - 1].AntalSlag > 0)
                            {
                                cc.Text = ("N").Formatera(TavlingRondResultat[halnr - 1].AntalPoang);
                            }
                            else
                            {
                                cc.Text = ("D").Formatera(TavlingRondResultat[halnr - 1].AntalPoang);
                            }
                            poangUt = poangUt +
                                int.Parse(TavlingRondResultat[halnr - 1].AntalPoang.ToString());
                        }
                        else
                        {
                            cc.Text = ("D").Formatera(0);
                        }
                    }
                }
                txtSummaPoangUt.Text = ("D").Formatera(poangUt);
                txtSummaSlagUt.Text = ("D").Formatera(slagUt);

                // och fortrsätt med hålen in
                foreach (System.Windows.Forms.Control cc in gbxIn.Controls)
                {
                    if (cc.Name.StartsWith("txtSlagHal"))
                    {
                        //då ska vi flytta lite till textboxen
                        //Hålnr hämtas från kontrollens namn
                        halnr = int.Parse(cc.Name.Substring(10, 2));
                        if (TavlingRondResultat != null)
                        {
                            cc.Text = ("D").Formatera(TavlingRondResultat[halnr - 1].AntalSlag);
                            slagIn = slagIn +
                                int.Parse(TavlingRondResultat[halnr - 1].AntalSlag.ToString());

                            //Sätt blå färg om sämre än par, röd om bättre än par
                            cc.ForeColor = (TavlingRondResultat[halnr - 1].AntalSlag.SättFärg(Bana.BanaHal[halnr - 1].Par, true));

                            if (tavlingRond.ÄrPågående())
                            {
                                cc.BackColor = Color.White;
                                cc.Enabled = true;
                            }
                            else
                            {
                                cc.BackColor = Color.LightYellow;
                                cc.Enabled = false;
                            }
                        }
                        else
                        {
                            cc.Text = ("D").Formatera(0);
                            cc.ForeColor = Color.Black;
                        }
                    }
                    if (cc.Name.StartsWith("txtPoangHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(11, 2));
                        if (TavlingRondResultat != null)
                        {
                            if (TavlingRondResultat[halnr - 1].AntalSlag > 0)
                            {
                                cc.Text = ("N").Formatera(TavlingRondResultat[halnr - 1].AntalPoang);
                            }
                            else
                            {
                                cc.Text = ("D").Formatera(TavlingRondResultat[halnr - 1].AntalPoang);
                            }
                            poangIn = poangIn +
                                int.Parse(TavlingRondResultat[halnr - 1].AntalPoang.ToString());
                        }
                        else
                        {
                            cc.Text = ("D").Formatera(0);
                        }
                    }

                    txtSummaPoangIn.Text = ("D").Formatera(poangIn);
                    txtSummaSlagIn.Text = ("D").Formatera(slagIn);
                    if (poangUt + poangIn > 36)
                    {
                        txtSummaPoang.ForeColor = Color.Red;
                    }
                    else if (poangUt + poangIn < 36)
                    {
                        txtSummaPoang.ForeColor = Color.Blue;
                    }
                    txtSummaPoang.Text = ("D").Formatera(poangUt + poangIn);
                    txtSummaSlag.Text = ("D").Formatera(slagUt + slagIn);
                }
                knappkontroller1.btnKnapp3.Enabled = true;
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
        /// Gå igenom alla fält i bilden för resultatet innan uppdatering
        /// </summary>
        /// <returns>True om OK annars false</returns>
        private bool AllaFältOK()
        {
            int halnr;
            bool result = false;

            try
            {
                Tavling.TavlingRond[RondNr - 1].RondStatus = ((ComboBoxKod)cboStatus.SelectedItem).Kod;
                if (cboNearest.SelectedIndex != -1)
                {
                    Tavling.TavlingRond[RondNr - 1].SpelarIDNearest = ((ComboBoxPar)cboNearest.SelectedItem).Identifier;
                }

                if (cboLongest.SelectedIndex != -1)
                {
                    Tavling.TavlingRond[RondNr - 1].SpelarIDLongest = ((ComboBoxPar)cboLongest.SelectedItem).Identifier;
                }

                if (!Tavling.HarSpelareTavlingRondResultat(RondID, SpelarID))
                {
                    InitieraTavlingRondResultat();
                }

                //Erhållna slag ska också sparas
                for (int i = 0; i < Tavling.TavlingStartlista.Length; i++)
                {
                    if (Tavling.TavlingStartlista[i].SpelareID == SpelarID)
                    {
                        Tavling.TavlingStartlista[i].ErhallnaSlag = int.Parse(txtErhallnaSlag.Text);
                    }
                }

                //Börja med hålen ut
                foreach (System.Windows.Forms.Control cc in gbxUt.Controls)
                {
                    if (cc.Name.StartsWith("txtSlagHal"))
                    {
                        //då ska vi kolla textboxen och, om OK, flytta till objektet
                        //Hålnr hämtas från kontrollens namn
                        halnr = int.Parse(cc.Name.Substring(10, 1));
                        if ((cc.Text).ÄrEnInt())
                        {
                            if (cc.Text != "0")
                            {
                                Tavling.TavlingRondResultat[halnr - 1].AntalSlag = int.Parse(cc.Text);
                                Tavling.TavlingRondResultat[halnr - 1].AntalPoang = RaknaUtAntalPoang(halnr);
                            }
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
                        if ((cc.Text).ÄrEnInt())
                        {
                            if (cc.Text != "0")
                            {
                                Tavling.TavlingRondResultat[halnr - 1].AntalSlag = int.Parse(cc.Text);
                                Tavling.TavlingRondResultat[halnr - 1].AntalPoang = RaknaUtAntalPoang(halnr);
                            }
                        }
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

        private void InitieraTavlingRondResultat()
        {
            TavlingRondResultat tavligRondResultat;
            for (int i = 0; i < 18; i++)
            {
                tavligRondResultat = new TavlingRondResultat();
                tavligRondResultat.RondId = RondID;
                tavligRondResultat.SpelarID = SpelarID;
                tavligRondResultat.HalNr = i + 1;
                tavligRondResultat.AntalSlag = 0;
                tavligRondResultat.AntalPoang = 0;
                Tavling.AddTavlingRondResultat(tavligRondResultat);
            }
        }

        /// <summary>
        /// Räkna ut antal poäng på hålet
        /// </summary>
        /// <param name="halnr">Aktuellt hål</param>
        /// <returns>Poängen</returns>
        private int RaknaUtAntalPoang(int halnr)
        {
            int antalPoang = 0;
            TextBox txtSlagHal = Controls.Find("txtSlagHal" + halnr, true).FirstOrDefault() as TextBox;

            if ((txtSlagHal.Text).ÄrEnInt())
            {
                antalPoang = Slope.RäknaUtAntalPoäng(int.Parse(txtErhallnaSlag.Text),
                    int.Parse(txtSlagHal.Text),
                    Bana.BanaHal[halnr - 1].Par,
                    Bana.BanaHal[halnr - 1].Hcp,
                    ref Feltext);
            }

            this.RaknaSummor();

            //Sätt focus på nästa inmatningsfält, inte om hålet är nr 18. Då är det nämligen slut
            if (halnr < 18)
            {
                halnr++;
                TextBox txtSlagHalNasta = Controls.Find("txtSlagHal" + halnr, true).FirstOrDefault() as TextBox;
                txtSlagHalNasta.Focus();
            }

            knappkontroller1.btnKnapp2.Enabled = true;
            knappkontroller1.btnKnapp3.Enabled = true;
            FormsUppdaterad = true;
            return antalPoang;
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
        }
        #endregion
    }
}
