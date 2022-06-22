using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Data;
using System.Drawing;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönsterklass för Pusttstatistiken
    /// </summary>
    public partial class Puttstatistik : FormBas
    {
        private DataSet PuttstatistikDS = new DataSet();

        /// <summary>
        /// Konstruktor
        /// </summary>
        public Puttstatistik()
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
                lblAntal.Text = Översätt("Text", lblAntal.Text);
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
                knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_Andelgraf");
                knappkontroller1.btnKnapp2.Enabled = false;
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
            txtAntal.Text = PuttstatistikDS.Tables["Antal"].Rows[0]["Antal rundor"].ToString();

            foreach (DataRow rad in PuttstatistikDS.Tables["Puttstatistik"].Rows)
            {
                switch (rad["Par"].ToString())
                {
                    case "3":
                        //Par 3:or
                        txtPar3Puttsnitt.Text = ("ND1").Formatera(
                            int.Parse(rad["Antal puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()));
                        txtPar3PuttarTotalt.Text = ("N").Formatera(
                            int.Parse(rad["Antal hål"].ToString()));

                        if (rad["Antal 0 puttar"].ToString() != "")
                        {
                            txtPar30Puttar.Text = ("N").Formatera(
                                int.Parse(rad["Antal 0 puttar"].ToString()));
                            txtPar30PuttarProc.Text = ("ND1").Formatera(
                                int.Parse(rad["Antal 0 puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar30Puttar.ForeColor = Color.Red;
                            txtPar30PuttarProc.ForeColor = Color.Red;
                        }

                        if (rad["Antal 1 puttar"].ToString() != "")
                        {
                            txtPar31Puttar.Text = ("N").Formatera(
                                int.Parse(rad["Antal 1 puttar"].ToString()));
                            txtPar31PuttarProc.Text = ("ND1").Formatera(
                                int.Parse(rad["Antal 1 puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar31Puttar.ForeColor = Color.Red;
                            txtPar31PuttarProc.ForeColor = Color.Red;
                        }

                        if (rad["Antal 2 puttar"].ToString() != "")
                        {
                            txtPar32Puttar.Text = ("N").Formatera(
                                int.Parse(rad["Antal 2 puttar"].ToString()));
                            txtPar32PuttarProc.Text = ("ND1").Formatera(
                                int.Parse(rad["Antal 2 puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                        }

                        if (rad["Antal 3 puttar"].ToString() != "")
                        {
                            txtPar33Puttar.Text = ("N").Formatera(
                                int.Parse(rad["Antal 3 puttar"].ToString()));
                            txtPar33PuttarProc.Text = ("ND1").Formatera(
                                int.Parse(rad["Antal 3 puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar33Puttar.ForeColor = Color.Blue;
                            txtPar33PuttarProc.ForeColor = Color.Blue;
                        }

                        if (rad["Antal fler puttar"].ToString() != "")
                        {
                            txtPar3FlerPuttar.Text = ("N").Formatera(
                                int.Parse(rad["Antal fler puttar"].ToString()));
                            txtPar3FlerPuttarProc.Text = ("ND1").Formatera(
                                int.Parse(rad["Antal fler puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar3FlerPuttar.ForeColor = Color.Blue;
                            txtPar3FlerPuttarProc.ForeColor = Color.Blue;
                        }
                        break;
                    case "4":
                        //Par 4:or
                        txtPar4Puttsnitt.Text = ("ND1").Formatera(
                            int.Parse(rad["Antal puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()));
                        txtPar4PuttarTotalt.Text = ("N").Formatera(
                            int.Parse(rad["Antal hål"].ToString()));

                        if (rad["Antal 0 puttar"].ToString() != "")
                        {
                            txtPar40Puttar.Text = ("N").Formatera(
                                int.Parse(rad["Antal 0 puttar"].ToString()));
                            txtPar40PuttarProc.Text = ("ND1").Formatera(
                                int.Parse(rad["Antal 0 puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar40Puttar.ForeColor = Color.Red;
                            txtPar40PuttarProc.ForeColor = Color.Red;
                        }

                        if (rad["Antal 1 puttar"].ToString() != "")
                        {
                            txtPar41Puttar.Text = ("N").Formatera(
                                int.Parse(rad["Antal 1 puttar"].ToString()));
                            txtPar41PuttarProc.Text = ("ND1").Formatera(
                                int.Parse(rad["Antal 1 puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar41Puttar.ForeColor = Color.Red;
                            txtPar41PuttarProc.ForeColor = Color.Red;
                        }

                        if (rad["Antal 2 puttar"].ToString() != "")
                        {
                            txtPar42Puttar.Text = ("N").Formatera(
                                int.Parse(rad["Antal 2 puttar"].ToString()));
                            txtPar42PuttarProc.Text = ("ND1").Formatera(
                                int.Parse(rad["Antal 2 puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                        }

                        if (rad["Antal 3 puttar"].ToString() != "")
                        {
                            txtPar43Puttar.Text = ("N").Formatera(
                                int.Parse(rad["Antal 3 puttar"].ToString()));
                            txtPar43PuttarProc.Text = ("ND1").Formatera(
                                int.Parse(rad["Antal 3 puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar43Puttar.ForeColor = Color.Blue;
                            txtPar43PuttarProc.ForeColor = Color.Blue;
                        }

                        if (rad["Antal fler puttar"].ToString() != "")
                        {
                            txtPar4FlerPuttar.Text = ("N").Formatera(
                                int.Parse(rad["Antal fler puttar"].ToString()));
                            txtPar4FlerPuttarProc.Text = ("ND1").Formatera(
                                int.Parse(rad["Antal fler puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar4FlerPuttar.ForeColor = Color.Blue;
                            txtPar4FlerPuttarProc.ForeColor = Color.Blue;
                        }
                        break;
                    case "5":
                        //Par 5:or
                        txtPar5Puttsnitt.Text = ("ND1").Formatera(
                            int.Parse(rad["Antal puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()));
                        txtPar5PuttarTotalt.Text = ("N").Formatera(
                            int.Parse(rad["Antal hål"].ToString()));

                        if (rad["Antal 0 puttar"].ToString() != "")
                        {
                            txtPar50Puttar.Text = ("N").Formatera(
                                int.Parse(rad["Antal 0 puttar"].ToString()));
                            txtPar50PuttarProc.Text = ("ND1").Formatera(
                                int.Parse(rad["Antal 0 puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar50Puttar.ForeColor = Color.Red;
                            txtPar50PuttarProc.ForeColor = Color.Red;
                        }

                        if (rad["Antal 1 puttar"].ToString() != "")
                        {
                            txtPar51Puttar.Text = ("N").Formatera(
                                int.Parse(rad["Antal 1 puttar"].ToString()));
                            txtPar51PuttarProc.Text = ("ND1").Formatera(
                                int.Parse(rad["Antal 1 puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar51Puttar.ForeColor = Color.Red;
                            txtPar51PuttarProc.ForeColor = Color.Red;
                        }

                        if (rad["Antal 2 puttar"].ToString() != "")
                        {
                            txtPar52Puttar.Text = ("N").Formatera(
                                int.Parse(rad["Antal 2 puttar"].ToString()));
                            txtPar52PuttarProc.Text = ("ND1").Formatera(
                                int.Parse(rad["Antal 2 puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                        }

                        if (rad["Antal 3 puttar"].ToString() != "")
                        {
                            txtPar53Puttar.Text = ("N").Formatera(
                                int.Parse(rad["Antal 3 puttar"].ToString()));
                            txtPar53PuttarProc.Text = ("ND1").Formatera(
                                int.Parse(rad["Antal 3 puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar53Puttar.ForeColor = Color.Blue;
                            txtPar53PuttarProc.ForeColor = Color.Blue;
                        }

                        if (rad["Antal fler puttar"].ToString() != "")
                        {
                            txtPar5FlerPuttar.Text = ("N").Formatera(
                                int.Parse(rad["Antal fler puttar"].ToString()));
                            txtPar5FlerPuttarProc.Text = ("ND1").Formatera(
                                int.Parse(rad["Antal fler puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtPar5FlerPuttar.ForeColor = Color.Blue;
                            txtPar5FlerPuttarProc.ForeColor = Color.Blue;
                        }
                        break;
                    case "9":
                        //Totalt
                        txtTotaltPuttsnittProc.Text = ("ND1").Formatera(
                            int.Parse(rad["Antal puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()));
                        txtTotaltPuttsnitt.Text = ("ND1").Formatera(
                            int.Parse(rad["Antal puttar"].ToString())
                            / decimal.Parse(PuttstatistikDS.Tables["Antal"].Rows[0]["Antal rundor"].ToString()));

                        if (rad["Antal 0 puttar"].ToString() != "")
                        {
                            txtTotalt0Puttar.Text = ("N").Formatera(
                                int.Parse(rad["Antal 0 puttar"].ToString()));
                            txtTotalt0PuttarProc.Text = ("ND1").Formatera(
                                int.Parse(rad["Antal 0 puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtTotalt0Puttar.ForeColor = Color.Red;
                            txtTotalt0PuttarProc.ForeColor = Color.Red;
                        }

                        if (rad["Antal 1 puttar"].ToString() != "")
                        {
                            txtTotalt1Puttar.Text = ("N").Formatera(
                                int.Parse(rad["Antal 1 puttar"].ToString()));
                            txtTotalt1PuttarProc.Text = ("ND1").Formatera(
                                int.Parse(rad["Antal 1 puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtTotalt1Puttar.ForeColor = Color.Red;
                            txtTotalt1PuttarProc.ForeColor = Color.Red;
                        }

                        if (rad["Antal 2 puttar"].ToString() != "")
                        {
                            txtTotalt2Puttar.Text = ("N").Formatera(
                                int.Parse(rad["Antal 2 puttar"].ToString()));
                            txtTotalt2PuttarProc.Text = ("ND1").Formatera(
                                int.Parse(rad["Antal 2 puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                        }

                        if (rad["Antal 3 puttar"].ToString() != "")
                        {
                            txtTotalt3Puttar.Text = ("N").Formatera(
                                int.Parse(rad["Antal 3 puttar"].ToString()));
                            txtTotalt3PuttarProc.Text = ("ND1").Formatera(
                                int.Parse(rad["Antal 3 puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtTotalt3Puttar.ForeColor = Color.Blue;
                            txtTotalt3PuttarProc.ForeColor = Color.Blue;
                        }

                        if (rad["Antal fler puttar"].ToString() != "")
                        {
                            txtTotaltFlerPuttar.Text = ("N").Formatera(
                                int.Parse(rad["Antal fler puttar"].ToString()));
                            txtTotaltFlerPuttarProc.Text = ("ND1").Formatera(
                                int.Parse(rad["Antal fler puttar"].ToString())
                            / decimal.Parse(rad["Antal hål"].ToString()) * 100);
                            txtTotaltFlerPuttar.ForeColor = Color.Blue;
                            txtTotaltFlerPuttarProc.ForeColor = Color.Blue;
                        }
                        break;
                }
            }
        }

        #endregion

        #region "Händelsehanterare"
        private void Puttar_Load(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            InitieraTexter();
            this.MdiParent = MdiMain;
            statistikHuvudKontroll1.Focus();
            FormsLaddar = false;
            Timglas.DefaultCursor();
        }

        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            fönsterhanterare1.HanteraVisaAndelgraf(PuttstatistikDS);
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

                    PuttstatistikDS = statistik.Puttstatistik(golfklubbNr, banaNr, spelarID.ToString(), fromDatum, tomDatum,
                        hcprond, niohalsrond, sallskapsrond, tavlingsrond);

                    if (PuttstatistikDS.Tables["Antal"].Rows[0]["Antal rundor"].ToString() != "0")
                    {
                        knappkontroller1.btnKnapp2.Enabled = true;
                        VisaResultat();
                        knappkontroller1.btnKnapp2.Enabled = true;
                    }
                    else
                    {
                        knappkontroller1.btnKnapp2.Enabled = false;
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
