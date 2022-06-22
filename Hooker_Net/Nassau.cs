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
    /// Fönsterklass för Nassau
    /// </summary>
    public partial class Nassau : FormBas
    {
        #region "Medlemsvariabler"
        Tavling _tavling;
        #endregion

        #region Egenskapeer
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
        #endregion

        /// <summary>
        /// Defaultkonstruktor
        /// </summary>
        public Nassau()
        {
            InitializeComponent();
        }

        #region Publika metoder
        /// <summary>
        /// Visar deltagarlistan
        /// </summary>
        public void VisaNassau()
        {
            BanaAktivitet banaAktivitet = new BanaAktivitet();
            GolfklubbAktivitet golfklubbAktivitet = new GolfklubbAktivitet();
            dtpStartdatum.Text = ("STD").Formatera(DateTime.Parse(Tavling.StartDatum.ToShortDateString()));
            txtTavlingNamn.Text = Tavling.Namn;

            if (Tavling.FleraBanor == "0")
            {
                lblBana.Visible = true;
                lblGolfklubb.Visible = true;
                TavlingRond tavlingRond = Tavling.TavlingRond.Single(p => p.RondNr == 1);
                Bana bana = banaAktivitet.HämtaBana(tavlingRond.BanaNr);

                if (bana != null)
                {
                    Golfklubb golfklubb = golfklubbAktivitet.HämtaGolfklubb(bana.GolfklubbNr);
                    txtGolfklubb.Text = golfklubb.GolfklubbNamn;
                    txtBana.Text = bana.BanaNamn;
                }
            }
            else
            {
                lblBana.Visible = false;
                lblGolfklubb.Visible = false;
                txtGolfklubb.Visible = false;
                txtBana.Visible = false;
            }

            //Bana bana = banaAktivitet.HämtaBana(Tavling.BanaNr);
            //txtBana.Text = bana.BanaNamn;
            FyllListan();
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

            for (int i = 0; i < dgwNassau.Columns.Count; i++)
            {
                dgwNassau.Columns[i].HeaderText = Översätt("Text", dgwNassau.Columns[i].HeaderText);
            }

            knappkontroller1.btnKnapp0.Visible = false;
            knappkontroller1.btnKnapp1.Visible = false;
            knappkontroller1.btnKnapp2.Visible = false;
            knappkontroller1.btnKnapp3.Visible = false;
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
        }

        private void FyllListan()
        {
            TavlingRondResultatAktivitet tavlingRondResultatAktivitet = new TavlingRondResultatAktivitet();
            DataSet nassauDS = tavlingRondResultatAktivitet.HämtaNassau(Tavling.TavlingID);

            if (nassauDS.Tables["Nassau"].Rows.Count == 0)
            {
                return;
            }

            int i = 0;
            string vinnareUt = nassauDS.Tables["Nassau"].Rows[0]["Spelarnamn"].ToString();
            string vinnareIn = nassauDS.Tables["Nassau"].Rows[0]["Spelarnamn"].ToString();
            string vinnareTot = nassauDS.Tables["Nassau"].Rows[0]["Spelarnamn"].ToString();
            string nearest = nassauDS.Tables["Nassau"].Rows[0]["Närmast"].ToString();
            string longest = nassauDS.Tables["Nassau"].Rows[0]["Längst"].ToString();
            int poangUt = (int)nassauDS.Tables["Nassau"].Rows[0]["RondresultatUt"];
            int poangIn = (int)nassauDS.Tables["Nassau"].Rows[0]["RondresultatIn"];
            int poangTot = (int)nassauDS.Tables["Nassau"].Rows[0]["RondresultatTot"];
            int rondNr = (int)nassauDS.Tables["Nassau"].Rows[0]["RondNr"];
            dgwNassau.Rows.Clear();

            foreach (DataRow rad in nassauDS.Tables["Nassau"].Rows)
            {
                //Snurra runt per Rondnr och bestäm vinnare Ut, In och Totalt
                if ((int)rad["RondNr"] != rondNr)
                {
                    dgwNassau.Rows.Add();
                    dgwNassau.Rows[i].Cells["RondNr"].Value = rondNr;
                    dgwNassau.Rows[i].Cells["Ut"].Value = vinnareUt + ";" + poangUt;
                    dgwNassau.Rows[i].Cells["In"].Value = vinnareIn + ";" + poangIn;
                    dgwNassau.Rows[i].Cells["Totalt"].Value = vinnareTot + ";" + poangTot;
                    dgwNassau.Rows[i].Cells["Närmast"].Value = nearest;
                    dgwNassau.Rows[i].Cells["Längst"].Value = longest;
                    i++;
                    poangUt = 0;
                    poangIn = 0;
                    poangTot = 0;
                    vinnareUt = null;
                    vinnareIn = null;
                    vinnareTot = null;
                    rondNr = (int)rad["RondNr"];
                    nearest = rad["Närmast"].ToString();
                    longest = rad["Längst"].ToString();
                }

                //Vinnare ut
                if ((int)rad["RondresultatUt"] > 0)
                {
                    if ((int)rad["RondresultatUt"] > poangUt)
                    {
                        poangUt = (int)rad["RondresultatUt"];
                        vinnareUt = rad["Spelarnamn"].ToString();
                    }
                    if ((int)rad["RondresultatUt"] == poangUt & vinnareUt != rad["Spelarnamn"].ToString())
                    {
                        poangUt = (int)rad["RondresultatUt"];
                        vinnareUt = vinnareUt + "/" + rad["Spelarnamn"].ToString();
                    }
                }

                //Vinnare in
                if ((int)rad["RondresultatIn"] > 0)
                {
                    if ((int)rad["RondresultatIn"] > poangIn)
                    {
                        poangIn = (int)rad["RondresultatIn"];
                        vinnareIn = rad["Spelarnamn"].ToString();
                    }
                    if ((int)rad["RondresultatIn"] == poangIn & vinnareIn != rad["Spelarnamn"].ToString())
                    {
                        poangIn = (int)rad["RondresultatIn"];
                        vinnareIn = vinnareIn + "/" + rad["Spelarnamn"].ToString();
                    }
                }

                //Vinnare totalt
                if ((int)rad["RondresultatTot"] > 0)
                {
                    if ((int)rad["RondresultatTot"] > poangTot)
                    {
                        poangTot = (int)rad["RondresultatTot"];
                        vinnareTot = rad["Spelarnamn"].ToString();
                    }
                    if ((int)rad["RondresultatTot"] == poangTot & vinnareTot != rad["Spelarnamn"].ToString())
                    {
                        poangTot = (int)rad["RondresultatTot"];
                        vinnareTot = vinnareTot + "/" + rad["Spelarnamn"].ToString();
                    }
                }
            }

            //Och den sista ronden, om det blev någe
            if (vinnareUt != null)
            {
                dgwNassau.Rows.Add();
                dgwNassau.Rows[i].Cells["RondNr"].Value = rondNr;
                dgwNassau.Rows[i].Cells["Ut"].Value = vinnareUt + "; " + poangUt;
                dgwNassau.Rows[i].Cells["In"].Value = vinnareIn + "; " + poangIn;
                dgwNassau.Rows[i].Cells["Totalt"].Value = vinnareTot + "; " + poangTot;
                dgwNassau.Rows[i].Cells["Närmast"].Value = nearest;
                dgwNassau.Rows[i].Cells["Längst"].Value = longest;
            }
        }
        #endregion

        private void Nassau_Load(object sender, EventArgs e)
        {
            InitieraTexter();
        }
    }
}
