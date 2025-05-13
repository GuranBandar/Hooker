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
        /// <param name="TillfalleID">Aktuell EclecticRondResultat</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticRondResultatDS HämtaEclecticRondResultat(int TillfalleID)
        {
            EclecticRondResultatDS ds = new EclecticRondResultatDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticRondResultat e WHERE e.TillfalleID = @TillfalleID";

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
        /// Hämtar rad från tabellen EclecticRondResultat i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="TillfalleID">Aktuell EclecticRondResultat</param>
        /// <param name="SpelarID">Aktuell spelare</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticRondResultatDS HämtaEclecticRondResultat(int TillfalleID, int SpelarID)
        {
            EclecticRondResultatDS ds = new EclecticRondResultatDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticRondResultat e WHERE e.TillfalleID = @TillfalleID " +
                    "AND e.SpelarID = @SpelarID";
                
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TillfalleID", DataTyp.Int, TillfalleID.ToString()),
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
        /// Ny EclecticRondResultat.
        /// </summary>
        /// <param name="EclecticTillfalle">EclecticTillfalle</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaNyEclecticRondResultat(EclecticTillfalle eclecticTillfalle, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                for (int i = 0; i < eclecticTillfalle.eclecticRondResultats.Length; i++)
                {
                    sql = "INSERT INTO EclecticRondResultat(TillfalleID, SpelarID, HalNr, AntalSlag, AntalPoang, " +
                        "RondDatum) " +
                        "VALUES " +
                        "(@TillfalleID, @SpelarID, @HalNr, @AntalSlag, @AntalPoang, @RondDatum)";

                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@TillfalleID", DataTyp.Int, eclecticTillfalle.eclecticRondResultats[i].TillfalleID.ToString()),
                        new DatabasParameters("@SpelarID", DataTyp.Int, eclecticTillfalle.eclecticRondResultats[i].SpelarID.ToString()),
                        new DatabasParameters("@HalNr", DataTyp.Int, eclecticTillfalle.eclecticRondResultats[i].HalNr.ToString()),
                        new DatabasParameters("@AntalSlag", DataTyp.Int, eclecticTillfalle.eclecticRondResultats[i].AntalSlag.ToString()),
                        new DatabasParameters("@AntalPoang", DataTyp.Int, eclecticTillfalle.eclecticRondResultats[i].AntalPoang.ToString()),
                        new DatabasParameters("@RondDatum", DataTyp.VarChar, eclecticTillfalle.eclecticRondResultats[i].RondDatum.ToString())
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
        /// Sprara EclecticRondResultat.
        /// </summary>
        /// <param name="EclecticTillfalle">EclecticTillfalle</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaEclecticRondResultat(EclecticTillfalle eclecticTillfalle, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();

                for (int i = 0; i < eclecticTillfalle.eclecticRondResultats.Length; i++)
                {
                    sql = "UPDATE EclecticRondResultat " +
                        "SET HalNr = @HalNr, AntalSlag = @AntalSlag, AntalPoang = @AntalPoang, RondDatum = @RondDatum " +
                        "WHERE TillfalleID = @TillfalleID AND SpelarID = @SpelarID";

                      List < DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@TillfalleID", DataTyp.Int, eclecticTillfalle.eclecticRondResultats[i].TillfalleID.ToString()),
                        new DatabasParameters("@SpelarID", DataTyp.Int, eclecticTillfalle.eclecticRondResultats[i].SpelarID.ToString()),
                        new DatabasParameters("@HalNr", DataTyp.Int, eclecticTillfalle.eclecticRondResultats[i].HalNr.ToString()),
                        new DatabasParameters("@AntalSlag", DataTyp.Int, eclecticTillfalle.eclecticRondResultats[i].AntalSlag.ToString()),
                        new DatabasParameters("@AntalPoang", DataTyp.Int, eclecticTillfalle.eclecticRondResultats[i].AntalPoang.ToString()),
                        new DatabasParameters("@RondDatum", DataTyp.VarChar, eclecticTillfalle.eclecticRondResultats[i].RondDatum.ToString())
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
