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
    /// Datalagerklass för Spelform
    /// </summary>
    public sealed class SpelformData : AbstractDataLager
    {
        /// <summary>
        /// Hämtar rad från tabellen Spelform i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="SpelformID">Aktuell spelform</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public SpelformDS HämtaSpelform(int SpelformID, string Sprakkod)
        {
            SpelformDS ds = new SpelformDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT s.* FROM Spelform s WHERE s.SpelformID = @SpelformID " +
                    "AND s.Sprakkod = @Sprakkod";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@SpelformID", DataTyp.Int, SpelformID.ToString()),
                    new DatabasParameters("@Sprakkod", DataTyp.String, Sprakkod.ToString())
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
        /// Hämtar alla rader från tabellen Spelform i aktuell databas.
        /// </summary>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public DataSet HämtaAllaSpelformer()
        {
            SpelformDS ds = new SpelformDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT s.* FROM Spelform s ORDER BY s.Beskrivning";
                DatabasAccess.FyllEnkeltDataSet(sql, ds);
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
        /// Hämtar rad från tabellen Spelform i aktuell databas.
        /// </summary>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public string HämtaMaxSpelform()
        {
            DataSet SpelformDS = new DataSet();
            string nyttSpelformID = string.Empty;
            string sql;

            try
            {
                sql = "SELECT s.SpelformID FROM Spelform s " +
                    " ORDER BY s.SpelformID DESC";
                SpelformDS = DatabasAccess.RunSql(sql);
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
            nyttSpelformID = SpelformDS.Tables[0].Rows[0]["SpelformID"].ToString();
            return nyttSpelformID;
        }

        /// <summary>
        /// Ny Spelform.
        /// </summary>
        /// <param name="Spelform">Spelform</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaNySpelform(Spelform Spelform, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "INSERT INTO Spelform(Sprakkod, Titel, Beskrivning, Lagspel, AntalPerLag, AnvandarNamnSkapad, " +
                    "SkapadDatum, AnvandarNamnUppdat, UppdatDatum) " +
                    "VALUES " +
                    "(@Sprakkod, @Titel, @Beskrivning, @Lagspel, @AntalPerLag, @AnvandarNamnSkapad, @SkapadDatum, " +
                    "@AnvandarNamnUppdat, @UppdatDatum)";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@Sprakkod", DataTyp.VarChar, Spelform.Sprakkod.ToString()),
                    new DatabasParameters("@Titel", DataTyp.VarChar, Spelform.Titel.ToString()),
                    new DatabasParameters("@Beskrivning", DataTyp.VarChar, Spelform.Beskrivning.ToString()),
                    new DatabasParameters("@Lagspel", DataTyp.VarChar, Spelform.Lagspel.ToString()),
                    new DatabasParameters("@AntalPerLag", DataTyp.VarChar, Spelform.AntalPerLag.ToString()),
                    new DatabasParameters("@AnvandarNamnSkapad", DataTyp.VarChar, Spelform.AnvandarNamnSkapad.ToString()),
                    new DatabasParameters("@SkapadDatum", DataTyp.VarChar, Spelform.SkapadDatum.ToString()),
                    new DatabasParameters("@AnvandarNamnUppdat", DataTyp.VarChar, Spelform.AnvandarNamnUppdat.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.VarChar, Spelform.UppdatDatum.ToString())
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
            //return nyttBokningID;
        }

        /// <summary>
        /// Sparar i Spelform.
        /// </summary>
        /// <param name="Spelform">Spelform</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaSpelform(Spelform Spelform, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();
                sql = "UPDATE Spelform " +
                    "SET Titel = @Sprakkod = Sprakkod, @Titel, Beskrivning = @Beskrivning, Lagspel = @Lagspel, " +
                    "AntalPerLag = @AntalPerLag, AnvandarNamnSkapad = @AnvandarNamnSkapad, " +
                    "AnvandarNamnUppdat = @AnvandarNamnUppdat, UppdatDatum = @UppdatDatum " +
                    "WHERE SpelformID = @SpelformID";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@SpelformID", DataTyp.Int, Spelform.SpelformID.ToString()),
                    new DatabasParameters("@Sprakkod", DataTyp.VarChar, Spelform.Sprakkod.ToString()),
                    new DatabasParameters("@Titel", DataTyp.VarChar, Spelform.Titel.ToString()),
                    new DatabasParameters("@Beskrivning", DataTyp.VarChar, Spelform.Beskrivning.ToString()),
                    new DatabasParameters("@Lagspel", DataTyp.VarChar, Spelform.Lagspel.ToString()),
                    new DatabasParameters("@AntalPerLag", DataTyp.VarChar, Spelform.AntalPerLag.ToString()),
                    new DatabasParameters("@AnvandarNamnSkapad", DataTyp.VarChar, Spelform.AnvandarNamnSkapad.ToString()),
                    new DatabasParameters("@SkapadDatum", DataTyp.VarChar, Spelform.SkapadDatum.ToString()),
                    new DatabasParameters("@AnvandarNamnUppdat", DataTyp.VarChar, Spelform.AnvandarNamnUppdat.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.VarChar, Spelform.UppdatDatum.ToString())
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
        /// Ta bort Spelform.
        /// </summary>
        /// <param name="Spelform">Spelform</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TabortSpelform(Spelform Spelform, ref string felID, ref string feltext)
        {
            string sql;
            DatabasAccess.SkapaTransaktion();

            try
            {
                sql = "DELETE FROM Spelform WHERE SpelformID = @SpelformID";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
            {
                new DatabasParameters("@SpelformID", DataTyp.Int, Spelform.SpelformID.ToString())
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
