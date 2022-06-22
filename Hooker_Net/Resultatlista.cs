using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Fönsterklass för hantering av Resultatlista
    /// </summary>
    public partial class Resultatlista : FormBas
    {
        #region Medelemsvariabler
        private int _rondID;
        private int _rondNR;
        private string _klass;
        private Tavling _tavling;
        private int _par;
        private Bana _bana;
        BanaAktivitet banaAktivitet;
        GolfklubbAktivitet golfklubbAktivitet;
        #endregion

        #region Egenskaper
        /// <summary>
        /// Objekt för Tävling
        /// </summary>
        public Tavling Tavling { get { return _tavling; } set { _tavling = value; } }

        /// <summary>
        /// RondID
        /// </summary>
        private int RondID { get { return _rondID; } set { _rondID = value; } }

        /// <summary>
        /// RondNR
        /// </summary>
        private int RondNR { get { return _rondNR; } set { _rondNR = value; } }

        /// <summary>
        /// Klass
        /// </summary>
        private string Klass { get { return _klass; } set { _klass = value; } }

        /// <summary>
        /// Par
        /// </summary>
        private int Par { get { return _par; } set { _par = value; } }

        /// <summary>
        /// Banaobjektet
        /// </summary>
        public Bana Bana { get { return _bana; } set { _bana = value; } }

        /// <summary>
        /// Golfklubb
        /// </summary>
        public Golfklubb Golfklubb { get; set; }
        #endregion

        /// <summary>
        /// Defaultkonstruktor
        /// </summary>
        public Resultatlista()
        {
            InitializeComponent();
        }

        #region Publika metoder
        /// <summary>
        /// Visar resultatlistan
        /// </summary>
        public void VisaResultatlista()
        {
            KoderAktivitet koderAktivitet = new KoderAktivitet();
            banaAktivitet = new BanaAktivitet();
            golfklubbAktivitet = new GolfklubbAktivitet();
            dtpStartdatum.Text = ("STD").Formatera(DateTime.Parse(Tavling.StartDatum.ToShortDateString()));
            txtTavlingNamn.Text = Tavling.Namn;
            Koder koder = koderAktivitet.HämtaKoder((Kodtabell.Tävlingsstatus).EnumToInt(), Tavling.TavlingStatus);
            txtTavlingStatus.Text = koder.Varde;
            FyllKlassRondCombo();
            HämtaGolfklubbOchBana();
        }
        #endregion

        #region Privata metoder
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
                    if (cc.Name.StartsWith("lbl") | cc.Name.StartsWith("gbx") | cc.Name.StartsWith("btn"))
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

            for (int i = 0; i < dgwResultatlista4.Columns.Count; i++)
            {
                dgwResultatlista4.Columns[i].HeaderText = Översätt("Text", dgwResultatlista4.Columns[i].HeaderText);
            }

            for (int i = 0; i < dgwResultatlista6.Columns.Count; i++)
            {
                dgwResultatlista6.Columns[i].HeaderText = Översätt("Text", dgwResultatlista6.Columns[i].HeaderText);
            }

            knappkontroller1.btnKnapp0.Visible = false;
            knappkontroller1.btnKnapp1.Visible = false;
            knappkontroller1.btnKnapp2.Visible = false;
            knappkontroller1.btnKnapp3.Visible = false;
            knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_RondResultat");
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
        }

        private void FyllKlassRondCombo()
        {
            KoderAktivitet koderAktivitet = new KoderAktivitet();
            Koder koder = null;

            if (Tavling.HarTavlingRondResultat())
            {
                cboKlassRond.Items.Clear();

                for (int i = 0; i < Tavling.TavlingRond.Length; i++)
                {
                    koder = koderAktivitet.HämtaKoder((Kodtabell.Tävlingsklasser).EnumToInt(), Tavling.TavlingRond[i].Klass);
                    cboKlassRond.Items.Add(new ComboBoxPar(Tavling.TavlingRond[i].RondId, koder.Varde + " - " + 
                        Tavling.TavlingRond[i].RondNr, Tavling.TavlingRond[i]));
                }

                cboKlassRond.SelectedItem = Tavling.TavlingRond[0].RondId;
                cboKlassRond.DisplayMember = "visa";
            }
        }

        private void HämtaGolfklubbOchBana()
        {
            TavlingRond tavlingRond = Tavling.TavlingRond.Single(p => p.RondNr == RondNR);
            Bana = banaAktivitet.HämtaBana(tavlingRond.BanaNr);

            if (Bana != null)
            {
                Golfklubb = golfklubbAktivitet.HämtaGolfklubb(Bana.GolfklubbNr);
                txtGolfklubb.Text = Golfklubb.GolfklubbNamn;
                txtBana.Text = Bana.BanaNamn;
                RäknaFramBanansPar(Bana.BanaNr);
            }
        }

        private void FyllListan()
        {
            TavlingRondResultatAktivitet tavlingRondResultatAktivitet = new TavlingRondResultatAktivitet();

            if (Tavling.HarTavlingResultatLista())
            {
                Tavling.TaBortTavlingResultatLista();
            }

            HämtaGolfklubbOchBana();
            tavlingRondResultatAktivitet.HämtaResultatlista(Tavling, Klass, RondNR);

            List<TavlingResultatLista> tavlingResultatlista = 
                (from items in Tavling.TavlingResultatLista
                     where items.RondNr == RondNR
                     select items).ToList();

            if (Tavling.TavlingRond.Length < 5)
            {
                dgwResultatlista4.Visible = true;
                dgwResultatlista4.BringToFront();
                dgwResultatlista6.SendToBack();
            }
            else
            {
                dgwResultatlista6.Visible = true;
                dgwResultatlista4.SendToBack();
                dgwResultatlista6.BringToFront();
            }

            //if (Tavling.HarTavlingResultatListaRond(RondNR) && 
            //    tavlingResultatlista[0].RondResultatTot > 0)
            if (Tavling.HarTavlingResultatListaRond(RondNR))
            {
                if (Tavling.TavlingRond.Length < 5)
                {
                    int placering = 0;
                    int i = 0;
                    int rondresultat = 0;
                    dgwResultatlista4.Rows.Clear();

                    foreach (TavlingResultatLista resultatlista in Tavling.TavlingResultatLista)
                    {
                        if (resultatlista.RondNr == RondNR)
                        {
                            dgwResultatlista4.Rows.Add();
                            dgwResultatlista4.Rows[i].Cells["AktuelltRondID"].Value = resultatlista.RondID;
                            dgwResultatlista4.Rows[i].Cells["AktuellKlass"].Value = resultatlista.Klass;
                            dgwResultatlista4.Rows[i].Cells["SpelarID"].Value = resultatlista.SpelarID;

                            //Placeringssiffran räknas upp om rondresulatet skilljer sig
                            if (resultatlista.TotalResultat == rondresultat)
                            {
                                dgwResultatlista4.Rows[i].Cells["Placering"].Value = placering;
                            }
                            else
                            {
                                dgwResultatlista4.Rows[i].Cells["Placering"].Value = i + 1;
                                placering = i + 1;
                            }

                            dgwResultatlista4.Rows[i].Cells["Totalt"].Value = RäknaFramTotal(resultatlista.TotalResultat,
                                resultatlista.RondNr);
                            dgwResultatlista4.Rows[i].Cells["Totalt"].Style.ForeColor = HämtaFärg(resultatlista.TotalResultat,
                                resultatlista.RondNr);
                            dgwResultatlista4.Rows[i].Cells["Spelarnamn"].Value = resultatlista.Spelarnamn;
                            dgwResultatlista4.Rows[i].Cells["Hemmaklubb"].Value = resultatlista.Hemmaklubb;
                            dgwResultatlista4.Rows[i].Cells["SpelHcp"].Value = resultatlista.SpelHcp;
                            dgwResultatlista4.Rows[i].Cells["Summa"].Value = resultatlista.TotalResultat;
                            dgwResultatlista4.Rows[i].Cells["Summa"].Style.ForeColor = HämtaFärg(resultatlista.TotalResultat,
                                resultatlista.RondNr);
                            rondresultat = resultatlista.TotalResultat;
                            i++;
                        }
                    }

                    i = 0;
                    foreach (TavlingResultatLista tavlingrondresultat in Tavling.TavlingResultatLista)
                    {
                        if (tavlingrondresultat.SpelarID != (int)dgwResultatlista4.Rows[i].Cells["SpelarID"].Value)
                        {
                            i++;
                        }
                        switch (tavlingrondresultat.RondNr)
                        {
                            case 1:
                                dgwResultatlista4.Rows[i].Cells["R1"].Value = tavlingrondresultat.RondResultatTot;
                                dgwResultatlista4.Rows[i].Cells["R1"].Style.ForeColor = HämtaFärg(tavlingrondresultat.RondResultatTot);
                                break;
                            case 2:
                                dgwResultatlista4.Rows[i].Cells["R2"].Value = tavlingrondresultat.RondResultatTot;
                                dgwResultatlista4.Rows[i].Cells["R2"].Style.ForeColor = HämtaFärg(tavlingrondresultat.RondResultatTot);
                                break;
                            case 3:
                                dgwResultatlista4.Rows[i].Cells["R3"].Value = tavlingrondresultat.RondResultatTot;
                                dgwResultatlista4.Rows[i].Cells["R3"].Style.ForeColor = HämtaFärg(tavlingrondresultat.RondResultatTot);
                                break;
                            case 4:
                                dgwResultatlista4.Rows[i].Cells["R4"].Value = tavlingrondresultat.RondResultatTot;
                                dgwResultatlista4.Rows[i].Cells["R4"].Style.ForeColor = HämtaFärg(tavlingrondresultat.RondResultatTot);
                                break;
                        }
                    }
                }
                else
                {
                    int placering = 0;
                    int i = 0;
                    int rondresultat = 0;
                    dgwResultatlista6.Rows.Clear();

                    foreach (TavlingResultatLista resultatlista in Tavling.TavlingResultatLista)
                    {
                        if (resultatlista.RondNr == RondNR)
                        {
                            dgwResultatlista6.Rows.Add();
                            dgwResultatlista6.Rows[i].Cells["AktuelltRondID_6"].Value = resultatlista.RondID;
                            dgwResultatlista6.Rows[i].Cells["AktuellKlass_6"].Value = resultatlista.Klass;
                            dgwResultatlista6.Rows[i].Cells["SpelarID_6"].Value = resultatlista.SpelarID;

                            //Placeringssiffran räknas upp om rondresulatet skilljer sig
                            if (resultatlista.TotalResultat == rondresultat)
                            {
                                dgwResultatlista6.Rows[i].Cells["Placering_6"].Value = placering;
                            }
                            else
                            {
                                dgwResultatlista6.Rows[i].Cells["Placering_6"].Value = i + 1;
                                placering = i + 1;
                            }

                            dgwResultatlista6.Rows[i].Cells["Totalt_6"].Value = RäknaFramTotal(resultatlista.TotalResultat,
                                resultatlista.RondNr);
                            dgwResultatlista6.Rows[i].Cells["Totalt_6"].Style.ForeColor = HämtaFärg(resultatlista.TotalResultat,
                                resultatlista.RondNr);
                            dgwResultatlista6.Rows[i].Cells["Spelarnamn_6"].Value = resultatlista.Spelarnamn;
                            dgwResultatlista6.Rows[i].Cells["Hemmaklubb_6"].Value = resultatlista.Hemmaklubb;
                            dgwResultatlista6.Rows[i].Cells["SpelHcp_6"].Value = resultatlista.SpelHcp;
                            dgwResultatlista6.Rows[i].Cells["Summa_6"].Value = resultatlista.TotalResultat;
                            dgwResultatlista6.Rows[i].Cells["Summa_6"].Style.ForeColor = HämtaFärg(resultatlista.TotalResultat,
                                resultatlista.RondNr);
                            rondresultat = resultatlista.TotalResultat;
                            i++;
                        }
                    }

                    i = 0;
                    foreach (TavlingResultatLista tavlingrondresultat in Tavling.TavlingResultatLista)
                    {
                        if (tavlingrondresultat.SpelarID != (int)dgwResultatlista6.Rows[i].Cells["SpelarID_6"].Value)
                        {
                            i++;
                        }
                        switch (tavlingrondresultat.RondNr)
                        {
                            case 1:
                                dgwResultatlista6.Rows[i].Cells["R1_6"].Value = tavlingrondresultat.RondResultatTot;
                                dgwResultatlista6.Rows[i].Cells["R1_6"].Style.ForeColor = HämtaFärg(tavlingrondresultat.RondResultatTot);
                                break;
                            case 2:
                                dgwResultatlista6.Rows[i].Cells["R2_6"].Value = tavlingrondresultat.RondResultatTot;
                                dgwResultatlista6.Rows[i].Cells["R2_6"].Style.ForeColor = HämtaFärg(tavlingrondresultat.RondResultatTot);
                                break;
                            case 3:
                                dgwResultatlista6.Rows[i].Cells["R3_6"].Value = tavlingrondresultat.RondResultatTot;
                                dgwResultatlista6.Rows[i].Cells["R3_6"].Style.ForeColor = HämtaFärg(tavlingrondresultat.RondResultatTot);
                                break;
                            case 4:
                                dgwResultatlista6.Rows[i].Cells["R4_6"].Value = tavlingrondresultat.RondResultatTot;
                                dgwResultatlista6.Rows[i].Cells["R4_6"].Style.ForeColor = HämtaFärg(tavlingrondresultat.RondResultatTot);
                                break;
                            case 5:
                                dgwResultatlista6.Rows[i].Cells["R5_6"].Value = tavlingrondresultat.RondResultatTot;
                                dgwResultatlista6.Rows[i].Cells["R5_6"].Style.ForeColor = HämtaFärg(tavlingrondresultat.RondResultatTot);
                                break;
                            case 6:
                                dgwResultatlista6.Rows[i].Cells["R6_6"].Value = tavlingrondresultat.RondResultatTot;
                                dgwResultatlista6.Rows[i].Cells["R6_6"].Style.ForeColor = HämtaFärg(tavlingrondresultat.RondResultatTot);
                                break;
                        }
                    }
                }
            }
            else
            {
                lblResultatlistext.Text = "Resultatlista för rond " + RondNR + " saknas.";
                lblResultatlistext.Visible = true;
            }
        }

        private void RäknaFramBanansPar(int banaNr)
        {
            foreach (BanaHal banaHal in Bana.BanaHal)
            {
                Par += banaHal.Par;
            }
        }

        private int RäknaFramTotal(int resultat, int rondNr)
        {
            if (ÄrSpelformSlag())
            {
                return resultat - (Par * rondNr);
            }
            else
            {
                return (36 * rondNr) - resultat;
            }
        }

        private bool ÄrSpelformSlag()
        {
            string spelform = string.Empty;

            //Fältet Spelform i Tavlingklass anger om slag eller poäng ska räknas. 
            //Spelform "SG" och "ST" är slagspelformer
            bool slag = false;
            spelform = Tavling.TavlingKlass[0].Spelform.Trim();

            if (spelform.Equals("SG") || spelform.Equals("ST"))
            {
                slag = true;
            }
            return slag;
        }

        private Color HämtaFärg(int resultat)
        {
            return HämtaFärg(resultat, 1);
        }

        private Color HämtaFärg(int resultat, int rondNr)
        {
            if (ÄrSpelformSlag())
            {
                if (resultat < Par * rondNr)
                {
                    return Color.Red;
                }
                else if (resultat == Par * rondNr)
                {
                    return Color.Black;
                }
                else
                {
                    return Color.Blue;
                }
            }
            else
            {
                if (resultat > 36 * rondNr)
                {
                    return Color.Red;
                }
                else if (resultat == 36 * rondNr)
                {
                    return Color.Black;
                }
                else
                {
                    return Color.Blue;
                }
            }
        }
        #endregion

        private void Resultatlista_Load(object sender, EventArgs e)
        {
            InitieraTexter();
        }

        /// <summary>
        /// Hantera Rondresultat-knappen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            if (dgwResultatlista4.CurrentRow.Cells["AktuelltRondID"].Value != null)
            {
                fönsterhanterare1.HanteraVisaRondResultat(Tavling.TavlingID,
                    dgwResultatlista4.CurrentRow.Cells["AktuellKlass"].Value.ToString(),
                    (int)dgwResultatlista4.CurrentRow.Cells["AktuelltRondID"].Value,
                    (int)dgwResultatlista4.CurrentRow.Cells["SpelarID"].Value);
            }
        }

        /// <summary>
        /// Hantera Avbryt-knappen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboKlassRond_SelectedIndexChanged(object sender, EventArgs e)
        {
            TavlingRond tavlingRond;
            lblResultatlistext.Visible = false;

            if (cboKlassRond.SelectedIndex != -1)
            {
                RondID = ((ComboBoxPar)cboKlassRond.SelectedItem).Identifier;
                tavlingRond = (TavlingRond)((ComboBoxPar)cboKlassRond.SelectedItem).Data;
                RondNR = tavlingRond.RondNr;
                Klass = tavlingRond.Klass;
                FyllListan();
            }
        }

        private void dgwResultatlista_DoubleClick(object sender, EventArgs e)
        {
            if (dgwResultatlista4.CurrentRow.Cells["AktuelltRondID"].Value != null)
            {
                fönsterhanterare1.HanteraVisaRondResultatSpelare(Tavling, 
                    (int)dgwResultatlista4.CurrentRow.Cells["SpelarID"].Value, RondNR);
            }
        }
    }
}
