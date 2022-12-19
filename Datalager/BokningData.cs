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
    /// Datalagerklass för Bokningarna
    /// </summary>
    public sealed class BokningData : AbstractDataLager
    {
        /// <summary>
        /// Hämtar rad från tabellen BokningDag i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="BokningID">Aktuell bokning</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public BokningDagDS HämtaBokningDag(int BokningID)
        {
            BokningDagDS ds = new BokningDagDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT b.* FROM BokningDag b WHERE b.BokningID = @BokningID";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@BokningID", DataTyp.Int, BokningID.ToString())
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
        /// Hämtar rad från tabellen BokningsLista i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="BokningID">Aktuell bokning</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public BokningsListaDS HämtaBokningsLista(int BokningID)
        {
            BokningsListaDS ds = new BokningsListaDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT b.* FROM BokningsLista b WHERE b.BokningID = @BokningID";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@BokningID", DataTyp.Int, BokningID.ToString())
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
        /// Hämtar rad från tabellen BokningDag i aktuell databas med angiven nyckel.
        /// </summary>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public DataSet HämtaSistaBokning(string sqlSok)
        {
            DataSet bokningDagDS = new DataSet();
            string sql;

            try
            {
                sql = "SELECT b.BokningID FROM BokningDag b " +
                    sqlSok.ToString() +
                    " ORDER BY b.BokningID DESC";
                bokningDagDS = DatabasAccess.RunSql(sql);
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
            return bokningDagDS;
        }

        /// <summary>
        /// Hämtar rad från tabellen BokningDag i aktuell databas med start från
        /// sökt bokningsdatum.
        /// </summary>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public DataSet SearchBokning(string sqlSok)
        {
            DataSet bokningDagDS = new DataSet();
            string sql;

            try
            {
                sql = "SELECT b.* FROM BokningDag b" +
                    sqlSok.ToString() +
                    " ORDER BY b.Datum ASC";
                bokningDagDS = DatabasAccess.RunSql(sql);
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
            return bokningDagDS;
        }

        /// <summary>
        /// Ny Bokning.
        /// </summary>
        /// <param name="bokningDag">Bokningen</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int SparaNyBokning(BokningDag bokningDag, ref string felID, ref string feltext)
        {
            string sql;
            int nyttBokningID;

            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "INSERT INTO BokningDag(Bana, Datum, Tider, TisdagTorsdag, " +
                    "AnvandarNamnSkapad, SkapadDatum, AnvandarNamnUppdat, UppdatDatum, " +
                    "Notering)" +
                    "VALUES " +
                    "(@Bana, @Datum, @Tider, @TisdagTorsdag, " +
                    "@AnvandarNamnSkapad, @SkapadDatum, @AnvandarNamnUppdat, @UppdatDatum, " +
                    "@Notering)";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@Bana", DataTyp.VarChar, bokningDag.Bana.ToString()),
                    new DatabasParameters("@Datum", DataTyp.VarChar, bokningDag.Datum.ToString()),
                    new DatabasParameters("@Tider", DataTyp.VarChar, bokningDag.Tider.ToString()),
                    new DatabasParameters("@TisdagTorsdag", DataTyp.Int, bokningDag.TisdagTorsdag.ToString()),
                    new DatabasParameters("@AnvandarNamnSkapad", DataTyp.VarChar, bokningDag.AnvandarNamnSkapad.ToString()),
                    new DatabasParameters("@SkapadDatum", DataTyp.VarChar, bokningDag.SkapadDatum.ToString()),
                    new DatabasParameters("@AnvandarNamnUppdat", DataTyp.VarChar, bokningDag.AnvandarNamnUppdat.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.VarChar, bokningDag.UppdatDatum.ToString()),
                    new DatabasParameters("@Notering", DataTyp.VarChar, bokningDag.Notering.ToString())
                };
                DatabasAccess.RunSql(sql, dbParameters);
                sql = "SELECT LAST_INSERT_ID()";
                nyttBokningID = Convert.ToInt32(DatabasAccess.ExecuteScalar(sql));
                bokningDag.BokningID = nyttBokningID;
                DatabasAccess.BekräftaTransaktion();
                SparaNyBokningLIsta(bokningDag, ref felID, ref feltext);
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
            return nyttBokningID;
        }

        /// <summary>
        /// Ny Bokning.
        /// </summary>
        /// <param name="bokningDag">Bokningen</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaNyBokningLIsta(BokningDag bokningDag, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                for (int i = 0; i < bokningDag.bokningListas.Length; i++)
                {
                    sql = "INSERT INTO BokningsLista(BokningID, BollNr, SpelareNamn) " +
                        "VALUES " +
                        "(@BokningID, @BollNr, @SpelareNamn)";
                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@BokningID", DataTyp.Int, bokningDag.BokningID.ToString()),
                        new DatabasParameters("@Bollnr", DataTyp.VarChar, bokningDag.bokningListas[i].BollNr.ToString()),
                        new DatabasParameters("@SpelareNamn", DataTyp.VarChar, bokningDag.bokningListas[i].SpelareNamn.ToString())
                    };
                    DatabasAccess.RunSql(sql, dbParameters);
                }
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
        /// Sparar i BokningDag.
        /// </summary>
        /// <param name="bokningDag">Bokningen</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaBokningDag(BokningDag bokningDag, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "UPDATE BokningDag " +
                    "SET Bana = @Bana, Datum = @Datum, Tider = @Tider, " +
                    "TisdagTorsdag = @TisdagTorsdag, AnvandarNamnSkapad = @AnvandarNamnSkapad, " +
                    "AnvandarNamnUppdat = @AnvandarNamnUppdat, UppdatDatum = @UppdatDatum, " +
                    "Notering = @Notering " +
                    "WHERE BokningID = @BokningID";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@BokningID", DataTyp.Int, bokningDag.BokningID.ToString()),
                    new DatabasParameters("@Bana", DataTyp.VarChar, bokningDag.Bana.ToString()),
                    new DatabasParameters("@Datum", DataTyp.VarChar, bokningDag.Datum.ToString()),
                    new DatabasParameters("@Tider", DataTyp.VarChar, bokningDag.Tider.ToString()),
                    new DatabasParameters("@TisdagTorsdag", DataTyp.Int, bokningDag.TisdagTorsdag.ToString()),
                    new DatabasParameters("@AnvandarNamnSkapad", DataTyp.VarChar, bokningDag.AnvandarNamnSkapad.ToString()),
                    new DatabasParameters("@SkapadDatum", DataTyp.VarChar, bokningDag.SkapadDatum.ToString()),
                    new DatabasParameters("@AnvandarNamnUppdat", DataTyp.VarChar, bokningDag.AnvandarNamnUppdat.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.VarChar, bokningDag.UppdatDatum.ToString()),
                    new DatabasParameters("@Notering", DataTyp.VarChar, bokningDag.Notering.ToString())
                };
                DatabasAccess.RunSql(sql, dbParameters);
                DatabasAccess.BekräftaTransaktion();
                SparaBokningLIsta(bokningDag, ref felID, ref feltext);
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
        /// Spara BokningLista.
        /// </summary>
        /// <param name="bokningDag">Bokningen</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaBokningLIsta(BokningDag bokningDag, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                for (int i = 0; i < bokningDag.bokningListas.Length; i++)
                {
                    sql = "UPDATE BokningsLista SET BollNr = @Bollnr, " +
                        "SpelareNamn = @SpelareNamn " +
                        "WHERE BokningID = @BokningID AND BollNr = @BollNr";
                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@BokningID", DataTyp.Int, bokningDag.BokningID.ToString()),
                        new DatabasParameters("@Bollnr", DataTyp.VarChar, bokningDag.bokningListas[i].BollNr.ToString()),
                        new DatabasParameters("@SpelareNamn", DataTyp.VarChar, bokningDag.bokningListas[i].SpelareNamn.ToString())
                    };
                    DatabasAccess.RunSql(sql, dbParameters);
                }
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
