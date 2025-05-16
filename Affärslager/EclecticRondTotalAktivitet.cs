using Hooker.Affärsobjekt;
using Hooker.Datalager;
using Hooker.Dataset;
using System.Collections.Generic;

namespace Hooker.Affärslager
{
    /// <summary>
    /// Affärslagerklass för EclecticRondTotal
    /// 
    /// Innehåller alla metoder för klassen EclecticRondTotals verksamhetslogik.
    /// </summary>
    public sealed class EclecticRondTotalAktivitet
    {
        /// <summary>
        /// Hämtar en listpost i tabellen EclecticRondTotal
        /// </summary>
        /// <param name="totalID">Aktuell total</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public List<EclecticRondTotal> HämtaEclecticRondTotal(int totalID, int spelarID)
        {
            EclecticRondTotalData eclecticRondTotalData = new EclecticRondTotalData();
            EclecticRondTotalDS eclecticRondTotalDS = eclecticRondTotalData.HämtaEclecticRondTotal(totalID, spelarID);
            List<EclecticRondTotal> eclecticRondTotals = null;

            if (eclecticRondTotalDS.EclecticRondTotal.Rows.Count > 0)
            {
                eclecticRondTotals = new List<EclecticRondTotal>(eclecticRondTotalDS.EclecticRondTotal.Rows.Count);
                foreach (EclecticRondTotalDS.EclecticRondTotalRow rad in eclecticRondTotalDS.EclecticRondTotal.Rows)
                {
                    eclecticRondTotals.Add(new EclecticRondTotal()
                    {
                        TotalID = rad.TotalID,
                        SpelarID = rad.SpelarID,
                        HalNr = rad.HalNr,
                        AntalSlag = rad.AntalSlag,
                        AntalPoang = rad.AntalPoang,
                        RondTotalUppdatDatum = rad.RondTotalUppdatDatum
                    });
                }
            }
            return eclecticRondTotals;
        }

        /// <summary>
        /// Hämta resultatlistan för aktuell tävling och rond
        /// </summary>
        /// <param name="Eclectic">Eclecticobjekt</param>
        /// <param name="Rondtotal">A</param>
        /// <returns></returns>
        public void HämtaResultatlista(Eclectic eclectic, int TotalID)
        {
            EclecticRondTotalData eclecticRondTotalData = new EclecticRondTotalData();
            //EclecticResultatLista eclecticResultat = null;

            ////Fältet Spelform i Tavlingklass anger om slag eller poäng ska räknas. 
            ////Spelform "SG" och "ST" är slagspelformer
            //bool slag = false;
            //string spelform = "";
            //int antalKlasser = tavling.AntalTavlingKlass();

            //if (antalKlasser > 0)
            //{
            //    for (int i = 0; i < tavling.TavlingKlass.Length; i++)
            //    {
            //        if (tavling.TavlingKlass[i].Klass == klass)
            //        {
            //            spelform = tavling.TavlingKlass[i].Spelform.Trim();
            //        }
            //    }

            //    if (spelform.Equals("SG") || spelform.Equals("ST"))
            //    {
            //        slag = true;
            //    }
            //}

            //DataSet resultatlistaDS = tavlingRondResultatData.HämtaResultatlista(tavling.TavlingID, klass, rondNr, slag);

            //if (resultatlistaDS.Tables[0].Rows.Count > 0)
            //{
            //    //tavlingResultatLista = new List<TavlingResultatLista>(resultatlistaDS.Tables[0].Rows.Count);
            //    foreach (DataRow rad in resultatlistaDS.Tables[0].Rows)
            //    {
            //        tavlingResultatLista = new TavlingResultatLista();
            //        tavlingResultatLista.SpelarID = (int)rad["SpelarID"];
            //        tavlingResultatLista.RondID = (int)rad["RondID"];
            //        tavlingResultatLista.RondNr = (int)rad["RondNr"];
            //        tavlingResultatLista.Klass = rad["Klass"].ToString();
            //        tavlingResultatLista.Spelarnamn = rad["Spelarnamn"].ToString();
            //        tavlingResultatLista.Hemmaklubb = rad["Hemmaklubb"].ToString();
            //        tavlingResultatLista.SpelHcp = (int)rad["ErhallnaSlag"];
            //        tavlingResultatLista.RondResultatUt = Convert.ToInt32(rad["RondResultatUt"]);
            //        tavlingResultatLista.RondResultatIn = Convert.ToInt32(rad["RondResultatIn"]);
            //        tavlingResultatLista.RondResultatTot = Convert.ToInt32(rad["RondResultatTot"]);
            //        tavlingResultatLista.TotalResultat = Convert.ToInt32(rad["TotalResultat"]);
            //        tavling.AddTavlingResultatLista(tavlingResultatLista);
            //    }
            //}
            //return tavlingResultatLista;
        }

        /// <summary>
        /// Spara i tabellen EclecticRondTotal för en spelare och eclectic
        /// </summary>
        /// <param name="EclecticTotal">Aktuellt objekt</param>
        /// <param name="TotalID">Aktuellt TotalID</param>
        /// <param name="spelarID">Aktuellt SpelarID</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void Spara(EclecticTotal eclectic, int totalID, int spelarID, ref string felID, ref string feltext)
        {
            EclecticRondTotalData eclecticRondTotalData = new EclecticRondTotalData();
            EclecticRondTotalDS eclecticRondTotalDS;

            //foreach (TavlingRondResultat tavlingRondResultat in tavling.TavlingRondResultat)
            //{
            //    tavlingRondResultatDS = tavlingRondResultatData.HämtaTavlingRondResultat(tavlingRondResultat.RondId,
            //        tavlingRondResultat.SpelarID, tavlingRondResultat.HalNr);

            //    if (tavlingRondResultatDS.TavlingRondResultat.Count > 0)
            //    {
            //        tavlingRondResultatData.SparaTavlingRondResultat(tavlingRondResultat, ref felID, ref feltext);
            //    }
            //    else
            //    {
            //        tavlingRondResultatData.InitieraTavlingRondResultat(tavlingRondResultat, ref felID, ref feltext);
            //    }
            //}
        }
    }
}
