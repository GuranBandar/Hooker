using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Hooker.Gemensam;
using Hooker.Affärsobjekt;
using Hooker_GUI.Kontroller;
using Hooker.Affärslager;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönsterklass för Rondresultat för en spelare
    /// </summary>
    public partial class RondResultatSpelare : FormBas
    {
        #region "Medlemsvariabler"
        private int _rondID;
        private int _rondNr;
        private int _spelareID;
        private Bana _bana;
        private Tavling _tavling;
        private TavlingRond _tavlingRond;
        private List<TavlingRondResultat> _tavlingRondResultat;
        private Color _backColorHeader = Color.LightBlue;
        private Color _backColorSlag = Color.LightYellow;
        #endregion

        #region Egenskapeer
        /// <summary>
        /// RondID
        /// </summary>
        public int RondID { get { return _rondID; } set { _rondID = value; } }

        /// <summary>
        /// RondNr
        /// </summary>
        public int RondNr { get { return _rondNr; } set { _rondNr = value; } }

        /// <summary>
        /// SpelarID
        /// </summary>
        public int SpelareID { get { return _spelareID; } set { _spelareID = value; } }

        /// <summary>
        /// Banaobjekt
        /// </summary>
        private Bana Bana { get { return _bana; } set { _bana = value; } }

        /// <summary>
        /// Tavlingobjektet
        /// </summary>
        public Tavling Tavling { get { return _tavling; } set { _tavling = value; } }

        private TavlingRond TavlingRond { get { return _tavlingRond; } set { _tavlingRond = value; } }

        /// <summary>
        /// TavlingRondResultatobjektet
        /// </summary>
        public List<TavlingRondResultat> TavlingRondResultat { get { return _tavlingRondResultat; } set { _tavlingRondResultat = value; } }
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

        private void FixaTillGridden()
        {
            int parIn = 0;
            int parUt = 0;
            SpelareAktivitet spelareAktivitet = new SpelareAktivitet();
            BanaAktivitet banaAktivitet = new BanaAktivitet();
            TavlingRond tavlingRond = Tavling.HämtaTavlingRond(RondNr, Tavling.TavlingID);
            Spelare spelare = spelareAktivitet.HämtaSpelare(SpelareID);
            this.Text = this.Text + " " + spelare.Namn;
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
                    }
                }
            }
        }

        private void FyllRondResultatSpelare()
        {
            int i = 1;
            int k = 0;
            int slagIn = 0;
            int slagUt = 0;
            int poangIn = 0;
            int poangUt = 0;
            int rondId = 0;

            foreach (TavlingRondResultat rondResultat in Tavling.TavlingRondResultat)
            {
                if (rondResultat.RondId != rondId)
                {
                    if (!rondId.Equals(0))
                    {
                        i = i + 2;
                        slagIn = 0;
                        slagUt = 0;
                        poangIn = 0;
                        poangUt = 0;
                        k++;
                    }
                    dgwRondresultat.Rows.Add(2);
                    rondId = rondResultat.RondId;
                    dgwRondresultat.Rows[i].Cells[0].Value = Tavling.TavlingRond[k].RondNr;
                    dgwRondresultat.Rows[i].Cells[1].Value = "Slag";
                    dgwRondresultat.Rows[i + 1].Cells[1].Value = "Poäng";
                    dgwRondresultat.Rows[i].Cells[1].Style.BackColor = _backColorHeader;
                    dgwRondresultat.Rows[i + 1].Cells[1].Style.BackColor = Color.Lavender;
                }

                if (rondResultat.SpelarID == SpelareID)
                {
                    // Börja med att lägga ut slagen
                    if (rondResultat.HalNr < 10)
                    {
                        dgwRondresultat.Rows[i].Cells[rondResultat.HalNr + 1].Value =
                            rondResultat.AntalSlag;
                        dgwRondresultat.Rows[i].Cells[rondResultat.HalNr + 1].Style.ForeColor =
                            (rondResultat.AntalSlag.SättFärg(Bana.BanaHal[rondResultat.HalNr - 1].Par));
                        dgwRondresultat.Rows[i].Cells[rondResultat.HalNr + 1].Style.BackColor =
                            _backColorSlag;
                        slagIn += rondResultat.AntalSlag;
                    }
                    else
                    {
                        dgwRondresultat.Rows[i].Cells[rondResultat.HalNr + 2].Value =
                            rondResultat.AntalSlag;
                        dgwRondresultat.Rows[i].Cells[rondResultat.HalNr + 2].Style.ForeColor =
                            (rondResultat.AntalSlag.SättFärg(Bana.BanaHal[rondResultat.HalNr - 1].Par));
                        dgwRondresultat.Rows[i].Cells[rondResultat.HalNr + 2].Style.BackColor =
                            _backColorSlag;
                        slagUt += rondResultat.AntalSlag;
                    }

                    // ta sedan poängen
                    if (rondResultat.HalNr < 10)
                    {
                        dgwRondresultat.Rows[i + 1].Cells[rondResultat.HalNr + 1].Value = 
                            rondResultat.AntalPoang;
                        poangIn += rondResultat.AntalPoang;
                    }
                    else
                    {
                        dgwRondresultat.Rows[i + 1].Cells[rondResultat.HalNr + 2].Value = 
                            rondResultat.AntalPoang;
                        poangUt += rondResultat.AntalPoang;
                    }
                }
                dgwRondresultat.Rows[i].Cells[11].Value = slagIn;
                dgwRondresultat.Rows[i].Cells[11].Style.BackColor = _backColorHeader;
                dgwRondresultat.Rows[i].Cells[21].Value = slagUt;
                dgwRondresultat.Rows[i].Cells[21].Style.BackColor = _backColorHeader;
                dgwRondresultat.Rows[i].Cells[22].Value = slagIn + slagUt;
                dgwRondresultat.Rows[i].Cells[22].Style.BackColor = _backColorHeader;
                dgwRondresultat.Rows[i + 1].Cells[11].Value = poangIn;
                dgwRondresultat.Rows[i + 1].Cells[11].Style.BackColor = Color.Lavender;
                dgwRondresultat.Rows[i + 1].Cells[21].Value = poangUt;
                dgwRondresultat.Rows[i + 1].Cells[21].Style.BackColor = Color.Lavender;
                dgwRondresultat.Rows[i + 1].Cells[22].Value = poangIn + poangUt;
                dgwRondresultat.Rows[i + 1].Cells[22].Style.BackColor = Color.Lavender;
            }
        }
        #endregion
    }
}
