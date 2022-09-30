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
    ///     Affärslagerklass för Bana
    /// 
    ///     Innehåller alla metoder för klassen Banas verksamhetslogik.
    /// </summary>
    public sealed class BanaAktivitet : SökVillkor
    {

        /// <summary>
        /// Hämtar rad från tabellen Bana i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="banaNR">Aktuell Bana</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public Bana HämtaBana(int banaNR)
        {
            BanaDS banaDS = new BanaDS();
            Datalager.BanaData banaData = new Datalager.BanaData();
            Bana bana = null;

            try
            {
                banaDS = banaData.HämtaBana(banaNR);

                if (banaDS.Bana.Count == 1)
                {
                    //Skapa Banaobjektet
                    bana = new Bana();
                    bana.BanaNr = banaDS.Bana[0].BanaNr;
                    bana.BanaNamn = banaDS.Bana[0].Namn;
                    bana.GolfklubbNr = banaDS.Bana[0].GolfklubbNr;
                    bana.SlopeHerrarGul = banaDS.Bana[0].SlopeHerrarGul;
                    bana.CrHerrarGul = banaDS.Bana[0].CrHerrarGul;
                    bana.SlopeDamerRod = banaDS.Bana[0].SlopeDamerRod;
                    bana.CrDamerRod = banaDS.Bana[0].CrDamerRod;
                    bana.UppdatDatum = banaDS.Bana[0].UppdatDatum;
                    bana.RankLayout = banaDS.Bana[0].RankLayout;
                    bana.RankSkick = banaDS.Bana[0].RankSkick;
                    bana.RankStrategi = banaDS.Bana[0].RankStrategi;
                    bana.RankNatur = banaDS.Bana[0].RankNatur;
                    bana.RankEtikett = banaDS.Bana[0].RankEtikett;
                    bana.RankRange = banaDS.Bana[0].RankRange;
                    bana.SlopeHerrarRod = banaDS.Bana[0].SlopeHerrarRod;
                    bana.CrHerrarRod = banaDS.Bana[0].CrHerrarRod;
                    bana.SlopeDamerGul = banaDS.Bana[0].SlopeDamerGul;
                    bana.CrDamerGul = banaDS.Bana[0].CrDamerGul;
                    bana.Notering = (banaDS.Bana[0].IsNoteringNull()) ? string.Empty : banaDS.Bana[0].Notering;
                    bana.Aktuell = banaDS.Bana[0].Aktuell;
                    bana.AntalHal = banaDS.Bana[0].AntalHal;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bana;
        }

        /// <summary>
        ///     Hämtar rad/-er från tabellen Bana i aktuell databas med angiven grupp.
        /// </summary>
        /// <param name="namn">Aktuell namn</param>
        /// <returns>Otypat dataset med efterfrågat data</returns>
        public List<Bana> HämtaBana(string namn)
        {
            BanaDS banaDS = new BanaDS();
            Datalager.BanaData banaData = new Datalager.BanaData();
            List<Bana> bana = null;
            banaDS = banaData.HämtaBana(namn);

            if (banaDS.Bana.Rows.Count > 0)
            {
                //Skapa Banaobjektet
                bana = new List<Bana>(banaDS.Bana.Rows.Count);
                foreach (BanaDS.BanaRow rad in banaDS.Bana.Rows)
                {
                    bana.Add(new Bana()
                    {
                        BanaNr = rad.BanaNr,
                        BanaNamn = rad.Namn,
                        GolfklubbNr = rad.GolfklubbNr,
                        SlopeHerrarGul = rad.SlopeHerrarGul,
                        CrHerrarGul = rad.CrHerrarGul,
                        SlopeDamerRod = rad.SlopeDamerRod,
                        CrDamerRod = rad.CrDamerRod,
                        UppdatDatum = rad.UppdatDatum,
                        RankLayout = rad.RankLayout,
                        RankSkick = rad.RankSkick,
                        RankStrategi = rad.RankStrategi,
                        RankNatur = rad.RankNatur,
                        RankEtikett = rad.RankEtikett,
                        RankRange = rad.RankRange,
                        SlopeHerrarRod = rad.SlopeHerrarRod,
                        CrHerrarRod = rad.CrHerrarRod,
                        SlopeDamerGul = rad.SlopeDamerGul,
                        CrDamerGul = rad.CrDamerGul,
                        Notering = rad.GetText("Notering"),
                        Aktuell = rad.Aktuell,
                        AntalHal = rad.AntalHal
                    });
                }
            }
            return bana;
        }

        /// <summary>
        /// Hämtar rad/-er från tabellen Bana i aktuell databas med angivet GolfklubbNr.
        /// </summary>
        /// <param name="namn">Aktuellt GolfklubbNr</param>
        /// <returns>Lista med Banaobjekt med efterfrågade banor</returns>
        public List<Bana> HämtaAktuellaBanorMedGolfklubbNr(int golfklubbNr)
        {
            BanaDS banaDS = new BanaDS();
            BanaData banaData = new BanaData();
            List<Bana> bana = null;
            banaDS = banaData.HämtaAktuellaBanorMedGolfklubbNr(golfklubbNr);

            if (banaDS.Bana.Rows.Count > 0)
            {
                //Skapa Banaobjektet
                bana = new List<Bana>(banaDS.Bana.Rows.Count);
                foreach (BanaDS.BanaRow rad in banaDS.Bana.Rows)
                {
                    bana.Add(new Bana()
                    {
                        BanaNr = rad.BanaNr,
                        BanaNamn = rad.Namn,
                        GolfklubbNr = rad.GolfklubbNr,
                        SlopeHerrarGul = rad.SlopeHerrarGul,
                        CrHerrarGul = rad.CrHerrarGul,
                        SlopeDamerRod = rad.SlopeDamerRod,
                        CrDamerRod = rad.CrDamerRod,
                        UppdatDatum = rad.UppdatDatum,
                        RankLayout = rad.RankLayout,
                        RankSkick = rad.RankSkick,
                        RankStrategi = rad.RankStrategi,
                        RankNatur = rad.RankNatur,
                        RankEtikett = rad.RankEtikett,
                        RankRange = rad.RankRange,
                        SlopeHerrarRod = rad.SlopeHerrarRod,
                        CrHerrarRod = rad.CrHerrarRod,
                        SlopeDamerGul = rad.SlopeDamerGul,
                        CrDamerGul = rad.CrDamerGul,
                        Notering = rad.GetText("Notering"),
                        Aktuell = rad.Aktuell,
                        AntalHal = rad.AntalHal
                    });
                }
            }
            return bana;
        }

        /// <summary>
        /// Hämtar rad/-er från tabellen Bana i aktuell databas med angivet GolfklubbNr.
        /// </summary>
        /// <param name="namn">Aktuellt GolfklubbNr</param>
        /// <returns>Lista med Banaobjekt med efterfrågade banor</returns>
        public List<Bana> HämtaBanaMedGolfklubbNr(int golfklubbNr)
        {
            BanaDS banaDS = new BanaDS();
            BanaData banaData = new BanaData();
            List<Bana> bana = null;
            banaDS = banaData.HämtaBanaMedGolfklubbNr(golfklubbNr);

            if (banaDS.Bana.Rows.Count > 0)
            {
                //Skapa Banaobjektet
                bana = new List<Bana>(banaDS.Bana.Rows.Count);
                foreach (BanaDS.BanaRow rad in banaDS.Bana.Rows)
                {
                    bana.Add(new Bana()
                    {
                        BanaNr = rad.BanaNr,
                        BanaNamn = rad.Namn,
                        GolfklubbNr = rad.GolfklubbNr,
                        SlopeHerrarGul = rad.SlopeHerrarGul,
                        CrHerrarGul = rad.CrHerrarGul,
                        SlopeDamerRod = rad.SlopeDamerRod,
                        CrDamerRod = rad.CrDamerRod,
                        UppdatDatum = rad.UppdatDatum,
                        RankLayout = rad.RankLayout,
                        RankSkick = rad.RankSkick,
                        RankStrategi = rad.RankStrategi,
                        RankNatur = rad.RankNatur,
                        RankEtikett = rad.RankEtikett,
                        RankRange = rad.RankRange,
                        SlopeHerrarRod = rad.SlopeHerrarRod,
                        CrHerrarRod = rad.CrHerrarRod,
                        SlopeDamerGul = rad.SlopeDamerGul,
                        CrDamerGul = rad.CrDamerGul,
                        Notering = rad.GetText("Notering"),
                        Aktuell = rad.Aktuell,
                        AntalHal = rad.AntalHal
                    });
                }
            }
            return bana;
        }

        /// <summary>
        /// Hämtar rad/-er från tabellen Bana i aktuell databas med angivet GolfklubbNr.
        /// </summary>
        /// <param name="namn">Aktuellt GolfklubbNr</param>
        /// <returns>Lista med Banaobjekt med efterfrågade banor</returns>
        public DataSet HämtaBanorMedGolfklubbNr(int golfklubbNr)
        {
            BanaData banaData = new BanaData();
            DataSet banaDS = banaData.HämtaBanorMedGolfklubbNr(golfklubbNr);
            return banaDS;
        }

        /// <summary>
        ///     Hämtar högsta nummer för Bana
        /// </summary>
        /// <returns>Dataset med kolumn för högsta nr i Bana</returns>
        public int HämtaMaxBanNr()
        {
            DataSet banaDS = new DataSet();
            Datalager.BanaData banaData = new Datalager.BanaData();
            banaDS = banaData.HämtaMaxBanNr();
            return (int)banaDS.Tables[0].Rows[0]["Max"];
        }

        /// <summary>
        ///     Söker rad/-er från tabellen Bana i aktuell databas med angivet sökvillkor.
        /// </summary>
        /// <param name="namn">Aktuell namn</param>
        /// <param name="ort">Ev ort i sökningen</param>
        /// <param name="land">Ev Landkod i sökningen</param>
        /// <param name="distrikt">Ev Distriktkod i sökningen</param>
        /// <returns>Banaobjekt med efterfrågat data</returns>
        public List<Bana> SökBana(string namn, string ort, string land, string distrikt)
        {
            DataSet banaDS = new DataSet();
            Datalager.BanaData banaData = new Datalager.BanaData();
            List<Bana> bana = null;
            short antArgument = 0;
            string sqlSok = "";
            string sql = "";

            try
            {
                if (!string.IsNullOrEmpty(namn))
                {
                    WhereMedLikeEfter(namn, "g.GolfklubbNamn", ref sqlSok, ref antArgument);
                    //WhereMedORochLikeEfter(namn, "GolfklubbNamn", ref sqlSok, ref antArgument);
                }

                if (!string.IsNullOrEmpty(ort))
                {
                    WhereMedLikeEfter(ort, "g.AdressOrt", ref sqlSok, ref antArgument);
                }

                if (!string.IsNullOrEmpty(land) & land != "00")
                {
                    WhereFörSträng(land, "g.Landkod", ref sqlSok, ref antArgument, " = ");
                }

                if (!string.IsNullOrEmpty(distrikt) & distrikt != "00")
                {
                    WhereFörSträng(distrikt, "g.Distriktkod", ref sqlSok, ref antArgument, " = ");
                }

                if (antArgument > 0)
                {
                    sql = sql + " WHERE " + sqlSok;
                }

                banaDS = banaData.SökBana(sql);

                if (banaDS.Tables["Bana"].Rows.Count > 0)
                {
                    //Skapa Banaobjektet
                    bana = new List<Bana>(banaDS.Tables["Bana"].Rows.Count);
                    foreach (DataRow rad in banaDS.Tables["Bana"].Rows)
                    {
                        bana.Add(new Bana()
                        {
                            GolfklubbNamn = rad["GolfklubbNamn"].ToString(),
                            AdressOrt = rad["AdressOrt"].ToString(),
                            Distriktkod = rad["Distriktkod"].ToString(),
                            Distrikt = rad["Distrikt"].ToString(),
                            Landkod = rad["Landkod"].ToString(),
                            Land = rad["Land"].ToString(),
                            BanaNr = (Convert.IsDBNull(rad["BanaNr"]) ? 0 : (int)rad["BanaNr"]),
                            BanaNamn = rad["Namn"].ToString(),
                            GolfklubbNr = Convert.ToInt32(rad["GolfklubbNr"]),
                            SlopeHerrarGul = (Convert.IsDBNull(rad["SlopeHerrarGul"]) ? 0 : (int)rad["SlopeHerrarGul"]),
                            CrHerrarGul = (Convert.IsDBNull(rad["CrHerrarGul"]) ? 0 : (decimal)rad["CrHerrarGul"]),
                            SlopeDamerRod = (Convert.IsDBNull(rad["SlopeDamerRod"]) ? 0 : (int)rad["SlopeDamerRod"]),
                            CrDamerRod = (Convert.IsDBNull(rad["CrDamerRod"]) ? 0 : (decimal)rad["CrDamerRod"]),
                            //UppdatDatum = DateTime.Parse(rad["UppdatDatum"].ToString()),
                            RankLayout = (Convert.IsDBNull(rad["RankLayout"]) ? 0 : (int)rad["RankLayout"]),
                            RankSkick = (Convert.IsDBNull(rad["RankSkick"]) ? 0 : (int)rad["RankSkick"]),
                            RankStrategi = (Convert.IsDBNull(rad["RankStrategi"]) ? 0 : (int)rad["RankStrategi"]),
                            RankNatur = (Convert.IsDBNull(rad["RankNatur"]) ? 0 : (int)rad["RankNatur"]),
                            RankEtikett = (Convert.IsDBNull(rad["RankEtikett"]) ? 0 : (int)rad["RankEtikett"]),
                            RankRange = (Convert.IsDBNull(rad["RankRange"]) ? 0 : (int)rad["RankRange"]),
                            SlopeHerrarRod = (Convert.IsDBNull(rad["SlopeHerrarRod"]) ? 0 : (int)rad["SlopeHerrarRod"]),
                            CrHerrarRod = (Convert.IsDBNull(rad["CrHerrarRod"]) ? 0 : (decimal)rad["CrHerrarRod"]),
                            SlopeDamerGul = (Convert.IsDBNull(rad["SlopeDamerGul"]) ? 0 : (int)rad["SlopeDamerGul"]),
                            CrDamerGul = (Convert.IsDBNull(rad["CrDamerGul"]) ? 0 : (decimal)rad["CrDamerGul"]),
                            Notering = (Convert.IsDBNull(rad["bananotering"]) ? string.Empty : rad["bananotering"].ToString()),
                            Aktuell = (Convert.IsDBNull(rad["Aktuell"]) ? string.Empty : rad["Aktuell"]).ToString(),
                            AntalHal = (Convert.IsDBNull(rad["AntalHal"]) ? string.Empty : rad["AntalHal"]).ToString()
                        });
                    }
                }
            }
            catch (HookerException)
            {
                throw;
            }
            return bana;
        }

        /// <summary>
        ///     Hämta Bana och banans alla BanaHal för angivet banaNr.
        /// </summary>
        /// <param name="banaNr">Banans nr</param>
        /// <returns>Ett sammansatt typat dataset med aktuell information</returns>
        public Bana HämtaBanaBanaHal(int banaNr)
        {
            BanaBanaHalSDS banaBanaHalSDS = new BanaBanaHalSDS();
            Datalager.BanaData banaData = new Datalager.BanaData();
            banaBanaHalSDS = banaData.HämtaBanaBanaHal(banaNr);
            Bana bana = null;
            BanaHal banaHal = null;

            if (banaBanaHalSDS.Bana.Count == 1)
            {
                //Skapa Banaobjektet
                bana = new Bana();
                bana.BanaNr = banaBanaHalSDS.Bana[0].BanaNr;
                bana.BanaNamn = banaBanaHalSDS.Bana[0].Namn;
                bana.GolfklubbNr = Convert.ToInt32(banaBanaHalSDS.Bana[0].GolfklubbNr);
                bana.SlopeHerrarGul = banaBanaHalSDS.Bana[0].SlopeHerrarGul;
                bana.CrHerrarGul = banaBanaHalSDS.Bana[0].CrHerrarGul;
                bana.SlopeDamerRod = banaBanaHalSDS.Bana[0].SlopeDamerRod;
                bana.CrDamerRod = banaBanaHalSDS.Bana[0].CrDamerRod;
                bana.UppdatDatum = banaBanaHalSDS.Bana[0].UppdatDatum;
                bana.RankLayout = banaBanaHalSDS.Bana[0].RankLayout;
                bana.RankSkick = banaBanaHalSDS.Bana[0].RankSkick;
                bana.RankStrategi = banaBanaHalSDS.Bana[0].RankStrategi;
                bana.RankNatur = banaBanaHalSDS.Bana[0].RankNatur;
                bana.RankEtikett = banaBanaHalSDS.Bana[0].RankEtikett;
                bana.RankRange = banaBanaHalSDS.Bana[0].RankRange;
                bana.SlopeHerrarRod = banaBanaHalSDS.Bana[0].SlopeHerrarRod;
                bana.CrHerrarRod = banaBanaHalSDS.Bana[0].CrHerrarRod;
                bana.SlopeDamerGul = banaBanaHalSDS.Bana[0].SlopeDamerGul;
                bana.CrDamerGul = banaBanaHalSDS.Bana[0].CrDamerGul;
                bana.Notering = (banaBanaHalSDS.Bana[0].IsNoteringNull()) ? string.Empty : banaBanaHalSDS.Bana[0].Notering;
                bana.Aktuell = banaBanaHalSDS.Bana[0].Aktuell;
                bana.AntalHal = banaBanaHalSDS.Bana[0].AntalHal;

                foreach (BanaBanaHalSDS.BanaHalRow rad in banaBanaHalSDS.BanaHal.Rows)
                {
                    banaHal = new BanaHal();
                    banaHal.HalNr = rad.Halnr;
                    banaHal.LangdVit = rad.LangdVit;
                    banaHal.LangdGul = rad.LangdGul;
                    banaHal.LangdBla = rad.LangdBla;
                    banaHal.LangdRod = rad.LangdRod;
                    banaHal.Par = rad.Par;
                    banaHal.Hcp = rad.Hcp;
                    bana.AddBanaHal(banaHal);
                }
            }
            return bana;
        }

        /// <summary>
        ///     Sparar alla förändringar i Bana i databasen 
        /// </summary>
        /// <param name="bana">Aktuell bana</param>
        /// <param name="nyBana">Ny bana, true or false</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void Spara(Bana bana, bool nyBana, ref string felID, ref string feltext)
        {
            Affärslager.BanaHalAktivitet banaHalAktivitet = new BanaHalAktivitet();
            bool kollaOK = false;
            kollaOK = Kolla(bana, ref felID, ref feltext);
            kollaOK = banaHalAktivitet.Kolla(bana, ref felID, ref feltext);

            if (kollaOK)
            {
                Datalager.BanaData banaData = new Datalager.BanaData();
                if (nyBana)
                {
                    banaData.SparaNyBana(bana, ref felID, ref feltext);
                }
                else
                {
                    banaData.SparaBana(bana, ref felID, ref feltext);
                }
            }
            else
            {
                throw new HookerException();
            }
        }

        /// <summary>
        ///     Ta bort Bana i databasen 
        /// </summary>
        /// <param name="bana">Aktuell bana</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBort(Bana bana, ref string felID, ref string feltext)
        {
            BanaData banaData = new BanaData();
            banaData.TaBortBana(bana.BanaNr, ref felID, ref feltext);
        }

        /// <summary>
        ///     Metoden kollar informationen innan uppdatering ska göras
        /// </summary>
        /// <param name="bana">Banaobjekt med informationen som ska kollas</param>
        /// <param name="felID">Ev felID som returneras</param>
        /// <param name="felmeddelande">Ev felmeddelande som returneras</param>
        private bool Kolla(Bana bana, ref string felID, ref string felmeddelande)
        {
            if (string.IsNullOrEmpty(bana.BanaNamn))
            {
                felID = "BANNAMNMISSING";
                felmeddelande = "";
                return false;
            }
            return true;
        }
    }
}
