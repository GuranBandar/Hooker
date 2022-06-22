using Hooker_GUI.Kontroller;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace Hooker_GUI
{
    /// <summary>
    /// MDIFönster
    /// </summary>
    public partial class MDIFönster : FormBas
    {
        private int childFormNumber = 0;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public MDIFönster()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            // Create a new instance of the child form.
            Form childForm = new Form();
            // Make it a child of this MDI form before showing it.
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                // TODO: Add code here to open the file.
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
                // TODO: Add code here to save the current contents of the form to a file.
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// CascadeToolStripMenuItem
        /// </summary>
        public void CascadeToolStripMenuItem()
        {
            MdiMain.LayoutMdi(MdiLayout.Cascade);
        }

        /// <summary>
        /// TileVerticleToolStripMenuItem
        /// </summary>
        public void TileVerticleToolStripMenuItem()
        {
            MdiMain.LayoutMdi(MdiLayout.TileVertical);
        }

        /// <summary>
        /// TileHorizontalToolStripMenuItem
        /// </summary>
        public void TileHorizontalToolStripMenuItem()
        {
            MdiMain.LayoutMdi(MdiLayout.TileHorizontal);
        }

        /// <summary>
        /// CloseAllToolStripMenuItem
        /// </summary>
        public void CloseAllToolStripMenuItem()
        {
            foreach (Form childForm in MdiMain.MdiChildren)
            {
                childForm.Close();
            }
        }

        private void LaddaMeny()
        {
            menyKontroll1.LaddaMenyn();
        }

        private void MDIFönster_Load(object sender, EventArgs e)
        {
            try
            {
                LaddaFelmeddelande();
                LaddaOrdlistan();
                VisaLoggaIn();
                this.LaddaMeny();
                CultureInfo ci = CultureInfo.InstalledUICulture;
                //Tala om för hela appen att detta är MdiMain
                MdiMain = this;
                toolStripStatusLabel.Text = "Inloggad: " + AppUser.Anvandarnamn;
                toolStripDatabaseLabel.Text = "Database: " + DatabasNamn;
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Main-method
        /// </summary>
        [STAThread]
        static void Main()
        {
            MDIFönster mdi;
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(true);
                SkapaDefaultDB("Default_Databas");
                mdi = new MDIFönster();
                mdi.Show();
            }
            catch
            {
                return;
            }

            mdi.Refresh();
            Application.Run(mdi);
        }

        private void MDIFönster_FormClosed(object sender, FormClosedEventArgs e)
        {
            MDIFönster mdi = new MDIFönster();
            mdi.Close();
        }

        /// <summary>
        /// Visar inloggningsformuläret så att användaren kan logga in i systemet.
        /// </summary>
        protected void VisaLoggaIn()
        {
            Inloggning f = new Inloggning();

            f.ShowDialog(this);
            if (f.DialogResult == DialogResult.Cancel)
            {
                this.Close();
            }
        }
    }
}
