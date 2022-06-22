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
    /// Datalagerklass för TavlingStartlista
    /// </summary>
    public sealed class TavlingStartlistaData : AbstractDataLager
    {
        /// <summary>
        /// Hämta Startlistan för aktuell tävling
        /// </summary>
        /// <param name="tavlingID">Aktuellt TavlingID</param>
        /// <returns>Otypat dataset med aktuell information</returns>
        public DataSet HämtaStartlista(int tavlingID)
        {
            DataSet startlistaDS = new DataSet();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingID.ToString())
                };
                startlistaDS = DatabasAccess.ExecuteSP("GetStartlista", dbParameters);
                startlistaDS.Tables[0].TableName = "Startlista";
                return startlistaDS;
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
        /// Ny TavlingStartlista.
        /// </summary>
        /// <param name="tavlingStartlista">TavlingStartlista</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaNyTavlingStartlista(TavlingStartlista tavlingStartlista, ref string felID, ref string feltext)
        {
            try
            {
                DatabasAccess.SkapaTransaktion();
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RondID", DataTyp.Int, tavlingStartlista.RondID.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, tavlingStartlista.SpelareID.ToString()),
                    new DatabasParameters("@BollNr", DataTyp.Int, tavlingStartlista.BollNr.ToString()),
                    new DatabasParameters("@Hal", DataTyp.Int, tavlingStartlista.Hal.ToString()),
                    new DatabasParameters("@StartDatum", DataTyp.SmallDateTime, tavlingStartlista.StartDatum.ToString()),
                    new DatabasParameters("@Starttid", DataTyp.Time, tavlingStartlista.Starttid.ToString()),
                    new DatabasParameters("@Klass", DataTyp.NChar, tavlingStartlista.Klass),
                    new DatabasParameters("@ExaktHcp", DataTyp.Decimal, tavlingStartlista.ExaktHcp.ToString()),
                    new DatabasParameters("@ErhallnaSlag", DataTyp.Int, tavlingStartlista.ErhallnaSlag.ToString()),
                    new DatabasParameters("@Tee", DataTyp.NChar, tavlingStartlista.Tee),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, tavlingStartlista.UppdatDatum.ToString())
                };
                DatabasAccess.ExecuteSP("InsertTavlingStartlista", dbParameters);
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
        /// Uppdatera TavlingStartlista.
        /// </summary>
        /// <param name="tavling">Tavling</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void UppdateraTavlingStartlista(Tavling tavling, ref string felID, ref string feltext)
        {
            try
            {
                DatabasAccess.SkapaTransaktion();

                for (int i = 0; i < tavling.TavlingStartlista.Length; i++)
                {
                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@RondID", DataTyp.Int, tavling.TavlingStartlista[i].RondID.ToString()),
                        new DatabasParameters("@SpelarID", DataTyp.Int, tavling.TavlingStartlista[i].SpelareID.ToString()),
                        new DatabasParameters("@BollNr", DataTyp.Int, tavling.TavlingStartlista[i].BollNr.ToString()),
                        new DatabasParameters("@Hal", DataTyp.Int, tavling.TavlingStartlista[i].Hal.ToString()),
                        new DatabasParameters("@StartDatum", DataTyp.SmallDateTime, tavling.TavlingStartlista[i].StartDatum.ToString()),
                        new DatabasParameters("@Starttid", DataTyp.Time, tavling.TavlingStartlista[i].Starttid.ToString()),
                        new DatabasParameters("@Klass", DataTyp.NChar, tavling.TavlingStartlista[i].Klass),
                        new DatabasParameters("@ExaktHcp", DataTyp.Decimal, tavling.TavlingStartlista[i].ExaktHcp.ToString()),
                        new DatabasParameters("@ErhallnaSlag", DataTyp.Int, tavling.TavlingStartlista[i].ErhallnaSlag.ToString()),
                        new DatabasParameters("@Tee", DataTyp.NChar, tavling.TavlingStartlista[i].Tee),
                        new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, tavling.TavlingStartlista[i].UppdatDatum.ToString())
                    };
                    DatabasAccess.ExecuteSP("UpdateTavlingStartlista", dbParameters);
                }
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
        /// Ta bort angiven TavlingStartlista
        /// </summary>
        /// <param name="rondID">Aktuellt rondID</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBortTavlingStartlista(int rondID, int spelarID, ref string felID, ref string feltext)
        {
            string sql;
            try
            {
                sql = "DELETE FROM TavlingStartlista WHERE RondID = RondID AND SpelarID = @SpelarID";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RondID", DataTyp.Int, rondID.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, spelarID.ToString())
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
