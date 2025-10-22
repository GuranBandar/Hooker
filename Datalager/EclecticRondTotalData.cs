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
    /// Datalagerklass för EclecticRondTotal
    /// </summary>
    public sealed class EclecticRondTotalData : AbstractDataLager
    {
        /// <summary>
        /// Hämtar rad från tabellen EclecticRondTotal i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="totalID">Aktuell EclecticTotal</param>
        /// <param name="spelarID">Aktuell spelare</param>
        /// <param name="halNr">Aktuellt hål</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticRondTotalDS HämtaEclecticRondTotal(int totalID, int spelarID, int halNr)
        {
            EclecticRondTotalDS ds = new EclecticRondTotalDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticRondTotal e WHERE e.TotalID = @TotalID " +
                    "AND e.SpelarID = @SpelarID AND e.HalNr = @HalNr";
                
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TotalID", DataTyp.Int, totalID.ToString()),
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
        /// Hämtar rad från tabellen EclecticRondTotal i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="totalID">Aktuell EclecticTotal</param>
        /// <param name="spelarID">Aktuell spelare</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticRondTotalDS HämtaEclecticRondTotal(int totalID, int spelarID)
        {
            EclecticRondTotalDS ds = new EclecticRondTotalDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticRondTotal e WHERE e.TotalID = @TotalID " +
                    "AND e.SpelarID = @SpelarID";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TotalID", DataTyp.Int, totalID.ToString()),
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
        /// Hämtar rad från tabellen EclecticRondTotal i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="TotalID">Aktuell EclecticTotal</param>
        /// <param name="SpelarID">Aktuell spelare</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticRondTotalDS HämtaEclecticRondTotal(int eclecticID)
        {
            EclecticRondTotalDS ds = new EclecticRondTotalDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* " +
                    "FROM EclecticTotal et " +
                    "INNER JOIN EclecticRondTotal e ON e.TotalID = et.TotalID " +
                    "WHERE et.EclecticID = @EclecticID";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@EclecticID", DataTyp.Int, eclecticID.ToString())
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
        /// Hämtar rad från tabellen EclecticRondTotal i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="eclecticID">Aktuell Eclectic</param>
        /// <param name="banaNr">Aktuell bana</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticRondTotalDS HämtaResultatlista(int eclecticID, int banaNr)
        {
            EclecticRondTotalDS ds = new EclecticRondTotalDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.TotalID, e.SpelarID, s.Namn, et.ErhallnaSlag, e.HalNr, bh.Par, bh.Hcp, e.AntalSlag_Brutto, e.AntalSlag_Netto, e.AntalPoang " +
                    "FROM EclecticTotal et " +
                    "INNER JOIN EclecticRondTotal e ON e.TotalID = et.TotalID " +
                    "INNER JOIN Spelare s ON e.SpelarID = s.SpelarID " +
                    "INNER JOIN BanaHal bh ON bh.BanaNr = et.BanaNr AND bh.HalNr = e.HalNr " +
                    "WHERE et.EclecticID = @EclecticID AND et.BanaNr = @BanaNr";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@EclecticID", DataTyp.Int, eclecticID.ToString()),
                    new DatabasParameters("@BanaNr", DataTyp.Int, banaNr.ToString()),
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
        /// Ny EclecticRondTotal.
        /// </summary>
        /// <param name="eclecticRondTotal">EclecticRondTotal</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int SparaNyEclecticRondTotalAllaHal(List<EclecticRondTotal> eclecticRondTotal, ref string felID, ref string feltext)
        {
            int antalRader = 0;

            try
            {
                var sb = new StringBuilder();
                var parameters = new Dictionary<string, object>();
                int index = 0;

                sb.Append("INSERT INTO EclecticRondTotal(TotalID, SpelarID, HalNr, AntalSlag_Brutto, AntalSlag_Netto, AntalPoang, RondTotalUppdatDatum, Uppdaterad) VALUES ");

                foreach (var item in eclecticRondTotal)
                {
                    if (index > 0) sb.Append(", ");
                    sb.Append($"(@TotalID{index}, @SpelarID{index}, @HalNr{index}, @AntalSlag_Brutto{index}, @AntalSlag_Netto{index}, @AntalPoang{index}, @RondTotalUppdatDatum{index}, @Uppdaterad{index})");

                    parameters[$"@TotalID{index}"] = item.TotalID;
                    parameters[$"@SpelarID{index}"] = item.SpelarID;
                    parameters[$"@HalNr{index}"] = item.HalNr;
                    parameters[$"@AntalSlag_Brutto{index}"] = item.AntalSlag_Brutto;
                    parameters[$"@AntalSlag_Netto{index}"] = item.AntalSlag_Netto;
                    parameters[$"@AntalPoang{index}"] = item.AntalPoang;
                    parameters[$"@RondTotalUppdatDatum{index}"] = item.RondTotalUppdatDatum;
                    parameters[$"@Uppdaterad{index}"] = item.Uppdaterad;

                    index++;
                }

                DatabasAccess.SkapaTransaktion();
                antalRader = DatabasAccess.ExecuteNonQuery(sb.ToString(), parameters);
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
            return antalRader;
        }

        /// <summary>
        /// Uppdaterar EclecticRondTotal med förändrade data
        /// </summary>
        /// <param name="nyaRader">Den uppdaterade listan</param>
        /// <param name="gamlaRader">Lista med gamla värden</param>
        /// <param name="felID"></param>
        /// <param name="feltext"></param>
        public void UppdateraRondTotal(List<EclecticRondTotal> nyaRader, List<EclecticRondTotal> gamlaRader, ref string felID, ref string feltext)
        {
            DatabasAccess.SkapaTransaktion();

            string sql = @"UPDATE EclecticRondTotal SET 
                    AntalSlag_Brutto = @AntalSlag_Brutto,
                    AntalSlag_Netto = @AntalSlag_Netto,
                    AntalPoang = @AntalPoang,
                    RondTotalUppdatDatum = @RondTotalUppdatDatum,
                    Uppdaterad = 'J' 
                    WHERE TotalID = @TotalID AND SpelarID = @SpelarID AND HalNr = @HalNr";

            foreach (var ny in nyaRader)
            {
                var gammal = gamlaRader.FirstOrDefault(x =>
                    x.TotalID == ny.TotalID &&
                    x.SpelarID == ny.SpelarID &&
                    x.HalNr == ny.HalNr);

                if (gammal == null) continue;

                bool ändrad =
                    ny.AntalSlag_Brutto != gammal.AntalSlag_Brutto ||
                    ny.AntalSlag_Netto != gammal.AntalSlag_Netto ||
                    ny.AntalPoang != gammal.AntalPoang ||
                    ny.RondTotalUppdatDatum != gammal.RondTotalUppdatDatum;

                if (!ändrad) continue;

                var param = new Dictionary<string, object>
                {
                    ["@TotalID"] = ny.TotalID,
                    ["@SpelarID"] = ny.SpelarID,
                    ["@HalNr"] = ny.HalNr,
                    ["@AntalSlag_Brutto"] = ny.AntalSlag_Brutto,
                    ["@AntalSlag_Netto"] = ny.AntalSlag_Netto,
                    ["@AntalPoang"] = ny.AntalPoang,
                    ["@RondTotalUppdatDatum"] = ny.RondTotalUppdatDatum
                };

                DatabasAccess.ExecuteNonQuery(sql, param);
            }

            DatabasAccess.BekräftaTransaktion();
        }

        /// <summary>
        /// Ny EclecticRondTotal.
        /// </summary>
        /// <param name="EclecticTotal">EclecticTotal</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaEclecticRondTotal(List<EclecticRondTotal> eclecticRondTotal, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "UPDATE EclecticRondTotal " +
                    "SET AntalSlag_Brutto = @AntalSlag_Brutto, AntalSlag_Netto = @AntalSlag_Netto, " +
                    "AntalPoang = @AntalPoang, RondTotalUppdatDatum = @RondTotalUppdatDatum, Uppdaterad = @Uppdaterad " +
                    "WHERE TotalID = @TotalID AND SpelarID = @SpelarID AND HalNr = @HalNr";

                //for (int i = 0; i < eclecticRondTotal.Count; i++)
                foreach (EclecticRondTotal eclecticRond in eclecticRondTotal)
                {
                      List < DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@TotalID", DataTyp.Int, eclecticRond.TotalID.ToString()),
                        new DatabasParameters("@SpelarID", DataTyp.Int, eclecticRond.SpelarID.ToString()),
                        new DatabasParameters("@HalNr", DataTyp.Int, eclecticRond.HalNr.ToString()),
                        new DatabasParameters("@AntalSlag_Brutto", DataTyp.Int, eclecticRond.AntalSlag_Brutto.ToString()),
                        new DatabasParameters("@AntalSlag_Netto", DataTyp.Int, eclecticRond.AntalSlag_Netto.ToString()),
                        new DatabasParameters("@AntalPoang", DataTyp.Int, eclecticRond.AntalPoang.ToString()),
                        new DatabasParameters("@RondTotalUppdatDatum", DataTyp.VarChar, eclecticRond.RondTotalUppdatDatum.ToString()),
                        new DatabasParameters("@Uppdaterad", DataTyp.VarChar, eclecticRond.Uppdaterad.ToString())
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
