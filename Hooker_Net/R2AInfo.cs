using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hooker_GUI.Kontroller;
using Hooker.Affärslager;
using Hooker.Gemensam;
using Hooker.Affärsobjekt;

namespace Hooker_GUI
{
    public partial class R2A : FormBas
    {
        public Tavling Tavling { get; set; }

        public R2A()
        {
            InitializeComponent();
        }

        #region Publika metoder
        /// <summary>
        /// Visar Race to Algarve
        /// </summary>
        public void VisaR2A()
        {
            KoderAktivitet koderAktivitet = new KoderAktivitet();
            dtpStartdatum.Text = ("STD").Formatera(DateTime.Parse(Tavling.StartDatum.ToShortDateString()));
            txtTavlingNamn.Text = Tavling.Namn;
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

            for (int i = 0; i < dgwR2A.Columns.Count; i++)
            {
                dgwR2A.Columns[i].HeaderText = Översätt("Text", dgwR2A.Columns[i].HeaderText);
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
            List<Ranking> ranking = tavlingRondResultatAktivitet.HämtaR2A(Tavling.TavlingID);
            int i = 0;
            int rank = 0;
            int platssiffra = 0;

            if (ranking != null)
            {
                dgwR2A.Rows.Clear();
                spelareAktivitet = new SpelareAktivitet();
                foreach (Ranking rankinglista in ranking)
                {
                    dgwR2A.Rows.Add();
                    if (platssiffra < rankinglista.Placeringssiffra)
                    {
                        rank++;
                        dgwR2A.Rows[i].Cells["Rank"].Value = i + 1;
                    }
                    else
                    {
                        dgwR2A.Rows[i].Cells["Rank"].Value = rank;
                    }
                    platssiffra = rankinglista.Placeringssiffra;

                    dgwR2A.Rows[i].Cells["Spelarnamn"].Value = spelareAktivitet.HämtaSpelare(rankinglista.SpelarID).Namn;
                    foreach (Trofen r2a in rankinglista.Trofen)
                    {
                        if (rankinglista.SpelarID == r2a.SpelarID)
                        {
                            switch (r2a.TavlingRondNr)
                            {
                                case 1:
                                    dgwR2A.Rows[i].Cells["R1"].Value = r2a.RondResultat + "; " + r2a.RankRond;
                                    break;
                                case 2:
                                    dgwR2A.Rows[i].Cells["R2"].Value = r2a.RondResultat + "; " + r2a.RankRond;
                                    break;
                                case 3:
                                    dgwR2A.Rows[i].Cells["R3"].Value = r2a.RondResultat + "; " + r2a.RankRond;
                                    break;
                                case 4:
                                    dgwR2A.Rows[i].Cells["R4"].Value = r2a.RondResultat + "; " + r2a.RankRond;
                                    break;
                                case 5:
                                    dgwR2A.Rows[i].Cells["R5"].Value = r2a.RondResultat + "; " + r2a.RankRond;
                                    break;
                                case 6:
                                    dgwR2A.Rows[i].Cells["R6"].Value = r2a.RondResultat + "; " + r2a.RankRond;
                                    break;
                            }
                        }
                    }
                    dgwR2A.Rows[i].Cells["Totalt"].Value = rankinglista.Placeringssiffra;
                    i++;
                }
            }
        }

        private void R2A_Load(object sender, EventArgs e)
        {
            InitieraTexter();
        }
        #endregion
    }
}
