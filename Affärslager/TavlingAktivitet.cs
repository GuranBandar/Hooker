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
    /// Affärslagerklass för Tävling
    /// 
    /// Innehåller alla metoder för klassen Tavlingss verksamhetslogik.
    /// </summary>
    public sealed class TavlingAktivitet : SökVillkor
    {
        /// <summary>
        /// Hämtar rad från tabellen Tavling i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="tavlingID">Aktuell Tavling</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public Tavling HämtaTavling(int tavlingID)
        {
            TavlingData tavlingData = new Datalager.TavlingData();
            TavlingDS tavlingDS = tavlingData.HämtaTavling(tavlingID);
            Tavling tavling = new Hooker.Affärsobjekt.Tavling();
            tavling.TavlingID = tavlingDS.Tavling[0].TavlingID;
            tavling.Namn = tavlingDS.Tavling[0].Namn;
            tavling.StartDatum = tavlingDS.Tavling[0].StartDatum;
            tavling.TavlingStatus = tavlingDS.Tavling[0].TavlingStatus;
            tavling.Spelsatt = tavlingDS.Tavling[0].Spelsatt;
            tavling.Speltyp = tavlingDS.Tavling[0].Speltyp;
            tavling.OppenFor = tavlingDS.Tavling[0].OppenFor;
            tavling.AnmalanTidigast= tavlingDS.Tavling[0].AnmalanTidigast;
            tavling.AnmalanSenast = tavlingDS.Tavling[0].AnmalanSenast;
            tavling.StartlistaPubliceras = tavlingDS.Tavling[0].StartlistaPubliceras;
            tavling.ForstaStart = tavlingDS.Tavling[0].ForstaStart;
            tavling.MaxAntalAnmalda = tavlingDS.Tavling[0].MaxAntalAnmalda;
            tavling.PrincipForOveranmalan = tavlingDS.Tavling[0].PrincipForOveranmalan;
            tavling.Startavgift = tavlingDS.Tavling[0].Startavgift;
            tavling.Greenfee = tavlingDS.Tavling[0].Greenfee;
            tavling.Prissumma = tavlingDS.Tavling[0].Prissumma;
            tavling.Notering = tavlingDS.Tavling[0].Notering;
            tavling.UppdatDatum = tavlingDS.Tavling[0].UppdatDatum;
            tavling.FleraBanor = tavlingDS.Tavling[0].FleraBanor;
            tavling.NassauBett = tavlingDS.Tavling[0].NassauBett;
            return tavling;
        }

        /// <summary>
        /// Hämtar rad från tabellen Tavling i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="tavlingID">Aktuell Tavling</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public Tavling HämtaTavlingTavlingKlass(int tavlingID)
        {
            TavlingData tavlingData = new Datalager.TavlingData();
            DataSet tavlingDS = tavlingData.HämtaTavlingTavlingKlass(tavlingID);
            Tavling tavling = null;
            TavlingKlass tavlingKlass = null;

            if (tavlingDS.Tables["Tavling"].Rows.Count == 1)
            {
                tavling = new Hooker.Affärsobjekt.Tavling();
                tavling.TavlingID = (int)tavlingDS.Tables["Tavling"].Rows[0]["TavlingID"];
                tavling.Namn = tavlingDS.Tables["Tavling"].Rows[0]["Namn"].ToString();
                tavling.StartDatum = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["StartDatum"];
                tavling.TavlingStatus = tavlingDS.Tables["Tavling"].Rows[0]["TavlingStatus"].ToString();
                tavling.Spelsatt = tavlingDS.Tables["Tavling"].Rows[0]["Spelsatt"].ToString();
                tavling.Speltyp = tavlingDS.Tables["Tavling"].Rows[0]["Speltyp"].ToString();
                tavling.OppenFor = tavlingDS.Tables["Tavling"].Rows[0]["OppenFor"].ToString();
                tavling.AnmalanTidigast = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["AnmalanTidigast"];
                tavling.AnmalanSenast = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["AnmalanSenast"];
                tavling.StartlistaPubliceras = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["StartlistaPubliceras"];
                tavling.ForstaStart = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["ForstaStart"];
                tavling.MaxAntalAnmalda = (int)tavlingDS.Tables["Tavling"].Rows[0]["MaxAntalAnmalda"];
                tavling.PrincipForOveranmalan = tavlingDS.Tables["Tavling"].Rows[0]["PrincipForOveranmalan"].ToString();
                tavling.Startavgift = (int)tavlingDS.Tables["Tavling"].Rows[0]["Startavgift"];
                tavling.Greenfee = (int)tavlingDS.Tables["Tavling"].Rows[0]["Greenfee"];
                tavling.Prissumma = (int)tavlingDS.Tables["Tavling"].Rows[0]["Prissumma"];
                tavling.Notering = tavlingDS.Tables["Tavling"].Rows[0]["Notering"].ToString();
                tavling.UppdatDatum = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["UppdatDatum"];
                tavling.FleraBanor = tavlingDS.Tables["Tavling"].Rows[0]["FleraBanor"].ToString();
                tavling.NassauBett = (int)tavlingDS.Tables["Tavling"].Rows[0]["NassauBett"];

                foreach (DataRow rad in tavlingDS.Tables["TavlingKlass"].Rows)
                {
                    tavlingKlass = new TavlingKlass();
                    tavlingKlass.Klass = rad["Klass"].ToString();
                    tavlingKlass.Spelform = rad["Spelform"].ToString();
                    tavlingKlass.Klasstyp = rad["Klasstyp"].ToString();
                    tavlingKlass.AntRonder = (int)rad["AntRonder"];
                    tavlingKlass.TeeMan = rad["TeeMan"].ToString();
                    tavlingKlass.TeeKvinna = rad["TeeKvinna"].ToString();
                    tavlingKlass.OnskemalOmTee = rad["OnskemalOmTee"].ToString();
                    tavlingKlass.Kon = rad["Kon"].ToString();
                    tavlingKlass.Anmalningsavgift = (int)rad["Anmalningsavgift"];
                    tavlingKlass.Tillaggsavgift = (int)rad["Tillaggsavgift"];
                    tavlingKlass.MinHcpMan = (decimal)rad["MinHcpMan"];
                    tavlingKlass.MaxHcpMan = (decimal)rad["MaxHcpMan"];
                    tavlingKlass.MinHcpKvinna = (decimal)rad["MinHcpKvinna"];
                    tavlingKlass.MaxHcpKvinna = (decimal)rad["MaxHcpKvinna"];
                    tavlingKlass.MinHcpLag = (decimal)rad["MinHcpLag"];
                    tavlingKlass.MaxHcpLag = (decimal)rad["MaxHcpLag"];
                    tavlingKlass.MinAlderMan = (int)rad["MinAlderMan"];
                    tavlingKlass.MaxAlderMan = (int)rad["MaxAlderMan"];
                    tavlingKlass.MinAlderKvinna = (int)rad["MinAlderKvinna"];
                    tavlingKlass.MaxAlderKvinna = (int)rad["MaxAlderKvinna"];
                    tavlingKlass.UppdatDatum = (System.DateTime)rad["UppdatDatum"];
                    tavlingKlass.KlassNamn = rad["KlassNamn"].ToString();
                    tavlingKlass.SpelformVarde = rad["SpelformVarde"].ToString();
                    tavlingKlass.KlasstypVarde = rad["KlasstypVarde"].ToString();
                    tavling.AddTavlingKlass(tavlingKlass);
                }
            }

            return tavling;
        }

        /// <summary>
        /// Hämtar alla tävlingar för aktuell period.
        /// </summary>
        /// <param name="fromDatum">From datum</param>
        /// <param name="tomDatum">Tom datum</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public List<Tavling> HämtaAllaTavlingar(DateTime fromDatum, DateTime tomDatum)
        {
            TavlingData tavlingData = new Datalager.TavlingData();
            TavlingDS tavlingDS = tavlingData.HämtaAllaTavlingar(fromDatum, tomDatum);
            List<Tavling> tavling = null;

            if (tavlingDS.Tavling.Rows.Count > 0)
            {
                //Skapa tavlingobjekten
                tavling = new List<Tavling>(tavlingDS.Tavling.Rows.Count);
                foreach (TavlingDS.TavlingRow rad in tavlingDS.Tavling.Rows)
                {
                    tavling.Add(new Tavling()
                    {
                        TavlingID = rad.TavlingID,
                        Namn = rad.Namn,
                        StartDatum = rad.StartDatum,
                        TavlingStatus = rad.TavlingStatus,
                        Spelsatt = rad.Spelsatt,
                        Speltyp = rad.Speltyp,
                        OppenFor = rad.OppenFor,
                        AnmalanTidigast = rad.AnmalanTidigast,
                        AnmalanSenast = rad.AnmalanSenast,
                        StartlistaPubliceras = rad.StartlistaPubliceras,
                        ForstaStart = rad.ForstaStart,
                        MaxAntalAnmalda = rad.MaxAntalAnmalda,
                        PrincipForOveranmalan = rad.PrincipForOveranmalan,
                        Startavgift = rad.Startavgift,
                        Greenfee = rad.Greenfee,
                        Prissumma = rad.Prissumma,
                        Notering = rad.Notering,
                        UppdatDatum = rad.UppdatDatum,
                        FleraBanor = rad.FleraBanor,
                        NassauBett = rad.NassauBett
                    });
                }
            }

            return tavling;
        }

        /// <summary>
        /// Hämtar alla tävlingar för aktuell period.
        /// </summary>
        /// <param name="fromDatum">From datum</param>
        /// <param name="tomDatum">Tom datum</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public List<Tavling> HämtaAllaStartadeEllerKlaraTavlingar(DateTime fromDatum, DateTime tomDatum)
        {
            TavlingData tavlingData = new Datalager.TavlingData();
            TavlingDS tavlingDS = tavlingData.HämtaAllaStartadeEllerKlaraTavlingar(fromDatum, tomDatum);
            List<Tavling> tavling = null;

            if (tavlingDS.Tavling.Rows.Count > 0)
            {
                //Skapa tavlingobjekten
                tavling = new List<Tavling>(tavlingDS.Tavling.Rows.Count);
                foreach (TavlingDS.TavlingRow rad in tavlingDS.Tavling.Rows)
                {
                    tavling.Add(new Tavling()
                    {
                        TavlingID = rad.TavlingID,
                        Namn = rad.Namn,
                        StartDatum = rad.StartDatum,
                        TavlingStatus = rad.TavlingStatus,
                        Spelsatt = rad.Spelsatt,
                        Speltyp = rad.Speltyp,
                        OppenFor = rad.OppenFor,
                        AnmalanTidigast = rad.AnmalanTidigast,
                        AnmalanSenast = rad.AnmalanSenast,
                        StartlistaPubliceras = rad.StartlistaPubliceras,
                        ForstaStart = rad.ForstaStart,
                        MaxAntalAnmalda = rad.MaxAntalAnmalda,
                        PrincipForOveranmalan = rad.PrincipForOveranmalan,
                        Startavgift = rad.Startavgift,
                        Greenfee = rad.Greenfee,
                        Prissumma = rad.Prissumma,
                        Notering = rad.Notering,
                        UppdatDatum = rad.UppdatDatum,
                        FleraBanor = rad.FleraBanor,
                        NassauBett = rad.NassauBett
                    });
                }
            }

            return tavling;
        }

        /// <summary>
        /// Hämtar alla tävlingsposter för Tavling i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="tavlingID">Aktuell Tavling</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public Tavling HämtaTavlingAllt(int tavlingID)
        {
            TavlingData tavlingData = new Datalager.TavlingData();
            DataSet tavlingDS = tavlingData.HämtaTavlingAllt(tavlingID);
            Tavling tavling = null;
//            TavlingKlass tavlingKlass = null;
//            TavlingDeltagare tavlingDeltagare = null;
//            TavlingRond tavlingRond = null;
//            TavlingRondResultat tavlingRondResultat = null;
//            TavlingStartlista tavlingStartlista = null;

            if (tavlingDS.Tables["Tavling"].Rows.Count == 1)
            {
                tavling = new Hooker.Affärsobjekt.Tavling();
                tavling.TavlingID = (int)tavlingDS.Tables["Tavling"].Rows[0]["TavlingID"];
                tavling.Namn = tavlingDS.Tables["Tavling"].Rows[0]["Namn"].ToString();
                tavling.StartDatum = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["StartDatum"];
                tavling.TavlingStatus = tavlingDS.Tables["Tavling"].Rows[0]["TavlingStatus"].ToString();
                tavling.Spelsatt = tavlingDS.Tables["Tavling"].Rows[0]["Spelsatt"].ToString();
                tavling.Speltyp = tavlingDS.Tables["Tavling"].Rows[0]["Speltyp"].ToString();
                tavling.OppenFor = tavlingDS.Tables["Tavling"].Rows[0]["OppenFor"].ToString();
                tavling.AnmalanTidigast = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["AnmalanTidigast"];
                tavling.AnmalanSenast = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["AnmalanSenast"];
                tavling.StartlistaPubliceras = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["StartlistaPubliceras"];
                tavling.ForstaStart = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["ForstaStart"];
                tavling.MaxAntalAnmalda = (int)tavlingDS.Tables["Tavling"].Rows[0]["MaxAntalAnmalda"];
                tavling.PrincipForOveranmalan = tavlingDS.Tables["Tavling"].Rows[0]["PrincipForOveranmalan"].ToString();
                tavling.Startavgift = (int)tavlingDS.Tables["Tavling"].Rows[0]["Startavgift"];
                tavling.Greenfee = (int)tavlingDS.Tables["Tavling"].Rows[0]["Greenfee"];
                tavling.Prissumma = (int)tavlingDS.Tables["Tavling"].Rows[0]["Prissumma"];
                tavling.Notering = tavlingDS.Tables["Tavling"].Rows[0]["Notering"].ToString();
                tavling.UppdatDatum = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["UppdatDatum"];
                tavling.FleraBanor = tavlingDS.Tables["Tavling"].Rows[0]["FleraBanor"].ToString();
                tavling.NassauBett = (int)tavlingDS.Tables["Tavling"].Rows[0]["NassauBett"];

                foreach (DataRow rad in tavlingDS.Tables["TavlingKlass"].Rows)
                {
                    TavlingKlass tavlingKlass = new TavlingKlass();
                    tavlingKlass.TavlingID = (int)rad["TavlingID"];
                    tavlingKlass.Klass = rad["Klass"].ToString();
                    tavlingKlass.Spelform = rad["Spelform"].ToString();
                    tavlingKlass.Klasstyp = rad["Klasstyp"].ToString();
                    tavlingKlass.AntRonder = (int)rad["AntRonder"];
                    tavlingKlass.TeeMan = rad["TeeMan"].ToString();
                    tavlingKlass.TeeKvinna = rad["TeeKvinna"].ToString();
                    tavlingKlass.OnskemalOmTee = rad["OnskemalOmTee"].ToString();
                    tavlingKlass.Kon = rad["Kon"].ToString();
                    tavlingKlass.Anmalningsavgift = (int)rad["Anmalningsavgift"];
                    tavlingKlass.Tillaggsavgift = (int)rad["Tillaggsavgift"];
                    tavlingKlass.MinHcpMan = (decimal)rad["MinHcpMan"];
                    tavlingKlass.MaxHcpMan = (decimal)rad["MaxHcpMan"];
                    tavlingKlass.MinHcpKvinna = (decimal)rad["MinHcpKvinna"];
                    tavlingKlass.MaxHcpKvinna = (decimal)rad["MaxHcpKvinna"];
                    tavlingKlass.MinHcpLag = (decimal)rad["MinHcpLag"];
                    tavlingKlass.MaxHcpLag = (decimal)rad["MaxHcpLag"];
                    tavlingKlass.MinAlderMan = (int)rad["MinAlderMan"];
                    tavlingKlass.MaxAlderMan = (int)rad["MaxAlderMan"];
                    tavlingKlass.MinAlderKvinna = (int)rad["MinAlderKvinna"];
                    tavlingKlass.MaxAlderKvinna = (int)rad["MaxAlderKvinna"];
                    tavlingKlass.UppdatDatum = (System.DateTime)rad["UppdatDatum"];
                    tavlingKlass.KlassNamn = rad["KlassNamn"].ToString();
                    tavlingKlass.SpelformVarde = rad["SpelformVarde"].ToString();
                    tavlingKlass.KlasstypVarde = rad["KlasstypVarde"].ToString();
                    tavling.AddTavlingKlass(tavlingKlass);
                }

                foreach (DataRow rad in tavlingDS.Tables["TavlingDeltagare"].Rows)
                {
                    TavlingDeltagare tavlingDeltagare = new TavlingDeltagare();
                    tavlingDeltagare.SpelarID = (int)rad["SpelarID"];
                    tavlingDeltagare.Klass = rad["Klass"].ToString();
                    tavlingDeltagare.AnmaldNr = (int)rad["AnmaldNr"];
                    tavlingDeltagare.Hcp = (decimal)rad["Hcp"];
                    tavlingDeltagare.SpelHcp = (int)rad["SpelHcp"];
                    tavlingDeltagare.UppdatDatum = (System.DateTime)rad["UppdatDatum"];
                    tavling.AddTavlingDeltagare(tavlingDeltagare);
                }

                foreach (DataRow rad in tavlingDS.Tables["TavlingRond"].Rows)
                {
                    TavlingRond tavlingRond = new TavlingRond();
                    tavlingRond.RondId = (int)rad["RondID"];
                    tavlingRond.TavlingID = (int)rad["TavlingID"];
                    tavlingRond.Klass = rad["Klass"].ToString();
                    tavlingRond.RondNr = (int)rad["RondNr"];
                    tavlingRond.Datum = (System.DateTime)rad["Datum"];
                    tavlingRond.ForstaStartTid = (TimeSpan)rad["ForstaStartTid"];
                    tavlingRond.AntalHal = (int)rad["AntalHal"];
                    tavlingRond.Cut = rad["Cut"].ToString();
                    tavlingRond.UppdatDatum = (System.DateTime)rad["UppdatDatum"];
                    
                    if (rad["SpelarIDNearest"] == System.DBNull.Value)
                    {
                        tavlingRond.SpelarIDNearest = 0;
                    }
                    else
                    {
                        tavlingRond.SpelarIDNearest = (int)rad["SpelarIDNearest"];
                    }
                    
                    if (rad["SpelarIDLongest"] == System.DBNull.Value)
                    {
                        tavlingRond.SpelarIDLongest = 0;
                    }
                    else
                    {
                        tavlingRond.SpelarIDLongest = (int)rad["SpelarIDLongest"];
                    }

                    tavlingRond.RondStatus = rad["RondStatus"].ToString();
                    tavlingRond.BanaNr = (int)rad["BanaNr"];
                    tavling.AddTavlingRond(tavlingRond);
                }

                foreach (DataRow rad in tavlingDS.Tables["TavlingRondResultat"].Rows)
                {
                    TavlingRondResultat tavlingRondResultat = new TavlingRondResultat();
                    tavlingRondResultat.RondId = (int)rad["RondID"];
                    tavlingRondResultat.SpelarID = (int)rad["SpelarID"];
                    tavlingRondResultat.HalNr = (int)rad["HalNr"];
                    tavlingRondResultat.AntalSlag = (int)rad["AntalSlag"];
                    tavlingRondResultat.AntalPoang = (int)rad["AntalPoang"];
                    tavlingRondResultat.UppdatDatum = (System.DateTime)rad["UppdatDatum"];
                    tavling.AddTavlingRondResultat(tavlingRondResultat);
                }

                foreach (DataRow rad in tavlingDS.Tables["TavlingStartlista"].Rows)
                {
                    TavlingStartlista tavlingStartlista = new TavlingStartlista();
                    tavlingStartlista.RondID = (int)rad["RondID"];
                    tavlingStartlista.SpelareID = (int)rad["SpelarID"];
                    tavlingStartlista.BollNr = (int)rad["BollNr"];
                    tavlingStartlista.Hal = (int)rad["Hal"];
                    tavlingStartlista.StartDatum = (System.DateTime)rad["StartDatum"];
                    tavlingStartlista.Starttid = (TimeSpan)rad["Starttid"];
                    tavlingStartlista.Klass = rad["Klass"].ToString();
                    tavlingStartlista.ExaktHcp = (decimal)rad["ExaktHcp"];
                    tavlingStartlista.ErhallnaSlag = (int)rad["ErhallnaSlag"];
                    tavlingStartlista.Tee = rad["Tee"].ToString();
                    tavlingStartlista.UppdatDatum = (System.DateTime)rad["UppdatDatum"];
                    tavling.AddTavlingStartlista(tavlingStartlista);
                }
            }

            return tavling;
        }

        /// <summary>
        /// Hämtar rad/-er från tabellen Tavling i aktuell databas med angivet tavlingNamn.
        /// </summary>
        /// <param name="tavlingNamn">Aktuell tavlingNamn</param>
        /// <param name="spelsatt">Spelsätt</param>
        /// <param name="speltyp">Speltyp</param>
        /// <param name="fromDatum">From datum</param>
        /// <param name="tomDatum">Tom datum</param>
        /// <returns>Objektlista med efterfrågat data</returns>
        public DataSet SökTavling(string tavlingNamn, string spelsatt, string speltyp, DateTime fromDatum, DateTime tomDatum)
        {
            Datalager.TavlingData tavlingData = new Datalager.TavlingData();
            DataSet tavlingDS;
            string sql;
            try
            {
                sql = SkapaSökvillkor(tavlingNamn, spelsatt, speltyp, fromDatum, tomDatum);
                tavlingDS = tavlingData.SökTavling(sql);
                return tavlingDS;
            }
            catch (HookerException)
            {
                throw;
            }
        }

        /// <summary>
        /// Kolla hur många anmälda som finns registrerad på aktuell tävling
        /// </summary>
        /// <param name="tavlingID">Aktuellt tavlingID</param>
        /// <returns>Antalet registrerade spelare på tävlingen</returns>
        public int KollaAntaletAnmälda(int tavlingID)
        {
            TavlingDeltagareDS tavlingDeltagareDS = new TavlingDeltagareDS();
            TavlingData tavlingData = new TavlingData();
            tavlingDeltagareDS = tavlingData.KollaAntaletAnmalda(tavlingID);
            return tavlingDeltagareDS.TavlingDeltagare.Count;
        }

        /// <summary>
        ///     Sparar alla förändringar i Tavling i databasen 
        /// </summary>
        /// <param name="tavling">Aktuell Tavling</param>
        /// <param name="nyTavling">Ny Tavling, true or false</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int Spara(Tavling tavling, bool nyTavling, ref string felID, ref string feltext)
        {
            int nyttTavlingID = 0;
            bool kollaOK = Kolla(tavling, ref felID, ref feltext);

            if (kollaOK)
            {
                Datalager.TavlingData tavlingData = new Datalager.TavlingData();
                if (nyTavling)
                {
                    nyttTavlingID = tavlingData.SparaNyTavling(tavling, ref felID, ref feltext);
                }
                else
                {
                    tavlingData.SparaTavling(tavling, ref felID, ref feltext);
                }
            }
            else
            {
                throw new HookerException();
            }
            return nyttTavlingID;
        }

        /// <summary>
        /// Ta bort Tavling i databasen 
        /// </summary>
        /// <param name="tavling">Aktuell Tavling</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBort(Tavling tavling, ref string felID, ref string feltext)
        {
            Datalager.TavlingData tavlingData = new Datalager.TavlingData();
            tavlingData.TaBortTavling(tavling, ref felID, ref feltext);
        }

        /// <summary>
        ///     Metoden kollar informationen innan uppdatering ska göras
        /// </summary>
        /// <param name="tavling">Tavling med informationen som ska kollas</param>
        /// <param name="felID">Ev felID som returneras</param>
        /// <param name="felmeddelande">Ev felmeddelande som returneras</param>
        private bool Kolla(Tavling tavling, ref string felID, ref string felmeddelande)
        {
            if (string.IsNullOrEmpty(tavling.Namn))
            {
                felID = "TAVLINGNAMNMISSING";
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
