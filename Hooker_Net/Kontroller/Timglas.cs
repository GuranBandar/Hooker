using Hooker.Affärslager;
using System;
using System.IO;
using System.Windows.Forms;

namespace Hooker_GUI.Kontroller
{
    /// <summary>
    /// Klass för Timglas
    /// </summary>
    public class Timglas : FormBas, IDisposable
    {
        public static Cursor WaitCursor { get; set; }
        /// <summary>
        /// Sätter Wait-Cursor
        /// </summary>
        /// <returns>Current Cursor</returns>
        public static Cursor WaitCurson()
        {
            try
            {
                if (WaitCursor == null)
                {
                    CursorsAktivitet cursorsAktivitet = new CursorsAktivitet();
                    int waitCursorImageID = int.Parse(Systemvariabel.WaitCursorImageID);
                    Hooker.Affärsobjekt.Cursors cursors = cursorsAktivitet.Hämta(waitCursorImageID);
                    WaitCursor = new Cursor(ReadResourceFile(cursors.Cursornamn + ".cur"));
                }
                Cursor.Current = WaitCursor;
                return Cursor.Current;
            }
            catch
            {
                return Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Tillbaka till DefaultCursor
        /// </summary>
        /// <returns>Default Cursor</returns>
        public new static Cursor DefaultCursor()
        {
            return Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Read contents of an embedded resource file
        /// </summary>
        private static string ReadResourceFile(string filename)
        {
            String strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            String strFilePath = Path.Combine(strAppPath, "Resources");
            String strFullFilename = Path.Combine(strFilePath, filename);

            return strFullFilename;
        }
    }
}
