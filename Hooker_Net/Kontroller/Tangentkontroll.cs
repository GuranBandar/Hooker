using System.Windows.Forms;

namespace Hooker_GUI.Kontroller
{
    /// <summary>
    /// Klass som kollar tangenttryckningar
    /// </summary>
    public partial class Tangentkontroll : UserControl
    {
        private static int _foregandeTangent;
        /// <summary>
        /// Konstruktor
        /// </summary>
        public Tangentkontroll()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Kollar den tangent som är tryckt. Om tangenten är en siffra eller bokstav returneras true
        /// annars returneras false.
        /// </summary>
        /// <returns>True eller false</returns>
        public bool KollaTangent(KeyEventArgs e)
        {
            bool result = false;

            //Spara en ev Alttangent, kortkommandon du vet ....!
            if (e.KeyValue == 18)
            {
                _foregandeTangent = e.KeyValue;
                return false;
            }
            //om föregående tangent är en alt, ställd tillbaka och hoppa ur (kontrollen har gjort sitt nu..?)
            if (_foregandeTangent == 18)
            {
                _foregandeTangent = 0;
                return false;
            }
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                result = true;
            }
            if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                result = true;
            }
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Back)
            {
                result = true;
            }

            //Lite specialtecken som ö, å, ä, komma, minus och punkt är naturligtvis OK
            if (e.KeyValue == 192 || e.KeyValue == 221 || e.KeyValue == 222 || e.KeyValue == 188 ||
                e.KeyValue == 189 || e.KeyValue == 190)
            {
                result = true;
            }

            switch (e.KeyCode)
            {
                case Keys.A:
                    result = true;
                    break;
                case Keys.B:
                    result = true;
                    break;
                case Keys.C:
                    result = true;
                    break;
                case Keys.D:
                    result = true;
                    break;
                case Keys.E:
                    result = true;
                    break;
                case Keys.F:
                    result = true;
                    break;
                case Keys.G:
                    result = true;
                    break;
                case Keys.H:
                    result = true;
                    break;
                case Keys.I:
                    result = true;
                    break;
                case Keys.J:
                    result = true;
                    break;
                case Keys.K:
                    result = true;
                    break;
                case Keys.L:
                    result = true;
                    break;
                case Keys.M:
                    result = true;
                    break;
                case Keys.N:
                    result = true;
                    break;
                case Keys.O:
                    result = true;
                    break;
                case Keys.P:
                    result = true;
                    break;
                case Keys.Q:
                    result = true;
                    break;
                case Keys.R:
                    result = true;
                    break;
                case Keys.S:
                    result = true;
                    break;
                case Keys.T:
                    result = true;
                    break;
                case Keys.U:
                    result = true;
                    break;
                case Keys.W:
                    result = true;
                    break;
                case Keys.V:
                    result = true;
                    break;
                case Keys.X:
                    result = true;
                    break;
                case Keys.Y:
                    result = true;
                    break;
                case Keys.Z:
                    result = true;
                    break;
            }
            return result;
        }
    }
}
