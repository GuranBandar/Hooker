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
    public sealed class EclecticData : AbstractDataLager
    {
        /// <summary>
        /// Hämtar rad från tabellen Eclectic i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="EclecticID">Aktuell bokning</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticDS HämtaEclectic(int EclecticID)
        {
            EclecticDS ds = new EclecticDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM Eclectic e WHERE e.EclecticID = @EclecticID";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@EclecticID", DataTyp.Int, EclecticID.ToString())
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
        /// Hämtar rad från tabellen Eclectic i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="EclecticStatus">Aktuell eclectic</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticDS HämtaEclectic(string EclecticStatus)
        {
            EclecticDS ds = new EclecticDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM Eclectic e WHERE e.EclecticStatus = @EclecticStatus";
                
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@EclecticStatus", DataTyp.Int, EclecticStatus.ToString())
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
        /// Hämtar rad från tabellen Eclectic i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="BanaNr">Aktuell bana</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticDS HämtaEclecticBana(int BanaNr)
        {
            EclecticDS ds = new EclecticDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM Eclectic e WHERE e.BanaNr = @BanaNr";
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
        /// Hämtar rad från tabellen Eclectic i aktuell databas med angiven nyckel.
        /// </summary>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public string HämtaMaxEclectic()
        {
            DataSet eclecticDS = new DataSet();
            string nyttEclecticID = string.Empty;
            string sql;

            try
            {
                sql = "SELECT e.EclecticID FROM Eclectic e " +
                    " ORDER BY e.EclecticID DESC";
                eclecticDS = DatabasAccess.RunSql(sql);
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
            nyttEclecticID = eclecticDS.Tables[0].Rows[0]["EclecticID"].ToString();
            return nyttEclecticID;
        }

        /// <summary>
        /// Ny Eclectic.
        /// </summary>
        /// <param name="Eclectic">Eclecticen</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaNyEclectic(Eclectic eclectic, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "INSERT INTO Eclectic(Namn, StartDatum, EclecticStatus, Notering, " +
                    "AnvandarNamnSkapad, SkapadDatum, AnvandarNamnUppdat, UppdatDatum) " +
                    "VALUES " +
                    "(@Namn, @StartDatum, @EclecticStatus, @Notering, " +
                    "@AnvandarNamnSkapad, @SkapadDatum, @AnvandarNamnUppdat, @UppdatDatum)";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@Namn", DataTyp.VarChar, eclectic.Namn.ToString()),
                    new DatabasParameters("@StartDatum", DataTyp.VarChar, eclectic.StartDatum.ToString()),
                    new DatabasParameters("@EclecticStatus", DataTyp.VarChar, eclectic.Eclecticstatus.ToString()),
                    new DatabasParameters("@Notering", DataTyp.VarChar, eclectic.Notering.ToString()),
                    new DatabasParameters("@AnvandarNamnSkapad", DataTyp.VarChar, eclectic.AnvandarNamnSkapad.ToString()),
                    new DatabasParameters("@SkapadDatum", DataTyp.VarChar, eclectic.SkapadDatum.ToString()),
                    new DatabasParameters("@AnvandarNamnUppdat", DataTyp.VarChar, eclectic.AnvandarNamnUppdat.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.VarChar, eclectic.UppdatDatum.ToString())
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
        /// Sparar i Eclectic.
        /// </summary>
        /// <param name="eclectic">Eclectic</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaEclectic(Eclectic eclectic, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "UPDATE Eclectic " +
                    "SET Namn = @Namn, StartDatum = @StartDatum, EclecticStatus = @EclecticStatus, " +
                    "Notering = @Notering, AnvandarNamnSkapad = @AnvandarNamnSkapad, SkapadDatum = @SkapadDatum, " +
                    "AnvandarNamnUppdat = @AnvandarNamnUppdat, UppdatDatum = @UppdatDatum " +
                    "WHERE EclecticID = @EclecticID";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@EclecticID", DataTyp.Int, eclectic.EclecticID.ToString()),
                    new DatabasParameters("@Namn", DataTyp.VarChar, eclectic.Namn.ToString()),
                    new DatabasParameters("@StartDatum", DataTyp.VarChar, eclectic.StartDatum.ToString()),
                    new DatabasParameters("@EclecticStatus", DataTyp.Char, eclectic.Eclecticstatus.ToString()),
                    new DatabasParameters("@Notering", DataTyp.VarChar, eclectic.Notering.ToString()),
                    new DatabasParameters("@AnvandarNamnSkapad", DataTyp.VarChar, eclectic.AnvandarNamnSkapad.ToString()),
                    new DatabasParameters("@SkapadDatum", DataTyp.VarChar, eclectic.SkapadDatum.ToString()),
                    new DatabasParameters("@AnvandarNamnUppdat", DataTyp.VarChar, eclectic.AnvandarNamnUppdat.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.VarChar, eclectic.UppdatDatum.ToString())
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
