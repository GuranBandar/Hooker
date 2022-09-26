using System;
using System.Data;
using Hooker.Affärsobjekt;
using Hooker.Dataset;
using GemensamService;
using Hooker.Gemensam;
using System.Collections.Generic;
using System.Text;

namespace Hooker.Datalager
{
    /// <summary>
    /// Datalagerklass för Bana
    /// </summary>
    public sealed class SpelareData : AbstractDataLager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="namn"></param>
        /// <returns></returns>
        public SpelareDS HämtaSpelare(string namn)
        {
            SpelareDS spelareDS = new SpelareDS();
            string sql = "SELECT s.* FROM Spelare s WHERE s.Namn LIKE @Namn";

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@Namn", namn + "%")
                };
                DatabasAccess.FyllEnkeltDataSet(sql, dbParameters, spelareDS);
                return spelareDS;
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
        /// Hämtar rad från tabellen Spelare i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="spelarID">Aktuellt SpelarID</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public SpelareDS HämtaSpelare(int spelarID)
        {
            SpelareDS spelareDS = new SpelareDS();
            string sql = "SELECT s.* FROM Spelare s WHERE s.SpelarID = @SpelarID";

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@SpelarID", DataTyp.Int, spelarID.ToString())
                };
                DatabasAccess.FyllEnkeltDataSet(sql, dbParameters, spelareDS);
                return spelareDS;
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
        /// <returns>Typat dataset med efterfrågat data</returns>
        public DataSet SökSpelare(string sqlSok)
        {
            _ = new DataSet();
            string sql;

            try
            {
                sql = "SELECT s.*, g.GolfklubbNamn, b.Namn AS BanaNamn FROM Spelare s " +
                    "LEFT OUTER JOIN Golfklubb g ON g.GolfklubbNr = s.GolfklubbNr " +
                    "LEFT OUTER JOIN Bana b ON b.BanaNr = s.HemmabanaNr " +
                    sqlSok.ToString();
                DataSet spelareDS = DatabasAccess.RunSql(sql);
                spelareDS.Tables[0].TableName = "Spelare";
                return spelareDS;
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
        /// <returns>Typat dataset med efterfrågat data</returns>
        public DataSet SökSpelareAnvandare()
        {
            _ = new DataSet();
            StringBuilder sql = new StringBuilder();

            try
            {
                sql.Append("SELECT s.*, g.GolfklubbNamn, b.Namn AS BanaNamn, ");
                sql.Append("a.Anvandarnamn ");
                sql.Append("FROM Spelare s ");
                sql.Append("INNER JOIN Anvandare a ON a.SpelarID = s.SpelarID ");
                sql.Append("LEFT OUTER JOIN Golfklubb g ON g.GolfklubbNr = s.GolfklubbNr ");
                sql.Append("LEFT OUTER JOIN Bana b ON b.BanaNr = s.HemmabanaNr");
                DataSet spelareDS = DatabasAccess.RunSql(sql.ToString());
                spelareDS.Tables[0].TableName = "Spelare";
                return spelareDS;
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
        /// Hämtar högsta SpelarID från tabellen Spelare i aktuell databas.
        /// </summary>
        /// <returns>Dataset med efterfrågat data</returns>
        public DataSet HämtaMaxSpelarID()
        {
            _ = new DataSet();
            string sql;

            try
            {
                sql = "SELECT MAX(SpelarID) AS Max FROM Spelare";
                DataSet spelareDS = DatabasAccess.RunSql(sql);
                spelareDS.Tables[0].TableName = "Spelare";
                return spelareDS;
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
        /// Hämtar högsta SpelarID från tabellen Spelare i aktuell databas.
        /// </summary>
        /// <param name="tavlingID">ID för aktuell tävling</param>
        /// <returns>Dataset med efterfrågat data</returns>
        public DataSet HämtaSpelareEjAnmälda(int tavlingID)
        {
            _ = new DataSet();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@tavlingID", DataTyp.Int, tavlingID.ToString())
                };
                DataSet spelareDS = DatabasAccess.ExecuteSP("GetSpelareEjAnmald", dbParameters);
                spelareDS.Tables[0].TableName = "Spelare";
                return spelareDS;
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
        ///     Ta bort i Spelare.
        /// </summary>
        /// <param name="spelare">Spelare</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TabortSpelare(Spelare spelare, ref string felID, ref string feltext)
        {
            string sql;
            DatabasAccess.SkapaTransaktion();

            try
            {
                sql = "DELETE FROM Spelare WHERE SpelarID = @SpelarID";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@SpelarID", DataTyp.Int, spelare.AktuelltSpelarID.ToString())
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
        ///     Ny Spelare.
        /// </summary>
        /// <param name="spelare">Spelare</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaNySpelare(Spelare spelare, ref string felID, ref string feltext)
        {
            string sql;
            DatabasAccess.SkapaTransaktion();

            try
            {
                sql = "INSERT INTO Spelare (SpelarID, Namn, Hcp, Klass, Kon, RevisionsDatum, " +
                    "Hemmabananr, GolfID, UppdatDatum, GolfklubbNr, FederationNo)" +
                    "VALUES " +
                    "(@SpelarID, @Namn, @Hcp, @Klass, @Kon, @RevisionsDatum, @Hemmabananr, @GolfID, " +
                    "@UppdatDatum, @GolfklubbNr, @FederationNo)";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@SpelarID", DataTyp.Int, spelare.AktuelltSpelarID.ToString()),
                    new DatabasParameters("@Namn", DataTyp.VarChar, spelare.Namn),
                    new DatabasParameters("@Hcp", DataTyp.Decimal, spelare.ExaktHcp.ToString()),
                    new DatabasParameters("@Klass", DataTyp.Char, spelare.Klass),
                    new DatabasParameters("@Kon", DataTyp.Char, spelare.Kön),
                    new DatabasParameters("@RevisionsDatum", DataTyp.SmallDateTime, spelare.Revisionsdatum.ToString()),
                    new DatabasParameters("@Hemmabananr", DataTyp.Int, spelare.HemmabanaNr.ToString()),
                    new DatabasParameters("@GolfID", DataTyp.NChar, spelare.GolfID.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, spelare.UppdatDatum.ToString()),
                    new DatabasParameters("@GolfklubbNr", DataTyp.Int, spelare.GolfklubbNr.ToString()),
                    new DatabasParameters("@FederationNo", DataTyp.Int, spelare.FederationNo.ToString())
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
        ///     Sparar i Spelare.
        /// </summary>
        /// <param name="spelare">Spelare</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaSpelare(Spelare spelare, ref string felID, ref string feltext)
        {
            string sql;
            DatabasAccess.SkapaTransaktion();

            try
            {
                sql = "UPDATE Spelare " +
                    "SET SpelarID = @SpelarID, Namn = @Namn, Hcp = @Hcp, Klass = @Klass" +
                    ", Kon = @Kon, RevisionsDatum = @RevisionsDatum, Hemmabananr = @Hemmabananr" +
                    ", GolfID = @GolfID, UppdatDatum = @UppdatDatum, GolfklubbNr = @GolfklubbNr" +
                    ", FederationNo = @FederationNo "+
                    "WHERE SpelarID = @SpelarID";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@SpelarID", DataTyp.Int, spelare.AktuelltSpelarID.ToString()),
                    new DatabasParameters("@Namn", DataTyp.VarChar, spelare.Namn),
                    new DatabasParameters("@Hcp", DataTyp.Decimal, spelare.ExaktHcp.ToString()),
                    new DatabasParameters("@Klass", DataTyp.Char, spelare.Klass),
                    new DatabasParameters("@Kon", DataTyp.Char, spelare.Kön),
                    new DatabasParameters("@RevisionsDatum", DataTyp.SmallDateTime, spelare.Revisionsdatum.ToString()),
                    new DatabasParameters("@Hemmabananr", DataTyp.Int, spelare.HemmabanaNr.ToString()),
                    new DatabasParameters("@GolfID", DataTyp.NChar, spelare.GolfID.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, spelare.UppdatDatum.ToString()),
                    new DatabasParameters("@GolfklubbNr", DataTyp.Int, spelare.GolfklubbNr.ToString()),
                    new DatabasParameters("@FederationNo", DataTyp.Int, spelare.FederationNo.ToString())
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
