using System;
using System.Data;
using System.Drawing;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönsterklass för Bananalysen
    /// </summary>
    public partial class BanaAnalys : FormBas
    {
        private DataSet _bananalysDS = new DataSet();
        /// <summary>
        /// Konstruktor
        /// </summary>
        public BanaAnalys()
        {
            FormsLaddar = true;
            InitializeComponent();
        }

        #region "Privata metoder"
        /// <summary>
        /// Initierar alla texter på kontrollerna
        /// </summary>
        private void InitieraTexter()
        {
            try
            {
                this.Text = Översätt("Text", this.Text);
                statistikHuvudKontroll1.InitieraSidhuvud();

                //snurra igenom vilka kontroller som ska visas repektive döljas
                foreach (System.Windows.Forms.Control cc in statistikHuvudKontroll1.Controls)
                {
                    if (cc.Name.Equals("gbxSpelarinfo"))
                    {
                        for (int i = 0; i < cc.Controls.Count; i++)
                        {
                            switch (cc.Controls[i].Name)
                            {
                                case "lblBana":
                                    cc.Controls[i].Show();
                                    break;
                                case "cboBana":
                                    cc.Controls[i].Show();
                                    break;
                                case "lblTyp":
                                    cc.Controls[i].Hide();
                                    break;
                                case "ddnRedovisningstyper":
                                    cc.Controls[i].Hide();
                                    break;
                            }
                        }
                    }
                    else if (cc.Name.Equals("gbxRondTyp"))
                    {
                        cc.Show();
                    }
                    else if (cc.Name.Equals("gbxRedovisningsinfo"))
                    {
                        cc.Hide();
                    }
                }
                
                lblAntal.Text = Översätt("Text", lblAntal.Text);
                gbxUt.Text = Översätt("Text", gbxUt.Text);
                gbxIn.Text = Översätt("Text", gbxIn.Text);
                gbxFW.Text = Översätt("Text", gbxFW.Text);
                gbxGR.Text = Översätt("Text", gbxGR.Text);
                gbxTotalt.Text = Översätt("Text", gbxTotalt.Text);

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

                foreach (System.Windows.Forms.Control cc in gbxFW.Controls)
                {
                    if (cc.Name.StartsWith("lbl"))
                    {
                        cc.Text = Översätt("Text", cc.Text);
                    }
                }

                foreach (System.Windows.Forms.Control cc in gbxGR.Controls)
                {
                    if (cc.Name.StartsWith("lbl"))
                    {
                        cc.Text = Översätt("Text", cc.Text);
                    }
                }

                foreach (System.Windows.Forms.Control cc in gbxTotalt.Controls)
                {
                    if (cc.Name.StartsWith("lbl"))
                    {
                        cc.Text = Översätt("Text", cc.Text);
                    }
                }

                VisaHålensPar();
                chaPoangGraf.ChartAreas[0].AxisX.Title = Översätt("Text", chaPoangGraf.Text);
                knappkontroller1.btnKnapp0.Visible = false;
                knappkontroller1.btnKnapp1.Visible = false;
                knappkontroller1.btnKnapp2.Enabled = false;
                knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_Öppna");
                knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_Sök");
                knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Visar hålens par för aktuell bana
        /// </summary>
        private void VisaHålensPar()
        {
            int halnr;
            int parUt = 0;
            int parIn = 0;
            Bana bana = new Bana();
            Hooker.Affärslager.BanaAktivitet banaAktivitet = new Hooker.Affärslager.BanaAktivitet();

            try
            {
                if (statistikHuvudKontroll1.BanaNr != 0)
                {
                    bana = banaAktivitet.HämtaBanaBanaHal(statistikHuvudKontroll1.BanaNr);

                    foreach (System.Windows.Forms.Control cc in gbxUt.Controls)
                    {
                        if (cc.Name.StartsWith("lblParHal"))
                        {
                            halnr = int.Parse(cc.Name.Substring(9, 1));
                            cc.Text = ("D").Formatera(bana.BanaHal[halnr - 1].Par);
                            Font oldFont = cc.Font;
                            Font newFont = new Font(oldFont, FontStyle.Bold | FontStyle.Italic);
                            cc.Font = newFont;
                            parUt = parUt + (int)bana.BanaHal[halnr - 1].Par;
                        }
                    }

                    foreach (System.Windows.Forms.Control cc in gbxIn.Controls)
                    {
                        if (cc.Name.StartsWith("lblParHal"))
                        {
                            halnr = int.Parse(cc.Name.Substring(9, 2));
                            cc.Text = ("D").Formatera(bana.BanaHal[halnr - 1].Par);
                            Font oldFont = cc.Font;
                            Font newFont = new Font(oldFont, FontStyle.Bold | FontStyle.Italic);
                            cc.Font = newFont;
                            parIn = parIn + (int)bana.BanaHal[halnr - 1].Par;
                        }
                    }

                    lblParUtSa.Text = ("D").Formatera(parUt);
                    lblParInSa.Text = ("D").Formatera(parIn);
                }
            }
            catch (HookerException hex)
            {
                HanteraUndantag(hex);
            }
        }

        /// <summary>
        /// Visar resulatet för sökta rundor
        /// </summary>
        private void VisaResultat()
        {
            int halnr;
            int antal;
            int slagUt = 0;
            int poangUt = 0;
            int parUt = 0;
            int birdieUt = 0;
            int puttarUt = 0;
            int fwUt = 0;
            int grUt = 0;
            int slagIn = 0;
            int poangIn = 0;
            int parIn = 0;
            int birdieIn = 0;
            int puttarIn = 0;
            int fwIn = 0;
            int grIn = 0;

            try
            {
                antal = int.Parse(_bananalysDS.Tables["Bananalys"].Rows[0]["Antal Rundor"].ToString());

                //Börja med hålen ut
                foreach (System.Windows.Forms.Control cc in gbxUt.Controls)
                {
                    if (cc.Name.StartsWith("txtSlagHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(10, 1));
                        cc.Text = ("ND1").Formatera(
                            decimal.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Slag"].ToString()) 
                            / antal);
                        slagUt = slagUt + 
                            int.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Slag"].ToString());
                    }

                    if (cc.Name.StartsWith("txtPoangHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(11, 1));
                        cc.Text = ("ND1").Formatera(
                            decimal.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Poäng"].ToString())
                            / antal);
                        poangUt = poangUt +
                            int.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Poäng"].ToString());
                    }

                    if (cc.Name.StartsWith("txtPuttarHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(12, 1));
                        cc.Text = ("ND1").Formatera(
                            decimal.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Puttar"].ToString())
                            / antal);
                        puttarUt = puttarUt +
                            int.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Puttar"].ToString());
                    }

                    if (cc.Name.StartsWith("txtParHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(9, 1));
                        if (_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal Par"].ToString() != "")
                        {
                            cc.Text = ("N").Formatera(
                                int.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal Par"].ToString()));
                            cc.ForeColor = Color.Blue;
                            parUt = parUt +
                                int.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal Par"].ToString());
                        }
                        else
                        {
                            cc.Text = "0";
                            cc.ForeColor = Color.Black;
                        }
                    }

                    if (cc.Name.StartsWith("txtBirdieHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(12, 1));
                        if (_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal Birdie"].ToString() != "")
                        {
                            cc.Text = ("N").Formatera(
                                int.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal Birdie"].ToString()));
                            cc.ForeColor = Color.Red;
                            birdieUt = birdieUt +
                                int.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal Birdie"].ToString());
                        }
                        else
                        {
                            cc.Text = "0";
                            cc.ForeColor = Color.Black;
                        }
                    }

                    if (cc.Name.StartsWith("txtFWHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(8, 1));
                        if (_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal FW"].ToString() != "")
                        {
                            cc.Text = ("ND1").Formatera(
                                decimal.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal FW"].ToString())
                                / antal * 100);
                            fwUt = fwUt +
                                int.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal FW"].ToString());
                        }
                        else
                        {
                            cc.Text = "0";
                        }
                    }

                    if (cc.Name.StartsWith("txtGRHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(8, 1));
                        if (_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal GR"].ToString() != "")
                        {
                            cc.Text = ("ND1").Formatera(
                                decimal.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal GR"].ToString())
                                / antal * 100);
                            grUt = grUt +
                                int.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal GR"].ToString());
                        }
                        else
                        {
                            cc.Text = "0";
                        }
                    }
                }
                txtSlagUtSa.Text = ("ND1").Formatera(decimal.Parse(slagUt.ToString()) / antal);
                txtPoangUtSa.Text = ("ND1").Formatera(decimal.Parse(poangUt.ToString()) / antal);
                txtParUtSa.Text = ("N").Formatera(decimal.Parse(parUt.ToString()));

                if (parUt > 0)
                {
                    txtParUtSa.ForeColor = Color.Blue;
                }
                else
                {
                    txtParUtSa.ForeColor = Color.Black;
                }

                txtBirdieUtSa.Text = ("N").Formatera(decimal.Parse(birdieUt.ToString()));
                if (birdieUt > 0)
                {
                    txtBirdieUtSa.ForeColor = Color.Red;
                }
                else
                {
                    txtBirdieUtSa.ForeColor = Color.Black;
                }

                txtPuttarUtSa.Text = ("ND1").Formatera(decimal.Parse(puttarUt.ToString()) / antal);
                txtFWUtSa.Text = ("ND1").Formatera((decimal.Parse(fwUt.ToString()) / antal) / 9 * 100);
                txtGRUtSa.Text = ("ND1").Formatera((decimal.Parse(grUt.ToString()) / antal) / 9 * 100);

                txtFWSnittUtAnt.Text = ("ND1").Formatera(decimal.Parse(fwUt.ToString()) / antal);
                txtFWSnittUtProc.Text = ("ND1").Formatera((decimal.Parse(fwUt.ToString()) / antal) / 9 * 100);
                txtGRSnittUtAnt.Text = ("ND1").Formatera(decimal.Parse(grUt.ToString()) / antal);
                txtGRSnittUtProc.Text = ("ND1").Formatera((decimal.Parse(grUt.ToString()) / antal) / 9 * 100);

                // och fortsätt med hålen in
                foreach (System.Windows.Forms.Control cc in gbxIn.Controls)
                {
                    if (cc.Name.StartsWith("txtSlagHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(10, 2));
                        cc.Text = ("ND1").Formatera(
                            decimal.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Slag"].ToString())
                            / antal);
                        slagIn = slagIn +
                            int.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Slag"].ToString());
                    }

                    if (cc.Name.StartsWith("txtPoangHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(11, 2));
                        cc.Text = ("ND1").Formatera(
                            decimal.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Poäng"].ToString())
                            / antal);
                        poangIn = poangIn +
                            int.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Poäng"].ToString());
                    }

                    if (cc.Name.StartsWith("txtPuttarHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(12, 2));
                        cc.Text = ("ND1").Formatera(
                            decimal.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Puttar"].ToString())
                            / antal);
                        puttarIn = puttarIn +
                            int.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Puttar"].ToString());
                    }

                    if (cc.Name.StartsWith("txtParHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(9, 2));
                        if (_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal Par"].ToString() != "")
                        {
                            cc.Text = ("N").Formatera(
                                int.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal Par"].ToString()));
                            cc.ForeColor = Color.Blue;
                            parIn = parIn +
                                int.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal Par"].ToString());
                        }
                        else
                        {
                            cc.Text = "0";
                            cc.ForeColor = Color.Black;
                        }
                    }

                    if (cc.Name.StartsWith("txtBirdieHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(12, 2));
                        if (_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal Birdie"].ToString() != "")
                        {
                            cc.Text = ("N").Formatera(
                                int.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal Birdie"].ToString()));
                            cc.ForeColor = Color.Red;
                            birdieIn = birdieIn +
                                int.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal Birdie"].ToString());
                        }
                        else
                        {
                            cc.Text = "0";
                            cc.ForeColor = Color.Black;
                        }
                    }

                    if (cc.Name.StartsWith("txtFWHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(8, 2));
                        if (_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal FW"].ToString() != "")
                        {
                            cc.Text = ("ND1").Formatera(
                                decimal.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal FW"].ToString())
                                / antal * 100);
                            fwIn = fwIn +
                                int.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal FW"].ToString());
                        }
                        else
                        {
                            cc.Text = "0";
                        }
                    }

                    if (cc.Name.StartsWith("txtGRHal"))
                    {
                        halnr = int.Parse(cc.Name.Substring(8, 2));
                        if (_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal GR"].ToString() != "")
                        {
                            cc.Text = ("ND1").Formatera(
                                decimal.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal GR"].ToString())
                                / antal * 100);
                            grIn = grIn +
                                int.Parse(_bananalysDS.Tables["Bananalys"].Rows[halnr - 1]["Antal GR"].ToString());
                        }
                        else
                        {
                            cc.Text = "0";
                        }
                    }
                }
                txtSlagInSa.Text = ("ND1").Formatera(decimal.Parse(slagIn.ToString()) / antal);
                txtPoangInSa.Text = ("ND1").Formatera(decimal.Parse(poangIn.ToString()) / antal);
                txtParInSa.Text = ("N").Formatera(decimal.Parse(parIn.ToString()));

                if (parIn > 0)
                {
                    txtParInSa.ForeColor = Color.Blue;
                }
                else
                {
                    txtParInSa.ForeColor = Color.Black;
                }

                txtBirdieInSa.Text = ("N").Formatera(decimal.Parse(birdieIn.ToString()));
                if (birdieIn > 0)
                {
                    txtBirdieInSa.ForeColor = Color.Red;
                }
                else
                {
                    txtBirdieInSa.ForeColor = Color.Black;
                }

                txtPuttarInSa.Text = ("ND1").Formatera(decimal.Parse(puttarIn.ToString()) / antal);
                txtFWInSa.Text = ("ND1").Formatera((decimal.Parse(fwIn.ToString()) / antal) / 9 * 100);
                txtGRInSa.Text = ("ND1").Formatera((decimal.Parse(grIn.ToString()) / antal) / 9 * 100);

                txtFWSnittInAnt.Text = ("ND1").Formatera(decimal.Parse(fwIn.ToString()) / antal);
                txtFWSnittInProc.Text = ("ND1").Formatera((decimal.Parse(fwIn.ToString()) / antal) / 9 * 100);
                txtGRSnittInAnt.Text = ("ND1").Formatera(decimal.Parse(grIn.ToString()) / antal);
                txtGRSnittInProc.Text = ("ND1").Formatera((decimal.Parse(grIn.ToString()) / antal) / 9 * 100);

                txtFWSnittTotAnt.Text = ("ND1").Formatera(decimal.Parse((fwUt + fwIn).ToString()) / antal);
                txtFWSnittTotProc.Text = ("ND1").Formatera((decimal.Parse((fwUt + fwIn).ToString()) / antal) / 18 * 100);
                txtGRSnittTotAnt.Text = ("ND1").Formatera(decimal.Parse((grUt + grIn).ToString()) / antal);
                txtGRSnittTotProc.Text = ("ND1").Formatera((decimal.Parse((grUt + grIn).ToString()) / antal) / 18 * 100);

                txtSlagTot.Text = ("ND1").Formatera(decimal.Parse((slagUt + slagIn).ToString()) / antal);
                txtPoangTot.Text = ("ND1").Formatera(decimal.Parse((poangUt + poangIn).ToString()) / antal);
                txtParTot.Text = ("ND1").Formatera(decimal.Parse((parUt + parIn).ToString()) / antal);
                txtBirdieTot.Text = ("ND1").Formatera(decimal.Parse((birdieUt + birdieIn).ToString()) / antal);

                VisaDiagram();
            }
            catch (HookerException hex)
            {
                HanteraUndantag(hex);
            }
        }

        /// <summary>
        /// Visa graf med snittpoäng per hål
        /// </summary>
        private void VisaDiagram()
        {
            int antal;
            double snittPoang = 0;
            antal = int.Parse(_bananalysDS.Tables["Bananalys"].Rows[0]["Antal Rundor"].ToString());

            chaPoangGraf.Series.Clear();
            chaPoangGraf.Series.Add("Snittpoäng");

            // Show data points labels
            chaPoangGraf.Series["Snittpoäng"].IsValueShownAsLabel = true;

            // Set data points label style
            chaPoangGraf.Series["Snittpoäng"]["BarLabelStyle"] = "Center";
            chaPoangGraf.Series["Snittpoäng"].XValueMember = "Hål";
            chaPoangGraf.Series["Snittpoäng"].YValueMembers = "SnittPoäng";

            // Set series point width
            chaPoangGraf.Series["Snittpoäng"]["PointWidth"] = "0.7";

            for (int i = 0; i < 18; i++)
            {
                snittPoang = Math.Round((double)(int)_bananalysDS.Tables["Bananalys"].Rows[i]["Poäng"] / antal, 1);
                chaPoangGraf.Series["Snittpoäng"].Points.AddXY((int)_bananalysDS.Tables["Bananalys"].Rows[i]["HalNr"], snittPoang);
                chaPoangGraf.Series["Snittpoäng"].Points[i].Color = Color.CornflowerBlue;            }

            gbxGraf.Visible = true;
        }

        private void RensaResultat()
        {
            foreach (System.Windows.Forms.Control cc in gbxUt.Controls)
            {
                if (cc.Name.StartsWith("txt"))
                {
                    cc.Text = "";
                }
            }
            foreach (System.Windows.Forms.Control cc in gbxIn.Controls)
            {
                if (cc.Name.StartsWith("txt"))
                {
                    cc.Text = "";
                }
            }
            foreach (System.Windows.Forms.Control cc in gbxFW.Controls)
            {
                if (cc.Name.StartsWith("txt"))
                {
                    cc.Text = "";
                }
            }
            foreach (System.Windows.Forms.Control cc in gbxGR.Controls)
            {
                if (cc.Name.StartsWith("txt"))
                {
                    cc.Text = "";
                }
            }
            foreach (System.Windows.Forms.Control cc in gbxTotalt.Controls)
            {
                if (cc.Name.StartsWith("txt"))
                {
                    cc.Text = "";
                }
            }
            gbxGraf.Visible = false;
        }
        #endregion

        #region "Händelsehanterare"
        private void BanaAnalys_Load(object sender, EventArgs e)
        {
            InitieraTexter();
            //gbxGraf.Visible = false;
            this.MdiParent = MdiMain;
            statistikHuvudKontroll1.Focus();
            FormsLaddar = false;
        }

        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            hanteraFönster1.HanteraVisaBana(statistikHuvudKontroll1.BanaNr.ToString());
        }

        /// <summary>
        /// Hanterar Sök-knappen
        /// 
        /// Användaren måste ha valt både spelare och bana för att statistiken ska visas.
        /// </summary>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            int spelarID;
            int banaNr;
            DateTime fromDatum;
            DateTime tomDatum;
            bool hcprond = false;
            bool niohalsrond = false;
            bool sallskapsrond = false;
            bool tavlingsrond = false;
            Hooker.Affärslager.Statistik statistik;

            try
            {
                if (statistikHuvudKontroll1.SpelarID == 0)
                {
                    VisaFelmeddelande("SPELAREMISSING");
                }
                else if (statistikHuvudKontroll1.BanaNr == 0)
                {
                    VisaFelmeddelande("BANAMISSING");
                }
                else
                {
                    statistik = new Hooker.Affärslager.Statistik();
                    spelarID = statistikHuvudKontroll1.SpelarID;
                    banaNr = statistikHuvudKontroll1.BanaNr;
                    fromDatum = statistikHuvudKontroll1.FromDatum;
                    tomDatum = statistikHuvudKontroll1.TomDatum;
                    if (statistikHuvudKontroll1.HcpronderVald)
                    {
                        hcprond = true;
                    }
                    else if (statistikHuvudKontroll1.NiohalsronderVald)
                    {
                        niohalsrond = true;
                    }
                    else if (statistikHuvudKontroll1.SallskapsronderVald)
                    {
                        sallskapsrond = true;
                    }
                    else if (statistikHuvudKontroll1.TavlingsronderVald)
                    {
                        tavlingsrond = true;
                    }

                    VisaHålensPar();
                    _bananalysDS = statistik.Bananalys("", banaNr.ToString(), spelarID.ToString(), 
                        fromDatum, tomDatum, hcprond, niohalsrond, sallskapsrond, tavlingsrond);

                    if (_bananalysDS.Tables["Bananalys"].Rows.Count > 0)
                    {
                        knappkontroller1.btnKnapp2.Enabled = true;
                        //Antalet rundor
                        txtAntal.Text = _bananalysDS.Tables["Bananalys"].Rows[0]["Antal Rundor"].ToString();
                        VisaResultat();
                    }
                    else
                    {
                        txtAntal.Text = "0";
                        VisaFelmeddelande("RNDSMISSING");
                        RensaResultat();
                    }
                }
            }
            catch (HookerException hex)
            {
                HanteraUndantag(hex);
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hanterar Avbryt-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void statistikHuvudKontroll1_OnCboSpelareSelect(object sender, EventArgs e)
        {
            if (!FormsLaddar)
            {
                this.knappkontroller1_OnKnapp3Click(sender, e);
            }
        }

        private void statistikHuvudKontroll1_OnDtpFromDatumChanged(object sender, EventArgs e)
        {
            if (!FormsLaddar)
            {
                this.knappkontroller1_OnKnapp3Click(sender, e);
            }
        }

        private void statistikHuvudKontroll1_OnDtpTomDatumChanged(object sender, EventArgs e)
        {
            if (!FormsLaddar)
            {
                this.knappkontroller1_OnKnapp3Click(sender, e);
            }
        }

        private void statistikHuvudKontroll1_OnCboHemmabanaSelect(object sender, EventArgs e)
        {
            if (!FormsLaddar)
            {
                this.knappkontroller1_OnKnapp3Click(sender, e);
            }
        }

        private void statistikHuvudKontroll1_OnCboGolfklubbSelect(object sender, EventArgs e)
        {
            if (!FormsLaddar)
            {
                if (statistikHuvudKontroll1.BanaNr != 0)
                    this.knappkontroller1_OnKnapp3Click(sender, e);
            }
        }
        #endregion
    }
}
