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
    /// Affärslagerklass för Spelare
    /// 
    /// Innehåller alla metoder för klassen Spelares verksamhetslogik.
    /// </summary>
    public sealed class SpelareAktivitet : SökVillkor
    {
        /// <summary>
        /// Hämtar rad från tabellen Spelare i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="spelarID">Aktuell Spelare</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public Spelare HämtaSpelare(int spelarID)
        {
            SpelareDS spelareDS = new SpelareDS();
            SpelareData spelareData = new SpelareData();
            spelareDS = spelareData.HämtaSpelare(spelarID);
            Spelare spelare = new Hooker.Affärsobjekt.Spelare();

            if (spelareDS.Tables[0].Rows.Count != 0)
            {
                spelare.AktuelltSpelarID = spelareDS.Spelare[0].SpelarID;
                spelare.Namn = spelareDS.Spelare[0].Namn;
                spelare.ExaktHcp = spelareDS.Spelare[0].Hcp;
                spelare.GolfID = spelareDS.Spelare[0].GolfID;
                spelare.HemmabanaNr = spelareDS.Spelare[0].Hemmabananr;
                spelare.Klass = spelareDS.Spelare[0].Klass;
                spelare.Kön = spelareDS.Spelare[0].Kon;
                spelare.Revisionsdatum = spelareDS.Spelare[0].RevisionsDatum;
                spelare.UppdatDatum = spelareDS.Spelare[0].UppdatDatum;
                spelare.Portugalgolfare = (spelareDS.Spelare[0].IsPortugalgolfareNull())
                    ? string.Empty : spelareDS.Spelare[0].Portugalgolfare;

                if (!spelareDS.Spelare[0].IsGolfklubbNrNull())
                {
                    spelare.GolfklubbNr = spelareDS.Spelare[0].GolfklubbNr;
                }
                if (!spelareDS.Spelare[0].IsFederationNoNull())
                {
                    spelare.FederationNo = spelareDS.Spelare[0].FederationNo;
                }
            }
            return spelare;
        }

        /// <summary>
        /// Hämtar rad/-er från tabellen Spelare i aktuell databas med angivet namn.
        /// </summary>
        /// <param name="namn">Aktuell namn</param>
        /// <returns>Objektlista med efterfrågat data</returns>
        public List<Spelare> HämtaSpelare(string namn)
        {
            SpelareDS spelareDS = new SpelareDS();
            SpelareData spelareData = new SpelareData();
            spelareDS = spelareData.HämtaSpelare(namn);
            List<Spelare> spelare = new List<Spelare>(spelareDS.Spelare.Rows.Count);
            foreach (SpelareDS.SpelareRow rad in spelareDS.Spelare.Rows)
            {
                if (rad.IsGolfklubbNrNull())
                    rad.GolfklubbNr = 0;

                spelare.Add(new Spelare()
                {
                    AktuelltSpelarID = rad.SpelarID,
                    Namn = rad.Namn,
                    ExaktHcp = rad.Hcp,
                    GolfID = rad.GolfID,
                    HemmabanaNr = rad.Hemmabananr,
                    Klass = rad.Klass,
                    Kön = rad.Kon,
                    Revisionsdatum = rad.RevisionsDatum,
                    UppdatDatum = rad.UppdatDatum,
                    GolfklubbNr = Functions.ToInt(rad.GolfklubbNr),
                    FederationNo = rad.FederationNo,
                    Portugalgolfare = rad.Portugalgolfare
                });
            }
            return spelare;
        }

        /// <summary>
        /// Hämtar högsta nummer för Spelare
        /// </summary>
        /// <returns>Dataset med kolumn för högsta nr i Spelare</returns>
        public int HämtaMaxSpelarID()
        {
            DataSet spelareDS = new DataSet();
            SpelareData spelare = new SpelareData();
            spelareDS = spelare.HämtaMaxSpelarID();
            return (int)spelareDS.Tables["Spelare"].Rows[0]["Max"];
        }

        /// <summary>
        /// Söker rad/-er från tabellen Spelare i aktuell databas med angivet sökvillkor.
        /// </summary>
        /// <param name="namn">Aktuell namn</param>
        /// <param name="golfID">Ev GolfID i sökningen</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public List<Spelare> SökSpelare(string namn, string golfID)
        {
            DataSet spelareDS = new DataSet();
            SpelareData spelareData = new SpelareData();
            short antArgument = 0;
            string sqlSok = "";
            string sql = "";
            try
            {
                if (namn.ToString() != "")
                {
                    WhereMedLikeEfter(namn, "s.Namn", ref sqlSok, ref antArgument);
                }

                if (golfID.ToString() != "")
                {
                    WhereMedLikeEfter(golfID, "s.GolfID", ref sqlSok, ref antArgument);
                }

                if (antArgument > 0)
                {
                    sql = sql + " WHERE " + sqlSok;
                }

                spelareDS = spelareData.SökSpelare(sql);
                List<Spelare> spelare = new List<Spelare>(spelareDS.Tables["Spelare"].Rows.Count);
                foreach (DataRow rad in spelareDS.Tables["Spelare"].Rows)
                {
                    if (rad["GolfklubbNr"] == DBNull.Value)
                    {
                        rad["GolfklubbNr"] = 0;
                    }
                    spelare.Add(new Spelare()
                    {
                        AktuelltSpelarID = (int)rad["SpelarID"],
                        Namn = rad["Namn"].ToString(),
                        ExaktHcp = (decimal)rad["Hcp"],
                        GolfID = rad["GolfID"].ToString(),
                        HemmabanaNr = (int)rad["Hemmabananr"],
                        Klass = rad["Klass"].ToString(),
                        Kön = rad["Kon"].ToString(),
                        Revisionsdatum = (DateTime)rad["RevisionsDatum"],
                        UppdatDatum = (DateTime)rad["UppdatDatum"],
                        GolfklubbNr = (int)rad["GolfklubbNr"],
                        Golfklubbnamn = rad["GolfklubbNamn"].ToString(),
                        Hemmabana = rad["BanaNamn"].ToString(),
                        FederationNo = (int)rad["FederationNo"],
                        Portugalgolfare = rad["Portugalgolfare"].ToString()
                    });
                }
                return spelare;
            }
            catch (HookerException)
            {
                throw;
            }
        }

        public List<Spelare> HämtaPortugalgolfare(string Portugalgolfare)
        {
            SpelareDS spelareDS = new SpelareDS();
            SpelareData spelareData = new SpelareData();

            try
            {
                spelareDS = spelareData.HämtaPortugalgolfare(Portugalgolfare);
                List<Spelare> spelare = new List<Spelare>(spelareDS.Tables["Spelare"].Rows.Count);
                foreach (SpelareDS.SpelareRow rad in spelareDS.Spelare.Rows)
                {
                    if (rad.IsGolfklubbNrNull())
                        rad.GolfklubbNr = 0;

                    spelare.Add(new Spelare()
                    {
                        AktuelltSpelarID = rad.SpelarID,
                        Namn = rad.Namn,
                        ExaktHcp = rad.Hcp,
                        GolfID = rad.GolfID,
                        HemmabanaNr = rad.Hemmabananr,
                        Klass = rad.Klass,
                        Kön = rad.Kon,
                        Revisionsdatum = rad.RevisionsDatum,
                        UppdatDatum = rad.UppdatDatum,
                        GolfklubbNr = Functions.ToInt(rad.GolfklubbNr),
                        FederationNo = rad.FederationNo,
                        Portugalgolfare = rad.Portugalgolfare
                    });
                }
                return spelare;
            }
            catch (HookerException)
            {
                throw;
            }
        }

        /// <summary>
        /// Söker rad/-er från tabellen Spelare i aktuell databas som också är
        /// användare.
        /// </summary>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public List<Spelare> SökSpelareAnvandare()
        {
            DataSet spelareDS = new DataSet();
            SpelareData spelareData = new SpelareData();

            try
            {
                spelareDS = spelareData.SökSpelareAnvandare();
                List<Spelare> spelare = new List<Spelare>(spelareDS.Tables["Spelare"].Rows.Count);
                foreach (DataRow rad in spelareDS.Tables["Spelare"].Rows)
                {
                    if (rad["GolfklubbNr"] == DBNull.Value)
                    {
                        rad["GolfklubbNr"] = 0;
                    }
                    spelare.Add(new Spelare()
                    {
                        AktuelltSpelarID = (int)rad["SpelarID"],
                        Namn = rad["Namn"].ToString(),
                        ExaktHcp = (decimal)rad["Hcp"],
                        GolfID = rad["GolfID"].ToString(),
                        HemmabanaNr = (int)rad["Hemmabananr"],
                        Klass = rad["Klass"].ToString(),
                        Kön = rad["Kon"].ToString(),
                        Revisionsdatum = (DateTime)rad["RevisionsDatum"],
                        UppdatDatum = (DateTime)rad["UppdatDatum"],
                        GolfklubbNr = (int)rad["GolfklubbNr"],
                        Golfklubbnamn = rad["GolfklubbNamn"].ToString(),
                        Hemmabana = rad["BanaNamn"].ToString(),
                        FederationNo = (int)rad["FederationNo"],
                        Portugalgolfare = rad["Portugalgolfare"].ToString()
                    });
                }
                return spelare;
            }
            catch (HookerException)
            {
                throw;
            }
        }

        /// <summary>
        /// Hämtar alla spelare som ej är anmälda till aktuell tävling
        /// </summary>
        /// <param name="tavling">Aktuell tävling</param>
        /// <returns>DataSet med efterfrågat data</returns>
        public DataSet HämtaSpelareEjAnmälda(Tavling tavling)
        {
            SpelareData spelareData = new SpelareData();
            DataSet spelareDS;
            try
            {
                spelareDS = spelareData.HämtaSpelareEjAnmälda(tavling.TavlingID);
                return spelareDS;
            }
            catch (HookerException)
            {
                throw;
            }
        }

        /// <summary>
        ///     Sparar alla förändringar i Spelare i databasen 
        /// </summary>
        /// <param name="spelare">Aktuell spelare</param>
        /// <param name="nySpelare">Ny spelare, true or false</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void Spara(Spelare spelare, bool nySpelare, ref string felID, ref string feltext)
        {
            bool kollaOK = false;
            kollaOK = Kolla(spelare, ref felID, ref feltext);

            if (kollaOK)
            {
                SpelareData spelareData = new SpelareData();
                if (nySpelare)
                {
                    spelareData.SparaNySpelare(spelare, ref felID, ref feltext);
                }
                else
                {
                    spelareData.SparaSpelare(spelare, ref felID, ref feltext);
                }
            }
        }

        /// <summary>
        ///     Ta bort Spelare i databasen 
        /// </summary>
        /// <param name="spelare">Aktuell spelare</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBort(Spelare spelare, ref string felID, ref string feltext)
        {
            SpelareData spelareData = new SpelareData();
            spelareData.TabortSpelare(spelare, ref felID, ref feltext);
        }

        /// <summary>
        ///     Metoden kollar informationen innan uppdatering ska göras
        /// </summary>
        /// <param name="spelare">Spelare med informationen som ska kollas</param>
        /// <param name="felID">Ev felID som returneras</param>
        /// <param name="felmeddelande">Ev felmeddelande som returneras</param>
        private bool Kolla(Spelare spelare, ref string felID, ref string felmeddelande)
        {
            if (spelare.Namn.Length == 0)
            {
                felID = "SPELNAMNMISSING";
                felmeddelande = "";
                return false;
            }
            //if (spelare.GolfID.Length < 9)
            //{
            //    felID = "GOLFIDMISSING";
            //    felmeddelande = "";
            //    return false;
            //}
            if (spelare.ExaktHcp == 0)
            {
                felID = "SPELHCPMISSING";
                felmeddelande = "";
                return false;
            }
            return true;
        }
    }
}
