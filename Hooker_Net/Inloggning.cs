using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker_GUI.Kontroller;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönsterklass för hantering av Inloggning
    /// </summary>
    public partial class Inloggning : Kontroller.FormBas
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public Inloggning()
        {
            //SkrivLog.SkrivPåLog("Inloggning initieras");
            InitializeComponent();
            lblDatabase.Text = "Database: " + DatabasNamn;
        }

        /// <summary>
        ///     Alla texter hämtas och knapparna initieras
        /// </summary>
        private void InitieraTexter()
        {
            this.Text = Översätt("Text", this.Text);
            lblAnvandarnamn.Text = Översätt("Text", lblAnvandarnamn.Text);
            lblLosenord.Text = Översätt("Text", lblLosenord.Text);

            btnNy.Text = Översätt("Text", "Knapp_Ny");
            btnOK.Text = Översätt("Text", "Knapp_OK");
            btnAvbryt.Text = Översätt("Text", "Knapp_Avbryt");
        }

        /// <summary>
        /// NY-knappen tryckt, öppna användarInfo
        /// </summary>
        private void btnNy_Click(object sender, EventArgs e)
        {
            AnvandareInfo anvandare = new AnvandareInfo();
            anvandare.NyAnvandare = true;
            anvandare.InitieraNyAnvandare();
            anvandare.Show();
        }

        /// <summary>
        /// OK-knappen tryckt, kolla användare och lösenord
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            Anvandare anvandare = new Anvandare();
            AnvandareAktivitet anvandareAktivitet = new AnvandareAktivitet();

            try
            {
                if (txtAnvandarnamn.TextLength > 0)
                {
                    Timglas.WaitCurson();

                    anvandare = anvandareAktivitet.LoggaIn(txtAnvandarnamn.Text, txtLosenord.Text);

                    if (anvandare != null)
                    {
                        //Inloggningen lyckades, spara nu användarobjektet
                        anvandare.SenastInloggadDatum = DateTime.Now.ToString("yyyy-MM-dd");
                        AppUser = anvandare;
                        //anvandareAktivitet.Spara(AppUser, false, ref FelID, ref Feltext);
                        anvandareAktivitet.InloggningOK(anvandare.AnvandarID, anvandare.SenastInloggadDatum,
                            ref FelID, ref Feltext);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        txtAnvandarnamn.Text = "";
                        txtLosenord.Text = "";
                        lblMeddelande.Text = ÖversättFelmeddelande("Felmeddelande", "INLOGGNINGMISSING");
                        lblMeddelande.ForeColor = Color.Red;
                        this.DialogResult = DialogResult.None;
                        txtAnvandarnamn.Focus();
                    }
                    Timglas.DefaultCursor();

                }
                else
                {
                    VisaFelmeddelande("ANVANDAREMISSING");
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Avbrytknappen är tryckt
        /// </summary>
        private void btnAvbryt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Inloggning_Load(object sender, EventArgs e)
        {
            InitieraTexter();
            btnOK.Enabled = true;
        }

        private void Inloggning_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }

    }
}