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
    /// Datalagerklass för Eclectic
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
        public void SparaNyEclecticRond(EclecticRond eclecticRond, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "INSERT INTO EclecticRond(EclecticID, RondNotering, RondNamn, RondDatum, RondStatus, BanaNr, " +
                    "AnvandarNamnSkapad, SkapadDatum, AnvandarNamnUppdat, UppdatDatum) " +
                    "VALUES " +
                    "(@EclecticID, @RondNotering, @RondNamn, @RondDatum, @RondStatus, @BanaNr, " +
                    "@AnvandarNamnSkapad, @SkapadDatum, @AnvandarNamnUppdat, @UppdatDatum)";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@EclecticID", DataTyp.Int, eclecticRond.EclecticID.ToString()),
                    new DatabasParameters("@RondNotering", DataTyp.VarChar, eclecticRond.RondNotering.ToString()),
                    new DatabasParameters("@RondNamn", DataTyp.VarChar, eclecticRond.RondNamn.ToString()),
                    new DatabasParameters("@RondDatum", DataTyp.VarChar, eclecticRond.RondDatum.ToString()),
                    new DatabasParameters("@RondStatus", DataTyp.Char, eclecticRond.Rondstatus.ToString()),
                    new DatabasParameters("@BanaNr", DataTyp.Int, eclecticRond.BanaNr.ToString()),
                    new DatabasParameters("@AnvandarNamnSkapad", DataTyp.VarChar, eclecticRond.AnvandarNamnSkapad.ToString()),
                    new DatabasParameters("@SkapadDatum", DataTyp.VarChar, eclecticRond.SkapadDatum.ToString()),
                    new DatabasParameters("@AnvandarNamnUppdat", DataTyp.VarChar, eclecticRond.AnvandarNamnUppdat.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.VarChar, eclecticRond.UppdatDatum.ToString())
                };
                DatabasAccess.RunSql(sql, dbParameters);
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
        public void SparaEclecticRond(EclecticRond eclecticRond, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "UPDATE EclecticRond " +
                    "SET EclecticID = @EclecticID,  RondNotering = @RondNotering, RondNamn = @RondNamn, RondDatum = @RondDatum, RondStatus = @RondStatus, " +
                    "BanaNr = @BanaNr,  AnvandarNamnSkapad = @AnvandarNamnSkapad, SkapadDatum = @SkapadDatum, AnvandarNamnUppdat = @AnvandarNamnUppdat, " +
                    "UppdatDatum = @UppdatDatum " +
                    "WHERE RondID = @RondID";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RondID", DataTyp.Int, eclecticRond.RondID.ToString()),
                    new DatabasParameters("@EclecticID", DataTyp.Int, eclecticRond.EclecticID.ToString()),
                    new DatabasParameters("@RondNotering", DataTyp.VarChar, eclecticRond.RondNotering.ToString()),
                    new DatabasParameters("@RondNamn", DataTyp.VarChar, eclecticRond.RondNamn.ToString()),
                    new DatabasParameters("@RondDatum", DataTyp.VarChar, eclecticRond.RondDatum.ToString()),
                    new DatabasParameters("@RondStatus", DataTyp.Char, eclecticRond.Rondstatus.ToString()),
                    new DatabasParameters("@BanaNr", DataTyp.Int, eclecticRond.BanaNr.ToString()),
                    new DatabasParameters("@AnvandarNamnSkapad", DataTyp.VarChar, eclecticRond.AnvandarNamnSkapad.ToString()),
                    new DatabasParameters("@SkapadDatum", DataTyp.VarChar, eclecticRond.SkapadDatum.ToString()),
                    new DatabasParameters("@AnvandarNamnUppdat", DataTyp.VarChar, eclecticRond.AnvandarNamnUppdat.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.VarChar, eclecticRond.UppdatDatum.ToString())
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
