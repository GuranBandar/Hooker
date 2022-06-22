using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace Hooker_GUI
{
    /// <summary>
    ///     Fönsterklass för hantering av Spelare
    /// </summary>
    public partial class SpelareInfo : FormBas
    {
        #region Egenskapeer
        /// <summary>
        /// SpelarID
        /// </summary>
        public int SpelarID { get; set; }

        /// <summary>
        /// Objekt för Spelare
        /// </summary>
        public Spelare Spelare { get; set; }

        /// <summary>
        /// Objekt för Hcplista
        /// </summary>
        public List<Hcplista> Hcplista { get; set; }

        /// <summary>
        /// Ny Spelare
        /// </summary>
        public bool NySpelare { get; set; }
        #endregion

        /// <summary>
        ///     Konstruktor
        /// </summary>
        public SpelareInfo()
        {
            InitializeComponent();
        }

        #region "Publika metoder"
        /// <summary>
        ///     Hämta info i databasen och presentera
        /// </summary>
        public void VisaSpelare()
        {
            SpelareAktivitet spelareAktivitet = new SpelareAktivitet();
            try
            {
                Spelare = spelareAktivitet.HämtaSpelare(SpelarID);

                if (Spelare != null)
                {
                    FyllBild();
                    FyllGolfklubbCombo();
                    FyllBanorCombo();
                    VisaHcplista();
                    txtNamn.Focus();
                    knappkontroller1.btnKnapp1.Enabled = false;
                    knappkontroller1.btnKnapp2.Enabled = false;
                    FormsUppdaterad = false;
                }
                else
                {
                    //Kan vara borttagen
                    VisaFelmeddelande("SPELAREMISSING");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        ///     Ny spelare initieras
        /// </summary>
        public void InitieraNySpelare()
        {
            SpelareAktivitet spelareAktivitet = new SpelareAktivitet();

            try
            {
                //Spelarens nummer hämtas med en Max(SpelarID)
                SpelarID = spelareAktivitet.HämtaMaxSpelarID() + 1;
                FyllGolfklubbCombo();
                knappkontroller1.btnKnapp1.Enabled = false;
                knappkontroller1.btnKnapp2.Enabled = false;
                knappkontroller1.btnKnapp3.Enabled = false;
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }
        #endregion

        #region "Privata metoder"
        /// <summary>
        ///     Alla texter hämtas och knapparna initieras
        /// </summary>
        private void InitieraTexter()
        {
            this.Text = Översätt("Text", this.Text);
            gbxSpelarinfo.Text = Översätt("Text", gbxSpelarinfo.Text);
            gbxhandicap.Text = Översätt("Text", gbxhandicap.Text);
            gbxKon.Text = Översätt("Text", gbxKon.Text);
            lnkMinGolf.Text = Översätt("Text", lnkMinGolf.Text);

            foreach (System.Windows.Forms.Control cc in gbxSpelarinfo.Controls)
            {

                if (cc.Name.StartsWith("lbl"))
                {
                    //då ska vi flytta lite till textboxen

                    cc.Text = Översätt("Text", cc.Text);
                }
            }

            foreach (System.Windows.Forms.Control cc in gbxhandicap.Controls)
            {

                if (cc.Name.StartsWith("lbl"))
                {
                    //då ska vi flytta lite till textboxen

                    cc.Text = Översätt("Text", cc.Text);
                }
            }

            foreach (System.Windows.Forms.Control cc in gbxKon.Controls)
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
            knappkontroller1.btnKnapp0.Visible = false;
            knappkontroller1.btnKnapp1.Text = Översätt("Text", "Knapp_Spara_o_Stäng");
            knappkontroller1.btnKnapp1.Enabled = false;
            knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_Spara");
            knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_TaBort");
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
        }

        /// <summary>
        ///     Bilden fylls med Spelarens data från databasen
        /// </summary>
        private void FyllBild()
        {
            txtExaktHcp.Text = Spelare.ExaktHcp.ToString();
            decimal hcpResultat = 0;

            if (Spelare.GolfID != null && Spelare.GolfID != "")
            {
                txtGolfID.Text = Spelare.GolfID.Substring(0, 6);
                txtLopnr.Text = Spelare.GolfID.Substring(6, 3);
                EGAPrognos eGAPrognos = new EGAPrognos();
                eGAPrognos.SpelarID = SpelarID;
                hcpResultat = eGAPrognos.UtförHcpPrognos();
                string a = ("ND1").Formatera(hcpResultat / 8);
            }

            if (Spelare.FederationNo != 0)
            {
                txtFederationNo.Text = Spelare.FederationNo.ToString();
            }

            txtKlass.Text = Spelare.Klass.ToString();
            txtNamn.Text = Spelare.Namn.ToString();
            txtRevDatum.Text = Spelare.Revisionsdatum.ToShortDateString().ToString();

            txtSpelHcp.Text = ("D").Formatera(Spelare.ExaktHcp);

            switch (Spelare.Kön)
            {
                case "M":
                    rbnMan.Checked = true;
                    break;
                case "K":
                    rbnKvinna.Checked = true;
                    break;
            }
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
                //golfklubb = golfklubbAktivitet.HämtaGolfklubb("");
                golfklubb = golfklubbAktivitet.SökGolfklubb("", "", "", "");

                if (golfklubb.Count > 0)
                {
                    cboGolfklubb.Items.Clear();
                    cboGolfklubb.Items.Add(new ComboBoxPar(0, "", ""));
                    foreach (Golfklubb rad in golfklubb)
                    {
                        cboGolfklubb.Items.Add(new ComboBoxPar(int.Parse(rad.GolfklubbNr.ToString()),
                            rad.GolfklubbNamn.ToString(), rad));
                    }

                    if (!NySpelare)
                    {
                        cboGolfklubb.SelectedItem = Functions.ToInt(int.Parse(Spelare.GolfklubbNr.ToString()));
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
        /// Hämta alla banor och fyll combon. Aktuell hemmabana väljs i combon.
        /// </summary>
        private void FyllBanorCombo()
        {
            List<Bana> bana = null;
            BanaAktivitet banaAktivitet = new BanaAktivitet();

            try
            {
                if (Spelare.GolfklubbNr != 0)
                {

                    bana = banaAktivitet.HämtaBanaMedGolfklubbNr(Spelare.GolfklubbNr);

                    if (bana != null && bana.Count > 0)
                    {
                        cboHemmaBana.Items.Clear();
                        cboHemmaBana.Items.Add(new ComboBoxPar(0, "", ""));
                        foreach (Bana banarad in bana)
                        {
                            cboHemmaBana.Items.Add(new ComboBoxPar(int.Parse(banarad.BanaNr.ToString()),
                                banarad.BanaNamn.ToString(), banarad));
                        }

                        if (!NySpelare)
                        {
                            cboHemmaBana.SelectedItem = int.Parse(Spelare.HemmabanaNr.ToString());
                        }
                        cboHemmaBana.DisplayMember = "visa";
                    }
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Visa Hcplistan för de senaste 10 ändringarna
        /// </summary>
        private void VisaHcplista()
        {
            HcplistaAktivitet hcplistaAktivitet = new HcplistaAktivitet();
            Hcplista = hcplistaAktivitet.HämtaHcplista(SpelarID);

            if (Hcplista.Count > 1)
            {
                List<Hcplista> hcplista = Hcplista.OrderByDescending(h => h.Datum).
                    Take(12).ToList();
                hcplista = hcplista.OrderBy(h => h.Datum).ToList();
                Series ser = new Series();
                ser.ChartType = SeriesChartType.Line;
                ser.Points.AddXY(0, hcplista[0].NyttHcp);
                ser.MarkerStyle = MarkerStyle.Circle;
                ser.MarkerSize = 10;
                ser.MarkerColor = Color.LightSlateGray;
                ChartArea cha = chaHcplista.ChartAreas[0];
                cha.AxisY.Interval = 1;
                ser.Points[0].Tag = 0;
                ser.Points[0].ToolTip = hcplista[0].Datum.ToShortDateString() +
                        "/" + hcplista[0].NyttHcp;

                if (hcplista.Count > 12)
                {
                    var nLista = hcplista.LastN(12);
                    var maxvalue = nLista.Max(w => w.Hcp);
                    var minvalue = nLista.Min(w => w.Hcp);
                    cha.AxisY.Minimum = Convert.ToDouble(minvalue) - 1.5;
                    cha.AxisY.Maximum = Convert.ToDouble(maxvalue) + 1.5;
                }
                else
                {
                    cha.AxisY.Minimum = Convert.ToDouble(Spelare.ExaktHcp) - 1.5;
                    cha.AxisY.Maximum = Convert.ToDouble(Spelare.ExaktHcp) + 1.5;
                }

                chaHcplista.Series.Clear();
                for (int i = 1; i <= hcplista.Count - 1; i++)
                {
                    ser.Points.AddXY(i, hcplista[i].NyttHcp);

                    if (Hcplista[i].Typ == "M")
                    {
                        ser.Points[i].Tag = hcplista[i].Hcp + "/" 
                            + hcplista[i].Typ + "/" + hcplista[i].HcplistaID;
                    }
                    else
                    {
                        ser.Points[i].Tag = hcplista[i].RundaNr + "/" + 
                            hcplista[i].Typ + "/" + hcplista[i].HcplistaID;
                    }
                    ser.Points[i].ToolTip = hcplista[i].Datum.ToShortDateString() +
                        "/" +  hcplista[i].NyttHcp;
                }

                chaHcplista.Series.Add(ser);
            }
        }

        /// <summary>
        ///     Gå igenom alla fält i bilden för Spelare innan uppdatering
        /// </summary>
        /// <returns>True om OK annars false</returns>
        private bool AllaFältOK()
        {
            decimal hcp;
            try
            {
                if (NySpelare)
                {
                    Spelare = new Spelare(); ;
                    Spelare.AktuelltSpelarID = SpelarID;
                }
                else
                {
                    Spelare = Spelare;
                }

                //Alla fält från bilden flyttas till objektet
                Spelare.Namn = txtNamn.Text.ToString().Trim();

                if (cboGolfklubb.SelectedIndex != -1)
                {
                    Spelare.GolfklubbNr = ((ComboBoxPar)cboGolfklubb.SelectedItem).Identifier;
                }
                else
                {
                    Spelare.GolfklubbNr = 0;
                }

                if (cboHemmaBana.SelectedIndex != -1)
                {
                    Spelare.HemmabanaNr = ((ComboBoxPar)cboHemmaBana.SelectedItem).Identifier;
                }
                else
                {
                    Spelare.HemmabanaNr = 0;
                }

                if ((txtRevDatum.Text.Trim().ÄrEttOKDatum()))
                {
                    Spelare.Revisionsdatum = DateTime.Parse(txtRevDatum.Text);
                }
                else
                {
                    VisaFelmeddelande("DATWRONGFORM");
                    txtRevDatum.Focus();
                    return false;
                }

                if (txtGolfID.Text.Length != 0 && txtLopnr.Text.Length != 0)
                {
                    Spelare.GolfID = txtGolfID.Text + txtLopnr.Text;
                }
                else
                {
                    Spelare.GolfID = string.Empty;
                }

                if (txtFederationNo.Text.Length != 0)
                {
                    Spelare.FederationNo = Convert.ToInt32(txtFederationNo.Text);
                }
                else
                {
                    Spelare.FederationNo = 0;
                }

                if (rbnMan.Checked)
                {
                    Spelare.Kön = "M";
                }
                else if (rbnKvinna.Checked)
                {
                    Spelare.Kön = "K";
                }

                if (txtExaktHcp.Text.Trim().Length == 0)
                {
                    Spelare.ExaktHcp = 0;
                }
                else
                {
                    if (((txtExaktHcp.Text).BytUtPunkt().ÄrEnIckeNegativDecimal()))
                    {
                        hcp = Spelare.ExaktHcp;
                        Spelare.ExaktHcp = decimal.Parse((txtExaktHcp.Text).BytUtPunkt());
                        UppdateraHcplista(hcp);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtExaktHcp.Focus();
                        return false;
                    }
                }

                Spelare.Klass = Slope.SättKlass(decimal.Parse((txtExaktHcp.Text).BytUtPunkt()), ref FelID);
                Spelare.UppdatDatum = DateTime.Today.Date;
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Uppdatera i Hcplista
        /// </summary>
        private void UppdateraHcplista(decimal hcp)
        {
            HcplistaAktivitet hcplistaAktivitet = new HcplistaAktivitet();
            Hcplista hcplista = new Hcplista();
            hcplista.Typ = "M";
            hcplista.SpelarID = Spelare.AktuelltSpelarID;
            hcplista.RundaNr = 0;
            hcplista.Datum = Spelare.Revisionsdatum;
            hcplista.AntalSlag = 0;
            hcplista.AntalPoang = 0;
            hcplista.Hcp = hcp;
            hcplista.NyttHcp = Spelare.ExaktHcp;
            hcplista.PlusMinus = Spelare.ExaktHcp - hcp;
            //Ingen ändring, hoppa över uppdateringen
            if (hcplista.PlusMinus != 0)
            {
                hcplista.Notering = "Manuell uppdatering";
                hcplista.UppdatDatum = DateTime.Today;
                hcplistaAktivitet.Spara(hcplista, true, ref FelID, ref Feltext);
            }
        }
        #endregion
    }
}
