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
        /// Hämtar eclecticronddeltagare i tabellen EclecticDeltagare för angiven spelare och Rond
        /// </summary>
        /// <param name="deltagarID">Aktuell spelare</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public EclecticRondDeltagare HämtaEclecticRondDeltagare(int spelarID, int rondID)
        {
            EclecticRondDeltagareData eclecticRondDeltagareData = new EclecticRondDeltagareData();
            EclecticRondDeltagareDS eclecticRondDeltagareDS =
                eclecticRondDeltagareData.HämtaEclecticRondDeltagare(spelarID, rondID);
            EclecticRondDeltagare eclecticRondDeltagare = new EclecticRondDeltagare();

            eclecticRondDeltagare.SpelarID = eclecticRondDeltagareDS.EclecticRondDeltagare[0].SpelarID;
            eclecticRondDeltagare.RondID = eclecticRondDeltagareDS.EclecticRondDeltagare[0].RondID;
            eclecticRondDeltagare.ExaktHcp = eclecticRondDeltagareDS.EclecticRondDeltagare[0].ExaktHcp;
            eclecticRondDeltagare.ErhallnaSlag = eclecticRondDeltagareDS.EclecticRondDeltagare[0].ErhallnaSlag;
            eclecticRondDeltagare.Tee = eclecticRondDeltagareDS.EclecticRondDeltagare[0].Tee;
            eclecticRondDeltagare.DeltagarDatum = eclecticRondDeltagareDS.EclecticRondDeltagare[0].DeltagarDatum;
            eclecticRondDeltagare.DeltagarUppdatDatum = eclecticRondDeltagareDS.EclecticRondDeltagare[0].DeltagarUppdatDatum;
            return eclecticRondDeltagare;
        }

        /// <summary>
        /// Hämtar alla eclecticronddeltagarposter i tabellen EclecticDeltagare för angiven Rond
        /// </summary>
        /// <param name="rondID">Aktuell rond</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public List<EclecticRondDeltagare> HämtaAllaEclecticRondDeltagareFörRonden(int rondID)
        {
            EclecticRondDeltagareData eclecticRondDeltagareData = new EclecticRondDeltagareData();
            EclecticRondDeltagareDS eclecticRondDeltagareDS = eclecticRondDeltagareData.
                HämtaAllaEclecticRondDeltagare(rondID);
            List<EclecticRondDeltagare> eclecticRondDeltagares = null;

            if (eclecticRondDeltagareDS.EclecticRondDeltagare.Rows.Count > 0)
            {
                eclecticRondDeltagares = new List<EclecticRondDeltagare>(eclecticRondDeltagareDS.EclecticRondDeltagare.Rows.Count);
                foreach (EclecticRondDeltagareDS.EclecticRondDeltagareRow rad in eclecticRondDeltagareDS.EclecticRondDeltagare.Rows)
                {
                    eclecticRondDeltagares.Add(new EclecticRondDeltagare()
                    {
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
        /// <param name="eclecticRondDeltagare">Aktuell EclecticRondDeltagare</param>
        /// <param name="nyEclecticRondDeltagare">Ny EclecticRondDeltagare, true or false</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void Spara(EclecticRondDeltagare eclecticRondDeltagare, bool nyEclecticRondDeltagare, ref string felID, ref string feltext)
        {
            EclecticRondDeltagareData eclecticRondDeltagareData = new EclecticRondDeltagareData();
            EclecticRondDeltagareDS eclecticRondDeltagareDS =
                eclecticRondDeltagareData.HämtaEclecticRondDeltagare(eclecticRondDeltagare.SpelarID,
                eclecticRondDeltagare.RondID);
            eclecticRondDeltagare.UppdatDatum = DateTime.Today.ToString();

            if (eclecticRondDeltagareDS.EclecticRondDeltagare.Count > 0)
            {
                eclecticRondDeltagare.DeltagarDatum = eclecticRondDeltagareDS.EclecticRondDeltagare[0].DeltagarDatum;
                eclecticRondDeltagareData.SparaEclecticRondDeltagare(eclecticRondDeltagare, ref felID, ref feltext);
            }
            else
            {
                eclecticRondDeltagareData.SparaNyEclecticRondDeltagare(eclecticRondDeltagare, ref felID, ref feltext);
            }
        }
    }
}
