using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Data;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönsterklass för hantering av Tävling
    /// </summary>
    public partial class Deltagarlista : FormBas
    {
        #region Medelemsvariabler
        //Tavling _tavling;
        //DataSet _deltagarlistaDS;
        #endregion

        #region Egenskaper
        /// <summary>
        /// Objekt för Tävling
        /// </summary>
        public Tavling Tavling { get; set; }

        /// <summary>
        /// DataSet för TävlingDeltagare
        /// </summary>
        public DataSet DeltagarlistaDS { get; set; }
        #endregion

        /// <summary>
        /// Defaultkonstruktor
        /// </summary>
        public Deltagarlista()
        {
            InitializeComponent();
        }

        #region Publika metoder
        /// <summary>
        /// Visar deltagarlistan
        /// </summary>
        public void VisaDeltagarlista()
        {
            dtpStartdatum.Text = ("STD").Formatera(DateTime.Parse(Tavling.StartDatum.ToShortDateString()));
            txtTavlingNamn.Text = Tavling.Namn;
            FyllListan();

            if (DeltagarlistaDS.Tables["Deltagarlista"].Rows.Count > 0 && Tavling.ÄrÖppenFörAnmälan())
            {
                knappkontroller1.btnKnapp3.Enabled = true;
            }
            else
            {
                knappkontroller1.btnKnapp3.Enabled = false;
            }

            if (Tavling.HarTavlingStartlista())
            {
                btnSkapaStartlista.Enabled = false;
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

            for (int i = 0; i < dgwDeltagarlista.Columns.Count; i++)
            {
                dgwDeltagarlista.Columns[i].HeaderText = Översätt("Text", dgwDeltagarlista.Columns[i].HeaderText);
            }

            knappkontroller1.btnKnapp0.Visible = false;
            knappkontroller1.btnKnapp1.Visible = false;
            knappkontroller1.btnKnapp2.Visible = false;
            knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_TaBort");
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
        }

        private void FyllListan()
        {
            TavlingDeltagareAktivitet tavlingDeltagareAktivitet = new TavlingDeltagareAktivitet();
            DeltagarlistaDS = tavlingDeltagareAktivitet.HämtaDeltagarlista(Tavling.TavlingID);
            int i = 0;
            dgwDeltagarlista.Rows.Clear();
            antalAnmalda.Text = DeltagarlistaDS.Tables["Deltagarlista"].Rows.Count.ToString();

            foreach (DataRow rad in DeltagarlistaDS.Tables["Deltagarlista"].Rows)
            {
                dgwDeltagarlista.Rows.Add();
                dgwDeltagarlista.Rows[i].Cells["SpelarID"].Value = rad["SpelarID"];
                dgwDeltagarlista.Rows[i].Cells["Nr"].Value = rad["AnmaldNr"];
                dgwDeltagarlista.Rows[i].Cells["Spelarnamn"].Value = rad["SpelarNamn"];
                dgwDeltagarlista.Rows[i].Cells["Golfklubb"].Value = rad["GolfklubbNamn"];
                dgwDeltagarlista.Rows[i].Cells["Hcp"].Value = rad["Hcp"];
                dgwDeltagarlista.Rows[i].Cells["Klassnamn"].Value = rad["Klassnamn"];
                if (Tavling.ÄrÖppenFörAnmälan())
                {
                    dgwDeltagarlista.Rows[i].Cells["TaBort"].Value = "0";
                }
                else
                {
                    dgwDeltagarlista.Rows[i].Cells["TaBort"].ReadOnly = true;
                }

                i++;
            }
        }
        #endregion

        private void Deltagarlista_Load(object sender, EventArgs e)
        {
            InitieraTexter();
        }

        /// <summary>
        /// Hanterar Ta Bort-Knappen
        /// </summary>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            string svar;
            TavlingDeltagareAktivitet tavlingDeltagareAktivitet = new TavlingDeltagareAktivitet();

            try
            {
                svar = VisaFråga("Varning_TABORTSPELARE");

                if (svar.Equals("Ja"))
                {
                    Timglas.WaitCurson();
                    for (int i = 0; i < DeltagarlistaDS.Tables["Deltagarlista"].Rows.Count; i++)
                    {
                        if (dgwDeltagarlista.Rows[i].Cells["TaBort"].Value.Equals("1"))
                        {
                            tavlingDeltagareAktivitet.TaBort((int)dgwDeltagarlista.Rows[i].Cells["SpelarID"].Value,
                                Tavling, ref FelID, ref Feltext);
                        }
                    }
                    Timglas.DefaultCursor();
                    VisaMeddelande("Information_OK");
                    this.Close();
                }
                //else
                //{
                //    VisaFelmeddelande("TAVLINGHARANMÄLDA");
                //}
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
            this.Close();
        }

        /// <summary>
        /// Hantera Skapa Startlista-knappen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSkapaStartlista_Click(object sender, EventArgs e)
        {
            TavlingStartlistaAktivitet tavlingStartlistaAktivitet = new TavlingStartlistaAktivitet();
            tavlingStartlistaAktivitet.SkapaStartlista(Tavling, ref FelID, ref Feltext);
            VisaMeddelande("Information_OK");
            btnSkapaStartlista.Enabled = false;
        }
    }
}
