using GemensamService;
using Hooker.Affärsobjekt;
using Hooker.Dataset;
using Hooker.Gemensam;
using System;
using System.Collections.Generic;

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
        /// <param name="TotalID">Aktuell EclecticTotal</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        //public EclecticRondTotalDS HämtaEclecticRondTotal(int TotalID)
        //{
        //    EclecticRondTotalDS ds = new EclecticRondTotalDS();
        //    string sql;

        //    try
        //    {
        //        ds.EnforceConstraints = false;
        //        sql = "SELECT e.* FROM EclecticRondTotal e WHERE e.TotalID = @TotalID";

        //        List<DatabasParameters> dbParameters = new List<DatabasParameters>()
        //        {
        //            new DatabasParameters("@TotalID", DataTyp.Int, TotalID.ToString())
        //        };
                
        //        DatabasAccess.FyllEnkeltDataSet(sql, dbParameters, ds);
        //        return ds;
        //    }
        //    catch (HookerException hex)
        //    {
        //        throw hex;
        //    }
        //    finally
        //    {
        //        if (DatabasAccess != null)
        //        {
        //            DatabasAccess.Dispose();
        //        }
        //    }
        //}

        /// <summary>
        /// Hämtar rad från tabellen EclecticRondTotal i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="TotalID">Aktuell EclecticTotal</param>
        /// <param name="SpelarID">Aktuell spelare</param>
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
        /// <param name="TotalID">Aktuell EclecticTotal</param>
        /// <param name="SpelarID">Aktuell spelare</param>
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
        /// <param name="TotalID">Aktuell EclecticTotal</param>
        /// <param name="SpelarID">Aktuell spelare</param>
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
        /// <param name="EclecticTotal">EclecticTotal</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaNyEclecticRondTotalAllaHal(List<EclecticRondTotal> eclecticRondTotal, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                for (int i = 0; i < eclecticRondTotal.Count; i++)
                {
                    sql = "INSERT INTO EclecticRondTotal(TotalID, SpelarID, HalNr, Par, Hcp, AntalSlag_Brutto, AntalSlag_Netto, AntalPoang, " +
                        "RondTotalUppdatDatum, Uppdaterad) " +
                        "VALUES " +
                        "(@TotalID, @SpelarID, @HalNr, @Par, @Hcp, @AntalSlag_Brutto, @AntalSlag_Netto, @AntalPoang, " +
                        "@RondTotalUppdatDatum, @Uppdaterad)";

                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@TotalID", DataTyp.Int, eclecticRondTotal[i].TotalID.ToString()),
                        new DatabasParameters("@SpelarID", DataTyp.Int, eclecticRondTotal[i].SpelarID.ToString()),
                        new DatabasParameters("@HalNr", DataTyp.Int, eclecticRondTotal[i].HalNr.ToString()),
                        new DatabasParameters("@Par", DataTyp.Int, eclecticRondTotal[i].Par.ToString()),
                        new DatabasParameters("@Hcp", DataTyp.Int, eclecticRondTotal[i].Hcp.ToString()),
                        new DatabasParameters("@AntalSlag_Brutto", DataTyp.Int, eclecticRondTotal[i].AntalSlag_Brutto.ToString()),
                        new DatabasParameters("@AntalSlag_Netto", DataTyp.Int, eclecticRondTotal[i].AntalSlag_Netto.ToString()),
                        new DatabasParameters("@AntalPoang", DataTyp.Int, eclecticRondTotal[i].AntalPoang.ToString()),
                        new DatabasParameters("@RondTotalUppdatDatum", DataTyp.VarChar, eclecticRondTotal[i].RondTotalUppdatDatum.ToString()),
                        new DatabasParameters("@Uppdaterad", DataTyp.VarChar, eclecticRondTotal[i].Uppdaterad.ToString())
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
                    "SET Par = @Par, Hcp = @Hcp, AntalSlag_Brutto = @AntalSlag_Brutto, AntalSlag_Netto = @AntalSlag_Netto, " +
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
                        new DatabasParameters("@Par", DataTyp.Int, eclecticRond.Par.ToString()),
                        new DatabasParameters("@Hcp", DataTyp.Int, eclecticRond.Hcp.ToString()),
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
