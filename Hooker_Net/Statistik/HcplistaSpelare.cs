using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;

namespace Hooker_GUI
{
    public partial class HcplistaSpelare : FormBas
    {
        private List<Hcplista> Hcplista { get; set; }
        private List<Spelare> spelarLista { get; set; }
        private Spelare Spelare { get; set; }
        private int SpelarID { get; set; }
        private DateTime FromDatum { get; set; }
        private DateTime TomDatum { get; set; }
        
        Fönsterhanterare fönsterhanterare = new Fönsterhanterare();

        public HcplistaSpelare()
        {
            Timglas.WaitCurson();
            FormsLaddar = true;
            InitializeComponent();
            Timglas.DefaultCursor();
        }
        /// <summary>
        /// Initierar alla texter på kontrollerna
        /// </summary>
        private void InitieraTexter()
        {
            try
            {
                this.Text = Översätt("Text", this.Text);
                gbxSpelarinfo.Text = Översätt("Text", gbxSpelarinfo.Text);                //lblPrognosEGA.Text = Översätt("Text", lblPrognosEGA.Text);

                foreach (System.Windows.Forms.Control cc in gbxSpelarinfo.Controls)
                {
                    if (cc.Name.StartsWith("lbl"))
                    {
                        cc.Text = Översätt("Text", cc.Text);
                    }
                }
                for (int i = 0; i < dgwHcplista.Columns.Count; i++)
                {
                    if (string.IsNullOrEmpty(dgwHcplista.Columns[i].HeaderText))
                    {
                        dgwHcplista.Columns[i].HeaderText = "";
                    }
                    else
                    {
                        dgwHcplista.Columns[i].HeaderText = Översätt("Text", dgwHcplista.Columns[i].HeaderText);
                    }
                }
                knappkontroller1.btnKnapp0.Visible = false;
                knappkontroller1.btnKnapp1.Visible = false;
                knappkontroller1.btnKnapp2.Enabled = false;
                knappkontroller1.btnKnapp3.Enabled = false;
                knappkontroller1.btnKnapp2.Text = Översätt("Text", "Knapp_HcpGraf");
                knappkontroller1.btnKnapp3.Text = Översätt("Text", "Knapp_Sök");
                knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        /// <summary>
        /// Initiera datum from och tom, from tre år bakåt
        /// </summary>
        private void InitieraDatum()
        {
            //Initiera med datum
            FromDatum = DateTime.Today.AddYears(- 2);
            TomDatum = DateTime.Today;
            dtpFromDatum.Text = FromDatum.ToShortDateString();
            dtpTomDatum.Text = TomDatum.ToShortDateString();
        }

        private void HcplistaSpelare_Load(object sender, EventArgs e)
        {
            Timglas.WaitCurson();

            InitieraTexter();
            InitieraDatum();
            this.MdiParent = MdiMain;
            FormEvent();
            FormsLaddar = false;
            FyllSpelareCombo();
            //SpelarID = AppUser.SpelarID;
            VisaLista();
            cboSpelare.Focus();
            Timglas.DefaultCursor();
        }

        /// <summary>
        /// Hämta poster från urvalet och lista dem
        /// </summary>
        private void VisaLista()
        {
            HcplistaAktivitet hcplistaAktivitet = new HcplistaAktivitet();
            Hcplista = hcplistaAktivitet.HämtaHcplista(SpelarID, FromDatum, TomDatum);
            dgwHcplista.Rows.Clear();
            int rowNr = 1;
            int i = 0;

            foreach (Hcplista hcp in Hcplista)
            {
                dgwHcplista.Rows.Add();
                dgwHcplista.Rows[i].Cells["Radnr"].Value = rowNr;
                dgwHcplista.Rows[i].Cells["Typ"].Value = hcp.Typ;
                dgwHcplista.Rows[i].Cells["RundaNr"].Value = hcp.RundaNr;
                dgwHcplista.Rows[i].Cells["Datum"].Value =
                    ("STD").Formatera(DateTime.Parse(hcp.Datum.ToString()));
                dgwHcplista.Rows[i].Cells["Hcp"].Value =
                    ("ND1").Formatera(decimal.Parse(hcp.Hcp.ToString()));
                dgwHcplista.Rows[i].Cells["NyttHcp"].Value =
                    ("ND1").Formatera(decimal.Parse(hcp.NyttHcp.ToString()));
                dgwHcplista.Rows[i].Cells["PlusMinus"].Value =
                    ("ND1").Formatera(decimal.Parse(hcp.PlusMinus.ToString()));
                dgwHcplista.Rows[i].Cells["Notering"].Value = hcp.Notering;
                if (hcp.PlusMinus < 0)
                    dgwHcplista.Rows[i].DefaultCellStyle.BackColor = Color.MistyRose;
                else if (hcp.PlusMinus > 0)
                    dgwHcplista.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
                i++;
                rowNr++;
            }

            dtpFromDatum.Focus();
            dgwHcplista.Refresh();
            knappkontroller1.btnKnapp2.Enabled = true;
            knappkontroller1.btnKnapp3.Enabled = true;
        }

        private void knappkontroller1_OnKnapp0Click(object sender, EventArgs e)
        {

        }

        private void knappkontroller1_OnKnapp1Click(object sender, EventArgs e)
        {

        }

        private void knappkontroller1_OnKnapp2Click(object sender, EventArgs e)
        {
            Spelare = spelarLista.Where(s => s.AktuelltSpelarID == 
                SpelarID).FirstOrDefault();
            fönsterhanterare.HanteraVisaHcplistaGraf(Spelare, Hcplista);
        }

        private void knappkontroller1_OnKnapp3Click(object sender, EventArgs e)
        {
            this.VisaLista();
        }

        /// <summary>
        /// Hanterar Avbryt-knappen
        /// </summary>
        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Hämta alla Spelare och fyll combon.
        /// </summary>
        private void FyllSpelareCombo()
        {
            SpelareAktivitet spelareAktivitet = new SpelareAktivitet();

            try
            {
                spelarLista = spelareAktivitet.SökSpelareAnvandare();

                if (spelarLista.Count > 0)
                {
                    if (cboSpelare.Items.Count == 0)
                    {
                        cboSpelare.Items.Clear();
                        cboSpelare.Items.Add(new ComboBoxPar(0, "", ""));
                        for (int i = 0; i < spelarLista.Count; i++)
                        {
                            cboSpelare.Items.Add(new ComboBoxPar(spelarLista[i].AktuelltSpelarID,
                                spelarLista[i].Namn, spelarLista[i]));
                        }
                    }

                    cboSpelare.SelectedItem = AppUser.SpelarID;
                    cboSpelare.DisplayMember = "visa";
                    SpelarID = AppUser.SpelarID;
                    txtExaktHcp.Text = spelarLista.Find(Spelare =>
                        Spelare.AktuelltSpelarID == AppUser.SpelarID).ExaktHcp.ToString();
                    //txtExaktHcp.Text = Spelare.ExaktHcp.ToString();
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        private void FormEvent()
        {
            foreach (var control in Controls.OfType<Control>())
            {
                control.Click += cboSpelare_SelectedIndexChanged;
                control.TextChanged += cboSpelare_SelectedIndexChanged;
                if (cboSpelare.Items.Count > 0)
                {
                    SpelarID = ((ComboBoxPar)cboSpelare.SelectedItem).Identifier;
                }
            }
            foreach (var dateFromControl in dtpFromDatum.Controls.OfType<Control>())
            {
                dateFromControl.Click += dtpFromDatum_ValueChanged;
                dateFromControl.TextChanged += dtpFromDatum_ValueChanged;
                FromDatum = dtpFromDatum.Value;
            }
            foreach (var dateTomControl in dtpTomDatum.Controls.OfType<Control>())
            {
                dateTomControl.Click += dtpTomDatum_ValueChanged;
                dateTomControl.TextChanged += dtpTomDatum_ValueChanged;
                TomDatum = dtpTomDatum.Value;
            }
        }

        private void cboSpelare_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormsUppdaterad = true;
            knappkontroller1.btnKnapp2.Enabled = true;
            if (cboSpelare.Items.Count > 0)
            {
                SpelarID = ((ComboBoxPar)cboSpelare.SelectedItem).Identifier;
            }
        }

        private void dtpFromDatum_ValueChanged(object sender, EventArgs e)
        {
            FormsUppdaterad = true;
            knappkontroller1.btnKnapp2.Enabled = true;
            FromDatum = dtpFromDatum.Value;
        }

        private void dtpTomDatum_ValueChanged(object sender, EventArgs e)
        {
            FormsUppdaterad = true;
            knappkontroller1.btnKnapp2.Enabled = true;
            TomDatum = dtpTomDatum.Value;
        }
    }
}
