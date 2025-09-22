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
    public sealed class EclecticTotalAktivitet
    {
        /// <summary>
        /// Hämtar alla eclecticTotalposter i tabellen EclecticTotal för angiven Eclectic
        /// </summary>
        /// <param name="eclecticID">Aktuell eclectic</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public List<EclecticTotal> HämtaAllaEclecticTotalFörEclecticen(int eclecticID)
        {
            EclecticTotalData eclecticTotalData = new EclecticTotalData();
            EclecticTotalDS eclecticTotalDS = eclecticTotalData.HämtaEclecticTotal(eclecticID);
            List<EclecticTotal> eclecticTotals = null;

            if (eclecticTotalDS.EclecticTotal.Rows.Count > 0)
            {
                eclecticTotals = new List<EclecticTotal>(eclecticTotalDS.EclecticTotal.Rows.Count);
                foreach (EclecticTotalDS.EclecticTotalRow rad in eclecticTotalDS.EclecticTotal.Rows)
                {
                    eclecticTotals.Add(new EclecticTotal()
                    {
                        TotalID = rad.TotalID,
                        SpelarID = rad.SpelarID,
                        EclecticID = rad.EclecticID,
                        ExaktHcp = rad.ExaktHcp,
                        ErhallnaSlag = rad.ErhallnaSlag,
                        Tee = rad.Tee,
                        BanaNr = rad.BanaNr,
                        TotalUppdatDatum = rad.TotalUppdatDatum
                    });
                }
            }
            return eclecticTotals;
        }

        /// <summary>
        /// Hämtar alla eclecticTotalposter i tabellen EclecticTotal för angiven Eclectic
        /// </summary>
        /// <param name="eclecticID">Aktuell eclectic</param>
        /// <param name="spelarID">Aktuell spelare</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public List<EclecticTotal> HämtaAllaEclecticTotalFörEclecticen(int eclecticID, int spelarID)
        {
            EclecticTotalData eclecticTotalData = new EclecticTotalData();
            EclecticTotalDS eclecticTotalDS = eclecticTotalData.HämtaEclecticTotal(eclecticID, spelarID);
            List<EclecticTotal> eclecticTotals = null;

            if (eclecticTotalDS.EclecticTotal.Rows.Count > 0)
            {
                eclecticTotals = new List<EclecticTotal>(eclecticTotalDS.EclecticTotal.Rows.Count);
                foreach (EclecticTotalDS.EclecticTotalRow rad in eclecticTotalDS.EclecticTotal.Rows)
                {
                    eclecticTotals.Add(new EclecticTotal()
                    {
                        TotalID = rad.TotalID,
                        SpelarID = rad.SpelarID,
                        EclecticID = rad.EclecticID,
                        ExaktHcp = rad.ExaktHcp,
                        ErhallnaSlag = rad.ErhallnaSlag,
                        Tee = rad.Tee,
                        BanaNr = rad.BanaNr,
                        TotalUppdatDatum = rad.TotalUppdatDatum
                    });
                }
            }
            return eclecticTotals;
        }

        /// <summary>
        /// Hämtar eclecticTotalpost i tabellen EclecticTotal för spelaren, banan och tee
        /// </summary>
        /// <param name="eclecticID">Aktuell eclectic</param>
        /// <param name="spelarID">Aktuell spelare</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public EclecticTotal HämtaEclecticTotalFörSpelareBanaOchTee(int spelarID, int banaNr, string tee)
        {
            EclecticTotalData eclecticTotalData = new EclecticTotalData();
            EclecticTotalDS eclecticTotalDS = eclecticTotalData.HämtaEclecticTotalFörSpelareBanaOchTee(spelarID, banaNr, tee);
            EclecticTotal eclecticTotal = null;

            if (eclecticTotalDS.EclecticTotal.Count == 1)
            {
                foreach (EclecticTotalDS.EclecticTotalRow rad in eclecticTotalDS.EclecticTotal.Rows)
                {
                    eclecticTotal = new EclecticTotal()
                    {
                        TotalID = rad.TotalID,
                        SpelarID = rad.SpelarID,
                        EclecticID = rad.EclecticID,
                        ExaktHcp = rad.ExaktHcp,
                        ErhallnaSlag = rad.ErhallnaSlag,
                        Tee = rad.Tee,
                        BanaNr = rad.BanaNr,
                        TotalUppdatDatum = rad.TotalUppdatDatum
                    };
                }
            }
            return eclecticTotal;
        }

        /// <summary>
        /// Sparar alla förändringar i EclecticTotal i databasen 
        /// </summary>
        /// <param name="eclecticTotal">Aktuell EclecticTotal</param>
        /// <param name="nyEclecticTotal">Ny EclecticTotal, true or false</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int Spara(EclecticTotal eclecticTotal, bool nyEclecticTotal, ref string felID, ref string feltext)
        {
            int nyttTotalID = 0;
            bool kollaOK = Kolla(eclecticTotal, ref felID, ref feltext);

            if (kollaOK)
            {
                EclecticTotalData eclecticTotalData = new EclecticTotalData();

                if (nyEclecticTotal)
                {
                    eclecticTotalData.SparaNyEclecticTotal(eclecticTotal, ref felID, ref feltext);
                    nyttTotalID = Convert.ToInt32(eclecticTotalData.HämtaMaxEclecticTotal());
                    eclecticTotal.TotalID = nyttTotalID;
                }
                else
                {
                    eclecticTotalData.SparaEclecticTotal(eclecticTotal, ref felID, ref feltext);
                }
            }
            else
            {
                throw new HookerException();
            }
            return nyttTotalID;
        }

        /// <summary>
        ///     Metoden kollar informationen innan uppdatering ska göras
        /// </summary>
        /// <param name="eclecticRond">Tavling med informationen som ska kollas</param>
        /// <param name="felID">Ev felID som returneras</param>
        /// <param name="felmeddelande">Ev felmeddelande som returneras</param>
        private bool Kolla(EclecticTotal eclecticTotal, ref string felID, ref string felmeddelande)
        {
            if (string.IsNullOrEmpty(eclecticTotal.SpelarID.ToString()))
            {
                felID = "SPELARESAKNAS";
                felmeddelande = "";
                return false;
            }
            return true;
        }
    }
}
