using Hooker.Affärsobjekt;
using Hooker.Datalager;
using Hooker.Dataset;
using Hooker.Gemensam;
using System;
using System.Data;

namespace Hooker.Affärslager
{
    /// <summary>
    /// Affärslagerklass för TävlingKlass
    /// 
    /// Innehåller alla metoder för klassen TavlingKlass verksamhetslogik.
    /// </summary>
    public sealed class TavlingKlassAktivitet
    {
        /// <summary>
        /// Hämtar rad från tabellen TavlingKlass i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="tavlingID">Aktuell Tavling</param>
        /// <param name="klass">Aktuell klass</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public TavlingKlass HämtaTavlingKlass(int tavlingID, string klass)
        {
            TavlingKlassData tavlingKlassData = new Datalager.TavlingKlassData();
            TavlingKlassDS tavlingKlassDS = tavlingKlassData.HämtaTavlingKlass(tavlingID, klass);
            TavlingKlass tavlingKlass = new Hooker.Affärsobjekt.TavlingKlass();
            tavlingKlass.TavlingID = tavlingKlassDS.TavlingKlass[0].TavlingID;
            tavlingKlass.Klass = tavlingKlassDS.TavlingKlass[0].Klass;
            tavlingKlass.Spelform = tavlingKlassDS.TavlingKlass[0].Spelform;
            tavlingKlass.Klasstyp = tavlingKlassDS.TavlingKlass[0].Klasstyp;
            tavlingKlass.Kon = tavlingKlassDS.TavlingKlass[0].Kon;
            tavlingKlass.AntRonder = tavlingKlassDS.TavlingKlass[0].AntRonder;
            tavlingKlass.TeeMan = tavlingKlassDS.TavlingKlass[0].TeeMan;
            tavlingKlass.TeeKvinna = tavlingKlassDS.TavlingKlass[0].TeeKvinna;
            tavlingKlass.OnskemalOmTee = tavlingKlassDS.TavlingKlass[0].OnskemalOmTee;
            tavlingKlass.Anmalningsavgift = tavlingKlassDS.TavlingKlass[0].Anmalningsavgift;
            tavlingKlass.Tillaggsavgift = tavlingKlassDS.TavlingKlass[0].Tillaggsavgift;
            tavlingKlass.MinHcpMan = tavlingKlassDS.TavlingKlass[0].MinHcpMan;
            tavlingKlass.MaxHcpMan = tavlingKlassDS.TavlingKlass[0].MaxHcpMan;
            tavlingKlass.MinHcpKvinna = tavlingKlassDS.TavlingKlass[0].MinHcpKvinna;
            tavlingKlass.MaxHcpKvinna = tavlingKlassDS.TavlingKlass[0].MaxHcpKvinna;
            tavlingKlass.MinHcpLag = tavlingKlassDS.TavlingKlass[0].MinHcpLag;
            tavlingKlass.MaxHcpLag = tavlingKlassDS.TavlingKlass[0].MaxHcpLag;
            tavlingKlass.MinAlderMan = tavlingKlassDS.TavlingKlass[0].MinAlderMan;
            tavlingKlass.MaxAlderMan = tavlingKlassDS.TavlingKlass[0].MaxAlderMan;
            tavlingKlass.MinAlderKvinna = tavlingKlassDS.TavlingKlass[0].MinAlderKvinna;
            tavlingKlass.MaxAlderKvinna = tavlingKlassDS.TavlingKlass[0].MaxAlderKvinna;
            tavlingKlass.UppdatDatum = tavlingKlassDS.TavlingKlass[0].UppdatDatum;
            return tavlingKlass;
        }

        /// <summary>
        /// Hämtar alla tavlingsrondposter i tabellen TavlingRond för angiven tavling och klass
        /// </summary>
        /// <param name="tavlingID">Aktuell tavling</param>
        /// <param name="klass">Aktuell klass</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public TavlingKlass HämtaTavlingKlassTavlingRond(int tavlingID, string klass)
        {
            TavlingKlassData tavlingKlassData = new TavlingKlassData();
            DataSet tavlingKlassDS = tavlingKlassData.HämtaTavlingKlassTavlingRond(tavlingID, klass);
            TavlingKlass tavlingKlass = null;
            TavlingRond tavlingRond = null;

            if (tavlingKlassDS.Tables["TavlingKlass"].Rows.Count == 1)
            {
                tavlingKlass = new Hooker.Affärsobjekt.TavlingKlass();
                tavlingKlass.TavlingID = (int)tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["TavlingID"];
                tavlingKlass.Klass = tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["Klass"].ToString();
                tavlingKlass.Spelform = tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["Spelform"].ToString();
                tavlingKlass.Klasstyp = tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["Klasstyp"].ToString();
                tavlingKlass.Kon = tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["Kon"].ToString();
                tavlingKlass.AntRonder = (int)tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["AntRonder"];
                tavlingKlass.TeeMan = tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["TeeMan"].ToString();
                tavlingKlass.TeeKvinna = tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["TeeKvinna"].ToString();
                tavlingKlass.OnskemalOmTee = tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["OnskemalOmTee"].ToString();
                tavlingKlass.Anmalningsavgift = (int)tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["Anmalningsavgift"];
                tavlingKlass.Tillaggsavgift = (int)tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["Tillaggsavgift"];
                tavlingKlass.MinHcpMan = (decimal)tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["MinHcpMan"];
                tavlingKlass.MaxHcpMan = (decimal)tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["MaxHcpMan"];
                tavlingKlass.MinHcpKvinna = (decimal)tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["MinHcpKvinna"];
                tavlingKlass.MaxHcpKvinna = (decimal)tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["MaxHcpKvinna"];
                tavlingKlass.MinHcpLag = (decimal)tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["MinHcpLag"];
                tavlingKlass.MaxHcpLag = (decimal)tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["MaxHcpLag"];
                tavlingKlass.MinAlderMan = (int)tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["MinAlderMan"];
                tavlingKlass.MaxAlderMan = (int)tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["MaxAlderMan"];
                tavlingKlass.MinAlderKvinna = (int)tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["MinAlderKvinna"];
                tavlingKlass.MaxAlderKvinna = (int)tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["MaxAlderKvinna"];
                tavlingKlass.UppdatDatum = (System.DateTime)tavlingKlassDS.Tables["TavlingKlass"].Rows[0]["UppdatDatum"];

                foreach (DataRow rad in tavlingKlassDS.Tables["TavlingRond"].Rows)
                {
                    tavlingRond = new TavlingRond();
                    tavlingRond.RondId = (int)rad["RondID"];
                    tavlingRond.TavlingID = (int)rad["TavlingID"];
                    tavlingRond.Klass = rad["Klass"].ToString();
                    tavlingRond.RondNr = (int)rad["RondNr"];
                    tavlingRond.Datum = (System.DateTime)rad["Datum"];
                    tavlingRond.ForstaStartTid = (System.TimeSpan)rad["ForstaStartTid"];
                    tavlingRond.AntalHal = (int)rad["AntalHal"];
                    tavlingRond.Cut = rad["Cut"].ToString();
                    tavlingRond.UppdatDatum = (System.DateTime)rad["UppdatDatum"];
                    tavlingKlass.AddTavlingRond(tavlingRond);
                }
            }
            return tavlingKlass;
        }

        /// <summary>
        /// Hämtar rad från tabellen TavlingKlass i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="tavlingID">Aktuell Tavling</param>
        /// <param name="klass">Aktuell klass</param>
        /// <returns>True om raden finnas annars false</returns>
        public bool FinnsTavlingKlass(int tavlingID, string klass)
        {
            TavlingKlassData tavlingKlassData = new Datalager.TavlingKlassData();
            TavlingKlassDS tavlingKlassDS = tavlingKlassData.HämtaTavlingKlass(tavlingID, klass);

            if (tavlingKlassDS.TavlingKlass.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Sparar alla förändringar i TavlingKlass i databasen 
        /// </summary>
        /// <param name="tavling">Aktuell TavlingKlass</param>
        /// <param name="nyTavlingKlass">Ny TavlingKlass, true or false</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int Spara(Tavling tavling, bool nyTavlingKlass, ref string felID, ref string feltext)
        {
            TavlingKlassData tavlingKlassData;
            TavlingRondAktivitet tavlingRondAktivitet;
            int nyaRader = 0;

            foreach (TavlingKlass tavlingKlass in tavling.TavlingKlass)
            {
                if (Kolla(tavlingKlass, ref felID, ref feltext))
                {
                    tavlingKlassData = new TavlingKlassData();

                    if (nyTavlingKlass || tavlingKlass.UppdatDatum == null)
                    {
                        tavlingKlass.UppdatDatum = DateTime.Today.Date;
                        tavlingKlass.ForstaStart = tavling.ForstaStart;
                        nyaRader = tavlingKlassData.SparaNyTavlingKlass(tavlingKlass, ref felID, ref feltext);

                        //Tabellen TavlingRond ska uppdateras nu, men först måste en ev gammal tas bort först
                        tavlingRondAktivitet = new TavlingRondAktivitet();
                        tavlingRondAktivitet.Spara(tavlingKlass, ref felID, ref feltext);
                    }
                    //else
                    //{
                    //    tavlingKlass.UppdatDatum = DateTime.Today.Date;
                    //    tavlingKlassData.SparaTavlingKlass(tavlingKlass, ref felID, ref feltext);
                    //}
                }
                else
                {
                    throw new HookerException();
                }
            }
            return nyaRader;
        }

        /// <summary>
        /// Sparar alla förändringar i TavlingKlass i databasen 
        /// </summary>
        /// <param name="tavlingKlass">Aktuell TavlingKlass</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void Spara(TavlingKlass tavlingKlass, ref string felID, ref string feltext)
        {
            TavlingKlassData tavlingKlassData;
            //TavlingRondAktivitet tavlingRondAktivitet;
            //bool kollaOK = false;

            if (Kolla(tavlingKlass, ref felID, ref feltext))
            {
                tavlingKlassData = new TavlingKlassData();
                tavlingKlass.UppdatDatum = DateTime.Today.Date;
                tavlingKlassData.SparaTavlingKlass(tavlingKlass, ref felID, ref feltext);

                //Tabellen TavlingRond ska uppdateras nu, men först måste en ev gammal tas bort först
                //if (nyTavlingKlass)
                //{
                //    tavlingRondAktivitet = new TavlingRondAktivitet();
                //    //tavlingRondAktivitet.SparaNyTavlingRond(tavlingKlass, ref felID, ref feltext);
                //}
            }
            else
            {
                throw new HookerException();
            }
        }

        /// <summary>
        ///     Ta bort TavlingKlass i databasen 
        /// </summary>
        /// <param name="tavlingKlass">Aktuell TavlingKlass</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBort(TavlingKlass tavlingKlass, ref string felID, ref string feltext)
        {
            Datalager.TavlingKlassData tavlingKlassData = new Datalager.TavlingKlassData();
            tavlingKlassData.TaBortTavlingKlass(tavlingKlass, ref felID, ref feltext);
        }

        /// <summary>
        ///     Metoden kollar informationen innan uppdatering ska göras
        /// </summary>
        /// <param name="tavlingKlass">TavlingKlass med informationen som ska kollas</param>
        /// <param name="felID">Ev felID som returneras</param>
        /// <param name="felmeddelande">Ev felmeddelande som returneras</param>
        private bool Kolla(TavlingKlass tavlingKlass, ref string felID, ref string felmeddelande)
        {
            if (string.IsNullOrEmpty(tavlingKlass.Klass))
            {
                felID = "TAVLINGNAMNMISSING";
                felmeddelande = "";
                return false;
            }
            if (string.IsNullOrEmpty(tavlingKlass.Spelform))
            {
                felID = "GOLFIDMISSING";
                felmeddelande = "";
                return false;
            }
            //if (string.IsNullOrEmpty(tavling.Notering))
            //{
            //    felID = "NOTERINGMISSING";
            //    felmeddelande = "";
            //    return false;
            //}
            return true;
        }
    }
}
