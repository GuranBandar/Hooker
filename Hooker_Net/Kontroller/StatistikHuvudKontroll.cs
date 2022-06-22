using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using System;
using System.Collections.Generic;

namespace Hooker_GUI.Kontroller
{
    /// <summary>
    /// Userkontroll för sidhuvud till alla statistiker
    /// </summary>
    public partial class StatistikHuvudKontroll : KontrollBas
    {
        //Spelare spelare;
        private int _spelarID;
        private int _hemmabanaNr;
        private int _banaNr;
        private int _golfklubbNr;
        private string _redovisningstyp;
        private DateTime _fromDatum;
        private DateTime _tomDatum;
        private bool _detaljeradRedovisningVald;
        private bool _summeradRedovisningVald;
        private bool _hcpronderVald;
        private bool _niohalsronderVald;
        private bool _sallskapsronderVald;
        private bool _tavlingsronderVald;

        /// <summary>
        /// Lyssnare för val i Spelare-Combon
        /// </summary>
        public delegate void CboSpelareSelectEventHandler(object sender, EventArgs e);
        /// <summary>
        /// Händelsehanterare för val i Spelare-Combon
        /// </summary>
        public event CboSpelareSelectEventHandler OnCboSpelareSelect;
        /// <summary>
        /// Lyssnare för val i Golfklubb-Combon
        /// </summary>
        public delegate void CboGolfklubbSelectEventHandler(object sender, EventArgs e);
        /// <summary>
        /// Händelsehanterare för val i Golfklubb-Combon
        /// </summary>
        public event CboGolfklubbSelectEventHandler OnCboGolfklubbSelect;
        /// <summary>
        /// Lyssnare för val i Hemmbana-Combon
        /// </summary>
        public delegate void CboHemmabanaSelectEventHandler(object sender, EventArgs e);
        /// <summary>
        /// Händelsehanterare för val i Hemmabana-Combon
        /// </summary>
        public event CboHemmabanaSelectEventHandler OnCboHemmabanaSelect;
        /// <summary>
        /// Lyssnare för val i Redovisnings-Combon
        /// </summary>
        public delegate void DdnRedovisningsSelectEventHandler(object sender, EventArgs e);
        /// <summary>
        /// Händelsehanterare för val i Redovisnings-Combon
        /// </summary>
        public event DdnRedovisningsSelectEventHandler OnDdnRedovisningsSelect;
        /// <summary>
        /// Lyssnare för val i FromDatum
        /// </summary>
        public delegate void DtpFromDatumChangedEventHandler(object sender, EventArgs e);
        /// <summary>
        /// Händelsehanterare för val i FromDatum
        /// </summary>
        public event DtpFromDatumChangedEventHandler OnDtpFromDatumChanged;
        /// <summary>
        /// Lyssnare för val i TomDatum
        /// </summary>
        public delegate void DtpTomDatumChangedEventHandler(object sender, EventArgs e);
        /// <summary>
        /// Händelsehanterare för val i TomDatum
        /// </summary>
        public event DtpTomDatumChangedEventHandler OnDtpTomDatumChanged;

        /// <summary>
        /// Spelare
        /// </summary>
        public Spelare Spelare { get; set; }

        public Anvandare Anvandare { get; set; }
        /// <summary>
        /// SpelarID
        /// </summary>
        public int SpelarID { get { return _spelarID; } }

        /// <summary>
        /// GolfklubbNr
        /// </summary>
        public int GolfklubbNr { get { return _golfklubbNr; } }

        /// <summary>
        /// BanaNr
        /// </summary>
        public int BanaNr { get { return _banaNr; } }

        /// <summary>
        /// HemmabanaNr
        /// </summary>
        public int HemmabanaNr { get { return _hemmabanaNr; } }

        /// <summary>
        /// Redovisningstyp
        /// </summary>
        public string Redovisningstyp { get { return _redovisningstyp; } }

        /// <summary>
        /// From-datum
        /// </summary>
        public DateTime FromDatum { get { return _fromDatum; } }

        /// <summary>
        /// Tom-datum
        /// </summary>
        public DateTime TomDatum { get { return _tomDatum; } }

        /// <summary>
        /// Detaljerad redovisning vald
        /// </summary>
        public bool DetaljeradRedovisningVald { get { return _detaljeradRedovisningVald; } }

        /// <summary>
        /// Summerad redovisning vald
        /// </summary>
        public bool SummeradRedovisningVald { get { return _summeradRedovisningVald; } }

        /// <summary>
        /// Hcpronder vald
        /// </summary>
        public bool HcpronderVald { get { return _hcpronderVald; } }

        /// <summary>
        /// Niohålsronder vald
        /// </summary>
        public bool NiohalsronderVald { get { return _niohalsronderVald; } }

        /// <summary>
        /// Sällskapronder vald
        /// </summary>
        public bool SallskapsronderVald { get { return _sallskapsronderVald; } }

        /// <summary>
        /// Tävlingsronder vald
        /// </summary>
        public bool TavlingsronderVald { get { return _tavlingsronderVald; } }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public StatistikHuvudKontroll()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initerar sidhuvudkontrollen
        /// </summary>
        public void InitieraSidhuvud()
        {
            gbxRedovisningsinfo.Text = FormBas.Översätt("Text", gbxRedovisningsinfo.Text);
            gbxRondTyp.Text = FormBas.Översätt("Text", gbxRondTyp.Text);
            gbxSpelarinfo.Text = FormBas.Översätt("Text", gbxSpelarinfo.Text);
            lblGolfklubb.Text = FormBas.Översätt("Text", lblGolfklubb.Text);
            lblTyp.Text = FormBas.Översätt("Text", lblTyp.Text);
            lblFromDatum.Text = FormBas.Översätt("Text", lblFromDatum.Text);
            lblSpelare.Text = FormBas.Översätt("Text", lblSpelare.Text);
            lblTomDatum.Text = FormBas.Översätt("Text", lblTomDatum.Text);
            rbnDetaljerad.Text = FormBas.Översätt("Text", rbnDetaljerad.Text);
            rbnSummerad.Text = FormBas.Översätt("Text", rbnSummerad.Text);
            rbnSummerad.Checked = true;
            rbnHcprond.Text = FormBas.Översätt("Text", rbnHcprond.Text);
            rbnNiohålsrond.Text = FormBas.Översätt("Text", rbnNiohålsrond.Text);
            rbnSällskapsrond.Text = FormBas.Översätt("Text", rbnSällskapsrond.Text);
            rbnTävlingsrond.Text = FormBas.Översätt("Text", rbnTävlingsrond.Text);
            KontrollLaddas = true;

            //Hämta spelarinfo från inloggningen
            Anvandare = FormBas.GetAppUser();
            _spelarID = Anvandare.SpelarID;
            this.FyllSpelareCombo();

            _hemmabanaNr = Spelare.HemmabanaNr;
            _golfklubbNr = Spelare.GolfklubbNr;
            _banaNr = Spelare.HemmabanaNr;
            _redovisningstyp = "0";

            //Initiera med datum från årets början
            int dagnr = DateTime.Today.DayOfYear;
            _fromDatum = DateTime.Today.AddDays(1 - dagnr);
            int year = DateTime.Today.Year;
            if (DateTime.IsLeapYear(year))
            {
                _tomDatum = DateTime.Today.AddDays(366 - dagnr);
            }
            else
            {
                _tomDatum = DateTime.Today.AddDays(365 - dagnr);
            }

            this.FyllGolfklubbCombo();
            this.FyllBanorCombo();
            this.FyllRedovisningsTypDropDown();

            //Datum från årets början
            dtpFromDatum.Text = FromDatum.ToShortDateString();
            dtpTomDatum.Text = TomDatum.ToShortDateString();
            KontrollLaddas = false;
            _hemmabanaNr = 0;
        }

        /// <summary>
        /// Hämta alla Spelare och fyll combon.
        /// </summary>
        private void FyllSpelareCombo()
        {
            SpelareAktivitet spelareAktivitet = new SpelareAktivitet();

            try
            {
                List<Spelare> spelare = spelareAktivitet.SökSpelare("", "");

                if (spelare.Count > 0)
                {
                    cboSpelare.Items.Clear();
                    cboSpelare.Items.Add(new ComboBoxPar(0, "Alla spelare", ""));
                    for (int i = 0; i < spelare.Count; i++)
                    {
                        cboSpelare.Items.Add(new ComboBoxPar(spelare[i].AktuelltSpelarID,
                            spelare[i].Namn, spelare[i]));
                    }

                    cboSpelare.SelectedItem = SpelarID;
                    cboSpelare.DisplayMember = "visa";

                    //Hämta också aktuell spelare
                    Spelare = spelareAktivitet.HämtaSpelare(Anvandare.SpelarID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                    cboGolfklubb.Items.Add(new ComboBoxPar(0, "Alla klubbar", ""));
                    for (int i = 0; i <= golfklubbar.Count - 1; i++)
                    {
                        cboGolfklubb.Items.Add(new ComboBoxPar(golfklubbar[i].GolfklubbNr,
                            golfklubbar[i].GolfklubbNamn, golfklubbar[i]));
                    }

                    cboGolfklubb.SelectedItem = int.Parse(GolfklubbNr.ToString());
                    cboGolfklubb.DisplayMember = "visa";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Hämta alla banor och fyll combon. Aktuell hemmabana väljs i combon.
        /// </summary>
        private void FyllBanorCombo()
        {
            List<Bana> bana = null;
            BanaAktivitet banaAktivitet = new BanaAktivitet();

            try
            {
                if (GolfklubbNr != 0)
                {
                    bana = banaAktivitet.HämtaBanaMedGolfklubbNr(GolfklubbNr);

                    if (bana != null && bana.Count > 0)
                    {
                        cboHemmabana.Items.Clear();
                        cboHemmabana.Items.Add(new ComboBoxPar(0, "Alla banor", ""));
                        foreach (Bana banarad in bana)
                        {
                            cboHemmabana.Items.Add(new ComboBoxPar(int.Parse(banarad.BanaNr.ToString()),
                                banarad.BanaNamn.ToString(), banarad));
                        }

                        if (HemmabanaNr != 0)
                        {
                            cboHemmabana.SelectedItem = int.Parse(HemmabanaNr.ToString());
                        }
                        else
                        {
                            cboHemmabana.SelectedItem = int.Parse(bana[0].BanaNr.ToString());
                            _banaNr = int.Parse(bana[0].BanaNr.ToString());
                        }

                        cboHemmabana.DisplayMember = "visa";
                    }
                }
                else
                {
                    cboHemmabana.Items.Clear();
                    cboHemmabana.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Hämta alla redovisningstyper och fyller combon.
        /// </summary>
        private void FyllRedovisningsTypDropDown()
        {
            List<Koder> koder = null;
            Hooker.Affärslager.KoderAktivitet koderAktivitet = new Hooker.Affärslager.KoderAktivitet();

            try
            {
                //Typ = 10, alla redovisningstyper
                koder = koderAktivitet.SökKoder((int)Kodtabell.Redovisningstyper, "", "Varde");

                if (koder.Count > 0)
                {
                    ddnRedovisningstyper.Items.Clear();
                    ddnRedovisningstyper.Items.Add(new ComboBoxKod("0", "Alla typer", ""));

                    foreach (Koder kodrad in koder)
                    {
                        ddnRedovisningstyper.Items.Add(new ComboBoxKod(kodrad.Argument, kodrad.Varde.ToString(),
                            kodrad));
                    }

                    //Börja med att visa för alla typer
                    ddnRedovisningstyper.SelectedItem = "0";
                    ddnRedovisningstyper.DisplayMember = "visa";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Användaren har fipplat i combon för spelare, spar valt id i propertyn
        /// </summary>
        private void cboSpelare_SelectedIndexChanged(object sender, EventArgs e)
        {
            _spelarID = ((ComboBoxPar)cboSpelare.SelectedItem).Identifier;

            if (OnCboSpelareSelect != null)
            {
                OnCboSpelareSelect(this, null);
            }
        }

        private void ddnRedovisningstyper_SelectedIndexChanged(object sender, EventArgs e)
        {
            _redovisningstyp = ((ComboBoxKod)ddnRedovisningstyper.SelectedItem).Kod;

            if (OnDdnRedovisningsSelect != null)
            {
                OnDdnRedovisningsSelect(this, null);
            }
        }


        /// <summary>
        /// Användaren har fipplat i FromDatum-kontrollen
        /// </summary>
        private void dtpFromDatum_ValueChanged(object sender, EventArgs e)
        {
            _fromDatum = dtpFromDatum.Value;

            if (OnDtpFromDatumChanged != null)
            {
                OnDtpFromDatumChanged(this, null);
            }
        }

        /// <summary>
        /// Användaren har fipplat i TomDatum-kontrollen
        /// </summary>
        private void dtpTomDatum_ValueChanged(object sender, EventArgs e)
        {
            _tomDatum = dtpTomDatum.Value;

            if (OnDtpTomDatumChanged != null)
            {
                OnDtpTomDatumChanged(this, null);
            }
        }

        /// <summary>
        /// Användaren har fipplat i Tävlingsrond-kontrollen
        /// </summary>
        private void rbnTävlingsrond_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnTävlingsrond.Checked)
            {
                _tavlingsronderVald = true;
            }
            else
            {
                _tavlingsronderVald = false;
            }
        }

        /// <summary>
        /// Användaren har fipplat i Hcprond-kontrollen
        /// </summary>
        private void rbnHcprond_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnHcprond.Checked)
            {
                _hcpronderVald = true;
            }
            else
            {
                _hcpronderVald = false;
            }
        }

        /// <summary>
        /// Användaren har fipplat i Sällskapsrond-kontrollen
        /// </summary>
        private void rbnSällskapsrond_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnSällskapsrond.Checked)
            {
                _sallskapsronderVald = true;
            }
            else
            {
                _sallskapsronderVald = false;
            }
        }

        /// <summary>
        /// Användaren har fipplat i Niohålsrond-kontrollen
        /// </summary>
        private void rbnNiohålsrond_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnNiohålsrond.Checked)
            {
                _niohalsronderVald = true;
            }
            else
            {
                _niohalsronderVald = false;
            }
        }

        private void rbnDetaljerad_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnDetaljerad.Checked)
            {
                _detaljeradRedovisningVald = true;
            }
            else
            {
                _detaljeradRedovisningVald = false;
            }
        }

        private void rbnSummerad_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnSummerad.Checked)
            {
                _summeradRedovisningVald = true;
            }
            else
            {
                _summeradRedovisningVald = false;
            }
        }

        private void cboHemmabana_SelectedIndexChanged(object sender, EventArgs e)
        {
            _banaNr = ((ComboBoxPar)cboHemmabana.SelectedItem).Identifier;

            if (OnCboHemmabanaSelect != null)
            {
                OnCboHemmabanaSelect(this, null);
            }

        }

        private void cboGolfklubb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!KontrollLaddas)
            {
                _golfklubbNr = ((ComboBoxPar)cboGolfklubb.SelectedItem).Identifier;
                _banaNr = 0;

                if (OnCboGolfklubbSelect != null)
                {
                    OnCboGolfklubbSelect(this, null);
                }
                FyllBanorCombo();
            }
        }
    }
}
