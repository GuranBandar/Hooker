using GemensamService;
using Hooker.Affärsobjekt;
using Hooker.Dataset;
using Hooker.Gemensam;
using System;
using System.Collections.Generic;
using System.Data;

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
        public EclecticRondTotalDS HämtaEclecticRondTotal(int TotalID, int SpelarID)
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
                    new DatabasParameters("@TotalID", DataTyp.Int, TotalID.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, SpelarID.ToString())
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
        public void SparaNyEclecticRondTotal(EclecticTotal eclecticTotal, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                for (int i = 0; i < eclecticTotal.eclecticRondTotals.Length; i++)
                {
                    sql = "INSERT INTO EclecticRondTotal(TotalID, SpelarID, HalNr, AntalSlag, AntalPoang, " +
                        "RondTotalUppdatDatum) " +
                        "VALUES " +
                        "(@TotalID, @SpelarID, @HalNr, @AntalSlag, @AntalPoang, @RondTotalUppdatDatum)";

                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@TotalID", DataTyp.Int, eclecticTotal.eclecticRondTotals[i].TotalID.ToString()),
                        new DatabasParameters("@SpelarID", DataTyp.Int, eclecticTotal.eclecticRondTotals[i].SpelarID.ToString()),
                        new DatabasParameters("@HalNr", DataTyp.Int, eclecticTotal.eclecticRondTotals[i].HalNr.ToString()),
                        new DatabasParameters("@AntalSlag", DataTyp.Int, eclecticTotal.eclecticRondTotals[i].AntalSlag.ToString()),
                        new DatabasParameters("@AntalPoang", DataTyp.Int, eclecticTotal.eclecticRondTotals[i].AntalPoang.ToString()),
                        new DatabasParameters("@RondTotalDatum", DataTyp.VarChar, eclecticTotal.eclecticRondTotals[i].RondTotalUppdatDatum.ToString())
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
                        "SET HalNr = @HalNr, AntalSlag = @AntalSlag, AntalPoang = @AntalPoang, " +
                        "TotalUppdatDatum = @TotalUppdatDatum " +
                        "WEHERE TotalID = @TotalID AND SpelarID = @SpelarID";

                      List < DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@TotalID", DataTyp.Int, eclecticTotal.TotalID.ToString()),
                        new DatabasParameters("@SpelarID", DataTyp.Int, eclecticTotal.SpelarID.ToString()),
                        new DatabasParameters("@HalNr", DataTyp.Int, eclecticTotal.eclecticRondTotals[i].HalNr.ToString()),
                        new DatabasParameters("@AntalSlag", DataTyp.Int, eclecticTotal.eclecticRondTotals[i].AntalSlag.ToString()),
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
