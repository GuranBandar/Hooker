using System;
using System.Collections.Generic;
using Hooker.Affärsobjekt;
using Hooker.Dataset;
using Hooker.Gemensam;
using GemensamService;

namespace Hooker.Datalager
{
    /// <summary>
    /// Datalagerklass för TavlingRond
    /// </summary>
    public sealed class TavlingRondData : AbstractDataLager
    {
        /// <summary>
        /// Hämtar en post i tabellen TavlingRond
        /// </summary>
        /// <param name="rondID">Aktuell rond</param>
        /// <returns>Typat dataset med aktuell information</returns>
        public TavlingRondDS HämtaTavlingRond(int rondID)
        {
            TavlingRondDS ds = new TavlingRondDS();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RondID", DataTyp.Int, rondID.ToString())
                };
                DatabasAccess.ExecuteSP("GetTavlingRondByPrimaryKey", dbParameters, ds);
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
        /// Hämtar alla tavlingsrondposter i tabellen TavlingRond för angiven tavling och klass
        /// </summary>
        /// <param name="tavlingID">Aktuell tavling</param>
        /// <param name="klass">Aktuell klass</param>
        /// <returns>Typat dataset med aktuell information</returns>
        public TavlingRondDS HämtaAllaTavlingRonderFörTävlingOchKlass(int tavlingID, string klass)
        {
            TavlingRondDS ds = new TavlingRondDS();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingID.ToString()),
                    new DatabasParameters("@Klass", DataTyp.NChar, klass)
                };
                DatabasAccess.ExecuteSP("GetTavlingRondByTavlingIDAndKlass", dbParameters, ds);
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
        /// Hämtar tavlingsrondpost i tabellen TavlingRond för angiven tavling och rondnr
        /// </summary>
        /// <param name="tavlingID">Aktuell tavling</param>
        /// <param name="rondNr">Aktuell klass</param>
        /// <returns>Typat dataset med aktuell information</returns>
        public TavlingRondDS HämtaTavlingRondFörTävlingOchRondNr(int tavlingID, int rondNr)
        {
            TavlingRondDS ds = new TavlingRondDS();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingID.ToString()),
                    new DatabasParameters("@RondNr", DataTyp.Int, rondNr.ToString())
                };
                DatabasAccess.ExecuteSP("GetTavlingRondByTavlingIDAndRondNr", dbParameters, ds);
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
        /// Ta bort angiven TavlingRond
        /// </summary>
        /// <param name="tavlingRond">TavlingRondobjekt</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBortTavlingRond(TavlingRond tavlingRond, ref string felID, ref string feltext)
        {
            string sql;
            try
            {
                sql = "	DELETE FROM TavlingRond WHERE RondID = @RondID";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RondID", DataTyp.Int, tavlingRond.RondId.ToString())
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
        /// Ta bort TavlingRonder
        /// </summary>
        /// <param name="tavling">Tavlingobjekt</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBortTavlingRonder(Tavling tavling, ref string felID, ref string feltext)
        {
            string sql;
            try
            {
                sql = "	DELETE FROM TavlingRond WHERE TavlingID = @TavlingID";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavling.TavlingID.ToString())
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
        /// Ny TavlingRond.
        /// </summary>
        /// <param name="tavlingRond">TavlingRond</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int SparaNyTavlingRond(TavlingRond tavlingRond, ref string felID, ref string feltext)
        {
            int nyaRader = 1;

            try
            {
                DatabasAccess.SkapaTransaktion();
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingRond.TavlingID.ToString()),
                    new DatabasParameters("@Klass", DataTyp.NChar, tavlingRond.Klass),
                    new DatabasParameters("@RondNr", DataTyp.Int, tavlingRond.RondNr.ToString()),
                    new DatabasParameters("@Datum", DataTyp.SmallDateTime, tavlingRond.Datum.ToString()),
                    new DatabasParameters("@ForstaStartTid", DataTyp.Time, tavlingRond.ForstaStartTid.ToString()),
                    new DatabasParameters("@AntalHal", DataTyp.Int, tavlingRond.AntalHal.ToString()),
                    new DatabasParameters("@Cut", DataTyp.NChar, tavlingRond.Cut),
                    new DatabasParameters("@SpelarIDNearest", DataTyp.Int, tavlingRond.SpelarIDNearest.ToString()),
                    new DatabasParameters("@SpelarIDLOngest", DataTyp.Int, tavlingRond.SpelarIDLongest.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, tavlingRond.UppdatDatum.ToString()),
                    new DatabasParameters("@RondStatus", DataTyp.NChar, tavlingRond.RondStatus),
                    new DatabasParameters("@BanaNr", DataTyp.Int, tavlingRond.BanaNr.ToString())
                };
                DatabasAccess.ExecuteSP("InsertTavlingRond", dbParameters);
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
        /// Sparar i TavlingRond.
        /// </summary>
        /// <param name="tavlingRond">TavlingRond</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void Spara(TavlingRond tavlingRond, ref string felID, ref string feltext)
        {
            try
            {
                DatabasAccess.SkapaTransaktion();
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RondID", DataTyp.Int, tavlingRond.RondId.ToString()),
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingRond.TavlingID.ToString()),
                    new DatabasParameters("@Klass", DataTyp.NChar, tavlingRond.Klass),
                    new DatabasParameters("@RondNr", DataTyp.Int, tavlingRond.RondNr.ToString()),
                    new DatabasParameters("@Datum", DataTyp.SmallDateTime, tavlingRond.Datum.ToString()),
                    new DatabasParameters("@ForstaStartTid", DataTyp.Time, tavlingRond.ForstaStartTid.ToString()),
                    new DatabasParameters("@AntalHal", DataTyp.Int, tavlingRond.AntalHal.ToString()),
                    new DatabasParameters("@Cut", DataTyp.NChar, tavlingRond.Cut),
                    new DatabasParameters("@SpelarIDNearest", DataTyp.Int, tavlingRond.SpelarIDNearest.ToString()),
                    new DatabasParameters("@SpelarIDLOngest", DataTyp.Int, tavlingRond.SpelarIDLongest.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, tavlingRond.UppdatDatum.ToString()),
                    new DatabasParameters("@RondStatus", DataTyp.NChar, tavlingRond.RondStatus),
                    new DatabasParameters("@BanaNr", DataTyp.Int, tavlingRond.BanaNr.ToString())
                };
                DatabasAccess.ExecuteSP("UpdateTavlingRond", dbParameters);
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
