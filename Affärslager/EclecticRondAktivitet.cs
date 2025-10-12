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
            else 
            {
                eclecticRonds = new List<EclecticRond>();
            }

            return eclecticRonds;
        }

        /// <summary>
        /// Hämtar en post i tabellen EclecticRond
        /// </summary>
        /// <param name="rondID">Aktuell rond</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public Eclectic HämtaEclecticOchEclecticRond(int eclecticID, int rondID)
        {
            EclecticData eclecticData = new EclecticData();
            EclecticDS eclecticDS = eclecticData.HämtaEclectic(eclecticID);
            Eclectic eclectic = null;

            if (eclecticDS.Eclectic.Count == 1)

            {
                eclectic = new Eclectic();
                eclectic.EclecticID = eclecticDS.Eclectic[0].EclecticID;
                eclectic.Namn = eclecticDS.Eclectic[0].Namn;
                eclectic.StartDatum = eclecticDS.Eclectic[0].StartDatum;
                eclectic.Eclecticstatus = eclecticDS.Eclectic[0].EclecticStatus;
                eclectic.Notering = eclecticDS.Eclectic[0].Notering;
                eclectic.AnvandarNamnSkapad = eclecticDS.Eclectic[0].AnvandarNamnSkapad;
                eclectic.SkapadDatum = eclecticDS.Eclectic[0].SkapadDatum;
                eclectic.AnvandarNamnUppdat = eclecticDS.Eclectic[0].AnvandarNamnUppdat;
                eclectic.UppdatDatum = eclecticDS.Eclectic[0].UppdatDatum;
            }
            
            EclecticRondData eclecticRondData = new EclecticRondData();
            EclecticRondDS eclecticRondDS = eclecticRondData.HämtaEclecticRond(rondID);
            if (eclecticRondDS.EclecticRond.Count == 1)
            {
                EclecticRond eclecticRond = new EclecticRond();
                eclecticRond.RondID = eclecticRondDS.EclecticRond[0].RondID;
                eclecticRond.EclecticID = eclecticRondDS.EclecticRond[0].EclecticID;
                eclecticRond.RondNotering = eclecticRondDS.EclecticRond[0].RondNotering;
                eclecticRond.RondNamn = eclecticRondDS.EclecticRond[0].RondNamn;
                eclecticRond.RondDatum = eclecticRondDS.EclecticRond[0].RondDatum;
                eclecticRond.Rondstatus = eclecticRondDS.EclecticRond[0].RondStatus;
                eclecticRond.BanaNr = eclecticRondDS.EclecticRond[0].BanaNr;
                eclecticRond.AnvandarNamnRondSkapad = eclecticRondDS.EclecticRond[0].AnvandarNamnRondSkapad;
                eclecticRond.RondSkapadDatum = eclecticRondDS.EclecticRond[0].RondSkapadDatum;
                eclecticRond.AnvandarNamnRondUppdat = eclecticRondDS.EclecticRond[0].AnvandarNamnRondUppdat;
                eclecticRond.RondUppdatDatum = eclecticRondDS.EclecticRond[0].RondUppdatDatum;
                eclectic.AddEclecticRond(eclecticRond);
            }
            return eclectic;
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
        public int Spara(EclecticRond eclecticRond, bool nyEclecticRond, ref string felID, ref string feltext)
        {
            int nyttRondID = 0;
            EclecticRondData eclecticRondData = new EclecticRondData();
            EclecticRondDS eclecticRondDS = eclecticRondData.HämtaEclecticRond(eclecticRond.RondID);
            eclecticRond.UppdatDatum = DateTime.Today.ToString();

            if (eclecticRondDS.EclecticRond.Count == 1)
            {
                eclecticRond.AnvandarNamnRondSkapad = eclecticRondDS.EclecticRond[0].AnvandarNamnRondSkapad;
                eclecticRond.RondSkapadDatum = eclecticRondDS.EclecticRond[0].RondSkapadDatum;
                eclecticRondData.SparaEclecticRond(eclecticRond, ref felID, ref feltext);
                nyttRondID = eclecticRond.RondID;
            }
            else
            {
                eclecticRondData.SparaNyEclecticRond(eclecticRond, ref felID, ref feltext);
                nyttRondID = int.Parse(eclecticRondData.HämtaMaxRondID());
            }

            return nyttRondID;
        }
    }
}
