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
    public sealed class EclecticRondDeltagareAktivitet
    {

        /// <summary>
        /// Hämtar alla eclecticronddeltagarposter i tabellen EclecticDeltagare för angiven Rond
        /// </summary>
        /// <param name="rondID">Aktuell rond</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public List<EclecticRondDeltagare> HämtaAllaEclecticRondDeltagareFörRonden(int deltagarID)
        {
            EclecticRondDeltagareData eclecticRondDeltagareData = new EclecticRondDeltagareData();
            EclecticRondDeltagareDS eclecticRondDeltagareDS = eclecticRondDeltagareData.HämtaEclecticRondDeltagare(deltagarID);
            List<EclecticRondDeltagare> eclecticRondDeltagares = null;

            if (eclecticRondDeltagareDS.EclecticRondDeltagare.Rows.Count > 0)
            {
                eclecticRondDeltagares = new List<EclecticRondDeltagare>(eclecticRondDeltagareDS.EclecticRondDeltagare.Rows.Count);
                foreach (EclecticRondDeltagareDS.EclecticRondDeltagareRow rad in eclecticRondDeltagareDS.EclecticRondDeltagare.Rows)
                {
                    eclecticRondDeltagares.Add(new EclecticRondDeltagare()
                    {
                        DeltagarID = rad.DeltagarID,
                        SpelarID = rad.SpelarID,
                        RondID = rad.RondID,
                        ExaktHcp = rad.ExaktHcp,
                        ErhallnaSlag = rad.ErhallnaSlag,
                        Tee = rad.Tee,
                        DeltagarDatum = rad.DeltagarDatum,
                        DeltagarUppdatDatum = rad.DeltagarUppdatDatum
                    });
                }
            }
            return eclecticRondDeltagares;
        }

        /// <summary>
        /// Sparar alla förändringar i EclecticTillfalle i databasen 
        /// </summary>
        /// <param name="eclecticTillfalle">Aktuell EclecticTillfalle</param>
        /// <param name="nyEclecticTillfalle">Ny EclecticTillfalle, true or false</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int Spara(EclecticRondDeltagare eclecticRondDeltagare, bool nyEclecticRondDeltagare, ref string felID, ref string feltext)
        {
            int nyttDeltagarID = 0;
            bool kollaOK = Kolla(eclecticRondDeltagare, ref felID, ref feltext);

            if (kollaOK)
            {
                EclecticRondDeltagareData eclecticRondDeltagareData = new EclecticRondDeltagareData();

                if (nyEclecticRondDeltagare)
                {
                    eclecticRondDeltagareData.SparaNyEclecticRondDeltagare(eclecticRondDeltagare, ref felID, ref feltext);
                    nyttDeltagarID = Convert.ToInt32(eclecticRondDeltagareData.HämtaMaxEclecticRondDeltagare());
                    eclecticRondDeltagare.DeltagarID = nyttDeltagarID;
                }
                else
                {
                    eclecticRondDeltagareData.SparaEclecticRondDeltagare(eclecticRondDeltagare, ref felID, ref feltext);
                }
            }
            else
            {
                throw new HookerException();
            }
            return nyttDeltagarID;
        }

        /// <summary>
        ///     Metoden kollar informationen innan uppdatering ska göras
        /// </summary>
        /// <param name="eclecticRond">Tavling med informationen som ska kollas</param>
        /// <param name="felID">Ev felID som returneras</param>
        /// <param name="felmeddelande">Ev felmeddelande som returneras</param>
        private bool Kolla(EclecticRondDeltagare eclecticRondDeltagare, ref string felID, ref string felmeddelande)
        {
            if (string.IsNullOrEmpty(eclecticRondDeltagare.SpelarID.ToString()))
            {
                felID = "SPELARESAKNAS";
                felmeddelande = "";
                return false;
            }
            return true;
        }
    }
}
