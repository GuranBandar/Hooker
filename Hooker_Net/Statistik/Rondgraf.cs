using Hooker.Affärsobjekt;
using Hooker_GUI.Kontroller;
using System;
using System.Drawing;


namespace Hooker_GUI
{
    /// <summary>
    /// Fönsterklass för Rondgrafen
    /// </summary>
    public partial class Rondgraf : FormBas
    {
        /// <summary>
        /// Konstruktor  
        /// </summary>
        public Rondgraf()
        {
            InitializeComponent();
        }

        #region "Publika metoder"
        /// <summary>
        /// Visar Rondgrafiken för en runda.
        /// </summary>
        /// <param name="runda">Sammansatt objekt med rundainformation</param>
        public void VisaGraf(Runda runda)
        {
            VisaRondgraf(runda);
        }

        /// <summary>
        /// Visar Rondgrafiken för en runda.
        /// </summary>
        /// <param name="rundaNr">Nyckel till Rundan</param>
        public void VisaGraf(int rundaNr)
        {
            Hooker.Affärslager.RundaAktivitet rundaAktivitet = new Hooker.Affärslager.RundaAktivitet();
            Runda runda = rundaAktivitet.HämtaRundaRundaHalRedovisning(rundaNr);
            VisaRondgraf(runda);
        }
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
                chaRondgraf.ChartAreas[0].AxisX.Title = Översätt("Text", chaRondgraf.Text);

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
        /// Visar Rondgrafiken för en runda.
        /// </summary>
        /// <param name="runda">Sammansatt objekt med rundainformation</param>
        private void VisaRondgraf(Runda runda)
        {
            Timglas.WaitCurson();
            int[] antalPoang = new int[6];
            for (int i = 0; i < runda.RundaHal.Length; i++)
            {
                if (runda.RundaHal[i].HalNr < 4)
                {
                    antalPoang[0] = antalPoang[0] + runda.RundaHal[i].AntalPoang;
                }
                if (runda.RundaHal[i].HalNr < 7)
                {
                    antalPoang[1] = antalPoang[1] + runda.RundaHal[i].AntalPoang;
                }
                if (runda.RundaHal[i].HalNr < 10)
                {
                    antalPoang[2] = antalPoang[2] + runda.RundaHal[i].AntalPoang;
                }
                if (runda.RundaHal[i].HalNr < 13)
                {
                    antalPoang[3] = antalPoang[3] + runda.RundaHal[i].AntalPoang;
                }
                if (runda.RundaHal[i].HalNr < 16)
                {
                    antalPoang[4] = antalPoang[4] + runda.RundaHal[i].AntalPoang;
                }
                if (runda.RundaHal[i].HalNr < 19)
                {
                    antalPoang[5] = antalPoang[5] + runda.RundaHal[i].AntalPoang;
                }
            }

            // Show data points labels
            chaRondgraf.Series["Resultat mot par"].IsValueShownAsLabel = false;

            chaRondgraf.ChartAreas[0].AxisX.IsLabelAutoFit = true;

            // Set data points label style
            chaRondgraf.Series["Resultat mot par"]["BarLabelStyle"] = "Center";
            chaRondgraf.Series["Resultat mot par"].XValueMember = "Hål";
            chaRondgraf.Series["Resultat mot par"].YValueMembers = "Resultat";

            // Set series point width
            chaRondgraf.Series["Resultat mot par"]["PointWidth"] = "0.7";

            for (int j = 0; j < 6; j++)
            {
                switch (j)
                {
                    case 0:
                        chaRondgraf.Series["Resultat mot par"].Points.AddXY("3", 6 - antalPoang[j]);
                        if (antalPoang[j] > 6)
                        {
                            chaRondgraf.Series["Resultat mot par"].Points[j].Color = Color.Tomato;
                        }
                        else
                        {
                            chaRondgraf.Series["Resultat mot par"].Points[j].Color = Color.CornflowerBlue;
                        }
                        break;
                    case 1:
                        chaRondgraf.Series["Resultat mot par"].Points.AddXY("6", 12 - antalPoang[j]);
                        if (antalPoang[j] > 12)
                        {
                            chaRondgraf.Series["Resultat mot par"].Points[j].Color = Color.Tomato;
                        }
                        else
                        {
                            chaRondgraf.Series["Resultat mot par"].Points[j].Color = Color.CornflowerBlue;
                        }
                        break;
                    case 2:
                        chaRondgraf.Series["Resultat mot par"].Points.AddXY("9", 18 - antalPoang[j]);
                        if (antalPoang[j] > 18)
                        {
                            chaRondgraf.Series["Resultat mot par"].Points[j].Color = Color.Tomato;
                        }
                        else
                        {
                            chaRondgraf.Series["Resultat mot par"].Points[j].Color = Color.CornflowerBlue;
                        }
                        break;
                    case 3:
                        chaRondgraf.Series["Resultat mot par"].Points.AddXY("12", 24 - antalPoang[j]);
                        if (antalPoang[j] > 24)
                        {
                            chaRondgraf.Series["Resultat mot par"].Points[j].Color = Color.Tomato;
                        }
                        else
                        {
                            chaRondgraf.Series["Resultat mot par"].Points[j].Color = Color.CornflowerBlue;
                        }
                        break;
                    case 4:
                        chaRondgraf.Series["Resultat mot par"].Points.AddXY("15", 30 - antalPoang[j]);
                        if (antalPoang[j] > 30)
                        {
                            chaRondgraf.Series["Resultat mot par"].Points[j].Color = Color.Tomato;
                        }
                        else
                        {
                            chaRondgraf.Series["Resultat mot par"].Points[j].Color = Color.CornflowerBlue;
                        }
                        break;
                    case 5:
                        chaRondgraf.Series["Resultat mot par"].Points.AddXY("18", 36 - antalPoang[j]);
                        if (antalPoang[j] > 36)
                        {
                            chaRondgraf.Series["Resultat mot par"].Points[j].Color = Color.Tomato;
                        }
                        else
                        {
                            chaRondgraf.Series["Resultat mot par"].Points[j].Color = Color.CornflowerBlue;
                        }
                        break;
                }
            }
            Timglas.DefaultCursor();
        }

        #endregion

        #region "Händelsehanterare"

        private void Rondgraf_Load(object sender, EventArgs e)
        {
            InitieraTexter();
        }

        /// <summary>
        /// Hanterar Avbryt-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
