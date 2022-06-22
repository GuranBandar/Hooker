using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönsterklass för hantering av Klassinfo
    /// </summary>
    public partial class KlassInfo : FormBas
    {
        #region "Medlemsvariabler"
        private bool _nyTavlingRond;
        #endregion

        #region Egenskaper
        /// <summary>
        /// TavlingID
        /// </summary>
        public int TavlingID { get; set; }

        /// <summary>
        /// Klass
        /// </summary>
        public string Klass { get; set; }

        /// <summary>
        /// Objekt för Tävling
        /// </summary>
        public Tavling Tavling { get; set; }

        /// <summary>
        /// Objekt för TävlingKlass
        /// </summary>
        private TavlingKlass TavlingKlass { get; set; }

        /// <summary>
        /// Ny TävlingKlass
        /// </summary>
        public bool NyTavlingKlass { get; set; }

        private bool NyTavlingRond { get { return _nyTavlingRond; } set { _nyTavlingRond = value; } }

        private List<Golfklubb> Golfklubbar { get; set; }

        private List<Bana> Banor { get; set; }
        #endregion

        /// <summary>
        /// Deafultkonstruktor
        /// </summary>
        public KlassInfo()
        {
            FormsLaddar = true;
            InitializeComponent();
            dgwRondinfo.Enabled = false;
        }

        #region "Publika metoder"
        /// <summary>
        /// Ny tävlingklass initieras
        /// </summary>
        public void InitieraNyTavlingKlass()
        {
            try
            {
                NyTavlingKlass = true;
                _nyTavlingRond = true;
                TavlingID = Tavling.TavlingID;
                FyllComboBoxKod(cboKlass, Kodtabell.Tävlingsklasser, "A");
                FyllComboBoxKod(cboSpelform, Kodtabell.Spelformer, "PB");
                FyllComboBoxKod(cboKlasstyp, Kodtabell.Klasstyp, "H");
                FyllComboBoxKod(cboKon, Kodtabell.Kön, "B");
                FyllComboBoxKod(cboTeeMan, Kodtabell.Tee, "3");
                FyllComboBoxKod(cboTeeKvinna, Kodtabell.Tee, "1");
                FyllGolfklubbCombo();
                knappkontroller1.btnKnapp1.Enabled = false;
                knappkontroller1.btnKnapp2.Enabled = false;
                knappkontroller1.btnKnapp3.Enabled = false;
                knappkontroller1.btnKnapp4.Enabled = true;
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hämta info i databasen och presentera
        /// </summary>
        public void VisaTavlingKlass()
        {
            try
            {
                TavlingKlass = Tavling.HämtaTavlingKlass(Klass);

                if (TavlingKlass != null)
                {
                    FyllComboBoxKod(cboKlass, Kodtabell.Tävlingsklasser, TavlingKlass.Klass);
                    cboKlass.Enabled = false;
                    FyllComboBoxKod(cboSpelform, Kodtabell.Spelformer, TavlingKlass.Spelform);
                    FyllComboBoxKod(cboKlasstyp, Kodtabell.Klasstyp, TavlingKlass.Klasstyp);
                    FyllComboBoxKod(cboKon, Kodtabell.Kön, TavlingKlass.Kon);
                    FyllComboBoxKod(cboTeeMan, Kodtabell.Tee, TavlingKlass.TeeMan);
                    FyllComboBoxKod(cboTeeKvinna, Kodtabell.Tee, TavlingKlass.TeeKvinna);
                    knappkontroller1.btnKnapp1.Enabled = false;
                    knappkontroller1.btnKnapp2.Enabled = false;
                    knappkontroller1.btnKnapp3.Enabled = true;
                    knappkontroller1.btnKnapp4.Enabled = true;
                    FyllBild();
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                    cboSpelform.Focus();
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
        /// Initierar alla texter på kontrollerna
        /// </summary>
        private void InitieraTexter()
        {
            try
            {
                this.Text = Översätt("Text", this.Text);

                foreach (System.Windows.Forms.Control cc in this.Controls)
                {
                    if (cc.Controls.Count == 0)
                    {
                        if (cc.Name.StartsWith("lbl") | cc.Name.StartsWith("gbx"))
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

                for (int i = 0; i < dgwRondinfo.Columns.Count; i++)
                {
                    dgwRondinfo.Columns[i].HeaderText = Översätt("Text", dgwRondinfo.Columns[i].HeaderText);
                }

                knappkontroller1.btnKnapp0.Visible = false;
                knappkontroller1.btnKnapp1.Text = Översätt("Text", "Knapp_NyKlass");
                knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_Spara");
                knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_TaBort");
                knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        ///     Bilden fylls med Spelarens data från databasen
        /// </summary>
        private void FyllBild()
        {
            txtRonder.Text = TavlingKlass.AntRonder.ToString();

            if (TavlingKlass.OnskemalOmTee.Equals("X"))
            {
                cbxOnskemalOmTee.Checked = true;
            }

            txtAnmalningsavgift.Text = TavlingKlass.Anmalningsavgift.ToString();
            txtTillaggsavgift.Text = TavlingKlass.Tillaggsavgift.ToString();
            txtMinHcpMan.Text = ("ND1").Formatera(TavlingKlass.MinHcpMan);
            txtMaxHcpMan.Text = ("ND1").Formatera(TavlingKlass.MaxHcpMan);
            txtMinHcpKvinna.Text = ("ND1").Formatera(TavlingKlass.MinHcpKvinna);
            txtMaxHcpKvinna.Text = ("ND1").Formatera(TavlingKlass.MaxHcpKvinna);
            txtMinHcpLag.Text = ("ND1").Formatera(TavlingKlass.MinHcpLag);
            txtMaxHcpLag.Text = ("ND1").Formatera(TavlingKlass.MaxHcpLag);
            txtMinAlderMan.Text = ("D").Formatera(TavlingKlass.MinAlderMan);
            txtMaxAlderMan.Text = ("D").Formatera(TavlingKlass.MaxAlderMan);
            txtMinAlderKvinna.Text = ("D").Formatera(TavlingKlass.MinAlderKvinna);
            txtMaxAlderKvinna.Text = ("D").Formatera(TavlingKlass.MaxAlderKvinna);

            if (Tavling.ÄrSkapad())
            {
                knappkontroller1.btnKnapp1.Enabled = true;
            }

            if (Tavling.HarTavlingKlass())
            {
                dgwRondinfo.Enabled = true;
                dgwRondinfo.Focus();
            }

            if (Tavling.HarTavlingRond())
            {
                knappkontroller1.btnKnapp2.Enabled = true;
                GolfklubbAktivitet golfklubbAktivitet = new GolfklubbAktivitet();
                BanaAktivitet banaAktivitet = new BanaAktivitet();

                if (Golfklubbar == null)
                {
                    Golfklubbar = golfklubbAktivitet.SökGolfklubb("", "", "", "");
                }

                if (Banor == null)
                {
                    Banor = banaAktivitet.SökBana("", "", "", "");
                }

                dgwRondinfo.Rows.Clear();
                //DataGridViewComboBoxColumn golfklubbCol = (DataGridViewComboBoxColumn)dgwRondinfo.Columns["Golfklubb"];
                for (int i = 0; i < Tavling.TavlingRond.Length; i++)
                {
                    dgwRondinfo.Rows.Add();
                    dgwRondinfo.Rows[i].Cells["RondID"].Value = Tavling.TavlingRond[i].RondId;
                    dgwRondinfo.Rows[i].Cells["RondNr"].Value = ("D").Formatera(Tavling.TavlingRond[i].RondNr);
                    dgwRondinfo.Rows[i].Cells["Datum"].Value =
                        ("STD").Formatera(DateTime.Parse(Tavling.TavlingRond[i].Datum.ToShortDateString()));
                    dgwRondinfo.Rows[i].Cells["ForstaStartTid"].Value = Tavling.TavlingRond[i].ForstaStartTid;
                    DataGridViewComboBoxCell golfklubbCol =
                        (DataGridViewComboBoxCell)(dgwRondinfo.Rows[i].Cells["Golfklubb"]);
                    golfklubbCol.DataSource = Golfklubbar;
                    golfklubbCol.DisplayMember = "GolfklubbNamn";
                    golfklubbCol.ValueMember = "GolfklubbNr";
                    golfklubbCol.Value = HämtaGolfklubbNrFörBana(Tavling.TavlingRond[i].BanaNr);
                    DataGridViewComboBoxCell banaCol =
                        (DataGridViewComboBoxCell)(dgwRondinfo.Rows[i].Cells["BanaNr"]);
                    banaCol.DataSource = HämtaBanaFörGolfklubb((int)golfklubbCol.Value);
                    banaCol.DisplayMember = "BanaNamn";
                    banaCol.ValueMember = "BanaNr";
                    banaCol.Value = Tavling.TavlingRond[i].BanaNr;
                    dgwRondinfo.Rows[i].Cells["AntalHal"].Value = ("D").Formatera(Tavling.TavlingRond[i].AntalHal);
                    dgwRondinfo.Rows[i].Cells["Cut"].Value = Tavling.TavlingRond[i].Cut;
                }
            }
        }

        /// <summary>
        /// Hämta Golfklubb för bana
        /// </summary>
        /// <param name="banaNr">Aktuellt banaNr</param>
        /// <returns>GolfklubbNr</returns>
        private int HämtaGolfklubbNrFörBana(int banaNr)
        {
            var items = (from item in Banor
                         where item.BanaNr == banaNr
                         select item).FirstOrDefault();
            return items.GolfklubbNr;
        }


        /// <summary>
        /// Hämta banor för Golfklubb
        /// </summary>
        /// <param name="golfklubbNr">Aktuellt golfklubbNr</param>
        /// <returns>Banor</returns>
        private List<Bana> HämtaBanaFörGolfklubb(int golfklubbNr)
        {
            List<Bana> items = (from item in Banor
                                where item.GolfklubbNr == golfklubbNr
                                select item).ToList();
            return items;
        }

        /// <summary>
        /// Gå igenom alla fält i bilden för TavlingKlass innan uppdatering
        /// </summary>
        /// <returns>True om OK annars false</returns>
        private bool AllaFältOK()
        {
            bool finnsKlass = false;
            TavlingKlassAktivitet tavlingKlassAktitivitet;
            try
            {
                Klass = ((ComboBoxKod)cboKlass.SelectedItem).Kod;

                if (NyTavlingKlass)
                {
                    tavlingKlassAktitivitet = new TavlingKlassAktivitet();
                    TavlingKlass = new TavlingKlass(); ;
                    TavlingKlass.TavlingID = Tavling.TavlingID;

                    if (finnsKlass = tavlingKlassAktitivitet.FinnsTavlingKlass(Tavling.TavlingID, Klass))
                    {
                        VisaFelmeddelande("POSTENFINNSREDAN");
                        cboKlass.Focus();
                        return false;
                    }
                }

                //Alla fält från bilden flyttas till objektet
                TavlingKlass.Klass = Klass;
                TavlingKlass.Spelform = ((ComboBoxKod)cboSpelform.SelectedItem).Kod;
                TavlingKlass.Klasstyp = ((ComboBoxKod)cboKlasstyp.SelectedItem).Kod;
                TavlingKlass.Kon = ((ComboBoxKod)cboKon.SelectedItem).Kod;

                if ((txtRonder.Text).ÄrEnInt())
                {
                    TavlingKlass.AntRonder = int.Parse(txtRonder.Text);
                }
                else
                {
                    VisaFelmeddelande("NOTNUMERIC");
                    txtRonder.Focus();
                    return false;
                }

                TavlingKlass.TeeMan = ((ComboBoxKod)cboTeeMan.SelectedItem).Kod;
                TavlingKlass.TeeKvinna = ((ComboBoxKod)cboTeeKvinna.SelectedItem).Kod;

                if (cbxOnskemalOmTee.Checked)
                {
                    TavlingKlass.OnskemalOmTee = "X";
                }
                else
                {
                    TavlingKlass.OnskemalOmTee = "";
                }

                if (!string.IsNullOrEmpty(txtAnmalningsavgift.Text))
                {
                    if ((txtAnmalningsavgift.Text).ÄrEnInt())
                    {
                        TavlingKlass.Anmalningsavgift = int.Parse(txtAnmalningsavgift.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtAnmalningsavgift.Focus();
                        return false;
                    }
                }

                if (!string.IsNullOrEmpty(txtTillaggsavgift.Text))
                {
                    if ((txtTillaggsavgift.Text).ÄrEnInt())
                    {
                        TavlingKlass.Tillaggsavgift = int.Parse(txtTillaggsavgift.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtTillaggsavgift.Focus();
                        return false;
                    }
                }

                if (!string.IsNullOrEmpty(txtMinHcpMan.Text))
                {
                    if ((txtMinHcpMan.Text).ÄrEnDecimal())
                    {
                        TavlingKlass.MinHcpMan = decimal.Parse(txtMinHcpMan.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtMinHcpMan.Focus();
                        return false;
                    }
                }

                if (!string.IsNullOrEmpty(txtMaxHcpMan.Text))
                {
                    if ((txtMaxHcpMan.Text).ÄrEnDecimal())
                    {
                        TavlingKlass.MaxHcpMan = decimal.Parse(txtMaxHcpMan.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtMaxHcpMan.Focus();
                        return false;
                    }
                }
                else
                {
                    TavlingKlass.MaxHcpMan = 36;
                }

                if (!string.IsNullOrEmpty(txtMinHcpKvinna.Text))
                {
                    if ((txtMinHcpKvinna.Text).ÄrEnDecimal())
                    {
                        TavlingKlass.MinHcpKvinna = decimal.Parse(txtMinHcpKvinna.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtMinHcpKvinna.Focus();
                        return false;
                    }
                }

                if (!string.IsNullOrEmpty(txtMaxHcpKvinna.Text))
                {
                    if ((txtMaxHcpKvinna.Text).ÄrEnDecimal())
                    {
                        TavlingKlass.MaxHcpKvinna = decimal.Parse(txtMaxHcpKvinna.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtMaxHcpKvinna.Focus();
                        return false;
                    }
                }
                else
                {
                    TavlingKlass.MaxHcpKvinna = 36;
                }


                if (!string.IsNullOrEmpty(txtMinHcpLag.Text))
                {
                    if ((txtMinHcpLag.Text).ÄrEnDecimal())
                    {
                        TavlingKlass.MinHcpLag = decimal.Parse(txtMinHcpLag.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtMinHcpLag.Focus();
                        return false;
                    }
                }

                if (!string.IsNullOrEmpty(txtMaxHcpLag.Text))
                {
                    if ((txtMaxHcpLag.Text).ÄrEnDecimal())
                    {
                        TavlingKlass.MaxHcpLag = decimal.Parse(txtMaxHcpLag.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtMaxHcpLag.Focus();
                        return false;
                    }
                }

                if (!string.IsNullOrEmpty(txtMinAlderMan.Text))
                {
                    if ((txtMinAlderMan.Text).ÄrEnInt())
                    {
                        TavlingKlass.MinAlderMan = int.Parse(txtMinAlderMan.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtMinAlderMan.Focus();
                        return false;
                    }
                }

                if (!string.IsNullOrEmpty(txtMaxAlderMan.Text))
                {
                    if ((txtMaxAlderMan.Text).ÄrEnInt())
                    {
                        TavlingKlass.MaxAlderMan = int.Parse(txtMaxAlderMan.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtMaxAlderMan.Focus();
                        return false;
                    }
                }
                else
                {
                    TavlingKlass.MaxAlderMan = 99;
                }


                if (!string.IsNullOrEmpty(txtMinAlderKvinna.Text))
                {
                    if ((txtMinAlderKvinna.Text).ÄrEnInt())
                    {
                        TavlingKlass.MinAlderKvinna = int.Parse(txtMinAlderKvinna.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtMinAlderKvinna.Focus();
                        return false;
                    }
                }

                if (!string.IsNullOrEmpty(txtMaxAlderKvinna.Text))
                {
                    if ((txtMaxAlderKvinna.Text).ÄrEnInt())
                    {
                        TavlingKlass.MaxAlderKvinna = int.Parse(txtMaxAlderKvinna.Text);
                    }
                    else
                    {
                        VisaFelmeddelande("NOTNUMERIC");
                        txtMaxAlderKvinna.Focus();
                        return false;
                    }
                }
                else
                {
                    TavlingKlass.MaxAlderKvinna = 99;
                }

                //TavlingKlass.UppdatDatum = DateTime.Today.Date;

                if (NyTavlingKlass)
                {
                    Tavling.AddTavlingKlass(TavlingKlass);
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
                return false;
            }
            return true;
        }
        #endregion

        private void FyllGolfklubbCombo()
        {
            //List<Golfklubb> golfklubbar = null;
            GolfklubbAktivitet golfklubbAktivitet = new GolfklubbAktivitet();

            try
            {
                if (Golfklubbar == null)
                {
                    Golfklubbar = golfklubbAktivitet.SökGolfklubb("", "", "", "");
                }

                if (Golfklubbar != null)
                {
                    DataGridViewComboBoxColumn golfklubbCol =
                        (DataGridViewComboBoxColumn)dgwRondinfo.Columns["Golfklubb"];
                    golfklubbCol.DataSource = Golfklubbar;
                    golfklubbCol.DisplayMember = "GolfklubbNamn";
                    golfklubbCol.ValueMember = "GolfklubbNr";
                    golfklubbCol.DataPropertyName = "GolfklubbNr";
                    dgwRondinfo.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgwRondinfo_EditingControlShowing);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Hämta alla aktuella Banor och fyll combon.
        /// </summary>
        private void FyllBanorCombo(int golfklubbNr)
        {
            List<Bana> bana = null;
            BanaAktivitet banaAktivitet = new BanaAktivitet();

            try
            {
                if (golfklubbNr > 0)
                {
                    bana = banaAktivitet.HämtaAktuellaBanorMedGolfklubbNr(golfklubbNr);

                    if (bana != null && bana.Count > 0)
                    {
                        DataGridViewComboBoxCell banaCell = (DataGridViewComboBoxCell)dgwRondinfo.CurrentRow.Cells["BanaNr"];
                        //DataGridViewComboBoxColumn banaCol = (DataGridViewComboBoxColumn)dgwRondinfo.Columns["BanaNr"];
                        //banaCol.Items.Clear();
                        //for (int i = 0; i <= bana.Count - 1; i++)
                        //{
                        //    banaCol.Items.Add(new ComboBoxPar(bana[i].BanaNr,
                        //        bana[i].BanaNamn + " - " + bana[i].BanaNr, bana[i]));
                        //}
                        //banaCol.DisplayMember = "visa";
                        banaCell.DataSource = bana;
                        banaCell.DisplayMember = "BanaNamn";
                        banaCell.ValueMember = "BanaNr";
                        //banaCell.DataPropertyName = "BanaNr";
                    }
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }


        /// <summary>
        /// Uppdaterar aktuell TavlingRondpost
        /// </summary>
        private bool BehandlaTavlingRond()
        {
            TavlingRond tavlingRond;
            try
            {
                //Hoppa över om inget är uppdaterat på raden
                if (FormsUppdaterad)
                {
                    Tavling.TaBortTavlingRond();

                    foreach (DataGridViewRow dr in dgwRondinfo.Rows)
                    {
                        if (Convert.ToInt16(dr.Cells["RondNr"].Value) > 0)
                        {
                            tavlingRond = new TavlingRond();
                            tavlingRond.TavlingID = Tavling.TavlingID;
                            tavlingRond.Klass = Klass;
                            tavlingRond.RondNr = Convert.ToInt16(dr.Cells["RondNr"].Value);
                            tavlingRond.Datum = Convert.ToDateTime(dr.Cells["Datum"].Value).Date;
                            tavlingRond.ForstaStartTid = (dr.Cells["ForstaStartTid"].Value.ToString().ConvertToTimeSpan());
                            tavlingRond.BanaNr = Convert.ToInt16((dr.Cells["BanaNr"] as DataGridViewComboBoxCell).Value.ToString());
                            tavlingRond.AntalHal = Convert.ToInt16(dr.Cells["AntalHal"].Value);
                            tavlingRond.RondStatus = "AN";

                            if (Functions.ToBool(dr.Cells["Cut"].Value == null))
                            {
                                tavlingRond.Cut = "0";
                            }
                            else if (dr.Cells["Cut"].Value.ToString() == "0")
                            {
                                tavlingRond.Cut = "0";
                            }
                            else
                            {
                                tavlingRond.Cut = "1";
                            }

                            Tavling.AddTavlingRond(tavlingRond);
                        }
                    }
                    SparaTavlingRond(Tavling);
                    FormsUppdaterad = false;
                }
                return true;
            }
            catch (Exception ex)
            {
                FormsUppdaterad = false;
                VisaFelmeddelande("TIDWRONG", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Spara TavlingsRonder
        /// </summary>
        /// <param name="tavling">Aktuella TavlingRonder</param>
        private void SparaTavlingRond(Tavling tavling)
        {
            TavlingRondAktivitet tavlingRondAktivitet = new TavlingRondAktivitet();
            tavlingRondAktivitet.Spara(tavling, ref FelID, ref Feltext);
        }
    }
}
