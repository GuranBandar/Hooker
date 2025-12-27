using Hooker.Affärsobjekt;
using Hooker.Datalager;
using Hooker.Dataset;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hooker.Affärslager
{
    /// <summary>
    /// Affärslagerklass för EclecticRondResultat
    /// 
    /// Innehåller alla metoder för klassen EclecticRondResultats verksamhetslogik.
    /// </summary>
    public sealed class EclecticRondResultatAktivitet
    {
        /// <summary>
        /// Hämtar en post i tabellen EclecticRondResultat
        /// </summary>
        /// <param name="deltagarID">Aktuell RondDeltagare</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public List<EclecticRondResultat> HämtaEclecticRondResultat(int rondID, int spelarID)
        {
            EclecticRondResultatData eclecticRondResultatData = new EclecticRondResultatData();
            EclecticRondResultatDS eclecticRondResultatDS = eclecticRondResultatData.HämtaEclecticRondResultat(rondID, spelarID);
            List<EclecticRondResultat> eclecticRondResultat = new List<EclecticRondResultat>();

            if (eclecticRondResultatDS.EclecticRondResultat.Rows.Count > 0)
            {
                eclecticRondResultat = new List<EclecticRondResultat>(eclecticRondResultatDS.EclecticRondResultat.Rows.Count);
                foreach (EclecticRondResultatDS.EclecticRondResultatRow rad in eclecticRondResultatDS.EclecticRondResultat.Rows)
                {
                    eclecticRondResultat.Add(new EclecticRondResultat()
                    {
                        RondID = rad.RondID,
                        SpelarID = rad.SpelarID,
                        HalNr = rad.HalNr,
                        AntalSlag_Brutto = rad.AntalSlag_Brutto,
                        AntalSlag_Netto = rad.AntalSlag_Netto,
                        AntalPoang = rad.AntalPoang,
                        RondDatum = rad.RondDatum
                    });
                }
            }
            return eclecticRondResultat;
        }

        /// <summary>
        /// Hämtar alla poster i tabellen EclecticRondResultat för en rond
        /// </summary>
        /// <param name="rondID">Aktuell Rond</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public List<EclecticRondResultat> HämtaEclecticRondResultat(int rondID)
        {
            EclecticRondResultatData eclecticRondResultatData = new EclecticRondResultatData();
            EclecticRondResultatDS eclecticRondResultatDS = eclecticRondResultatData.HämtaEclecticRondResultat(rondID);
            List<EclecticRondResultat> eclecticRondResultat = null;

            if (eclecticRondResultatDS.EclecticRondResultat.Rows.Count > 0)
            {
                eclecticRondResultat = new List<EclecticRondResultat>(eclecticRondResultatDS.EclecticRondResultat.Rows.Count);
                foreach (EclecticRondResultatDS.EclecticRondResultatRow rad in eclecticRondResultatDS.EclecticRondResultat.Rows)
                {
                    eclecticRondResultat.Add(new EclecticRondResultat()
                    {
                        RondID = rad.RondID,
                        SpelarID = rad.SpelarID,
                        HalNr = rad.HalNr,
                        AntalSlag_Brutto = rad.AntalSlag_Brutto,
                        AntalSlag_Netto = rad.AntalSlag_Netto,
                        AntalPoang = rad.AntalPoang,
                        RondDatum = rad.RondDatum
                    });
                }
            }
            return eclecticRondResultat;
        }

        /// <summary>
        /// Skapa en resultatlista från tabellen EclecticRondResultat
        /// </summary>
        /// <param name="rondID">Aktuell Rond</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public List<EclecticResultatlista> SkapaResultatlista(int rondID)
        {
            DataSet resultatlistaDS = new DataSet();
            EclecticRondResultatData eclecticRondResultatData = new EclecticRondResultatData();
            List<EclecticResultatlista> resultatlista = new List<EclecticResultatlista>();
            resultatlistaDS = eclecticRondResultatData.SkapaResultatlista(rondID);

            if (resultatlistaDS.Tables["Resultatlista"].Rows.Count > 0)
            {
                resultatlista = new List<EclecticResultatlista>(resultatlistaDS.Tables["Resultatlista"].Rows.Count);
                foreach (DataRow rad in resultatlistaDS.Tables["Resultatlista"].Rows)
                {
                    resultatlista.Add(new EclecticResultatlista()
                    {
                        Placering = Convert.ToInt32(rad["Placering"]),
                        RondID = (int)rad["RondID"],
                        BanaNr = (int)rad["BanaNr"],
                        BanaNamn = rad["BanaNamn"].ToString(),
                        SpelarID = (int)rad["SpelarID"],
                        Namn = rad["Namn"].ToString(),
                        Exakthcp = rad["Exakthcp"].ToString(),
                        ErhallnaSlag = (int)rad["ErhallnaSlag"],
                        AntalPoang_Totalt= Convert.ToInt32(rad["PoangTotalt"]),
                        AntalPoang_Ut = Convert.ToInt32(rad["PoangUt"]),
                        AntalPoang_In = Convert.ToInt32(rad["PoangIn"])
                    });
                }
            }
            return resultatlista;
        }

        /// <summary>
        /// Spara i tabellen EclecticRondResultat för en spelare och ett tillfälle
        /// </summary>
        /// <param name="EclecticRondResultat">Aktuellt objekt</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void Spara(List<EclecticRondResultat> eclecticRondResultat, ref string felID, ref string feltext)
        {
            int resultat = 0;
            EclecticRondResultatData eclecticRondResultatData = new EclecticRondResultatData();
            List<EclecticRondResultat> eclecticRondResultatOld = new List<EclecticRondResultat>();

            //För uppdatering av förändrade värden
            eclecticRondResultatOld = this.HämtaEclecticRondResultat(eclecticRondResultat[0].RondID, eclecticRondResultat[0].SpelarID);

            if (eclecticRondResultatOld.Count > 0)
            {
                eclecticRondResultatData.UppdateraRondResultat(eclecticRondResultat, eclecticRondResultatOld, ref felID, ref feltext);
                //eclecticRondResultatData.SparaEclecticRondResultat(eclecticRondResultat, ref felID, ref feltext);
            }
            else
            {
                eclecticRondResultatData.SparaNyEclecticRondResultat(eclecticRondResultat, ref felID, ref feltext);
            }
        }
    }
}
