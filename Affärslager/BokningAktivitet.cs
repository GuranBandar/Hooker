using Hooker.Datalager;
using Hooker.Dataset;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using System.Collections.Generic;
using System.Data;
using System;

namespace Hooker.Affärslager
{
    /// <summary>
    /// Klass för Bokning
    /// 
    /// Innehåller alla metoder för klassen BokningDags verksamhetslogik.
    /// </summary>
    public sealed class BokningAktivitet : SökVillkor
    {
        /// <summary>
        /// Hämtar rad från tabellen BokningDag i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="BokningID">Aktuell bokning</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public BokningDag HämtaBokning(int BokningID)
        {
            BokningData bokningData = new BokningData();
            BokningsListaDS bokningsListaDS = new BokningsListaDS();
            BokningDagDS bokningDagDS = bokningData.HämtaBokningDag(BokningID);
            BokningDag bokningDag = null;
            BokningsLista bokningsLista = null;

            if (bokningDagDS.BokningDag.Count == 1)
            {
                //Skapa BokningDagObjektet
                bokningDag = new BokningDag();
                bokningDag.BokningID = bokningDagDS.BokningDag[0].BokningID;
                bokningDag.Bana = bokningDagDS.BokningDag[0].Bana;
                bokningDag.Datum = bokningDagDS.BokningDag[0].Datum;
                bokningDag.Tider = bokningDagDS.BokningDag[0].Tider;
                bokningDag.TisdagTorsdag = Convert.ToInt32(bokningDagDS.BokningDag[0].TisdagTorsdag);
                bokningDag.AnvandarNamnSkapad = bokningDagDS.BokningDag[0].AnvandarNamnSkapad;
                bokningDag.SkapadDatum = bokningDagDS.BokningDag[0].SkapadDatum;
                bokningDag.AnvandarNamnUppdat = bokningDagDS.BokningDag[0].AnvandarNamnUppdat;
                bokningDag.UppdatDatum = bokningDagDS.BokningDag[0].UppdatDatum;
            }

            bokningsListaDS = bokningData.HämtaBokningsLista(BokningID);
            if (bokningsListaDS.BokningsLista.Count > 0)
            {
                foreach (BokningsListaDS.BokningsListaRow rad in bokningsListaDS.BokningsLista.Rows)
                {
                    bokningsLista = new BokningsLista();
                    bokningsLista.BokningID = rad.BokningID;
                    bokningsLista.BollNr = rad.BollNr.ToString();
                    bokningsLista.SpelareNamn = rad.SpelareNamn.ToString();
                    bokningDag.AddBokningsLista(bokningsLista);
                }

            }
            return bokningDag;
        }

        /// <summary>
        /// Hämtar rad från tabellen BokningDag i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="BokningID">Aktuell bokning</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public int HämtaSistaBokning(int tisdagTorsdag)
        {
            DataSet bokningDagDS = new DataSet();
            BokningData bokningData = new BokningData();
            int bokningID = 0;
            short antArgument = 0;
            string sqlSok = "";
            string sql = "";
            if (tisdagTorsdag.ToString() != "")
            {
                WhereFörInteger(tisdagTorsdag, "b.TisdagTorsdag", ref sqlSok, ref antArgument, " = ");
            }

            if (antArgument > 0)
            {
                sql = sql + " WHERE " + sqlSok;
            }

            bokningDagDS = bokningData.HämtaSistaBokning(sql);

            if (bokningDagDS.Tables[0].Rows.Count > 0)
            {
                bokningID = (int)bokningDagDS.Tables[0].Rows[0]["BokningID"];
            }

            return bokningID;
        }

        /// <summary>
        /// Sparar alla förändringar i BokningDag i databasen 
        /// </summary>
        /// <param name="bokningDag">Aktuell bokning</param>
        /// <param name="nyBokning">Ny Anvandare, true or false</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int Spara(BokningDag bokningDag, bool nyBokning, ref string felID, ref string feltext)
        {
            int nyttBokningID = 0;
            bool kollaOK = true;
//                Kolla(bokningDag, ref felID, ref feltext);

            if (kollaOK)
            {
                BokningData bokningData = new BokningData();
                if (nyBokning)
                {
                    nyttBokningID = bokningData.SparaNyBokning(bokningDag, ref felID, ref feltext);
                }
                else
                {
                    bokningData.SparaBokningDag(bokningDag, ref felID, ref feltext);
                }
            }
            else
            {
                throw new HookerException();
            }

            return nyttBokningID;
        }
    }
}
