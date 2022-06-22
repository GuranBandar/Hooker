using Hooker.Affärslager;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Hooker_GUI
{
    public partial class TävlingInfo : FormBas
    {
        #region "Händelsehanterare"
        private void TävlingInfo_Load(object sender, EventArgs e)
        {
            this.InitieraTexter();
            this.MdiParent = MdiMain;
            FormsUppdaterad = false;
            FormEvent();
            dtpStartdatum.Focus();
            FormsLaddar = false;
            GömKontroller();
        }

        private void FormEvent()
        {
            foreach (var control in Controls.OfType<Control>())
            {
                control.Click += Tavling_Changed;
                control.TextChanged += Tavling_Changed;
            }
            foreach (var tavlingInfo in gbxTavlingInfo.Controls.OfType<Control>())
            {
                tavlingInfo.TextChanged += Tavling_Changed;
            }
            foreach (var tavlingDetaljer in gbxTavlingDetaljer.Controls.OfType<Control>())
            {
                tavlingDetaljer.TextChanged += Tavling_Changed;
            }
        }

        private void Tavling_Changed(object sender, EventArgs e)
        {
            if (FormsLaddar == false)
            {
                FormsUppdaterad = true;
                knappkontroller1.btnKnapp0.Enabled = true;
                knappkontroller1.btnKnapp2.Enabled = true;
            }
        }

        /// <summary>
        /// Hanterar Spara & stäng-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp0Click(object sender, EventArgs e)
        {
            this.knappkontroller1_OnKnapp2Click(sender, e);
            this.Close();
        }

        /// <summary>
        /// Hantera Ny Klass-knappen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void knappkontroller1_OnKnapp1Click(object sender, EventArgs e)
        {
            fönsterhanterare1.HanteraNyTavlingKlass(Tavling);
            this.VisaTavling();
        }

        /// <summary>
        ///     Hantera Spara-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            Hooker.Affärslager.TavlingAktivitet tavlingAktivitet;
            int nyttTavlingID;

            try
            {
                if (AllaFältOK())
                {
                    tavlingAktivitet = new Hooker.Affärslager.TavlingAktivitet();
                    nyttTavlingID = tavlingAktivitet.Spara(Tavling, NyTavling, ref FelID, ref Feltext);
                    VisaMeddelande("Information_OK");

                    //Nu visar vi Tävlingen som den ser ut i databasen
                    if (NyTavling)
                    {
                        this.NyTavling = false;
                        TavlingID = nyttTavlingID;
                        //knappkontroller1.btnKnapp1.Enabled = true;
                    }

                    FormsLaddar = true;
                    VisaTavling();
                }
                else
                {
                    //Om fel returnerades ska objektet städas vid nyupplägg
                    if (NyTavling)
                    {
                        Tavling = null;
                    }
                }
            }
            catch (HookerException)
            {
                if (NyTavling)
                {
                    Tavling = null;
                }
                VisaFelmeddelande(FelID, Feltext);
            }
        }


        /// <summary>
        /// Hanterar Ta Bort-Knappen
        /// </summary>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            //Kolla först om rundor finns reggade på spelaren, 
            //då ska det förstås inte gå att ta bort spelaren
            int anmalda = 0;
            string svar;
            TavlingAktivitet tavlingAktivitet = new TavlingAktivitet();

            try
            {
                svar = VisaFråga("Varning_TABORTTAVLING");

                //Kolla om svaret gäller fast det finns anmälda
                if (svar.Equals("Ja"))
                {
                    if (Tavling.HarTavlingDeltagare())
                    {
                        anmalda = Tavling.TavlingDeltagare.Count();
                    }
                    if (anmalda != 0)
                    {
                        svar = VisaFråga("Varning_TAVLINGHARANMÄLDA");
                        if (!svar.Equals("Ja"))
                        {
                            return;
                        }
                    }
                    //Ta nu bort tävlingen
                    tavlingAktivitet.TaBort(Tavling, ref FelID, ref Feltext);
                    VisaMeddelande("Information_OK");
                    this.Close();
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
        /// Tävlingen ska inte kunna sättas till Statlista publicerad (SP) eller Pågående (PG) 
        /// om startlista saknas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tavling == null)
            {
                return;
            }

            if (Tavling.HarTavlingStartlista())
            {
                return;
            }

            if (((ComboBoxKod)cboStatus.SelectedItem).Kod.Equals("SP") ||
                ((ComboBoxKod)cboStatus.SelectedItem).Kod.Equals("PG"))
            {
                knappkontroller1.btnKnapp2.Enabled = false;
                VisaFelmeddelande("TVLEJSTARTLISTA");
            }
        }

        private void btnAnmalan_Click(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            GömKontroller();
            tavlingAnmalanKontroll1.Visible = true;
            tavlingAnmalanKontroll1.Tavling = Tavling;
            tavlingAnmalanKontroll1.VisaTavlingAnmalan();
            btnKlassInfo.Enabled = true;
            HanteraKnappar();
            Timglas.DefaultCursor();
        }

        private void btnKlassInfo_Click(object sender, EventArgs e)
        {
            GömKontroller();
            if (Tavling.HarTavlingKlass())
            {
                tavlingKlassKontroll1.Visible = true;
                tavlingKlassKontroll1.Tavling = Tavling;
                tavlingKlassKontroll1.VisaTavlingKlassInfo();
            }
            HanteraKnappar();
        }

        private void btnDeltagarlista_Click(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            GömKontroller();
            fönsterhanterare1.HanteraVisaDeltagarlista(Tavling);
            this.VisaTavling();
            HanteraKnappar();
            Timglas.DefaultCursor();
        }

        private void btnStartlista_Click(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            GömKontroller();
            fönsterhanterare1.HanteraVisaStartlista(Tavling);
            this.VisaTavling();
            HanteraKnappar();
            Timglas.DefaultCursor();
        }

        private void btnResultatlista_Click(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            fönsterhanterare1.HanteraVisaResultatlista(Tavling);
            HanteraKnappar();
            Timglas.DefaultCursor();
        }

        private void btnNassau_Click(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            fönsterhanterare1.HanteraVisaNassau(Tavling);
            HanteraKnappar();
            Timglas.DefaultCursor();
        }

        private void btnTrofen_Click(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            fönsterhanterare1.HanteraVisaTrofen(Tavling);
            HanteraKnappar();
            Timglas.DefaultCursor();
        }

        private void btnR2A_Click(object sender, EventArgs e)
        {
            fönsterhanterare1.HanteraVisaR2A(Tavling);
            HanteraKnappar();
        }

        private void btnAllaBett_Click(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            fönsterhanterare1.HanteraVisaAllaBett(Tavling);
            HanteraKnappar();
            Timglas.DefaultCursor();
        }
        #endregion
    }
}
