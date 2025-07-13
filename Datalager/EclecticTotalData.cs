using GemensamService;
using Hooker.Affärsobjekt;
using Hooker.Dataset;
using Hooker.Gemensam;
using System;
using System.Collections.Generic;

namespace Hooker.Datalager
{
    /// <summary>
    /// Datalagerklass för EclecticTotal
    /// </summary>
    public sealed class EclecticTotalData : AbstractDataLager
    {
        /// <summary>
        /// Hämtar rad från tabellen EclecticTotal i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="eclecticID">Aktuell EclecticTotal</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticTotalDS HämtaEclecticTotal(int eclecticID)
        {
            EclecticTotalDS ds = new EclecticTotalDS();
            string sql;

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@EclecticID", DataTyp.Int, eclecticID.ToString())
                };
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticTotal e WHERE e.EclecticID = @EclecticID";
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
        /// Hämtar rad från tabellen EclecticTotal i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="eclecticID">Aktuell EclecticTotal</param>
        /// <param name="spelarID">Aktuell spelare</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticTotalDS HämtaEclecticTotal(int eclecticID, int spelarID)
        {
            EclecticTotalDS ds = new EclecticTotalDS();
            string sql;

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@EclecticID", DataTyp.Int, eclecticID.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, spelarID.ToString())
                };
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticTotal e WHERE e.EclecticID = @EclecticID " +
                    "AND e.SpelarID = @SpelarID";
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
        /// Ny EclecticTotal.
        /// </summary>
        /// <param name="Eclectic">Eclectic</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaNyEclecticTotal(Eclectic eclectic, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                for (int i = 0; i < eclectic.eclecticTotals.Length; i++)
                {
                    sql = "INSERT INTO EclecticTotal(SpelarID, EclecticID, RondID, ExaktHcp, ErhallnaSlag, " +
                        "Tee, BanaNr, TotalDatum) " +
                        "VALUES " +
                        "(@SpelarID, @EclecticID, @RondID, @ExaktHcp, @ErhallnaSlag, @Tee, @BanaNr, @TotalDatum)";
                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@EclectiCID", DataTyp.Int, eclectic.eclecticTotals[i].EclecticID.ToString()),
                        new DatabasParameters("@SpelarID", DataTyp.Int, eclectic.eclecticTotals[i].SpelarID.ToString()),
                        new DatabasParameters("@ExaktHcp", DataTyp.Decimal, eclectic.eclecticTotals[i].ExaktHcp.ToString()),
                        new DatabasParameters("@ErhallnaSlag", DataTyp.Int, eclectic.eclecticTotals[i].ErhallnaSlag.ToString()),
                        new DatabasParameters("@Tee", DataTyp.Char, eclectic.eclecticTotals[i].Tee.ToString()),
                        new DatabasParameters("@BanaNr", DataTyp.Int, eclectic.eclecticTotals[i].BanaNr.ToString()),
                        new DatabasParameters("@TotalDatum", DataTyp.VarChar, eclectic.eclecticTotals[i].TotalUppdatDatum.ToString())
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
        /// Sparar i EclecticTotal.
        /// </summary>
        /// <param name="eclecticTotal">Eclectic</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaEclecticTotal(EclecticTotal eclecticTotal, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "UPDATE EclecticTotal " +
                    "SET EclecticID = @Eclectic, RondID = @RondID ExaktHcp = @ExaktHcp, ErhallnaSlag = @ErhallnaSlag, " +
                    "Tee = @Tee, BanaNr = @BanaNr, TotalDatum = @TotalDatum, " +
                    "WHERE TotalID = @TotalID AND SpelarID = @SpelarID";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TotalID", DataTyp.Int, eclecticTotal.TotalID.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, eclecticTotal.SpelarID.ToString()),
                    new DatabasParameters("@EclecticID", DataTyp.Int, eclecticTotal.EclecticID.ToString()),
                    new DatabasParameters("@RondID", DataTyp.Int, eclecticTotal.RondID.ToString()),
                    new DatabasParameters("@ExaktHcp", DataTyp.Decimal, eclecticTotal.ExaktHcp.ToString()),
                    new DatabasParameters("@ErhallnaSlag", DataTyp.Int, eclecticTotal.ErhallnaSlag.ToString()),
                    new DatabasParameters("@Tee", DataTyp.Char, eclecticTotal.Tee.ToString()),
                    new DatabasParameters("@BanaNr", DataTyp.Int, eclecticTotal.BanaNr.ToString()),
                    new DatabasParameters("@TotalDatum", DataTyp.VarChar, eclecticTotal.TotalUppdatDatum.ToString())
                };
                
                DatabasAccess.RunSql(sql, dbParameters);
                DatabasAccess.BekräftaTransaktion();
            }
            catch (HookerException hex)
            {
                felID = "SQLERROR";
                feltext = hex.Message.ToString();
                DatabasAccess.ÅngraTransaktion();
                throw hex;
            }
            catch (Exception ex)
            {
                DatabasAccess.ÅngraTransaktion();
                throw ex;
            }
            finally
            {
                DatabasAccess.Dispose();
            }
        }
    }
}
