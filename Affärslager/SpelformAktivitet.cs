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
    /// Klass för Spelform
    /// 
    /// Innehåller alla metoder för klassen Spelforms verksamhetslogik.
    /// </summary>
    public sealed class SpelformAktivitet : SökVillkor
    {
        /// <summary>
        /// Hämtar rad från tabellen Spelform i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="SpelformID">Aktuell spelform</param>
        /// <param name="Sprakkod">Användarens språkkod</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public Spelform HämtaSpelform(int SpelformID, string Sprakkod)
        {
            SpelformData SpelformData = new SpelformData();
            SpelformDS SpelformDS = SpelformData.HämtaSpelform(SpelformID, Sprakkod);
            Spelform Spelform = null;

            if (SpelformDS.Spelform.Count == 1)
            {
                //Skapa Spelformobjekt
                Spelform = new Spelform();
                Spelform.SpelformID = SpelformDS.Spelform[0].SpelformID;
                Spelform.Sprakkod = SpelformDS.Spelform[0].Sprakkod;
                Spelform.Titel = SpelformDS.Spelform[0].Titel;
                Spelform.Beskrivning = SpelformDS.Spelform[0].Beskrivning;
                Spelform.Lagspel = SpelformDS.Spelform[0].Lagspel;
                Spelform.AntalPerLag = (SpelformDS.Spelform[0].IsAntalPerLagNull()) ? string.Empty : SpelformDS.Spelform[0].AntalPerLag;
                Spelform.AnvandarNamnSkapad = SpelformDS.Spelform[0].AnvandarNamnSkapad;
                Spelform.SkapadDatum = SpelformDS.Spelform[0].SkapadDatum;
                Spelform.AnvandarNamnUppdat = SpelformDS.Spelform[0].AnvandarNamnUppdat;
                Spelform.UppdatDatum = SpelformDS.Spelform[0].UppdatDatum;
            }
            return Spelform;
        }

        /// <summary>
        /// Hämtar alla rader från tabellen Spelform i aktuell databas.
        /// </summary>
        /// <returns>Objekt med efterfrågat data</returns>
        public List<Spelform> HämtaAllaSpelformer()
        {
            DataSet SpelformDS = new DataSet();
            SpelformData SpelformData = new SpelformData();
            SpelformDS = SpelformData.HämtaAllaSpelformer();
            List<Spelform> Spelform = new List<Spelform>();

            if (SpelformDS.Tables[0].Rows.Count > 0)
            {
                Spelform = new List<Spelform>(SpelformDS.Tables[0].Rows.Count);
                foreach (DataRow rad in SpelformDS.Tables[0].Rows)
                {
                    //Skapa SpelformObjektet
                    Spelform.Add(new Spelform()
                    {
                        SpelformID = (int)rad["SpelformID"],
                        Sprakkod = rad["Sprakkod"].ToString(),
                        Titel = rad["Titel"].ToString(),
                        Beskrivning = rad["Beskrivning"].ToString(),
                        Lagspel = rad["Lagspel"].ToString(),
                        AntalPerLag = rad["AntalPerLag"].ToString(),
                        AnvandarNamnSkapad = rad["AnvandarNamnSkapad"].ToString(),
                        SkapadDatum = rad["SkapadDatum"].ToString(),
                        AnvandarNamnUppdat = rad["AnvandarNamnUppdat"].ToString(),
                        UppdatDatum = rad["UppdatDatum"].ToString(),
                    }); ;
                }
            }

            return Spelform;
        }

        /// <summary>
        /// Sparar alla förändringar i Spelform i databasen 
        /// </summary>
        /// <param name="Spelform">Aktuell spelform</param>
        /// <param name="nySpelform">Ny Spelform, true or false</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int Spara(Spelform Spelform, bool nySpelform, ref string felID, ref string feltext)
        {
            int nyttSpelformID = 0;
            bool kollaOK = true;
            string sql;

            if (kollaOK)
            {
                SpelformData SpelformData = new SpelformData();
                if (nySpelform)
                {
                    SpelformData.SparaNySpelform(Spelform, ref felID, ref feltext);
                    nyttSpelformID = Convert.ToInt32(SpelformData.HämtaMaxSpelform());
                    Spelform.SpelformID = nyttSpelformID;
                }
                else
                {
                    SpelformData.SparaSpelform(Spelform, ref felID, ref feltext);
                }
            }
            else
            {
                throw new HookerException();
            }

            return nyttSpelformID;
        }

        /// <summary>
        /// Ta bort Spelform i databasen 
        /// </summary>
        /// <param name="Spelform">Aktuell Spelform</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBort(Spelform Spelform, ref string felID, ref string feltext)
        {
            SpelformData SpelformData = new SpelformData();
            SpelformData.TabortSpelform(Spelform, ref felID, ref feltext);
        }
    }
}
