using GemensamService;
using Hooker.Affärsobjekt;
using Hooker.Dataset;
using Hooker.Gemensam;
using System;
using System.Collections.Generic;

namespace Hooker.Datalager
{
    /// <summary>
    /// Datalagerklass för EclecticTillfalle
    /// </summary>
    public sealed class EclecticRondResultatData : AbstractDataLager
    {
        /// <summary>
        /// Hämtar rad från tabellen EclecticRondResultat i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="rondID">Aktuell EclecticRond</param>
        /// <param name="spelarID">Aktuell spelare</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticRondResultatDS HämtaEclecticRondResultat(int rondID, int spelarID)
        {
            EclecticRondResultatDS ds = new EclecticRondResultatDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticRondResultat e WHERE e.RondID = @RondID AND e.SpelarID = @SpelarID";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RondID", DataTyp.Int, rondID.ToString()),
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
        /// Hämtar alla poster i tabellen EclecticRondResultat för en rond
        /// </summary>
        /// <param name="rondID">Aktuell EclecticRond</param>
        /// <param name="spelarID">Aktuell spelare</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticRondResultatDS HämtaEclecticRondResultat(int rondID)
        {
            EclecticRondResultatDS ds = new EclecticRondResultatDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticRondResultat e WHERE e.RondID = @RondID";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RondID", DataTyp.Int, rondID.ToString())
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
        /// Hämtar rad från tabellen EclecticRondResultat i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="rondID">Aktuell EclecticRond</param>
        /// <param name="spelarID">Aktuell spelare</param>
        /// <param name="halnr">Aktuellt hål</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticRondResultatDS HämtaEclecticRondResultat(int rondID, int spelarID, int halNr)
        {
            EclecticRondResultatDS ds = new EclecticRondResultatDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticRondResultat e WHERE e.RondID = @RondID AND e.SpelarID = @SpelarID " +
                    "AND HalNr = @HalNr";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RondID", DataTyp.Int, rondID.ToString()),
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
        /// Ny EclecticRondResultat.
        /// </summary>
        /// <param name="EclecticRondDeltagare">EclecticRondDeltagare</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaNyEclecticRondResultat(EclecticRondResultat eclecticRondResultat, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "INSERT INTO EclecticRondResultat(RondID, SpelarID, HalNr, AntalSlag, AntalPoang, " +
                    "RondDatum) " +
                    "VALUES " +
                    "(@RondID, @SpelarID, @HalNr, @AntalSlag, @AntalPoang, @RondDatum)";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RondID", DataTyp.Int, eclecticRondResultat.RondID.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, eclecticRondResultat.SpelarID.ToString()),
                    new DatabasParameters("@HalNr", DataTyp.Int, eclecticRondResultat.HalNr.ToString()),
                    new DatabasParameters("@AntalSlag", DataTyp.Int, eclecticRondResultat.AntalSlag.ToString()),
                    new DatabasParameters("@AntalPoang", DataTyp.Int, eclecticRondResultat.AntalPoang.ToString()),
                    new DatabasParameters("@RondDatum", DataTyp.VarChar, eclecticRondResultat.RondDatum.ToString())
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
        /// Ny EclecticRondResultat.
        /// </summary>
        /// <param name="EclecticRondDeltagare">EclecticRondDeltagare</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaNyEclecticRondResultatAllaHal(List<EclecticRondResultat> eclecticRondResultat, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                List<DatabasParameters> dbParameters = null;

                sql = "INSERT INTO EclecticRondResultat(RondID, SpelarID, HalNr, AntalSlag, AntalPoang, " +
                    "RondDatum) " +
                    "VALUES " +
                    "(@RondID, @SpelarID, @HalNr, @AntalSlag, @AntalPoang, @RondDatum)," +
                    "(@RondID, @SpelarID, @HalNr, @AntalSlag, @AntalPoang, @RondDatum)," +
                    "(@RondID, @SpelarID, @HalNr, @AntalSlag, @AntalPoang, @RondDatum)," +
                    "(@RondID, @SpelarID, @HalNr, @AntalSlag, @AntalPoang, @RondDatum)," +
                    "(@RondID, @SpelarID, @HalNr, @AntalSlag, @AntalPoang, @RondDatum)," +
                    "(@RondID, @SpelarID, @HalNr, @AntalSlag, @AntalPoang, @RondDatum)," +
                    "(@RondID, @SpelarID, @HalNr, @AntalSlag, @AntalPoang, @RondDatum)," +
                    "(@RondID, @SpelarID, @HalNr, @AntalSlag, @AntalPoang, @RondDatum)," +
                    "(@RondID, @SpelarID, @HalNr, @AntalSlag, @AntalPoang, @RondDatum)," +
                    "(@RondID, @SpelarID, @HalNr, @AntalSlag, @AntalPoang, @RondDatum)," +
                    "(@RondID, @SpelarID, @HalNr, @AntalSlag, @AntalPoang, @RondDatum)," +
                    "(@RondID, @SpelarID, @HalNr, @AntalSlag, @AntalPoang, @RondDatum)," +
                    "(@RondID, @SpelarID, @HalNr, @AntalSlag, @AntalPoang, @RondDatum)," +
                    "(@RondID, @SpelarID, @HalNr, @AntalSlag, @AntalPoang, @RondDatum)," +
                    "(@RondID, @SpelarID, @HalNr, @AntalSlag, @AntalPoang, @RondDatum)," +
                    "(@RondID, @SpelarID, @HalNr, @AntalSlag, @AntalPoang, @RondDatum)," +
                    "(@RondID, @SpelarID, @HalNr, @AntalSlag, @AntalPoang, @RondDatum)";

                foreach (EclecticRondResultat rondResultat in eclecticRondResultat)
                {
                    dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@RondID", DataTyp.Int, rondResultat.RondID.ToString()),
                        new DatabasParameters("@SpelarID", DataTyp.Int, rondResultat.SpelarID.ToString()),
                        new DatabasParameters("@HalNr", DataTyp.Int, rondResultat.HalNr.ToString()),
                        new DatabasParameters("@AntalSlag", DataTyp.Int, rondResultat.AntalSlag.ToString()),
                        new DatabasParameters("@AntalPoang", DataTyp.Int, rondResultat.AntalPoang.ToString()),
                        new DatabasParameters("@RondDatum", DataTyp.VarChar, rondResultat.RondDatum.ToString())
                    };
                }
                DatabasAccess.RunSqlMultipel(sql, dbParameters);
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
        /// Sprara EclecticRondResultat.
        /// </summary>
        /// <param name="EclecticTillfalle">EclecticTillfalle</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaEclecticRondResultat(EclecticRondResultat eclecticRondResultat, ref string felID, ref string feltext)
        {
            string sql;
            
            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "UPDATE EclecticRondResultat " +
                    "SET HalNr = @HalNr, AntalSlag = @AntalSlag, AntalPoang = @AntalPoang, RondDatum = @RondDatum " +
                    "WHERE RondID = @RondID AND SpelarID = @SpelarID AND HalNr = @HalNr";

                    List < DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RondID", DataTyp.Int, eclecticRondResultat.RondID.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, eclecticRondResultat.SpelarID.ToString()),
                    new DatabasParameters("@HalNr", DataTyp.Int, eclecticRondResultat.HalNr.ToString()),
                    new DatabasParameters("@AntalSlag", DataTyp.Int, eclecticRondResultat.AntalSlag.ToString()),
                    new DatabasParameters("@AntalPoang", DataTyp.Int, eclecticRondResultat.AntalPoang.ToString()),
                    new DatabasParameters("@RondDatum", DataTyp.VarChar, eclecticRondResultat.RondDatum.ToString())
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
    }
}
