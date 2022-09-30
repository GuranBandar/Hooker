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
    /// Datalagerklass för Golfklubb
    /// </summary>
    public sealed class GolfklubbData : AbstractDataLager
    {
        /// <summary>
        /// Hämtar rad från tabellen Golfklubb i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="golfklubbNr">Aktuell Tavling</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public GolfklubbDS HämtaGolfklubb(int golfklubbNr)
        {
            GolfklubbDS ds = new GolfklubbDS();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@GolfklubbNr", DataTyp.Int, golfklubbNr.ToString())
                };
                DatabasAccess.ExecuteSP("GetGolfklubbByPrimaryKey", dbParameters, ds);
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
        /// Hämtar rad från tabellen Golfklubb i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="namn">Aktuellt namn</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public GolfklubbDS HämtaGolfklubb(string namn)
        {
            GolfklubbDS ds = new GolfklubbDS();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@Namn", DataTyp.String, namn)
                };
                DatabasAccess.ExecuteSP("GetGolfklubbByNamn", dbParameters, ds);
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
        /// Hämtar rad/-er från tabellen Golfklubb i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="sqlSok">Eventuellt where-villkor</param>
        /// <returns>Otypat dataset med efterfrågat data</returns>
        public DataSet SökGolfklubb(string sqlSok)
        {
            DataSet GolfklubbDS = new DataSet();
            string sql = "SELECT g.*, k1.Varde AS Land, k2.Varde AS Distrikt " +
                "FROM Golfklubb g " +
                "LEFT OUTER JOIN Koder k1 ON k1.Typ = '4' AND k1.Argument = g.Landkod " +
                "LEFT OUTER JOIN Koder k2 ON k2.Typ = '1' AND k2.Argument = g.Distriktkod " +
                sqlSok.ToString() +
                " ORDER BY g.GolfklubbNamn";
            try
            {
                GolfklubbDS = DatabasAccess.RunSql(sql);
                GolfklubbDS.Tables[0].TableName = "Golfklubb";
                return GolfklubbDS;
            }
            catch (HookerException hex)
            {
                throw hex;
            }
            finally
            {
                DatabasAccess.Dispose();
            }
        }

        /// <summary>
        /// Ta bort i Golfklubb.
        /// </summary>
        /// <param name="golfklubb">Golfklubb</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TabortGolfklubb(Golfklubb golfklubb, ref string felID, ref string feltext)
        {
            string sql;
            try
            {
                sql = "DELETE FROM Golfklubb WHERE GolfklubbNr = @GolfklubbNr";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@GolfklubbNr", DataTyp.Int, golfklubb.GolfklubbNr.ToString())
                };

                DatabasAccess.SkapaTransaktion();
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
        /// Ny Golfklubb.
        /// </summary>
        /// <param name="Golfklubb">Golfklubb</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int SparaNyGolfklubb(Golfklubb Golfklubb, ref string felID, ref string feltext)
        {
            int nyttGolfklubbNr;
            DataSet ds = new DataSet();
            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@GolfklubbNamn", DataTyp.VarChar, Golfklubb.GolfklubbNamn),
                    new DatabasParameters("@AdressBesok", DataTyp.VarChar, Golfklubb.AdressBesok),
                    new DatabasParameters("@AdressOrt", DataTyp.VarChar, Golfklubb.AdressOrt),
                    new DatabasParameters("@TelBokning", DataTyp.VarChar, Golfklubb.TelBokning),
                    new DatabasParameters("@TelKansli", DataTyp.VarChar, Golfklubb.TelKansli),
                    new DatabasParameters("@Epost", DataTyp.VarChar, Golfklubb.Epost),
                    new DatabasParameters("@Hemsida", DataTyp.VarChar, Golfklubb.Hemsida),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, Golfklubb.UppdatDatum.ToString()),
                    new DatabasParameters("@Distriktkod", DataTyp.Char, Golfklubb.Distriktkod),
                    new DatabasParameters("@Landkod", DataTyp.Char, Golfklubb.Landkod),
                    new DatabasParameters("@Notering", DataTyp.VarChar, Golfklubb.Notering)
                };
                DatabasAccess.SkapaTransaktion();
                ds = DatabasAccess.ExecuteSP("InsertGolfklubb", dbParameters);
                nyttGolfklubbNr = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
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
            return nyttGolfklubbNr;
        }

        /// <summary>
        /// Sparar i Golfklubb.
        /// </summary>
        /// <param name="Golfklubb">Golfklubb</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaGolfklubb(Golfklubb Golfklubb, ref string felID, ref string feltext)
        {
            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@GolfklubbNamn", DataTyp.VarChar, Golfklubb.GolfklubbNamn),
                    new DatabasParameters("@AdressBesok", DataTyp.VarChar, Golfklubb.AdressBesok),
                    new DatabasParameters("@AdressOrt", DataTyp.VarChar, Golfklubb.AdressOrt),
                    new DatabasParameters("@TelBokning", DataTyp.VarChar, Golfklubb.TelBokning),
                    new DatabasParameters("@TelKansli", DataTyp.VarChar, Golfklubb.TelKansli),
                    new DatabasParameters("@Epost", DataTyp.VarChar, Golfklubb.Epost),
                    new DatabasParameters("@Hemsida", DataTyp.VarChar, Golfklubb.Hemsida),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, Golfklubb.UppdatDatum.ToString()),
                    new DatabasParameters("@Distriktkod", DataTyp.Char, Golfklubb.Distriktkod),
                    new DatabasParameters("@Landkod", DataTyp.Char, Golfklubb.Landkod),
                    new DatabasParameters("@Notering", DataTyp.VarChar, Golfklubb.Notering),
                    new DatabasParameters("@GolfklubbNr", DataTyp.Int, Golfklubb.GolfklubbNr.ToString())
                };
                DatabasAccess.SkapaTransaktion();
                DatabasAccess.ExecuteSP("UpdateGolfklubb", dbParameters);
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
