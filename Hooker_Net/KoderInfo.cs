using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;

namespace Hooker_GUI
{
    /// <summary>
    ///     Fönsterklass för Koder
    /// </summary>
    public partial class KoderInfo : FormBas
    {
        #region "Egenskaper"
        /// <summary>
        ///     Typ, del av nyckel till Koder
        /// </summary>
        public int Typ { get; set; }

        /// <summary>
        ///     Argument, den andra delen av nyckeln till Koder
        /// </summary>
        public string Argument { get; set; }

        /// <summary>
        /// Objekt för Koder
        /// </summary>
        public Koder koder { get; set; }

        /// <summary>
        /// Ny Kodargument
        /// </summary>
        public bool NyKodArgument { get; set; }

        /// <summary>
        /// Ny Kodtyp
        /// </summary>
        public bool NyKodtyp { get; set; }
        #endregion

        /// <summary>
        ///     Konstruktor
        /// </summary>
        public KoderInfo()
        {
            InitializeComponent();
        }

        #region "Publika metoder"
        /// <summary>
        ///     Hämta info i databasen och presentera
        /// </summary>
        public void VisaKoder()
        {
            Hooker.Affärslager.KoderAktivitet koderAktivitet = new Hooker.Affärslager.KoderAktivitet();
            try
            {
                koder = koderAktivitet.HämtaKoder(Typ, Argument);

                if (koder != null)
                {
                    FyllBild();
                    FyllComboBoxKod(cboKodtyper, Kodtabell.Alla_koder, Typ.ToString());
                    cboKodtyper.Focus();
                    knappkontroller1.btnKnapp1.Enabled = false;
                    knappkontroller1.btnKnapp2.Enabled = false;
                    FormsUppdaterad = false;
                }
                else
                {
                    //Kan vara borttagen
                    VisaFelmeddelande("KODMISSING");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        ///     Ny kod initieras
        /// </summary>
        public void InitieraNykod()
        {
            Hooker.Affärslager.KoderAktivitet koderAktivitet = new Hooker.Affärslager.KoderAktivitet();
            try
            {
                koder = koderAktivitet.HämtaKoder("0", Typ.ToString());
                FyllComboBoxKod(cboKodtyper, Kodtabell.Alla_koder, Typ.ToString());

                if (NyKodtyp)
                {
                    //Om ny Kodtyp ska skapas
                    Argument = cboKodtyper.Items.Count.ToString();
                    txtArgument.Text = Argument;
                }

                //Om typen är 1, dvs Distrikt, ska textboxen för Argument innehålla landkoden
                if (Typ == (int)Kodtabell.Distrikt)
                {
                    txtArgument.ReadOnly = false;
                }
                else
                {
                    txtArgument.ReadOnly = false;
                }

                knappkontroller1.btnKnapp2.Enabled = false;
                knappkontroller1.btnKnapp3.Enabled = false;
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
            gbxKoder.Text = Översätt("Text", gbxKoder.Text);
            lblVarde.Text = Översätt("Text", lblVarde.Text);
            lblMinvarde.Text = Översätt("Text", lblMinvarde.Text);
            lblMaxvarde.Text = Översätt("Text", lblMaxvarde.Text);

            foreach (System.Windows.Forms.Control cc in gbxKoder.Controls)
            {
                if (cc.Name.StartsWith("lbl"))
                {
                    //då ska vi flytta lite till textboxen
                    cc.Text = Översätt("Text", cc.Text);
                }
            }

            cboKodtyper.Enabled = false;
            knappkontroller1.btnKnapp0.Visible = false;
            knappkontroller1.btnKnapp1.Text = Översätt("Text", "Knapp_Spara_o_Stäng");
            knappkontroller1.btnKnapp1.Enabled = false;
            knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_Spara");
            knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_TaBort");
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
        }

        /// <summary>
        ///     Bilden fylls med Kodens data från databasen
        /// </summary>
        private void FyllBild()
        {
            txtArgument.Text = koder.Argument.ToString();
            txtArgument.ReadOnly = true;
            txtVarde.Text = koder.Varde.ToString();
            txtMinvarde.Text = ("").Formatera(koder.IntervallMin);
            txtMaxvarde.Text = ("").Formatera(koder.IntervallMax);
        }

        /// <summary>
        ///     Gå igenom alla fält i bilden för Koden innan uppdatering
        /// </summary>
        /// <returns>True om OK annars false</returns>
        private bool AllaFältOK()
        {
            try
            {
                if (NyKodtyp | NyKodArgument)
                {
                    koder.Typ = Convert.ToInt16(((ComboBoxKod)cboKodtyper.SelectedItem).Kod);
                    koder.Argument = txtArgument.Text.ToString().Trim();
                }

                //Alla fält från bilden flyttas till objektet
                if (string.IsNullOrEmpty(txtVarde.Text))
                {
                    return false;
                }
                else
                {
                    koder.Varde = txtVarde.Text.ToString().Trim();
                }

                if (string.IsNullOrEmpty(txtMinvarde.Text.Trim()))
                {
                    koder.IntervallMin = 0;
                }
                else
                {
                    if (((txtMinvarde.Text).BytUtPunkt().ÄrEnIckeNegativDecimal()))
                    {
                        koder.IntervallMin = decimal.Parse((txtMinvarde.Text).BytUtPunkt());
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtMinvarde.Focus();
                        return false;
                    }
                }

                if (string.IsNullOrEmpty(txtMaxvarde.Text.Trim()))
                {
                    koder.IntervallMax = 0;
                }
                else
                {
                    if (((txtMaxvarde.Text).BytUtPunkt().ÄrEnIckeNegativDecimal()))
                    {
                        koder.IntervallMax = decimal.Parse((txtMaxvarde.Text).BytUtPunkt());
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtMaxvarde.Focus();
                        return false;
                    }
                }

                koder.UppdatDatum = DateTime.Today.Date;
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
