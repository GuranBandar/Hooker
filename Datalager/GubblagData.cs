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
    public sealed class GubblagData : AbstractDataLager
    {
        /// <summary>
        /// Hämtar rad från tabellen GubblagDag i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="GubblagID">Aktuell Gubblag</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public GubblagDS HämtaGubblag(int GubblagID)
        {
            GubblagDS ds = new GubblagDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT g.* FROM Gubblag g WHERE g.GubblagID = @GubblagID";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@GubblagID", DataTyp.Int, GubblagID.ToString())
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
        /// Hämtar rad från tabellen Gubblag i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="Datum">Aktuell bokning</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public GubblagDS HämtaGubblag(string Gubblagsnamn)
        {
            GubblagDS ds = new GubblagDS();
            string sql;
            string gubblagsnamn = Gubblagsnamn.ToString();

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT g.* FROM Gubblag g WHERE g.Gubblagsnamn = @Gubblagsnamn";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@Gubblagsnamn", DataTyp.String, gubblagsnamn.ToString())
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
        /// Hämtar rad från tabellen GubblagsSpelare i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="GubblagID">Aktuellt gubblag</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public GubblagsSpelareDS HämtaGubblagsSpelare(int GubblagID)
        {
            GubblagsSpelareDS ds = new GubblagsSpelareDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT g.* FROM GubblagsSpelare g WHERE g.GubblagID = @GubblagID";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@GubblagID", DataTyp.Int, GubblagID.ToString())
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
        /// Hämtar alla Gublag från tabellen Gubblag i aktuell databas.
        /// </summary>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public DataSet HämtaAllaGubblag()
        {
            DataSet GubblagDS = new DataSet();
            string sql;

            try
            {
                sql = "SELECT g.* FROM Gubblag g " +
                    " ORDER BY g.Gubblagsnamn ASC";
                GubblagDS = DatabasAccess.RunSql(sql);
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
            return GubblagDS;
        }

        /// <summary>
        /// Nytt Gubblag.
        /// </summary>
        /// <param name="Gubblag">Gubblaget</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int SparaNyttGubblag(Gubblag Gubblag, ref string felID, ref string feltext)
        {
            string sql;
            int nyttGubblagID;

            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "INSERT INTO Gubblag(Gubblagsnamn, " +
                    "AnvandarNamnSkapad, SkapadDatum, AnvandarNamnUppdat, UppdatDatum) " +
                    "VALUES " +
                    "(@Gubblagsnamn, " +
                    "@AnvandarNamnSkapad, @SkapadDatum, @AnvandarNamnUppdat, @UppdatDatum)";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@Gubblagsnamn", DataTyp.VarChar, Gubblag.Gubblagsnamn.ToString()),
                    new DatabasParameters("@AnvandarNamnSkapad", DataTyp.VarChar, Gubblag.AnvandarNamnSkapad.ToString()),
                    new DatabasParameters("@SkapadDatum", DataTyp.VarChar, Gubblag.SkapadDatum.ToString()),
                    new DatabasParameters("@AnvandarNamnUppdat", DataTyp.VarChar, Gubblag.AnvandarNamnUppdat.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.VarChar, Gubblag.UppdatDatum.ToString())
                };

                DatabasAccess.RunSql(sql, dbParameters);
                sql = "SELECT LAST_INSERT_ID()";
                nyttGubblagID = Convert.ToInt32(DatabasAccess.ExecuteScalar(sql));
                Gubblag.GubblagID = nyttGubblagID;
                DatabasAccess.BekräftaTransaktion();
                SparaNyGubblagsSpelare(Gubblag, ref felID, ref feltext);
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
            return nyttGubblagID;
        }

        /// <summary>
        /// Ny Gubblagsspelare.
        /// </summary>
        /// <param name="Gubblag">Gubblag</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaNyGubblagsSpelare(Gubblag Gubblag, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                for (int i = 0; i < Gubblag.gubblagsSpelares.Length; i++)
                {
                    sql = "INSERT INTO GubblagsSpelare(GubblagID, BollNr, SpelarID, SpelareNamn) " +
                        "VALUES " +
                        "(@GubblagID, @BollNr, @SpelarID, @SpelareNamn)";

                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@GubblagID", DataTyp.Int, Gubblag.GubblagID.ToString()),
                        new DatabasParameters("@Bollnr", DataTyp.VarChar, Gubblag.gubblagsSpelares[i].BollNr.ToString()),
                        new DatabasParameters("@SpelarID", DataTyp.Int, Gubblag.gubblagsSpelares[i].SpelarID.ToString()),
                        new DatabasParameters("@SpelareNamn", DataTyp.VarChar, Gubblag.gubblagsSpelares[i].SpelareNamn.ToString())
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
        /// Sparar i Gubblag.
        /// </summary>
        /// <param name="Gubblag">Gubblaget</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaGubblag(Gubblag Gubblag, bool nyaGubblagsSpelare, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "UPDATE Gubblag " +
                    "SET Gubblagsnamn = @Gubblagsnamn, " +
                    "AnvandarNamnSkapad = @AnvandarNamnSkapad, " +
                    "AnvandarNamnUppdat = @AnvandarNamnUppdat, UppdatDatum = @UppdatDatum " +
                    "WHERE GubblagID = @GubblagID";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@GubblagID", DataTyp.Int, Gubblag.GubblagID.ToString()),
                    new DatabasParameters("@Gubblagsnamn", DataTyp.VarChar, Gubblag.Gubblagsnamn.ToString()),
                    new DatabasParameters("@AnvandarNamnSkapad", DataTyp.VarChar, Gubblag.AnvandarNamnSkapad.ToString()),
                    new DatabasParameters("@SkapadDatum", DataTyp.VarChar, Gubblag.SkapadDatum.ToString()),
                    new DatabasParameters("@AnvandarNamnUppdat", DataTyp.VarChar, Gubblag.AnvandarNamnUppdat.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.VarChar, Gubblag.UppdatDatum.ToString())
                };

                DatabasAccess.RunSql(sql, dbParameters);
                DatabasAccess.BekräftaTransaktion();

                if(nyaGubblagsSpelare)
                {
                    SparaNyGubblagsSpelare(Gubblag, ref felID, ref feltext);
                }
                else
                {
                    SparaGubblagsSpelare(Gubblag, ref felID, ref feltext);
                }
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
        /// Spara GubblagsSpelare.
        /// </summary>
        /// <param name="Gubblag">Gubblag"</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaGubblagsSpelare(Gubblag Gubblag, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                for (int i = 0; i < Gubblag.gubblagsSpelares.Length; i++)
                {
                    sql = "UPDATE GubblagsSpelare SET BollNr = @Bollnr, SpelarID = @SpelarID, " +
                        "SpelareNamn = @SpelareNamn " +
                        "WHERE GubblagID = @GubblagID AND BollNr = @BollNr";

                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@GubblagID", DataTyp.Int, Gubblag.GubblagID.ToString()),
                        new DatabasParameters("@Bollnr", DataTyp.VarChar, Gubblag.gubblagsSpelares[i].BollNr.ToString()),
                        new DatabasParameters("@SpelarID", DataTyp.Int, Gubblag.gubblagsSpelares[i].SpelarID.ToString()),
                        new DatabasParameters("@SpelareNamn", DataTyp.VarChar, Gubblag.gubblagsSpelares[i].SpelareNamn.ToString())
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
        /// Ta bort Bokning.
        /// </summary>
        /// <param name="Gubblag">Gubblag</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TabortGubblag(Gubblag Gubblag, ref string felID, ref string feltext)
        {
            string sql;
            DatabasAccess.SkapaTransaktion();

            try
            {
                sql = "DELETE FROM Gubblag WHERE GubblagID = @GubblagID";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@GubblagID", DataTyp.Int, Gubblag.GubblagID.ToString())
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
