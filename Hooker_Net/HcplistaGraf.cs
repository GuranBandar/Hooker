using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönsterklass för Rondnalysen
    /// </summary>
    public partial class HcplistaGraf : FormBas
    {
        public HcplistaGraf()
        {
            InitializeComponent();
        }

        #region Egenskapeer
        /// <summary>
        /// SpelarID
        /// </summary>
        public int SpelarID { get; set; }

        /// <summary>
        /// Objekt för Spelare
        /// </summary>
        public Spelare Spelare { get; set; }

        ///// <summary>
        ///// Objektlista för Spelare
        ///// </summary>
        //public List<Spelare> spelarLista { get; set; }

        /// <summary>
        /// Objekt för Hcplista
        /// </summary>
        public List<Hcplista> Hcplista { get; set; }

        /// <summary>
        /// Ny HcpPost
        /// </summary>
        public bool NyHcpPost { get; set; }

        ///// <summary>
        ///// From-datum
        ///// </summary>
        //public DateTime FromDatum { get; set; }

        ///// <summary>
        ///// Tom-datum
        ///// </summary>
        //public DateTime TomDatum { get; set; }
        #endregion

        #region "Privata metoder"
        /// <summary>
        /// Initierar alla texter på kontrollerna
        /// </summary>
        private void InitieraTexter()
        {
            try
            {
                this.Text = Översätt("Text", this.Text);
                lblExaktHcp.Text = Översätt("Text", lblExaktHcp.Text);
                lblSpelare.Text = Översätt("Text", lblSpelare.Text);
                lblPrognosEGA.Text = Översätt("Text", lblPrognosEGA.Text);

                gbxKnappBox.Text = Översätt("Text", gbxKnappBox.Text);
                knappkontroller1.btnKnapp0.Visible = false;
                knappkontroller1.btnKnapp1.Visible = false;
                knappkontroller1.btnKnapp2.Visible = false;
                knappkontroller1.btnKnapp3.Visible = false;
                knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }
        #endregion

        private void HcplistaGraf_Load(object sender, EventArgs e)
        {
            InitieraTexter();
        }

        /// <summary>
        /// Visa HcpGraf
        /// </summary>
        private void VisaHcplista()
        {
            Timglas.WaitCurson();
            if (Spelare != null)
            {
                txtSpelarNamn.Text = Spelare.Namn;
                txtExaktHcp.Text = Spelare.ExaktHcp.ToString();
                EGAPrognos eGAPrognos = new EGAPrognos
                {
                    SpelarID = Spelare.AktuelltSpelarID
                };
                txtPrognosEGA.Text = ("ND1").Formatera(eGAPrognos.UtförHcpPrognos());
            }
            else
            {
                VisaFelmeddelande("SPELAREMISSING");
                return;
            }

            if (Hcplista == null)
            {
                HcplistaAktivitet hcplistaAktivitet = new HcplistaAktivitet();
                Hcplista = hcplistaAktivitet.HämtaHcplista(SpelarID);
            }

            List<Hcplista> hcplista = Hcplista.OrderByDescending(h => h.Datum).Take(20).ToList();
            hcplista = hcplista.OrderBy(h => h.Datum).ToList();
            
            if (hcplista.Count != 0)
            {
                Series ser = new Series
                {
                    ChartType = SeriesChartType.Line
                };
                ser.Points.AddXY(0, hcplista[0].NyttHcp);
                ser.MarkerStyle = MarkerStyle.Circle;
                ser.MarkerSize = 10;
                ser.MarkerColor = Color.LightSlateGray;
                ChartArea cha = chaHcpGraf.ChartAreas[0];
                cha.AxisY.Interval = 1;
                cha.AxisY.Minimum = Convert.ToDouble(Spelare.ExaktHcp) - 3.5;
                cha.AxisY.Maximum = Convert.ToDouble(Spelare.ExaktHcp) + 3.5;
                ser.Points[0].Tag = 0;
                ser.Points[0].ToolTip = hcplista[0].Datum.ToShortDateString() +
                        "/" + hcplista[0].NyttHcp;

                for (int i = 1; i <= hcplista.Count - 1; i++)
                {
                    ser.Points.AddXY(i, hcplista[i].NyttHcp);

                    if (hcplista[i].Typ == "M")
                    {
                        ser.Points[i].Tag = hcplista[i].Hcp + "/" + 
                            hcplista[i].Typ + "/" + hcplista[i].HcplistaID;
                    }
                    else
                    {
                        ser.Points[i].Tag = hcplista[i].RundaNr + "/" 
                            + hcplista[i].Typ + "/" + hcplista[i].HcplistaID;
                    }
                    ser.Points[i].ToolTip = hcplista[i].Datum.ToShortDateString() +
                        "/" + hcplista[i].NyttHcp;
                }

                chaHcpGraf.Series.Add(ser);
            }
            Timglas.DefaultCursor();
        }

        /// <summary>
        /// Visar Hcplista graf 
        /// </summary>
        public void VisaHcplistaGraf()
        {
            try
            {
                if (Spelare != null)
                {
                    VisaHcplista();
                    knappkontroller1.btnKnapp1.Enabled = false;
                    knappkontroller1.btnKnapp2.Enabled = false;
                    knappkontroller1.Focus();
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

        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {

        }

        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Hämta Rundanr vid klick i grafen
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private string ClickPoint(MouseEventArgs e)
        {
            string rundaNr = "";
            _ = new HitTestResult();
            //check where you clicked, returns different information like the clicked series name and the index of the clicked point
            HitTestResult clicked = chaHcpGraf.HitTest(e.X, e.Y);

            if (clicked.PointIndex != -1)
            {
                try
                {
                    if (chaHcpGraf.Series[clicked.Series.Name] == null)
                    {
                        rundaNr = "0";
                    }
                    else
                    {
                        //this is how you get your y-Value
                        rundaNr = chaHcpGraf.Series[clicked.Series.Name].
                            Points[clicked.PointIndex].Tag.ToString();
                    }
                }
                catch (NullReferenceException)
                {
                    rundaNr = "0";
                }
            }
            return rundaNr;
        }

        /// <summary>
        /// Visa Rundanotering vid högerklick i grafen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chaHcpGraf_MouseClick(object sender, MouseEventArgs e)
        {
            Timglas.WaitCurson();
            char[] delimiters = new char[] { '/' };
            string rundaNr = "0";
            string typ = string.Empty;
            int hcplistaID = 0;

            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        string itemClicked = ClickPoint(e);
                        string[] parts = itemClicked.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 0; i < parts.Length; i++)
                        {
                            if (i == 0)
                            {
                                rundaNr = parts[0];
                            }
                            else if (i == 1)
                            {
                                typ = parts[1];
                            }
                            else
                            {
                                hcplistaID = Convert.ToInt32(parts[2]);
                            }
                        }

                        //Om RundaNr = 0 är ingen runda markerad
                        if (rundaNr == "0" || rundaNr == "" || rundaNr == null)
                        {
                            if (typ == "S")
                            {
                                VisaFelmeddelande("INGENRADMARKERAD");
                            }
                            if (typ == "R")
                            {
                                string notering = Hcplista.Where(h => h.HcplistaID == hcplistaID).
                                    Select(h => h.Notering).FirstOrDefault();
                                HanteraUndantag(notering);
                            }
                        }
                        else
                        {
                            fönsterhanterare1.HanteraVisaRundaNotering(rundaNr);
                        }
                    }
                    break;
            }
            Timglas.DefaultCursor();
        }

        /// <summary>
        /// Visa Rundan vid dubbelklick i grafen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chaHcpGraf_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Timglas.WaitCurson();
            char[] delimiters = new char[] { '/' };
            string rundaNr = "0";
            string typ = string.Empty;
            int hcplistaID = 0;

            string itemClicked = ClickPoint(e);
            string[] parts = itemClicked.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parts.Length; i++)
            {
                if (i == 0)
                {
                    rundaNr = parts[0];
                }
                else if (i == 1)
                {
                    typ = parts[1];
                }
                else
                {
                    hcplistaID = Convert.ToInt32(parts[2]);
                }
            }

            //Om RundaNr = 0 är ingen runda markerad
            if (rundaNr == "0" || rundaNr == "" || rundaNr == null)
            {
                if (typ == "S")
                {
                    VisaFelmeddelande("INGENRADMARKERAD");
                }
                if (typ == "R")
                {
                    string notering = Hcplista.Where(h => h.HcplistaID == hcplistaID).
                        Select(h => h.Notering).FirstOrDefault();
                    HanteraUndantag(notering);
                }
            }
            else
            {
                fönsterhanterare1.HanteraVisaRunda(rundaNr);
            }
            Timglas.DefaultCursor();
        }
    }
}
