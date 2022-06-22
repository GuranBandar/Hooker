using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using Hooker_GUI.Kontroller;
using Hooker.Affärslager;
using Hooker.Gemensam;
using Hooker.Affärsobjekt;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönsterklass för hantering av Tävling
    /// </summary>
    public partial class TävlingInfo : FormBas
    {
        #region "Medlemsvariabler"
        private int _tavlingID;
        Tavling _tavling;
        private bool _nyTavling;
        private bool _tavlingUppdaterad = false;
        #endregion

        #region Egenskapeer
        /// <summary>
        /// TavlingID
        /// </summary>
        public int TavlingID
        {
            get
            {
                return _tavlingID;
            }
            set
            {
                _tavlingID = value;
            }
        }

        /// <summary>
        /// Objekt för Tävling
        /// </summary>
        public Tavling Tavling
        {
            get
            {
                return _tavling;
            }
            set
            {
                _tavling = value;
            }
        }

        /// <summary>
        /// Ny Tävling
        /// </summary>
        public bool NyTavling
        {
            get
            {
                return _nyTavling;
            }
            set
            {
                _nyTavling = value;
            }
        }
        #endregion

        /// <summary>
        /// Defaultkonstruktor
        /// </summary>
        public TävlingInfo()
        {
            FormsLaddar = true;
            InitializeComponent();
        }

        #region "Publika metoder"
        /// <summary>
        /// Ny tävling initieras
        /// </summary>
        public void InitieraNyTavling()
        {
            try
            {
                _nyTavling = true;
                dtpStartdatum.Text = ("STD").Formatera(DateTime.Today.AddMonths(1));
                dtpAnmalanTidigast.Text = null;
                dtpAnmalanSenast.Text = "";
                dtpStartlistaPubliceras.Text = "";
                dtpForstaStart.Text = "";
                GömKontroller();
                FyllComboBoxKod(cboStatus, Kodtabell.Tävlingsstatus, "SK");
                FyllComboBoxKod(cboSpelsatt, Kodtabell.Spelsätt, "S");
                FyllComboBoxKod(cboSpeltyp, Kodtabell.Speltyper, "SS");
                FyllComboBoxKod(cboOppenFor, Kodtabell.ÖppenFör, "A");
                FyllComboBoxKod(cboPrincipForOveranmalan, Kodtabell.PrincipForOveranmalan, "A");
                knappkontroller1.btnKnapp0.Enabled = false;
                knappkontroller1.btnKnapp1.Enabled = false;
                knappkontroller1.btnKnapp2.Enabled = false;
                knappkontroller1.btnKnapp3.Enabled = false;
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hämta info i databasen och presentera
        /// </summary>
        public void VisaTavling()
        {
            TavlingAktivitet tavlingAktivitet = new TavlingAktivitet();
            try
            {
                Tavling = tavlingAktivitet.HämtaTavlingAllt(TavlingID);

                if (Tavling != null)
                {
                    GömKontroller();
                    FyllComboBoxKod(cboStatus, Kodtabell.Tävlingsstatus, Tavling.TavlingStatus);
                    FyllComboBoxKod(cboSpelsatt, Kodtabell.Spelsätt, Tavling.Spelsatt);
                    FyllComboBoxKod(cboSpeltyp, Kodtabell.Speltyper, Tavling.Speltyp);
                    FyllComboBoxKod(cboOppenFor, Kodtabell.ÖppenFör, Tavling.OppenFor);
                    FyllComboBoxKod(cboPrincipForOveranmalan, Kodtabell.PrincipForOveranmalan, Tavling.PrincipForOveranmalan);
                    FyllBild();

                    if (Tavling.ÄrSkapad())
                    {
                        knappkontroller1.btnKnapp1.Enabled = true;
                    }
                    else
                    {
                        knappkontroller1.btnKnapp1.Enabled = false;
                    }

                    knappkontroller1.btnKnapp0.Enabled = false;
                    knappkontroller1.btnKnapp2.Enabled = false;
                    _tavlingUppdaterad = false;
                    knappkontroller1.btnKnapp3.Enabled = true;
                    dtpStartdatum.Focus();
                    FormsLaddar = false;
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        #endregion

        #region "Privata metoder"
        /// <summary>
        ///     Alla texter hämtas och knapparna initieras
        /// </summary>
        private void InitieraTexter()
        {
            this.Text = Översätt("Text", this.Text);

            foreach (System.Windows.Forms.Control cc in this.Controls)
            {
                if (cc.Controls.Count == 0)
                {
                    if (cc.Name.StartsWith("lbl") | cc.Name.StartsWith("gbx") | cc.Name.StartsWith("btn"))
                    {
                        cc.Text = Översätt("Text", cc.Text);
                    }
                }
                else
                {
                    if (cc.Name.StartsWith("gbx"))
                    {
                        cc.Text = Översätt("Text", cc.Text);
                    }
                    for (int i = 0; i < cc.Controls.Count; i++)
                    {
                        if (cc.Controls[i].Name.StartsWith("lbl"))
                        {
                            cc.Controls[i].Text = Översätt("Text", cc.Controls[i].Text);
                        }
                    }
                }
            }
            btnKlassInfo.Text = Översätt("Text", btnKlassInfo.Text);
            btnAnmalan.Text = Översätt("Text", btnAnmalan.Text);
            btnDeltagarlista.Text = Översätt("Text", btnDeltagarlista.Text);
            btnStartlista.Text = Översätt("Text", btnStartlista.Text);
            btnResultatlista.Text = Översätt("Text", btnResultatlista.Text);
            btnNassau.Text = Översätt("Text", btnNassau.Text);
            btnTrofen.Text = Översätt("Text", btnTrofen.Text);
            btnR2A.Text = Översätt("Text", btnR2A.Text);
            knappkontroller1.btnKnapp0.Enabled = false;
            knappkontroller1.btnKnapp1.Enabled = false;

            if (Tavling != null)
            {
                if (Tavling.ÄrSkapad())
                {
                    knappkontroller1.btnKnapp1.Enabled = true;
                }
            }

            knappkontroller1.btnKnapp0.Text = Översätt("Text", "Knapp_Spara_o_Stäng");
            knappkontroller1.btnKnapp1.Text = Översätt("Text", "Knapp_NyKlass");
            knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_Spara");
            knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_TaBort");
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
        }

        /// <summary>
        /// Göm knapparna för Tävlingen
        /// </summary>
        private void GömKontroller()
        {
            btnKlassInfo.Enabled = false;
            btnAnmalan.Enabled = false;
            btnDeltagarlista.Enabled = false;
            btnStartlista.Enabled = false;
            btnResultatlista.Enabled = false;
            btnNassau.Enabled = false;
            btnTrofen.Enabled = false;
            btnR2A.Enabled = false;
            tavlingAnmalanKontroll1.Visible = false;
            tavlingKlassKontroll1.Visible = false;
        }

        /// <summary>
        /// Hanterar knappar för Tävlingen
        /// </summary>
        private void HanteraKnappar()
        {
            if (Tavling.HarTavlingKlass())
            {
                btnKlassInfo.Enabled = true;
            }

            if (Tavling.ÄrÖppenFörAnmälan())
            {
                btnAnmalan.Enabled = true;
                btnDeltagarlista.Enabled = true;
            }

            if (Tavling.ÄrStängdFörAnmälan())
            {
                btnDeltagarlista.Enabled = true;
            }

            if (Tavling.HarTavlingStartlista())
            {
                btnDeltagarlista.Enabled = true;
                btnStartlista.Enabled = true;
            }

            if ((Tavling.ÄrPågående() && Tavling.HarTavlingRondResultat()) || Tavling.ÄrStängd())
            {
                btnResultatlista.Enabled = true;
                btnNassau.Enabled = true;
                btnTrofen.Enabled = true;
                btnR2A.Enabled = true;
            }
        }

        /// <summary>
        /// Bilden fylls med tävlingens data från databasen
        /// </summary>
        private void FyllBild()
        {
            dtpStartdatum.Text = ("STD").Formatera(DateTime.Parse(Tavling.StartDatum.ToShortDateString()));
            txtTavlingNamn.Text = Tavling.Namn;

            if (Tavling.FleraBanor == "1")
            {
                cbxFleraBanor.Checked = true;
            }

            dtpAnmalanTidigast.Text = ("STD").Formatera(DateTime.Parse(Tavling.AnmalanTidigast.ToShortDateString()));
            dtpAnmalanSenast.Text = ("STD").Formatera(DateTime.Parse(Tavling.AnmalanSenast.ToShortDateString()));
            dtpStartlistaPubliceras.Text = ("STD").Formatera(DateTime.Parse(Tavling.StartlistaPubliceras.ToShortDateString()));
            txtMaxAntal.Text = ("D").Formatera(Tavling.MaxAntalAnmalda);
            txtPrissumma.Text = ("D").Formatera(Tavling.Prissumma);
            txtGreenfee.Text = ("D").Formatera(Tavling.Greenfee);
            txtStartavgift.Text = ("D").Formatera(Tavling.Startavgift);
            dtpForstaStart.Text = ("STD").Formatera(DateTime.Parse(Tavling.ForstaStart.ToShortDateString()));
            txtNotering.Text = Tavling.Notering;

            if (Tavling.HarTavlingKlass())
            {
                if (Tavling.TavlingKlass[0].Spelform.Trim() == "R2")
                {
                    btnR2A.BringToFront();
                    btnTrofen.SendToBack();
                }
                else
                {
                    btnTrofen.BringToFront();
                    btnR2A.SendToBack();
                }
                tavlingKlassKontroll1.Tavling = Tavling;
                tavlingKlassKontroll1.VisaTavlingKlassInfo();
                tavlingKlassKontroll1.Visible = true;
                tangentkontroll1.Enabled = true;
            }

            this.HanteraKnappar();
        }


        /// <summary>
        /// Gå igenom alla fält i bilden för Tävling innan uppdatering
        /// </summary>
        /// <returns>True om OK annars false</returns>
        private bool AllaFältOK()
        {
            try
            {
                if (NyTavling)
                {
                    Tavling = new Tavling();
                }

                //Alla fält från bilden flyttas till objektet
                Tavling.StartDatum = dtpStartdatum.Value;

                if (string.IsNullOrEmpty(txtTavlingNamn.Text))
                {
                    VisaFelmeddelande("TAVLINGNAMNSAKNAS");
                    txtTavlingNamn.Focus();
                    return false;
                }
                else
                {
                    Tavling.Namn = txtTavlingNamn.Text;
                }

                if (cbxFleraBanor.Checked == true)
                {
                    Tavling.FleraBanor = "1";
                }
                else
                {
                    Tavling.FleraBanor = "0";
                }

                Tavling.TavlingStatus = ((ComboBoxKod)cboStatus.SelectedItem).Kod;
                Tavling.Spelsatt = ((ComboBoxKod)cboSpelsatt.SelectedItem).Kod;
                Tavling.Speltyp = ((ComboBoxKod)cboSpeltyp.SelectedItem).Kod;
                Tavling.OppenFor = ((ComboBoxKod)cboOppenFor.SelectedItem).Kod;
                Tavling.AnmalanTidigast = dtpAnmalanTidigast.Value;
                Tavling.AnmalanSenast = dtpAnmalanSenast.Value;
                Tavling.StartlistaPubliceras = dtpStartlistaPubliceras.Value;
                Tavling.ForstaStart = dtpForstaStart.Value;

                if ((txtMaxAntal.Text).ÄrEnInt())
                {
                    Tavling.MaxAntalAnmalda = int.Parse(txtMaxAntal.Text);
                }
                else
                {
                    VisaFelmeddelande("NOTNUMERIC");
                    txtMaxAntal.Focus();
                    return false;
                }

                Tavling.PrincipForOveranmalan = ((ComboBoxKod)cboPrincipForOveranmalan.SelectedItem).Kod;

                if (!string.IsNullOrEmpty(txtPrissumma.Text))
                {
                    if ((txtPrissumma.Text).ÄrEnInt())
                    {
                        Tavling.Prissumma = Convert.ToInt32(txtPrissumma.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtPrissumma.Focus();
                        return false;
                    }
                }

                if (txtNotering.Text.Trim().Length > 120)
                {
                    Tavling.Notering = txtNotering.Text.Trim().Substring(0, 120);
                }
                else
                {
                    Tavling.Notering = txtNotering.Text.Trim();
                }

                Tavling.UppdatDatum = DateTime.Today.Date;
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
                return false;
            }
            return true;
        }
        #endregion

        #region "Händelsehanterare"
        private void TävlingInfo_Load(object sender, EventArgs e)
        {
            this.InitieraTexter();
            this.MdiParent = MdiMain;
            _tavlingUppdaterad = false;
            dtpStartdatum.Focus();
            FormsLaddar = false;
            GömKontroller();
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
            int anmalda;
            string svar;
            TavlingAktivitet tavlingAktivitet = new TavlingAktivitet();

            try
            {
                anmalda = tavlingAktivitet.KollaAntaletAnmälda(TavlingID);
                svar = VisaFråga("Varning_TABORTTAVLING");

                //Kolla om svaret gäller fast det finns anmälda
                if (svar.Equals("Ja"))
                {
                    if (anmalda != 0)
                    {
                        svar = VisaFråga("Varning_TAVLINGHARANMÄLDA");
                        if (!svar.Equals("Ja"))
                        {
                            return;
                        }
                    }
                    //Ta nu bort tävlingen
                    tavlingAktivitet.TaBort(TavlingID, ref FelID, ref Feltext);
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

            if (_tavlingUppdaterad)
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
        /// Känner av om användaren har fipplat i fönstret, aktiverara Spara-knappen.
        /// </summary>
        private void TävlingInfo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            bool okTangent = false;
            okTangent = tangentkontroll1.KollaTangent(e);

            if (okTangent)
            {
                _tavlingUppdaterad = true;
                knappkontroller1.btnKnapp0.Enabled = true;
                knappkontroller1.btnKnapp2.Enabled = true;
            }

        }

        private void cboSpelsatt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormsLaddar == false)
            {
                _tavlingUppdaterad = true;
                knappkontroller1.btnKnapp0.Enabled = true;
                knappkontroller1.btnKnapp2.Enabled = true;
            }
        }

        private void cboSpeltyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormsLaddar == false)
            {
                _tavlingUppdaterad = true;
                knappkontroller1.btnKnapp0.Enabled = true;
                knappkontroller1.btnKnapp2.Enabled = true;
            }
        }

        private void cboOppenFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormsLaddar == false)
            {
                _tavlingUppdaterad = true;
                knappkontroller1.btnKnapp0.Enabled = true;
                knappkontroller1.btnKnapp2.Enabled = true;
            }
        }

        private void cboPrincipForOveranmalan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormsLaddar == false)
            {
                _tavlingUppdaterad = true;
                knappkontroller1.btnKnapp0.Enabled = true;
                knappkontroller1.btnKnapp2.Enabled = true;
            }
        }

        private void btnAnmalan_Click(object sender, EventArgs e)
        {
            GömKontroller();
            tavlingAnmalanKontroll1.Visible = true;
            tavlingAnmalanKontroll1.Tavling = Tavling;
            tavlingAnmalanKontroll1.VisaTavlingAnmalan();
            btnKlassInfo.Enabled = true;
            HanteraKnappar();   
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
            GömKontroller();
            fönsterhanterare1.HanteraVisaDeltagarlista(Tavling);
            this.VisaTavling();
            HanteraKnappar();
        }

        private void btnStartlista_Click(object sender, EventArgs e)
        {
            GömKontroller();
            fönsterhanterare1.HanteraVisaStartlista(Tavling);
            this.VisaTavling();
            HanteraKnappar();
        }

        private void btnResultatlista_Click(object sender, EventArgs e)
        {
            fönsterhanterare1.HanteraVisaResultatlista(Tavling);
            HanteraKnappar();
            //this.VisaTavling();
        }

        private void btnNassau_Click(object sender, EventArgs e)
        {
            fönsterhanterare1.HanteraVisaNassau(Tavling);
            //this.VisaTavling();
            HanteraKnappar();
        }

        private void btnTrofen_Click(object sender, EventArgs e)
        {
            fönsterhanterare1.HanteraVisaTrofen(Tavling);
            //this.VisaTavling();
            HanteraKnappar();
        }

        private void btnR2A_Click(object sender, EventArgs e)
        {
            fönsterhanterare1.HanteraVisaR2A(Tavling);
            HanteraKnappar();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormsLaddar == false)
            {
                _tavlingUppdaterad = true;
                knappkontroller1.btnKnapp0.Enabled = true;
                knappkontroller1.btnKnapp2.Enabled = true;
            }
        }
        #endregion
    }
}
