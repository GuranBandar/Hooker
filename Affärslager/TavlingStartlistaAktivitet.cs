using System;
using System.Collections.Generic;
using System.Data;
using Hooker.Dataset;
using Hooker.Datalager;
using Hooker.Gemensam;
using Hooker.Affärsobjekt;

namespace Hooker.Affärslager
{
    /// <summary>
    /// Affärslagerklass för TävlingStartlista
    /// 
    /// Innehåller alla metoder för klassen TavlingStartlista verksamhetslogik.
    /// </summary>
    public sealed class TavlingStartlistaAktivitet
    {
        /// <summary>
        /// Hämta Startlistan för aktuell tävling
        /// </summary>
        /// <param name="tavlingID">Aktuellt TavlingID</param>
        /// <returns>Otypat dataset med aktuell information</returns>
        public DataSet HämtaStartlista(int tavlingID)
        {
            DataSet startlistaDS;
            TavlingStartlistaData tavlingStartlistaData = new TavlingStartlistaData();
            startlistaDS = tavlingStartlistaData.HämtaStartlista(tavlingID);
            return startlistaDS;
        }

        /// <summary>
        /// Skapa startlista
        /// </summary>
        /// <param name="tavling">Aktuell Tavling</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SkapaStartlista(Tavling tavling, ref string felID, ref string feltext)
        {
            int bollNr;
            int antSpelare;
            int antPerBoll;
            Spelare spelare;
            TimeSpan minuter = TimeSpan.FromMinutes(0);
            TavlingStartlista tavlingStartlista;
            SpelareAktivitet spelareaktivitet = new SpelareAktivitet();
            TavlingStartlistaData tavlingsStartlistaData = new TavlingStartlistaData();
            TavlingAktivitet tavlingAktivitet = new TavlingAktivitet();

            foreach (TavlingRond rond in tavling.TavlingRond)
            {
                bollNr = 0;
                antSpelare = 0;
                antPerBoll = 0;

                switch (tavling.TavlingDeltagare.Length)
                {
                    case 6:
                    case 7:
                    case 8:
                        antPerBoll= 4;
                        break;
                    case 9:
                        antPerBoll = 3;
                        break;
                    default:
                        antPerBoll= 4;
                        break;
                }
                foreach (TavlingDeltagare startande in tavling.TavlingDeltagare)
                {
                    if (GetRemainder(antSpelare, antPerBoll) == 0)
                    {
                        minuter = TimeSpan.FromMinutes(bollNr * 10);
                        bollNr++;
                    }
                    spelare = spelareaktivitet.HämtaSpelare(startande.SpelarID);
                    tavlingStartlista = new TavlingStartlista();
                    tavlingStartlista.RondID = rond.RondId;
                    tavlingStartlista.SpelareID = startande.SpelarID;
                    tavlingStartlista.BollNr = bollNr;
                    tavlingStartlista.Hal = 1;
                    tavlingStartlista.StartDatum = rond.Datum;
                    tavlingStartlista.Starttid = rond.ForstaStartTid.Add(minuter);
                    tavlingStartlista.Klass = startande.Klass;
                    tavlingStartlista.ExaktHcp = spelare.ExaktHcp;
                    tavlingStartlista.ErhallnaSlag = 
                        RäknaUtErhållnaSlag(spelare, rond.BanaNr);
                    tavlingStartlista.Tee = "3";
                    tavlingStartlista.UppdatDatum = DateTime.Today;
                    tavlingsStartlistaData.SparaNyTavlingStartlista(tavlingStartlista, ref felID, ref feltext);
                    antSpelare++;
                }
            }

            //Ny status på tävlingen
            tavling.TavlingStatus = "SP";
            tavlingAktivitet.Spara(tavling, false, ref felID, ref feltext);
        }

        /// <summary>
        /// Hämtar aktuell Bana
        /// </summary>
        private int RäknaUtErhållnaSlag(Spelare spelare, int rondID)
        {
            return RäknaUtErhållnaSlag(spelare.Kön, spelare.ExaktHcp, rondID);
        }

        /// <summary>
        /// Räkna ut antal erhållna slag
        /// </summary>
        /// <param name="kon">Spelarens kön</param>
        /// <param name="hcp">Spelarens hcp</param>
        /// <returns></returns>
        private int RäknaUtErhållnaSlag(string kon, decimal hcp, int banaNr)
        {
            BanaAktivitet banaAktivitet = new BanaAktivitet();
            Bana bana = banaAktivitet.HämtaBanaBanaHal(banaNr);
            int par = 0;
            int erhallnaSlag = 0;
            for (int i = 0; i < bana.BanaHal.Length; i++)
            {
                par += bana.BanaHal[i].Par;
            }
            if (kon.Equals("M"))
            {
                erhallnaSlag = Slope.RäknaUtErhållnaSlag(bana.CrHerrarGul, bana.SlopeHerrarGul,
                    par, hcp);
            }
            if (kon.Equals("K"))
            {
                erhallnaSlag = Slope.RäknaUtErhållnaSlag(bana.CrDamerRod, bana.SlopeDamerRod,
                    par, hcp);
            }
            return erhallnaSlag;
        }

        /// <summary>
        /// Uppdatera startlista
        /// </summary>
        /// <param name="tavling">Aktuell Tavling</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void UppdateraStartlista(Tavling tavling, ref string felID, ref string feltext)
        {
            TavlingStartlistaData tavlingStartlistaData = new TavlingStartlistaData();
            tavlingStartlistaData.UppdateraTavlingStartlista(tavling, ref felID, ref feltext);
        }

        /// <summary>
        /// Ta bort TavlingStartlista i databasen 
        /// </summary>
        /// <param name="rondID">Aktuellt rondID</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBort(Tavling tavling, int rondID, int spelarID, ref string felID, ref string feltext)
        {
            TavlingStartlistaData tavlingStartlistaData = new TavlingStartlistaData();
            tavlingStartlistaData.TaBortTavlingStartlista(rondID, spelarID, ref felID, ref feltext);

            //Ny status på tävlingen
            TavlingAktivitet tavlingAktivitet = new TavlingAktivitet();
            tavling.TavlingStatus = "ÖA";
            tavlingAktivitet.Spara(tavling, false, ref felID, ref feltext);
        }

        private double GetRemainder(int number, int dividend)
        {
            double remainder = Convert.ToDouble(number % dividend);
            return remainder;
        }
    }
}
