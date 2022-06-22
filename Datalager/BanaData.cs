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
    /// Datalagerklass för Bana
    /// </summary>
    public sealed class BanaData : AbstractDataLager
    {
        /// <summary>
        /// Hämtar rad från tabellen Bana i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="banaNR">Aktuellt BanaNR</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public BanaDS HämtaBana(int banaNR)
        {
            BanaDS banaDS = new BanaDS();
            string sql = "SELECT b.* FROM Bana b " +
                "WHERE b.BanaNR = @BanaNr";

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@BanaNr", banaNR.ToString())
                };
                DatabasAccess.FyllEnkeltDataSet(sql, dbParameters, banaDS);
                return banaDS;
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
        /// Hämtar rad från tabellen Bana i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="namn">Aktuellt namn</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public BanaDS HämtaBana(string namn)
        {
            BanaDS ds = new BanaDS();
            string sql = "SELECT g.*, b.Namn FROM Golfklubb g " +
                "LEFT OUTER JOIN Bana b ON g.GolfklubbNr = b.GolfklubbNr " +
                "WHERE g.GolfklubbNamn LIKE @Namn " +
                "ORDER BY g.GolfklubbNamn, b.Namn";

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@Namn", namn + "%")
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
                DatabasAccess.Dispose();
            }
        }

        /// <summary>
        /// Hämtar rad/-er från tabellen Bana i aktuell databas med angivet GolfklubbNr.
        /// </summary>
        /// <param name="golfklubbNr">Aktuell Tavling</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public BanaDS HämtaAktuellaBanorMedGolfklubbNr(int golfklubbNr)
        {
            BanaDS ds = new BanaDS();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@GolfklubbNr", DataTyp.Int, golfklubbNr.ToString())
                };
                DatabasAccess.ExecuteSP("GetAktuellaBanorByGolfklubbNr", dbParameters, ds);
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
        /// Hämtar rad/-er från tabellen Bana i aktuell databas med angivet GolfklubbNr.
        /// </summary>
        /// <param name="golfklubbNr">Aktuell Tavling</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public BanaDS HämtaBanaMedGolfklubbNr(int golfklubbNr)
        {
            BanaDS ds = new BanaDS();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@GolfklubbNr", DataTyp.Int, golfklubbNr.ToString())
                };
                DatabasAccess.ExecuteSP("GetBanaByGolfklubbNr", dbParameters, ds);
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
        /// Hämtar rad/-er från tabellen Bana i aktuell databas med angivet GolfklubbNr.
        /// </summary>
        /// <param name="golfklubbNr">Aktuell Tavling</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public DataSet HämtaBanorMedGolfklubbNr(int golfklubbNr)
        {
            DataSet banaDS = new DataSet();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@GolfklubbNr", DataTyp.Int, golfklubbNr.ToString()),
                };
                banaDS = DatabasAccess.ExecuteSP("GetBanorByGolfklubbNr", dbParameters);
                return banaDS;
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
        /// Hämtar rad från tabellen Bana i aktuell databas med angiven nyckel.
        /// </summary>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public DataSet HämtaMaxBanNr()
        {
            DataSet banaDS = new DataSet();
            string sql = "SELECT MAX(BanaNr) AS Max FROM Bana";

            try
            {
                banaDS = DatabasAccess.RunSql(sql);
                return banaDS;
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
        /// Hämtar rad/-er från tabellen Bana i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="sqlSok">Eventuellt where-villkor</param>
        /// <returns>Otypat dataset med efterfrågat data</returns>
        public DataSet SökBana(string sqlSok)
        {
            DataSet banaDS = new DataSet();
            string sql = "SELECT g.*, b.*, b.Notering AS Bananotering, k1.Varde AS Land, " +
                "k2.Varde AS Distrikt " +
                "FROM Golfklubb g " +
                "LEFT OUTER JOIN Bana b ON b.GolfklubbNr = g.GolfklubbNr " +
                "LEFT OUTER JOIN Koder k1 ON k1.Typ = '4' AND k1.Argument = g.Landkod " +
                "LEFT OUTER JOIN Koder k2 ON k2.Typ = '1' AND k2.Argument = g.Distriktkod " +
                sqlSok.ToString() +
                " ORDER BY g.GolfklubbNamn, b.Namn";

            try
            {
                banaDS = DatabasAccess.RunSql(sql);
                banaDS.Tables[0].TableName = "Bana";
                return banaDS;
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
        /// Hämta Bana och banans alla BanaHal för angivet banaNr.
        /// </summary>
        /// <param name="banaNr">Banans nr</param>
        /// <returns>Ett sammansatt typat dataset med aktuell information</returns>
        public BanaBanaHalSDS HämtaBanaBanaHal(int banaNr)
        {
            BanaBanaHalSDS ds = new BanaBanaHalSDS();
            string sql = "SELECT * FROM Bana WHERE BanaNR = @BanaNr" + ";" +
                " SELECT * FROM BanaHal WHERE BanaNr = @BanaNr" + ";";

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@BanaNr", DataTyp.Int, banaNr.ToString())
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
                DatabasAccess.Dispose();
            }
        }

        /// <summary>
        /// Ta bort angiven BanaHål och Bana
        /// </summary>
        /// <param name="banaNr">Bananummer</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBortBana(int banaNr, ref string felID, ref string feltext)
        {
            string sql;
            try
            {
                sql = "DELETE FROM BanaHal WHERE BanaNr = @BanaNr";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@BanaNr", DataTyp.Int, banaNr.ToString())
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
        ///     Ny Bana.
        /// </summary>
        /// <param name="bana">Bana</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaNyBana(Bana bana, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "INSERT INTO Bana (BanaNr, Namn, GolfklubbNr, SlopeHerrarGul, CrHerrarGul" +
                    ", SlopeDamerRod, CrDamerRod, UppdatDatum, RankLayout, RankSkick" +
                    ", RankStrategi, RankNatur, RankEtikett, RankRange, SlopeHerrarRod, CrHerrarRod" +
                    ", SlopeDamerGul, CrDamerGul, Notering, Aktuell, AntalHal) " +
                    "VALUES " +
                    "(@BanaNr, @Namn, @GolfklubbNr, @SlopeHerrarGul, @CrHerrarGul, @SlopeDamerRod" +
                    ", @CrDamerRod, @UppdatDatum, @RankLayout" +
                    ", @RankSkick, @RankStrategi, @RankNatur, @RankEtikett, @RankRange" +
                    ", @SlopeHerrarRod, @CrHerrarRod, @SlopeDamerGul, @CrDamerGul" +
                    ", @Notering, @Aktuell, @AntalHal)";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@BanaNr", DataTyp.Int, bana.BanaNr.ToString()),
                    new DatabasParameters("@GolfklubbNr", DataTyp.Int, bana.GolfklubbNr.ToString()),
                    new DatabasParameters("@Namn", DataTyp.VarChar, bana.BanaNamn),
                    new DatabasParameters("@SlopeHerrarGul", DataTyp.Int, bana.SlopeHerrarGul.ToString()),
                    new DatabasParameters("@CrHerrarGul", DataTyp.Decimal, bana.CrHerrarGul.ToString()),
                    new DatabasParameters("@SlopeDamerRod", DataTyp.Decimal, bana.SlopeDamerRod.ToString()),
                    new DatabasParameters("@CrDamerRod", DataTyp.Decimal, bana.CrDamerRod.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, bana.UppdatDatum.ToString()),
                    new DatabasParameters("@RankLayout", DataTyp.Int, bana.RankLayout.ToString()),
                    new DatabasParameters("@RankSkick", DataTyp.Int, bana.RankSkick.ToString()),
                    new DatabasParameters("@RankStrategi", DataTyp.Int, bana.RankStrategi.ToString()),
                    new DatabasParameters("@RankNatur", DataTyp.Int, bana.RankNatur.ToString()),
                    new DatabasParameters("@RankEtikett", DataTyp.Int, bana.RankEtikett.ToString()),
                    new DatabasParameters("@RankRange", DataTyp.Int, bana.RankRange.ToString()),
                    new DatabasParameters("@SlopeHerrarRod", DataTyp.Int, bana.SlopeHerrarRod.ToString()),
                    new DatabasParameters("@CrHerrarRod", DataTyp.Decimal, bana.CrHerrarRod.ToString()),
                    new DatabasParameters("@SlopeDamerGul", DataTyp.Int, bana.SlopeDamerGul.ToString()),
                    new DatabasParameters("@CrDamerGul", DataTyp.Decimal, bana.CrDamerGul.ToString()),
                    new DatabasParameters("@Notering", DataTyp.VarChar, bana.Notering),
                    new DatabasParameters("@Aktuell", DataTyp.Int, bana.Aktuell),
                    new DatabasParameters("@AntalHal", DataTyp.Char, bana.AntalHal)
                };
                DatabasAccess.RunSql(sql, dbParameters);
                DatabasAccess.BekräftaTransaktion();

                SparaNyBanaHal(bana, ref felID, ref feltext);
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
        ///     Ny Bana.
        /// </summary>
        /// <param name="bana">Bana</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        private void SparaNyBanaHal(Bana bana, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion(); 
                for (int i = 0; i < bana.BanaHal.Length; i++)
                {
                    sql = " INSERT INTO BanaHal (BanaNr, Halnr, LangdVit, LangdGul, LangdBla" +
                        ", LangdRod, Par, Hcp) " +
                        "VALUES " +
                        "(@BanaNr, @Halnr, @LangdVit, @LangdGul, @LangdBla, @LangdRod, @Par, @Hcp)";
                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@BanaNr", DataTyp.Int, bana.BanaNr.ToString()),
                        new DatabasParameters("@Halnr", DataTyp.Int, bana.BanaHal[i].HalNr.ToString()),
                        new DatabasParameters("@LangdVit", DataTyp.Int, bana.BanaHal[i].LangdVit.ToString()),
                        new DatabasParameters("@LangdGul", DataTyp.Int, bana.BanaHal[i].LangdGul.ToString()),
                        new DatabasParameters("@LangdBla", DataTyp.Int, bana.BanaHal[i].LangdBla.ToString()),
                        new DatabasParameters("@LangdRod", DataTyp.Int, bana.BanaHal[i].LangdRod.ToString()),
                        new DatabasParameters("@Par", DataTyp.Int, bana.BanaHal[i].Par.ToString()),
                        new DatabasParameters("@Hcp", DataTyp.Int, bana.BanaHal[i].Hcp.ToString())
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
        ///     Sparar i bana.
        /// </summary>
        /// <param name="bana">Bana</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaBana(Bana bana, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "UPDATE Bana " +
                     "SET Namn = @Namn, GolfklubbNr = @GolfklubbNr, SlopeHerrarGul = @SlopeHerrarGul" +
                     ", CrHerrarGul = @CrHerrarGul, SlopeDamerRod = @SlopeDamerRod" +
                     ", CrDamerRod = @CrDamerRod, UppdatDatum = @UppdatDatum" +
                     ", RankLayout = @RankLayout, RankSkick = @RankSkick" +
                     ", RankStrategi = @RankStrategi, RankNatur = @RankNatur" +
                     ", RankEtikett = @RankEtikett, RankRange = @RankRange" +
                     ", SlopeHerrarRod = @SlopeHerrarRod, CrHerrarRod = @CrHerrarRod" +
                     ", SlopeDamerGul = @SlopeDamerGul, CrDamerGul = @CrDamerGul" +
                     ", Notering = @Notering, Aktuell = @Aktuell, AntalHal = @AntalHal " +
                     "WHERE BanaNr = @BanaNr";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@BanaNr", DataTyp.Int, bana.BanaNr.ToString()),
                    new DatabasParameters("@GolfklubbNr", DataTyp.Int, bana.GolfklubbNr.ToString()),
                    new DatabasParameters("@Namn", DataTyp.VarChar, bana.BanaNamn),
                    new DatabasParameters("@SlopeHerrarGul", DataTyp.Int, bana.SlopeHerrarGul.ToString()),
                    new DatabasParameters("@CrHerrarGul", DataTyp.Decimal, bana.CrHerrarGul.ToString()),
                    new DatabasParameters("@SlopeDamerRod", DataTyp.Decimal, bana.SlopeDamerRod.ToString()),
                    new DatabasParameters("@CrDamerRod", DataTyp.Decimal, bana.CrDamerRod.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, bana.UppdatDatum.ToString()),
                    new DatabasParameters("@RankLayout", DataTyp.Int, bana.RankLayout.ToString()),
                    new DatabasParameters("@RankSkick", DataTyp.Int, bana.RankSkick.ToString()),
                    new DatabasParameters("@RankStrategi", DataTyp.Int, bana.RankStrategi.ToString()),
                    new DatabasParameters("@RankNatur", DataTyp.Int, bana.RankNatur.ToString()),
                    new DatabasParameters("@RankEtikett", DataTyp.Int, bana.RankEtikett.ToString()),
                    new DatabasParameters("@RankRange", DataTyp.Int, bana.RankRange.ToString()),
                    new DatabasParameters("@SlopeHerrarRod", DataTyp.Int, bana.SlopeHerrarRod.ToString()),
                    new DatabasParameters("@CrHerrarRod", DataTyp.Decimal, bana.CrHerrarRod.ToString()),
                    new DatabasParameters("@SlopeDamerGul", DataTyp.Int, bana.SlopeDamerGul.ToString()),
                    new DatabasParameters("@CrDamerGul", DataTyp.Decimal, bana.CrDamerGul.ToString()),
                    new DatabasParameters("@Notering", DataTyp.VarChar, bana.Notering),
                    new DatabasParameters("@Aktuell", DataTyp.Int, bana.Aktuell),
                    new DatabasParameters("@AntalHal", DataTyp.Char, bana.AntalHal)
                };
                DatabasAccess.RunSql(sql, dbParameters);

                SparaBanaHal(bana, ref felID, ref feltext);
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
        ///     Ny Bana.
        /// </summary>
        /// <param name="bana">Bana</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        private void SparaBanaHal(Bana bana, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                for (int i = 0; i < bana.BanaHal.Length; i++)
                {
                    sql = "UPDATE BanaHal SET LangdVit = @LangdVit" +
                        ", LangdGul = @LangdGul, LangdBla = @LangdBla, LangdRod = @LangdRod" +
                        ", Par = @Par, Hcp = @Hcp " +
                        "WHERE BanaNr = @BanaNr AND Halnr = @Halnr";
                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@BanaNr", DataTyp.Int, bana.BanaNr.ToString()),
                        new DatabasParameters("@Halnr", DataTyp.Int, bana.BanaHal[i].HalNr.ToString()),
                        new DatabasParameters("@LangdVit", DataTyp.Int, bana.BanaHal[i].LangdVit.ToString()),
                        new DatabasParameters("@LangdGul", DataTyp.Int, bana.BanaHal[i].LangdGul.ToString()),
                        new DatabasParameters("@LangdBla", DataTyp.Int, bana.BanaHal[i].LangdBla.ToString()),
                        new DatabasParameters("@LangdRod", DataTyp.Int, bana.BanaHal[i].LangdRod.ToString()),
                        new DatabasParameters("@Par", DataTyp.Int, bana.BanaHal[i].Par.ToString()),
                        new DatabasParameters("@Hcp", DataTyp.Int, bana.BanaHal[i].Hcp.ToString())
                    };
                    DatabasAccess.RunSql(sql, dbParameters);
                }
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
    }
}
