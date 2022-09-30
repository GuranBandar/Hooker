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
    ///     Datalagerklass för Koder
    /// </summary>
    public sealed class KoderData : AbstractDataLager
    {

        /// <summary>
        ///     Söker i Koder
        /// </summary>
        /// <param name="sqlSök">Sökvillkor för läsningen</param>
        /// <returns>Dataset med aktuella rader</returns>
        public KoderDS SökKoder(string sqlSök)
        {
            string sql = "";
            KoderDS ds = new KoderDS();

            try
            {
                //Skapa sql:en
                sql = "SELECT * FROM Koder" + sqlSök.ToString();
                List<DatabasParameters> dbParameters = new List<DatabasParameters>();
                DatabasAccess.FyllEnkeltDataSet(sql, dbParameters, ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw new HookerException(ex.Message, ex);
            }
            finally
            {
                DatabasAccess.Dispose();
            }
        }

        /// <summary>
        ///     Hämta Kod med mha nyckel
        /// </summary>
        /// <param name="typ">Typ av kod</param>
        /// <param name="argument">Nyckel till koden</param>
        /// <returns></returns>
        public KoderDS HämtaKoder(int typ, string argument)
        {
            string sql;
            KoderDS ds = new KoderDS();

            try
            {
                //Skapa sql:en
                sql = "SELECT * FROM Koder WHERE Typ = @Typ AND Argument = @Argument";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@Typ", DataTyp.Int, typ.ToString()),
                    new DatabasParameters("@Argument", DataTyp.VarChar, argument)
                };
                DatabasAccess.FyllEnkeltDataSet(sql, dbParameters, ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw new HookerException(ex);
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
        ///     Hämtar högsta Argument för typen från tabellen Koder i aktuell databas.
        /// </summary>
        /// <returns>Dataset med efterfrågat data</returns>
        public DataSet HämtaMaxArgument(Kodtabell typ, string sqlSök)
        {
            string sql;
            DataSet ds = new DataSet();

            try
            {
                if (typ == Kodtabell.Alla_koder)
                {
                    sql = "SELECT MAX(Typ) AS Max FROM Koder";
                }
                else if (typ == Kodtabell.Distrikt)
                {
                    sql = "SELECT Argument AS Max FROM Koder";
                    sql = sql + sqlSök.ToString();
                }
                else
                {
                    sql = "SELECT MAX(Argument) AS Max FROM Koder";
                    sql = sql + sqlSök.ToString();
                }

                return DatabasAccess.RunSql(sql);
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
        /// Tar bort Kod i tabellen Koder
        /// </summary>
        /// <param name="koder">Objekt med aktuella värden</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBortKod(Koder koder, ref string felID, ref string feltext)
        {
            string sql;
            DatabasAccess.SkapaTransaktion();

            try
            {
                sql = "DELETE FROM Koder WHERE Typ = @Typ AND Argument = @Argument";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@Typ", DataTyp.Int, koder.Typ.ToString()),
                    new DatabasParameters("@Argument", DataTyp.VarChar, koder.Argument)
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

        /// <summary>
        ///     Sparar i tabellen Koder
        /// </summary>
        /// <param name="koder">Dataset med aktuella värden</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaNyKod(Koder koder, ref string felID, ref string feltext)
        {
            string sql;
            DatabasAccess.SkapaTransaktion();

            try
            {
                sql = "INSERT INTO Koder(Typ, Argument, Varde, IntervallMin, IntervallMax, UppdatDatum) " +
                    "Values(@Typ, @Argument, @Varde, @IntervallMin, @IntervallMax, @Uppdatdatum)";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@Typ", DataTyp.Int, koder.Typ.ToString()),
                    new DatabasParameters("@Argument", DataTyp.VarChar, koder.Argument),
                    new DatabasParameters("@Varde", DataTyp.VarChar, koder.Varde),
                    new DatabasParameters("@IntervallMin", DataTyp.Decimal, koder.IntervallMin.ToString()),
                    new DatabasParameters("@IntervallMax", DataTyp.Decimal, koder.IntervallMax.ToString()),
                    new DatabasParameters("@Uppdatdatum", DataTyp.SmallDateTime, DateTime.Today.ToString())
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

        /// <summary>
        ///     Sparar i tabellen Koder
        /// </summary>
        /// <param name="koder">Dataset med aktuella värden</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaKoder(Koder koder, ref string felID, ref string feltext)
        {
            string sql;
            DatabasAccess.SkapaTransaktion();

            try
            {
                sql = "UPDATE Koder SET Varde = @Varde, IntervallMin = @IntervallMin, " +
                    "IntervallMax = @IntervallMax, UppdatDatum = @UppdatDatum " +
                        "WHERE Typ = @Typ AND Argument = @Argument";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@Typ", DataTyp.Int, koder.Typ.ToString()),
                    new DatabasParameters("@Argument", DataTyp.VarChar, koder.Argument),
                    new DatabasParameters("@Varde", DataTyp.VarChar, koder.Varde),
                    new DatabasParameters("@IntervallMin", DataTyp.Decimal, koder.IntervallMin.ToString()),
                    new DatabasParameters("@IntervallMax", DataTyp.Decimal, koder.IntervallMax.ToString()),
                    new DatabasParameters("@Uppdatdatum", DataTyp.SmallDateTime, DateTime.Today.ToString())
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
