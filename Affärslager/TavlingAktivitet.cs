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
            Tavling tavling = new Hooker.Affärsobjekt.Tavling
            {
                TavlingID = tavlingDS.Tavling[0].TavlingID,
                Namn = tavlingDS.Tavling[0].Namn,
                StartDatum = tavlingDS.Tavling[0].StartDatum,
                TavlingStatus = tavlingDS.Tavling[0].TavlingStatus,
                Spelsatt = tavlingDS.Tavling[0].Spelsatt,
                Speltyp = tavlingDS.Tavling[0].Speltyp,
                OppenFor = tavlingDS.Tavling[0].OppenFor,
                AnmalanTidigast = tavlingDS.Tavling[0].AnmalanTidigast,
                AnmalanSenast = tavlingDS.Tavling[0].AnmalanSenast,
                StartlistaPubliceras = tavlingDS.Tavling[0].StartlistaPubliceras,
                ForstaStart = tavlingDS.Tavling[0].ForstaStart,
                MaxAntalAnmalda = tavlingDS.Tavling[0].MaxAntalAnmalda,
                PrincipForOveranmalan = tavlingDS.Tavling[0].PrincipForOveranmalan,
                Startavgift = tavlingDS.Tavling[0].Startavgift,
                Greenfee = tavlingDS.Tavling[0].Greenfee,
                Prissumma = tavlingDS.Tavling[0].Prissumma,
                Notering = tavlingDS.Tavling[0].Notering,
                UppdatDatum = tavlingDS.Tavling[0].UppdatDatum,
                FleraBanor = tavlingDS.Tavling[0].FleraBanor,
                NassauBett = tavlingDS.Tavling[0].NassauBett
            };
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
            //TavlingKlass tavlingKlass = null;

            if (tavlingDS.Tables["Tavling"].Rows.Count == 1)
            {
                tavling = new Hooker.Affärsobjekt.Tavling
                {
                    TavlingID = (int)tavlingDS.Tables["Tavling"].Rows[0]["TavlingID"],
                    Namn = tavlingDS.Tables["Tavling"].Rows[0]["Namn"].ToString(),
                    StartDatum = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["StartDatum"],
                    TavlingStatus = tavlingDS.Tables["Tavling"].Rows[0]["TavlingStatus"].ToString(),
                    Spelsatt = tavlingDS.Tables["Tavling"].Rows[0]["Spelsatt"].ToString(),
                    Speltyp = tavlingDS.Tables["Tavling"].Rows[0]["Speltyp"].ToString(),
                    OppenFor = tavlingDS.Tables["Tavling"].Rows[0]["OppenFor"].ToString(),
                    AnmalanTidigast = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["AnmalanTidigast"],
                    AnmalanSenast = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["AnmalanSenast"],
                    StartlistaPubliceras = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["StartlistaPubliceras"],
                    ForstaStart = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["ForstaStart"],
                    MaxAntalAnmalda = (int)tavlingDS.Tables["Tavling"].Rows[0]["MaxAntalAnmalda"],
                    PrincipForOveranmalan = tavlingDS.Tables["Tavling"].Rows[0]["PrincipForOveranmalan"].ToString(),
                    Startavgift = (int)tavlingDS.Tables["Tavling"].Rows[0]["Startavgift"],
                    Greenfee = (int)tavlingDS.Tables["Tavling"].Rows[0]["Greenfee"],
                    Prissumma = (int)tavlingDS.Tables["Tavling"].Rows[0]["Prissumma"],
                    Notering = tavlingDS.Tables["Tavling"].Rows[0]["Notering"].ToString(),
                    UppdatDatum = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["UppdatDatum"],
                    FleraBanor = tavlingDS.Tables["Tavling"].Rows[0]["FleraBanor"].ToString(),
                    NassauBett = (int)tavlingDS.Tables["Tavling"].Rows[0]["NassauBett"]
                };

                foreach (DataRow rad in tavlingDS.Tables["TavlingKlass"].Rows)
                {
                    TavlingKlass tavlingKlass = new TavlingKlass
                    {
                        Klass = rad["Klass"].ToString(),
                        Spelform = rad["Spelform"].ToString(),
                        Klasstyp = rad["Klasstyp"].ToString(),
                        AntRonder = (int)rad["AntRonder"],
                        TeeMan = rad["TeeMan"].ToString(),
                        TeeKvinna = rad["TeeKvinna"].ToString(),
                        OnskemalOmTee = rad["OnskemalOmTee"].ToString(),
                        Kon = rad["Kon"].ToString(),
                        Anmalningsavgift = (int)rad["Anmalningsavgift"],
                        Tillaggsavgift = (int)rad["Tillaggsavgift"],
                        MinHcpMan = (decimal)rad["MinHcpMan"],
                        MaxHcpMan = (decimal)rad["MaxHcpMan"],
                        MinHcpKvinna = (decimal)rad["MinHcpKvinna"],
                        MaxHcpKvinna = (decimal)rad["MaxHcpKvinna"],
                        MinHcpLag = (decimal)rad["MinHcpLag"],
                        MaxHcpLag = (decimal)rad["MaxHcpLag"],
                        MinAlderMan = (int)rad["MinAlderMan"],
                        MaxAlderMan = (int)rad["MaxAlderMan"],
                        MinAlderKvinna = (int)rad["MinAlderKvinna"],
                        MaxAlderKvinna = (int)rad["MaxAlderKvinna"],
                        UppdatDatum = (System.DateTime)rad["UppdatDatum"],
                        KlassNamn = rad["KlassNamn"].ToString(),
                        SpelformVarde = rad["SpelformVarde"].ToString(),
                        KlasstypVarde = rad["KlasstypVarde"].ToString()
                    };
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
                tavling = new Hooker.Affärsobjekt.Tavling
                {
                    TavlingID = (int)tavlingDS.Tables["Tavling"].Rows[0]["TavlingID"],
                    Namn = tavlingDS.Tables["Tavling"].Rows[0]["Namn"].ToString(),
                    StartDatum = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["StartDatum"],
                    TavlingStatus = tavlingDS.Tables["Tavling"].Rows[0]["TavlingStatus"].ToString(),
                    Spelsatt = tavlingDS.Tables["Tavling"].Rows[0]["Spelsatt"].ToString(),
                    Speltyp = tavlingDS.Tables["Tavling"].Rows[0]["Speltyp"].ToString(),
                    OppenFor = tavlingDS.Tables["Tavling"].Rows[0]["OppenFor"].ToString(),
                    AnmalanTidigast = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["AnmalanTidigast"],
                    AnmalanSenast = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["AnmalanSenast"],
                    StartlistaPubliceras = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["StartlistaPubliceras"],
                    ForstaStart = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["ForstaStart"],
                    MaxAntalAnmalda = (int)tavlingDS.Tables["Tavling"].Rows[0]["MaxAntalAnmalda"],
                    PrincipForOveranmalan = tavlingDS.Tables["Tavling"].Rows[0]["PrincipForOveranmalan"].ToString(),
                    Startavgift = (int)tavlingDS.Tables["Tavling"].Rows[0]["Startavgift"],
                    Greenfee = (int)tavlingDS.Tables["Tavling"].Rows[0]["Greenfee"],
                    Prissumma = (int)tavlingDS.Tables["Tavling"].Rows[0]["Prissumma"],
                    Notering = tavlingDS.Tables["Tavling"].Rows[0]["Notering"].ToString(),
                    UppdatDatum = (System.DateTime)tavlingDS.Tables["Tavling"].Rows[0]["UppdatDatum"],
                    FleraBanor = tavlingDS.Tables["Tavling"].Rows[0]["FleraBanor"].ToString(),
                    NassauBett = (int)tavlingDS.Tables["Tavling"].Rows[0]["NassauBett"]
                };

                foreach (DataRow rad in tavlingDS.Tables["TavlingKlass"].Rows)
                {
                    TavlingKlass tavlingKlass = new TavlingKlass
                    {
                        TavlingID = (int)rad["TavlingID"],
                        Klass = rad["Klass"].ToString(),
                        Spelform = rad["Spelform"].ToString(),
                        Klasstyp = rad["Klasstyp"].ToString(),
                        AntRonder = (int)rad["AntRonder"],
                        TeeMan = rad["TeeMan"].ToString(),
                        TeeKvinna = rad["TeeKvinna"].ToString(),
                        OnskemalOmTee = rad["OnskemalOmTee"].ToString(),
                        Kon = rad["Kon"].ToString(),
                        Anmalningsavgift = (int)rad["Anmalningsavgift"],
                        Tillaggsavgift = (int)rad["Tillaggsavgift"],
                        MinHcpMan = (decimal)rad["MinHcpMan"],
                        MaxHcpMan = (decimal)rad["MaxHcpMan"],
                        MinHcpKvinna = (decimal)rad["MinHcpKvinna"],
                        MaxHcpKvinna = (decimal)rad["MaxHcpKvinna"],
                        MinHcpLag = (decimal)rad["MinHcpLag"],
                        MaxHcpLag = (decimal)rad["MaxHcpLag"],
                        MinAlderMan = (int)rad["MinAlderMan"],
                        MaxAlderMan = (int)rad["MaxAlderMan"],
                        MinAlderKvinna = (int)rad["MinAlderKvinna"],
                        MaxAlderKvinna = (int)rad["MaxAlderKvinna"],
                        UppdatDatum = (System.DateTime)rad["UppdatDatum"],
                        KlassNamn = rad["KlassNamn"].ToString(),
                        SpelformVarde = rad["SpelformVarde"].ToString(),
                        KlasstypVarde = rad["KlasstypVarde"].ToString()
                    };
                    tavling.AddTavlingKlass(tavlingKlass);
                }

                foreach (DataRow rad in tavlingDS.Tables["TavlingDeltagare"].Rows)
                {
                    TavlingDeltagare tavlingDeltagare = new TavlingDeltagare
                    {
                        SpelarID = (int)rad["SpelarID"],
                        Klass = rad["Klass"].ToString(),
                        AnmaldNr = (int)rad["AnmaldNr"],
                        Hcp = (decimal)rad["Hcp"],
                        SpelHcp = (int)rad["SpelHcp"],
                        UppdatDatum = (System.DateTime)rad["UppdatDatum"]
                    };
                    tavling.AddTavlingDeltagare(tavlingDeltagare);
                }

                foreach (DataRow rad in tavlingDS.Tables["TavlingRond"].Rows)
                {
                    TavlingRond tavlingRond = new TavlingRond
                    {
                        RondId = (int)rad["RondID"],
                        TavlingID = (int)rad["TavlingID"],
                        Klass = rad["Klass"].ToString(),
                        RondNr = (int)rad["RondNr"],
                        Datum = (System.DateTime)rad["Datum"],
                        ForstaStartTid = (TimeSpan)rad["ForstaStartTid"],
                        AntalHal = (int)rad["AntalHal"],
                        Cut = rad["Cut"].ToString(),
                        UppdatDatum = (System.DateTime)rad["UppdatDatum"]
                    };

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
                    TavlingRondResultat tavlingRondResultat = new TavlingRondResultat
                    {
                        RondId = (int)rad["RondID"],
                        SpelarID = (int)rad["SpelarID"],
                        HalNr = (int)rad["HalNr"],
                        AntalSlag = (int)rad["AntalSlag"],
                        AntalPoang = (int)rad["AntalPoang"],
                        UppdatDatum = (System.DateTime)rad["UppdatDatum"]
                    };
                    tavling.AddTavlingRondResultat(tavlingRondResultat);
                }

                foreach (DataRow rad in tavlingDS.Tables["TavlingStartlista"].Rows)
                {
                    TavlingStartlista tavlingStartlista = new TavlingStartlista
                    {
                        RondID = (int)rad["RondID"],
                        SpelareID = (int)rad["SpelarID"],
                        BollNr = (int)rad["BollNr"],
                        Hal = (int)rad["Hal"],
                        StartDatum = (System.DateTime)rad["StartDatum"],
                        Starttid = (TimeSpan)rad["Starttid"],
                        Klass = rad["Klass"].ToString(),
                        ExaktHcp = (decimal)rad["ExaktHcp"],
                        ErhallnaSlag = (int)rad["ErhallnaSlag"],
                        Tee = rad["Tee"].ToString(),
                        UppdatDatum = (System.DateTime)rad["UppdatDatum"]
                    };
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
            _ = new TavlingDeltagareDS();
            TavlingData tavlingData = new TavlingData();
            TavlingDeltagareDS tavlingDeltagareDS = tavlingData.KollaAntaletAnmalda(tavlingID);
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
