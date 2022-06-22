using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönsterklass för Trofén
    /// </summary>
    public partial class TrofeInfo : FormBas
    {
        #region Egenskaper
        /// <summary>
        /// Objekt för Tävling
        /// </summary>
        public Tavling Tavling { get; set; }

        /// <summary>
        /// DataSet för Trofén
        /// </summary>
        private DataSet TrofenDS { get; set; }
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
            List<Ranking> ranking = tavlingRondResultatAktivitet.HämtaTrofen(Tavling);
            int i = 0;
            int rank = 0;
            int platssiffra = 0;
            var rondValue = string.Empty;
            Color backColor = Color.White;
            bool sämstaMarkerad = false;

            if (ranking != null)
            {
                dgwTrofen.Rows.Clear();
                spelareAktivitet = new SpelareAktivitet();
                foreach (Ranking rankinglista in ranking.OrderBy(x => x.Placeringssiffra - x.SämstaPlacering))
                {
                    dgwTrofen.Rows.Add();
                    if (platssiffra < rankinglista.Placeringssiffra - rankinglista.SämstaPlacering)
                    {
                        rank++;
                        dgwTrofen.Rows[i].Cells["Rank"].Value = i + 1;
                    }
                    else
                    {
                        dgwTrofen.Rows[i].Cells["Rank"].Value = rank;
                    }
                    platssiffra = rankinglista.Placeringssiffra - rankinglista.SämstaPlacering;

                    dgwTrofen.Rows[i].Cells["Spelarnamn"].Value = spelareAktivitet.HämtaSpelare(rankinglista.SpelarID).Namn;
                    backColor = Color.White;
                    sämstaMarkerad = false;
                    foreach (Trofen trofen in rankinglista.Trofen)
                    {
                        if (rankinglista.SpelarID == trofen.SpelarID)
                        {
                            rondValue = trofen.RondResultat + "; " + trofen.RankRond;

                            if (trofen.RankRond == rankinglista.SämstaPlacering && !sämstaMarkerad)
                            {
                                backColor = Color.LightPink;
                                sämstaMarkerad = true;
                            }

                            switch (trofen.TavlingRondNr)
                            {

                                case 1:
                                    dgwTrofen.Rows[i].Cells["FörstaNio"].Value = rondValue;
                                    dgwTrofen.Rows[i].Cells["FörstaNio"].Style.BackColor = backColor;
                                    break;
                                case 2:
                                    dgwTrofen.Rows[i].Cells["AndraNio"].Value = rondValue;
                                    dgwTrofen.Rows[i].Cells["AndraNio"].Style.BackColor = backColor;
                                    break;
                                case 3:
                                    dgwTrofen.Rows[i].Cells["TredjeNio"].Value = rondValue;
                                    dgwTrofen.Rows[i].Cells["TredjeNio"].Style.BackColor = backColor;
                                    break;
                                case 4:
                                    dgwTrofen.Rows[i].Cells["FjärdeNio"].Value = rondValue;
                                    dgwTrofen.Rows[i].Cells["FjärdeNio"].Style.BackColor = backColor;
                                    break;
                                case 5:
                                    dgwTrofen.Rows[i].Cells["FemteNio"].Value = rondValue;
                                    dgwTrofen.Rows[i].Cells["FemteNio"].Style.BackColor = backColor;
                                    break;
                                case 6:
                                    dgwTrofen.Rows[i].Cells["SjätteNio"].Value = rondValue;
                                    dgwTrofen.Rows[i].Cells["SjätteNio"].Style.BackColor = backColor;
                                    break;
                                case 7:
                                    dgwTrofen.Rows[i].Cells["SjundeNio"].Value = rondValue;
                                    dgwTrofen.Rows[i].Cells["SjundeNio"].Style.BackColor = backColor;
                                    break;
                                case 8:
                                    dgwTrofen.Rows[i].Cells["ÅttondeNio"].Value = rondValue;
                                    dgwTrofen.Rows[i].Cells["ÅttondeNio"].Style.BackColor = backColor;
                                    break;
                            }
                            backColor = Color.White;
                        }
                    }
                    dgwTrofen.Rows[i].Cells["Brutto"].Value = rankinglista.Placeringssiffra;
                    dgwTrofen.Rows[i].Cells["Netto"].Value = rankinglista.Placeringssiffra - rankinglista.SämstaPlacering;
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
