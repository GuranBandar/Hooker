using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GemensamService;
using System.IO;

namespace Hooker.Gemensam
{
    /// <summary>
    /// Skriv på loggfil
    /// </summary>
    public class SkrivLog
    {
        /// <summary>
        /// 
        /// </summary>
        protected static string Applogfil { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected static bool WriteToLog { get; set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public SkrivLog()
        {
            Applogfil = Konfiguration.GetConfigData("Applogfil");
            WriteToLog = Konfiguration.GetConfigData("WriteToLog").Equals("True") ? true : false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        public static void SkrivPåLog(string post)
        {
            if (WriteToLog)
            {
                StreamWriter writer = new StreamWriter(Applogfil, true);
                writer.WriteLine(DateTime.Now + " " + post);
                writer.Close();
            }
        }
    }
}
