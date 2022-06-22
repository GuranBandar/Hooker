using Hooker.Affärsobjekt;
using System;

namespace Hooker_GUI.Kontroller
{
    /// <summary>
    /// UserControl för TavlingKlassgridden
    /// </summary>
    public partial class TavlingKlassKontroll : KontrollBas
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
        public TavlingKlassKontroll()
        {
            InitializeComponent();
            InitieraTexter();
        }

        #region "Privata metoder"
        /// <summary>
        ///     Alla texter hämtas och knapparna initieras
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

            for (int i = 0; i < dgwKlassinfo.Columns.Count; i++)
            {
                dgwKlassinfo.Columns[i].HeaderText = FormBas.Översätt("Text", dgwKlassinfo.Columns[i].HeaderText);
            }
        }
        #endregion

        /// <summary>
        /// Visar aktuell TavlingKlassInfo
        /// </summary>
        public void VisaTavlingKlassInfo()
        {
            dgwKlassinfo.Rows.Clear();
            for (int i = 0; i < Tavling.TavlingKlass.Length; i++)
            {
                dgwKlassinfo.Rows.Add();
                dgwKlassinfo.Rows[i].Cells["Klass"].Value = Tavling.TavlingKlass[i].Klass;
                dgwKlassinfo.Rows[i].Cells["Klasser"].Value = Tavling.TavlingKlass[i].Klass;
                dgwKlassinfo.Rows[i].Cells["Namn"].Value = Tavling.TavlingKlass[i].KlassNamn;
                dgwKlassinfo.Rows[i].Cells["Spelform"].Value = Tavling.TavlingKlass[i].SpelformVarde;
                dgwKlassinfo.Rows[i].Cells["Klasstyp"].Value = Tavling.TavlingKlass[i].KlasstypVarde;
                dgwKlassinfo.Rows[i].Cells["Ronder"].Value = Tavling.TavlingKlass[i].AntRonder.ToString();
            }
        }

        private void dgwKlassinfo_DoubleClick(object sender, EventArgs e)
        {
            if (dgwKlassinfo.CurrentRow.Cells["Klass"].Value != null)
            {
                fönsterhanterare1.HanteraVisaTavlingKlass(Tavling, dgwKlassinfo.CurrentRow.Cells["Klass"].Value.ToString());
                VisaTavlingKlassInfo();
            }
        }
    }
}
