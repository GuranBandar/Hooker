using System;
using System.Data;
using System.Drawing;
using Hooker_GUI.Kontroller;
using System.Windows.Forms.DataVisualization.Charting;

namespace Hooker_GUI
{
    /// <summary>
    ///     Fönsterklass för Andelsgraf, dvs andel puttar respektive slag för aktuellt urval
    /// </summary>
    public partial class AndelPuttGraf : FormBas
    {
        /// <summary>
        ///     Konstruktor
        /// </summary>
        public AndelPuttGraf()
        {
            InitializeComponent();
            InitieraTexter();
        }

        #region "Privata metoder"
        /// <summary>
        ///     Initierar alla texter på kontrollerna
        /// </summary>
        private void InitieraTexter()
        {
            try
            {
                this.Text = Översätt("Text", this.Text);
                chaAndelPutt.Titles.Add(Översätt("Text", chaAndelPutt.Text));

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

        /// <summary>
        ///     Visar Andelsgrafiken för aktuellt urval.
        /// </summary>
        /// <param name="andelDS">Dataset med aktuell information</param>
        public void VisaAndelgraf(DataSet andelDS)
        {
            foreach (DataRow rad in andelDS.Tables["Puttstatistik"].Rows)
            {
                switch (rad["Par"].ToString())
                {
                    case "9":
                        decimal andelPutt = (decimal)(int)rad["Antal puttar"] /
                            ((int)rad["Antal puttar"] +
                            (int)rad["Antal slag"]);
                        decimal andelSlag = (decimal)(int)rad["Antal slag"] /
                            ((int)rad["Antal puttar"] +
                            (int)rad["Antal slag"]);
                        decimal[] yValues = { (decimal)Math.Round(andelPutt * 100, 0), 
                                    (decimal)Math.Round(andelSlag * 100, 0)};
                        string[] xValues = { Översätt("Text", "Rubrik_Puttar"),
                                 Översätt("Text", "Rubrik_Slag") };
                        chaAndelPutt.Series["Default"].Points.DataBindXY(xValues, yValues);
                        chaAndelPutt.Series["Default"].Points[1]["Exploded"] = "true";
                        chaAndelPutt.Series["Default"].IsValueShownAsLabel = true;
                        chaAndelPutt.Series["Default"].Points[0].Color = Color.Tomato;
                        chaAndelPutt.Series["Default"].Points[1].Color = Color.CornflowerBlue;
                        chaAndelPutt.Series["Default"].ChartType = SeriesChartType.Pie;
                        chaAndelPutt.Series["Default"]["PieLabelStyle"] = "Inside";
                        chaAndelPutt.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                        chaAndelPutt.Legends[0].Enabled = true;
                        chaAndelPutt.Visible = true;
                        break;
                }
            }
       }

        #endregion

        #region "Händelsehanterare"
        private void chaAndelPutt_Load(object sender, EventArgs e)
        {
            InitieraTexter();
        }

        /// <summary>
        ///     Hanterar Avbryt-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
