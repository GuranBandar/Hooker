using System;
using System.Configuration;
using System.IO;

namespace Hooker.Gemensam
{
    /// <summary>
    /// Klass för loggning
    /// </summary>
    public static class Loggning
    {
        /// <summary>
        /// Skriv på logfilen om det ska göras
        /// </summary>
        /// <param name="meddelande"></param>
        public static void SkrivaPaLoggfil(string meddelande)
        {
            string logga = ConfigurationManager.AppSettings["Logga"];
            string Datum = DateTime.Now.ToString();

            try
            {
                if (logga == "Ja")
                {
                    string filePath = ConfigurationManager.AppSettings["filePath"];
                    string filename = ConfigurationManager.AppSettings["fileName"];

                    using (StreamWriter writer = File.AppendText(filePath + filename))
                    {
                        writer.WriteLine(Datum + ": " + meddelande);
                        writer.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AppendLog(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }
    }
}