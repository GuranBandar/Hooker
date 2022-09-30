using Hooker.Affärsobjekt;
using Hooker.Datalager;
using Hooker.Dataset;
using Hooker.Gemensam;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Hooker.Affärslager
{
    /// <summary>
    /// Affärslagerklass för TävlingRondResultat
    /// 
    /// Innehåller alla metoder för klassen TavlingRondResultat verksamhetslogik.
    /// </summary>
    public sealed class TavlingRondResultatAktivitet
    {
        /// <summary>
        /// Hämtar en post i tabellen TavlingRondResultat
        /// </summary>
        /// <param name="rondID">Aktuell rond</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public List<TavlingRondResultat> HämtaTavlingRondResultat(int rondID, int spelarID)
        {
            TavlingRondResultatData tavlingRondResultatData = new TavlingRondResultatData();
            TavlingRondResultatDS tavlingRondResultatDS = tavlingRondResultatData.HämtaTavlingRondResultat(rondID, spelarID);
            List<TavlingRondResultat> tavlingRondResultat = null;

            if (tavlingRondResultatDS.TavlingRondResultat.Rows.Count > 0)
            {
                tavlingRondResultat = new List<TavlingRondResultat>(tavlingRondResultatDS.TavlingRondResultat.Rows.Count);
                foreach (TavlingRondResultatDS.TavlingRondResultatRow rad in tavlingRondResultatDS.TavlingRondResultat.Rows)
                {
                    tavlingRondResultat.Add(new TavlingRondResultat()
                    {
                        RondId = rad.RondID,
                        SpelarID = rad.SpelarID,
                        HalNr = rad.HalNr,
                        AntalSlag = rad.AntalSlag,
                        AntalPoang = rad.AntalPoang,
                        UppdatDatum = rad.UppdatDatum
                    });
                }
            }
            return tavlingRondResultat;
        }

        /// <summary>
        /// Hämtar en post i tabellen TavlingRondResultat
        /// </summary>
        /// <param name="rondNr">Aktuell rond</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public List<TavlingRondResultat> HämtaTavlingRondResultatForSpelare(int tavlingID, int rondNr, int spelarID)
        {
            TavlingRondResultatData tavlingRondResultatData = new TavlingRondResultatData();
            TavlingRondResultatDS tavlingRondResultatDS =
                tavlingRondResultatData.HämtaTavlingRondResultatForSpelare(tavlingID, rondNr, spelarID);
            List<TavlingRondResultat> tavlingRondResultat = null;

            if (tavlingRondResultatDS.TavlingRondResultat.Rows.Count > 0)
            {
                tavlingRondResultat = new List<TavlingRondResultat>(tavlingRondResultatDS.TavlingRondResultat.Rows.Count);
                foreach (TavlingRondResultatDS.TavlingRondResultatRow rad in tavlingRondResultatDS.TavlingRondResultat.Rows)
                {
                    tavlingRondResultat.Add(new TavlingRondResultat()
                    {
                        RondId = rad.RondID,
                        SpelarID = rad.SpelarID,
                        HalNr = rad.HalNr,
                        AntalSlag = rad.AntalSlag,
                        AntalPoang = rad.AntalPoang,
                        UppdatDatum = rad.UppdatDatum
                    });
                }
            }
            return tavlingRondResultat;
        }

        /// <summary>
        /// Hämtar Tävlingresultat för spelare
        /// </summary>
        /// <param name="tavlingID">Aktuellt TavlingId</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public DataSet HämtaTavlingResultatForSpelare(int tavlingID, int spelarID)
        {
            TavlingRondResultatData tavlingRondResultatData = new TavlingRondResultatData();
            DataSet tavlingResultat = tavlingRondResultatData.HämtaTavlingResultatForSpelare(tavlingID, spelarID);
            return tavlingResultat;
        }

        /// <summary>
        /// Initiera poster i tabellen TavlingRondResultat
        /// </summary>
        /// <param name="tavling">Aktuell Tavling</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void InitieraTavlingRondResultat(Tavling tavling, int spelarID, ref string felID, ref string feltext)
        {
            TavlingRondResultatData tavlingRondResultatData = new TavlingRondResultatData();
            TavlingRondResultat tavlingRondResultat = null;

            //Tabellen TavlingRondResultat ska initieras för spelaren, betyder att TavlingRond poster behövs 
            if (tavling.HarTavlingRond())
            {
                foreach (TavlingRond tavlingRond in tavling.TavlingRond)
                {
                    for (int i = 0; i < tavlingRond.AntalHal; i++)
                    {
                        tavlingRondResultat = new TavlingRondResultat();
                        tavlingRondResultat.RondId = tavlingRond.RondId;
                        tavlingRondResultat.SpelarID = spelarID;
                        tavlingRondResultat.HalNr = i + 1;
                        tavlingRondResultat.AntalSlag = 0;
                        tavlingRondResultat.AntalPoang = 0;
                        tavlingRondResultat.UppdatDatum = DateTime.Today.Date;
                        tavlingRondResultatData.InitieraTavlingRondResultat(tavlingRondResultat, ref felID, ref feltext);
                    }
                }
            }
        }

        /// <summary>
        /// Hämta resultatlistan för aktuell tävling och rond
        /// </summary>
        /// <param name="tavling">Tavlingobjekt</param>
        /// <param name="klass">A</param>
        /// <returns></returns>
        public void HämtaResultatlista(Tavling tavling, string klass, int rondNr)
        {
            TavlingRondResultatData tavlingRondResultatData = new TavlingRondResultatData();
            TavlingResultatLista tavlingResultatLista = null;

            //Fältet Spelform i Tavlingklass anger om slag eller poäng ska räknas. 
            //Spelform "SG" och "ST" är slagspelformer
            bool slag = false;
            string spelform = "";
            int antalKlasser = tavling.AntalTavlingKlass();

            if (antalKlasser > 0)
            {
                for (int i = 0; i < tavling.TavlingKlass.Length; i++)
                {
                    if (tavling.TavlingKlass[i].Klass == klass)
                    {
                        spelform = tavling.TavlingKlass[i].Spelform.Trim();
                    }
                }

                if (spelform.Equals("SG") || spelform.Equals("ST"))
                {
                    slag = true;
                }
            }

            DataSet resultatlistaDS = tavlingRondResultatData.HämtaResultatlista(tavling.TavlingID, klass, rondNr, slag);

            if (resultatlistaDS.Tables[0].Rows.Count > 0)
            {
                //tavlingResultatLista = new List<TavlingResultatLista>(resultatlistaDS.Tables[0].Rows.Count);
                foreach (DataRow rad in resultatlistaDS.Tables[0].Rows)
                {
                    tavlingResultatLista = new TavlingResultatLista();
                    tavlingResultatLista.SpelarID = (int)rad["SpelarID"];
                    tavlingResultatLista.RondID = (int)rad["RondID"];
                    tavlingResultatLista.RondNr = (int)rad["RondNr"];
                    tavlingResultatLista.Klass = rad["Klass"].ToString();
                    tavlingResultatLista.Spelarnamn = rad["Spelarnamn"].ToString();
                    tavlingResultatLista.Hemmaklubb = rad["Hemmaklubb"].ToString();
                    tavlingResultatLista.SpelHcp = (int)rad["ErhallnaSlag"];
                    tavlingResultatLista.RondResultatUt = Convert.ToInt32(rad["RondResultatUt"]);
                    tavlingResultatLista.RondResultatIn = Convert.ToInt32(rad["RondResultatIn"]);
                    tavlingResultatLista.RondResultatTot = Convert.ToInt32(rad["RondResultatTot"]);
                    tavlingResultatLista.TotalResultat = Convert.ToInt32(rad["TotalResultat"]);
                    tavling.AddTavlingResultatLista(tavlingResultatLista);
                }
            }
            //return tavlingResultatLista;
        }

        /// <summary>
        /// Hämta Nassauresultat för aktuell tävling
        /// </summary>
        /// <param name="tavlingID">TavlingID</param>
        /// <returns>Otypat dataset med begärd information</returns>
        public DataSet HämtaNassau(int tavlingID)
        {
            TavlingRondResultatData tavlingRondResultatData = new TavlingRondResultatData();
            DataSet nassauDS = tavlingRondResultatData.HämtaNassau(tavlingID);
            return nassauDS;
        }

        /// <summary>
        /// Hämta Troféresultat för aktuell tävling
        /// </summary>
        /// <param name="tavlingID">TavlingID</param>
        /// <returns>Otypat dataset med begärd information</returns>
        public List<Ranking> HämtaTrofen(Tavling tavling)
        {
            TavlingRondResultatData tavlingRondResultatData = new TavlingRondResultatData();
            DataSet trofenDS = tavlingRondResultatData.HämtaTrofen(tavling.TavlingID);
            List<Ranking> rankinglista = null;

            if (trofenDS.Tables["Resultatlista"].Rows.Count > 0)
            {
                rankinglista = SkapaRankingLista(trofenDS, tavling);
            }

            return rankinglista;
        }

        /// <summary>
        /// Hämta R2A
        /// </summary>
        /// <param name="tavlingID">TavlingID</param>
        /// <returns>Otypat dataset med begärd information</returns>
        public List<Ranking> HämtaR2A(int tavlingID)
        {
            TavlingRondResultatData tavlingRondResultatData = new TavlingRondResultatData();
            DataSet r2aDS = tavlingRondResultatData.HämtaR2A(tavlingID);
            List<Ranking> rankinglista = null;
            Ranking ranking = null;
            Trofen r2a = null;
            int placering = 0;

            if (r2aDS.Tables["Ranking"].Rows.Count > 0)
            {
                rankinglista = new List<Ranking>(r2aDS.Tables["Ranking"].Rows.Count);
                foreach (DataRow rankrad in r2aDS.Tables["Ranking"].Rows)
                {
                    ranking = new Ranking();
                    ranking.TavlingId = (int)rankrad["TavlingID"];
                    ranking.Placering = placering++;
                    ranking.SpelarID = (int)rankrad["SpelarID"];
                    ranking.Placeringssiffra = (int)rankrad["Placeringssiffra"];
                    foreach (DataRow rondrad in r2aDS.Tables["R2A"].Rows)
                    {
                        if (ranking.SpelarID == (int)rondrad["SpelarID"])
                        {
                            r2a = new Trofen();
                            r2a.RondNr = (int)rondrad["RondNr"];
                            r2a.TavlingRondNr = (int)rondrad["TavlingRondNr"];
                            r2a.SpelarID = (int)rondrad["SpelarID"];
                            r2a.RondResultat = (int)rondrad["RondResultat"];
                            r2a.RankRond = (int)rondrad["RankRond"];
                            ranking.AddTrofen(r2a);
                        }
                    }
                    rankinglista.Add(ranking);
                }
            }
            return rankinglista;
        }

        /// <summary>
        /// Ta bort rader ur tabellen TavlingRondResultat för en spelare och tävling
        /// </summary>
        /// <param name="rondID">Aktuellt rondID</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBort(int rondID, int spelarID, ref string felID, ref string feltext)
        {
            TavlingRondResultatData tavlingRondResultatData = new TavlingRondResultatData();
            tavlingRondResultatData.TaBort(rondID, spelarID, ref felID, ref feltext);
        }

        /// <summary>
        /// Spara i tabellen TavlingRondResultat för en spelare och tävling
        /// </summary>
        /// <param name="tavling">Aktuellt objekt</param>
        /// <param name="rondID">Aktuellt RondID</param>
        /// <param name="spelarID">Aktuellt SpelarID</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void Spara(Tavling tavling, int rondID, int spelarID, ref string felID, ref string feltext)
        {
            TavlingRondResultatData tavlingRondResultatData = new TavlingRondResultatData();
            TavlingRondResultatDS tavlingRondResultatDS;

            foreach (TavlingRondResultat tavlingRondResultat in tavling.TavlingRondResultat)
            {
                tavlingRondResultatDS = tavlingRondResultatData.HämtaTavlingRondResultat(tavlingRondResultat.RondId,
                    tavlingRondResultat.SpelarID, tavlingRondResultat.HalNr);

                if (tavlingRondResultatDS.TavlingRondResultat.Count > 0)
                {
                    tavlingRondResultatData.SparaTavlingRondResultat(tavlingRondResultat, ref felID, ref feltext);
                }
                else
                {
                    tavlingRondResultatData.InitieraTavlingRondResultat(tavlingRondResultat, ref felID, ref feltext);
                }
            }
        }

        /// <summary>
        /// Löser det här med kod därför att den version av MariaDB som Synology supporterar inte fixar detta.
        /// 
        /// Den version som behövs är 10.2.3 som lägst, Synologys version suger.
        /// </summary>
        /// <param name="trofenDS"></param>
        /// <param name="tavling"></param>
        /// <returns></returns>
        private List<Ranking> SkapaRankingLista(DataSet trofenDS, Tavling tavling)
        {
            List<Ranking> rankinglista = null;
            Ranking ranking = null;
            Trofen trofen = null;
            List<Trofen> trofelista = null;
            int placering = 1;
            int antalRonder = tavling.TavlingKlass[0].AntRonder * 2;
            int radNr = 0;
            List<int> rankRond = new List<int>();

            trofelista = new List<Trofen>(trofenDS.Tables["Resultatlista"].Rows.Count);
            foreach (DataRow rondrad in trofenDS.Tables["Resultatlista"].Rows)
            {
                trofen = new Trofen();
                trofen.TavlingId = Convert.ToInt16(rondrad["TavlingID"]);
                trofen.RondNr = Convert.ToInt16(rondrad["RondNr"]);
                trofen.TavlingRondNr = Convert.ToInt16(rondrad["TavlingRondNr"]);
                trofen.SpelarID = Convert.ToInt16(rondrad["SpelarID"]);
                trofen.RondResultat = Convert.ToInt16(rondrad["RondResultat"]);
                trofelista.Add(trofen);
            }

            for (int i = 0; i < antalRonder; i++)
            {
                List<Trofen> tavlingsRond = trofelista.Where(x => x.TavlingRondNr == i + 1).ToList();

                var query = tavlingsRond.Rank(s => s.RondResultat, (s, r) => new { s, r });

                foreach (var x in query)
                {
                    int rank = (x.r);
                    trofelista[radNr].RankRond = rank;
                    radNr++;
                }
            }

            IEnumerable<Ranking> result = trofelista.
               GroupBy(hit => hit.SpelarID).
               Select(group => new Ranking
               {
                   TavlingId = tavling.TavlingID,
                   SpelarID = group.Key,
                   Placeringssiffra = group.Sum(hit => hit.RankRond)
               }).
               OrderBy(hit => hit.Placeringssiffra);

            rankinglista = new List<Ranking>(result.Count());

            foreach (Ranking item in result)
            {
                ranking = new Ranking();
                rankRond = new List<int>();
                ranking.TavlingId = item.TavlingId;
                ranking.Placering = placering++;
                ranking.SpelarID = item.SpelarID;
                ranking.Placeringssiffra = item.Placeringssiffra;
                foreach (Trofen troferad in trofelista)
                {
                    if (troferad.SpelarID == item.SpelarID)
                    {
                        trofen = new Trofen();
                        trofen.RondNr = troferad.RondNr;
                        trofen.TavlingRondNr = troferad.TavlingRondNr;
                        trofen.SpelarID = troferad.SpelarID;
                        trofen.RondResultat = troferad.RondResultat;
                        trofen.RankRond = troferad.RankRond;
                        ranking.AddTrofen(trofen);
                        rankRond.Add(trofen.RankRond);
                    }
                }

                ranking.SämstaPlacering = rankRond.OrderByDescending(x => x).FirstOrDefault();
                rankinglista.Add(ranking);
            }
            return rankinglista;
        }
    }
}
