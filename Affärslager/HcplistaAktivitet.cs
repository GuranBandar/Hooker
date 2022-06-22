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
    /// Affärslagerklass för Hcplista
    /// 
    /// Innehåller alla metoder för klassen Hcplista verksamhetslogik.
    /// </summary>
    public sealed class HcplistaAktivitet
    {
        /// <summary>
        /// Hämtar rad/-er från tabellen Hcplista i aktuell databas med angivet spelarID.
        /// </summary>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <returns>Hcplistaobjekt med efterfrågat data</returns>
        public List<Hcplista> HämtaHcplista(int spelarID)
        {
            HcplistaData hcplistaData = new HcplistaData();
            List<Hcplista> hcplista = new List<Hcplista>();
            HcplistaDS hcplistaDS = hcplistaData.HämtaHcplista(spelarID);

            if (hcplistaDS.Hcplista.Rows.Count > 0)
            {
                //Skapa Hcplistaobjektet
                hcplista = new List<Hcplista>(hcplistaDS.Hcplista.Rows.Count);
                foreach (HcplistaDS.HcplistaRow rad in hcplistaDS.Hcplista.Rows)
                {
                    hcplista.Add(new Hcplista()
                    {
                        HcplistaID = rad.HcplistaID,
                        Typ = rad.Typ,
                        SpelarID = rad.SpelarID,
                        RundaNr = rad.RundaNr,
                        Datum = rad.Datum,
                        AntalSlag = rad.AntalSlag,
                        AntalPoang = rad.AntalPoang,
                        Hcp = rad.Hcp,
                        NyttHcp = rad.NyttHcp,
                        PlusMinus = rad.PlusMinus,
                        Notering = rad.Notering,
                        UppdatDatum = rad.UppdatDatum
                    }); ;
                }
            }
            return hcplista;
        }

        /// <summary>
        /// Hämtar rad/-er från tabellen Hcplista i aktuell databas med angivet spelarID.
        /// </summary>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <param name="fromDatum">Aktuellt from datum</param>
        /// <param name="tomDatum">Aktuellt tom datum</param>
        /// <returns>Hcplistaobjekt med efterfrågat data</returns>
        public List<Hcplista> HämtaHcplista(int spelarID, DateTime fromDatum, 
            DateTime tomDatum)
        {
            HcplistaData hcplistaData = new HcplistaData();
            List<Hcplista> hcplista = new List<Hcplista>();
            HcplistaDS hcplistaDS = hcplistaData.HämtaHcplista(spelarID, fromDatum, tomDatum);

            if (hcplistaDS.Hcplista.Rows.Count > 0)
            {
                //Skapa Hcplistaobjektet
                hcplista = new List<Hcplista>(hcplistaDS.Hcplista.Rows.Count);
                foreach (HcplistaDS.HcplistaRow rad in hcplistaDS.Hcplista.Rows)
                {
                    hcplista.Add(new Hcplista()
                    {
                        HcplistaID = rad.HcplistaID,
                        Typ = rad.Typ,
                        SpelarID = rad.SpelarID,
                        RundaNr = rad.RundaNr,
                        Datum = rad.Datum,
                        AntalSlag = rad.AntalSlag,
                        AntalPoang = rad.AntalPoang,
                        Hcp = rad.Hcp,
                        NyttHcp = rad.NyttHcp,
                        PlusMinus = rad.PlusMinus,
                        Notering = rad.Notering,
                        UppdatDatum = rad.UppdatDatum
                    }); ;
                }
            }
            return hcplista;
        }
        /// <summary>
        /// Sparar alla förändringar i Hcplista i databasen 
        /// </summary>
        /// <param name="Hcplista">Aktuell Hcplista</param>
        /// <param name="nyHcplista">Ny Hcplista, true or false</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int Spara(Hcplista Hcplista, bool nyHcplista, ref string felID, ref string feltext)
        {
            int nyttHcplistaID = 0;
            HcplistaData HcplistaData = new HcplistaData();

            if (nyHcplista)
            {
                nyttHcplistaID = HcplistaData.SparaNyHcplista(Hcplista, ref felID, ref feltext);
            }
            else
            {
                HcplistaData.SparaHcplista(Hcplista, ref felID, ref feltext);
            }

            return nyttHcplistaID;
        }

        ///// <summary>
        ///// Ny Hcplista.
        ///// </summary>
        ///// <param name="spelare">Aktuell spelare</param>
        ///// <param name="typ">Typ av ändring</param>
        ///// <param name="hcp">Tidigare hcp</param>
        ///// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        ///// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        //public int Spara(Spelare spelare, string typ, decimal hcp, ref string felID, 
        //    ref string feltext)
        //{
        //    int nyttHcplistaID = 0;
        //    HcplistaData HcplistaData = new HcplistaData();
        //    nyttHcplistaID = HcplistaData.SparaNyHcplista(spelare, typ, hcp, ref felID, 
        //        ref feltext);

        //    return nyttHcplistaID;
        //}

        /// <summary>
        /// Ta bort Hcplista i databasen 
        /// </summary>
        /// <param name="Hcplista">Aktuell Hcplista</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBort(Hcplista Hcplista, ref string felID, ref string feltext)
        {
            HcplistaData HcplistaData = new HcplistaData();
            HcplistaData.TabortHcplista(Hcplista, ref felID, ref feltext);
        }

    }
}
