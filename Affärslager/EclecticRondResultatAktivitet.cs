using Hooker.Affärsobjekt;
using Hooker.Datalager;
using Hooker.Dataset;
using System.Collections.Generic;

namespace Hooker.Affärslager
{
    /// <summary>
    /// Affärslagerklass för EclecticRondResultat
    /// 
    /// Innehåller alla metoder för klassen EclecticRondResultats verksamhetslogik.
    /// </summary>
    public sealed class EclecticRondResultatAktivitet
    {
        /// <summary>
        /// Hämtar en post i tabellen EclecticRondResultat
        /// </summary>
        /// <param name="deltagarID">Aktuell RondDeltagare</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public List<EclecticRondResultat> HämtaEclecticRondResultat(int deltagarID, int spelarID)
        {
            EclecticRondResultatData eclecticRondResultatData = new EclecticRondResultatData();
            EclecticRondResultatDS eclecticRondResultatDS = eclecticRondResultatData.HämtaEclecticRondResultat(deltagarID, spelarID);
            List<EclecticRondResultat> eclecticRondResultats = null;

            if (eclecticRondResultatDS.EclecticRondResultat.Rows.Count > 0)
            {
                eclecticRondResultats = new List<EclecticRondResultat>(eclecticRondResultatDS.EclecticRondResultat.Rows.Count);
                foreach (EclecticRondResultatDS.EclecticRondResultatRow rad in eclecticRondResultatDS.EclecticRondResultat.Rows)
                {
                    eclecticRondResultats.Add(new EclecticRondResultat()
                    {
                        DeltagarID = rad.DeltagarID,
                        SpelarID = rad.SpelarID,
                        HalNr = rad.HalNr,
                        AntalSlag = rad.AntalSlag,
                        AntalPoang = rad.AntalPoang,
                        RondDatum = rad.RondDatum
                    });
                }
            }
            return eclecticRondResultats;
        }

        /// <summary>
        /// Spara i tabellen EclecticRondResultat för en spelare och ett tillfälle
        /// </summary>
        /// <param name="EclecticRondResultat">Aktuellt objekt</param>
        /// <param name="tillfalleID">Aktuellt tillfalleID</param>
        /// <param name="spelarID">Aktuellt SpelarID</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void Spara(EclecticRondDeltagare eclecticRondDeltagare, int deltagarID, int spelarID, ref string felID, ref string feltext)
        {
            EclecticRondResultatData eclecticRondResultatData = new EclecticRondResultatData();
            EclecticRondResultatDS eclecticRondResultatDS;

            foreach (EclecticRondResultat eclecticRondResultat in eclecticRondDeltagare.eclecticRondResultats)
            {
                eclecticRondResultatDS = eclecticRondResultatData.HämtaEclecticRondResultat(eclecticRondResultat.DeltagarID,
                    eclecticRondResultat.SpelarID);

                if (eclecticRondResultatDS.EclecticRondResultat.Count > 0)
                {
                    eclecticRondResultatData.SparaEclecticRondResultat(eclecticRondResultat, ref felID, ref feltext);
                }
                else
                {
                    eclecticRondResultatData.SparaNyEclecticRondResultat(eclecticRondResultat, ref felID, ref feltext);
                }
            }
        }
    }
}
