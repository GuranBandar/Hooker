using Hooker.Affärslager;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Hooker_GUI
{
    public partial class GolfklubbInfo : FormBas
    {
        #region "Händelsehanterare"

        private void GolfklubbInfo_Load(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            InitieraTexter();
            this.MdiParent = MdiMain;
            txtGolfklubbNamn.Focus();
            FormEvent();
            FormsLaddar = false;
            Timglas.DefaultCursor();
        }

        /// <summary>
        /// Hantera Ny Bana
        /// </summary>
        private void knappkontroller1_OnKnapp0Click_1(object sender, EventArgs e)
        {
            fönsterhanterare1.HanteraNyBana(Golfklubb.GolfklubbNr.ToString());
        }

        /// <summary>
        /// Hanterar Spara & stäng-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp1Click(object sender, EventArgs e)
        {
            this.knappkontroller1_OnKnapp2Click(sender, e);
            this.Close();
        }

        /// <summary>
        /// Hantera Spara-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            GolfklubbAktivitet golfklubbAktivitet;
            int nyttGolfklubbNr;

            try
            {
                Timglas.WaitCurson();
                if (AllaFältIGolfklubbOK())
                {
                    golfklubbAktivitet = new GolfklubbAktivitet();
                    nyttGolfklubbNr = golfklubbAktivitet.Spara(Golfklubb, NyGolfklubb, ref FelID, ref Feltext);
                    VisaMeddelande("Information_OK");

                    //Nu visar vi Golfklubben som den ser ut i databasen

                    if (NyGolfklubb)
                    {
                        GolfklubbNr = nyttGolfklubbNr;
                        this.NyGolfklubb = false;
                    }
                    FormsLaddar = true;
                    VisaGolfklubb();
                }
                else
                {
                    //Om fel returnerades ska objektet städas vi nyupplägg
                    if (NyGolfklubb)
                    {
                        Golfklubb = null;
                    }
                }
                Timglas.DefaultCursor();
            }
            catch (HookerException)
            {
                if (NyGolfklubb)
                {
                    Golfklubb = null;
                }

                VisaFelmeddelande(FelID, Feltext);
            }
            finally
            {
                knappkontroller1.btnKnapp0.Enabled = true;
                knappkontroller1.btnKnapp1.Enabled = false;
                knappkontroller1.btnKnapp2.Enabled = false;
                knappkontroller1.btnKnapp4.Focus();
                FormsUppdaterad = false;
            }
        }

        /// <summary>
        /// Hanterar Ta Bort-Knappen
        /// </summary>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            //Kolla först om rundor finns reggade på banan, 
            //då ska det förstås inte gå att ta bort banan
            BanaAktivitet banaAktivitet = new BanaAktivitet();
            DataSet banor;
            string svar;
            GolfklubbAktivitet golfklubbAktivitet;

            try
            {
                banor = banaAktivitet.HämtaBanorMedGolfklubbNr(Golfklubb.GolfklubbNr);
                if (banor.Tables[0].Rows.Count == 0)
                {
                    svar = VisaFråga("Varning_TABORTGOLFKLUBB");

                    if (svar.Equals("Ja"))
                    {
                        golfklubbAktivitet = new GolfklubbAktivitet();
                        golfklubbAktivitet.TaBort(Golfklubb, ref FelID, ref Feltext);
                        VisaMeddelande("Information_OK");
                        this.Close();
                    }
                }
                else
                {
                    VisaFelmeddelande("GOLFKLUBBHARBANA");
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
        /// Hanterar Avbryt-Knappen
        /// </summary>
        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            string svar;

            if (FormsUppdaterad)
            {
                svar = VisaFråga("Varning_UppdateringGjord");
                if (svar.Equals("Ja"))
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// Användaren har dubbelklickat på en rad, då ska Banan visas 
        /// </summary>
        private void dgwBanor_DoubleClick(object sender, EventArgs e)
        {
            if (dgwBanor.CurrentRow.Cells["BanaNr"].Value != null)
            {
                fönsterhanterare1.HanteraVisaBana(dgwBanor.CurrentRow.Cells["BanaNr"].Value.ToString());
            }
        }

        private void cboLand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FormsLaddar)
            {
                FormsUppdaterad = true;
                knappkontroller1.btnKnapp1.Enabled = true;
                knappkontroller1.btnKnapp2.Enabled = true;
            }
            FyllDistriktCombo(((ComboBoxKod)cboLand.SelectedItem).Kod.ToString());
        }

        private void cboDistrikt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FormsLaddar)
            {
                FormsUppdaterad = true;
                knappkontroller1.btnKnapp1.Enabled = true;
                knappkontroller1.btnKnapp2.Enabled = true;
            }
        }

        private void FormEvent()
        {
            foreach (var control in Controls.OfType<Control>())
            {
                control.Click += Golfklubb_Changed;
                control.TextChanged += Golfklubb_Changed;
            }
            foreach (var adressControl in gbxAdressinfo.Controls.OfType<Control>())
            {
                adressControl.Click += Golfklubb_Changed;
            }
            foreach (var banaInfo in gbxBanor.Controls.OfType<Control>())
            {
                banaInfo.Click += Golfklubb_Changed;
            }
        }

        private void Golfklubb_Changed(object sender, EventArgs e)
        {
            FormsUppdaterad = true;
            knappkontroller1.btnKnapp1.Enabled = true;
            knappkontroller1.btnKnapp2.Enabled = true;
        }

        /// <summary>
        /// Användaren har klickat på länken till klubbens hemsida
        /// </summary>
        private void lnkHemsida_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            base.StartWebbrowser(txtHemsida.Text);
        }
        #endregion
    }
}
