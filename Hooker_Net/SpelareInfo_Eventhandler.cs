using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Hooker_GUI
{
    public partial class SpelareInfo : FormBas
    {
        private void Spelare_Load(object sender, EventArgs e)
        {
            InitieraTexter();
            this.MdiParent = MdiMain;
            this.FormEvent();
            txtNamn.Focus();
            Timglas.DefaultCursor();
        }

        /// <summary>
        /// Hanterar Spara & stäng-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp1Click(object sender, EventArgs e)
        {
            this.knappkontroller1_OnKnapp2Click(sender, e);
            this.Close();
        }

        /// <summary>
        ///     Hantera Spara-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            Hooker.Affärslager.SpelareAktivitet spelareAktivitet;

            try
            {
                Timglas.WaitCurson();

                if (AllaFältOK())
                {
                    spelareAktivitet = new Hooker.Affärslager.SpelareAktivitet();
                    spelareAktivitet.Spara(Spelare, NySpelare, ref FelID, ref Feltext);
                    VisaMeddelande("Information_OK");

                    //Nu visar vi Spelaren som den ser ut i databasen
                    if (NySpelare)
                    {
                        this.NySpelare = false;
                        knappkontroller1.btnKnapp3.Enabled = true;
                    }

                    VisaSpelare();
                }
                else
                {
                    //Om fel returnerades ska objektet städas vid nyupplägg
                    if (NySpelare)
                    {
                        Spelare = null;
                    }
                }
                Timglas.DefaultCursor();
            }
            catch (HookerException)
            {
                if (NySpelare)
                {
                    Spelare = null;
                }
                VisaFelmeddelande(FelID, Feltext);
            }
        }

        /// <summary>
        ///     Hanterar Ta Bort-Knappen
        /// </summary>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            //Kolla först om rundor finns reggade på spelaren, 
            //då ska det förstås inte gå att ta bort spelaren
            Hooker.Affärslager.RundaAktivitet rundaAktivitet = new Hooker.Affärslager.RundaAktivitet();
            int rundor;
            string svar;
            SpelareAktivitet spelareAktivitet;

            try
            {
                rundor = rundaAktivitet.KollaAntaletRundorForSpelare(Spelare.AktuelltSpelarID);
                if (rundor == 0)
                {
                    svar = VisaFråga("Varning_TABORTSPELARE");

                    if (svar.Equals("Ja"))
                    {
                        spelareAktivitet = new Hooker.Affärslager.SpelareAktivitet();
                        spelareAktivitet.TaBort(Spelare, ref FelID, ref Feltext);
                        VisaMeddelande("Information_OK");
                        this.Close();
                    }
                }
                else
                {
                    VisaFelmeddelande("SPELAREHARRUNDA");
                }
            }
            catch (HookerException)
            {
                VisaFelmeddelande(FelID, Feltext);
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        ///     Hanterar Avbryt-Knappen
        /// </summary>
        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            string svar;

            if (FormsUppdaterad)
            {
                svar = VisaFråga("Varning_UppdateringGjord");
                if (svar.Equals("Ja"))
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// Användaren har klickat på länken till "Min Golf" på golf.se
        /// </summary>
        private void lnkMinGolf_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Timglas.WaitCurson();
                base.StartWebbrowser("mingolf.golf.se");
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
            Timglas.DefaultCursor();
        }

        /// <summary>
        /// Visa Rundanotering vid högerklick i grafen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chaHcplista_MouseClick(object sender, MouseEventArgs e)
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
                            if (typ == "R" || typ == "M")
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
        private void chaHcplista_MouseDoubleClick(object sender, MouseEventArgs e)
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

        /// <summary>
        /// Hämta Rundanr vid klick i grafen
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private string ClickPoint(MouseEventArgs e)
        {
            string rundaNr = "";
            HitTestResult clicked = new HitTestResult();
            //check where you clicked, returns different information like the clicked series name and the index of the clicked point
            clicked = chaHcplista.HitTest(e.X, e.Y);

            if (clicked.PointIndex != -1)
            {
                try
                {
                    if (chaHcplista.Series[clicked.Series.Name] == null)
                    {
                        rundaNr = "0";
                    }
                    else
                    {
                        //this is how you get your y-Value
                        rundaNr = chaHcplista.Series[clicked.Series.Name].
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
        /// Metod för att sätta 
        /// </summary>
        private void FormEvent()
        {
            foreach (var control in Controls.OfType<Control>())
            {
                control.Click += Spelare_Changed;
            }
            foreach (var hcpControl in gbxhandicap.Controls.OfType<Control>())
            {
                hcpControl.Click += Spelare_Changed;
            }
            foreach (var spelarInfo in gbxSpelarinfo.Controls.OfType<Control>())
            {
                spelarInfo.Click += Spelare_Changed;
            }
            foreach (var kon in gbxKon.Controls.OfType<RadioButton>())
            {
                kon.CheckedChanged += Spelare_Changed;
            }
            foreach (var cha in chaHcplista.Controls.OfType<MouseButtons>())
            {
                return;
            }
        }

        /// <summary>
        /// Känner av om användaren har fipplat i fönstret, aktiverara Spara-knappen.
        /// </summary>
        private void Spelare_Changed(object sender, EventArgs e)
        {
            FormsUppdaterad = true;
            knappkontroller1.btnKnapp1.Enabled = true;
            knappkontroller1.btnKnapp2.Enabled = true;
        }

        private void cboGolfklubb_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormsUppdaterad = true;
            knappkontroller1.btnKnapp1.Enabled = true;
            knappkontroller1.btnKnapp2.Enabled = true;

            if (NySpelare)
            {
                Spelare = new Spelare();
            }

            Spelare.GolfklubbNr = ((ComboBoxPar)cboGolfklubb.SelectedItem).Identifier;
            FyllBanorCombo();
        }
    }
}
