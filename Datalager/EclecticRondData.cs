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
    /// Datalagerklass för EclecticRond
    /// </summary>
    public sealed class EclecticRondData : AbstractDataLager
    {
        /// <summary>
        /// Hämtar rad från tabellen EclecticRond i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="RondID">Aktuell bokning</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticRondDS HämtaEclecticRond(int RondID)
        {
            EclecticRondDS ds = new EclecticRondDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticRond e WHERE e.RondID = @RondID";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
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
        /// Hämtar rad från tabellen EclecticRond i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="RondID">Aktuell bokning</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticRondDS HämtaEclecticRonder(int EclecticID)
        {
            EclecticRondDS ds = new EclecticRondDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticRond e WHERE e.EclecticID = @EclecticID";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@EclecticID", DataTyp.Int, EclecticID.ToString()),
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
        /// Hämtar rad från tabellen EclecticRond i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="RondID">Aktuell bokning</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticRondDS HämtaEclecticRondBana(int EclecticID, int BanaNr)
        {
            EclecticRondDS ds = new EclecticRondDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticRond e WHERE e.EclecticID = @EclecticID " +
                    "AND e.BanaNr = @BanaNr";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@EclecticID", DataTyp.Int, EclecticID.ToString()),
                    new DatabasParameters("@BanaNr", DataTyp.Int, BanaNr.ToString())
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
        /// Hämtar rad från tabellen EclecticRond i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="BanaNr">Aktuell bana</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticDS HämtaEclecticRondBana(int BanaNr)
        {
            EclecticDS ds = new EclecticDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticRond e WHERE e.BanaNr = @BanaNr";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@BanaNr", DataTyp.Int, BanaNr.ToString())
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
        /// Hämtar rad från tabellen EclecticRond i aktuell databas med angiven nyckel.
        /// </summary>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public string HämtaMaxRondID()
        {
            DataSet eclecticRondDS = new DataSet();
            string nyttRondID = string.Empty;
            string sql;

            try
            {
                sql = "SELECT e.RondID FROM EclecticRond e " +
                    " ORDER BY e.RondID DESC";
                eclecticRondDS = DatabasAccess.RunSql(sql);
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
            nyttRondID = eclecticRondDS.Tables[0].Rows[0]["RondID"].ToString();
            return nyttRondID;
        }

        /// <summary>
        /// Ny EclecticRond.
        /// </summary>
        /// <param name="EclecticRond">Eclecticronden</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaNyEclecticRond(Eclectic eclectic, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                for (int i = 0; i < eclectic.eclecticRonds.Length; i++)
                {
                    sql = "INSERT INTO EclecticRond(EclecticID, RondNotering, RondNamn, RondDatum, " +
                        "RondStatus, BanaNr, AnvandarNamnRondSkapad, RondSkapadDatum, " +
                        "AnvandarNamnRondUppdat, RondUppdatDatum) " +

                    "VALUES " +
                    "(@EclecticID, @RondNotering, @RondNamn, @RondDatum, @RondStatus, @BanaNr, " +
                    "@AnvandarNamnRondSkapad, @RondSkapadDatum, @AnvandarNamnRondUppdat, @RondUppdatDatum)";

                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@EclecticID", DataTyp.Int, eclectic.eclecticRonds[i].EclecticID.ToString()),
                        new DatabasParameters("@RondNotering", DataTyp.VarChar, eclectic.eclecticRonds[i].RondNotering.ToString()),
                        new DatabasParameters("@RondNamn", DataTyp.VarChar, eclectic.eclecticRonds[i].RondNamn.ToString()),
                        new DatabasParameters("@RondDatum", DataTyp.VarChar, eclectic.eclecticRonds[i].RondDatum.ToString()),
                        new DatabasParameters("@RondStatus", DataTyp.Char, eclectic.eclecticRonds[i].Rondstatus.ToString()),
                        new DatabasParameters("@BanaNr", DataTyp.Int, eclectic.eclecticRonds[i].BanaNr.ToString()),
                        new DatabasParameters("@AnvandarNamnRondSkapad", DataTyp.VarChar, eclectic.eclecticRonds[i].AnvandarNamnRondSkapad.ToString()),
                        new DatabasParameters("@RondSkapadDatum", DataTyp.VarChar, eclectic.eclecticRonds[i].RondSkapadDatum.ToString()),
                        new DatabasParameters("@AnvandarNamnRondUppdat", DataTyp.VarChar, eclectic.eclecticRonds[i].AnvandarNamnRondUppdat.ToString()),
                        new DatabasParameters("@RondUppdatDatum", DataTyp.VarChar, eclectic.eclecticRonds[i].RondUppdatDatum.ToString())
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
        /// Sparar i EclecticRond.
        /// </summary>
        /// <param name="eclecticRond">EclecticRond</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaEclecticRond(Eclectic eclectic, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                for (int i = 0; i < eclectic.eclecticRonds.Length; i++)
                {
                    sql = "UPDATE EclecticRond " +
                    "SET EclecticID = @EclecticID,  RondNotering = @RondNotering, RondNamn = @RondNamn, RondDatum = @RondDatum, RondStatus = @RondStatus, " +
                    "BanaNr = @BanaNr,  AnvandarNamnRondSkapad = @AnvandarNamnRondSkapad, " +
                    "RondSkapadDatum = @RondSkapadDatum, AnvandarNamnRondUppdat = @AnvandarNamnRondUppdat, " +
                    "RondUppdatDatum = @RondUppdatDatum " +
                    "WHERE RondID = @RondID";

                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RondID", DataTyp.Int, eclectic.eclecticRonds[i].RondID.ToString()),
                    new DatabasParameters("@EclecticID", DataTyp.Int, eclectic.eclecticRonds[i].EclecticID.ToString()),
                    new DatabasParameters("@RondNotering", DataTyp.VarChar, eclectic.eclecticRonds[i].RondNotering.ToString()),
                    new DatabasParameters("@RondNamn", DataTyp.VarChar, eclectic.eclecticRonds[i].RondNamn.ToString()),
                    new DatabasParameters("@RondDatum", DataTyp.VarChar, eclectic.eclecticRonds[i].RondDatum.ToString()),
                    new DatabasParameters("@RondStatus", DataTyp.Char, eclectic.eclecticRonds[i].Rondstatus.ToString()),
                    new DatabasParameters("@BanaNr", DataTyp.Int, eclectic.eclecticRonds[i].BanaNr.ToString()),
                    new DatabasParameters("@AnvandarNamnRondSkapad", DataTyp.VarChar, eclectic.eclecticRonds[i].AnvandarNamnRondSkapad.ToString()),
                    new DatabasParameters("@RondSkapadDatum", DataTyp.VarChar, eclectic.eclecticRonds[i].RondSkapadDatum.ToString()),
                    new DatabasParameters("@AnvandarNamnRondUppdat", DataTyp.VarChar, eclectic.eclecticRonds[i].AnvandarNamnRondUppdat.ToString()),
                    new DatabasParameters("@RondUppdatDatum", DataTyp.VarChar, eclectic.eclecticRonds[i].RondUppdatDatum.ToString())
                };
                    DatabasAccess.RunSql(sql, dbParameters);
                }
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
