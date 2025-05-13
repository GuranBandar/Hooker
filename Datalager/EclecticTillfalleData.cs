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
    /// Datalagerklass för EclecticTillfalle
    /// </summary>
    public sealed class EclecticTillfalleData : AbstractDataLager
    {
        /// <summary>
        /// Hämtar rad från tabellen EclecticTillfalle i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="EclecticID">Aktuell EclecticTotal</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticTillfalleDS HämtaEclecticTillfalle(int TillfalleID)
        {
            EclecticTillfalleDS ds = new EclecticTillfalleDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticTillfalle e WHERE e.TillfalleID = @TillfalleID";
                
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TillfalleID", DataTyp.Int, TillfalleID.ToString())
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
        /// Hämtar rad från tabellen EclecticTillfalle i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="RondID">Aktuell EclecticRond</param>
        /// <param name="TillfalleID">Aktuellt tillfälle</param>
        /// <param name="SpelarID">Aktuell spelare</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticTillfalleDS HämtaEclecticTillfalle(int TillfalleID, int SpelarID, int RondID)
        {
            EclecticTillfalleDS ds = new EclecticTillfalleDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticTillfalle e WHERE e.TillfalleID = @TillfalleID " +
                    "AND e.SpelarID = @SpelarID AND e.RondID = @RondID";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TillfalleID", DataTyp.Int, TillfalleID.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, SpelarID.ToString()),
                    new DatabasParameters("@RondID", DataTyp.Int, RondID.ToString())
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
        /// Hämtar rad från tabellen EclecticTillfallae i aktuell databas med angiven nyckel.
        /// </summary>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public string HämtaMaxEclecticTillfalle()
        {
            DataSet eclecticTillfalleDS = new DataSet();
            string nyttEclecticTillfallaeID = string.Empty;
            string sql;

            try
            {
                sql = "SELECT e.EclecticTillfalleID FROM EclecticTillfallae e " +
                    " ORDER BY e.EclecticTillfallaeID DESC";
                eclecticTillfalleDS = DatabasAccess.RunSql(sql);
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
            nyttEclecticTillfallaeID = eclecticTillfalleDS.Tables[0].Rows[0]["EclecticTillfallaeID"].ToString();
            return nyttEclecticTillfallaeID;
        }

        /// <summary>
        /// Ny EclecticTillfalle.
        /// </summary>
        /// <param name="EclecticTillfalle">EclecticTillfalle</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaNyEclecticTillfalle(EclecticRond eclecticRond, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();

                for (int i = 0; i < eclecticRond.eclecticTillfalles.Length; i++)
                {
                    sql = "INSERT INTO EclecticTillfalle(SpelarID, RondID, ExaktHcp, ErhallnaSlag, " +
                        "Tee, TillfalleDatum, TillfalleUppdatDatum) " +
                        "VALUES " +
                        "(@SpelarID, @RondID, @ExaktHcp,@ErhallnaSlag, @Tee, @TillfalleDatum, " +
                        "@TillfalleUppdatDatum)";
                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@SpelarID", DataTyp.Int, eclecticRond.eclecticTillfalles[i].SpelarID.ToString()),
                        new DatabasParameters("@RondID", DataTyp.Int, eclecticRond.eclecticTillfalles[i].EclecticID.ToString()),
                        new DatabasParameters("@ExaktHcp", DataTyp.Decimal, eclecticRond.eclecticTillfalles[i].ExaktHcp.ToString()),
                        new DatabasParameters("@ErhallnaSlag", DataTyp.Int, eclecticRond.eclecticTillfalles[i].ErhallnaSlag.ToString()),
                        new DatabasParameters("@Tee", DataTyp.Char, eclecticRond.eclecticTillfalles[i].Tee.ToString()),
                        new DatabasParameters("@TillfalleDatum", DataTyp.VarChar, eclecticRond.eclecticTillfalles[i].TillfalleDatum.ToString()),
                        new DatabasParameters("@TillfalleUppdatDatum", DataTyp.VarChar, eclecticRond.eclecticTillfalles[i].TillfalleUppdatDatum.ToString())
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
        /// Spara EclecticTillfalle.
        /// </summary>
        /// <param name="EclecticTillfalle">EclecticTillfalle</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaEclecticTillfalle(EclecticRond eclecticRond, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();

                for (int i = 0; i < eclecticRond.eclecticTillfalles.Length; i++)
                {
                    sql = "UPDATE EclecticTillfalle " +
                        "SET RondID = @RondID, ExaktHcp = @ExaktHcp, " +
                        "ErhallnaSlag = @ErhallnaSlag, Tee = @Tee, TillfalleDatum = @TillfalleDatum, " +
                        "TillfalleUppdatDatum = @TillfalleUppdatDatum " +
                        "WHERE TillfalleID = @TillfalleID AND SpelarID = @SpelarID";
                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@TillfalleID", DataTyp.Int, eclecticRond.eclecticTillfalles[i].TillfalleID.ToString()),
                        new DatabasParameters("@SpelarID", DataTyp.Int, eclecticRond.eclecticTillfalles[i].SpelarID.ToString()),
                        new DatabasParameters("@RondID", DataTyp.Int, eclecticRond.eclecticTillfalles[i].EclecticID.ToString()),
                        new DatabasParameters("@ExaktHcp", DataTyp.Decimal, eclecticRond.eclecticTillfalles[i].ExaktHcp.ToString()),
                        new DatabasParameters("@ErhallnaSlag", DataTyp.Int, eclecticRond.eclecticTillfalles[i].ErhallnaSlag.ToString()),
                        new DatabasParameters("@Tee", DataTyp.Char, eclecticRond.eclecticTillfalles[i].Tee.ToString()),
                        new DatabasParameters("@TillfalleDatum", DataTyp.VarChar, eclecticRond.eclecticTillfalles[i].TillfalleDatum.ToString()),
                        new DatabasParameters("@TillfalleUppdatDatum", DataTyp.VarChar, eclecticRond.eclecticTillfalles[i].TillfalleUppdatDatum.ToString())
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
