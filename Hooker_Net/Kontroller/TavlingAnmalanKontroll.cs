using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using System;
using System.Data;
using System.Windows.Forms;

namespace Hooker_GUI.Kontroller
{
    /// <summary>
    /// UserControl för Tävlingsanmälan
    /// </summary>
    public partial class TavlingAnmalanKontroll : KontrollBas
    {
        #region Egenskapeer
        /// <summary>
        /// Objekt för Tävling
        /// </summary>
        public Tavling Tavling { get; set; }

        private Bana Bana { get; set; }
        #endregion

        /// <summary>
        /// Defaultkonstruktor
        /// </summary>
        public TavlingAnmalanKontroll()
        {
            InitializeComponent();
            InitieraTexter();
        }

        #region "Privata metoder"
        /// <summary>
        /// Alla texter hämtas och knapparna initieras
        /// </summary>
        private void InitieraTexter()
        {
            this.Text = FormBas.Översätt("Text", this.Text);

            foreach (System.Windows.Forms.Control cc in this.Controls)
            {
                if (cc.Controls.Count == 0)
                {
                    if (cc.Name.StartsWith("lbl") | cc.Name.StartsWith("gbx"))
                    {
                        cc.Text = FormBas.Översätt("Text", cc.Text);
                    }
                }
                else
                {
                    if (cc.Name.StartsWith("gbx"))
                    {
                        cc.Text = FormBas.Översätt("Text", cc.Text);
                    }
                    for (int i = 0; i < cc.Controls.Count; i++)
                    {
                        if (cc.Controls[i].Name.StartsWith("lbl"))
                        {
                            cc.Controls[i].Text = FormBas.Översätt("Text", cc.Controls[i].Text);
                        }
                    }
                }
            }

            for (int i = 0; i < dgwAnmalan.Columns.Count; i++)
            {
                dgwAnmalan.Columns[i].HeaderText = FormBas.Översätt("Text", dgwAnmalan.Columns[i].HeaderText);
            }
        }

        /// <summary>
        /// Kollar om spelaren är aktuell för tävlingen
        /// </summary>
        /// <param name="hcp">Spelarens hcp</param>
        /// <param name="golfID">Spelarens golfid</param>
        /// <param name="kon">Spelarens kön</param>
        /// <param name="klass">Tävlingsklass</param>
        /// <param name="klassNamn">Tävlingsklassens namn</param>
        /// <returns></returns>
        private bool SpelareAktuell(decimal hcp, string golfID, string kon, ref string klass,
            ref string klassNamn)
        {
            int year = DateTime.Today.Year;
            int alder = year - (1900 + int.Parse(golfID.Substring(0, 2)));

            for (int i = 0; i < Tavling.TavlingKlass.Length; i++)
            {
                if (Tavling.TavlingKlass[i].Kon == "M")
                {
                    if (hcp >= Tavling.TavlingKlass[i].MinHcpMan
                        && hcp <= Tavling.TavlingKlass[i].MaxHcpMan
                        && kon == "M"
                        && alder >= Tavling.TavlingKlass[i].MinAlderMan
                        && alder <= Tavling.TavlingKlass[i].MaxAlderMan)
                    {
                        klass = Tavling.TavlingKlass[i].Klass;
                        klassNamn = Tavling.TavlingKlass[i].KlassNamn;
                        return true;
                    }
                }
                else if (Tavling.TavlingKlass[i].Kon == "K")
                {
                    if (hcp >= Tavling.TavlingKlass[i].MinHcpKvinna
                        && hcp <= Tavling.TavlingKlass[i].MaxHcpKvinna
                        && kon == "K"
                        && alder >= Tavling.TavlingKlass[i].MinAlderKvinna
                        && alder <= Tavling.TavlingKlass[i].MaxAlderKvinna)
                    {
                        klass = Tavling.TavlingKlass[i].Klass;
                        klassNamn = Tavling.TavlingKlass[i].KlassNamn;
                        return true;
                    }
                }
                else if (Tavling.TavlingKlass[i].Kon == "B")
                {
                    if (hcp >= Tavling.TavlingKlass[i].MinHcpKvinna
                        && hcp <= Tavling.TavlingKlass[i].MaxHcpKvinna
                        && hcp >= Tavling.TavlingKlass[i].MinHcpMan
                        && hcp <= Tavling.TavlingKlass[i].MaxHcpMan
                        && alder >= Tavling.TavlingKlass[i].MinAlderKvinna
                        && alder <= Tavling.TavlingKlass[i].MaxAlderKvinna
                        && alder >= Tavling.TavlingKlass[i].MinAlderMan
                        && alder <= Tavling.TavlingKlass[i].MaxAlderMan)
                    {
                        klass = Tavling.TavlingKlass[i].Klass;
                        klassNamn = Tavling.TavlingKlass[i].KlassNamn;
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        /// <summary>
        /// Visar alla spelare som ej är anmälda till aktuell tävling
        /// </summary>
        public void VisaTavlingAnmalan()
        {
            string klass = null;
            string klassNamn = null;
            int j = 0;
            SpelareAktivitet spelareAktivitet = new SpelareAktivitet();
            DataSet spelareDS = spelareAktivitet.HämtaSpelareEjAnmälda(Tavling);
            dgwAnmalan.Rows.Clear();

            //List<string> countriesNotApproved = (from c in Context.C_Country_Details
            //                                     where c.Approved_For_Research == null
            //                                     select c.Country).ToList();


            for (int i = 0; i < spelareDS.Tables["Spelare"].Rows.Count; i++)
            {
                //Kolla först att spelaren också är aktuell, t ex hcp och/eller ålder etc, för tävlingen
                if (SpelareAktuell(decimal.Parse(spelareDS.Tables["Spelare"].Rows[i]["Hcp"].ToString()),
                    spelareDS.Tables["Spelare"].Rows[i]["GolfID"].ToString(),
                    spelareDS.Tables["Spelare"].Rows[i]["Kon"].ToString(), ref klass, ref klassNamn))
                {
                    dgwAnmalan.Rows.Add();
                    dgwAnmalan.Rows[j].Cells["SpelarID"].Value = spelareDS.Tables["Spelare"].Rows[i]["SpelarID"];
                    dgwAnmalan.Rows[j].Cells["Anmalan"].Value = "0";
                    dgwAnmalan.Rows[j].Cells["SpelarNamn"].Value = spelareDS.Tables["Spelare"].Rows[i]["SpelarNamn"];
                    dgwAnmalan.Rows[j].Cells["Hcp"].Value = spelareDS.Tables["Spelare"].Rows[i]["Hcp"];
                    dgwAnmalan.Rows[j].Cells["Golfklubb"].Value = spelareDS.Tables["Spelare"].Rows[i]["Golfklubb"];
                    dgwAnmalan.Rows[j].Cells["Klass"].Value = klass;
                    dgwAnmalan.Rows[j].Cells["KlassNamn"].Value = klassNamn;
                    j++;
                }
                else
                {
                    //if (dgwAnmalan.Rows.Count == 1)
                    //{
                    //    dgwAnmalan.CurrentRow.Frozen = true;
                    //}
                }
            }
        }

        /// <summary>
        /// Anmäler vald spelare till tävlingen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgwAnmalan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TavlingDeltagare tavlingDeltagare;
            if (dgwAnmalan.CurrentRow.Cells["SpelarID"].Value != null)
            {
                tavlingDeltagare = new TavlingDeltagare();
                tavlingDeltagare.SpelarID = (int)dgwAnmalan.CurrentRow.Cells["SpelarID"].Value;
                tavlingDeltagare.TavlingID = Tavling.TavlingID;
                tavlingDeltagare.Klass = dgwAnmalan.CurrentRow.Cells["Klass"].Value.ToString();
                tavlingDeltagare.Hcp = (decimal)dgwAnmalan.CurrentRow.Cells["Hcp"].Value;
                tavlingDeltagare.UppdatDatum = DateTime.Now;
                Tavling.AddTavlingDeltagare(tavlingDeltagare);
                SparaTavlingDeltagare(tavlingDeltagare);
                VisaTavlingAnmalan();
            }
        }

        /// <summary>
        /// Spara TavlingsDeltagare
        /// </summary>
        /// <param name="tavlingDeltagare"></param>
        private void SparaTavlingDeltagare(TavlingDeltagare tavlingDeltagare)
        {
            TavlingDeltagareAktivitet tavlingDeltagareAktivitet = new TavlingDeltagareAktivitet();
            tavlingDeltagareAktivitet.Spara(tavlingDeltagare, true, ref felID, ref feltext);
            TavlingRondResultatAktivitet tavlingRondResultatAktivitet = new TavlingRondResultatAktivitet();
            tavlingRondResultatAktivitet.InitieraTavlingRondResultat(Tavling, tavlingDeltagare.SpelarID, ref felID, ref feltext);
        }
    }
}