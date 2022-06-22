using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using Hooker_GUI.Kontroller;

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
        /// Tar fram ett tänkt hcp enligt Amerikansk modell, dvs de tio bästa rundorna av de senaste tjugo
        /// </summary>
        private void SimuleraHcp()
        {
            int slagTot = 0;

            //Först sortera rundorna descending
            DataTable ronder = Rondanalys.Tables["Rondanalys"];
            DataView rondView = ronder.AsDataView();
            rondView.Sort = "Datum desc";
            DataTable hcpRonder = rondView.ToTable();

            //Sedan plocka ut de senaste tjugo rundorna
            List<DataRow> myRows = new List<DataRow>(hcpRonder.Select().Take(20));
            myRows.Sort((x, y) => string.Compare(x["Slag"].ToString(), y["Slag"].ToString()));

            //myRows.Select("Poang DESC", "Poang DESC");
            //och summera de 10 bästa av dessa 20
            for (int i = 0; i < 10; i++)
            {
                slagTot += (int)myRows[i]["Slag"];
            }

            lblSnittSlag.Text = (slagTot / 10).ToString();
            //DataView rondView = new DataView(Rondanalys.Tables["Rondanalys"]);
            //Först hämta de senaste tjugo rundorna
            //List<DataRow> myRows = new List<DataRow>();
            //List<DataRow> rondRows = (DataTable)(Rondanalys.Tables["Rondanalys"].Rows.Add;

            //for (int i = Rondanalys.Tables["Rondanalys"].Rows.Count - 1; i > Rondanalys.Tables["Rondanalys"].Rows.Count - 21; i--)
            //foreach (DataRow row in Rondanalys.Tables["Rondanalys"].Rows)
            //{
            //    myRows.Add(row);
                //myRows.Add(Rondanalys.Tables["Rondanalys"].Rows[i]);
            //}

            //List<DataRow> hcpRow = myRows.Select(x => new List<DataRow>() { }()).OrderBy(y = y[1]).Take(20);

            //Sedan sortera på antal slag
            //rondView.Sort = "Slag";

            //Sedan summera de tio bästa och dela med 10
            //foreach (DataRow row in myRows)
            //{
            //    slagTot += (int)row["Slag"];
            //    //summera senaste slag på bästa 10 av de senaste 20 rundorna
            //}
        }

        /// <summary>
        /// Visar Formkurvagrafiken för aktuellt urval.
        /// </summary>
        public void VisaFormkurva()
        {
            for (int i = 0; i <= Rondanalys.Tables["Rondanalys"].Rows.Count - 1; i++)
            {
                chaFormkurva.Series["Series1"].Points.AddY(Rondanalys.Tables["Rondanalys"].Rows[i]["Poäng"]);
            }
        }

        #region "Händelsehanterare"
        private void FormkurvaGraf_Load(object sender, EventArgs e)
        {
            InitieraTexter();

            if (Rondanalys.Tables["Rondanalys"].Rows.Count > 19)
            {
                this.SimuleraHcp();
            }
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
