using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;

namespace Hooker_GUI
{
    public partial class SökAnvändare : FormBas
    {
        private void SökAnvändare_Load(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            InitieraTexter();
            FyllComboBoxKod(cboAnvandargrupp, Kodtabell.Anvandargrupper, "01");
            this.MdiParent = MdiMain;
            txtNamn.Focus();
            Timglas.DefaultCursor();
        }

        private void Knappkontroller1_OnKnapp0Click_1(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Hanterar Ny-knappen
        /// </summary>
        private void Knappkontroller1_OnKnapp1Click_1(object sender, EventArgs e)
        {
            hanteraFönster1.HanteraNyAnvandare();
        }

        /// <summary>
        /// Hanterar Öppna-knappen
        /// </summary>
        private void Knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            hanteraFönster1.HanteraVisaAnvandare(dgwSokAnvandare.CurrentRow.Cells["AnvandarID"].Value.ToString());
        }

        /// <summary>
        /// Hanterar Sök-Knappen
        /// </summary>
        private void Knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            VisaResultat();
            Timglas.DefaultCursor();
        }

        /// <summary>
        /// Hanterar Avbryt-Knappen
        /// </summary>
        private void Knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
