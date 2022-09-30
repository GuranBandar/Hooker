using Hooker.Affärsobjekt;
using Hooker.Datalager;
using Hooker.Gemensam;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hooker.Affärslager
{
    /// <summary>
    /// Affärslagerklass för TävlingDeltagare
    /// 
    /// Innehåller alla metoder för klassen TavlingDeltagares verksamhetslogik.
    /// </summary>
    public sealed class TavlingDeltagareAktivitet
    {
        /// <summary>
        /// Hämta Deltagarlistan för aktuell tävling
        /// </summary>
        /// <param name="tavlingID">Aktuellt TavlingID</param>
        /// <returns>Otypat dataset med aktuell information</returns>
        public DataSet HämtaDeltagarlista(int tavlingID)
        {
            DataSet deltagarlistaDS;
            TavlingDeltagareData tavlingDeltagareData = new TavlingDeltagareData();
            deltagarlistaDS = tavlingDeltagareData.HämtaDeltagarlista(tavlingID);
            return deltagarlistaDS;
        }

        /// <summary>
        /// Hämtar spelare för tävlingsrond.
        /// </summary>
        /// <param name="tavlingID">Aktuellt tavlingID</param>
        /// <param name="rondID">Akteullt rondID</param>
        /// <returns>Objektlista med efterfrågat data</returns>
        public List<TavlingDeltagare> HämtaDeltagareFörTavlingRond(int tavlingID, int rondID)
        {
            TavlingDeltagareData tavlingDeltagareData = new TavlingDeltagareData();
            DataSet spelareDS = tavlingDeltagareData.HämtaDeltagareFörTavlingRond(tavlingID, rondID);
            List<TavlingDeltagare> tavlingDeltagare = new List<TavlingDeltagare>(spelareDS.Tables["Deltagare"].Rows.Count);
            foreach (DataRow rad in spelareDS.Tables["Deltagare"].Rows)
            {
                tavlingDeltagare.Add(new TavlingDeltagare()
                {
                    TavlingID = (int)rad["tavlingID"],
                    SpelarID = (int)rad["SpelarID"],
                    Klass = rad["Klass"].ToString(),
                    AnmaldNr = (int)rad["AnmaldNr"],
                    Hcp = (decimal)rad["Hcp"],
                    SpelHcp = (int)rad["SpelHcp"],
                    UppdatDatum = (DateTime)rad["UppdatDatum"],
                    SpelarNamn = rad["Namn"].ToString()
                });
            }
            return tavlingDeltagare;
        }

        /// <summary>
        /// Hämtar spelare för tävling.
        /// </summary>
        /// <param name="tavlingID">Aktuellt tavlingID</param>
        /// <returns>Objektlista med efterfrågat data</returns>
        public List<TavlingDeltagare> HämtaDeltagareFörTavling(int tavlingID)
        {
            TavlingDeltagareData tavlingDeltagareData = new TavlingDeltagareData();
            DataSet spelareDS = tavlingDeltagareData.HämtaDeltagareFörTavling(tavlingID);
            List<TavlingDeltagare> tavlingDeltagare = new List<TavlingDeltagare>(spelareDS.Tables["Deltagare"].Rows.Count);
            foreach (DataRow rad in spelareDS.Tables["Deltagare"].Rows)
            {
                tavlingDeltagare.Add(new TavlingDeltagare()
                {
                    TavlingID = (int)rad["tavlingID"],
                    SpelarID = (int)rad["SpelarID"],
                    Klass = rad["Klass"].ToString(),
                    AnmaldNr = (int)rad["AnmaldNr"],
                    Hcp = (decimal)rad["Hcp"],
                    SpelHcp = (int)rad["SpelHcp"],
                    UppdatDatum = (DateTime)rad["UppdatDatum"],
                    SpelarNamn = rad["Namn"].ToString()
                });
            }
            return tavlingDeltagare;
        }

        /// <summary>
        /// Ta bort TavlingDeltagare i databasen 
        /// </summary>
        /// <param name="spelarID">Aktuell Spelare</param>
        /// <param name="tavling">Tavlingobjekt</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBort(int spelarID, Tavling tavling, ref string felID, ref string feltext)
        {
            //men ta först bort poster i TavlingRondResultat
            TavlingRondResultatAktivitet tavlingRondResultatAktivitet = new TavlingRondResultatAktivitet();
            tavlingRondResultatAktivitet.TaBort(spelarID, tavling.TavlingID, ref felID, ref feltext);
            TavlingDeltagareData tavlingDeltagareData = new TavlingDeltagareData();
            tavlingDeltagareData.TaBort(spelarID, tavling.TavlingID, ref felID, ref feltext);
        }

        /// <summary>
        /// Sparar alla förändringar i TavlingDeltagare i databasen 
        /// </summary>
        /// <param name="tavlingDeltagare">Aktuell TavlingDeltagare</param>
        /// <param name="nyTavlingDeltagare">Ny TavlingDeltagare, true or false</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void Spara(TavlingDeltagare tavlingDeltagare, bool nyTavlingDeltagare, ref string felID, ref string feltext)
        {
            bool kollaOK = Kolla(tavlingDeltagare, ref felID, ref feltext);

            if (kollaOK)
            {
                TavlingDeltagareData tavlingDeltagareData = new TavlingDeltagareData();
                if (nyTavlingDeltagare)
                {
                    tavlingDeltagareData.SparaNyTavlingDeltagare(tavlingDeltagare, ref felID, ref feltext);
                }
                else
                {
                    tavlingDeltagareData.SparaTavlingDeltagare(tavlingDeltagare, ref felID, ref feltext);
                }
            }
            else
            {
                throw new HookerException();
            }
        }

        /// <summary>
        ///     Metoden kollar informationen innan uppdatering ska göras
        /// </summary>
        /// <param name="tavlingDeltagare">TavlingDeltagare med informationen som ska kollas</param>
        /// <param name="felID">Ev felID som returneras</param>
        /// <param name="felmeddelande">Ev felmeddelande som returneras</param>
        private bool Kolla(TavlingDeltagare tavlingDeltagare, ref string felID, ref string felmeddelande)
        {
            if (string.IsNullOrEmpty(tavlingDeltagare.Klass))
            {
                felID = "TAVLINGKLASSMISSING";
                felmeddelande = "";
                return false;
            }
            if (string.IsNullOrEmpty(tavlingDeltagare.Hcp.ToString()))
            {
                felID = "HCPMISSING";
                felmeddelande = "";
                return false;
            }
            return true;
        }
    }
}
