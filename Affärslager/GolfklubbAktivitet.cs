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
    /// Affärslagerklass för Golfklubb
    /// 
    /// Innehåller alla metoder för klassen Golfklubbs verksamhetslogik.
    /// </summary>
    public sealed class GolfklubbAktivitet : SökVillkor
    {

        /// <summary>
        /// Hämtar rad från tabellen Golfklubb i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="golfklubbNR">Aktuell Golfklubb</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public Golfklubb HämtaGolfklubb(int golfklubbNR)
        {
            GolfklubbData golfklubbData = new GolfklubbData();
            GolfklubbDS golfklubbDS = golfklubbData.HämtaGolfklubb(golfklubbNR);
            Golfklubb golfklubb = null;

            if (golfklubbDS.Golfklubb.Count == 1)
            {
                //Skapa Golfklubbobjektet
                golfklubb = new Golfklubb();
                golfklubb.GolfklubbNr = golfklubbDS.Golfklubb[0].GolfklubbNr;
                golfklubb.GolfklubbNamn = golfklubbDS.Golfklubb[0].GolfklubbNamn;
                golfklubb.AdressBesok = (golfklubbDS.Golfklubb[0].IsAdressBesokNull()) ? string.Empty : golfklubbDS.Golfklubb[0].AdressBesok;
                golfklubb.AdressOrt = (golfklubbDS.Golfklubb[0].IsAdressOrtNull()) ? string.Empty : golfklubbDS.Golfklubb[0].AdressOrt;
                golfklubb.TelBokning = (golfklubbDS.Golfklubb[0].IsTelBokningNull()) ? string.Empty : golfklubbDS.Golfklubb[0].TelBokning;
                golfklubb.TelKansli = (golfklubbDS.Golfklubb[0].IsTelKansliNull()) ? string.Empty : golfklubbDS.Golfklubb[0].TelKansli;
                golfklubb.Epost = (golfklubbDS.Golfklubb[0].IsEpostNull()) ? string.Empty : golfklubbDS.Golfklubb[0].Epost;
                golfklubb.Hemsida = (golfklubbDS.Golfklubb[0].IsHemsidaNull()) ? string.Empty : golfklubbDS.Golfklubb[0].Hemsida;
                golfklubb.UppdatDatum = golfklubbDS.Golfklubb[0].UppdatDatum;
                golfklubb.Distriktkod = golfklubbDS.Golfklubb[0].Distriktkod;
                golfklubb.Landkod = golfklubbDS.Golfklubb[0].Landkod;
                golfklubb.Notering = (golfklubbDS.Golfklubb[0].IsNoteringNull()) ? string.Empty : golfklubbDS.Golfklubb[0].Notering;
            }
            return golfklubb;
        }

        /// <summary>
        /// Hämtar rad/-er från tabellen Golfklubb i aktuell databas med angiven grupp.
        /// </summary>
        /// <param name="namn">Aktuell namn</param>
        /// <returns>Otypat dataset med efterfrågat data</returns>
        public List<Golfklubb> HämtaGolfklubb(string namn)
        {
            GolfklubbDS golfklubbDS = new GolfklubbDS();
            GolfklubbData golfklubbData = new GolfklubbData();
            List<Golfklubb> golfklubb = null;
            golfklubbDS = golfklubbData.HämtaGolfklubb(namn);

            if (golfklubbDS.Golfklubb.Rows.Count > 0)
            {
                //Skapa Golfklubbobjektet
                golfklubb = new List<Golfklubb>(golfklubbDS.Golfklubb.Rows.Count);
                foreach (GolfklubbDS.GolfklubbRow rad in golfklubbDS.Golfklubb.Rows)
                {
                    golfklubb.Add(new Golfklubb()
                    {
                        GolfklubbNr = rad.GolfklubbNr,
                        GolfklubbNamn = rad.GolfklubbNamn,
                        AdressBesok = rad.GetText("AdressBesok"),
                        AdressOrt = rad.GetText("AdressOrt"),
                        TelBokning = rad.GetText("TelBokning"),
                        TelKansli = rad.GetText("TelKansli"),
                        Epost = rad.GetText("Epost"),
                        Hemsida = rad.GetText("Hemsida"),
                        UppdatDatum = rad.UppdatDatum,
                        Distriktkod = rad.Distriktkod,
                        Landkod = rad.Landkod,
                        Notering = rad.GetText("Notering")
                    });
                }
            }
            return golfklubb;
        }

        /// <summary>
        /// Söker rad/-er från tabellen Golfklubb i aktuell databas med angivet sökvillkor.
        /// </summary>
        /// <param name="namn">Aktuell namn</param>
        /// <param name="ort">Ev ort i sökningen</param>
        /// <param name="land">Ev Landkod i sökningen</param>
        /// <param name="distrikt">Ev Distriktkod i sökningen</param>
        /// <returns>Golfklubbobjekt med efterfrågat data</returns>
        public List<Golfklubb> SökGolfklubb(string namn, string ort, string land, string distrikt)
        {
            DataSet golfklubbDS = new DataSet();
            Datalager.GolfklubbData golfklubbData = new Datalager.GolfklubbData();
            List<Golfklubb> golfklubb = null;
            short antArgument = 0;
            string sqlSok = "";
            string sql = "";

            try
            {
                if (!string.IsNullOrEmpty(namn))
                {
                    WhereMedLikeEfter(namn, "GolfklubbNamn", ref sqlSok, ref antArgument);
                }

                if (!string.IsNullOrEmpty(ort))
                {
                    WhereMedLikeEfter(ort, "AdressOrt", ref sqlSok, ref antArgument);
                }

                if (!string.IsNullOrEmpty(land) & land != "00")
                {
                    WhereFörSträng(land, "Landkod", ref sqlSok, ref antArgument, " = ");
                }

                if (!string.IsNullOrEmpty(distrikt) & distrikt != "00")
                {
                    WhereFörSträng(distrikt, "Distriktkod", ref sqlSok, ref antArgument, " = ");
                }

                if (antArgument > 0)
                {
                    sql = sql + " WHERE " + sqlSok;
                }

                golfklubbDS = golfklubbData.SökGolfklubb(sql);

                if (golfklubbDS.Tables["Golfklubb"].Rows.Count > 0)
                {
                    //Skapa Golfklubbobjektet
                    golfklubb = new List<Golfklubb>(golfklubbDS.Tables["Golfklubb"].Rows.Count);
                    foreach (DataRow rad in golfklubbDS.Tables["Golfklubb"].Rows)
                    {
                        golfklubb.Add(new Golfklubb()
                        {
                            GolfklubbNr = (int)rad["GolfklubbNr"],
                            GolfklubbNamn = rad["GolfklubbNamn"].ToString(),
                            AdressBesok = rad["AdressBesok"].ToString(),
                            AdressOrt = rad["AdressOrt"].ToString(),
                            TelBokning = rad["TelBokning"].ToString(),
                            TelKansli = rad["TelKansli"].ToString(),
                            Epost = rad["Epost"].ToString(),
                            Hemsida = rad["Hemsida"].ToString(),
                            UppdatDatum = DateTime.Parse(rad["UppdatDatum"].ToString()),
                            Distriktkod = rad["Distriktkod"].ToString(),
                            Landkod = rad["Landkod"].ToString(),
                            Notering = rad["Notering"].ToString(),
                            Distrikt = rad["Distrikt"].ToString(),
                            Land = rad["Land"].ToString()
                        });
                    }
                }
            }
            catch (HookerException)
            {
                throw;
            }
            return golfklubb;
        }

        /// <summary>
        ///     Sparar alla förändringar i Golfklubb i databasen 
        /// </summary>
        /// <param name="Golfklubb">Aktuell Golfklubb</param>
        /// <param name="nyGolfklubb">Ny Golfklubb, true or false</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int Spara(Golfklubb golfklubb, bool nyGolfklubb, ref string felID, ref string feltext)
        {
            int nyttGolfklubbNr = 0;
            bool kollaOK = Kolla(golfklubb, ref felID, ref feltext);

            if (kollaOK)
            {
                GolfklubbData golfklubbData = new GolfklubbData();
                if (nyGolfklubb)
                {
                    nyttGolfklubbNr = golfklubbData.SparaNyGolfklubb(golfklubb, ref felID, ref feltext);
                }
                else
                {
                    golfklubbData.SparaGolfklubb(golfklubb, ref felID, ref feltext);
                }
            }
            else
            {
                throw new HookerException();
            }
            return nyttGolfklubbNr;
        }

        /// <summary>
        ///     Ta bort Golfklubb i databasen 
        /// </summary>
        /// <param name="Golfklubb">Aktuell Golfklubb</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBort(Golfklubb golfklubb, ref string felID, ref string feltext)
        {
            GolfklubbData golfklubbData = new GolfklubbData();
            golfklubbData.TabortGolfklubb(golfklubb, ref felID, ref feltext);
        }

        /// <summary>
        ///     Metoden kollar informationen innan uppdatering ska göras
        /// </summary>
        /// <param name="Golfklubb">Golfklubbobjekt med informationen som ska kollas</param>
        /// <param name="felID">Ev felID som returneras</param>
        /// <param name="felmeddelande">Ev felmeddelande som returneras</param>
        private bool Kolla(Golfklubb golfklubb, ref string felID, ref string felmeddelande)
        {
            if (string.IsNullOrEmpty(golfklubb.GolfklubbNamn))
            {
                felID = "BANNAMNMISSING";
                felmeddelande = "";
                return false;
            }
            if (string.IsNullOrEmpty(golfklubb.Landkod))
            {
                felID = "BANLANDMISSING";
                felmeddelande = "";
                return false;
            }
            return true;
        }
    }
}
