using GemensamService;
using Hooker.Affärsobjekt;
using Hooker.Dataset;
using Hooker.Gemensam;
using System;
using System.Collections.Generic;
using System.Text;

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
        public void SparaNyEclecticRondResultat(List<EclecticRondResultat> eclecticRondResultat, ref string felID, ref string feltext)
        {
            string sql;
            int nyaRader = 0;

            try
            {
                //DatabasAccess.SkapaTransaktion();
                //sql = @"INSERT INTO EclecticRondResultat(RondID, SpelarID, HalNr, Par, Hcp, AntalSlag_Brutto, AntalSlag_Netto, " +
                //     "AntalPoang, RondDatum) " +
                //    "VALUES " +
                //    "(@RondID, @SpelarID, @HalNr, @Par, @Hcp, @AntalSlag_Brutto, @AntalSlag_Netto, @AntalPoang, @RondDatum)";

                var sb = new StringBuilder();
                var parameters = new Dictionary<string, object>();
                int index = 0;

                foreach (var result in eclecticRondResultat)
                {
                    sb.AppendLine($"INSERT INTO EclecticRondResultat(RondID, SpelarID, HalNr, AntalSlag_Brutto, AntalSlag_Netto, AntalPoang, RondDatum) " +
                                  $"VALUES (@RondID{index}, @SpelarID{index}, @HalNr{index}, @AntalSlag_Brutto{index}, @AntalSlag_Netto{index}, @AntalPoang{index}, @RondDatum{index});");

                    parameters[$"@RondID{index}"] = result.RondID;
                    parameters[$"@SpelarID{index}"] = result.SpelarID;
                    parameters[$"@HalNr{index}"] = result.HalNr;
                    parameters[$"@AntalSlag_Brutto{index}"] = result.AntalSlag_Brutto;
                    parameters[$"@AntalSlag_Netto{index}"] = result.AntalSlag_Netto;
                    parameters[$"@AntalPoang{index}"] = result.AntalPoang;
                    parameters[$"@RondDatum{index}"] = result.RondDatum;

                    index++;
                }

                DatabasAccess.SkapaTransaktion();
                nyaRader = DatabasAccess.ExecuteNonQuery(sb.ToString(), parameters);
                DatabasAccess.BekräftaTransaktion();

                //foreach (var result in eclecticRondResultat)
                //{
                //    var dbParameters = new Dictionary<string, object>
                //    {
                //        ["@RondId"] = result.RondID,
                //        ["@SpelarId"] = result.SpelarID,
                //        ["@HalNr"] = result.HalNr,
                //        ["@Par"] = result.Par,
                //        ["@Hcp"] = result.Hcp,
                //        ["@AntalSlag_Brutto"] = result.AntalSlag_Brutto,
                //        ["@AntalSlag_Netto"] = result.AntalSlag_Netto,
                //        ["@AntalPoang"] = result.AntalPoang,
                //        ["@RondDatum"] = result.RondDatum,
                //    };
                //    nyaRader = DatabasAccess.ExecuteNonQuery(sql, dbParameters);
                //}
                //DatabasAccess.BekräftaTransaktion();
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
        public void SparaEclecticRondResultat(List<EclecticRondResultat> eclecticRondResultat, ref string felID, ref string feltext)
        {
            string sql;
            int uppdateradeRader = 0;

            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = @"UPDATE EclecticRondResultat " +
                    "SET HalNr = @HalNr, AntalSlag_Brutto = @AntalSlag_Brutto, AntalSlag_Netto = @AntalSlag_Netto, " +
                    "AntalPoang = @AntalPoang, RondDatum = @RondDatum " +
                    "WHERE RondID = @RondID AND SpelarID = @SpelarID AND HalNr = @HalNr";

                foreach (var item in eclecticRondResultat)
                {
                    var dbParameters = new Dictionary<string, object>
                    {
                        ["@RondID"] = item.RondID,
                        ["@SpelarID"] = item.SpelarID,
                        ["@HalNr"] = item.HalNr,
                        ["@AntalSlag_Brutto"] = item.AntalSlag_Brutto,
                        ["@AntalSlag_Netto"] = item.AntalSlag_Netto,
                        ["@AntalPoang"] = item.AntalPoang,
                        ["RondDatum"] = item.RondDatum
                    };
                    uppdateradeRader = DatabasAccess.ExecuteNonQuery(sql, dbParameters);
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
