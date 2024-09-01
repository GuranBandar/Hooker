using Hooker.Affärsobjekt;
using Hooker.Datalager;
using Hooker.Dataset;
using Hooker.Gemensam;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hooker.Affärslager
{
    /// <summary>
    /// Klass för Bokning
    /// 
    /// Innehåller alla metoder för klassen Gubblag verksamhetslogik.
    /// </summary>
    public sealed class GubblagAktivitet : SökVillkor
    {
        /// <summary>
        /// Hämtar rad från tabellen BokningDag i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="GubblagID">Aktuellt Gubblag</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public Gubblag HämtaGubblag(int gubblagID)
        {   
            GubblagData gubblagData = new GubblagData();
            GubblagsSpelareDS gubblagsSpelareDS = new GubblagsSpelareDS();
            GubblagDS gubblagDS = gubblagData.HämtaGubblag(gubblagID);
            Gubblag gubblag = null;
            GubblagsSpelare gubblagsSpelare = null;

            if (gubblagDS.Gubblag.Count == 1)
            {
                //Skapa Gubblagobjekt
                gubblag = new Gubblag();
                gubblag.GubblagID = gubblagDS.Gubblag[0].GubblagID;
                gubblag.Gubblagsnamn = gubblagDS.Gubblag[0].Gubblagsnamn;
                gubblag.AnvandarNamnSkapad = gubblagDS.Gubblag[0].AnvandarNamnSkapad;
                gubblag.SkapadDatum = gubblagDS.Gubblag[0].SkapadDatum;
                gubblag.AnvandarNamnUppdat = (gubblagDS.Gubblag[0].IsAnvandarNamnUppdatNull()) ?
                    string.Empty : gubblagDS.Gubblag[0].AnvandarNamnUppdat;
                gubblag.UppdatDatum = (gubblagDS.Gubblag[0].IsAnvandarNamnUppdatNull()) ?
                    string.Empty : gubblagDS.Gubblag[0].UppdatDatum;

            }

            gubblagsSpelareDS = gubblagData.HämtaGubblagsSpelare(gubblagID);
            if (gubblagsSpelareDS.GubblagsSpelare.Count > 0)
            {
                foreach (GubblagsSpelareDS.GubblagsSpelareRow rad in gubblagsSpelareDS.GubblagsSpelare.Rows)
                {
                    gubblagsSpelare = new GubblagsSpelare();
                    gubblagsSpelare.GubblagID = rad.GubblagID;
                    gubblagsSpelare.BollNr = rad.BollNr.ToString();
                    gubblagsSpelare.SpelarID = rad.SpelarID;
                    gubblagsSpelare.SpelareNamn = rad.SpelareNamn.ToString();
                    gubblag.AddGubblagsSpelare(gubblagsSpelare);
                }
            }
            return gubblag;
        }

        /// <summary>
        /// Hämtar rad från tabellen Gubblag i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="GubblagID">Aktuellt Gubblag</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public List<Gubblag> HämtallaGubblag()
        {
            GubblagData gubblagData = new GubblagData();
            DataSet gubblagDS = gubblagData.HämtaAllaGubblag();
            List<Gubblag> gubbLag = new List<Gubblag>();

            if (gubblagDS.Tables[0].Rows.Count > 0)
            {
                gubbLag = new List<Gubblag>(gubblagDS.Tables[0].Rows.Count);
                foreach (DataRow rad in gubblagDS.Tables[0].Rows)
                {
                    //Skapa BokningDagObjektet
                    gubbLag.Add(new Gubblag()
                    {
                        GubblagID = (int)rad["GubblagID"],
                        Gubblagsnamn = rad["Gubblagsnamn"].ToString(),
                        AnvandarNamnSkapad = rad["AnvandarNamnSkapad"].ToString(),
                        SkapadDatum = rad["SkapadDatum"].ToString(),
                        AnvandarNamnUppdat = rad["AnvandarNamnUppdat"].ToString(),
                        UppdatDatum = rad["UppdatDatum"].ToString()
                    });
                }
            }
            return gubbLag;
        }


        /// <summary>
        /// Sparar alla förändringar i Gubblag i databasen 
        /// </summary>
        /// <param name="gubblag">Aktuellt gubblag</param>
        /// <param name="nyttGubblag">Nytt gubblag, true or false</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int Spara(Gubblag gubblag, bool nyaGubblagsSpelare, ref string felID, ref string feltext)
        {
            int nyttGubblagID = 0;
            bool kollaOK = true;
            //                Kolla(bokningDag, ref felID, ref feltext);

            if (kollaOK)
            {
                GubblagData gubblagData = new GubblagData();
                gubblagData.SparaGubblag(gubblag, nyaGubblagsSpelare, ref felID, ref feltext);
            }
            else
            {
                throw new HookerException();
            }

            return nyttGubblagID;
        }

        /// <summary>
        /// Ta bort Gubblag i databasen 
        /// </summary>
        /// <param name="Gubblag">Aktuellt gubblag</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBort(Gubblag gubblag, ref string felID, ref string feltext)
        {
            GubblagData gubblagData = new GubblagData();
            gubblagData.TabortGubblag(gubblag, ref felID, ref feltext);
        }
    }
}
