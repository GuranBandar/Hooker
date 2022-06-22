using Hooker.Affärslager;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Hooker_GUI
{
    public partial class BanaInfo : FormBas
    {
        #region "Händelsehanterare"
        /// <summary>
        /// Hantera visa Golfklubb 
        /// </summary>
        private void knappkontroller1_OnKnapp0Click(object sender, EventArgs e)
        {
            hanteraFönster1.HanteraVisaGolfklubb(Bana.GolfklubbNr.ToString());
        }

        /// <summary>
        /// Hanterar Kopiera-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp1Click(object sender, EventArgs e)
        {
            BanaAktivitet banaAktivitet;
            NyBana = true;
            Bana.BanaNamn = Bana.BanaNamn + " - kopia";

            try
            {
                Timglas.WaitCurson();
                banaAktivitet = new Hooker.Affärslager.BanaAktivitet();
                Bana.BanaNr = banaAktivitet.HämtaMaxBanNr() + 1;
                banaAktivitet.Spara(Bana, NyBana, ref FelID, ref Feltext);
                VisaMeddelande("Information_OK");

                //Nu visar vi banan som den ser ut i databasen
                this.BanaNr = Bana.BanaNr;
                VisaBana();
                this.NyBana = false;
                Timglas.DefaultCursor();
            }
            catch (HookerException)
            {
                if (NyBana)
                {
                    Bana = null;
                }

                VisaFelmeddelande(FelID, Feltext);
            }
            finally
            {
                knappkontroller1.btnKnapp0.Enabled = true;
                knappkontroller1.btnKnapp1.Enabled = false;
                knappkontroller1.btnKnapp2.Enabled = false;
                knappkontroller1.btnKnapp4.Focus();
                FormsUppdaterad = false;
            }
        }

        /// <summary>
        /// Hantera Spara-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            Hooker.Affärslager.BanaAktivitet banaAktivitet;

            try
            {
                Timglas.WaitCurson();
                if (AllaFältIBanaOK() && AllaFältIBanaHalOK())
                {
                    banaAktivitet = new Hooker.Affärslager.BanaAktivitet();
                    banaAktivitet.Spara(Bana, NyBana, ref FelID, ref Feltext);
                    VisaMeddelande("Information_OK");

                    //Nu visar vi banan som den ser ut i databasen

                    if (NyBana)
                    {
                        this.NyBana = false;
                    }
                    VisaBana();
                }
                else
                {
                    //Om fel returnerades ska objektet städas vi nyupplägg
                    if (NyBana)
                    {
                        Bana = null;
                    }
                }
                Timglas.DefaultCursor();
            }
            catch (HookerException)
            {
                if (NyBana)
                {
                    Bana = null;
                }

                VisaFelmeddelande(FelID, Feltext);
            }
            finally
            {
                knappkontroller1.btnKnapp0.Enabled = true;
                knappkontroller1.btnKnapp1.Enabled = false;
                knappkontroller1.btnKnapp2.Enabled = false;
                knappkontroller1.btnKnapp4.Focus();
                FormsUppdaterad = false;
            }
        }

        /// <summary>
        /// Hanterar Ta Bort-Knappen
        /// </summary>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            //Kolla först om rundor finns reggade på banan, 
            //då ska det förstås inte gå att ta bort banan
            Hooker.Affärslager.RundaAktivitet rundaAktivitet = new Hooker.Affärslager.RundaAktivitet();
            int rundor;
            string svar;
            Hooker.Affärslager.BanaAktivitet banaAktivitet;

            try
            {
                rundor = rundaAktivitet.KollaAntaletRundor(Bana.BanaNr);
                if (rundor == 0)
                {
                    svar = VisaFråga("Varning_TABORTBANA");

                    if (svar.Equals("Ja"))
                    {
                        banaAktivitet = new Hooker.Affärslager.BanaAktivitet();
                        banaAktivitet.TaBort(Bana, ref FelID, ref Feltext);
                        VisaMeddelande("Information_OK");
                        this.Close();
                    }
                }
                else
                {
                    VisaFelmeddelande("BANAHARRUNDA");
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
        /// Hanterar Avbryt-Knappen
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
        /// Bilden Load-event
        /// </summary>
        private void Bana_Load(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            InitieraTexter();
            this.MdiParent = MdiMain;
            FormEvent();
            cboGolfklubb.Focus();
            Timglas.DefaultCursor();
        }

        private void FormEvent()
        {
            txtNotering.TextChanged += Bana_Changed;
            foreach (var control in Controls.OfType<Control>())
            {
                control.TextChanged += Bana_Changed;
            }
            foreach (var checkbox in gbxBana.Controls.OfType<CheckBox>())
            {
                checkbox.CheckedChanged += Bana_Changed;
            }
            foreach (var checkbox in gbxAntalHal.Controls.OfType<RadioButton>())
            {
                checkbox.CheckedChanged += Bana_Changed;
            }
            foreach (var textbox in gbxBana.Controls.OfType<Control>())
            {
                textbox.TextChanged += Bana_Changed;
            }
            foreach (var textbox in gbxUt.Controls.OfType<Control>())
            {
                textbox.TextChanged += Bana_Changed;
            }
            foreach (var textbox in gbxIn.Controls.OfType<Control>())
            {
                textbox.TextChanged += Bana_Changed;
            }
            foreach (var textbox in gbxSlopekalkylator.Controls.OfType<Control>())
            {
                textbox.TextChanged += Bana_Changed;
            }
            foreach (var textbox in gbxSlope.Controls.OfType<Control>())
            {
                textbox.TextChanged += Bana_Changed;
            }
            foreach (var textbox in gbxRanking.Controls.OfType<Control>())
            {
                textbox.TextChanged += Bana_Changed;
            }
        }

        private void Bana_Changed(object sender, EventArgs e)
        {
            FormsUppdaterad = true;
            knappkontroller1.btnKnapp1.Enabled = true;
            knappkontroller1.btnKnapp2.Enabled = true;
        }

        /// <summary>
        /// Beräkna antalet erhållna slag efter slopen
        /// </summary>
        private void btnBeraknaSlag_Click(object sender, EventArgs e)
        {
            int banansPar = 0;
            txtErhallnaSlagVit.Text = "";
            txtErhallnaSlagGul.Text = "";
            txtErhallnaSlagBla.Text = "";
            txtErhallnaSlagRod.Text = "";

            try
            {
                for (int i = 0; i < Bana.BanaHal.Length; i++)
                {
                    banansPar = banansPar + Bana.BanaHal[i].Par;
                }

                if (((txtExaktHcp.Text).BytUtPunkt().ÄrEnIckeNegativDecimal()) == true)
                {
                    if (rbnMan.Checked)
                    {
                        if (Bana.CrHerrarGul > 0)
                        {
                            txtErhallnaSlagGul.Text =
                                Hooker.Affärslager.Slope.RäknaUtErhållnaSlag(Bana.CrHerrarGul,
                                Bana.SlopeHerrarGul, banansPar,
                                decimal.Parse((txtExaktHcp.Text).BytUtPunkt()),
                                ref Feltext).ToString();
                        }
                        if (Bana.CrHerrarRod > 0)
                        {
                            txtErhallnaSlagRod.Text =
                                Hooker.Affärslager.Slope.RäknaUtErhållnaSlag(Bana.CrHerrarRod,
                                Bana.SlopeHerrarRod, banansPar,
                                decimal.Parse((txtExaktHcp.Text).BytUtPunkt()),
                                ref Feltext).ToString();
                        }
                        if (Bana.CrHerrarGul == 0 && Bana.CrHerrarRod == 0)
                        {
                            txtErhallnaSlagGul.Text =
                                Hooker.Affärslager.Slope.RäknaUtErhållnaSlag(0, 0, banansPar,
                                decimal.Parse((txtExaktHcp.Text).BytUtPunkt()),
                                ref Feltext).ToString();
                        }
                    }
                    if (rbnKvinna.Checked)
                    {
                        if (Bana.CrDamerGul > 0)
                        {
                            txtErhallnaSlagGul.Text =
                                Hooker.Affärslager.Slope.RäknaUtErhållnaSlag(Bana.CrDamerGul,
                                Bana.SlopeDamerGul, banansPar,
                                decimal.Parse((txtExaktHcp.Text).BytUtPunkt()),
                                ref Feltext).ToString();
                        }
                        if (Bana.CrDamerRod > 0)
                        {
                            txtErhallnaSlagRod.Text =
                                Hooker.Affärslager.Slope.RäknaUtErhållnaSlag(Bana.CrDamerRod,
                                Bana.SlopeDamerRod, banansPar,
                                decimal.Parse((txtExaktHcp.Text).BytUtPunkt()),
                                ref Feltext).ToString();
                        }
                        if (Bana.CrDamerGul == 0 && Bana.CrDamerRod == 0)
                        {
                            txtErhallnaSlagRod.Text =
                                Hooker.Affärslager.Slope.RäknaUtErhållnaSlag(0, 0, banansPar,
                                decimal.Parse((txtExaktHcp.Text).BytUtPunkt()),
                                ref Feltext).ToString();
                        }
                    }
                }
                else
                {
                    VisaFelmeddelande("NOTNUMERIC");
                    txtExaktHcp.Focus();
                }
            }
            catch (HookerException)
            {
                VisaFelmeddelande(FelID);
            }
        }

        /// <summary>
        /// Anändaren har klickat på länken till klubbens hemsida
        /// </summary>
        private void lnkHemsida_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Windows.Forms.WebBrowser web = new System.Windows.Forms.WebBrowser();

            try
            {
                System.Diagnostics.Process.Start("microsoft-edge:http://" + txtHemsida.Text);
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Användaren har klickat på golfbanacombon
        /// </summary>
        private void cboGolfklubb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GolfklubbAktivitet golfklubbAktivitet = new GolfklubbAktivitet();
            int golfblubbNr = ((ComboBoxPar)cboGolfklubb.SelectedItem).Identifier;
            Golfklubb = golfklubbAktivitet.HämtaGolfklubb(golfblubbNr);

            if (Golfklubb != null)
            {
                cboLand.SelectedItem = Golfklubb.Landkod;
                FyllDistriktCombo(Golfklubb.Landkod);
                cboDistrikt.SelectedItem = Golfklubb.Distriktkod;
                cboLand.Enabled = false;
                cboDistrikt.Enabled = false;
                txtBanaNamn.Focus();
            }
        }
        #endregion
    }
}
