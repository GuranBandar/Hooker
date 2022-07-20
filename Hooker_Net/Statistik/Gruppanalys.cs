using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Data;
using System.Drawing;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönsterklass för Gruppanalysen
    /// </summary>
    public partial class Gruppanalys : FormBas
    {
        private DataSet gruppanalysDS = new DataSet();

        /// <summary>
        /// Konstruktor
        /// </summary>
        public Gruppanalys()
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
                gbxPar3.Text = Översätt("Text", gbxPar3.Text);
                gbxPar4.Text = Översätt("Text", gbxPar4.Text);
                gbxPar5.Text = Översätt("Text", gbxPar5.Text);
                gbxTotalt.Text = Översätt("Text", gbxTotalt.Text);

                foreach (System.Windows.Forms.Control cc in gbxPar3.Controls)
                {
                    if (cc.Name.StartsWith("lbl"))
                    {
                        cc.Text = Översätt("Text", cc.Text);
                    }
                }

                foreach (System.Windows.Forms.Control cc in gbxPar4.Controls)
                {
                    if (cc.Name.StartsWith("lbl"))
                    {
                        cc.Text = Översätt("Text", cc.Text);
                    }
                }

                foreach (System.Windows.Forms.Control cc in gbxPar5.Controls)
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

                knappkontroller1.btnKnapp0.Visible = false;
                knappkontroller1.btnKnapp1.Visible = false;
                knappkontroller1.btnKnapp2.Visible = false;
                knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_Sök");
                knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        ///     Nollställ alla textboxar på kontrollerna
        /// </summary>
        private void NollställTextboxar()
        {
            try
            {
                txtAntal.Text = "";

                foreach (System.Windows.Forms.Control cc in gbxPar3.Controls)
                {
                    if (cc.Name.StartsWith("txt"))
                    {
                        cc.Text = "";
                    }
                }

                foreach (System.Windows.Forms.Control cc in gbxPar4.Controls)
                {
                    if (cc.Name.StartsWith("txt"))
                    {
                        cc.Text = "";
                    }
                }

                foreach (System.Windows.Forms.Control cc in gbxPar5.Controls)
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
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Visar resulatet för sökta rundor
        /// </summary>
        private void VisaResultat()
        {
            txtAntal.Text = gruppanalysDS.Tables["Antal"].Rows[0]["Antal rundor"].ToString();

            foreach (DataRow rad in gruppanalysDS.Tables["Gruppanalys"].Rows)
            {
                switch (rad["Par"].ToString())
                {
                    case "3":
                        //Par 3:or
                        txtPar3Antal.Text = "N".Formatera(int.Parse(rad["Antal hål"].ToString()));
                        txtPar3Poangsnitt.Text = "ND1".Formatera(
                            decimal.Parse(rad["Poäng"].ToString()) / decimal.Parse(rad["Antal hål"].ToString()));
                        txtPar3Slagsnitt.Text = "ND1".Formatera(
                            decimal.Parse(rad["Slag"].ToString()) / decimal.Parse(rad["Antal hål"].ToString()));
                        txtPar3Puttsnitt.Text = "ND1".Formatera(
                            decimal.Parse(rad["Puttar"].ToString()) / decimal.Parse(rad["Antal hål"].ToString()));
                        txtPar3GRTraff.Text = "N".Formatera(Convert.ToInt32(rad["Antal GR"]));
                        txtPar3GRTraffProc.Text = "ND1".Formatera(
                            decimal.Parse(Convert.ToInt32(rad["Antal GR"]).ToString()) /
                            decimal.Parse(Convert.ToInt32(rad["Antal hål"]).ToString()) * 100);
                        txtPar3FWTraff.Text = "N".Formatera(Convert.ToInt32(rad["Antal FW"]));
                        txtPar3FWTraffProc.Text = "ND1".Formatera(
                            decimal.Parse(Convert.ToInt32(rad["Antal FW"]).ToString()) /
                            decimal.Parse(Convert.ToInt32(rad["Antal hål"]).ToString()) * 100);

                        if (rad["Antal Eagle"].ToString() != "")
                        {
                            txtPar3Eagle.Text = "N".Formatera(int.Parse(rad["Antal Eagle"].ToString()));
                            txtPar3EagleProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Eagle"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar3Eagle.ForeColor = Color.Red;
                            txtPar3EagleProc.ForeColor = Color.Red;
                        }

                        if (rad["Antal Birdie"].ToString() != "")
                        {
                            txtPar3Birdie.Text = "N".Formatera(int.Parse(rad["Antal Birdie"].ToString()));
                            txtPar3BirdieProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Birdie"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar3Birdie.ForeColor = Color.Red;
                            txtPar3BirdieProc.ForeColor = Color.Red;
                        }

                        if (rad["Antal Par"].ToString() != "")
                        {
                            txtPar3Par.Text = "N".Formatera(int.Parse(rad["Antal Par"].ToString()));
                            txtPar3ParProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Par"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                        }

                        if (rad["Antal Bogey"].ToString() != "")
                        {
                            txtPar3Bogey.Text = "N".Formatera(int.Parse(rad["Antal Bogey"].ToString()));
                            txtPar3BogeyProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Bogey"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar3Bogey.ForeColor = Color.Blue;
                            txtPar3BogeyProc.ForeColor = Color.Blue;
                        }

                        if (rad["Antal Dubbelbogey"].ToString() != "")
                        {
                            txtPar3Dubbelbogey.Text = "N".Formatera(int.Parse(rad["Antal Dubbelbogey"].ToString()));
                            txtPar3DubbelbogeyProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Dubbelbogey"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar3Dubbelbogey.ForeColor = Color.Blue;
                            txtPar3DubbelbogeyProc.ForeColor = Color.Blue;
                        }

                        if (rad["Antal Trippelbogey"].ToString() != "")
                        {
                            txtPar3Trippelbogey.Text = "N".Formatera(int.Parse(rad["Antal Trippelbogey"].ToString()));
                            txtPar3TrippelbogeyProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Trippelbogey"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar3Trippelbogey.ForeColor = Color.Blue;
                            txtPar3TrippelbogeyProc.ForeColor = Color.Blue;
                        }

                        if (rad["Antal Andra"].ToString() != "")
                        {
                            txtPar3Andra.Text = "N".Formatera(int.Parse(rad["Antal Andra"].ToString()));
                            txtPar3AndraProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Andra"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar3Andra.ForeColor = Color.Blue;
                            txtPar3AndraProc.ForeColor = Color.Blue;
                        }
                        break;
                    case "4":
                        //Par 4:or
                        txtPar4Antal.Text = "N".Formatera(int.Parse(rad["Antal hål"].ToString()));
                        txtPar4Poangsnitt.Text = "ND1".Formatera(
                            decimal.Parse(rad["Poäng"].ToString()) / decimal.Parse(rad["Antal hål"].ToString()));
                        txtPar4Slagsnitt.Text = "ND1".Formatera(
                            decimal.Parse(rad["Slag"].ToString()) / decimal.Parse(rad["Antal hål"].ToString()));
                        txtPar4Puttsnitt.Text = "ND1".Formatera(
                            decimal.Parse(rad["Puttar"].ToString()) / decimal.Parse(rad["Antal hål"].ToString()));
                        txtPar4GRTraff.Text = "N".Formatera(Convert.ToInt32(rad["Antal GR"]));
                        txtPar4GRTraffProc.Text = "ND1".Formatera(
                            decimal.Parse(Convert.ToInt32(rad["Antal GR"]).ToString()) /
                            decimal.Parse(Convert.ToInt32(rad["Antal hål"]).ToString()) * 100);
                        txtPar4FWTraff.Text = "N".Formatera(Convert.ToInt32(rad["Antal FW"]));
                        txtPar4FWTraffProc.Text = "ND1".Formatera(
                            decimal.Parse(Convert.ToInt32(rad["Antal FW"]).ToString()) /
                            decimal.Parse(Convert.ToInt32(rad["Antal hål"]).ToString()) * 100);

                        if (rad["Antal Eagle"].ToString() != "")
                        {
                            txtPar4Eagle.Text = "N".Formatera(int.Parse(rad["Antal Eagle"].ToString()));
                            txtPar4EagleProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Eagle"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar4Eagle.ForeColor = Color.Red;
                            txtPar4EagleProc.ForeColor = Color.Red;
                        }

                        if (rad["Antal Birdie"].ToString() != "")
                        {
                            txtPar4Birdie.Text = "N".Formatera(int.Parse(rad["Antal Birdie"].ToString()));
                            txtPar4BirdieProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Birdie"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar4Birdie.ForeColor = Color.Red;
                            txtPar4BirdieProc.ForeColor = Color.Red;
                        }

                        if (rad["Antal Par"].ToString() != "")
                        {
                            txtPar4Par.Text = "N".Formatera(int.Parse(rad["Antal Par"].ToString()));
                            txtPar4ParProc.Text = ("ND1").Formatera(
                                decimal.Parse(rad["Antal Par"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                        }

                        if (rad["Antal Bogey"].ToString() != "")
                        {
                            txtPar4Bogey.Text = "N".Formatera(int.Parse(rad["Antal Bogey"].ToString()));
                            txtPar4BogeyProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Bogey"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar4Bogey.ForeColor = Color.Blue;
                            txtPar4BogeyProc.ForeColor = Color.Blue;
                        }

                        if (rad["Antal Dubbelbogey"].ToString() != "")
                        {
                            txtPar4Dubbelbogey.Text = "N".Formatera(int.Parse(rad["Antal Dubbelbogey"].ToString()));
                            txtPar4DubbelbogeyProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Dubbelbogey"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar4Dubbelbogey.ForeColor = Color.Blue;
                            txtPar4DubbelbogeyProc.ForeColor = Color.Blue;
                        }

                        if (rad["Antal Trippelbogey"].ToString() != "")
                        {
                            txtPar4Trippelbogey.Text = "N".Formatera(int.Parse(rad["Antal Trippelbogey"].ToString()));
                            txtPar4TrippelbogeyProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Trippelbogey"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar4Trippelbogey.ForeColor = Color.Blue;
                            txtPar4TrippelbogeyProc.ForeColor = Color.Blue;
                        }

                        if (rad["Antal Andra"].ToString() != "")
                        {
                            txtPar4Andra.Text = "N".Formatera(int.Parse(rad["Antal Andra"].ToString()));
                            txtPar4AndraProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Andra"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar4Andra.ForeColor = Color.Blue;
                            txtPar4AndraProc.ForeColor = Color.Blue;
                        }
                        break;
                    case "5":
                        //Par 5:or
                        txtPar5Antal.Text = "N".Formatera(int.Parse(rad["Antal hål"].ToString()));
                        txtPar5Poangsnitt.Text = "ND1".Formatera(
                            decimal.Parse(rad["Poäng"].ToString()) / decimal.Parse(rad["Antal hål"].ToString()));
                        txtPar5Slagsnitt.Text = "ND1".Formatera(
                            decimal.Parse(rad["Slag"].ToString()) / decimal.Parse(rad["Antal hål"].ToString()));
                        txtPar5Puttsnitt.Text = "ND1".Formatera(
                            decimal.Parse(rad["Puttar"].ToString()) / decimal.Parse(rad["Antal hål"].ToString()));
                        txtPar5GRTraff.Text = "N".Formatera(Convert.ToInt32(rad["Antal GR"]));
                        txtPar5GRTraffProc.Text = "ND1".Formatera(
                            decimal.Parse(Convert.ToInt32(rad["Antal GR"]).ToString()) /
                            decimal.Parse(Convert.ToInt32(rad["Antal hål"]).ToString()) * 100);
                        txtPar5FWTraff.Text = "N".Formatera(Convert.ToInt32(rad["Antal FW"]));
                        txtPar5FWTraffProc.Text = "ND1".Formatera(
                            decimal.Parse(Convert.ToInt32(rad["Antal FW"]).ToString()) /
                            decimal.Parse(Convert.ToInt32(rad["Antal hål"]).ToString()) * 100);

                        if (rad["Antal Eagle"].ToString() != "")
                        {
                            txtPar5Eagle.Text = "N".Formatera(int.Parse(rad["Antal Eagle"].ToString()));
                            txtPar5EagleProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Eagle"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar5Eagle.ForeColor = Color.Red;
                            txtPar5EagleProc.ForeColor = Color.Red;
                        }

                        if (rad["Antal Birdie"].ToString() != "")
                        {
                            txtPar5Birdie.Text = "N".Formatera(int.Parse(rad["Antal Birdie"].ToString()));
                            txtPar5BirdieProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Birdie"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar5Birdie.ForeColor = Color.Red;
                            txtPar5BirdieProc.ForeColor = Color.Red;
                        }

                        if (rad["Antal Par"].ToString() != "")
                        {
                            txtPar5Par.Text = "N".Formatera(int.Parse(rad["Antal Par"].ToString()));
                            txtPar5ParProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Par"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                        }

                        if (rad["Antal Bogey"].ToString() != "")
                        {
                            txtPar5Bogey.Text = "N".Formatera(int.Parse(rad["Antal Bogey"].ToString()));
                            txtPar5BogeyProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Bogey"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar5Bogey.ForeColor = Color.Blue;
                            txtPar5BogeyProc.ForeColor = Color.Blue;
                        }

                        if (rad["Antal Dubbelbogey"].ToString() != "")
                        {
                            txtPar5Dubbelbogey.Text = "N".Formatera(int.Parse(rad["Antal Dubbelbogey"].ToString()));
                            txtPar5DubbelbogeyProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Dubbelbogey"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar5Dubbelbogey.ForeColor = Color.Blue;
                            txtPar5DubbelbogeyProc.ForeColor = Color.Blue;
                        }

                        if (rad["Antal Trippelbogey"].ToString() != "")
                        {
                            txtPar5Trippelbogey.Text = "N".Formatera(int.Parse(rad["Antal Trippelbogey"].ToString()));
                            txtPar5TrippelbogeyProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Trippelbogey"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar5Trippelbogey.ForeColor = Color.Blue;
                            txtPar5TrippelbogeyProc.ForeColor = Color.Blue;
                        }

                        if (rad["Antal Andra"].ToString() != "")
                        {
                            txtPar5Andra.Text = "N".Formatera(int.Parse(rad["Antal Andra"].ToString()));
                            txtPar5AndraProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Andra"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar5Andra.ForeColor = Color.Blue;
                            txtPar5AndraProc.ForeColor = Color.Blue;
                        }
                        break;
                    case "9":
                        //Totalt
                        txtTotaltAntal.Text = "N".Formatera(int.Parse(rad["Antal hål"].ToString()));
                        txtTotaltPoangsnitt.Text = "ND1".Formatera(
                            decimal.Parse(rad["Poäng"].ToString()) / decimal.Parse(rad["Antal hål"].ToString()));
                        txtTotaltSlagsnitt.Text = "ND1".Formatera(
                            decimal.Parse(rad["Slag"].ToString()) / decimal.Parse(rad["Antal hål"].ToString()));
                        txtTotaltPuttsnitt.Text = "ND1".Formatera(
                            decimal.Parse(rad["Puttar"].ToString()) / decimal.Parse(rad["Antal hål"].ToString()));
                        txtTotaltGRTraff.Text = "N".Formatera(Convert.ToInt32(rad["Antal GR"]));
                        txtTotaltGRTraffProc.Text = "ND1".Formatera(
                            decimal.Parse(Convert.ToInt32(rad["Antal GR"]).ToString()) /
                            decimal.Parse(Convert.ToInt32(rad["Antal hål"]).ToString()) * 100);
                        txtTotaltFWTraff.Text = "N".Formatera(Convert.ToInt32(rad["Antal FW"]));
                        txtTotaltFWTraffProc.Text = "ND1".Formatera(
                            decimal.Parse(Convert.ToInt32(rad["Antal FW"]).ToString()) /
                            decimal.Parse(Convert.ToInt32(rad["Antal hål"]).ToString()) * 100);

                        if (rad["Antal Eagle"].ToString() != "")
                        {
                            txtTotaltEagle.Text = "N".Formatera(int.Parse(rad["Antal Eagle"].ToString()));
                            txtTotaltEagleProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Eagle"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtTotaltEagle.ForeColor = Color.Red;
                            txtTotaltEagleProc.ForeColor = Color.Red;
                        }

                        if (rad["Antal Birdie"].ToString() != "")
                        {
                            txtTotaltBirdie.Text = "N".Formatera(int.Parse(rad["Antal Birdie"].ToString()));
                            txtTotaltBirdieProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Birdie"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtTotaltBirdie.ForeColor = Color.Red;
                            txtTotaltBirdieProc.ForeColor = Color.Red;
                        }

                        if (rad["Antal Par"].ToString() != "")
                        {
                            txtTotaltPar.Text = "N".Formatera(int.Parse(rad["Antal Par"].ToString()));
                            txtTotaltParProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Par"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                        }

                        if (rad["Antal Bogey"].ToString() != "")
                        {
                            txtTotaltBogey.Text = "N".Formatera(int.Parse(rad["Antal Bogey"].ToString()));
                            txtTotaltBogeyProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Bogey"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtTotaltBogey.ForeColor = Color.Blue;
                            txtTotaltBogeyProc.ForeColor = Color.Blue;
                        }

                        if (rad["Antal Dubbelbogey"].ToString() != "")
                        {
                            txtTotaltDubbelbogey.Text = "N".Formatera(int.Parse(rad["Antal Dubbelbogey"].ToString()));
                            txtTotaltDubbelbogeyProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Dubbelbogey"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtTotaltDubbelbogey.ForeColor = Color.Blue;
                            txtTotaltDubbelbogeyProc.ForeColor = Color.Blue;
                        }

                        if (rad["Antal Trippelbogey"].ToString() != "")
                        {
                            txtTotaltTrippelbogey.Text = "N".Formatera(int.Parse(rad["Antal Trippelbogey"].ToString()));
                            txtTotaltTrippelbogeyProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Trippelbogey"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtTotaltTrippelbogey.ForeColor = Color.Blue;
                            txtTotaltTrippelbogeyProc.ForeColor = Color.Blue;
                        }

                        if (rad["Antal Andra"].ToString() != "")
                        {
                            txtTotaltAndra.Text = "N".Formatera(int.Parse(rad["Antal Andra"].ToString()));
                            txtTotaltAndraProc.Text = "ND1".Formatera(
                                decimal.Parse(rad["Antal Andra"].ToString())
                                / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtTotaltAndra.ForeColor = Color.Blue;
                            txtTotaltAndraProc.ForeColor = Color.Blue;
                        }
                        break;
                }
            }
        }

        #endregion

        #region "Händelsehanterare
        private void Gruppanalys_Load(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            InitieraTexter();
            this.MdiParent = MdiMain;
            statistikHuvudKontroll1.Focus();
            FormsLaddar = false;
            Timglas.DefaultCursor();
        }

        /// <summary>
        /// Hanterar Sök-knappen
        /// 
        /// Användaren måste ha valt både spelare och bana för att statistiken ska visas.
        /// </summary>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            int spelarID;
            string golfklubbNr;
            string banaNr;
            DateTime fromDatum;
            DateTime tomDatum;
            bool hcprond = false;
            bool niohalsrond = false;
            bool sallskapsrond = false;
            bool tavlingsrond = false;
            Hooker.Affärslager.Statistik statistik;

            try
            {
                Timglas.WaitCurson();
                if (statistikHuvudKontroll1.SpelarID == 0)
                {
                    VisaFelmeddelande("SPELAREMISSING");
                }
                else
                {
                    NollställTextboxar();
                    statistik = new Hooker.Affärslager.Statistik();
                    spelarID = statistikHuvudKontroll1.SpelarID;

                    if (statistikHuvudKontroll1.GolfklubbNr.ToString().Equals("0"))
                    {
                        golfklubbNr = "";
                    }
                    else
                    {
                        golfklubbNr = statistikHuvudKontroll1.GolfklubbNr.ToString();
                    }

                    if (statistikHuvudKontroll1.BanaNr.ToString().Equals("0"))
                    {
                        banaNr = "";
                    }
                    else
                    {
                        banaNr = statistikHuvudKontroll1.BanaNr.ToString();
                    }

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

                    gruppanalysDS = statistik.Gruppanalys(golfklubbNr, banaNr, spelarID.ToString(), fromDatum, tomDatum,
                        hcprond, niohalsrond, sallskapsrond, tavlingsrond);

                    if (gruppanalysDS.Tables["Antal"].Rows[0]["Antal rundor"].ToString() != "0")
                    {
                        VisaResultat();
                    }
                    else
                    {
                        VisaFelmeddelande("RNDSMISSING");
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
            finally
            {
                Timglas.DefaultCursor();
            }
        }

        /// <summary>
        /// Hanterar Avbryt-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void statistikHuvudKontroll1_OnCboBanaSelect(object sender, EventArgs e)
        {
            this.knappkontroller1_OnKnapp3Click(sender, e);
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

        private void statistikHuvudKontroll1_OnCboGolfklubbSelect(object sender, EventArgs e)
        {
            if (!FormsLaddar)
            {
                if (statistikHuvudKontroll1.BanaNr != 0)
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
        #endregion
    }
}
