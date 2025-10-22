using GemensamService;
using Hooker.Affärsobjekt;
using Hooker.Dataset;
using Hooker.Gemensam;
using System;
using System.Collections.Generic;
using System.Linq;
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
            int nyaRader = 0;

            try
            {
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
        /// Uppdaterar EclecticRondResultat med förändrade data
        /// </summary>
        /// <param name="nyaRader">Den uppdaterade listan</param>
        /// <param name="gamlaRader">Lista med gamla värden</param>
        /// <param name="felID"></param>
        /// <param name="feltext"></param>
        public void UppdateraRondResultat(List<EclecticRondResultat> nyaRader, List<EclecticRondResultat> gamlaRader, ref string felID, ref string feltext)
        {
            DatabasAccess.SkapaTransaktion();

            string sql = @"UPDATE EclecticRondResultat SET 
                    AntalSlag_Brutto = @AntalSlag_Brutto,
                    AntalSlag_Netto = @AntalSlag_Netto,
                    AntalPoang = @AntalPoang,
                    RondDatum = @RondDatum,
                    Uppdaterad = 'J'
                   WHERE TotalID = @RondID AND SpelarID = @SpelarID AND HalNr = @HalNr";

            foreach (var ny in nyaRader)
            {
                var gammal = gamlaRader.FirstOrDefault(x =>
                    x.RondID == ny.RondID &&
                    x.SpelarID == ny.SpelarID &&
                    x.HalNr == ny.HalNr);

                if (gammal == null) continue;

                bool ändrad =
                    ny.AntalSlag_Brutto != gammal.AntalSlag_Brutto ||
                    ny.AntalSlag_Netto != gammal.AntalSlag_Netto ||
                    ny.AntalPoang != gammal.AntalPoang ||
                    ny.RondDatum != gammal.RondDatum;

                if (!ändrad) continue;

                var param = new Dictionary<string, object>
                {
                    ["@RondID"] = ny.RondID,
                    ["@SpelarID"] = ny.SpelarID,
                    ["@HalNr"] = ny.HalNr,
                    ["@AntalSlag_Brutto"] = ny.AntalSlag_Brutto,
                    ["@AntalSlag_Netto"] = ny.AntalSlag_Netto,
                    ["@AntalPoang"] = ny.AntalPoang,
                    ["@RondDatum"] = ny.RondDatum
                };

                DatabasAccess.ExecuteNonQuery(sql, param);
            }

            DatabasAccess.BekräftaTransaktion();
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
