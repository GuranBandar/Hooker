using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönsterklass för Rondresultat för en spelare
    /// </summary>
    public partial class RondResultatSpelare : FormBas
    {
        #region "Medlemsvariabler"
        private Color _backColorHeader = Color.LightBlue;
        private Color _backColorSlag = Color.LightYellow;
        #endregion

        #region Egenskapeer
        /// <summary>
        /// RondID
        /// </summary>
        public int RondID { get; set; }

        /// <summary>
        /// RondNr
        /// </summary>
        public int RondNr { get; set; }

        /// <summary>
        /// SpelarID
        /// </summary>
        public int SpelareID { get; set; }

        /// <summary>
        /// Banans par in
        /// </summary>
        private int ParIn { get; set; }

        /// <summary>
        /// Banans par ut
        /// </summary>
        private int ParUt { get; set; }

        /// <summary>
        /// Banans par
        /// </summary>
        private int Par { get; set; }

        /// <summary>
        /// Erhållna slag
        /// </summary>
        private int ErhallnaSlag { get; set; }

        /// <summary>
        /// Banaobjekt
        /// </summary>
        private Bana Bana { get; set; }

        /// <summary>
        /// Tavlingobjektet
        /// </summary>
        public Tavling Tavling { get; set; }

        private TavlingRond TavlingRond { get; set; }

        /// <summary>
        /// TavlingRondResultatobjektet
        /// </summary>
        public List<TavlingRondResultat> TavlingRondResultat { get; set; }
        #endregion

        /// <summary>
        /// Konstruktor
        /// </summary>
        public RondResultatSpelare()
        {
            InitializeComponent();
            InitieraTexter();
        }

        public void VisaRondResultatSpelare()
        {
            FixaTillGridden();
            FyllRondResultatSpelare();
        }

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

            dgwRondresultat.RowTemplate.Height = 20;
            for (int i = 0; i < dgwRondresultat.Columns.Count; i++)
            {
                dgwRondresultat.Columns[i].HeaderText = Översätt("Text", dgwRondresultat.Columns[i].HeaderText);
                dgwRondresultat.Columns[i].ReadOnly = true;
                dgwRondresultat.Columns[i].Resizable = DataGridViewTriState.False;
                dgwRondresultat.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        /// <summary>
        /// Fixa till rubriker etc
        /// </summary>
        private void FixaTillGridden()
        {
            int parIn = 0;
            int parUt = 0;
            SpelareAktivitet spelareAktivitet = new SpelareAktivitet();
            BanaAktivitet banaAktivitet = new BanaAktivitet();
            TavlingRond tavlingRond = Tavling.HämtaTavlingRond(RondNr, Tavling.TavlingID);
            Spelare spelare = spelareAktivitet.HämtaSpelare(SpelareID);
            this.Text = this.Text + ": " + spelare.Namn;
            Bana = banaAktivitet.HämtaBanaBanaHal(tavlingRond.BanaNr);
            dgwRondresultat.Rows.Clear();
            dgwRondresultat.Rows.Add();
            dgwRondresultat.Rows[0].Cells[1].Value = "Par";

            for (int j = 0; j < 18; j++)
            {
                if (j < 9)
                {
                    dgwRondresultat.Rows[0].Cells[j + 2].Value = Bana.BanaHal[j].Par;
                    parUt += Bana.BanaHal[j].Par;
                }
                else
                {
                    if (j == 9)
                    {
                        dgwRondresultat.Rows[0].Cells[j + 2].Value = parUt;
                    }
                    dgwRondresultat.Rows[0].Cells[j + 3].Value = Bana.BanaHal[j].Par;
                    parIn += Bana.BanaHal[j].Par;
                    if (j == 17)
                    {
                        dgwRondresultat.Rows[0].Cells[j + 4].Value = parIn;
                        dgwRondresultat.Rows[0].Cells[j + 5].Value = parUt + parIn;
                        ParIn = parIn;
                        ParUt = parUt;
                        Par = parUt + parIn;
                    }
                }
            }

            int i = 1;
            dgwRondresultat.Rows.Add(Tavling.TavlingRond.Length * 2);
            foreach (TavlingRond rond in Tavling.TavlingRond)
            {
                dgwRondresultat.Rows[i].Cells[0].Value = rond.RondNr;
                dgwRondresultat.Rows[i].Cells[1].Value = "Slag";
                dgwRondresultat.Rows[i].Cells[1].Style.BackColor = Color.LightBlue;
                i++;
                dgwRondresultat.Rows[i].Cells[1].Value = "Poäng";
                dgwRondresultat.Rows[i].Cells[1].Style.BackColor = Color.Lavender;
                i++;
            }
        }

        /// <summary>
        /// Fyll i scorekortet för spelare
        /// </summary>
        private void FyllRondResultatSpelare()
        {
            int i = 1;
            int halNr = 0;
            int slagIn = 0;
            int slagUt = 0;
            int poangIn = 0;
            int poangUt = 0;
            int antalSlag = 0;
            int antalPoang = 0;
            string rondNr;

            TavlingRondResultatAktivitet resultatAktivitet = new TavlingRondResultatAktivitet();
            DataSet rondResultatDS = resultatAktivitet.HämtaTavlingResultatForSpelare(Tavling.TavlingID, SpelareID);
            DataTable tavlingResultatDT = rondResultatDS.Tables["TavlingResultat"];

            //Lägg också ut hcp och erhållna slag i rubriken
            this.Text = this.Text + ", HCP: " + tavlingResultatDT.Rows[0]["ExaktHcp"].ToString() + ", Erhållna slag: " +
                tavlingResultatDT.Rows[0]["ErhallnaSlag"].ToString();
            ErhallnaSlag = (int)tavlingResultatDT.Rows[0]["ErhallnaSlag"];
            rondNr = tavlingResultatDT.Rows[0]["RondNr"].ToString();

            foreach (DataRow rondResultat in tavlingResultatDT.Select())
            {
                if (rondResultat["RondNr"].ToString() != rondNr)
                {
                    i = i + 2;
                    slagIn = 0;
                    slagUt = 0;
                    poangIn = 0;
                    poangUt = 0;
                    rondNr = rondResultat["RondNr"].ToString();
                }

                // Börja med att lägga ut slagen
                halNr = Convert.ToInt16(rondResultat["HalNr"]);
                antalSlag = Convert.ToInt16(rondResultat["AntalSlag"]);
                antalPoang = Convert.ToInt16(rondResultat["AntalPoang"]);

                if (halNr < 10)
                {
                    dgwRondresultat.Rows[i].Cells[halNr + 1].Value = antalSlag;
                    dgwRondresultat.Rows[i].Cells[halNr + 1].Style.ForeColor = (antalSlag.SättFärg(Bana.BanaHal[halNr - 1].Par, true));
                    dgwRondresultat.Rows[i].Cells[halNr + 1].Style.BackColor = Color.LightYellow;
                    slagIn += antalSlag;
                }
                else
                {
                    dgwRondresultat.Rows[i].Cells[halNr + 2].Value = antalSlag;
                    dgwRondresultat.Rows[i].Cells[halNr + 2].Style.ForeColor = (antalSlag.SättFärg(Bana.BanaHal[halNr - 1].Par, true));
                    dgwRondresultat.Rows[i].Cells[halNr + 2].Style.BackColor = Color.LightYellow;
                    slagUt += antalSlag;
                }

                // ta sedan poängen
                if (halNr < 10)
                {
                    dgwRondresultat.Rows[i + 1].Cells[halNr + 1].Value = antalPoang;
                    poangIn += antalPoang;
                }
                else
                {
                    dgwRondresultat.Rows[i + 1].Cells[halNr + 2].Value = antalPoang;
                    poangUt += antalPoang;
                }

                if (halNr == 9)
                {
                    dgwRondresultat.Rows[i].Cells[11].Value = slagIn;
                    dgwRondresultat.Rows[i].Cells[11].Style.ForeColor = (slagIn.SättFärg(ParIn, true));
                    dgwRondresultat.Rows[i].Cells[11].Style.BackColor = Color.LightBlue;
                    dgwRondresultat.Rows[i + 1].Cells[11].Value = poangIn;
                    dgwRondresultat.Rows[i + 1].Cells[11].Style.ForeColor = (poangIn.SättFärg(18, false));
                    dgwRondresultat.Rows[i + 1].Cells[11].Style.BackColor = Color.Lavender;
                }

                if (halNr == 18)
                {
                    dgwRondresultat.Rows[i].Cells[21].Value = slagUt;
                    dgwRondresultat.Rows[i].Cells[21].Style.ForeColor = (slagUt.SättFärg(ParUt, true));
                    dgwRondresultat.Rows[i].Cells[21].Style.BackColor = Color.LightBlue;
                    dgwRondresultat.Rows[i].Cells[22].Value = slagIn + slagUt;
                    dgwRondresultat.Rows[i].Cells[22].Style.ForeColor = ((slagIn + slagUt).SättFärg(Par, true));
                    dgwRondresultat.Rows[i].Cells[22].Style.BackColor = Color.LightBlue;
                    dgwRondresultat.Rows[i].Cells[23].Value = ErhallnaSlag;
                    dgwRondresultat.Rows[i].Cells[24].Value = (slagIn + slagUt) - ErhallnaSlag;
                    dgwRondresultat.Rows[i].Cells[24].Style.ForeColor = (((slagIn + slagUt) - ErhallnaSlag).SättFärg(Par, true));
                    dgwRondresultat.Rows[i + 1].Cells[21].Value = poangUt;
                    dgwRondresultat.Rows[i + 1].Cells[21].Style.ForeColor = (poangUt.SättFärg(18, false));
                    dgwRondresultat.Rows[i + 1].Cells[21].Style.BackColor = Color.Lavender;
                    dgwRondresultat.Rows[i + 1].Cells[22].Value = poangIn + poangUt;
                    dgwRondresultat.Rows[i + 1].Cells[22].Style.ForeColor = ((poangIn + poangUt).SättFärg(36, false));
                    dgwRondresultat.Rows[i + 1].Cells[22].Style.BackColor = Color.Lavender;
                }
            }
        }
        #endregion
    }
}
