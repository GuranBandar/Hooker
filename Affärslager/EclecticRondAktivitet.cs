using Hooker.Affärsobjekt;
using Hooker.Datalager;
using Hooker.Dataset;
using Hooker.Gemensam;
using System;
using System.Collections.Generic;

namespace Hooker.Affärslager
{
    /// <summary>
    /// Affärslagerklass för EclecticRond
    /// 
    /// Innehåller alla metoder för klassen Eclecticss verksamhetslogik.
    /// </summary>
    public sealed class EclecticRondAktivitet
    {
        /// <summary>
        /// Hämtar alla rader från tabellen EclecticRond i aktuell databas.
        /// </summary>
        /// <returns>Objekt med efterfrågat data</returns>
        public List<EclecticRond> HämtaAllaEclecticRonder(int eclecticID)
        {
            EclecticRondData eclecticRondData = new EclecticRondData();
            EclecticRondDS eclecticRondDS = eclecticRondData.HämtaEclecticRonder(eclecticID);
            List<EclecticRond> eclecticRonds = null;

            if (eclecticRondDS.EclecticRond.Rows.Count > 0)
            {
                eclecticRonds = new List<EclecticRond>(eclecticRondDS.EclecticRond.Rows.Count);
                foreach (EclecticRondDS.EclecticRondRow rad in eclecticRondDS.EclecticRond.Rows)
                {
                    eclecticRonds.Add(new EclecticRond()
                    {
                        RondID = rad.RondID,
                        EclecticID = rad.EclecticID,
                        RondNotering = rad.RondNotering,
                        RondNamn = rad.RondNamn,
                        RondDatum = rad.RondDatum,
                        Rondstatus = rad.RondStatus,
                        BanaNr = rad.BanaNr,
                        AnvandarNamnRondSkapad = rad.AnvandarNamnRondSkapad,
                        RondSkapadDatum = rad.RondSkapadDatum,
                        AnvandarNamnRondUppdat = rad.AnvandarNamnRondUppdat,
                        RondUppdatDatum = rad.RondUppdatDatum
                    });
                }
            }
            return eclecticRonds;
        }

    /// <summary>
    /// Hämtar en post i tabellen EclecticRond
    /// </summary>
    /// <param name="rondID">Aktuell rond</param>
    /// <returns>Objekt med efterfrågat data</returns>
    public EclecticRond HämtaEclecticRond(int rondID)
        {
            EclecticRondData eclecticRondData = new EclecticRondData();
            EclecticRondDS EclecticRondDS = eclecticRondData.HämtaEclecticRond(rondID);
            EclecticRond EclecticRond = new EclecticRond();
            EclecticRond.RondID = EclecticRondDS.EclecticRond[0].RondID;
            EclecticRond.EclecticID = EclecticRondDS.EclecticRond[0].EclecticID;
            EclecticRond.RondNotering = EclecticRondDS.EclecticRond[0].RondNotering;
            EclecticRond.RondNamn = EclecticRondDS.EclecticRond[0].RondNamn;
            EclecticRond.RondDatum = EclecticRondDS.EclecticRond[0].RondDatum;
            EclecticRond.Rondstatus = EclecticRondDS.EclecticRond[0].RondStatus;
            EclecticRond.BanaNr = EclecticRondDS.EclecticRond[0].BanaNr;
            EclecticRond.AnvandarNamnRondSkapad = EclecticRondDS.EclecticRond[0].AnvandarNamnRondSkapad;
            EclecticRond.RondSkapadDatum = EclecticRondDS.EclecticRond[0].RondSkapadDatum;
            EclecticRond.AnvandarNamnRondUppdat = EclecticRondDS.EclecticRond[0].AnvandarNamnRondUppdat;
            EclecticRond.RondUppdatDatum = EclecticRondDS.EclecticRond[0].RondUppdatDatum;
            return EclecticRond;
        }

        /// <summary>
        /// Hämtar alla eclecticrondposter i tabellen EclecticRond för angiven Bana
        /// </summary>
        /// <param name="eclecticID">Aktuell eclectic</param>
        /// <param name="banaNr">Aktuell bana</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public List<EclecticRond> HämtaAllaEclecticRonderFörEclecticen(int eclecticID, int banaNr)
        {
            EclecticRondData eclecticRondData= new EclecticRondData();
            EclecticRondDS eclecticRondDS = eclecticRondData.HämtaEclecticRondBana(eclecticID, banaNr);
            List<EclecticRond> eclecticRonds = null;

            if (eclecticRondDS.EclecticRond.Rows.Count > 0)
            {
                eclecticRonds = new List<EclecticRond>(eclecticRondDS.EclecticRond.Rows.Count);
                foreach (EclecticRondDS.EclecticRondRow rad in eclecticRondDS.EclecticRond.Rows)
                {
                    eclecticRonds.Add(new EclecticRond()
                    {
                        RondID = rad.RondID,
                        EclecticID = rad.EclecticID,
                        RondNotering = rad.RondNotering,
                        RondNamn = rad.RondNamn,
                        RondDatum = rad.RondDatum,
                        Rondstatus = rad.RondStatus,
                        BanaNr = rad.BanaNr,
                        AnvandarNamnRondSkapad = rad.AnvandarNamnRondSkapad,
                        RondSkapadDatum = rad.RondSkapadDatum,
                        AnvandarNamnRondUppdat = rad.AnvandarNamnRondUppdat,
                        RondUppdatDatum = rad.RondUppdatDatum
                    });
                }
            }
            return eclecticRonds;
        }

        /// <summary>
        /// Sparar alla förändringar i EclecticRond i databasen 
        /// </summary>
        /// <param name="eclecticRond">Aktuell EclecticRond</param>
        /// <param name="nyEclecticRond">Ny EclecticRond, true or false</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int Spara(Eclectic eclectic, bool nyEclecticRond, ref string felID, ref string feltext)
        {
            int nyttRondID = 0;
            bool kollaOK = true;

            if (kollaOK)
            {
                EclecticRondData eclecticRondData = new EclecticRondData();

                if (nyEclecticRond)
                {
                    eclecticRondData.SparaNyEclecticRond(eclectic, ref felID, ref feltext);
                    nyttRondID = Convert.ToInt32(eclecticRondData.HämtaMaxRondID());
                    eclectic.eclecticRonds[0].RondID = nyttRondID;
                }
                else
                {
                    eclecticRondData.SparaEclecticRond(eclectic, ref felID, ref feltext);
                }
            }
            else
            {
                throw new HookerException();
            }
            return nyttRondID;
        }

        /// <summary>
        ///     Metoden kollar informationen innan uppdatering ska göras
        /// </summary>
        /// <param name="eclecticRond">Tavling med informationen som ska kollas</param>
        /// <param name="felID">Ev felID som returneras</param>
        /// <param name="felmeddelande">Ev felmeddelande som returneras</param>
        private bool Kolla(Eclectic eclectic, ref string felID, ref string felmeddelande)
        {
            if (string.IsNullOrEmpty(eclectic.eclecticRonds[0].BanaNr.ToString()))
            {
                felID = "BANASAKNAS";
                felmeddelande = "";
                return false;
            }
            return true;
        }
    }
}
