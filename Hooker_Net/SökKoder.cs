using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Collections.Generic;

namespace Hooker_GUI
{
    /// <summary>
    ///     Fönsterklass för att söka koder
    /// </summary>
    public partial class SökKoder : FormBas
    {
        List<Koder> _koder;
        private bool _sokningGjord = false;

        /// <summary>
        /// Objekt för Koder
        /// </summary>
        public List<Koder> koder
        {
            get
            {
                return _koder;
            }
            set
            {
                _koder = value;
            }
        }

        /// <summary>
        ///     Konstruktor
        /// </summary>
        public SökKoder()
        {
            InitializeComponent();
        }

        #region "Privata metoder"
        /// <summary>
        ///     Initierar alla texter på kontrollerna
        /// </summary>
        private void InitieraTexter()
        {
            this.Text = Översätt("Text", this.Text);
            gbxKodtyper.Text = Översätt("Text", gbxKodtyper.Text);

            foreach (System.Windows.Forms.Control cc in gbxKodtyper.Controls)
            {
                if (cc.Name.StartsWith("lbl"))
                {
                    //då ska vi flytta lite till textboxen
                    cc.Text = Översätt("Text", cc.Text);
                }
            }

            for (int i = 0; i < dgwSökKoder.Columns.Count; i++)
            {
                dgwSökKoder.Columns[i].HeaderText = Översätt("Text", dgwSökKoder.Columns[i].HeaderText);
            }

            knappkontroller1.btnKnapp0.Visible = false;
            knappkontroller1.btnKnapp1.Text = Översätt("Text", "Knapp_Ny");
            knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_Öppna");
            knappkontroller1.btnKnapp2.Enabled = false;
            knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_Sök");
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
        }

        /// <summary>
        ///     Visar sökt urval i datagridden
        /// </summary>
        private void VisaResultat()
        {
            Hooker.Affärslager.KoderAktivitet koderAktivitet = new Hooker.Affärslager.KoderAktivitet();
            string typ = "";

            try
            {
                Timglas.WaitCurson();

                if ((ComboBoxKod)cboKodtyper.SelectedItem != null)
                {
                    typ = ((ComboBoxKod)cboKodtyper.SelectedItem).Kod.ToString();
                }

                dgwSökKoder.Rows.Clear();
                _sokningGjord = true;
                knappkontroller1.btnKnapp2.Enabled = false;
                koder = koderAktivitet.SökKoder(Convert.ToInt32(typ), txtArgument.Text.ToString(), "Varde");

                if (koder != null)
                {
                    for (int i = 0; i <= koder.Count - 1; i++)
                    {
                        dgwSökKoder.Rows.Add();
                        dgwSökKoder.Rows[i].Cells[0].Value = koder[i].Typ.ToString();
                        dgwSökKoder.Rows[i].Cells[1].Value = koder[i].Argument.ToString();
                        dgwSökKoder.Rows[i].Cells[2].Value = koder[i].Varde.ToString();
                    }
                    dgwSökKoder.Rows[0].Cells[0].DataGridView.Focus();
                    knappkontroller1.btnKnapp2.Enabled = true;
                }
                else
                {
                    VisaFelmeddelande("KODERMISSING");
                }
                Timglas.DefaultCursor();
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }
        #endregion

        #region Händelsehanterare
        private void SökKoder_Load(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            InitieraTexter();
            FyllComboBoxKod(cboKodtyper, Kodtabell.Alla_koder, "");
            this.MdiParent = MdiMain;
            cboKodtyper.Focus();
            Timglas.DefaultCursor();
        }

        private void SökKoder_Enter(object sender, EventArgs e)
        {
            if (_sokningGjord)
            {
                VisaResultat();
            }
        }

        /// <summary>
        ///     Hanterar Ny-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp1Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwSökKoder.CurrentRow == null)
                {
                    VisaFelmeddelande("KODMISSING");
                    return;
                }

                if (dgwSökKoder.CurrentRow.Cells["Typ"].Value != null)
                {
                    fönsterhanterare1.HanteraNyKod(Convert.ToInt32(dgwSökKoder.CurrentRow.Cells["Typ"].Value.ToString()));
                }
                else
                {
                    fönsterhanterare1.HanteraNyKod(Convert.ToInt32(((ComboBoxKod)cboKodtyper.SelectedItem).Kod.ToString()));
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        ///     Användaren har tryckt på knappen "Öppna", och förhoppningsvis också markerat en rad.
        /// </summary>
        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            string typ = "";
            string argument = "";
            try
            {
                if (dgwSökKoder.CurrentRow.Selected || dgwSökKoder.CurrentCell.Selected)
                {
                    if (dgwSökKoder.CurrentRow.Cells["Typ"].Value != null)
                    {
                        typ = dgwSökKoder.CurrentRow.Cells["Typ"].Value.ToString();
                        argument = dgwSökKoder.CurrentRow.Cells["Argument"].Value.ToString();
                    }
                }

                //Om typ = blank är ingen rad markerad
                if (typ == "")
                {
                    VisaFelmeddelande("INGENRADMARKERAD");
                }
                else
                {
                    fönsterhanterare1.HanteraVisaKoder(Convert.ToInt32(typ), argument);
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        ///     Hanterar Sök-Knappen
        /// </summary>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            VisaResultat();
        }

        /// <summary>
        ///     Hanterar Avbryt-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        ///     Användaren har fibblat i combon, då ska Koderna visas 
        /// </summary>
        private void cboKodtyper_SelectedIndexChanged(object sender, EventArgs e)
        {
            VisaResultat();
        }

        /// <summary>
        ///     Användaren har dubbelklickat på en rad, då ska Koden visas 
        /// </summary>
        private void dgwSökKoder_DoubleClick(object sender, EventArgs e)
        {
            if (dgwSökKoder.CurrentRow.Cells["Typ"].Value != null)
            {
                fönsterhanterare1.HanteraVisaKoder(Convert.ToInt32(dgwSökKoder.CurrentRow.Cells["Typ"].Value.ToString()),
                    dgwSökKoder.CurrentRow.Cells["Argument"].Value.ToString());
            }
        }
        #endregion
    }
}
