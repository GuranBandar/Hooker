using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Hooker_GUI
{
    public partial class Rondresultat : FormBas
    {
        #region händelsehanterare
        private void Rondresultat_Load(object sender, EventArgs e)
        {
            this.InitieraTexter();
            FormEvent();
            this.MdiParent = MdiMain;
            FormsLaddar = false;
        }

        private void FormEvent()
        {
            foreach (var control in Controls.OfType<Control>())
            {
                control.Click += Rondresultat_Changed;
                control.TextChanged += Rondresultat_Changed;
            }
            foreach (var control in gbxUt.Controls.OfType<Control>())
            {
                control.Click += Rondresultat_Changed;
                control.TextChanged += Rondresultat_Changed;
                if (control.Name.StartsWith("txtSlag"))
                {
                    control.TextChanged += SlagTextBox_Changed;
                }
            }
            foreach (var control in gbxIn.Controls.OfType<Control>())
            {
                control.Click += Rondresultat_Changed;
                control.TextChanged += Rondresultat_Changed;
                if (control.Name.StartsWith("txtSlag"))
                {
                    control.TextChanged += SlagTextBox_Changed;
                }
            }
        }

        private void Rondresultat_Changed(object sender, EventArgs e)
        {
            if (!FormsLaddar)
            {
                FormsUppdaterad = true;
                knappkontroller1.btnKnapp2.Enabled = true;
            }
        }

        /// <summary>
        /// Hantera knappen för visa tävling
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void knappkontroller1_OnKnapp1Click(object sender, EventArgs e)
        {
            fönsterhanterare1.HanteraVisaTavling(TavlingID.ToString());
        }

        /// <summary>
        /// Hantera sparaknappen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            TavlingRondAktivitet tavlingRondAktivitet;
            TavlingRondResultatAktivitet tavlingRondResultatAktivitet;
            TavlingStartlistaAktivitet tavlingStartlistaAktivitet;

            try
            {

                if (AllaFältOK())
                {
                    Timglas.WaitCurson();
                    tavlingRondAktivitet = new TavlingRondAktivitet();
                    tavlingRondAktivitet.Spara(Tavling.TavlingRond[RondNr - 1], ref FelID, ref Feltext);
                    tavlingStartlistaAktivitet = new TavlingStartlistaAktivitet();
                    tavlingStartlistaAktivitet.UppdateraStartlista(Tavling, ref FelID, ref Feltext);
                    tavlingRondResultatAktivitet = new TavlingRondResultatAktivitet();
                    tavlingRondResultatAktivitet.Spara(Tavling, RondID, SpelarID, ref FelID, ref Feltext);
                    Timglas.DefaultCursor();
                    VisaMeddelande("Information_OK");
                    FyllRondResultat();
                    knappkontroller1.btnKnapp2.Enabled = false;
                    FormsUppdaterad = false;
                    cboSpelare.Focus();
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
        /// Hanterar Ta bort-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            TavlingRondResultatAktivitet tavlingRondResultatAktivitet = new TavlingRondResultatAktivitet(); ;
            string svar;

            try
            {
                //Kolla först om rundan ska tas bort 
                svar = VisaFråga("Varning_TABORTRUNDA");

                if (svar.Equals("Ja"))
                {
                    tavlingRondResultatAktivitet.TaBort(RondID, SpelarID, ref FelID, ref Feltext);
                    VisaMeddelande("Information_OK");
                    //this.Close();
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

        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboSpelare_SelectedIndexChanged(object sender, EventArgs e)
        {
            TavlingStartlista aktuellSpelare;
            if (cboSpelare.SelectedIndex != -1)
            {
                SpelarID = ((ComboBoxPar)cboSpelare.SelectedItem).Identifier;
                aktuellSpelare = (TavlingStartlista)((ComboBoxPar)cboSpelare.SelectedItem).Data;
                txtExaktHcp.Text = aktuellSpelare.ExaktHcp.ToString();
                txtErhallnaSlag.Text = aktuellSpelare.ErhallnaSlag.ToString();
                FyllRondResultat();
                knappkontroller1.btnKnapp2.Enabled = false;
                FormsUppdaterad = false;
                txtSlagHal1.Focus();
            }
        }

        private void cboTavling_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTavling.SelectedIndex != -1)
            {
                if (Tavling != null)
                {
                    Tavling.TaBortTavlingRondResultat();
                    RondNr = 0;
                    RondID = 0;
                }

                TavlingID = ((ComboBoxPar)cboTavling.SelectedItem).Identifier;

                if (!FormsLaddar)
                {
                    FyllKlasserCombo();
                    VisaBanaValdTävling();
                }
            }
        }

        private void cboKlass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKlass.SelectedIndex != -1)
            {
                Klass = ((ComboBoxKod)cboKlass.SelectedItem).Kod;
                FyllRonderCombo();
                FyllSpelareCombo();
            }
        }

        private void cboRondnr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRondnr.SelectedIndex != -1)
            {
                RondID = ((ComboBoxPar)cboRondnr.SelectedItem).Identifier;
                RondNr = int.Parse(((ComboBoxPar)cboRondnr.SelectedItem).Visa);
                TavlingRond = Tavling.HämtaTavlingRond(RondNr, TavlingID);
                FyllComboBoxKod(cboStatus, Kodtabell.Rondstatus, TavlingRond.RondStatus);
                RondStatus = TavlingRond.RondStatus;
                VisaBanaValdTävling();

                if (!FormsLaddar)
                {
                    FyllRondResultat();
                }
                knappkontroller1.btnKnapp2.Enabled = false;
                FormsUppdaterad = false;
                txtSlagHal1.Focus();
            }
        }

        private void SlagTextBox_Changed(object sender, EventArgs e)
        {
            TextBox txtSlag = (TextBox)sender;
            string cc = txtSlag.Name;
            int halNr = Convert.ToInt32(cc.Substring(10, cc.Length - 10));
            TextBox txtPoangHal = Controls.Find("txtPoangHal" + halNr, true).FirstOrDefault() as TextBox;
            txtPoangHal.Text = RaknaUtAntalPoang(halNr).ToString();
        }
        #endregion
    }
}
