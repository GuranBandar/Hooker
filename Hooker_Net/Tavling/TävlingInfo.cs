using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönsterklass för hantering av Tävling
    /// </summary>
    public partial class TävlingInfo : FormBas
    {

        #region Egenskapeer
        /// <summary>
        /// TavlingID
        /// </summary>
        public int TavlingID { get; set; }

        /// <summary>
        /// Objekt för Tävling
        /// </summary>
        public Tavling Tavling { get; set; }

        /// <summary>
        /// Ny Tävling
        /// </summary>
        public bool NyTavling { get; set; }
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
                NyTavling = true;
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
                    FormsUppdaterad = false;
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
            btnAllaBett.Text = Översätt("Text", btnAllaBett.Text);
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
            btnAllaBett.Enabled = false;
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

            if (Tavling.ÄrStängd())
            {
                btnAllaBett.Enabled = true;
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
            txtAntalAnmalda.Text = ("D").Formatera(Tavling.TavlingDeltagare.Length);
            txtPrissumma.Text = ("D").Formatera(Tavling.Prissumma);
            txtNassauBett.Text = ("D").Formatera(Tavling.NassauBett);
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

                if (!string.IsNullOrEmpty(txtNassauBett.Text))
                {
                    if ((txtNassauBett.Text).ÄrEnInt())
                    {
                        Tavling.NassauBett = Convert.ToInt32(txtNassauBett.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtNassauBett.Focus();
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
    }
}
