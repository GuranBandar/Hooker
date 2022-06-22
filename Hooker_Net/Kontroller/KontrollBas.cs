using System.Windows.Forms;

namespace Hooker_GUI.Kontroller
{
    /// <summary>
    /// Baskontroll för UserControls
    /// </summary>
    public partial class KontrollBas : UserControl
    {
        protected static bool KontrollLaddas { get; set; }

        /// <summary>
        /// FelID från metodanrop till GUI:et
        /// </summary>
        public static string felID = "";

        /// <summary>
        /// FelText från metodanrop till GUI:et
        /// </summary>
        public static string feltext = "";

        /// <summary>
        /// Defaultkonstruktor
        /// </summary>
        public KontrollBas()
        {
            InitializeComponent();
        }
    }
}
