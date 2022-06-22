using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using System;

namespace Hooker_GUI.Kontroller
{
    public partial class RundaNotering : FormBas
    {
        public int RundaNr { get; set; }
        public Runda Runda { get; set; }

        public RundaNotering()
        {
            InitializeComponent();
            InitieraTexter();
        }

        public RundaNotering(Runda runda)
        {
            InitializeComponent();
            InitieraTexter();
            Runda = runda;
            txtNotering.Text = Runda.Notering;
        }

        /// <summary>
        /// Visa rundans notering
        /// </summary>
        public void VisaRundaNotering()
        {
            RundaAktivitet rundaAktivitet = new RundaAktivitet();
            Timglas.WaitCurson();
            Runda = rundaAktivitet.HämtaRunda(RundaNr);
            if (Runda != null)
            {
                txtNotering.Text = Runda.Notering;
            }
            btnSpara.Enabled = false;
            btnSparaOStäng.Enabled = false;
        }

        /// <summary>
        /// Initierar alla texter på kontrollerna
        /// </summary>
        private void InitieraTexter()
        {
            try
            {
                this.Text = Översätt("Text", this.Text);
                lblNotering.Text = Översätt("Text", lblNotering.Text);
                btnAvbryt.Text = Översätt("Text", btnAvbryt.Text);
                btnSpara.Text = Översätt("Text", btnSpara.Text);
                btnSparaOStäng.Text = Översätt("Text", btnSparaOStäng.Text);
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        private void btnSparaOStäng_Click(object sender, EventArgs e)
        {
            btnSpara_Click(sender, e);
        }

        private void btnSpara_Click(object sender, EventArgs e)
        {
            Runda.Notering = txtNotering.Text;
            this.Close();
        }

        private void btnAvbryt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
