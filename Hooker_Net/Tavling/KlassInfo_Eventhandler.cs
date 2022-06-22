using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Hooker_GUI
{
    public partial class KlassInfo : FormBas
    {

        private void KlassInfo_Load(object sender, EventArgs e)
        {
            this.InitieraTexter();
            FormsUppdaterad = false;
            FormEvent();
            cboKlass.Focus();
        }

        private void FormEvent()
        {
            foreach (var control in Controls.OfType<Control>())
            {
                control.Click += Klass_Changed;
                control.TextChanged += Klass_Changed;
            }
            foreach (var control in gbxRondinfo.Controls.OfType<Control>())
            {
                control.Click += Klass_Changed;
                control.TextChanged += Klass_Changed;
            }
        }

        private void Klass_Changed(object sender, EventArgs e)
        {
            FormsUppdaterad = true;
            knappkontroller1.btnKnapp2.Enabled = true;
        }

        private void dgwRondinfo_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox golfcombo = null;

            if (dgwRondinfo.CurrentCell.ColumnIndex == 4 && e.Control is ComboBox)
                golfcombo = e.Control as ComboBox;

            if (golfcombo != null)
            {
                golfcombo.SelectedIndexChanged -= new EventHandler(GolfComboBox_SelectedIndexChanged);
                golfcombo.SelectedIndexChanged += new EventHandler(GolfComboBox_SelectedIndexChanged);
            }
        }

        private void GolfComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox golfcombo = (ComboBox)sender;
            string item = null;
            try
            {
                if (dgwRondinfo.CurrentCell.ColumnIndex == 4)
                    item = golfcombo.Text;
                if (item != null)
                    FyllBanorCombo((int)golfcombo.SelectedValue);
            }
            catch (HookerException hex)
            {
                VisaMeddelande("FELMEDMISSING" + Environment.NewLine + hex.Message);
            }
        }

        /// <summary>
        /// Hanterar NyKlass-knappen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void knappkontroller1_OnKnapp1Click(object sender, EventArgs e)
        {
            NyTavlingKlass = true;
            fönsterhanterare1.HanteraNyTavlingKlass(Tavling);
            this.DialogResult = System.Windows.Forms.DialogResult.None;
        }

        /// <summary>
        /// Hantera Spara-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            Hooker.Affärslager.TavlingKlassAktivitet tavlingKlassAktivitet;

            try
            {
                if (AllaFältOK())
                {
                    tavlingKlassAktivitet = new TavlingKlassAktivitet();

                    if (NyTavlingKlass)
                    {
                        tavlingKlassAktivitet.Spara(Tavling, NyTavlingKlass, ref FelID, ref Feltext);
                        VisaMeddelande("Information_OK");
                    }
                    else
                    {
                        tavlingKlassAktivitet.Spara(TavlingKlass, ref FelID, ref Feltext);
                        if (BehandlaTavlingRond())
                        {
                            VisaMeddelande("Information_OK");
                        }
                        else
                        {
                            VisaTavlingKlass();
                            this.DialogResult = System.Windows.Forms.DialogResult.None;
                            dgwRondinfo.Enabled = true;
                            dgwRondinfo.Focus();
                        }
                    }

                    //VisaMeddelande("Information_OK");

                    //Nu visar vi posten som den ser ut i databasen
                    if (NyTavlingKlass)
                    {
                        this.NyTavlingKlass = false;
                        knappkontroller1.btnKnapp3.Enabled = true;
                        VisaTavlingKlass();
                        this.DialogResult = System.Windows.Forms.DialogResult.None;
                        dgwRondinfo.Enabled = true;
                        dgwRondinfo.Focus();
                    }
                }
                else
                {
                    //Om fel returnerades ska objektet städas vid nyupplägg
                    if (NyTavlingKlass)
                    {
                        TavlingKlass = null;
                    }
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                }
            }
            catch (HookerException)
            {
                if (NyTavlingKlass)
                {
                    TavlingKlass = null;
                }
                VisaFelmeddelande(FelID, Feltext);
            }
        }

        /// <summary>
        /// Hanterar Ta Bort-knappen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            string svar;
            TavlingKlassAktivitet tavlingKlassAktivitet = new TavlingKlassAktivitet();

            try
            {
                svar = VisaFråga("Varning_TABORTTAVLINGKLASS");

                //Kolla om svaret gäller fast det finns anmälda
                if (svar.Equals("Ja"))
                {
                    //Ta nu bort tävlingen
                    tavlingKlassAktivitet.TaBort(TavlingKlass, ref FelID, ref Feltext);
                    VisaMeddelande("Information_OK");
                    Tavling.TaBortTavlingKlass();


                    if (Tavling.HarTavlingRond())
                    {
                        Tavling.TaBortTavlingRond();
                    }
                    //this.InitieraNyTavlingKlass();
                    //fönsterhanterare1.HanteraVisaTavling(TavlingID.ToString());
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                    this.Close();
                }
            }
            catch (HookerException)
            {
                VisaFelmeddelande(FelID, Feltext);
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Hanterar Avbryt-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void knappkontroller1_OnKnapp1Click_1(object sender, EventArgs e)
        {
            NyTavlingKlass = true;
            fönsterhanterare1.HanteraNyTavlingKlass(Tavling);
            this.DialogResult = System.Windows.Forms.DialogResult.None;
        }

        /// <summary>
        /// Ta bort aktuell TavlingRondpost
        /// </summary>
        private void dgwRondinfo_UserDeletedRow(object sender, System.Windows.Forms.DataGridViewRowEventArgs e)
        {
            TavlingRond tavlingRond;
            TavlingRondAktivitet tavlingRondAktivitet = new TavlingRondAktivitet();

            if (dgwRondinfo.CurrentRow.Cells["RondID"].Value != null)
            {
                tavlingRond = new TavlingRond();
                tavlingRond.RondId = (int)dgwRondinfo.CurrentRow.Cells["RondID"].Value;
                tavlingRondAktivitet.TaBort(tavlingRond, ref FelID, ref Feltext);
            }
        }

        private void dgwRondinfo_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (dgwRondinfo.IsCurrentCellDirty)
            {
                FormsUppdaterad = true;
            }
        }

        private void dgwRondinfo_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwRondinfo.IsCurrentCellDirty)
            {
                if (dgwRondinfo.CurrentCell.ColumnIndex > 6)
                {
                    BehandlaTavlingRond();
                    FyllBild();
                }
            }
        }

        private void dgwRondinfo_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            FyllGolfklubbCombo();
        }

        private void dgwRondinfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
