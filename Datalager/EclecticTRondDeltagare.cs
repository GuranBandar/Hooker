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
    /// Datalagerklass för EclecticRondDeltagare
    /// </summary>
    public sealed class EclecticRondDeltagareData : AbstractDataLager
    {
        /// <summary>
        /// Hämtar rad från tabellen EclecticRondDeltagare i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="EclecticID">Aktuell EclecticTotal</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticRondDeltagareDS HämtaEclecticRondDeltagare(int RondDeltagarID)
        {
            EclecticRondDeltagareDS ds = new EclecticRondDeltagareDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticRondDeltagare e WHERE e.RondDeltagarID = @RondDeltagarID";
                
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RondDeltagarID", DataTyp.Int, RondDeltagarID.ToString())
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
        /// Hämtar rad från tabellen EclecticRondDeltagare i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="RondID">Aktuell EclecticRond</param>
        /// <param name="RondDeltagarID">Aktuellt tillfälle</param>
        /// <param name="SpelarID">Aktuell spelare</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticRondDeltagareDS HämtaEclecticRondDeltagare(int RondDeltagarID, int SpelarID, 
            int RondID)
        {
            EclecticRondDeltagareDS ds = new EclecticRondDeltagareDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticRondDeltagare e WHERE e.RondDeltagarID = @RondDeltagarID " +
                    "AND e.SpelarID = @SpelarID AND e.RondID = @RondID";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RondDeltagarID", DataTyp.Int, RondDeltagarID.ToString()),
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
        public string HämtaMaxEclecticRondDeltagare()
        {
            DataSet eclecticRondDeltagareDS = new DataSet();
            string nyttEclecticRondDeltagarID = string.Empty;
            string sql;

            try
            {
                sql = "SELECT e.EclecticRondDeltagarID FROM EclecticRondDeltagare e " +
                    " ORDER BY e.EclecticRondDeltagarID DESC";
                eclecticRondDeltagareDS = DatabasAccess.RunSql(sql);
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
            nyttEclecticRondDeltagarID = eclecticRondDeltagareDS.Tables[0].Rows[0]["nyttEclecticRondDeltagarID"].
                ToString();
            return nyttEclecticRondDeltagarID;
        }

        /// <summary>
        /// Ny EclecticRondDeltagare.
        /// </summary>
        /// <param name="EclecticRondDeltagare">EclecticRondDeltagare</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaNyEclecticRondDeltagare(EclecticRond eclecticRond, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();

                for (int i = 0; i < eclecticRond.eclecticRondDeltagares.Length; i++)
                {
                    sql = "INSERT INTO EclecticRondDeltagare(SpelarID, RondID, ExaktHcp, ErhallnaSlag, " +
                        "Tee, RondDeltagareDatum, RondDeltagareUppdatDatum) " +
                        "VALUES " +
                        "(@SpelarID, @RondID, @ExaktHcp,@ErhallnaSlag, @Tee, @RondDeltagareDatum, " +
                        "@RondDeltagareUppdatDatum)";
                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@SpelarID", DataTyp.Int, eclecticRond.eclecticRondDeltagares[i].SpelarID.ToString()),
                        new DatabasParameters("@RondID", DataTyp.Int, eclecticRond.eclecticRondDeltagares[i].EclecticID.ToString()),
                        new DatabasParameters("@ExaktHcp", DataTyp.Decimal, eclecticRond.eclecticRondDeltagares[i].ExaktHcp.ToString()),
                        new DatabasParameters("@ErhallnaSlag", DataTyp.Int, eclecticRond.eclecticRondDeltagares[i].ErhallnaSlag.ToString()),
                        new DatabasParameters("@Tee", DataTyp.Char, eclecticRond.eclecticRondDeltagares[i].Tee.ToString()),
                        new DatabasParameters("@RondDeltagareDatum", DataTyp.VarChar, eclecticRond.eclecticRondDeltagares[i].DeltagarDatum.ToString()),
                        new DatabasParameters("@RondDeltagareUppdatDatum", DataTyp.VarChar, eclecticRond.eclecticRondDeltagares[i].DeltagarUppdatDatum.ToString())
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
        /// Spara EclecticRondDeltagare.
        /// </summary>
        /// <param name="EclecticRondDeltagare">EclecticRondDeltagare</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaEclecticRondDeltagare(EclecticRond eclecticRond, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();

                for (int i = 0; i < eclecticRond.eclecticRondDeltagares.Length; i++)
                {
                    sql = "UPDATE EclecticRondDeltagare " +
                        "SET RondID = @RondID, ExaktHcp = @ExaktHcp, " +
                        "ErhallnaSlag = @ErhallnaSlag, Tee = @Tee, RondDeltagareDatum = @RondDeltagareDatum, " +
                        "RondDeltagareUppdatDatum = @RondDeltagareUppdatDatum " +
                        "WHERE RondDeltagarID = @RondDeltagarID AND SpelarID = @SpelarID";
                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@RondDeltagarID", DataTyp.Int, eclecticRond.eclecticRondDeltagares[i].DeltagarID.ToString()),
                        new DatabasParameters("@SpelarID", DataTyp.Int, eclecticRond.eclecticRondDeltagares[i].SpelarID.ToString()),
                        new DatabasParameters("@RondID", DataTyp.Int, eclecticRond.eclecticRondDeltagares[i].EclecticID.ToString()),
                        new DatabasParameters("@ExaktHcp", DataTyp.Decimal, eclecticRond.eclecticRondDeltagares[i].ExaktHcp.ToString()),
                        new DatabasParameters("@ErhallnaSlag", DataTyp.Int, eclecticRond.eclecticRondDeltagares[i].ErhallnaSlag.ToString()),
                        new DatabasParameters("@Tee", DataTyp.Char, eclecticRond.eclecticRondDeltagares[i].Tee.ToString()),
                        new DatabasParameters("@RondDeltagareDatum", DataTyp.VarChar, eclecticRond.eclecticRondDeltagares[i].DeltagarDatum.ToString()),
                        new DatabasParameters("@RondDeltagareUppdatDatum", DataTyp.VarChar, eclecticRond.eclecticRondDeltagares[i].DeltagarUppdatDatum.ToString())
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
