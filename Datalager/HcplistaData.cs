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
    /// Datalagerklass för Hcplista
    /// </summary>
    public sealed class HcplistaData : AbstractDataLager
    {
        /// <summary>
        /// Hämta Hcplista som finns registrerad på aktuell spelare
        /// </summary>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <returns>Typat dataset med alla registrerade hcprundor på spelaren</returns>
        public HcplistaDS HämtaHcplista(int spelarID)
        {
            HcplistaDS ds = new HcplistaDS();
            string sql;

            try
            {
                sql = "SELECT h.* FROM Hcplista h WHERE h.SpelarID = @SpelarID";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
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
        /// Hämta Hcplista som finns registrerad på aktuell spelare
        /// </summary>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <param name="fromDatum">Aktuellt from datum</param>
        /// <param name="tomDatum">Aktuellt tom datum</param>
        /// <returns>Typat dataset med alla registrerade hcprundor på spelaren</returns>
        public HcplistaDS HämtaHcplista(int spelarID, DateTime fromDatum, DateTime tomDatum)
        {
            HcplistaDS ds = new HcplistaDS();
            string sql;

            try
            {
                sql = "SELECT h.* FROM Hcplista h WHERE h.SpelarID = @SpelarID " +
                    "AND Datum BETWEEN @FromDatum AND @TomDatum " +
                    "ORDER BY h.Datum";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@SpelarID", DataTyp.Int, spelarID.ToString()),
                    new DatabasParameters("@FromDatum", DataTyp.SmallDateTime, fromDatum.ToString()),
                    new DatabasParameters("@TomDatum", DataTyp.SmallDateTime, tomDatum.ToString())
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
        /// Ny Hcplista.
        /// </summary>
        /// <param name="Hcplista">Hcplista</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int SparaNyHcplista(Hcplista Hcplista, ref string felID, ref string feltext)
        {
            int nyttHcplistaID;
            DataSet ds = new DataSet();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@Typ", DataTyp.VarChar, Hcplista.Typ),
                    new DatabasParameters("@SpelarID", DataTyp.Int, Hcplista.SpelarID.ToString()),
                    new DatabasParameters("@RundaNr", DataTyp.Int, Hcplista.RundaNr.ToString()),
                    new DatabasParameters("@Datum", DataTyp.SmallDateTime, Hcplista.Datum.ToString()),
                    new DatabasParameters("@AntalSlag", DataTyp.Int, Hcplista.AntalSlag.ToString()),
                    new DatabasParameters("@AntalPoang", DataTyp.Int, Hcplista.AntalPoang.ToString()),
                    new DatabasParameters("@Hcp", DataTyp.Decimal, Hcplista.Hcp.ToString()),
                    new DatabasParameters("@NyttHcp", DataTyp.Decimal, Hcplista.NyttHcp.ToString()),
                    new DatabasParameters("@PlusMinus", DataTyp.Decimal, Hcplista.PlusMinus.ToString()),
                    new DatabasParameters("@Notering", DataTyp.String, Hcplista.Notering),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, Hcplista.UppdatDatum.ToString())
                };
                DatabasAccess.SkapaTransaktion();
                ds = DatabasAccess.ExecuteSP("InsertHcplista", dbParameters);
                nyttHcplistaID = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
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
            return Convert.ToInt32(nyttHcplistaID);
        }

        ///// <summary>
        ///// Ny Hcplista.
        ///// </summary>
        ///// <param name="spelare">Aktuell spelare</param>
        ///// <param name="typ">Typ av ändring</param>
        ///// <param name="hcp">Tidigare hcp</param>
        ///// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        ///// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        //public int SparaNyHcplista(Spelare spelare, string typ, decimal hcp, 
        //    ref string felID, ref string feltext)
        //{
        //    object nyttHcplistaID;
        //    string sql;
        //    int noll = 0;
        //    decimal plusMinus = spelare.ExaktHcp - hcp;
        //    string notering = "Manuel revidering";
        //    try
        //    {
        //        sql = "INSERT INTO Hcplista (Typ, SpelarID, RundaNr, Datum, AntalSlag, AntalPoang, " +
        //            "Hcp, NyttHcp, PlusMinus, Notering, UppdatDatum) " +
        //            "VALUES (@Typ, @SpelarID, @RundaNr, @Datum, @AntalSlag, @AntalPoang, @Hcp ," +
        //            "@NyttHcp, @PlusMinus, @Notering, @UppdatDatum); " +
        //            "SELECT LAST_INSERT_ID();";
        //        List<DatabasParameters> dbParameters = new List<DatabasParameters>()
        //        {
        //            new DatabasParameters("@Typ", DataTyp.VarChar, typ),
        //            new DatabasParameters("@SpelarID", DataTyp.Int, spelare.AktuelltSpelarID.ToString()),
        //            new DatabasParameters("@RundaNr", DataTyp.Int, noll.ToString()),
        //            new DatabasParameters("@Datum", DataTyp.SmallDateTime, spelare.Revisionsdatum.ToString()),
        //            new DatabasParameters("@AntalSlag", DataTyp.Int, noll.ToString()),
        //            new DatabasParameters("@AntalPoang", DataTyp.Int, noll.ToString()),
        //            new DatabasParameters("@Hcp", DataTyp.Decimal, hcp.ToString()),
        //            new DatabasParameters("@NyttHcp", DataTyp.Decimal, spelare.ExaktHcp.ToString()),
        //            new DatabasParameters("@PlusMinus", DataTyp.Decimal, plusMinus.ToString()),
        //            new DatabasParameters("@Notering", DataTyp.String, notering),
        //            new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, spelare.UppdatDatum.ToString())
        //        };
        //        DatabasAccess.SkapaTransaktion();
        //        nyttHcplistaID = DatabasAccess.RunScalar(sql, dbParameters);
        //        DatabasAccess.BekräftaTransaktion();
        //    }
        //    catch (HookerException hex)
        //    {
        //        felID = "SQLERROR";
        //        feltext = hex.Message.ToString();
        //        if (DatabasAccess.HarAktivTransaktion())
        //        {
        //            DatabasAccess.ÅngraTransaktion();
        //        }
        //        throw hex;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (DatabasAccess.HarAktivTransaktion())
        //        {
        //            DatabasAccess.ÅngraTransaktion();
        //        }
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (DatabasAccess != null)
        //        {
        //            DatabasAccess.Dispose();
        //        }
        //    }
        //    return Convert.ToInt32(nyttHcplistaID);
        //}

        /// <summary>
        /// Sparar i Hcplista.
        /// </summary>
        /// <param name="Hcplista">Hcplista</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaHcplista(Hcplista Hcplista, ref string felID, ref string feltext)
        {
            string sql;
            try
            {
                sql = "UPDATE Hcplista SET Typ = @Typ, SpelarID = @SpelarId, RundaNr = @RundaNr, " +
                        "Datum = @Datum, AntalSlag = @AntalSlag, AntalPoang = @AntalPoang, Hcp = @Hcp, " +
                        "NyttHcp = @NyttHcp, PlusMinus = @PlusMinus, Notering = @Notering, " +
                        "UppdatDatum = @UppdatDatum] " +
                        "WHERE HcplistaID = @HcplistaID";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
            {
                    new DatabasParameters("@HcplistaID", DataTyp.Int, Hcplista.HcplistaID.ToString()),
                    new DatabasParameters("@Typ", DataTyp.VarChar, Hcplista.Typ),
                    new DatabasParameters("@SpelarID", DataTyp.Int, Hcplista.SpelarID.ToString()),
                    new DatabasParameters("@RundaNr", DataTyp.Int, Hcplista.RundaNr.ToString()),
                    new DatabasParameters("@Datum", DataTyp.SmallDateTime, Hcplista.Datum.ToString()),
                    new DatabasParameters("@AntalSlag", DataTyp.Int, Hcplista.AntalSlag.ToString()),
                    new DatabasParameters("@AntalPoang", DataTyp.Int, Hcplista.AntalPoang.ToString()),
                    new DatabasParameters("@Hcp", DataTyp.Decimal, Hcplista.Hcp.ToString()),
                    new DatabasParameters("@NyttHcp", DataTyp.Decimal, Hcplista.NyttHcp.ToString()),
                    new DatabasParameters("@PlusMinus", DataTyp.Decimal, Hcplista.PlusMinus.ToString()),
                    new DatabasParameters("@Notering", DataTyp.String, Hcplista.Notering),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, Hcplista.UppdatDatum.ToString())
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
        /// Ta bort i Hcplista.
        /// </summary>
        /// <param name="Hcplista">Hcplista</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TabortHcplista(Hcplista Hcplista, ref string felID, ref string feltext)
        {
            string sql;
            try
            {
                sql = "DELETE FROM Hcplista WHERE HcplistaID = @HcplistaID";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@HcplistaID", DataTyp.Int, Hcplista.HcplistaID.ToString())
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
    }
}
