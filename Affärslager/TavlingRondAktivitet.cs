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
    /// Affärslagerklass för TävlingRond
    /// 
    /// Innehåller alla metoder för klassen TavlingRonds verksamhetslogik.
    /// </summary>
    public sealed class TavlingRondAktivitet
    {
        /// <summary>
        /// Hämtar en post i tabellen TavlingRond
        /// </summary>
        /// <param name="rondID">Aktuell rond</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public TavlingRond HämtaTavlingRond(int rondID)
        {
            TavlingRondData tavlingRondData = new TavlingRondData();
            TavlingRondDS tavlingRondDS = tavlingRondData.HämtaTavlingRond(rondID);
            TavlingRond tavlingRond = new TavlingRond();
            tavlingRond.RondId = tavlingRondDS.TavlingRond[0].RondID;
            tavlingRond.TavlingID = tavlingRondDS.TavlingRond[0].TavlingID;
            tavlingRond.Klass = tavlingRondDS.TavlingRond[0].Klass;
            tavlingRond.RondNr = tavlingRondDS.TavlingRond[0].RondNr;
            tavlingRond.ForstaStartTid = tavlingRondDS.TavlingRond[0].ForstaStartTid;
            tavlingRond.AntalHal = tavlingRondDS.TavlingRond[0].AntalHal;
            tavlingRond.Cut = tavlingRondDS.TavlingRond[0].Cut;
            tavlingRond.UppdatDatum = tavlingRondDS.TavlingRond[0].UppdatDatum;
            tavlingRond.SpelarIDNearest = tavlingRondDS.TavlingRond[0].SpelarIDNearest;
            tavlingRond.SpelarIDLongest = tavlingRondDS.TavlingRond[0].SpelarIDLongest;
            tavlingRond.RondStatus = tavlingRondDS.TavlingRond[0].RondStatus;
            tavlingRond.BanaNr = tavlingRondDS.TavlingRond[0].BanaNr;
            return tavlingRond;
        }

        /// <summary>
        /// Hämtar alla tavlingsrondposter i tabellen TavlingRond för angiven tavling och klass
        /// </summary>
        /// <param name="tavlingID">Aktuell tavling</param>
        /// <param name="klass">Aktuell klass</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public List<TavlingRond> HämtaAllaTavlingRonderFörTävlingOchKlass(int tavlingID, string klass)
        {
            TavlingRondData tavlingRondData = new TavlingRondData();
            TavlingRondDS tavlingRondDS = tavlingRondData.HämtaAllaTavlingRonderFörTävlingOchKlass(tavlingID, klass);
            List<TavlingRond> tavlingRond = null;

            if (tavlingRondDS.TavlingRond.Rows.Count > 0)
            {
                tavlingRond = new List<TavlingRond>(tavlingRondDS.TavlingRond.Rows.Count);
                foreach (TavlingRondDS.TavlingRondRow rad in tavlingRondDS.TavlingRond.Rows)
                {
                    tavlingRond.Add(new TavlingRond()
                    {
                        RondId = rad.RondID,
                        TavlingID = rad.TavlingID,
                        Klass = rad.Klass,
                        RondNr = rad.RondNr,
                        ForstaStartTid = rad.ForstaStartTid,
                        AntalHal = rad.AntalHal,
                        Cut = rad.Cut,
                        UppdatDatum = rad.UppdatDatum,
                        BanaNr = rad.BanaNr
                    });
                }
            }
            return tavlingRond;
        }

        /// <summary>
        /// Sparar alla nya TavlingRond rader i databasen 
        /// </summary>
        /// <param name="tavlingKlass">Aktuell TavlingKlass</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void Spara(Tavling tavling, ref string felID, ref string feltext)
        {
            //Börja med att ta bort alla gamla
            this.TaBort(tavling, ref felID, ref feltext);
            TavlingRondData tavlingRondData = new TavlingRondData();

            //Lägg upp lika många TavlingsRonder som antalet ronder i TavlingKlass
            foreach (TavlingRond rond in tavling.TavlingRond)
            {
                rond.UppdatDatum = DateTime.Today;
                tavlingRondData.SparaNyTavlingRond(rond, ref felID, ref feltext);
            }
        }

        /// <summary>
        /// Sparar aktuell TavlingRond i databasen 
        /// </summary>
        /// <param name="tavlingRond">Aktuell TavlingRond</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void Spara(TavlingRond tavlingRond, ref string felID, ref string feltext)
        {
            TavlingRondData tavlingRondData = new TavlingRondData();
            TavlingRondDS tavlingRondDS = tavlingRondData.HämtaTavlingRondFörTävlingOchRondNr(tavlingRond.TavlingID, tavlingRond.RondNr);
            tavlingRond.UppdatDatum = DateTime.Today;

            if (tavlingRondDS.TavlingRond.Count == 1)
            {
                tavlingRondData.Spara(tavlingRond, ref felID, ref feltext);
            }
            else
            {
                tavlingRondData.SparaNyTavlingRond(tavlingRond, ref felID, ref feltext);
            }
        }

        /// <summary>
        /// Ta bort TavlingRond i databasen 
        /// </summary>
        /// <param name="tavlingRond">Aktuell TavlingRond</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBort(TavlingRond tavlingRond, ref string felID, ref string feltext)
        {
            TavlingRondData tavlingRondData = new TavlingRondData();
            tavlingRondData.TaBortTavlingRond(tavlingRond, ref felID, ref feltext);
        }

        /// <summary>
        /// Ta bort TavlingRond i databasen 
        /// </summary>
        /// <param name="tavlingRond">Aktuell TavlingRond</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        private void TaBort(Tavling tavling, ref string felID, ref string feltext)
        {
            TavlingRondData tavlingRondData = new TavlingRondData();
            tavlingRondData.TaBortTavlingRonder(tavling, ref felID, ref feltext);
        }
    }
}
