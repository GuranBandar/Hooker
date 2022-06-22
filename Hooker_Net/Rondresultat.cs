using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Hooker_GUI.Kontroller;
using Hooker.Affärslager;
using Hooker.Gemensam;
using Hooker.Affärsobjekt;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönsterklass för hantering av Rondresultat
    /// </summary>
    public partial class Rondresultat : FormBas
    {
        #region "Medlemsvariabler"
        private int _tavlingID;
        private string _klass;
        private int _rondID;
        private int _rondNr;
        private int _spelarID;
        private Tavling _tavling;
        private TavlingRond _tavlingRond;
        private TavlingStartlista _tavlingStartlista;
        private List<TavlingRondResultat> _tavlingRondResultat;
        private Bana _bana;
        private string _rondStatus;
        #endregion

        #region Egenskapeer
        /// <summary>
        /// TavlingID
        /// </summary>
        public int TavlingID { get { return _tavlingID; } set { _tavlingID = value; } }

        /// <summary>
        /// Klass
        /// </summary>
        public string Klass { get { return _klass; } set { _klass = value; } }

        /// <summary>
        /// RondID
        /// </summary>
        public int RondID { get { return _rondID; } set { _rondID = value; } }
        
        /// <summary>
        /// RondNr
        /// </summary>
        public int RondNr { get { return _rondNr; } set { _rondNr = value; } }

        /// <summary>
        /// RondStatus
        /// </summary>
        public string RondStatus { get { return _rondStatus; } set { _rondStatus = value; } }
        
        /// <summary>
        /// SpelarID
        /// </summary>
        public int SpelarID { get { return _spelarID; } set { _spelarID = value; } }

        /// <summary>
        /// Tavlingobjektet
        /// </summary>
        public Tavling Tavling { get { return _tavling; } set { _tavling = value; } }

        private TavlingRond TavlingRond { get { return _tavlingRond; } set { _tavlingRond = value; } }

        private TavlingStartlista TavlingStartlista { get { return _tavlingStartlista; } set { _tavlingStartlista = value; } }

        /// <summary>
        /// TavlingRondResultatobjektet
        /// </summary>
        public List<TavlingRondResultat> TavlingRondResultat { get { return _tavlingRondResultat; } set { _tavlingRondResultat = value; } }

        /// <summary>
        /// Banaobjektet
        /// </summary>
        public Bana Bana { get { return _bana; } set { _bana = value; } }
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

        #region "Publika metoder"
        /// <summary>
        /// Visa Rondresultatet
        /// </summary>
        public void VisaRondResultat()
        {
            FyllKlasserCombo();
            FyllRonderCombo();
            FyllSpelareCombo();
            FyllRondResultat();
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
            //Datum från årets början
            //int dagnr = DateTime.Today.DayOfYear;
            //dtpFromDatum.Text = DateTime.Today.AddDays(1 - dagnr).ToShortDateString();
            //int year = DateTime.Today.Year;
            //if (DateTime.IsLeapYear(year))
            //{
            //    dtpTomDatum.Text = DateTime.Today.AddDays(366 - dagnr).ToShortDateString();
            //}
            //else
            //{
            //    dtpTomDatum.Text = DateTime.Today.AddDays(365 - dagnr).ToShortDateString();
            //}
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
            DateTime startDatum = Convert.ToDateTime(DateTime.Today.Year + "-01-01");
            DateTime sluttDatum = Convert.ToDateTime(DateTime.Today.Year + "-12-31");

            try
            {
                tavling = tavlingAktivitet.HämtaAllaTavlingar(startDatum, sluttDatum); 

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
                    VisaFelmeddelande("TVLPOSTERMISSING");
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
                    for (int i = 0; i < Tavling.TavlingRond.Length; i++)
                    {
                        cboRondnr.Items.Add(new ComboBoxPar(Tavling.TavlingRond[i].RondId,
                            Tavling.TavlingRond[i].RondNr.ToString(), Tavling.TavlingRond[i]));
                    }

                    if (RondNr == 0)
                    {
                        RondNr = Tavling.TavlingRond[0].RondNr;
                        RondID = Tavling.TavlingRond[0].RondId;
                    }
                    cboRondnr.SelectedItem = RondID;
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
                            cboNearest.Items.Add(new ComboBoxPar(tavlingStartlista.SpelareID, spelarNamn, tavlingStartlista));
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

                if (tavlingRond.ÄrStängd())
                {
                    cboNearest.Enabled = false;
                    cboNearest.BackColor = Color.LightYellow;
                    cboLongest.Enabled = false;
                    cboLongest.BackColor = Color.LightYellow;
                }
                else
                {
                    cboNearest.Enabled = true;
                    cboNearest.BackColor = Color.White;
                    cboLongest.Enabled = true;
                    cboLongest.BackColor = Color.White;
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
                            cc.ForeColor = (TavlingRondResultat[halnr - 1].AntalSlag.SättFärg(Bana.BanaHal[halnr - 1].Par));

                            if (tavlingRond.ÄrStängd())
                            {
                                cc.BackColor = Color.LightYellow;
                                cc.Enabled = false;
                            }
                            else
                            {
                                cc.BackColor = Color.White;
                                cc.Enabled = true;
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
                            cc.ForeColor = (TavlingRondResultat[halnr - 1].AntalSlag.SättFärg(Bana.BanaHal[halnr - 1].Par));

                            if (tavlingRond.ÄrStängd())
                            {
                                cc.BackColor = Color.LightYellow;
                                cc.Enabled = false;
                            }
                            else
                            {
                                cc.BackColor = Color.White;
                                cc.Enabled = true;
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
                    Tavling.TavlingRond[RondNr - 1].SpelarIDLongest= ((ComboBoxPar)cboLongest.SelectedItem).Identifier;
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

        private int RaknaUtAntalPoang(int halnr)
        {
            int antalPoang = 0;
            if (halnr < 10)
            {
                foreach (System.Windows.Forms.Control cc in gbxUt.Controls)
                {
                    if (cc.Name.StartsWith("txtSlagHal"))
                    {
                        //då ska vi kolla textboxen och, om OK, flytta till objektet
                        //Hålnr hämtas från kontrollens namn
                        if (int.Parse(cc.Name.Substring(10, 1)) == halnr)
                        {
                            if ((cc.Text).ÄrEnInt())
                            {
                                antalPoang = Slope.RäknaUtAntalPoäng(int.Parse(txtErhallnaSlag.Text),
                                    int.Parse(cc.Text),
                                    Bana.BanaHal[halnr - 1].Par,
                                    Bana.BanaHal[halnr - 1].Hcp,
                                    ref Feltext);
                            }
                        }
                    }
                }
                //kör en loop till för att sätta focus på nästa fält, dock inte om hålet är nr 9. Då är nämligen nästa hål inne i 
                //en annan konroll
                if (halnr < 9)
                {
                    foreach (System.Windows.Forms.Control cc in gbxUt.Controls)
                    {
                        if (cc.Name.StartsWith("txtSlagHal"))
                        {
                            //Hålnr hämtas från kontrollens namn
                            if (int.Parse(cc.Name.Substring(10, 1)) == halnr + 1)
                            {
                                cc.Focus();
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (System.Windows.Forms.Control cc in gbxIn.Controls)
                {
                    if (cc.Name.StartsWith("txtSlagHal"))
                    {
                        //då ska vi kolla textboxen och, om OK, flytta till objektet
                        //Hålnr hämtas från kontrollens namn
                        if (int.Parse(cc.Name.Substring(10, 2)) == halnr)
                        {
                            if ((cc.Text).ÄrEnInt())
                            {
                                antalPoang = Slope.RäknaUtAntalPoäng(int.Parse(txtErhallnaSlag.Text),
                                    int.Parse(cc.Text),
                                    Bana.BanaHal[halnr - 1].Par,
                                    Bana.BanaHal[halnr - 1].Hcp,
                                    ref Feltext);
                            }
                        }
                    }
                }
                //kör en loop till för att sätta focus på nästa fält, dock inte om hålet är nr 18. Då är det nämligen slut
                if (halnr < 18)
                {
                    foreach (System.Windows.Forms.Control cc in gbxIn.Controls)
                    {
                        if (cc.Name.StartsWith("txtSlagHal"))
                        {
                            //Hålnr hämtas från kontrollens namn
                            if (int.Parse(cc.Name.Substring(10, 2)) == halnr + 1)
                            {
                                cc.Focus();
                            }
                        }
                    }
                }
            }

            knappkontroller1.btnKnapp2.Enabled = true;
            knappkontroller1.btnKnapp3.Enabled = true;
            FormsUppdaterad = true;
            return antalPoang;
        }
        #endregion

        #region händelsehanterare
        private void Rondresultat_Load(object sender, EventArgs e)
        {
            this.InitieraTexter();
            this.MdiParent = MdiMain;
            FormsLaddar = false;
        }

        /// <summary>
        /// Hantera knappen för visa tävling
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void knappkontroller1_OnKnapp1Click(object sender, EventArgs e)
        {
            fönsterhanterare1.HanteraVisaTavling(TavlingID.ToString());
        }

        /// <summary>
        /// Hantera sparaknappen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            TavlingRondAktivitet tavlingRondAktivitet;
            TavlingRondResultatAktivitet tavlingRondResultatAktivitet;
            TavlingStartlistaAktivitet tavlingStartlistaAktivitet;

            try
            {
                if (AllaFältOK())
                {
                    tavlingRondAktivitet = new TavlingRondAktivitet();
                    tavlingRondAktivitet.Spara(Tavling.TavlingRond[RondNr - 1], ref FelID, ref Feltext);
                    tavlingStartlistaAktivitet = new TavlingStartlistaAktivitet();
                    tavlingStartlistaAktivitet.UppdateraStartlista(Tavling, ref FelID, ref Feltext);
                    tavlingRondResultatAktivitet = new TavlingRondResultatAktivitet();
                    tavlingRondResultatAktivitet.Spara(Tavling, RondID, SpelarID, ref FelID, ref Feltext);
                    VisaMeddelande("Information_OK");
                    FyllRondResultat();
                    knappkontroller1.btnKnapp2.Enabled = false;
                    FormsUppdaterad = false;
                    cboSpelare.Focus();
                }
            }
            catch (HookerException)
            {
                VisaFelmeddelande(FelID, Feltext);
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hanterar Ta bort-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            TavlingRondResultatAktivitet tavlingRondResultatAktivitet = new TavlingRondResultatAktivitet(); ;
            string svar;

            try
            {
                //Kolla först om rundan ska tas bort 
                svar = VisaFråga("Varning_TABORTRUNDA");

                if (svar.Equals("Ja"))
                {
                    tavlingRondResultatAktivitet.TaBort(RondID, SpelarID, ref FelID, ref Feltext);
                    VisaMeddelande("Information_OK");
                    //this.Close();
                }
            }
            catch (HookerException)
            {
                VisaFelmeddelande(FelID, Feltext);
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboSpelare_SelectedIndexChanged(object sender, EventArgs e)
        {
            TavlingStartlista aktuellSpelare;
            if (cboSpelare.SelectedIndex != -1)
            {
                SpelarID = ((ComboBoxPar)cboSpelare.SelectedItem).Identifier;
                aktuellSpelare = (TavlingStartlista)((ComboBoxPar)cboSpelare.SelectedItem).Data;
                txtExaktHcp.Text = aktuellSpelare.ExaktHcp.ToString();
                txtErhallnaSlag.Text = aktuellSpelare.ErhallnaSlag.ToString();
                FyllRondResultat();
                knappkontroller1.btnKnapp2.Enabled = false;
                FormsUppdaterad = false;
                txtSlagHal1.Focus();
            }
        }

        private void cboTavling_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTavling.SelectedIndex != -1)
            {
                if (Tavling != null)
                {
                    Tavling.TaBortTavlingRondResultat();
                    RondNr = 0;
                    RondID = 0;
                }

                TavlingID = ((ComboBoxPar)cboTavling.SelectedItem).Identifier;
                FyllKlasserCombo();
                VisaBanaValdTävling();
            }
        }

        private void cboKlass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKlass.SelectedIndex != -1)
            {
                Klass = ((ComboBoxKod)cboKlass.SelectedItem).Kod;
                FyllRonderCombo();
                FyllSpelareCombo();
            }
        }

        private void cboRondnr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRondnr.SelectedIndex != -1)
            {
                RondID = ((ComboBoxPar)cboRondnr.SelectedItem).Identifier;
                RondNr = int.Parse(((ComboBoxPar)cboRondnr.SelectedItem).Visa);
                TavlingRond = Tavling.HämtaTavlingRond(RondNr, TavlingID);
                //TavlingStartlista = Tavling.HämtaTavlingStartlista(RondID);
                //dtpFromDatum.Text = TavlingRond.Datum.ToString();
                //dtpTomDatum.Text = TavlingRond.Datum.ToString();
                FyllComboBoxKod(cboStatus, Kodtabell.Rondstatus, TavlingRond.RondStatus);
                RondStatus = TavlingRond.RondStatus;
                VisaBanaValdTävling();

                if (!FormsLaddar)
                {
                    FyllRondResultat();
                }
                knappkontroller1.btnKnapp2.Enabled = false;
                FormsUppdaterad = false;
                txtSlagHal1.Focus();
            }
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FormsLaddar)
            {
                knappkontroller1.btnKnapp2.Enabled = true;
            }
        }

        private void cboNearest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FormsLaddar)
            {
                knappkontroller1.btnKnapp2.Enabled = true;
            }
        }

        private void cboLongest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FormsLaddar)
            {
                knappkontroller1.btnKnapp2.Enabled = true;
            }
        }

        private void txtErhallnaSlag_TextChanged(object sender, EventArgs e)
        {
            if (!FormsLaddar)
            {
                knappkontroller1.btnKnapp2.Enabled = true;
            }
        }

        private void txtSlagHal1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSlagHal1.Text))
            {
                txtPoangHal1.Text = RaknaUtAntalPoang(1).ToString();
            }
        }

        private void txtSlagHal2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSlagHal2.Text))
            {
                txtPoangHal2.Text = RaknaUtAntalPoang(2).ToString();
            }
        }

        private void txtSlagHal3_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSlagHal3.Text))
            {
                txtPoangHal3.Text = RaknaUtAntalPoang(3).ToString();
            }
        }

        private void txtSlagHal4_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSlagHal4.Text))
            {
                txtPoangHal4.Text = RaknaUtAntalPoang(4).ToString();
            }
        }

        private void txtSlagHal5_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSlagHal5.Text))
            {
                txtPoangHal5.Text = RaknaUtAntalPoang(5).ToString();
            }
        }

        private void txtSlagHal6_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSlagHal6.Text))
            {
                txtPoangHal6.Text = RaknaUtAntalPoang(6).ToString();
            }
        }

        private void txtSlagHal7_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSlagHal7.Text))
            {
                txtPoangHal7.Text = RaknaUtAntalPoang(7).ToString();
            }
        }

        private void txtSlagHal8_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSlagHal8.Text))
            {
                txtPoangHal8.Text = RaknaUtAntalPoang(8).ToString();
            }
        }

        private void txtSlagHal9_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSlagHal9.Text))
            {
                txtPoangHal9.Text = RaknaUtAntalPoang(9).ToString();
            }
            txtSlagHal10.Focus();
        }

        private void txtSlagHal10_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSlagHal10.Text))
            {
                txtPoangHal10.Text = RaknaUtAntalPoang(10).ToString();
            }
        }

        private void txtSlagHal11_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSlagHal11.Text))
            {
                txtPoangHal11.Text = RaknaUtAntalPoang(11).ToString();
            }
        }

        private void txtSlagHal12_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSlagHal12.Text))
            {
                txtPoangHal12.Text = RaknaUtAntalPoang(12).ToString();
            }
        }

        private void txtSlagHal13_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSlagHal13.Text))
            {
                txtPoangHal13.Text = RaknaUtAntalPoang(13).ToString();
            }
        }

        private void txtSlagHal14_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSlagHal14.Text))
            {
                txtPoangHal14.Text = RaknaUtAntalPoang(14).ToString();
            }
        }

        private void txtSlagHal15_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSlagHal15.Text))
            {
                txtPoangHal15.Text = RaknaUtAntalPoang(15).ToString();
            }
        }

        private void txtSlagHal16_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSlagHal16.Text))
            {
                txtPoangHal16.Text = RaknaUtAntalPoang(16).ToString();
            }
        }

        private void txtSlagHal17_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSlagHal17.Text))
            {
                txtPoangHal17.Text = RaknaUtAntalPoang(17).ToString();
            }
        }

        private void txtSlagHal18_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSlagHal18.Text))
            {
                txtPoangHal18.Text = RaknaUtAntalPoang(18).ToString();
            }
            knappkontroller1.btnKnapp2.Focus();
        }
        #endregion
    }
}
