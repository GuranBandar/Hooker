using Hooker.Affärslager;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Hooker_GUI
{
    public partial class SystemvariablerInfo : FormBas
    {

        private void SystemvariablerInfo_Load(object sender, EventArgs e)
        {
            InitieraTexter();
            this.MdiParent = MdiMain;
            FormEvent();
            txtApplikationsnamn.Focus();
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
        ///     Hantera Spara-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            SystemvariablerAktivitet systemvariablerAktivitet;

            try
            {
                Timglas.WaitCurson();
                FyllObjektet();
                systemvariablerAktivitet = new SystemvariablerAktivitet();
                systemvariablerAktivitet.Spara(Systemvariabler, NySystemvariabel, ref FelID, ref Feltext);
                VisaMeddelande("Information_OK");

                //Nu visar vi Systemvaribler som den ser ut i databasen
                if (NySystemvariabel)
                {
                    this.NySystemvariabel = false;
                }

                this.Hämta();
                knappkontroller1.btnKnapp2.Enabled = false;
                knappkontroller1.btnKnapp3.Enabled = false;
                FormsUppdaterad = false;

                Timglas.DefaultCursor();
            }
            catch (HookerException)
            {
                if (NySystemvariabel)
                {
                    Systemvariabler = null;
                }
                VisaFelmeddelande(FelID, Feltext);
            }
        }

        /// <summary>
        ///     Hanterar Ta Bort-Knappen
        /// </summary>
        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            ////Kolla först om rundor finns reggade på spelaren, 
            ////då ska det förstås inte gå att ta bort spelaren
            //Hooker.Affärslager.RundaAktivitet rundaAktivitet = new Hooker.Affärslager.RundaAktivitet();
            //int rundor;
            //string svar;
            //SpelareAktivitet spelareAktivitet;

            //try
            //{
            //    rundor = rundaAktivitet.KollaAntaletRundorForSpelare(Spelare.AktuelltSpelarID);
            //    if (rundor == 0)
            //    {
            //        svar = VisaFråga("Varning_TABORTSPELARE");

            //        if (svar.Equals("Ja"))
            //        {
            //            spelareAktivitet = new Hooker.Affärslager.SpelareAktivitet();
            //            spelareAktivitet.TaBort(Spelare, ref FelID, ref Feltext);
            //            VisaMeddelande("Information_OK");
            //            this.Close();
            //        }
            //    }
            //    else
            //    {
            //        VisaFelmeddelande("SPELAREHARRUNDA");
            //    }
            //}
            //catch (HookerException)
            //{
            //    VisaFelmeddelande(FelID, Feltext);
            //}
            //catch (Exception ex)
            //{
            //    HanteraUndantag(ex);
            //}
        }

        /// <summary>
        ///     Hanterar Avbryt-Knappen
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //txtWaitCursorFilePath.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogfil_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //txtApplofFilePath.Text = openFileDialog1.FileName;
            }
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

            knappkontroller1.btnKnapp0.Visible = false;
            knappkontroller1.btnKnapp1.Visible = false;
            knappkontroller1.btnKnapp2.Enabled = false;
            knappkontroller1.btnKnapp3.Enabled = false;
            knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_Spara");
            knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_TaBort");
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
        }

        private void FormEvent()
        {
            foreach (var control in Controls.OfType<Control>())
            {
                control.Click += Systemvariabel_Changed;
                control.TextChanged += Systemvariabel_Changed;
            }
        }

        private void Systemvariabel_Changed(object sender, EventArgs e)
        {
            FormsUppdaterad = true;
            knappkontroller1.btnKnapp2.Enabled = true;
            knappkontroller1.btnKnapp3.Enabled = true;
        }
        #endregion
    }
}
