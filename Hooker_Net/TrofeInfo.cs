using System;
using System.Collections;
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
    /// Fönsterklass för Trofén
    /// </summary>
    public partial class TrofeInfo : FormBas
    {
        #region Medelemsvariabler
        Tavling _tavling;
        DataSet _trofenDS;
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
        /// DataSet för Trofén
        /// </summary>
        private DataSet TrofenDS
        {
            get
            {
                return _trofenDS;
            }
            set
            {
                _trofenDS = value;
            }
        }
        #endregion

        /// <summary>
        /// Defaultkonstruktor
        /// </summary>
        public TrofeInfo()
        {
            InitializeComponent();
        }

        #region Publika metoder
        /// <summary>
        /// Visar Trofén
        /// </summary>
        public void VisaTrofen()
        {
            BanaAktivitet banaAktivitet = new BanaAktivitet();
            GolfklubbAktivitet golfklubbAktivitet = new GolfklubbAktivitet();
            KoderAktivitet koderAktivitet = new KoderAktivitet();
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
            Koder koder = koderAktivitet.HämtaKoder((Kodtabell.Tävlingsstatus).EnumToInt(), Tavling.TavlingStatus);
            txtTavlingStatus.Text = koder.Varde;
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

            for (int i = 0; i < dgwTrofen.Columns.Count; i++)
            {
                dgwTrofen.Columns[i].HeaderText = Översätt("Text", dgwTrofen.Columns[i].HeaderText);
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
            SpelareAktivitet spelareAktivitet;
            List<Ranking> ranking = tavlingRondResultatAktivitet.HämtaTrofen(Tavling.TavlingID);
            int i = 0;
            int rank = 0;
            int platssiffra = 0;

            if (ranking != null)
            {
                dgwTrofen.Rows.Clear();
                spelareAktivitet = new SpelareAktivitet();
                foreach (Ranking rankinglista in ranking)
                {
                    dgwTrofen.Rows.Add();
                    if (platssiffra < rankinglista.Placeringssiffra)
                    {
                        rank++;
                        dgwTrofen.Rows[i].Cells["Rank"].Value = i + 1;
                    }
                    else
                    {
                        dgwTrofen.Rows[i].Cells["Rank"].Value = rank;
                    }
                    platssiffra = rankinglista.Placeringssiffra;

                    dgwTrofen.Rows[i].Cells["Spelarnamn"].Value = spelareAktivitet.HämtaSpelare(rankinglista.SpelarID).Namn;
                    foreach (Trofen trofen in rankinglista.Trofen)
                    {
                        if(rankinglista.SpelarID == trofen.SpelarID)
                        {
                            switch (trofen.TavlingRondNr)
                            {
                                case 1:
                                    dgwTrofen.Rows[i].Cells["FörstaNio"].Value = trofen.RondResultat + "; " + trofen.RankRond;
                                    break;
                                case 2:
                                    dgwTrofen.Rows[i].Cells["AndraNio"].Value = trofen.RondResultat + "; " + trofen.RankRond;
                                    break;
                                case 3:
                                    dgwTrofen.Rows[i].Cells["TredjeNio"].Value = trofen.RondResultat + "; " + trofen.RankRond;
                                    break;
                                case 4:
                                    dgwTrofen.Rows[i].Cells["FjärdeNio"].Value = trofen.RondResultat + "; " + trofen.RankRond;
                                    break;
                                case 5:
                                    dgwTrofen.Rows[i].Cells["FemteNio"].Value = trofen.RondResultat + "; " + trofen.RankRond;
                                    break;
                                case 6:
                                    dgwTrofen.Rows[i].Cells["SjätteNio"].Value = trofen.RondResultat + "; " + trofen.RankRond;
                                    break;
                                case 7:
                                    dgwTrofen.Rows[i].Cells["SjundeNio"].Value = trofen.RondResultat + "; " + trofen.RankRond;
                                    break;
                                case 8:
                                    dgwTrofen.Rows[i].Cells["ÅttondeNio"].Value = trofen.RondResultat + "; " + trofen.RankRond;
                                    break;
                            } 
                        }
                    }
                    dgwTrofen.Rows[i].Cells["Totalt"].Value = rankinglista.Placeringssiffra;
                    i++;
                }
            }
        }
        #endregion

        private void Trofen_Load(object sender, EventArgs e)
        {
            InitieraTexter();
        }
    }
}
