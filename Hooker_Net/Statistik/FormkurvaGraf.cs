using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Hooker_GUI
{
    /// <summary>
    /// Formkurvan som en graf
    /// </summary>
    public partial class FormkurvaGraf : FormBas
    {
        private DataSet _rondanalysDS = new DataSet();

        public DataSet Rondanalys { get { return _rondanalysDS; } set { _rondanalysDS = value; } }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public FormkurvaGraf()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Initierar alla texter på kontrollerna
        /// </summary>
        private void InitieraTexter()
        {
            try
            {
                this.Text = Översätt("Text", this.Text);
                chaFormkurva.Series["Series1"].IsValueShownAsLabel = true;
                chaFormkurva.Series["Series1"].ChartType = SeriesChartType.Spline;
                chaFormkurva.ChartAreas["Formen"].AxisX.IsMarginVisible = false;
                lblPrognosEGA.Text = Översätt("Text", lblPrognosEGA.Text);

                knappkontroller1.btnKnapp0.Visible = false;
                knappkontroller1.btnKnapp1.Visible = false;
                knappkontroller1.btnKnapp2.Visible = false;
                knappkontroller1.btnKnapp3.Visible = false;
                knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
                this.SimuleraHcp();
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Tar fram ett tänkt hcp enligt EGA-modellen, dvs snitt på de åtta bästa rundorna 
        /// av de senaste tjugo
        /// </summary>
        private void SimuleraHcp()
        {
            Timglas.WaitCurson();
            EGAPrognos eGAPrognos = new EGAPrognos();
            eGAPrognos.SpelarID = AppUser.SpelarID;
            txtPrognosEGA.Text = ("ND1").Formatera(eGAPrognos.UtförHcpPrognos());
            Timglas.DefaultCursor();
        }

        /// <summary>
        /// Visar Formkurvagrafiken för aktuellt urval.
        /// </summary>
        public void VisaFormkurva()
        {
            Series ser = new Series();
            ser.ChartType = SeriesChartType.Spline;
            ser.Points.AddXY(0, 28);
            ser.MarkerStyle = MarkerStyle.Diamond;
            ser.MarkerSize = 11;
            ser.MarkerColor = Color.DarkOliveGreen;
            ser.Points[0].Tag = 0;
            for (int i = 1; i <= Rondanalys.Tables["Rondanalys"].Rows.Count; i++)
            {
                ser.Points.AddXY(i, Rondanalys.Tables["Rondanalys"].Rows[i - 1]["Poäng"]);
                ser.Points[i].Tag = Rondanalys.Tables["Rondanalys"].Rows[i - 1]["RundaNr"];
                ser.Points[i].ToolTip = Rondanalys.Tables["Rondanalys"].Rows[i - 1]["Datum"].ToString();
            }
            chaFormkurva.Series.Add(ser);
        }

        #region "Händelsehanterare"
        private void FormkurvaGraf_Load(object sender, EventArgs e)
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

        /// <summary>
        /// Högerklick ska visa Rundanotering
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chaFormkurva_MouseClick(object sender, MouseEventArgs e)
        {
            string rundaNr = "";
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        try
                        {
                            HitTestResult clicked = new HitTestResult();
                            //check where you clicked, returns different information like the clicked series name and the index of the clicked point
                            clicked = chaFormkurva.HitTest(e.X, e.Y);

                            if (clicked.PointIndex != -1)
                            {
                                //this is how you get your y-Value
                                rundaNr = chaFormkurva.Series[clicked.Series.Name].
                                    Points[clicked.PointIndex].Tag.ToString();
                            }

                            //Om RundaNr = 0 är ingen runda markerad
                            if (rundaNr == "0" || rundaNr == "")
                            {
                                VisaFelmeddelande("INGENRADMARKERAD");
                            }
                            else
                            {
                                hanteraFönster1.HanteraVisaRundaNotering(rundaNr);
                            }
                        }
                        catch (Exception ex)
                        {
                            HanteraUndantag(ex);
                        }
                    }
                    break;
            }

        }

        /// <summary>
        /// Dubbelklick ska visa Rundan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chaFormkurva_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string rundaNr = "";
            try
            {
                HitTestResult clicked = new HitTestResult();
                //check where you clicked, returns different information like the clicked series name and the index of the clicked point
                clicked = chaFormkurva.HitTest(e.X, e.Y);

                if (clicked.PointIndex != -1)
                {
                    //this is how you get your y-Value
                    rundaNr = chaFormkurva.Series[clicked.Series.Name].
                        Points[clicked.PointIndex].Tag.ToString();
                }

                //Om RundaNr = 0 är ingen runda markerad
                if (rundaNr == "0" || rundaNr == "")
                {
                    VisaFelmeddelande("INGENRADMARKERAD");
                }
                else
                {
                    hanteraFönster1.HanteraVisaRunda(rundaNr);
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
