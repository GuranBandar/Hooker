using Hooker.Affärsobjekt;
using Hooker.Datalager;
using Hooker.Dataset;
using Hooker.Gemensam;
using System;

namespace Hooker.Affärslager
{
    /// <summary>
    /// Affärslagerklass för Tävling
    /// 
    /// Innehåller alla metoder för klassen Tavlingss verksamhetslogik.
    /// </summary>
    public sealed class EclecticAktivitet : SökVillkor
    {
        /// <summary>
        /// Hämtar rad från tabellen Tavling i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="tavlingID">Aktuell Tavling</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public Eclectic HämtaEclectic(int eclecticID)
        {
            EclecticData eclecticData = new EclecticData();
            EclecticDS eclecticDS = eclecticData.HämtaEclectic(eclecticID);
            Eclectic eclectic = new Eclectic
            {
                EclecticID = eclecticDS.Eclectic[0].EclecticID,
                Namn = eclecticDS.Eclectic[0].Namn,
                StartDatum = eclecticDS.Eclectic[0].StartDatum,
                Eclecticstatus = eclecticDS.Eclectic[0].EclecticStatus,
                Notering = eclecticDS.Eclectic[0].Notering
            };
            return eclectic;
        }

        /// <summary>
        /// Hämtar rad från tabellen Tavling i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="tavlingID">Aktuell Tavling</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public Eclectic HämtaEclectic(string eclecticStatus)
        {
            EclecticData eclecticData = new EclecticData();
            EclecticDS eclecticDS = eclecticData.HämtaEclectic(eclecticStatus);
            Eclectic eclectic = new Eclectic
            {
                EclecticID = eclecticDS.Eclectic[0].EclecticID,
                Namn = eclecticDS.Eclectic[0].Namn,
                StartDatum = eclecticDS.Eclectic[0].StartDatum,
                Eclecticstatus = eclecticDS.Eclectic[0].EclecticStatus,
                Notering = eclecticDS.Eclectic[0].Notering
            };
            return eclectic;
        }

        /// <summary>
        ///     Sparar alla förändringar i Eclectic i databasen 
        /// </summary>
        /// <param name="eclectic">Aktuell Eclectic</param>
        /// <param name="nyEclectic">Ny Eclectic, true or false</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int Spara(Eclectic eclectic, bool nyEclectic, ref string felID, ref string feltext)
        {
            int nyttEclecticID = 0;
            bool kollaOK = Kolla(eclectic, ref felID, ref feltext);

            if (kollaOK)
            {
                EclecticData eclecticData = new EclecticData();

                if (nyEclectic)
                {
                    eclecticData.SparaNyEclectic(eclectic, ref felID, ref feltext);
                    nyttEclecticID = Convert.ToInt32(eclecticData.HämtaMaxEclectic());
                    eclectic.EclecticID = nyttEclecticID;
                }
                else
                {
                    eclecticData.SparaEclectic(eclectic, ref felID, ref feltext);
                }
            }
            else
            {
                throw new HookerException();
            }
            return nyttEclecticID;
        }

        /// <summary>
        ///     Metoden kollar informationen innan uppdatering ska göras
        /// </summary>
        /// <param name="tavling">Tavling med informationen som ska kollas</param>
        /// <param name="felID">Ev felID som returneras</param>
        /// <param name="felmeddelande">Ev felmeddelande som returneras</param>
        private bool Kolla(Eclectic eclectic, ref string felID, ref string felmeddelande)
        {
            if (string.IsNullOrEmpty(eclectic.Namn))
            {
                felID = "TAVLINGNAMNMISSING";
                felmeddelande = "";
                return false;
            }
            return true;
        }
    }
}
