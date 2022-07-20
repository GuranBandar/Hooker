using GemensamService;
using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Hooker_GUI.Kontroller
{
    /// <summary>
    /// Basklass för alla Formulär
    /// </summary>
    public partial class FormBas : Form
    {
        //private static bool _configInlast;
        private static bool _formsUppdaterad;
        private static bool _formsLaddar;
        //private static string _databasNamn;
        private static System.Collections.Specialized.NameValueCollection _ordlista =
            new System.Collections.Specialized.NameValueCollection();
        private static System.Collections.Specialized.NameValueCollection _tooltip =
            new System.Collections.Specialized.NameValueCollection();
        private static System.Collections.Specialized.NameValueCollection _felmeddelande =
            new System.Collections.Specialized.NameValueCollection();

        public Hooker_GUI.Kontroller.Knappkontroller knappkontroll = new Knappkontroller();
        //private SkrivLog skrivlog = new SkrivLog();

        //        private static Anvandare _appUser;

        /// <summary>
        /// FelID från metodanrop till GUI:et
        /// </summary>
        public static string FelID = "";
        /// <summary>
        /// FelText från metodanrop till GUI:et
        /// </summary>
        public static string Feltext = "";
        /// <summary>
        /// Indikerar att applikationen håller på att avsluta
        /// </summary>
        static bool Avslutar = false;

        /// <summary>
        /// Property för vilken databas
        /// </summary>
        private IDatabasAccess DatabasAccess { get; set; }

        /// <summary>
        /// MDIBasformulär
        /// </summary>
        protected static MDIFönster MdiMain = null;

        protected static string DatabasNamn { get; set; }

        /// <summary>
        /// Påloggad användare
        /// </summary>
        protected static Anvandare AppUser { get; set; }

        /// <summary>
        /// Aktuell Cursor ikon
        /// </summary>
        protected Cursor AppIcon { get; set; }

        /// <summary>
        /// Aktuella systemvariabler
        /// </summary>
        protected static Systemvariabler Systemvariabel { get; set; }

        /// <summary>
        /// Formulär uppdaterad?
        /// </summary>
        protected bool FormsUppdaterad { get { return _formsUppdaterad; } set { _formsUppdaterad = value; } }

        /// <summary>
        /// Formulär laddas?
        /// </summary>
        protected bool FormsLaddar { get { return _formsLaddar; } set { _formsLaddar = value; } }

        protected static bool designMode;
        /// <summary>
        /// Konstruktor, sätter upp connectiom mot aktuell databas
        /// </summary>
        public FormBas()
        {
            //bool designMode;
            DatabasFabrik fabriken = new DatabasFabrik();
            //SystemvariablerInfo systemvariablerInfo = new SystemvariablerInfo();
            try
            {
                //SkrivLog.SkrivPåLog("DatabasAccess initieras");
                designMode = this.IsInDesignMode();
                InitializeComponent();

                if (!designMode)
                {
                    DatabasAccess = fabriken.GetDatabase();
                    InitieraSpelare();
                    InitieraSystemvariabler();
                }
            }
            catch (Exception)
            {
                Application.Exit();
                //SkrivLog.SkrivPåLog(ex.Message);
            }
        }

        /// <summary>
        /// Initera ett spelarobjekt för varje gång klassen exekveras, infon kan ju vara uppdaterad
        /// </summary>
        private void InitieraSpelare()
        {
            try
            {
                //Finns en AppUser, läs nu aktuell spelare för att uppdatera objektet 
                if (AppUser != null)
                {
                    Anvandare anvandare = AppUser;
                    SpelareAktivitet spelareAktivitet = new SpelareAktivitet();
                    Spelare spelare = spelareAktivitet.HämtaSpelare(anvandare.SpelarID);
                    if (spelare != null)
                    {
                        //anvandare.ExaktHcp = spelare.ExaktHcp;
                        //anvandare.HemmabanaNr = spelare.HemmabanaNr;
                        //anvandare.Revisionsdatum = spelare.Revisionsdatum;
                        //anvandare.Klass = spelare.Klass;
                        //anvandare.Namn = spelare.Namn;
                        //anvandare.UppdatDatum = spelare.UppdatDatum;
                        //if (spelare.GolfklubbNr != 0)
                        //{
                        //    anvandare.GolfklubbNr = spelare.GolfklubbNr;
                        //}
                        //AppUser = anvandare;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Initera ett Systemvariabelobjekt för varje gång klassen exekveras, infon kan ju vara uppdaterad
        /// </summary>
        private void InitieraSystemvariabler()
        {
            try
            {
                //Finns en Systemvariabel, läs nu aktuell systemvariabel för att uppdatera objektet 
                //if (Systemvariabel != null)
                //{
                Systemvariabler systemvariabler = new Systemvariabler();
                SystemvariablerAktivitet systemvariablerAktivitet = new SystemvariablerAktivitet();
                Systemvariabler systemvariabel = systemvariablerAktivitet.Hämta();
                if (systemvariabel != null)
                {
                    systemvariabler.Applikationsnamn = systemvariabel.Applikationsnamn;
                    systemvariabler.Epostadress = systemvariabel.Epostadress;
                    systemvariabler.MailFrom = systemvariabel.MailFrom;
                    systemvariabler.MailPassword = systemvariabel.MailPassword;
                    systemvariabler.MobilUtvecklare = systemvariabel.MobilUtvecklare;
                    systemvariabler.Utvecklare = systemvariabel.Utvecklare;
                    systemvariabler.Verktyg = systemvariabel.Verktyg;
                    systemvariabler.Version = systemvariabel.Version;
                    systemvariabler.WaitCursorImageID = systemvariabel.WaitCursorImageID;
                    systemvariabler.WriteToLog = systemvariabel.WriteToLog;
                }
                Systemvariabel = systemvariabler;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Hantera alla undantag som fångas i applikationen.
        /// Visa undantagets felmeddelande.
        /// </summary>
        /// <param name="undantag">Undantaget som fångats</param>
        protected static void HanteraUndantag(Exception undantag)
        {
            string felmeddelande;
            //Ignorera undantag om applikationen håller på att avsluta
            if (!Avslutar)
            {
                felmeddelande = "Fel";
                MessageBox.Show(undantag.Message, felmeddelande, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Hantera alla undantag som fångas i applikationen.
        /// Visa undantagets felmeddelande.
        /// </summary>
        /// <param name="undantag">Undantaget som fångats</param>
        protected static void HanteraUndantag(string undantag)
        {
            string felmeddelande;
            //Ignorera undantag om applikationen håller på att avsluta
            if (!Avslutar)
            {
                felmeddelande = "Fel";
                MessageBox.Show(undantag, felmeddelande, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Hämtar från tabellen Ordlista
        /// </summary>
        /// <param name="grupp">Aktuell grupp</param>
        /// <returns>Objektlista</returns>
        protected static List<Ordlista> HämtaOrdlista(string grupp)
        {
            string sprakkod = (AppUser is null) ? "SE" : AppUser.Sprakkod;

            Hooker.Affärslager.OrdlistaAktivitet ordlistaAktivitet = new Hooker.Affärslager.OrdlistaAktivitet();
            List<Ordlista> ordlista = ordlistaAktivitet.HämtaOrdlista(grupp, sprakkod);
            return ordlista;
        }

        /// <summary>
        /// Laddar ordlistan från inskickat objekt
        /// </summary>
        protected static void LaddaOrdlistan()
        {
            if (_ordlista.Count == 0)
            {
                List<Ordlista> ordlista = HämtaOrdlista("Text");

                if (ordlista != null)
                {
                    _ordlista.Clear();
                    for (int i = 0; i <= ordlista.Count - 1; i++)
                    {
                        _ordlista.Add(ordlista[i].Grupp + "." + ordlista[i].Text.Trim(), ordlista[i].Data);
                    }
                }
            }
        }

        /// <summary>
        /// Laddar Felmeddelande från Ordlista
        /// </summary>
        protected static void LaddaFelmeddelande()
        {
            if (_felmeddelande.Count == 0)
            {
                List<Ordlista> ordlista = HämtaOrdlista("Felmeddelande");

                if (ordlista != null)
                {
                    _felmeddelande.Clear();
                    for (int i = 0; i <= ordlista.Count - 1; i++)
                    {
                        _felmeddelande.Add(ordlista[i].Grupp + "." + ordlista[i].Text.Trim(), ordlista[i].Data);
                    }
                }
            }
        }

        /// <summary>
        /// Hämtar meddelande från tabell i databasen och visa resultatet i en Messagebox
        /// </summary>
        /// <param name="felID">Text som ska visas</param>
        protected static void VisaFelmeddelande(string felID)
        {
            VisaFelmeddelande(felID, "");
        }

        /// <summary>
        /// Hämtar meddelande från tabell i databasen och visa resultatet i en Messagebox
        /// </summary>
        /// <param name="felID">Text som ska visas</param>
        /// <param name="meddelande">Kompletterande meddelande till messageboxen</param>
        protected static void VisaFelmeddelande(string felID, string meddelande)
        {
            //Hämta felmeddelande från tabell
            string felmeddelande = "";
            felmeddelande = ÖversättFelmeddelande("Felmeddelande", felID);
            if (felmeddelande.Length > 0)
            {
                MessageBox.Show(felmeddelande.ToString() + "\n" + meddelande.ToString(), "Fel", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Felmeddelande för felID: " + felID.ToString() + " saknas", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Visar meddelande i Messagebox. Väntar på svar, ja eller nej, och returnerar svaret.
        /// </summary>
        /// <param name="msgID">ID till meddelande osm ska visas</param>
        /// <returns>Svaret, ja eller nej</returns>
        protected static string VisaFråga(string msgID)
        {
            DialogResult resultat = new DialogResult();
            string meddelande = "";
            meddelande = Översätt("Text", msgID);
            resultat = MessageBox.Show(meddelande.ToString(), "Varning", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (resultat == DialogResult.Yes)
            {
                return "Ja";
            }
            else
            {
                return "Nej";
            }
        }

        /// <summary>
        /// Visar meddelande i Messagebox. 
        /// </summary>
        /// <param name="msgID">ID till meddelande som ska visas</param>
        protected static void VisaMeddelande(string msgID)
        {
            DialogResult resultat = new DialogResult();
            string meddelande = "";
            meddelande = Översätt("Text", msgID);
            resultat = MessageBox.Show(meddelande.ToString(), "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        /// <summary>
        /// Returnerar ett ord från ordlistan
        /// 
        /// Följande typer, första delen i fältet text, ska användas:
        /// 
        ///     - Radrubrik                 = Radrubriktexter för rad
        ///     - Titel                     = Sidrubrik
        ///     - Rubrik                    = Kolumnrubrik
        ///     - Knappar                   = Knapptexter
        ///     - LinkButton                = Länktexter
        ///     - Text                      = Texter
        ///     - ToolTip                   = Tooltiptexter
        ///     - Felmeddelande             = Felmeddelande
        ///     - Information               = Information
        ///     - Varning                   = Varningsmeddelande
        /// 
        /// </summary>
        /// <param name="grupp">Typ av textgrupp</param>
        /// <param name="text">Aktuell text</param>
        /// <returns>En string med den aktuella texten</returns>
        public static string Översätt(string grupp, string text)
        {
            return Översätt(grupp + "." + text);
        }

        /// <summary>
        /// Returnerar ett text från ordlistan
        /// </summary>
        /// <param name="gruppText"></param>
        /// <returns></returns>
        public static string Översätt(string gruppText)
        {
            if (gruppText.Trim() == "")
            {
                return gruppText; //Översätt inte tomma strängar.
            }

            string ret = _ordlista.Get(gruppText);
            if (ret == null)
            {
                return "!!" + gruppText + "!!";
            }
            else
            {
                return ret;
            }
        }

        /// <summary>
        ///     returnerar AppUser
        /// </summary>
        /// <returns>AppUser</returns>
        public static Anvandare GetAppUser()
        {
            return AppUser;
        }

        /// <summary>
        /// Returnerar ett felmeddelande från ordlistan
        /// </summary>
        /// <param name="grupp">Typ av textgrupp</param>
        /// <param name="text">Aktuell text</param>
        /// <returns>En string med den aktuella texten</returns>
        protected static string ÖversättFelmeddelande(string grupp, string text)
        {
            return ÖversättFelmeddelande(grupp + "." + text);
        }

        /// <summary>
        /// Returnerar ett felmeddealnde från ordlistan
        /// </summary>
        /// <param name="gruppText">Typ av felmeddelande</param>
        /// <returns>En string med det aktuella felmeddelandet</returns>
        protected static string ÖversättFelmeddelande(string gruppText)
        {
            if (gruppText.Trim() == "")
            {
                return gruppText; //Översätt inte tomma strängar.
            }

            string ret = _felmeddelande.Get(gruppText.Trim());
            if (ret == null)
            {
                return "!!" + gruppText + "!!";
            }
            else
            {
                return ret;
            }
        }

        /// <summary>
        /// Hämta alla klasser och fyller combon.
        /// </summary>
        /// <param name="combo">Aktuell Combokontroll</param>
        /// <param name="tabell">Kodtabell som ska läsas</param>
        /// <param name="showItem">Värde som ska visas</param>
        protected void FyllComboBoxKod(ComboBox combo, Enum tabell, string showItem)
        {
            FyllComboBoxKod(combo, tabell, showItem, false);
        }

        /// <summary>
        /// Hämta alla klasser och fyller combon.
        /// </summary>
        /// <param name="combo">Aktuell Combokontroll</param>
        /// <param name="tabell">Kodtabell som ska läsas</param>
        /// <param name="showItem">Värde som ska visas</param>
        /// <param name="tomRad">Markerar om en extra rad ska adderas</param>
        protected void FyllComboBoxKod(ComboBox combo, Enum tabell, string showItem, bool tomRad)
        {
            List<Koder> koder = null;
            KoderAktivitet koderAktivitet = new KoderAktivitet();

            try
            {
                koder = koderAktivitet.SökKoder((tabell).EnumToInt(), "", "Varde");

                if (koder.Count > 0)
                {
                    combo.Items.Clear();

                    if (tomRad)
                    {
                        combo.Items.Add(new ComboBoxKod("00", "Alla", ""));
                    }
                    foreach (Koder kodrad in koder)
                    {
                        combo.Items.Add(new ComboBoxKod(kodrad.Argument, kodrad.Varde.ToString(),
                            kodrad));
                    }
                    combo.DisplayMember = "visa";

                    if (!string.IsNullOrEmpty(showItem))
                    {
                        combo.SelectedItem = showItem.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }

        ///// <summary>
        ///// Läser från konfigurationsdata
        ///// </summary>
        //protected static void GetConfig()
        //{
        //    try
        //    {   
        //        if (!_configInlast)
        //        {
        //            ArrayList configArray = new ArrayList();
        //            foreach (string key in ConfigurationManager.AppSettings)
        //            {
        //                string value = ConfigurationManager.AppSettings[key];
        //                configArray.Add(key + "&" + value);
        //            }
        //            Konfiguration.AddConfig(configArray);
        //            _configInlast = true;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        protected static void TimglasPå()
        {
            //Cursor.Current = Cursors.WaitCursor;
        }

        protected static void TimglasAv()
        {
            //Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Användaren har klickat på en länken, kör nu den i den Web Browser användaren föredrar
        /// </summary>
        /// <param name="url">Länken som ska köras</param>
        protected void StartWebbrowser(string url)
        {
            var RunningProcessPaths = ProcessFileNameFinderClass.GetAllRunningProcessFilePaths();
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                switch (AppUser.WebBrowser)
                {
                    case "C":
                        if (RunningProcessPaths.Contains("chrome.exe"))
                        {
                            startInfo.FileName = "chrome.exe";
                            startInfo.Arguments = url;
                            Process.Start(startInfo);
                        }
                        else
                        {
                            Process.Start("chrome.exe", "https://" + url);
                        }
                        break;
                    case "E":
                        Process.Start("microsoft-edge:https://" + url);
                        break;
                    case "F":
                        if (RunningProcessPaths.Contains("firefox.exe"))
                        {
                            startInfo.FileName = "firefox.exe";
                            startInfo.Arguments = url;
                            Process.Start(startInfo);
                        }
                        else
                        {
                            Process.Start("firefox.exe", "https://" + url);
                        }
                        break;
                    case "I":
                        if (RunningProcessPaths.Contains("IExplore.exe"))
                        {
                            startInfo.FileName = "IExplore.exe";
                            startInfo.Arguments = url;
                            Process.Start(startInfo);
                        }
                        else
                        {
                            Process.Start("IExplore.exe", "https://" + url);
                        }
                        break;
                    case "O":
                        if (RunningProcessPaths.Contains("opera.exe"))
                        {
                            startInfo.FileName = "opera.exe";
                            startInfo.Arguments = url;
                            Process.Start(startInfo);
                        }
                        else
                        {
                            Process.Start("opera.exe", "https://" + url);
                        }
                        break;
                    default:
                        Process.Start(url);
                        break;
                }
            }
            catch (System.ComponentModel.Win32Exception)
            {
                HanteraUndantag("Unable to find the Webb Browser... " + AppUser.WebBrowser + " not found!");
            }
        }
        //public static HashSet<string> GetAllRunningProcessFilePaths()
        //{
        //    var allProcesses = System.Diagnostics.Process.GetProcesses();
        //    HashSet<string> ProcessExeNames = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
        //    foreach (Process p in allProcesses)
        //    {
        //        string processExePath = GetProcessExecutablePath(p);
        //        ProcessExeNames.Add(System.IO.Path.GetFileName(processExePath));
        //    }
        //    return ProcessExeNames;
        //}

        ///// <summary>
        ///// Get executable path of running process
        ///// </summary>
        ///// <param name="Process"></param>
        ///// <returns></returns>
        //public static string GetProcessExecutablePath(Process Process)
        //{
        //    try
        //    {
        //        if (Environment.OSVersion.Version.Major >= 6)
        //        {
        //            return GetExecutablePathAboveXP(Process.Id);// this gets the process file name without running as administrator 
        //        }
        //        return Process.MainModule.FileName;// Vista and later this requires running as administrator.
        //    }
        //    catch
        //    {
        //        return "";
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="ProcessId"></param>
        ///// <returns></returns>
        //public static string GetExecutablePathAboveXP(int ProcessId)
        //{
        //    int MAX_PATH = 260;
        //    StringBuilder sb = new StringBuilder(MAX_PATH + 1);
        //    IntPtr hprocess = OpenProcess(ProcessAccessFlags.PROCESS_QUERY_LIMITED_INFORMATION, false, ProcessId);
        //    if (hprocess != IntPtr.Zero)
        //    {
        //        try
        //        {
        //            int size = sb.Capacity;
        //            if (QueryFullProcessImageName(hprocess, 0, sb, ref size))
        //            {
        //                return sb.ToString();
        //            }
        //        }
        //        finally
        //        {
        //            CloseHandle(hprocess);
        //        }
        //    }
        //    return "";
        //}

        /// <summary>
        /// Skapa en connection för defaultdatabasen
        /// </summary>
        /// <param name="defaultDatabas">Defaultdatabasens namn</param>
        protected static void SkapaDefaultDB(string defaultDatabas)
        {
            try
            {
                //Skapa också en instans för defaultconnection till databasen 
                //(egentligen en fuling, då vi inte ska gå direkt mot datalagret!)
                DatabasNamn = Konfiguration.GetConfigData(defaultDatabas).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FormBas_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.F1:
                    break;

                default:
                    FormsUppdaterad = true;
                    break;
            }
        }

        ///// <summary>
        ///// Kör Google Chrome
        ///// </summary>
        ///// <param name="link"></param>
        //private static void StartaChrome(string link)
        //{
        //    string url = "";

        //    if (!string.IsNullOrEmpty(link)) //if empty just run the browser
        //    {
        //        if (link.Contains(".")) //check if it's an url or a google search
        //        {
        //            url = link;
        //        }
        //        else
        //        {
        //            url = "https://www.google.com/search?q=" + link.Replace(" ", "+");
        //        }
        //    }

        //    try
        //    {
        //        Process.Start("chrome.exe", url + " --incognito");
        //    }
        //    catch (System.ComponentModel.Win32Exception e)
        //    {
        //        HanteraUndantag("Unable to find Google Chrome... chrome.exe not found!");
        //    }
        //}

        ///// <summary>
        ///// Kör Microsoft Edge
        ///// </summary>
        ///// <param name="link"></param>
        //private static void StartaEdge(string link)
        //{
        //    string url = "";

        //    if (!string.IsNullOrEmpty(link)) //if empty just run the browser
        //    {
        //        if (link.Contains(".")) //check if it's an url or a google search
        //        {
        //            url = link;
        //        }
        //        else
        //        {
        //            url = link.Replace(" ", "+");
        //        }
        //    }

        //    try
        //    {
        //        Process.Start("microsoft-edge:https://" + link);
        //    }
        //    catch (System.ComponentModel.Win32Exception e)
        //    {
        //        HanteraUndantag("Unable to find Microsoft Edge on the computer!");
        //    }
        //}
    }
}