using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using System;
using System.Windows.Forms;

namespace Hooker_GUI.Kontroller
{
    /// <summary>
    /// Klass för Menykontrollerna
    /// </summary>
    public partial class MenyKontroll : UserControl
    {
        /// <summary>
        /// MDIParent
        /// </summary>
        public static MDIFönster MDIParent;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public MenyKontroll()
        {
            InitializeComponent();
        }

        public Anvandare Anvandare { get; set; }

        /// <summary>
        /// Gå igenom alla menyer, sätt text
        /// </summary>
        public void LaddaMenyn()
        {
            foreach (ToolStripMenuItem item in menuStrip.Items)
            {
                item.Text = FormBas.Översätt("Text", item.Text);
                InitieraMenytexter(item);
            }
        }

        /// <summary>
        /// Sätt text i alla undermenyer
        /// </summary>
        /// <param name="item">Aktuellt menyalternativ</param>
        private void InitieraMenytexter(ToolStripMenuItem item)
        {
            foreach (ToolStripItem subItem in item.DropDownItems)
            {
                if (subItem is ToolStripItem)
                {
                    if (subItem.Text.Length > 0)
                    {
                        subItem.Text = FormBas.Översätt("Text", subItem.Text);
                        if (item.DropDownItems.Count > 1)
                        {
                            InitieraMenytexter((ToolStripMenuItem)subItem);
                        }
                    }
                }
            }
        }

        #region Arkivmeny
        private void menuArkivNyAnvändare_Click(object sender, EventArgs e)
        {
            AnvandareInfo anvandare = new AnvandareInfo();
            anvandare.NyAnvandare = true;
            anvandare.InitieraNyAnvandare();
            anvandare.Show();
        }

        private void menuArkivNyBana_Click(object sender, EventArgs e)
        {
            BanaInfo bana = new BanaInfo();
            bana.NyBana = true;
            bana.InitieraNyBana();
            bana.Show();
        }

        private void menuArkivNyKod_Click(object sender, EventArgs e)
        {
            KoderInfo koderInfo = new KoderInfo();
            koderInfo.Typ = (int)Kodtabell.Alla_koder;
            koderInfo.NyKodtyp = true;
            koderInfo.InitieraNykod();
            koderInfo.Show();
        }

        private void menuArkivNyRedovisningspost_Click(object sender, EventArgs e)
        {
            RedovisningInfo redovsning = new RedovisningInfo();
            redovsning.NyRedovisning = true;
            redovsning.InitieraNyRedovisning();
            redovsning.Show();
        }

        private void menuArkivÖppnaRedovisningspost_Click(object sender, EventArgs e)
        {
            SökRedovisning sökRedovisning = new SökRedovisning();
            sökRedovisning.Show();
        }

        private void menuArkivNyRunda_Click(object sender, EventArgs e)
        {
            RundaInfo runda = new RundaInfo();
            runda.InitieraNyRunda();
            runda.Show();
        }

        private void menuArkivNySpelare_Click(object sender, EventArgs e)
        {
            SpelareInfo spelare = new SpelareInfo();
            spelare.NySpelare = true;
            spelare.InitieraNySpelare();
            spelare.Show();
        }

        private void menuArkivÖppnaBana_Click(object sender, EventArgs e)
        {
            SökBana sökBana = new SökBana("Bana");
            sökBana.Show();
        }

        private void menuArkivÖppnaHcpGraf_Click(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            HcplistaGraf hcplistaGraf = new HcplistaGraf();
            //Hämta spelarID från inloggningen
            Anvandare anvandare = FormBas.GetAppUser();
            hcplistaGraf.SpelarID = anvandare.SpelarID;
            hcplistaGraf.VisaHcplistaGraf();
            hcplistaGraf.Show();
        }

        private void menuArkivÖppnaKod_Click(object sender, EventArgs e)
        {
            SökKoder sökKoder = new SökKoder();
            sökKoder.Show();
        }

        private void menuArkivÖppnaRunda_Click(object sender, EventArgs e)
        {
            SökRunda sökRunda = new SökRunda();
            sökRunda.Show();
        }

        private void menuArkivÖppnaSpelare_Click(object sender, EventArgs e)
        {
            Timglas.WaitCurson();
            SpelareInfo spelareInfo = new SpelareInfo();
            //Hämta spelarID från inloggningen
            Anvandare = FormBas.GetAppUser();
            spelareInfo.SpelarID = Anvandare.SpelarID;
            spelareInfo.VisaSpelare();
            spelareInfo.Show();
        }

        private void menuArkivAvsluta_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Sökmeny

        private void menuSökBana_Click(object sender, EventArgs e)
        {
            SökBana sökBana = new SökBana("Bana");
            sökBana.Show();
        }

        private void menuSökGolfklubb_Click(object sender, EventArgs e)
        {
            SökBana sökBana = new SökBana("Klubb");
            sökBana.Show();
        }

        private void menuSökKoder_Click(object sender, EventArgs e)
        {
            SökKoder sökKoder = new SökKoder();
            sökKoder.Show();
        }

        private void menuSökRedovisning_Click(object sender, EventArgs e)
        {
            SökRedovisning sökRedovisning = new SökRedovisning();
            sökRedovisning.Show();
        }

        private void menuSökRunda_Click(object sender, EventArgs e)
        {
            SökRunda sökRunda = new SökRunda();
            sökRunda.Show();
        }

        private void menuSökSpelare_Click(object sender, EventArgs e)
        {
            SökSpelare sökSpelare = new SökSpelare();
            sökSpelare.Show();
        }
        private void MenuSökAnvändare_Click(object sender, EventArgs e)
        {
            SökAnvändare sokAnvandare = new SökAnvändare();
            sokAnvandare.Show();
        }

        #endregion

        #region Statistikmeny

        private void menuStatistikBananalys_Click(object sender, EventArgs e)
        {
            BanaAnalys bananalys = new BanaAnalys();
            bananalys.Show();
        }

        private void menuStatistikEGALista_Click(object sender, EventArgs e)
        {
            EGALista egalista = new EGALista();
            egalista.Show();
        }

        private void menuStatistikEkonomi_Click(object sender, EventArgs e)
        {
            EkonomiAnalys ekonomianalys = new EkonomiAnalys();
            ekonomianalys.Show();
        }

        private void menuStatistikGruppanalys_Click(object sender, EventArgs e)
        {
            Gruppanalys gruppanalys = new Gruppanalys();
            gruppanalys.Show();
        }

        private void menuStatistikHcplistaSpelare_Click(object sender, EventArgs e)
        {
            HcplistaSpelare hcplistaSpelare = new HcplistaSpelare();
            hcplistaSpelare.Show();
        }

        private void menuStatistikPuttstatistik_Click(object sender, EventArgs e)
        {
            Puttstatistik puttstatistik = new Puttstatistik();
            puttstatistik.Show();
        }

        private void menuStatistikRondanalys_Click(object sender, EventArgs e)
        {
            Rondanalys rondanalys = new Rondanalys();
            rondanalys.Show();
        }

        private void menuStatistikRondkostnad_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Fönstermeny

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDIFönster mdi = new MDIFönster();
            mdi.CascadeToolStripMenuItem();
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDIFönster mdi = new MDIFönster();
            mdi.TileVerticleToolStripMenuItem();
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDIFönster mdi = new MDIFönster();
            mdi.TileHorizontalToolStripMenuItem();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDIFönster mdi = new MDIFönster();
            mdi.CloseAllToolStripMenuItem();
        }

        #endregion

        private void menuHjälpOm_Click(object sender, EventArgs e)
        {
            Om om = new Om();
            om.Show();
        }

        private void menyAnvandareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnvandareInfo anvandareInfo = new AnvandareInfo();
            //Hämta AnvandarID från inloggningen
            Anvandare = FormBas.GetAppUser();
            anvandareInfo.AnvandarID = Anvandare.AnvandarID;
            anvandareInfo.VisaAnvandare();
            anvandareInfo.Show();
        }

        #region Tävlingar


        private void menuSokTavling_Click(object sender, EventArgs e)
        {
            SökTävling sökTävling = new SökTävling();
            sökTävling.Show();
        }

        private void menyRondresultat_Click(object sender, EventArgs e)
        {
            Rondresultat rondresultat = new Rondresultat();
            rondresultat.Show();
        }

        private void menuTävlingNyTävling_Click(object sender, EventArgs e)
        {
            TävlingInfo tävling = new TävlingInfo();
            tävling.NyTavling = true;
            tävling.InitieraNyTavling();
            tävling.Show();
        }

        private void menyDatabaseQuery_Click(object sender, EventArgs e)
        {
            DatabaseQuery databaseQuery = new DatabaseQuery();
            databaseQuery.Show();
        }

        private void menuArkivNyGolfklubb_Click(object sender, EventArgs e)
        {
            GolfklubbInfo golfklubb = new GolfklubbInfo();
            golfklubb.InitieraNyGolfklubb();
            golfklubb.Show();
        }
        #endregion

        private void menySendMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendMail sendMail = new SendMail();
            sendMail.Show();
        }

        private void menySystemvariablerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemvariablerInfo systemvariabler = new SystemvariablerInfo();
            systemvariabler.Show();
        }

        private void menuStatistik_Click(object sender, EventArgs e)
        {

        }

        private void menuArkivÖppna_Click(object sender, EventArgs e)
        {

        }
    }
}
