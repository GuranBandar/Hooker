using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Collections.Generic;

namespace Hooker_GUI
{
    /// <summary>
    /// Förnsterklass för redovisningspost
    /// </summary>
    public partial class RedovisningInfo : FormBas
    {
        #region "Egenskaper"
        /// <summary>
        /// TransNr
        /// </summary>
        public int TransNr { get; set; }

        /// <summary>
        /// Objekt för Redovisning
        /// </summary>
        public Redovisning Redovisning { get; set; }

        /// <summary>
        /// Ny Redovisning
        /// </summary>
        public bool NyRedovisning { get; set; }

        #endregion

        /// <summary>
        /// Defaultkonstruktor
        /// </summary>
        public RedovisningInfo()
        {
            InitializeComponent();
        }

        #region "Publika metoder"
        /// <summary>
        /// Hämta info i databasen och presentera
        /// </summary>
        public void VisaRedovisning()
        {
            RedovisningAktivitet redovisningAktivitet = new RedovisningAktivitet();
            try
            {
                Redovisning = redovisningAktivitet.HämtaRedovisning(TransNr);

                if (Redovisning != null)
                {
                    FyllBild();
                    FyllComboBoxKod(cboRedovisningtyper, Kodtabell.Redovisningstyper, Redovisning.Typ);
                    //FyllRedovisningTypCombo();
                    FyllSpelareCombo();
                    cboRedovisningtyper.Focus();
                    knappkontroller1.btnKnapp2.Enabled = false;
                    FormsUppdaterad = false;
                }
                else
                {
                    //Kan vara borttagen
                    VisaFelmeddelande("REDOVISNINGMISSING");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Ny Redovisning initieras
        /// </summary>
        public void InitieraNyRedovisning()
        {
            RedovisningAktivitet redovisningAktivitet = new RedovisningAktivitet();
            try
            {
                Redovisning = new Redovisning();
                FyllComboBoxKod(cboRedovisningtyper, Kodtabell.Redovisningstyper, "1");
                //FyllRedovisningTypCombo();
                FyllSpelareCombo();

                knappkontroller1.btnKnapp1.Enabled = false;
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
            gbxRedovisning.Text = Översätt("Text", gbxRedovisning.Text);
            lblDatum.Text = Översätt("Text", lblDatum.Text);
            lblSpelare.Text = Översätt("Text", lblSpelare.Text);
            lblBelopp.Text = Översätt("Text", lblBelopp.Text);
            lblRundanr.Text = Översätt("Text", lblRundanr.Text);
            lblNotering.Text = Översätt("Text", lblNotering.Text);

            foreach (System.Windows.Forms.Control cc in gbxRedovisning.Controls)
            {
                if (cc.Name.StartsWith("lbl"))
                {
                    //då ska vi flytta lite till textboxen
                    cc.Text = Översätt("Text", cc.Text);
                }
            }

            knappkontroller1.btnKnapp0.Visible = false;
            knappkontroller1.btnKnapp1.Text = Översätt("Text", "Knapp_Spara_o_Stäng");
            knappkontroller1.btnKnapp1.Enabled = false;
            knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_Spara");
            knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_TaBort");
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
        }

        /// <summary>
        /// Hämta alla redovisningstyper och fyller combon.
        /// </summary>
        private void FyllRedovisningTypCombo()
        {
            List<Koder> koder = null;
            KoderAktivitet koderAktivitet = new KoderAktivitet();

            try
            {
                //Typ = 10, alla redovisningstyper
                koder = koderAktivitet.SökKoder((int)Kodtabell.Redovisningstyper, "", "Varde");

                if (koder.Count > 0)
                {
                    cboRedovisningtyper.Items.Clear();
                    foreach (Koder kodrad in koder)
                    {
                        cboRedovisningtyper.Items.Add(new ComboBoxKod(kodrad.Argument, kodrad.Varde.ToString(),
                            kodrad));
                    }

                    if (NyRedovisning)
                    {
                        cboRedovisningtyper.SelectedItem = "1";
                    }
                    else
                    {
                        cboRedovisningtyper.SelectedItem = Redovisning.Typ;
                    }
                    cboRedovisningtyper.DisplayMember = "visa";
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hämtar alla spelare och fyller combon
        /// </summary>
        private void FyllSpelareCombo()
        {
            List<Spelare> spelare = null;
            SpelareAktivitet spelareAktivitet = new SpelareAktivitet();

            try
            {
                spelare = spelareAktivitet.SökSpelare("", "");

                if (spelare.Count > 0)
                {
                    cboSpelare.Items.Clear();
                    cboSpelare.Items.Add(new ComboBoxPar(0, "", ""));
                    foreach (Spelare gubbe in spelare)
                    {
                        cboSpelare.Items.Add(new ComboBoxPar(gubbe.AktuelltSpelarID, gubbe.Namn, gubbe));
                    }

                    if (NyRedovisning)
                    {
                        cboSpelare.SelectedItem = AppUser.SpelarID;
                    }
                    else
                    {
                        cboSpelare.SelectedItem = int.Parse(Redovisning.SpelarID.ToString());
                    }
                    cboSpelare.DisplayMember = "visa";
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Bilden fylls med Redovisningens data från databasen
        /// </summary>
        private void FyllBild()
        {
            dtpDatum.Text = ("STD").Formatera(DateTime.Parse(Redovisning.Datum.ToShortDateString()));
            txtBelopp.Text = ("").Formatera(Redovisning.Belopp);
            txtRundaNr.Text = ("D").Formatera(Redovisning.RundaNr);
            txtNotering.Text = Redovisning.Notering;
        }

        /// <summary>
        /// Gå igenom alla fält i bilden för Redovisning innan uppdatering
        /// </summary>
        /// <returns>True om OK annars false</returns>
        private bool AllaFältOK()
        {
            try
            {
                if (NyRedovisning)
                {
                    Redovisning = new Redovisning();
                    Redovisning.Typ = ((ComboBoxKod)cboRedovisningtyper.SelectedItem).Kod.ToString();
                    Redovisning.RundaNr = 0;
                    Redovisning.Notering = "";
                }

                //Alla fält från bilden flyttas till objektet
                Redovisning.Datum = dtpDatum.Value;
                Redovisning.SpelarID = ((ComboBoxPar)cboSpelare.SelectedItem).Identifier;

                if ((txtBelopp.Text).ÄrEnDecimal())
                {
                    Redovisning.Belopp = decimal.Parse(txtBelopp.Text);
                }
                else
                {
                    VisaFelmeddelande("NOTNUMERIC");
                    txtBelopp.Focus();
                    return false;
                }

                if (!string.IsNullOrEmpty(txtNotering.Text))
                {
                    if (txtNotering.Text.Trim().Length > 120)
                    {
                        Redovisning.Notering = txtNotering.Text.Trim().Substring(0, 120);
                    }
                    else
                    {
                        Redovisning.Notering = txtNotering.Text.Trim();
                    }
                }

                Redovisning.UppdatDatum = DateTime.Today.Date;
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
