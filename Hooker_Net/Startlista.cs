using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    public partial class Startlista : FormBas
    {
        #region Medelemsvariabler
        Tavling _tavling;
        DataSet _startlistaDS;
        private int _rondNR;
        #endregion

        #region Egenskaper
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
        /// DataSet för Startlista
        /// </summary>
        public DataSet StartlistaDS
        {
            get
            {
                return _startlistaDS;
            }
            set
            {
                _startlistaDS = value;
            }
        }
        /// <summary>
        /// RondNr
        /// </summary>
        public int RondNR { get { return _rondNR; } set { _rondNR = value; } }
        #endregion

        public Startlista()
        {
            FormsLaddar = true;
            InitializeComponent();
        }

        #region Publika metoder
        /// <summary>
        /// Visar startlistan
        /// </summary>
        public void VisaStartlista()
        {
            dtpStartdatum.Text = ("STD").Formatera(DateTime.Parse(Tavling.StartDatum.ToShortDateString()));
            txtTavlingNamn.Text = Tavling.Namn;
            FyllListan();
            FormsLaddar = false;

            if (StartlistaDS.Tables["Startlista"].Rows.Count > 0 && (Tavling.ÄrPågående() || Tavling.ÄrStängd()))
            {
                knappkontroller1.btnKnapp3.Enabled = false;
            }
            else
            {
                knappkontroller1.btnKnapp3.Enabled = true;
            }
        }
        #endregion

        #region Privata metoder
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

            for (int i = 0; i < dgwStartlista.Columns.Count; i++)
            {
                dgwStartlista.Columns[i].HeaderText = Översätt("Text", dgwStartlista.Columns[i].HeaderText);
            }

            knappkontroller1.btnKnapp0.Visible = false;
            knappkontroller1.btnKnapp1.Visible = false;
            knappkontroller1.btnKnapp2.Visible = false;
            knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_TaBort");
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
        }

        private void FyllListan()
        {
            TavlingStartlistaAktivitet tavlingStartlistaAktivitet = new TavlingStartlistaAktivitet();
            BanaAktivitet banaAktivitet = new BanaAktivitet();
            GolfklubbAktivitet golfklubbAktivitet = new GolfklubbAktivitet();
            Bana bana;
            Golfklubb golfklubb;

            if (StartlistaDS == null)
            {
                _startlistaDS = tavlingStartlistaAktivitet.HämtaStartlista(Tavling.TavlingID);

                if (_startlistaDS.Tables["Startlista"].Rows.Count > 0)
                {
                    FyllRonderCombo();
                }
            }
            int i = 0;
            dgwStartlista.Rows.Clear();

            int rondNr = Convert.ToInt16(((ComboBoxPar)cboRondnr.SelectedItem).Visa);
            TavlingRond tavlingRond = Tavling.TavlingRond.Single(p => p.RondNr == rondNr);
            bana = banaAktivitet.HämtaBana(tavlingRond.BanaNr);

            if (bana != null)
            {
                golfklubb = golfklubbAktivitet.HämtaGolfklubb(bana.GolfklubbNr);
                txtGolfklubb.Text = golfklubb.GolfklubbNamn;
                txtBana.Text = bana.BanaNamn;
            }

            foreach (DataRow rad in _startlistaDS.Tables["Startlista"].Rows)
            {
                if (rad["RondNr"].ToString().Equals(((ComboBoxPar)cboRondnr.SelectedItem).Visa))
                {
                    dgwStartlista.Rows.Add();
                    dgwStartlista.Rows[i].Cells["SpelarID"].Value = rad["SpelarID"];
                    dgwStartlista.Rows[i].Cells["RondNr"].Value = rad["RondNr"];
                    dgwStartlista.Rows[i].Cells["BollNr"].Value = rad["BollNr"];
                    dgwStartlista.Rows[i].Cells["HålNr"].Value = rad["Hal"];
                    dgwStartlista.Rows[i].Cells["Starttid"].Value = rad["Starttid"];
                    dgwStartlista.Rows[i].Cells["Spelarnamn"].Value = rad["SpelarNamn"];
                    dgwStartlista.Rows[i].Cells["Golfklubb"].Value = rad["Golfklubb"];
                    dgwStartlista.Rows[i].Cells["ExaktHcp"].Value = rad["ExaktHcp"];
                    dgwStartlista.Rows[i].Cells["ErhallnaSlag"].Value = rad["ErhallnaSlag"];
                    dgwStartlista.Rows[i].Cells["Tee"].Value = rad["Tee"];
                    i++;
                }
            }
        }

        /// <summary>
        /// Hämta vald Tävlingsklassronder och fyll combon.
        /// </summary>
        private void FyllRonderCombo()
        {
            try
            {
                if (Tavling.HarTavlingRond())
                {
                    cboRondnr.Items.Clear();
                    for (int i = 0; i < Tavling.TavlingRond.Length; i++)
                    {
                        cboRondnr.Items.Add(new ComboBoxPar(Tavling.TavlingRond[i].RondId,
                            Tavling.TavlingRond[i].RondNr.ToString(), Tavling.TavlingRond[i]));
                    }

                    cboRondnr.SelectedIndex = 0;
                    cboRondnr.DisplayMember = "visa";
                }
                else
                {
                    VisaFelmeddelande("TVLPOSTERMISSING");
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }
        #endregion

        private void Startlista_Load(object sender, EventArgs e)
        {
            InitieraTexter();
            cboRondnr.Focus();
            FormsLaddar = false;
        }

        /// <summary>
        /// Hanterar Avbryt-Knappen
        /// </summary>
        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Visa startlistan för valt rondnr
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboRondnr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormsLaddar == false)
            { 
                FyllListan();
            }
        }

        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            TavlingStartlistaAktivitet tavlingStartlista = new TavlingStartlistaAktivitet();
            TavlingRondResultatAktivitet tavlingRondResultatAktivitet = new TavlingRondResultatAktivitet();

            foreach (TavlingStartlista rad in Tavling.TavlingStartlista)
            {
                tavlingRondResultatAktivitet.TaBort(rad.RondID, rad.SpelareID, ref FelID, ref Feltext);
                tavlingStartlista.TaBort(rad.RondID, rad.SpelareID, ref FelID, ref Feltext);
            }
        }

    }
}
