using Hooker.Affärsobjekt;
using Hooker.Datalager;
using Hooker.Dataset;
using Hooker.Gemensam;
using System;
using System.Collections.Generic;

namespace Hooker.Affärslager
{
    /// <summary>
    /// Affärslagerklass för EclecticTillfalle
    /// 
    /// Innehåller alla metoder för klassen Eclecticss verksamhetslogik.
    /// </summary>
    public sealed class EclecticTillfalleAktivitet
    {

        /// <summary>
        /// Hämtar alla eclectictillfalleposter i tabellen EclecticTillfalle för angiven Rond
        /// </summary>
        /// <param name="rondID">Aktuell rond</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public List<EclecticTillfalle> HämtaAllaEclecticTillfalleFörRonden(int tillfalleID)
        {
            EclecticTillfalleData eclecticTillfalleData = new EclecticTillfalleData();
            EclecticTillfalleDS eclecticTillfalleDS = eclecticTillfalleData.HämtaEclecticTillfalle(tillfalleID);
            List<EclecticTillfalle> eclecticTillfalles = null;

            if (eclecticTillfalleDS.EclecticTillfalle.Rows.Count > 0)
            {
                eclecticTillfalles = new List<EclecticTillfalle>(eclecticTillfalleDS.EclecticTillfalle.Rows.Count);
                foreach (EclecticTillfalleDS.EclecticTillfalleRow rad in eclecticTillfalleDS.EclecticTillfalle.Rows)
                {
                    eclecticTillfalles.Add(new EclecticTillfalle()
                    {
                        TillfalleID = rad.TillfalleID,
                        SpelarID = rad.SpelarID,
                        RondID = rad.RondID,
                        ExaktHcp = rad.ExaktHcp,
                        ErhallnaSlag = rad.ErhallnaSlag,
                        Tee = rad.Tee,
                        TillfalleDatum = rad.TillfalleDatum,
                        TillfalleUppdatDatum = rad.TillfalleUppdatDatum
                    });
                }
            }
            return eclecticTillfalles;
        }

        /// <summary>
        /// Sparar alla förändringar i EclecticTillfalle i databasen 
        /// </summary>
        /// <param name="eclecticTillfalle">Aktuell EclecticTillfalle</param>
        /// <param name="nyEclecticTillfalle">Ny EclecticTillfalle, true or false</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int Spara(EclecticTillfalle eclecticTillfalle, bool nyEclecticTillfalle, ref string felID, ref string feltext)
        {
            int nyttTillfalleID = 0;
            bool kollaOK = Kolla(eclecticTillfalle, ref felID, ref feltext);

            if (kollaOK)
            {
                EclecticTillfalleData eclecticTillfalleData = new EclecticTillfalleData();

                if (nyEclecticTillfalle)
                {
                    eclecticTillfalleData.SparaNyEclecticTillfalle(eclecticTillfalle, ref felID, ref feltext);
                    nyttTillfalleID = Convert.ToInt32(eclecticTillfalleData.HämtaMaxEclecticTillfalle());
                    eclecticTillfalle.TillfalleID = nyttTillfalleID;
                }
                else
                {
                    eclecticTillfalleData.SparaEclecticTillfalle(eclecticTillfalle, ref felID, ref feltext);
                }
            }
            else
            {
                throw new HookerException();
            }
            return nyttTillfalleID;
        }

        /// <summary>
        ///     Metoden kollar informationen innan uppdatering ska göras
        /// </summary>
        /// <param name="eclecticRond">Tavling med informationen som ska kollas</param>
        /// <param name="felID">Ev felID som returneras</param>
        /// <param name="felmeddelande">Ev felmeddelande som returneras</param>
        private bool Kolla(EclecticTillfalle eclecticTillfalle, ref string felID, ref string felmeddelande)
        {
            if (string.IsNullOrEmpty(eclecticTillfalle.SpelarID.ToString()))
            {
                felID = "SPELARESAKNAS";
                felmeddelande = "";
                return false;
            }
            return true;
        }
    }
}
