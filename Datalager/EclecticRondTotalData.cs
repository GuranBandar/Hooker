using GemensamService;
using Hooker.Affärsobjekt;
using Hooker.Dataset;
using Hooker.Gemensam;
using System;
using System.Collections.Generic;

namespace Hooker.Datalager
{
    /// <summary>
    /// Datalagerklass för EclecticRondTotal
    /// </summary>
    public sealed class EclecticRondTotalData : AbstractDataLager
    {
        /// <summary>
        /// Hämtar rad från tabellen EclecticRondTotal i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="TotalID">Aktuell EclecticTotal</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticRondTotalDS HämtaEclecticRondTotal(int TotalID)
        {
            EclecticRondTotalDS ds = new EclecticRondTotalDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticRondTotal e WHERE e.TotalID = @TotalID";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TotalID", DataTyp.Int, TotalID.ToString())
                };
                
                DatabasAccess.FyllEnkeltDataSet(sql, dbParameters, ds);
                return ds;
            }
            catch (HookerException hex)
            {
                throw hex;
            }
            finally
            {
                if (DatabasAccess != null)
                {
                    DatabasAccess.Dispose();
                }
            }
        }

        /// <summary>
        /// Hämtar rad från tabellen EclecticRondTotal i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="TotalID">Aktuell EclecticTotal</param>
        /// <param name="SpelarID">Aktuell spelare</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticRondTotalDS HämtaEclecticRondTotal(int totalID, int spelarID, int halNr)
        {
            EclecticRondTotalDS ds = new EclecticRondTotalDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticRondTotal e WHERE e.TotalID = @TotalID " +
                    "AND e.SpelarID = @SpelarID AND e.HalNr = @HalNr";
                
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TotalID", DataTyp.Int, totalID.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, spelarID.ToString()),
                    new DatabasParameters("@HalNr", DataTyp.Int, halNr.ToString())
                };
                
                DatabasAccess.FyllEnkeltDataSet(sql, dbParameters, ds);
                return ds;
            }
            catch (HookerException hex)
            {
                throw hex;
            }
            finally
            {
                if (DatabasAccess != null)
                {
                    DatabasAccess.Dispose();
                }
            }
        }

        /// <summary>
        /// Hämtar rad från tabellen EclecticRondTotal i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="TotalID">Aktuell EclecticTotal</param>
        /// <param name="SpelarID">Aktuell spelare</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticRondTotalDS HämtaEclecticRondTotal(int totalID, int spelarID)
        {
            EclecticRondTotalDS ds = new EclecticRondTotalDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticRondTotal e WHERE e.TotalID = @TotalID " +
                    "AND e.SpelarID = @SpelarID";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TotalID", DataTyp.Int, totalID.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, spelarID.ToString())
                };

                DatabasAccess.FyllEnkeltDataSet(sql, dbParameters, ds);
                return ds;
            }
            catch (HookerException hex)
            {
                throw hex;
            }
            finally
            {
                if (DatabasAccess != null)
                {
                    DatabasAccess.Dispose();
                }
            }
        }

        /// <summary>
        /// Ny EclecticRondTotal.
        /// </summary>
        /// <param name="EclecticTotal">EclecticTotal</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaNyEclecticRondTotalAllaHal(List<EclecticRondTotal> eclecticRondTotal, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                for (int i = 0; i < eclecticRondTotal.Count; i++)
                {
                    sql = "INSERT INTO EclecticRondTotal(TotalID, SpelarID, HalNr, AntalSlag_Brutto, AntalSlag_Netto, AntalPoang, " +
                        "RondTotalUppdatDatum) " +
                        "VALUES " +
                        "(@TotalID, @SpelarID, @HalNr, @AntalSlag_Brutto, @AntalSlag_Netto, @AntalPoang, @RondTotalUppdatDatum)";

                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@TotalID", DataTyp.Int, eclecticRondTotal[i].TotalID.ToString()),
                        new DatabasParameters("@SpelarID", DataTyp.Int, eclecticRondTotal[i].SpelarID.ToString()),
                        new DatabasParameters("@HalNr", DataTyp.Int, eclecticRondTotal[i].HalNr.ToString()),
                        new DatabasParameters("@AntalSlag_Brutto", DataTyp.Int, eclecticRondTotal[i].AntalSlag_Brutto.ToString()),
                        new DatabasParameters("@AntalSlag_Netto", DataTyp.Int, eclecticRondTotal[i].AntalSlag_Netto.ToString()),
                        new DatabasParameters("@AntalPoang", DataTyp.Int, eclecticRondTotal[i].AntalPoang.ToString()),
                        new DatabasParameters("@RondTotalUppdatDatum", DataTyp.VarChar, eclecticRondTotal[i].RondTotalUppdatDatum.ToString())
                    };
                    DatabasAccess.RunSql(sql, dbParameters);
                }
                DatabasAccess.BekräftaTransaktion();
            }
            catch (HookerException hex)
            {
                felID = "SQLERROR";
                feltext = hex.Message.ToString();
                if (DatabasAccess.HarAktivTransaktion())
                {
                    DatabasAccess.ÅngraTransaktion();
                }
                throw hex;
            }
            catch (Exception ex)
            {
                if (DatabasAccess.HarAktivTransaktion())
                {
                    DatabasAccess.ÅngraTransaktion();
                }
                throw ex;
            }
            finally
            {
                if (DatabasAccess != null)
                {
                    DatabasAccess.Dispose();
                }
            }
        }

        /// <summary>
        /// Ny EclecticRondTotal.
        /// </summary>
        /// <param name="EclecticTotal">EclecticTotal</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaEclecticRondTotal(EclecticTotal eclecticTotal, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();

                for (int i = 0; i < eclecticTotal.eclecticRondTotals.Length; i++)
                {
                    sql = "UPDATE EclecticRondTotal " +
                        "SET HalNr = @HalNr, AntalSlag_Brutto = @AntalSlag_Brutto, AntalSlag_Netto = @AntalSlag_Netto, AntalPoang = @AntalPoang, " +
                        "TotalUppdatDatum = @TotalUppdatDatum " +
                        "WEHERE TotalID = @TotalID AND SpelarID = @SpelarID";

                      List < DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@TotalID", DataTyp.Int, eclecticTotal.TotalID.ToString()),
                        new DatabasParameters("@SpelarID", DataTyp.Int, eclecticTotal.SpelarID.ToString()),
                        new DatabasParameters("@HalNr", DataTyp.Int, eclecticTotal.eclecticRondTotals[i].HalNr.ToString()),
                        new DatabasParameters("@AntalSlag_Brutto", DataTyp.Int, eclecticTotal.eclecticRondTotals[i].AntalSlag_Brutto.ToString()),
                        new DatabasParameters("@AntalSlag_Netto", DataTyp.Int, eclecticTotal.eclecticRondTotals[i].AntalSlag_Netto.ToString()),
                        new DatabasParameters("@AntalPoang", DataTyp.Int, eclecticTotal.eclecticRondTotals[i].AntalPoang.ToString()),
                        new DatabasParameters("@TotalUppdatDatum", DataTyp.VarChar, eclecticTotal.eclecticRondTotals[i].RondTotalUppdatDatum.ToString())
                    };
                    DatabasAccess.RunSql(sql, dbParameters);
                }
                DatabasAccess.BekräftaTransaktion();
            }
            catch (HookerException hex)
            {
                felID = "SQLERROR";
                feltext = hex.Message.ToString();
                if (DatabasAccess.HarAktivTransaktion())
                {
                    DatabasAccess.ÅngraTransaktion();
                }
                throw hex;
            }
            catch (Exception ex)
            {
                if (DatabasAccess.HarAktivTransaktion())
                {
                    DatabasAccess.ÅngraTransaktion();
                }
                throw ex;
            }
            finally
            {
                if (DatabasAccess != null)
                {
                    DatabasAccess.Dispose();
                }
            }
        }
    }
}
