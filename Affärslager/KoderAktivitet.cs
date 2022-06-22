using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Hooker.Affärsobjekt;
using Hooker.Datalager;
using Hooker.Dataset;
using Hooker.Gemensam;

namespace Hooker.Affärslager
{
    /// <summary>
    /// Affärsklass för Koder
    /// 
    /// Innehåller alla metoder för klassen Koders verksamhetslogik.
    /// </summary>
    public sealed class KoderAktivitet : SökVillkor
    {

        /// <summary>
        ///     Skapar söksträng för sök i databasen, anropar sök och sätter värden för
        ///     aktuella Koder i klassen.
        /// </summary>
        /// <param name="typ">Del av nyckel till Koder som ska hämtas</param>
        /// <param name="argument">Del av nyckel till Koder som ska hämtas</param>
        /// <returns>Typat dataset med Koder</returns>
        public List<Koder> SökKoder(string typ, string argument)
        {
            KoderAktivitet koderAktitivtet = new KoderAktivitet();
            List<Koder> koder = koderAktitivtet.SökKoder(Convert.ToInt32(typ), argument, "Argument");
            return koder;
        }

        /// <summary>
        ///     Skapar söksträng för sök i databasen, anropar sök och sätter värden för
        ///     aktuella Koder i klassen.
        /// </summary>
        /// <param name="kod">Del av nyckel till Koder som ska hämtas</param>
        /// <param name="argument">Del av nyckel till Koder som ska hämtas</param>
        /// <returns>Typat dataset med Koder</returns>
        public List<Koder> SökKoder(int kod, string argument)
        {
            KoderAktivitet koderAktivitet = new KoderAktivitet();
            List<Koder> koder = koderAktivitet.SökKoder(kod, argument, "Argument");
            return koder;
        }

        /// <summary>
        ///     Skapar söksträng för sök i databasen, anropar sök och sätter värden för
        ///     aktuella Koder i klassen.
        /// </summary>
        /// <param name="typ">Del av nyckel till Koder som ska hämtas</param>
        /// <param name="argument">Del av nyckel till Koder som ska hämtas</param>
        /// <param name="sortering">Ev kolumn resultatet ska sorteras på</param>
        /// <returns>Dataset med Koder</returns>
        public List<Koder> SökKoder(int typ, string argument, string sortering)
        {
            KoderDS koderDS = new KoderDS();
            KoderData koderData = new KoderData();
            List<Koder> koder = null;
            string sqlSök = "";
            string sql = "";
            short argRäknare;

            try
            {
                argRäknare = 0;

                if (!string.IsNullOrEmpty(typ.ToString()))
                { //  om typ angivits
                    WhereFörInteger(typ, "typ ", ref sqlSök, ref argRäknare, "= ");
                }

                if (!string.IsNullOrEmpty(argument))
                { //  om argument angivits, % efter

                    WhereMedLikeEfter(argument, "argument ", ref sqlSök, ref argRäknare);
                }

                // Om inga argument finns så ska inte "WHERE" vara med i select satsen
                if (argRäknare > 0)
                {
                    sql = sql + " WHERE " + sqlSök;
                }

                //  så lite sql-kod för sorteringen
                sql = sql + " ORDER BY Typ";

                if (!string.IsNullOrEmpty(sortering))
                {
                    sql = sql + ", " + sortering;
                }

                koderDS = koderData.SökKoder(sql);
                koder = new List<Koder>(koderDS.Koder.Rows.Count);
                foreach (KoderDS.KoderRow rad in koderDS.Koder.Rows)
                {
                    koder.Add(new Koder()
                    {
                        Typ = rad.Typ,
                        Argument = rad.Argument,
                        Varde = rad.Varde,
                        IntervallMin = rad.IntervallMin,
                        IntervallMax = rad.IntervallMax,
                        UppdatDatum = rad.UppdatDatum
                    });
                }
                return koder;
            }
            catch (HookerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new HookerException(ex.Message, ex);
            }
        }

        /// <summary>
        ///     Hämtar koder för angiven Typ och Argument
        /// </summary>
        /// <param name="typ">Del av nyckel</param>
        /// <param name="argument">Del av nyckel</param>
        /// <returns>Typat dataset med önskade uppgifter</returns>
        public Koder HämtaKoder(string typ, string argument)
        {
            Koder koder = this.HämtaKoder(Convert.ToInt32(typ), argument);
            return koder;
        }

        /// <summary>
        ///     Hämtar koder för angiven Typ och Argument
        /// </summary>
        /// <param name="typ">Del av nyckel</param>
        /// <param name="argument">Del av nyckel</param>
        /// <returns>Typat dataset med önskade uppgifter</returns>
        public Koder HämtaKoder(int typ, string argument)
        {
            KoderData koderData = new KoderData();
            KoderDS koderDS = koderData.HämtaKoder(typ, argument);
            Koder koder = null;

            if (koderDS.Koder.Count == 1)
            {
                koder = new Koder();
                koder.Typ = koderDS.Koder[0].Typ;
                koder.Argument = koderDS.Koder[0].Argument;
                koder.Varde = koderDS.Koder[0].Varde;
                koder.IntervallMin = koderDS.Koder[0].IntervallMin;
                koder.IntervallMax = koderDS.Koder[0].IntervallMax;
                koder.UppdatDatum = koderDS.Koder[0].UppdatDatum;
            }
            return koder;
        }

        /// <summary>
        ///     Hämtar max Argument för angiven typ
        /// </summary>
        /// <param name="typ">Typ</param>
        /// <param name="argument">Argument</param>
        /// <returns>Dataset med Max Argument</returns>
        private string HämtaMaxArgument(int typ, string argument)
        {
            DataSet koderDS = new DataSet();
            KoderData koderData = new KoderData();
            string sqlSök = "";
            string sql = "";
            short argRäknare = 0;
            string nästaVärde;
            Kodtabell kod;

            try
            {
                kod = (Kodtabell)typ;
                WhereFörInteger(typ.ToString(), "Typ ", ref sqlSök, ref argRäknare, "= ");

                if (!string.IsNullOrEmpty(argument))
                { //  om argument angivits, % efter
                    WhereMedLikeEfter(argument, "Argument", ref sqlSök, ref argRäknare);
                }

                // Om inga argument finns så ska inte "WHERE" vara med i select satsen
                if (argRäknare > 0)
                {
                    sql = sql + " WHERE " + sqlSök;
                }

                // Lite special för Distrikt är det, argumentet inleds ju med landkoden (två första tecken)
                if (kod == Kodtabell.Distrikt)
                {
                    sql = sql + " ORDER BY Argument DESC";
                }

                koderDS = koderData.HämtaMaxArgument(kod, sql);
                
                if (koderDS.Tables[0].Rows.Count > 0)
                {
                    if (kod == Kodtabell.Distrikt)
                    {
                        nästaVärde = (int.Parse(koderDS.Tables[0].Rows[0]["Max"].ToString().Substring(2, 2))
                            + 1).ToString();

                        if (nästaVärde.Length == 1)
                        {
                            nästaVärde = argument + "0" + nästaVärde;
                        }
                        else
                        {
                            nästaVärde = argument + nästaVärde;
                        }
                    }
                    else
                    {
                        nästaVärde = (int.Parse(koderDS.Tables[0].Rows[0]["Max"].ToString()) + 1).ToString();
                    }
                }
                else if (koderDS.Tables[0].Rows.Count == 0)
                {
                    if (kod == Kodtabell.Distrikt)
                    {
                        nästaVärde = argument + "01";
                    }
                    else
                    {
                        nästaVärde = "1";
                    }
                }
                else
                {
                    throw new HookerException();
                }
                return nästaVärde;
            }
            catch (HookerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new HookerException(ex.Message, ex);
            }
        }

        /// <summary>
        ///     Sparar Koder
        /// </summary>
        /// <param name="koder">Objekt med Koder som ska sparas</param>
        /// <param name="nyKod">Ny kod, true eller false </param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void Spara(Koder koder, bool nyKod, ref string felID, ref string feltext)
        {
            KoderData koderData = new KoderData();
            bool kollaOK = false;
            kollaOK = Kolla(koder, nyKod, ref felID, ref feltext);

            if (kollaOK)
            {
                if (nyKod)
                {
                    if (koder.Typ == (int)Kodtabell.Distrikt)
                    {
                        koder.Argument = HämtaMaxArgument(koder.Typ,
                            koder.Argument.Trim().ToString());
                    }
                    koderData.SparaNyKod(koder, ref felID, ref feltext);
                }
                else
                {
                    koderData.SparaKoder(koder, ref felID, ref feltext);
                }
            }
            else
            {
                throw new HookerException();
            }
        }

        /// <summary>
        /// Ta bort Koder i databasen 
        /// </summary>
        /// <param name="koder">Aktuell kod</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBort(Koder koder, ref string felID, ref string feltext)
        {
            KoderData koderData = new KoderData();
            koderData.TaBortKod(koder, ref felID, ref feltext);
        }

        /// <summary>
        ///     Metoden kollar informationen innan uppdatering ska göras
        /// </summary>
        /// <param name="koder">Object med informationen som ska kollas</param>
        /// <param name="nyKod">Ny kod, true eller false </param>
        /// <param name="felID">Ev felID som returneras</param>
        /// <param name="feltext">Ev felmeddelande som returneras</param>
        private bool Kolla(Koder koder, bool nyKod, ref string felID, ref string feltext)
        {
            Koder kod;

            //Om Typ = 1 (Distrikt) ska de två första i Argument vara en giltig Landkod
            if (koder.Typ == (int)Kodtabell.Distrikt)
            {
                kod = HämtaKoder((int)Kodtabell.Land, koder.Argument.Substring(0, 2));
                if (kod == null)
                {
                    felID = "KODARGMISSING";
                    feltext = "";
                    return false;
                }
            }

            if (nyKod)
            {
                kod = HämtaKoder(koder.Typ, koder.Argument);
                if (kod != null)
                {
                    felID = "KODEXISTS";
                    feltext = "";
                    return false;
                }
            }
            return true;
        }
    }
}
