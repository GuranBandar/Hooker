using Hooker.Affärsobjekt;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hooker_GUI.Kontroller
{
    /// <summary>
    ///     Klass för hantering av fönsteranrop
    /// </summary>
    public partial class Fönsterhanterare : KontrollBas
    {
        private BanaInfo bana1;
        private KoderInfo koder1;
        private RedovisningInfo redovisning;
        private RundaInfo runda1;
        private RundaNotering rundaNotering;
        private SpelareInfo spelare1;
        private Rondgraf rondgraf1;
        private AndelPuttGraf andelgraf1;
        private KlassInfo klassInfo;
        private TävlingInfo tavlingInfo;
        private Deltagarlista deltagarlista;
        private Startlista startlista;
        private Resultatlista resultatlista;
        private Rondresultat rondResultat;
        private Nassau nassau;
        private TrofeInfo trofen;
        private FormkurvaGraf formkurvaGraf1;
        private RondResultatSpelare rondResultatSpelare;
        private GolfklubbInfo golfklubb;
        private R2A r2a;
        private AllaBett allaBett;
        private AnvandareInfo anvandareInfo;
        private HcplistaGraf HcplistaGraf;

        /// <summary>
        ///     Konstruktor
        /// </summary>
        public Fönsterhanterare()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Hanterar Visa Användare
        /// </summary>
        /// <param name="AnvandarID">Sökt BanaNr</param>
        public void HanteraVisaAnvandare(string anvandarID)
        {
            anvandareInfo = new Hooker_GUI.AnvandareInfo();
            anvandareInfo.AnvandarID = int.Parse(anvandarID);
            anvandareInfo.VisaAnvandare();
            anvandareInfo.Show();
        }

        /// <summary>
        ///     Hanterar Visa Bana
        /// </summary>
        /// <param name="banaNr">Sökt BanaNr</param>
        public void HanteraVisaBana(string banaNr)
        {
            bana1 = new Hooker_GUI.BanaInfo();
            bana1.BanaNr = int.Parse(banaNr);
            bana1.VisaBana();
            bana1.Show();
        }

        /// <summary>
        /// Hanterar Ny Bana med Golfklubbsnummer
        /// </summary>
        public void HanteraNyBana(string golfklubbNr)
        {
            bana1 = new BanaInfo(golfklubbNr);
            bana1.NyBana = true;
            bana1.InitieraNyBana();
            bana1.Show();
        }

        /// <summary>
        /// Hanterar Ny Bana
        /// </summary>
        public void HanteraNyBana()
        {
            bana1 = new BanaInfo();
            bana1.NyBana = true;
            bana1.InitieraNyBana();
            bana1.Show();
        }

        /// <summary>
        /// Hanterar Visa Golfklubb
        /// </summary>
        /// <param name="golfklubbNr">Sökt golfklubb</param>
        public void HanteraVisaGolfklubb(string golfklubbNr)
        {
            golfklubb = new Hooker_GUI.GolfklubbInfo();
            golfklubb.GolfklubbNr = int.Parse(golfklubbNr);
            golfklubb.VisaGolfklubb();
            golfklubb.Show();
        }

        /// <summary>
        /// Hanterar Ny Golfklubb
        /// </summary>
        public void HanteraNyGolfklubb()
        {
            golfklubb = new Hooker_GUI.GolfklubbInfo();
            golfklubb.NyGolfklubb = true;
            golfklubb.InitieraNyGolfklubb();
            golfklubb.Show();
        }

        /// <summary>
        /// Hanterar Visa Redovisning
        /// </summary>
        /// <param name="transNr">Sökt transNr</param>
        public void HanteraVisaRedovisning(string transNr)
        {
            redovisning = new RedovisningInfo();
            redovisning.TransNr = int.Parse(transNr);
            redovisning.VisaRedovisning();
            redovisning.Show();
        }

        /// <summary>
        /// Hanterar Ny Redovisning
        /// </summary>
        public void HanteraNyRedovisning()
        {
            redovisning = new RedovisningInfo();
            redovisning.NyRedovisning = true;
            redovisning.InitieraNyRedovisning();
            redovisning.Show();
        }

        /// <summary>
        ///     Hanterar Visa Runda
        /// </summary>
        /// <param name="rundaNr">Sökt rundaNr</param>
        public void HanteraVisaRunda(string rundaNr)
        {
            runda1 = new Hooker_GUI.RundaInfo();
            runda1.RundaNr = int.Parse(rundaNr);
            runda1.VisaRunda();
            runda1.Show();
        }

        /// <summary>
        /// Hanterar Visa Runda
        /// </summary>
        /// <param name="rundaNr">Sökt rundaNr</param>
        public void HanteraVisaRunda(string rundaNr, string golfklubbNr)
        {
            runda1 = new Hooker_GUI.RundaInfo();
            runda1.RundaNr = int.Parse(rundaNr);
            runda1.GolfklubbNr = int.Parse(golfklubbNr);
            runda1.VisaRunda();
            runda1.Show();
        }

        /// <summary>
        /// Hanterar Ny Runda
        /// </summary>
        public void HanteraNyRunda()
        {
            runda1 = new Hooker_GUI.RundaInfo();
            runda1.NyRunda = true;
            runda1.InitieraNyRunda();
            runda1.Show();
        }

        /// <summary>
        /// Hanterar Visa RundaNotering
        /// </summary>
        /// <param name="rundaNr">Sökt rundaNr</param>
        public void HanteraVisaRundaNotering(string rundaNr)
        {
            rundaNotering = new Hooker_GUI.Kontroller.RundaNotering();
            rundaNotering.RundaNr = int.Parse(rundaNr);
            rundaNotering.VisaRundaNotering();
            rundaNotering.Show();
        }

        /// <summary>
        ///     Hanterar Visa Spelare
        /// </summary>
        /// <param name="spelarID">Sökt spelare</param>
        public void HanteraVisaSpelare(string spelarID)
        {
            spelare1 = new Hooker_GUI.SpelareInfo();
            spelare1.SpelarID = int.Parse(spelarID);
            spelare1.VisaSpelare();
            spelare1.Show();
        }

        /// <summary>
        ///     Hanterar Ny Spelare
        /// </summary>
        public void HanteraNySpelare()
        {
            spelare1 = new Hooker_GUI.SpelareInfo();
            spelare1.NySpelare = true;
            spelare1.InitieraNySpelare();
            spelare1.Show();
        }

        /// <summary>
        ///     Hanterar Visa Koder
        /// </summary>
        /// <param name="typ">Del av nyckel</param>
        /// <param name="argument">Resten av nyckeln</param>
        public void HanteraVisaKoder(int typ, string argument)
        {
            koder1 = new Hooker_GUI.KoderInfo();
            koder1.Typ = typ;
            koder1.Argument = argument.Trim();
            koder1.VisaKoder();
            koder1.Show();
        }

        /// <summary>
        ///     Hanterar Ny Kod
        /// </summary>
        /// <param name="typ">Aktuell typ</param>
        public void HanteraNyKod(int typ)
        {
            koder1 = new Hooker_GUI.KoderInfo();
            koder1.NyKodArgument = true;
            koder1.Typ = typ;
            koder1.InitieraNykod();
            koder1.Show();
        }

        /// <summary>
        /// Hanterar Visa Tävling
        /// </summary>
        /// <param name="tavlingID">Sökt tävling</param>
        public void HanteraVisaTavling(string tavlingID)
        {
            tavlingInfo = new Hooker_GUI.TävlingInfo();
            tavlingInfo.TavlingID = int.Parse(tavlingID);
            tavlingInfo.Show();
            tavlingInfo.VisaTavling();
        }

        /// <summary>
        /// Hanterar Ny Tävling
        /// </summary>
        public void HanteraNyTavling()
        {
            tavlingInfo = new Hooker_GUI.TävlingInfo();
            tavlingInfo.NyTavling = true;
            tavlingInfo.InitieraNyTavling();
            tavlingInfo.Show();
        }

        /// <summary>
        /// Hanterar Ny TavlingKlass
        /// </summary>
        public void HanteraNyTavlingKlass(Tavling tavling)
        {
            klassInfo = new Hooker_GUI.KlassInfo();
            klassInfo.NyTavlingKlass = true;
            klassInfo.Tavling = tavling;
            klassInfo.InitieraNyTavlingKlass();
            klassInfo.ShowDialog();
            klassInfo.Dispose();
        }

        /// <summary>
        /// Hanterar visa TavlingKlass
        /// </summary>
        /// <param name="tavlingID">Aktuellt tävlingsid</param>
        /// <param name="klass">Aktuell klass</param>
        public void HanteraVisaTavlingKlass(Tavling tavling, string klass)
        {
            klassInfo = new KlassInfo();
            klassInfo.Tavling = tavling;
            klassInfo.Klass = klass;
            klassInfo.VisaTavlingKlass();
            klassInfo.ShowDialog();
            klassInfo.Dispose();
        }

        /// <summary>
        /// Hanterar visa Formkurvagraf
        /// </summary>
        /// <param name="runda">Dataset med rondinformation</param>
        public void HanteraVisaFormkurva(DataSet rondanalys)
        {
            formkurvaGraf1 = new FormkurvaGraf();
            formkurvaGraf1.Rondanalys = rondanalys;
            formkurvaGraf1.VisaFormkurva();
            formkurvaGraf1.ShowDialog();
            formkurvaGraf1.Dispose();
        }

        /// <summary>
        ///     Hanterar visa Rondgraf
        /// </summary>
        /// <param name="runda">Sammansatt objekt med rundainformation</param>
        public void HanteraVisaRondgraf(Runda runda)
        {
            rondgraf1 = new Rondgraf();
            rondgraf1.VisaGraf(runda);
            rondgraf1.ShowDialog();
            rondgraf1.Dispose();
        }

        /// <summary>
        ///     Hanterar visa Rondgraf
        /// </summary>
        /// <param name="rundaNr">Rundans nr</param>
        public void HanteraVisaRondgraf(string rundaNr)
        {
            rondgraf1 = new Rondgraf();
            rondgraf1.VisaGraf(int.Parse(rundaNr));
            rondgraf1.ShowDialog();
            rondgraf1.Dispose();
        }

        /// <summary>
        ///     Hanterar visa Andelgraf
        /// </summary>
        /// <param name="andelDS">Dataset med aktuella värden</param>
        public void HanteraVisaAndelgraf(DataSet andelDS)
        {
            andelgraf1 = new AndelPuttGraf();
            andelgraf1.VisaAndelgraf(andelDS);
            andelgraf1.ShowDialog();
            andelgraf1.Dispose();
        }

        /// <summary>
        /// Hanterar visa Deltagarlista
        /// </summary>
        /// <param name="tavling">Aktuellt tävling</param>
        public void HanteraVisaDeltagarlista(Tavling tavling)
        {
            deltagarlista = new Deltagarlista();
            deltagarlista.Tavling = tavling;
            deltagarlista.VisaDeltagarlista();
            deltagarlista.ShowDialog();
            deltagarlista.Dispose();
        }

        /// <summary>
        /// Hanterar visa Startlista
        /// </summary>
        /// <param name="tavling">Aktuellt tavlingsobjekt</param>
        public void HanteraVisaStartlista(Tavling tavling)
        {
            startlista = new Startlista();
            startlista.Tavling = tavling;
            startlista.VisaStartlista();
            startlista.ShowDialog();
            startlista.Dispose();
        }

        /// <summary>
        /// Hanterar visa Resultatlista
        /// </summary>
        /// <param name="tavling">Aktuellt tavlingsobjekt</param>
        public void HanteraVisaResultatlista(Tavling tavling)
        {
            resultatlista = new Resultatlista();
            resultatlista.Tavling = tavling;
            resultatlista.VisaResultatlista();
            resultatlista.ShowDialog();
            resultatlista.Dispose();
        }

        /// <summary>
        /// Hanterar visa RondResultat
        /// </summary>
        /// <param name="tavlingID">Aktuellt tavlingsID</param>
        public void HanteraVisaRondResultat(string tavlingID, DateTime fromDatum, DateTime tomDatum)
        {
            rondResultat = new Rondresultat(int.Parse(tavlingID), fromDatum, tomDatum);
            rondResultat.TavlingID = int.Parse(tavlingID);
            rondResultat.VisaRondResultat();

            if (rondResultat.TavlingStartad)
            {
                rondResultat.Show();
            }
        }

        /// <summary>
        /// Hanterar visa RondResultat
        /// </summary>
        /// <param name="tavlingID">Aktuellt tavlingsID</param>
        /// <param name="klass">Aktuell klass</param>
        /// <param name="rondID">Aktuellt rondID</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        public void HanteraVisaRondResultat(int tavlingID, string klass, int rondID, int spelarID)
        {
            rondResultat = new Rondresultat();
            rondResultat.TavlingID = tavlingID;
            rondResultat.Klass = klass;
            rondResultat.RondID = rondID;
            rondResultat.SpelarID = spelarID;
            rondResultat.VisaRondResultat();
            rondResultat.Show();
        }

        /// <summary>
        /// Hanterar visa Nassau
        /// </summary>
        /// <param name="tavling">Aktuellt tavlingsobjekt</param>
        public void HanteraVisaNassau(Tavling tavling)
        {
            nassau = new Nassau();
            nassau.Tavling = tavling;
            nassau.VisaNassau();
            nassau.ShowDialog();
            nassau.Dispose();
        }

        /// <summary>
        /// Hanterar visa Trofén
        /// </summary>
        /// <param name="tavling">Aktuellt tavlingsobjekt</param>
        public void HanteraVisaTrofen(Tavling tavling)
        {
            trofen = new TrofeInfo();
            trofen.Tavling = tavling;
            trofen.VisaTrofen();
            trofen.ShowDialog();
            trofen.Dispose();
        }

        /// <summary>
        /// Hanterar visa Race to Algarve
        /// </summary>
        /// <param name="tavling">Aktuellt tavlingsobjekt</param>
        public void HanteraVisaR2A(Tavling tavling)
        {
            r2a = new R2A();
            r2a.Tavling = tavling;
            r2a.VisaR2A();
            r2a.ShowDialog();
            r2a.Dispose();
        }

        /// <summary>
        /// Hanterar visa alla bett
        /// </summary>
        /// <param name="tavling">Aktuellt tavlingsobjekt</param>
        public void HanteraVisaAllaBett(Tavling tavling)
        {
            allaBett = new AllaBett();
            allaBett.Tavling = tavling;
            allaBett.VisaAllaBett();
            allaBett.ShowDialog();
            allaBett.Dispose();
        }

        /// <summary>
        /// Hantera visa Rondresultat för spelare
        /// </summary>
        /// <param name="tavling">Aktuellt tavlingsobjekt</param>
        /// <param name="rondID">Aktuellt rondID</param>
        /// <param name="spelareID">Aktuellt spelareID</param>
        public void HanteraVisaRondResultatSpelare(Tavling tavling, int spelareID, int rondNR)
        {
            rondResultatSpelare = new RondResultatSpelare();
            rondResultatSpelare.Tavling = tavling;
            rondResultatSpelare.SpelareID = spelareID;
            rondResultatSpelare.RondNr = rondNR;
            rondResultatSpelare.VisaRondResultatSpelare();
            rondResultatSpelare.ShowDialog();
            rondResultatSpelare.Dispose();
        }

        /// <summary>
        /// Hanterar Ny Användare
        /// </summary>
        public void HanteraNyAnvandare()
        {
            anvandareInfo = new AnvandareInfo();
            anvandareInfo.NyAnvandare = true;
            anvandareInfo.InitieraNyAnvandare();
            anvandareInfo.Show();
        }

        public void HanteraVisaHcplistaGraf(Spelare spelare, List<Hcplista> hcplista)
        {
            HcplistaGraf = new HcplistaGraf();
            HcplistaGraf.Spelare = spelare;
            HcplistaGraf.Hcplista = hcplista;
            HcplistaGraf.VisaHcplistaGraf();
            HcplistaGraf.ShowDialog();
            HcplistaGraf.Dispose();
        }
    }
}
