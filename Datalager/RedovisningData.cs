using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Hooker.Affärsobjekt;
using Hooker.Dataset;
using Hooker.Gemensam;
using GemensamService;

namespace Hooker.Datalager
{
    /// <summary>
    /// Datalagerklass för Redovisning
    /// </summary>
    public sealed class RedovisningData : AbstractDataLager
    {
        /// <summary>
        ///     Söker i Redovisning
        /// </summary>
        /// <param name="sqlSök">Sökvillkor för läsningen</param>
        /// <returns>Dataset med aktuella rader</returns>
        public DataSet SökRedovisning(string sqlSök)
        {
            StringBuilder sql = new StringBuilder();
            DataSet dsRedovisning;

            try
            {
                //Skapa sql:en
                sql.Append("SELECT re.TransNr, re.Typ, re.Datum, re.RundaNr, re.SpelarID, re.Belopp, k.Varde AS Typnamn, ");
                sql.Append("CASE WHEN r.Notering IS NOT NULL THEN r.Notering ");
		        sql.Append("WHEN re.Notering IS NOT NULL THEN re.Notering ");
                sql.Append("ELSE '' END AS Notering ");
                sql.Append("FROM Redovisning re ");
                sql.Append("INNER JOIN Koder k ON k.Typ = 10 AND k.Argument = re.Typ ");
                sql.Append("LEFT OUTER JOIN Runda r ON re.RundaNr = r.RundaNr");
                sql.Append(sqlSök);
                sql.Append(" ORDER BY Typnamn, re.Datum");
                dsRedovisning = DatabasAccess.RunSql(sql.ToString());
                dsRedovisning.Tables[0].TableName = "Redovisning";
                return dsRedovisning;
            }
            catch (Exception ex)
            {
                throw new HookerException(ex.Message, ex);
            }
            finally
            {
                if (DatabasAccess!= null)
                {
                    DatabasAccess.Dispose();
                }
            }
        }

        /// <summary>
        /// Hämta Redovisning med mha nyckel
        /// </summary>
        /// <param name="transNr">TransNr</param>
        /// <returns>Typat DataSet</returns>
        public RedovisningDS HämtaRedovisning(int transNr)
        {
            RedovisningDS redovisningDS = new RedovisningDS();
            string sql = "SELECT r.* FROM Redovisning r WHERE r.TransNr = @TransNr";

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TransNr", DataTyp.Int, transNr.ToString())
                };
                DatabasAccess.FyllEnkeltDataSet(sql, dbParameters, redovisningDS);
                return redovisningDS;
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
        /// Ta bort redovisning
        /// </summary>
        /// <param name="rundaNr">RundaNr</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBortRedovisningRunda(int rundaNr, ref string felID, ref string feltext)
        {
            string sql;
                
            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "DELETE FROM Redovisning WHERE RundaNr = @RundaNr";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RundaNr", DataTyp.Int, rundaNr.ToString())
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
        /// Ta bort redovisning
        /// </summary>
        /// <param name="redovisning">Redovisning</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBortRedovisningTrans(Redovisning redovisning, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "DELETE Redovisning WHERE TransNr = @TransNr";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TransNr", DataTyp.Int, redovisning.TransNr.ToString())
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
        /// Ny Redovisning.
        /// </summary>
        /// <param name="redovisning">Redovisning</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int SparaNyRedovisning(Redovisning redovisning, ref string felID, ref string feltext)
        {
            string sql;
            int nyttTransNr;

            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "INSERT INTO Redovisning (Typ, Datum, RundaNr, SpelarID, Belopp, Notering, UppdatDatum) " +
                    "VALUES " +
                    "(@Typ, @Datum, @RundaNr, @SpelarID, @Belopp, @Notering, @UppdatDatum);";
                    //"SELECT @@IDENTITY;";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@Typ", DataTyp.Char, redovisning.Typ),
                    new DatabasParameters("@Datum", DataTyp.SmallDateTime, redovisning.Datum.ToString()),
                    new DatabasParameters("@RundaNr", DataTyp.Int, redovisning.RundaNr.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, redovisning.SpelarID.ToString()),
                    new DatabasParameters("@Belopp", DataTyp.Decimal, redovisning.Belopp.ToString()),
                    new DatabasParameters("@Notering", DataTyp.VarChar, redovisning.Notering),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, redovisning.UppdatDatum.ToString())
                };
                DatabasAccess.RunSql(sql, dbParameters);
                sql = "SELECT LAST_INSERT_ID()";
                
                nyttTransNr = Convert.ToInt32(DatabasAccess.ExecuteScalar(sql));
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
            return nyttTransNr;
        }
        
        /// <summary>
        /// Sparar i Redovisning.
        /// </summary>
        /// <param name="redovisning">Redovisning</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaRedovisning(Redovisning redovisning, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "UPDATE Redovisning SET  Typ = @Typ, Datum = @Datum, RundaNr = @RundaNr" +
                    ", SpelarID = @SpelarID, Belopp = @Belopp, Notering = @Notering, UppdatDatum = @UppdatDatum " +
                    "WHERE TransNr = @TransNr";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@Typ", DataTyp.Char, redovisning.Typ),
                    new DatabasParameters("@Datum", DataTyp.SmallDateTime, redovisning.Datum.ToString()),
                    new DatabasParameters("@RundaNr", DataTyp.Int, redovisning.RundaNr.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, redovisning.SpelarID.ToString()),
                    new DatabasParameters("@Belopp", DataTyp.Decimal, redovisning.Belopp.ToString()),
                    new DatabasParameters("@Notering", DataTyp.VarChar, redovisning.Notering),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, redovisning.UppdatDatum.ToString()),
                    new DatabasParameters("@TransNr", DataTyp.Int, redovisning.TransNr.ToString())
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
    }
}
