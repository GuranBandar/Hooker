using System;
using System.Collections.Generic;
using System.Data;
using Hooker.Affärsobjekt;
using Hooker.Dataset;
using Hooker.Gemensam;
using GemensamService;

namespace Hooker.Datalager
{
    /// <summary>
    /// Datalagerklass för Runda
    /// 
    /// Ska kolla om det går att göra en uppdatering paralellt här
    /// </summary>
    public sealed class RundaData : AbstractDataLager
    {
        /// <summary>
        /// Hämtar rad från tabellen Runda i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="rundaNr">Aktuell runda</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public RundaDS HämtaRunda(int rundaNr)
        {
            RundaDS ds = new RundaDS();
            string sql;

            try
            {
                sql = "SELECT r.* FROM Runda r WHERE r.RundaNr = @RundaNr";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RundaNr", DataTyp.Int, rundaNr.ToString())
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
        /// Kolla hur många rundor som finns registrerad på aktuell bana
        /// </summary>
        /// <param name="banaNr">Aktuell banaNr</param>
        /// <returns>Typat dataset med alla registrerade rundor på banan</returns>
        public RundaDS KollaAntaletRundor(int banaNr)
        {
            RundaDS ds = new RundaDS();
            string sql;

            try
            {
                sql = "SELECT r.* FROM Runda r WHERE r.BanaNr = @BanaNr";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@BanaNr", DataTyp.Int, banaNr.ToString())
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
        /// Kolla hur många rundor som finns registrerad på aktuell spelare
        /// </summary>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <returns>Typat dataset med alla registrerade rundor på spelaren</returns>
        public RundaDS KollaAntaletRundorForSpelare(int spelarID)
        {
            RundaDS ds = new RundaDS();
            string sql;

            try
            {
                sql = "SELECT r.* FROM Runda r WHERE r.SpelarID = @SpelarID";
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
        /// Hämtar rad/-er från tabellen Runda i aktuell databas med angivet wherevillkor.
        /// </summary>
        /// <param name="sqlSok">Eventuellt where-villkor</param>
        /// <returns>Otypat dataset med efterfrågat data</returns>
        public DataSet SökRunda(string sqlSok)
        {
            DataSet rundaDS = new DataSet();
            string sql;

            try
            {
                sql = "SELECT r.rundaNr, r.SpelarID, r.BanaNr, r.Datum, r.Notering, " +
                    "s.Namn AS 'Spelare', b.namn AS 'Bana', b.Aktuell, " +
                    "sum(rh.AntalPoang) AS 'Poäng', sum(rh.AntalSlag) AS 'Slag' " +
                    "FROM Runda r " +
                    "INNER JOIN Spelare s  ON r.SpelarID = s.SpelarID " +
                    "INNER JOIN Bana b ON r.BanaNr = b.BanaNr " +
                    "INNER JOIN RundaHal rh ON r.RundaNr = rh.RundaNr" +
                    sqlSok.ToString() +
                    " GROUP BY r.rundaNr, r.SpelarID, r.BanaNr, r.Datum, r.Notering, s.Namn, " +
                    "b.namn, b.Aktuell " +
                    "ORDER BY r.Datum";
                rundaDS = DatabasAccess.RunSql(sql);
                rundaDS.Tables[0].TableName = "Runda";
                return rundaDS;
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
        /// Hämtar rad/-er från tabellen Runda i aktuell databas med angivet wherevillkor.
        /// </summary>
        /// <param name="sqlSok">Eventuellt where-villkor</param>
        /// <returns>Otypat dataset med efterfrågat data</returns>
        public DataSet SökRundaGolfklubb(string sqlSok)
        {
            DataSet rundaDS = new DataSet();
            string sql;

            try
            {
                sql = "SELECT r.rundaNr, r.SpelarID, r.BanaNr, r.Datum, r.Notering, " +
                    "s.Namn AS 'Spelare', b.Namn AS 'Bana', b.Aktuell, sum(rh.AntalPoang) AS 'Poäng', " +
                    "sum(rh.AntalSlag) AS 'Slag' " +
                    "FROM Runda r " +
                    "INNER JOIN Spelare s  ON r.SpelarID = s.SpelarID " +
                    "INNER JOIN Bana b ON r.BanaNr = b.BanaNr " +
                    "INNER JOIN Golfklubb g ON g.GolfklubbNr = b.GolfklubbNr " +
                    "INNER JOIN RundaHal rh ON r.RundaNr = rh.RundaNr" +
                    sqlSok.ToString() +
                    " GROUP BY r.rundaNr, r.SpelarID, r.BanaNr, r.Datum, r.Notering, s.Namn, b.Namn, b.Aktuell " +
                    "ORDER BY r.Datum";
                rundaDS = DatabasAccess.RunSql(sql);
                rundaDS.Tables[0].TableName = "Runda";
                return rundaDS;
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
        /// Hämtar högsta RundaNr från tabellen Runda i aktuell databas.
        /// </summary>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public DataSet HämtaMaxRundaNr()
        {
            DataSet rundaDS = new DataSet();
            string sql;

            try
            {
                sql = "SELECT MAX(RundaNr) AS 'Max' FROM Runda";
                rundaDS = DatabasAccess.RunSql(sql);
                rundaDS.Tables[0].TableName = "Runda";
                return rundaDS;
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
        /// Hämta Runda, rundans alla RundaHal samt Redovisning för angivet rundaNr.
        /// </summary>
        /// <param name="rundaNr">Rundans nr</param>
        /// <returns>Ett sammansatt typat dataset med aktuell information</returns>
        public RundaRundaHalRedovisningSDS HämtaRundaRundaHalRedovisning(int rundaNr)
        {
            RundaRundaHalRedovisningSDS ds = new RundaRundaHalRedovisningSDS();
            string sql;

            try
            {
                sql = "SELECT * FROM Runda WHERE RundaNR = @RundaNr" + ";" +
                    " SELECT * FROM RundaHal WHERE RundaNr = @RundaNr" + ";" +
                    " SELECT * FROM Redovisning WHERE RundaNr = @RundaNr" + ";";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RundaNr", DataTyp.Int, rundaNr.ToString())
                };
                DatabasAccess.FyllSammansattDataSet(sql, dbParameters, ds);
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
        /// Ta bort angiven runda
        /// </summary>
        /// <param name="runda">Rundaobjekt</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBortRunda(Runda runda, ref string felID, ref string feltext)
        {
            string sql;
                
            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "DELETE FROM Runda WHERE RundaNr = @RundaNr";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RundaNr", DataTyp.Int, runda.RundaNr.ToString())
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
        /// Ny Runda.
        /// </summary>
        /// <param name="runda">Runda</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaNyRunda(Runda runda, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "INSERT INTO Runda (RundaNr, Datum, SpelarID, ExaktHcp, ErhallnaSlag, Tee" +
                    ", BanaNr, Tavlingsrond, Placering, Sallskapsrond, Hcprond" +
                    ", Notering, UppdatDatum, Niohalsrond, Markor) " +
                    "VALUES " +
                    "(@RundaNr, @Datum, @SpelarID, @ExaktHcp, @ErhallnaSlag, @Tee, @BanaNr" +
                    ", @Tavlingsrond, @Placering, @Sallskapsrond, @Hcprond" +
                    ", @Notering, @UppdatDatum, @Niohalsrond, @Markor)";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RundaNr", DataTyp.Int, runda.RundaNr.ToString()),
                    new DatabasParameters("@Datum", DataTyp.SmallDateTime, runda.Datum.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, runda.SpelarID.ToString()),
                    new DatabasParameters("@ExaktHcp", DataTyp.Decimal,  runda.ExaktHcp.ToString()),
                    new DatabasParameters("@ErhallnaSlag", DataTyp.Int, runda.ErhallnaSlag.ToString()),
                    new DatabasParameters("@Tee", DataTyp.Char, runda.Tee),
                    new DatabasParameters("@BanaNr", DataTyp.Int, runda.BanaNr.ToString()),
                    new DatabasParameters("@Tavlingsrond", DataTyp.Char, runda.Tavlingsrond),
                    new DatabasParameters("@Placering", DataTyp.Int, runda.Placering.ToString()),
                    new DatabasParameters("@Sallskapsrond", DataTyp.Char, runda.Sallskapsrond),
                    new DatabasParameters("@Hcprond", DataTyp.Char, runda.Hcprond),
                    new DatabasParameters("@Notering", DataTyp.VarChar, runda.Notering),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, runda.UppdatDatum.ToString()),
                    new DatabasParameters("@Niohalsrond", DataTyp.Char, runda.Niohalsrond),
                    new DatabasParameters("@Markor", DataTyp.Int, runda.Markor.ToString())
                };
                DatabasAccess.RunSql(sql, dbParameters);
                SparaNyRundaHal(runda, ref felID, ref feltext);
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
        /// Ny Runda.
        /// </summary>
        /// <param name="runda">Runda</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        private void SparaNyRundaHal(Runda runda, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                //DatabasAccess.SkapaTransaktion();
                for (int i = 0; i < runda.RundaHal.Length; i++)
                {
                    sql = " INSERT INTO RundaHal (RundaNr, Halnr, AntalSlag, AntalPoang, AntalPuttar" +
                        ", FwTraff, GrTraff, AntalPlikt) " +
                        "VALUES " +
                        "(@RundaNr, @Halnr, @AntalSlag, @AntalPoang, @AntalPuttar" +
                        ", @FwTraff, @GrTraff, @AntalPlikt)";
                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@RundaNr", DataTyp.Int, runda.RundaNr.ToString()),
                        new DatabasParameters("@Halnr", DataTyp.Int, runda.RundaHal[i].HalNr.ToString()),
                        new DatabasParameters("@AntalSlag", DataTyp.Int, runda.RundaHal[i].AntalSlag.ToString()),
                        new DatabasParameters("@AntalPoang", DataTyp.Int, runda.RundaHal[i].AntalPoang.ToString()),
                        new DatabasParameters("@AntalPuttar", DataTyp.Int, runda.RundaHal[i].AntalPuttar.ToString()),
                        new DatabasParameters("@FwTraff", DataTyp.Char, runda.RundaHal[i].FwTraff),
                        new DatabasParameters("@GrTraff", DataTyp.Char, runda.RundaHal[i].GrTraff),
                        new DatabasParameters("@AntalPlikt", DataTyp.Int, runda.RundaHal[i].AntalPlikt.ToString())
                    };
                    DatabasAccess.RunSql(sql, dbParameters);
                }
                //DatabasAccess.BekräftaTransaktion();
            }
            catch (HookerException hex)
            {
                felID = "SQLERROR";
                feltext = hex.Message.ToString();
                throw hex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// Sparar i Runda.
        /// </summary>
        /// <param name="runda">Runda</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaRunda(Runda runda, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "UPDATE Runda " +
                    "SET Datum = @Datum, SpelarID = @SpelarID" +
                    ", ExaktHcp = @ExaktHcp, ErhallnaSlag = @ErhallnaSlag, Tee = @Tee" +
                    ", BanaNr = @BanaNr, Tavlingsrond = @Tavlingsrond, Placering = @Placering" +
                    ", Sallskapsrond = @Sallskapsrond, Hcprond = @Hcprond, Notering = @Notering" +
                    ", UppdatDatum = @UppdatDatum, Niohalsrond = @Niohalsrond, Markor = @Markor " +
                    "WHERE RundaNr = @RundaNr";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RundaNr", DataTyp.Int, runda.RundaNr.ToString()),
                    new DatabasParameters("@Datum", DataTyp.SmallDateTime, runda.Datum.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, runda.SpelarID.ToString()),
                    new DatabasParameters("@ExaktHcp", DataTyp.Decimal,  runda.ExaktHcp.ToString()),
                    new DatabasParameters("@ErhallnaSlag", DataTyp.Int, runda.ErhallnaSlag.ToString()),
                    new DatabasParameters("@Tee", DataTyp.Char, runda.Tee),
                    new DatabasParameters("@BanaNr", DataTyp.Int, runda.BanaNr.ToString()),
                    new DatabasParameters("@Tavlingsrond", DataTyp.Char, runda.Tavlingsrond),
                    new DatabasParameters("@Placering", DataTyp.Int, runda.Placering.ToString()),
                    new DatabasParameters("@Sallskapsrond", DataTyp.Char, runda.Sallskapsrond),
                    new DatabasParameters("@Hcprond", DataTyp.Char, runda.Hcprond),
                    new DatabasParameters("@Notering", DataTyp.VarChar, runda.Notering),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, runda.UppdatDatum.ToString()),
                    new DatabasParameters("@Niohalsrond", DataTyp.Char, runda.Niohalsrond),
                    new DatabasParameters("@Markor", DataTyp.Int, runda.Markor.ToString())
                };
                DatabasAccess.RunSql(sql, dbParameters);
                DatabasAccess.BekräftaTransaktion();

                SparaRundaHal(runda, ref felID, ref feltext);
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
        /// Uppdatera i RundaHal.
        /// </summary>
        /// <param name="runda">Runda</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        private void SparaRundaHal(Runda runda, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                for (int i = 0; i < runda.RundaHal.Length; i++)
                {
                    sql = "UPDATE RundaHal SET AntalSlag = @AntalSlag, AntalPoang = @AntalPoang" +
                        ", AntalPuttar = @AntalPuttar, FwTraff = @FwTraff, GrTraff = @GrTraff" +
                        ", AntalPlikt = @AntalPlikt " +
                        "WHERE RundaNr = @RundaNr AND Halnr = @Halnr";
                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@RundaNr", DataTyp.Int, runda.RundaNr.ToString()),
                        new DatabasParameters("@Halnr", DataTyp.Int, runda.RundaHal[i].HalNr.ToString()),
                        new DatabasParameters("@AntalSlag", DataTyp.Int, runda.RundaHal[i].AntalSlag.ToString()),
                        new DatabasParameters("@AntalPoang", DataTyp.Int, runda.RundaHal[i].AntalPoang.ToString()),
                        new DatabasParameters("@AntalPuttar", DataTyp.Int, runda.RundaHal[i].AntalPuttar.ToString()),
                        new DatabasParameters("@FwTraff", DataTyp.Char, runda.RundaHal[i].FwTraff),
                        new DatabasParameters("@GrTraff", DataTyp.Char, runda.RundaHal[i].GrTraff),
                        new DatabasParameters("@AntalPlikt", DataTyp.Int, runda.RundaHal[i].AntalPlikt.ToString())
                    };
                    DatabasAccess.RunSql(sql, dbParameters);
                }
                DatabasAccess.BekräftaTransaktion();
            }
            catch (HookerException hex)
            {
                felID = "SQLERROR";
                feltext = hex.Message.ToString();
                throw hex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sparar i Runda, RundaaHal och Redovisning. Metoden håller transaktion över uppdateringen, då ev 
        /// tre tabeller uppdateras.
        /// </summary>
        /// <param name="runda">Runda</param>
        /// <param name="rundaHal">RundaHal</param>
        /// <param name="redovisning"></param>
        /// <param name="felID">Felmeddelande i Orslistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void Spara(RundaRundaHalRedovisningSDS.RundaDataTable runda, 
            RundaRundaHalRedovisningSDS.RundaHalDataTable rundaHal,
            RundaRundaHalRedovisningSDS.RedovisningDataTable redovisning,
            ref string felID, ref string feltext)
        {
            string sql;
            List<DatabasParameters> dbParameters;
            DatabasAccess.SkapaTransaktion();

            try
            {
                #region Runda
                foreach (RundaRundaHalRedovisningSDS.RundaRow rad in runda)
                {
                    if (rad.RowState != DataRowState.Unchanged)
                    {
                        switch (rad.RowState)
                        {
                            case DataRowState.Deleted:
                                sql = "DELETE FROM Redovisning WHERE RundaNr = @RundaNr";
                                dbParameters = new List<DatabasParameters>()
                                {
                                    new DatabasParameters("@RundaNr", 
                                        rad["RundaNr", DataRowVersion.Original].ToString())
                                };
                                DatabasAccess.RunSql(sql, dbParameters);
                                sql = "DELETE FROM RundaHal WHERE RundaNr = @RundaNr";
                                dbParameters = new List<DatabasParameters>()
                                {
                                    new DatabasParameters("@RundaNr", 
                                        rad["RundaNr", DataRowVersion.Original].ToString())
                                };
                                DatabasAccess.RunSql(sql, dbParameters);
                                sql = "DELETE FROM Runda WHERE RundaNr = @RundaNr";
                                dbParameters = new List<DatabasParameters>()
                                {
                                    new DatabasParameters("@RundaNr", 
                                        rad["RundaNr", DataRowVersion.Original].ToString())
                                };
                                DatabasAccess.RunSql(sql, dbParameters);
                                break;
                            case DataRowState.Added:
                                sql = "INSERT INTO Runda (RundaNr, Datum, SpelarID, ExaktHcp, ErhallnaSlag, Tee" +
                                    ", BanaNr, Tavlingsrond, Placering, Sallskapsrond, Hcprond" +
                                    ", Notering, UppdatDatum, Niohalsrond, Markor) " +
                                    "VALUES " +
                                    "(@RundaNr, @Datum, @SpelarID, @ExaktHcp, @ErhallnaSlag, @Tee, @BanaNr" +
                                    ", @Tavlingsrond, @Placering, @Sallskapsrond, @Hcprond" +
                                    ", @Notering, @UppdatDatum, @Niohalsrond, @Markor)";
                                dbParameters = new List<DatabasParameters>()
                                {
                                    new DatabasParameters("@RundaNr", DataTyp.Int, rad.RundaNr.ToString()),
                                    new DatabasParameters("@Datum", DataTyp.SmallDateTime, rad.Datum.ToString()),
                                    new DatabasParameters("@SpelarID", DataTyp.Int, rad.SpelarID.ToString()),
                                    new DatabasParameters("@ExaktHcp", DataTyp.Decimal, rad.ExaktHcp.ToString()),
                                    new DatabasParameters("@ErhallnaSlag", DataTyp.Int, rad.ErhallnaSlag.ToString()),
                                    new DatabasParameters("@Tee", DataTyp.Char, rad.Tee),
                                    new DatabasParameters("@BanaNr", DataTyp.Int, rad.BanaNr.ToString()),
                                    new DatabasParameters("@Tavlingsrond", DataTyp.Char, rad.Tavlingsrond),
                                    new DatabasParameters("@Placering", DataTyp.Int, rad.Placering.ToString()),
                                    new DatabasParameters("@Sallskapsrond", DataTyp.Char, rad.Sallskapsrond),
                                    new DatabasParameters("@Hcprond", DataTyp.Char, rad.Hcprond),
                                    new DatabasParameters("@Notering", DataTyp.VarChar, rad.Notering),
                                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, rad.UppdatDatum.ToString()),
                                    new DatabasParameters("@Niohalsrond", DataTyp.Char, rad.Niohalsrond),
                                    new DatabasParameters("@Markor", DataTyp.Int, rad.Markor.ToString())
                                };
                                DatabasAccess.RunSql(sql, dbParameters);
                                break;
                            case DataRowState.Modified:
                                sql = "UPDATE Runda " +
                                    "SET Datum = @Datum, SpelarID = @SpelarID" + 
                                    ", ExaktHcp = @ExaktHcp, ErhallnaSlag = @ErhallnaSlag, Tee = @Tee" +
                                    ", BanaNr = @BanaNr, Tavlingsrond = @Tavlingsrond, Placering = @Placering" +
                                    ", Sallskapsrond = @Sallskapsrond, Hcprond = @Hcprond, Notering = @Notering" +
                                    ", UppdatDatum = @UppdatDatum, Niohalsrond = @Niohalsrond, Markor = @Markor " +
                                    "WHERE RundaNr = @RundaNr";
                                dbParameters = new List<DatabasParameters>()
                                {
                                    new DatabasParameters("@RundaNr", DataTyp.Int, rad.RundaNr.ToString()),
                                    new DatabasParameters("@Datum", DataTyp.SmallDateTime, rad.Datum.ToString()),
                                    new DatabasParameters("@SpelarID", DataTyp.Int, rad.SpelarID.ToString()),
                                    new DatabasParameters("@ExaktHcp", DataTyp.Decimal, rad.ExaktHcp.ToString()),
                                    new DatabasParameters("@ErhallnaSlag", DataTyp.Int, rad.ErhallnaSlag.ToString()),
                                    new DatabasParameters("@Tee", DataTyp.Char, rad.Tee),
                                    new DatabasParameters("@BanaNr", DataTyp.Int, rad.BanaNr.ToString()),
                                    new DatabasParameters("@Tavlingsrond", DataTyp.Char, rad.Tavlingsrond),
                                    new DatabasParameters("@Placering", DataTyp.Int, rad.Placering.ToString()),
                                    new DatabasParameters("@Sallskapsrond", DataTyp.Char, rad.Sallskapsrond),
                                    new DatabasParameters("@Hcprond", DataTyp.Char, rad.Hcprond),
                                    new DatabasParameters("@Notering", DataTyp.VarChar, rad.Notering),
                                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, rad.UppdatDatum.ToString()),
                                    new DatabasParameters("@Niohalsrond", DataTyp.Char, rad.Niohalsrond),
                            new DatabasParameters("@Markor", DataTyp.Int, rad.Markor.ToString())
                                };
                                DatabasAccess.RunSql(sql, dbParameters);
                                break;
                        }
                    }
                }
                #endregion

                #region RundaHal
                foreach (RundaRundaHalRedovisningSDS.RundaHalRow rad in rundaHal)
                {
                    if (rad.RowState != DataRowState.Unchanged)
                    {
                        switch (rad.RowState)
                        {
                            case DataRowState.Added:
                                sql = " INSERT INTO RundaHal (RundaNr, Halnr, AntalSlag, AntalPoang, AntalPuttar" +
                                    ", FwTraff, GrTraff, AntalPlikt) " +
                                    "VALUES " +
                                    "(@RundaNr, @Halnr, @AntalSlag, @AntalPoang, @AntalPuttar" +
                                    ", @FwTraff, @GrTraff, @AntalPlikt)";
                                dbParameters = new List<DatabasParameters>()
                                {
                                    new DatabasParameters("@RundaNr", DataTyp.Int, rad.RundaNr.ToString()),
                                    new DatabasParameters("@Halnr", DataTyp.Int, rad.HalNr.ToString()),
                                    new DatabasParameters("@AntalSlag", DataTyp.Int, rad.AntalSlag.ToString()),
                                    new DatabasParameters("@AntalPoang", DataTyp.Int, rad.AntalPoang.ToString()),
                                    new DatabasParameters("@AntalPuttar", DataTyp.Int, rad.AntalPuttar.ToString()),
                                    new DatabasParameters("@FwTraff", DataTyp.Char, rad.FwTraff),
                                    new DatabasParameters("@GrTraff", DataTyp.Char, rad.GrTraff),
                                    new DatabasParameters("@AntalPlikt", DataTyp.Int, rad.AntalPlikt.ToString())
                                };
                                DatabasAccess.RunSql(sql, dbParameters);
                                break;
                            case DataRowState.Modified:
                                sql = "UPDATE RundaHal SET AntalSlag = @AntalSlag, AntalPoang = @AntalPoang" +
                                    ", AntalPuttar = @AntalPuttar, FwTraff = @FwTraff, GrTraff = @GrTraff" +
                                    ", AntalPlikt = @AntalPlikt " +
                                    "WHERE RundaNr = @RundaNr AND Halnr = @Halnr";
                                dbParameters = new List<DatabasParameters>()
                                {
                                    new DatabasParameters("@RundaNr", DataTyp.Int, rad.RundaNr.ToString()),
                                    new DatabasParameters("@Halnr", DataTyp.Int, rad.HalNr.ToString()),
                                    new DatabasParameters("@AntalSlag", DataTyp.Int, rad.AntalSlag.ToString()),
                                    new DatabasParameters("@AntalPoang", DataTyp.Int, rad.AntalPoang.ToString()),
                                    new DatabasParameters("@AntalPuttar", DataTyp.Int, rad.AntalPuttar.ToString()),
                                    new DatabasParameters("@FwTraff", DataTyp.Char, rad.FwTraff),
                                    new DatabasParameters("@GrTraff", DataTyp.Char, rad.GrTraff),
                                    new DatabasParameters("@AntalPlikt", DataTyp.Int, rad.AntalPlikt.ToString())
                                };
                                DatabasAccess.RunSql(sql, dbParameters);
                                break;
                        }
                    }
                }
                #endregion

                #region "Redovisning"
                foreach (RundaRundaHalRedovisningSDS.RedovisningRow rad in redovisning)
                {
                    if (rad.RowState != DataRowState.Unchanged)
                    {
                        switch (rad.RowState)
                        {
                            case DataRowState.Deleted:
                                sql = "DELETE Redovisning WHERE TransNr = @TransNr";
                                dbParameters = new List<DatabasParameters>()
                                {
                                    new DatabasParameters("@TransNr", 
                                        rad["TransNr", DataRowVersion.Original].ToString())
                                };
                                DatabasAccess.RunSql(sql, dbParameters);
                                break;
                            case DataRowState.Added:
                                sql = "INSERT INTO Redovisning (Typ, Datum, RundaNr, SpelarID, Belopp, Notering) " +
                                    "VALUES " +
                                    "(@Typ, @Datum, @RundaNr, @SpelarID, @Belopp, @Notering)";
                                dbParameters = new List<DatabasParameters>()
                                {
                                    new DatabasParameters("@Typ", DataTyp.Char, rad.Typ),
                                    new DatabasParameters("@Datum", DataTyp.SmallDateTime, rad.Datum.ToString()),
                                    new DatabasParameters("@RundaNr", DataTyp.Int, rad.RundaNr.ToString()),
                                    new DatabasParameters("@SpelarID", DataTyp.Int, rad.SpelarID.ToString()),
                                    new DatabasParameters("@Belopp", DataTyp.Decimal, rad.Belopp.ToString()),
                                    new DatabasParameters("@Notering", DataTyp.VarChar, rad.Notering)
                                };
                                DatabasAccess.RunSql(sql, dbParameters);
                                break;
                            case DataRowState.Modified:
                                sql = "UPDATE Redovisning SET  Typ = @Typ, Datum = @Datum, RundaNr = @RundaNr" +
                                    ", SpelarID = @SpelarID, Belopp = @Belopp, Notering = @Notering " +
                                    "WHERE RundaNr = @RundaNr";
                                dbParameters = new List<DatabasParameters>()
                                {
                                    new DatabasParameters("@Typ", DataTyp.Char, rad.Typ),
                                    new DatabasParameters("@Datum", DataTyp.SmallDateTime, rad.Datum.ToString()),
                                    new DatabasParameters("@RundaNr", DataTyp.Int, rad.RundaNr.ToString()),
                                    new DatabasParameters("@SpelarID", DataTyp.Int, rad.SpelarID.ToString()),
                                    new DatabasParameters("@Belopp", DataTyp.Decimal, rad.Belopp.ToString()),
                                    new DatabasParameters("@Notering", DataTyp.VarChar, rad.Notering)
                                };
                                DatabasAccess.RunSql(sql, dbParameters);
                                break;
                        }
                    }
                }

                #endregion

                runda.AcceptChanges();
                rundaHal.AcceptChanges();
                redovisning.AcceptChanges();
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
                if (DatabasAccess != null)
                {
                    DatabasAccess.Dispose();
                }
            }
        }
    }
}
