using Hooker.Affärsobjekt;
using Hooker.Dataset;
using Hooker.Gemensam;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hooker.Affärslager
{
    /// <summary>
    ///     Klass för Runda
    /// 
    ///     Innehåller alla metoder för klassen Rundas verksamhetslogik.
    /// </summary>
    public sealed class RundaAktivitet : SökVillkor
    {
        /// <summary>
        ///     Kolla hur många rundor som finns registrerad på aktuell bana
        /// </summary>
        /// <param name="banaNr">Aktuell banaNr</param>
        /// <returns>Antalet registrerade rundor på banan</returns>
        public int KollaAntaletRundor(int banaNr)
        {
            RundaDS rundaDS = new RundaDS();
            Datalager.RundaData rundaData = new Datalager.RundaData();
            rundaDS = rundaData.KollaAntaletRundor(banaNr);
            return rundaDS.Runda.Count;
        }

        /// <summary>
        ///     Kolla hur många rundor som finns registrerad på aktuell spelare
        /// </summary>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <returns>Antalet registrerade rundor på spelaren</returns>
        public int KollaAntaletRundorForSpelare(int spelarID)
        {
            RundaDS rundaDS = new RundaDS();
            Datalager.RundaData rundaData = new Datalager.RundaData();
            rundaDS = rundaData.KollaAntaletRundorForSpelare(spelarID);
            return rundaDS.Runda.Count;
        }

        /// <summary>
        /// Hämtar högsta nummer för Runda
        /// </summary>
        /// <returns>Dataset med kolumn för högsta nr i Runda</returns>
        private int HämtaMaxRundaNr()
        {
            DataSet rundaDS = new DataSet();
            Datalager.RundaData rundaData = new Datalager.RundaData();
            rundaDS = rundaData.HämtaMaxRundaNr();
            return (int)rundaDS.Tables["Runda"].Rows[0]["Max"];
        }

        /// <summary>
        /// Hämtar rad från tabellen Runda i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="rundaNr">Aktuell Runda</param>
        /// <returns>Objekt med efterfrågat data</returns>
        public Runda HämtaRunda(int rundaNr)
        {
            RundaDS rundaDS = new RundaDS();
            Datalager.RundaData rundaData = new Datalager.RundaData();
            Runda runda = null;

            try
            {
                rundaDS = rundaData.HämtaRunda(rundaNr);

                if (rundaDS.Runda.Count == 1)
                {
                    //Skapa Rundaobjektet
                    runda = new Runda();
                    runda.BanaNr = rundaDS.Runda[0].BanaNr;
                    runda.Datum = rundaDS.Runda[0].Datum;
                    runda.ErhallnaSlag = rundaDS.Runda[0].ErhallnaSlag;
                    runda.ExaktHcp = rundaDS.Runda[0].ExaktHcp;
                    runda.Hcprond = rundaDS.Runda[0].Hcprond;
                    runda.Notering = (rundaDS.Runda[0].IsNoteringNull()) ? string.Empty : rundaDS.Runda[0].Notering;
                    runda.Sallskapsrond = rundaDS.Runda[0].Sallskapsrond;
                    runda.SpelarID = rundaDS.Runda[0].SpelarID;
                    runda.Tavlingsrond = rundaDS.Runda[0].Tavlingsrond;
                    runda.Tee = rundaDS.Runda[0].Tee;
                    runda.Markor = (rundaDS.Runda[0].IsMarkorNull()) ? 0 : rundaDS.Runda[0].Markor;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return runda;

        }

        /// <summary>
        ///     Söker rad/-er från tabellen Runda i aktuell databas med angivet sökvillkor.
        /// </summary>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <param name="bananr">Bananr</param>
        /// <param name="fromDatum">Ev from datum</param>
        /// <param name="tomdatum">Ev tom datum</param>
        /// <param name="tavlingsrond">Ev markering för tävlingsrond</param>
        /// <param name="sallskapsrond">Ev markering för sällskapsrond</param>
        /// <param name="hcprond">Ev markering för hcprond</param>
        /// <param name="niohalsrond">Ev markering för niohålsrond</param>
        /// <returns>Otypat dataset med efterfrågat data</returns>
        public List<Runda> SökRunda(string spelarID, string bananr, DateTime fromDatum, DateTime tomdatum,
            bool tavlingsrond, bool sallskapsrond, bool hcprond, bool niohalsrond)
        {
            DataSet rundaDS = new DataSet();
            Datalager.RundaData rundaData = new Datalager.RundaData();
            List<Runda> runda = null;
            short antArgument = 0;
            string sqlSok = "";
            string sql = "";
            try
            {
                if (fromDatum.ToString() != "")
                {
                    WhereFörSträng(fromDatum.ToString(), "r.Datum", ref sqlSok, ref antArgument, " > ");
                }

                if (tomdatum.ToString() != "")
                {
                    WhereFörSträng(tomdatum.ToString(), "r.Datum", ref sqlSok, ref antArgument, " < ");
                }

                if (bananr.ToString() != "")
                {
                    WhereFörInteger(bananr, "b.BanaNr", ref sqlSok, ref antArgument, " = ");
                }

                if (spelarID.ToString() != "")
                {
                    WhereFörInteger(spelarID, "r.SpelarID", ref sqlSok, ref antArgument, " = ");
                }

                if (tavlingsrond)
                {
                    WhereFörSträng("X", "Tavlingsrond", ref sqlSok, ref antArgument, " = ");
                }

                if (sallskapsrond)
                {
                    WhereFörSträng("X", "Sallskapsrond", ref sqlSok, ref antArgument, " = ");
                }

                if (hcprond)
                {
                    WhereFörSträng("X", "Hcprond", ref sqlSok, ref antArgument, " = ");
                }

                if (niohalsrond)
                {
                    WhereFörSträng("X", "Niohalsrond", ref sqlSok, ref antArgument, " = ");
                }

                if (antArgument > 0)
                {
                    sql = sql + " WHERE " + sqlSok;
                }

                rundaDS = rundaData.SökRunda(sql);

                if (rundaDS.Tables["Runda"].Rows.Count > 0)
                {
                    //Skapa rundaobjekten
                    runda = new List<Runda>(rundaDS.Tables["Runda"].Rows.Count);
                    foreach (DataRow rad in rundaDS.Tables["Runda"].Rows)
                    {
                        runda.Add(new Runda()
                        {
                            RundaNr = (int)rad["RundaNr"],
                            Datum = (DateTime)rad["Datum"],
                            SpelarID = (int)rad["SpelarID"],
                            BanaNr = (int)rad["BanaNr"],
                            Notering = rad["Notering"].ToString(),
                            SpelareNamn = rad["Spelare"].ToString(),
                            BanaNamn = rad["Bana"].ToString(),
                            Aktuell = rad["Aktuell"].ToString(),
                            SummaAntalPoang = Convert.ToInt32(rad["Poäng"]),
                            SummaAntalSlag = Convert.ToInt32(rad["Slag"])
                        });
                    }
                }
            }
            catch (HookerException)
            {
                throw;
            }
            return runda;
        }

        /// <summary>
        /// Söker rad/-er från tabellen Runda i aktuell databas med angivet sökvillkor.
        /// </summary>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <param name="golfklubbNr">GolfklubbNr</param>
        /// <param name="fromDatum">Ev from datum</param>
        /// <param name="tomdatum">Ev tom datum</param>
        /// <param name="tavlingsrond">Ev markering för tävlingsrond</param>
        /// <param name="sallskapsrond">Ev markering för sällskapsrond</param>
        /// <param name="hcprond">Ev markering för hcprond</param>
        /// <param name="niohalsrond">Ev markering för niohålsrond</param>
        /// <returns>Otypat dataset med efterfrågat data</returns>
        public List<Runda> SökRundaGolfklubb(string spelarID, string golfklubbNr, DateTime fromDatum, DateTime tomdatum,
            bool tavlingsrond, bool sallskapsrond, bool hcprond, bool niohalsrond)
        {
            DataSet rundaDS = new DataSet();
            Datalager.RundaData rundaData = new Datalager.RundaData();
            List<Runda> runda = null;
            short antArgument = 0;
            string sqlSok = "";
            string sql = "";
            try
            {
                if (fromDatum.ToString() != "")
                {
                    WhereFörSträng(fromDatum.ToString(), "r.Datum", ref sqlSok, ref antArgument, " > ");
                }

                if (tomdatum.ToString() != "")
                {
                    WhereFörSträng(tomdatum.ToString(), "r.Datum", ref sqlSok, ref antArgument, " < ");
                }

                if (golfklubbNr.ToString() != "")
                {
                    WhereFörInteger(golfklubbNr, "g.GolfklubbNr", ref sqlSok, ref antArgument, " = ");
                }

                if (spelarID.ToString() != "")
                {
                    WhereFörInteger(spelarID, "r.SpelarID", ref sqlSok, ref antArgument, " = ");
                }

                if (tavlingsrond)
                {
                    WhereFörSträng("X", "Tavlingsrond", ref sqlSok, ref antArgument, " = ");
                }

                if (sallskapsrond)
                {
                    WhereFörSträng("X", "Sallskapsrond", ref sqlSok, ref antArgument, " = ");
                }

                if (hcprond)
                {
                    WhereFörSträng("X", "Hcprond", ref sqlSok, ref antArgument, " = ");
                }

                if (niohalsrond)
                {
                    WhereFörSträng("X", "Niohalsrond", ref sqlSok, ref antArgument, " = ");
                }

                if (antArgument > 0)
                {
                    sql = sql + " WHERE " + sqlSok;
                }

                rundaDS = rundaData.SökRundaGolfklubb(sql);

                if (rundaDS.Tables["Runda"].Rows.Count > 0)
                {
                    //Skapa rundaobjekten
                    runda = new List<Runda>(rundaDS.Tables["Runda"].Rows.Count);
                    foreach (DataRow rad in rundaDS.Tables["Runda"].Rows)
                    {
                        runda.Add(new Runda()
                        {
                            RundaNr = (int)rad["RundaNr"],
                            Datum = (DateTime)rad["Datum"],
                            SpelarID = (int)rad["SpelarID"],
                            BanaNr = (int)rad["BanaNr"],
                            Notering = rad["Notering"].ToString(),
                            SpelareNamn = rad["Spelare"].ToString(),
                            BanaNamn = rad["Bana"].ToString(),
                            Aktuell = rad["Aktuell"].ToString(),
                            SummaAntalPoang = Convert.ToInt32(rad["Poäng"]),
                            SummaAntalSlag = Convert.ToInt32(rad["Slag"])
                        });
                    }
                }
            }
            catch (HookerException)
            {
                throw;
            }
            return runda;
        }

        ///// <summary>
        /////     Hämta Runda, Rundans alla RundaHal samt Redovisning för angivet rundaNr.
        ///// </summary>
        ///// <param name="rundaNr">Rundans nr</param>
        ///// <returns>Ett sammansatt typat dataset med aktuell information</returns>
        //public RundaRundaHalRedovisningSDS HämtaRundaRundaHalRedovisning(int rundaNr)
        //{
        //    RundaRundaHalRedovisningSDS rundaRundaHalRedovisningSDS = new RundaRundaHalRedovisningSDS();
        //    Datalager.RundaData rundaData = new Datalager.RundaData();
        //    rundaRundaHalRedovisningSDS = rundaData.HämtaRundaRundaHalRedovisning(rundaNr);
        //    return rundaRundaHalRedovisningSDS;
        //}


        /// <summary>
        ///     Hämta Runda, Rundans alla RundaHal samt Redovisning för angivet rundaNr.
        /// </summary>
        /// <param name="rundaNr">Rundans nr</param>
        /// <returns>Ett objekt med aktuell information</returns>
        public Runda HämtaRundaRundaHalRedovisning(int rundaNr)
        {
            RundaRundaHalRedovisningSDS rundaRundaHalRedovisningSDS = new RundaRundaHalRedovisningSDS();
            Datalager.RundaData rundaData = new Datalager.RundaData();
            rundaRundaHalRedovisningSDS = rundaData.HämtaRundaRundaHalRedovisning(rundaNr);
            Runda runda = null;
            RundaHal rundaHal = null;
            Redovisning redovisning = null;

            if (rundaRundaHalRedovisningSDS.Runda.Count == 1)
            {
                //Skapa Rundaobjektet
                runda = new Runda();
                runda.RundaNr = rundaRundaHalRedovisningSDS.Runda[0].RundaNr;
                runda.Datum = rundaRundaHalRedovisningSDS.Runda[0].Datum;
                runda.SpelarID = rundaRundaHalRedovisningSDS.Runda[0].SpelarID;
                runda.ExaktHcp = rundaRundaHalRedovisningSDS.Runda[0].ExaktHcp;
                runda.ErhallnaSlag = rundaRundaHalRedovisningSDS.Runda[0].ErhallnaSlag;
                runda.Tee = rundaRundaHalRedovisningSDS.Runda[0].Tee;
                runda.BanaNr = rundaRundaHalRedovisningSDS.Runda[0].BanaNr;
                runda.Tavlingsrond = rundaRundaHalRedovisningSDS.Runda[0].Tavlingsrond;
                runda.Placering = rundaRundaHalRedovisningSDS.Runda[0].Placering;
                runda.Sallskapsrond = rundaRundaHalRedovisningSDS.Runda[0].Sallskapsrond;
                runda.Hcprond = rundaRundaHalRedovisningSDS.Runda[0].Hcprond;
                //Fältet visas inte 
                //runda.Katastrofrond = rundaRundaHalRedovisningSDS.Runda[0].Katastrofrond;
                runda.Notering = rundaRundaHalRedovisningSDS.Runda[0].Notering;
                runda.UppdatDatum = rundaRundaHalRedovisningSDS.Runda[0].UppdatDatum;
                runda.Niohalsrond = rundaRundaHalRedovisningSDS.Runda[0].Niohalsrond;
                runda.Markor = (rundaRundaHalRedovisningSDS.Runda[0].IsMarkorNull()) ?
                    0 : rundaRundaHalRedovisningSDS.Runda[0].Markor;

                foreach (RundaRundaHalRedovisningSDS.RundaHalRow rad in rundaRundaHalRedovisningSDS.RundaHal.Rows)
                {
                    rundaHal = new RundaHal();
                    rundaHal.HalNr = rad.HalNr;
                    rundaHal.AntalSlag = rad.AntalSlag;
                    rundaHal.AntalPoang = rad.AntalPoang;
                    rundaHal.AntalPuttar = rad.AntalPuttar;
                    rundaHal.FwTraff = rad.FwTraff;
                    rundaHal.GrTraff = rad.GrTraff;
                    rundaHal.AntalPlikt = rad.AntalPlikt;
                    runda.AddRundaHal(rundaHal);
                }

                foreach (RundaRundaHalRedovisningSDS.RedovisningRow rad in rundaRundaHalRedovisningSDS.Redovisning.Rows)
                {
                    redovisning = new Redovisning();
                    redovisning.TransNr = rad.TransNr;
                    redovisning.Typ = rad.Typ;
                    redovisning.Datum = rad.Datum;
                    redovisning.RundaNr = rad.RundaNr;
                    redovisning.SpelarID = rad.SpelarID;
                    redovisning.Belopp = rad.Belopp;
                    redovisning.Notering = rad.Notering;
                    runda.AddRedovisning(redovisning);
                }
            }
            return runda;
        }
        /// <summary>
        ///     Metoden kollar informationen innan uppdatering ska göras
        /// </summary>
        /// <param name="runda">Objekt med informationen som ska kollas</param>
        /// <param name="felID">Ev felID som returneras</param>
        /// <param name="felmeddelande">Ev felmeddelande som returneras</param>
        private bool Kolla(Runda runda, ref string felID, ref string felmeddelande)
        {
            int antRondtyper = 0;

            if (runda.SpelarID == 0)
            {
                felID = "RNDSPELAREMISSING";
                felmeddelande = "";
                return false;
            }
            if (runda.BanaNr == 0)
            {
                felID = "RNDBANAMISSING";
                felmeddelande = "";
                return false;
            }

            if (runda.Hcprond == "X")
            {
                antRondtyper++;
            }
            if (runda.Niohalsrond == "X")
            {
                antRondtyper++;
            }
            if (runda.Sallskapsrond == "X")
            {
                antRondtyper++;
            }
            if (runda.Tavlingsrond == "X")
            {
                antRondtyper++;
            }

            //if (antRondtyper == 0 | antRondtyper > 1)
            if (antRondtyper == 0)
            {
                felID = "RNDTYPFEL";
                felmeddelande = "";
                return false;
            }

            //Kolla markering för Tävlingsrond och placering, är den ena angiven ska den andra också anges.
            if (runda.Tavlingsrond == "X" && runda.Placering.ToString().Length == 0)
            {
                felID = "TAVLINGSRONDFEL";
                felmeddelande = "";
                return false;
            }

            if (runda.Placering > 0 & runda.Tavlingsrond == "")
            {
                felID = "TAVLINGSRONDFEL";
                felmeddelande = "";
                return false;
            }
            return true;
        }

        /// <summary>
        ///     Sparar alla förändringar i Runda, RundaHal och Redovisning i databasen 
        /// </summary>
        /// <param name="ds">Aktuellt dataset</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void Spara(DataSet ds, ref string felID, ref string feltext)
        {
            if (ds.HasChanges())
            {
                Datalager.RundaData rundaData = new Datalager.RundaData();
                rundaData.Spara((RundaRundaHalRedovisningSDS.RundaDataTable)ds.Tables["Runda"],
                    (RundaRundaHalRedovisningSDS.RundaHalDataTable)ds.Tables["RundaHal"],
                    (RundaRundaHalRedovisningSDS.RedovisningDataTable)ds.Tables["Redovisning"],
                    ref felID, ref feltext);
            }
        }

        /// <summary>
        /// Sparar alla förändringar i Runda i databasen 
        /// </summary>
        /// <param name="runda">Aktuell runda</param>
        /// <param name="nyRunda">Ny runda, true or false</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void Spara(Runda runda, bool nyRunda, ref string felID, ref string feltext)
        {
            bool kollaOK = false;
            kollaOK = Kolla(runda, ref felID, ref feltext);

            if (kollaOK)
            {
                Datalager.RundaData rundaData = new Datalager.RundaData();
                if (nyRunda)
                {
                    runda.RundaNr = this.HämtaMaxRundaNr() + 1;
                    rundaData.SparaNyRunda(runda, ref felID, ref feltext);
                }
                else
                {
                    rundaData.SparaRunda(runda, ref felID, ref feltext);
                }
            }
            else
            {
                throw new HookerException();
            }
        }

        /// <summary>
        /// Ta bort Runda i databasen 
        /// </summary>
        /// <param name="runda">Aktuell runda</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBort(Runda runda, ref string felID, ref string feltext)
        {
            Datalager.RundaData rundaData = new Datalager.RundaData();
            rundaData.TaBortRunda(runda, ref felID, ref feltext);
        }
    }
}
