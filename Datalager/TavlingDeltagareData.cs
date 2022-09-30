using GemensamService;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hooker.Datalager
{
    /// <summary>
    /// Datalagerklass för TavlingKlass
    /// </summary>
    public sealed class TavlingDeltagareData : AbstractDataLager
    {
        /// <summary>
        /// Hämta Deltagarlistan för aktuell tävling
        /// </summary>
        /// <param name="tavlingID">Aktuellt TavlingID</param>
        /// <returns>Otypat dataset med aktuell information</returns>
        public DataSet HämtaDeltagarlista(int tavlingID)
        {
            DataSet deltagarlistaDS = new DataSet();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingID.ToString())
                };
                deltagarlistaDS = DatabasAccess.ExecuteSP("GetDeltagarlista", dbParameters);
                deltagarlistaDS.Tables[0].TableName = "Deltagarlista";
                return deltagarlistaDS;
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
        /// Hämtar spelare för tävlingsrond.
        /// </summary>
        /// <param name="tavlingID">Aktuellt tavlingID</param>
        /// <param name="rondID">Akteullt rondID</param>
        /// <returns>Objektlista med efterfrågat data</returns>
        public DataSet HämtaDeltagareFörTavlingRond(int tavlingID, int rondID)
        {
            DataSet spelareDS = new DataSet();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingID.ToString()),
                    new DatabasParameters("@RondID", DataTyp.Int, rondID.ToString())
                };
                spelareDS = DatabasAccess.ExecuteSP("GetDeltagareForTavlingRond", dbParameters);
                spelareDS.Tables[0].TableName = "Deltagare";
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
        /// Hämtar spelare för tävlingsrond.
        /// </summary>
        /// <param name="tavlingID">Aktuellt tavlingID</param>
        /// <returns>Objektlista med efterfrågat data</returns>
        public DataSet HämtaDeltagareFörTavling(int tavlingID)
        {
            DataSet spelareDS = new DataSet();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingID.ToString())
                };
                spelareDS = DatabasAccess.ExecuteSP("GetDeltagareForTavling", dbParameters);
                spelareDS.Tables[0].TableName = "Deltagare";
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
        /// Ta bort TavlingDelatagare
        /// </summary>
        /// <param name="spelarID">Aktuell spelare</param>
        /// <param name="tavlingID">Aktuellt tavlingID</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBort(int spelarID, int tavlingID, ref string felID, ref string feltext)
        {
            string sql;
            try
            {
                sql = "DELETE FROM TavlingDeltagare WHERE SpelarID = @SpelarID AND TavlingID = @TavlingID";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@SpelarID", DataTyp.Int, spelarID.ToString()),
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingID.ToString())
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
        /// Ny TavlingDeltagare.
        /// </summary>
        /// <param name="tavlingDeltagare">TavlingDeltagare</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int SparaNyTavlingDeltagare(TavlingDeltagare tavlingDeltagare, ref string felID,
            ref string feltext)
        {
            int nyaRader = 1;

            try
            {
                DatabasAccess.SkapaTransaktion();
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingDeltagare.TavlingID.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, tavlingDeltagare.SpelarID.ToString()),
                    new DatabasParameters("@Klass", DataTyp.NChar, tavlingDeltagare.Klass),
                    new DatabasParameters("@Hcp", DataTyp.Decimal, tavlingDeltagare.Hcp.ToString()),
                    new DatabasParameters("@SpelHcp", DataTyp.Int, tavlingDeltagare.SpelHcp.ToString()),
                    new DatabasParameters("@AnmaldNr", DataTyp.Int, tavlingDeltagare.AnmaldNr.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, tavlingDeltagare.UppdatDatum.ToString())
                };
                DatabasAccess.ExecuteSP("InsertTavlingDeltagare", dbParameters);
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
            return nyaRader;
        }

        /// <summary>
        /// Sparar i TavlingDeltagare.
        /// </summary>
        /// <param name="tavlingDeltagare">TavlingDeltagare</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaTavlingDeltagare(TavlingDeltagare tavlingDeltagare, ref string felID, ref string feltext)
        {
            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingDeltagare.TavlingID.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, tavlingDeltagare.SpelarID.ToString()),
                    new DatabasParameters("@Klass", DataTyp.NChar, tavlingDeltagare.Klass),
                    new DatabasParameters("@Hcp", DataTyp.Decimal, tavlingDeltagare.Hcp.ToString()),
                    new DatabasParameters("@SpelHcp", DataTyp.Int, tavlingDeltagare.SpelHcp.ToString()),
                    new DatabasParameters("@AnmaldNr", DataTyp.Int, tavlingDeltagare.AnmaldNr.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, tavlingDeltagare.UppdatDatum.ToString())
                };
                DatabasAccess.ExecuteSP("UpdateTavlingDeltagare", dbParameters);
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
