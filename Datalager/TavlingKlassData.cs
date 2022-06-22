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
    /// Datalagerklass för TavlingKlass
    /// </summary>
    public sealed class TavlingKlassData : AbstractDataLager
    {
        /// <summary>
        /// Hämtar rad från tabellen Tavling i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="tavlingID">Aktuell Tavling</param>
        /// <param name="klass">Aktuell klass</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public TavlingKlassDS HämtaTavlingKlass(int tavlingID, string klass)
        {
            TavlingKlassDS ds = new TavlingKlassDS();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingID.ToString()),
                    new DatabasParameters("@Klass", DataTyp.NChar, klass)
                };
                DatabasAccess.ExecuteSP("GetTavlingKlassByPrimaryKey", dbParameters, ds);
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
        /// Hämtar rad från tabellen TavlingKlass i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="tavlingID">Aktuell Tavling</param>
        /// <param name="klass">Aktuell tävlingsklass</param>
        /// <returns>Otypat dataset med efterfrågat data</returns>
        public DataSet HämtaTavlingKlassTavlingRond(int tavlingID, string klass)
        {
            DataSet tavlingKlassTavlingRondDS = new DataSet();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingID.ToString()),
                    new DatabasParameters("@Klass", DataTyp.NChar, klass)
                };
                tavlingKlassTavlingRondDS = DatabasAccess.ExecuteSP("GetTavlingKlassTavlingRond", dbParameters);
                tavlingKlassTavlingRondDS.Tables[0].TableName = "TavlingKlass";
                tavlingKlassTavlingRondDS.Tables[1].TableName = "TavlingRond";
                return tavlingKlassTavlingRondDS;
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
        /// Hämtar rad från tabellen TavlingKlass i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="sqlSok">Eventuellt where-villkor</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public TavlingKlassDS SökTavlingKlass(string sqlSok)
        {
            TavlingKlassDS ds = new TavlingKlassDS();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>();
                DatabasAccess.ExecuteSP("GetTavlingKlassByPrimaryKey", dbParameters, ds);
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
        /// <param name="klass">Aktuell klass</param>
        /// <returns>Typat dataset med alla registrerade rundor på banan</returns>
        public TavlingKlassDS KollaAntaletTavlingRonder(string klass)
        {
            DataSet ds = new DataSet();
            string sql;

            try
            {
                sql = "SELECT r.* FROM TavlingKlass r WHERE r.BanaNr = @BanaNr";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@BanaNr", DataTyp.Int, klass)
                };
                DatabasAccess.FyllEnkeltDataSet(sql, dbParameters, ds);
                return (TavlingKlassDS)ds;
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
        /// Kolla hur många tävlingar som finns registrerad på aktuell spelare
        /// </summary>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <returns>Typat dataset med alla registrerade rundor på spelaren</returns>
        public TavlingKlassDS KollaAntaletTavlingarForSpelare(int spelarID)
        {
            string sql;
            DataSet ds = new DataSet();

            try
            {
                sql = "SELECT r.* FROM TavlingKlass r WHERE r.SpelarID = @SpelarID";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@SpelarID", DataTyp.Int, spelarID.ToString())
                };
                DatabasAccess.FyllEnkeltDataSet(sql, dbParameters, ds);
                return (TavlingKlassDS)ds;
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
        /// Ta bort angiven TavlingKlass
        /// </summary>
        /// <param name="tavlingKlass">TavlingKlassobjekt</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBortTavlingKlass(TavlingKlass tavlingKlass, ref string felID, ref string feltext)
        {
            string sql;
            try
            {
                sql = "DELETE FROM TavlingKlass WHERE TavlingID = @TavlingID AND Klass = @Klass";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingKlass.TavlingID.ToString()),
                    new DatabasParameters("@Klass", DataTyp.NChar, tavlingKlass.Klass)
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
        /// Ny tavlingKlass.
        /// </summary>
        /// <param name="tavlingKlass">TavlingKlass</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int SparaNyTavlingKlass(TavlingKlass tavlingKlass, ref string felID, ref string feltext)
        {
            int nyaRader = 0;

            try
            {
                DatabasAccess.SkapaTransaktion();
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingKlass.TavlingID.ToString()),
                    new DatabasParameters("@Klass", DataTyp.NChar, tavlingKlass.Klass),
                    new DatabasParameters("@Spelform", DataTyp.NChar, tavlingKlass.Spelform),
                    new DatabasParameters("@Klasstyp", DataTyp.NChar, tavlingKlass.Klasstyp),
                    new DatabasParameters("@AntRonder", DataTyp.Int, tavlingKlass.AntRonder.ToString()),
                    new DatabasParameters("@TeeMan", DataTyp.NChar, tavlingKlass.TeeMan),
                    new DatabasParameters("@TeeKvinna", DataTyp.NChar, tavlingKlass.TeeKvinna),
                    new DatabasParameters("@OnskemalOmTee", DataTyp.NChar, tavlingKlass.OnskemalOmTee),
                    new DatabasParameters("@Kon", DataTyp.NChar, tavlingKlass.Kon),
                    new DatabasParameters("@Anmalningsavgift", DataTyp.Int, tavlingKlass.Anmalningsavgift.ToString()),
                    new DatabasParameters("@Tillaggsavgift", DataTyp.Int, tavlingKlass.Tillaggsavgift.ToString()),
                    new DatabasParameters("@MinHcpMan", DataTyp.Decimal, tavlingKlass.MinHcpMan.ToString()),
                    new DatabasParameters("@MaxHcpMan", DataTyp.Decimal, tavlingKlass.MaxHcpMan.ToString()),
                    new DatabasParameters("@MinHcpKvinna", DataTyp.Decimal, tavlingKlass.MinHcpKvinna.ToString()),
                    new DatabasParameters("@MaxHcpKvinna", DataTyp.Decimal, tavlingKlass.MaxHcpKvinna.ToString()),
                    new DatabasParameters("@MinHcpLag", DataTyp.Decimal, tavlingKlass.MinHcpLag.ToString()),
                    new DatabasParameters("@MaxHcpLag", DataTyp.Decimal, tavlingKlass.MaxHcpLag.ToString()),
                    new DatabasParameters("@MinAlderMan", DataTyp.Int, tavlingKlass.MinAlderMan.ToString()),
                    new DatabasParameters("@MaxAlderMan", DataTyp.Int, tavlingKlass.MaxAlderMan.ToString()),
                    new DatabasParameters("@MinAlderKvinna", DataTyp.Int, tavlingKlass.MinAlderKvinna.ToString()),
                    new DatabasParameters("@MaxAlderKvinna", DataTyp.Int, tavlingKlass.MaxAlderKvinna.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, tavlingKlass.UppdatDatum.ToString())
                };
                DatabasAccess.ExecuteSP("InsertTavlingKlass", dbParameters);
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
        /// Sparar i tavlingKlass.
        /// </summary>
        /// <param name="tavlingKlass">TavlingKlass</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaTavlingKlass(TavlingKlass tavlingKlass, ref string felID, ref string feltext)
        {
            try
            {
                DatabasAccess.SkapaTransaktion();
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingKlass.TavlingID.ToString()),
                    new DatabasParameters("@Klass", DataTyp.NChar, tavlingKlass.Klass),
                    new DatabasParameters("@Spelform", DataTyp.NChar, tavlingKlass.Spelform),
                    new DatabasParameters("@Klasstyp", DataTyp.NChar, tavlingKlass.Klasstyp),
                    new DatabasParameters("@AntRonder", DataTyp.Int, tavlingKlass.AntRonder.ToString()),
                    new DatabasParameters("@TeeMan", DataTyp.NChar, tavlingKlass.TeeMan),
                    new DatabasParameters("@TeeKvinna", DataTyp.NChar, tavlingKlass.TeeKvinna),
                    new DatabasParameters("@OnskemalOmTee", DataTyp.NChar, tavlingKlass.OnskemalOmTee),
                    new DatabasParameters("@Kon", DataTyp.NChar, tavlingKlass.Kon),
                    new DatabasParameters("@Anmalningsavgift", DataTyp.Int, tavlingKlass.Anmalningsavgift.ToString()),
                    new DatabasParameters("@Tillaggsavgift", DataTyp.Int, tavlingKlass.Tillaggsavgift.ToString()),
                    new DatabasParameters("@MinHcpMan", DataTyp.Decimal, tavlingKlass.MinHcpMan.ToString()),
                    new DatabasParameters("@MaxHcpMan", DataTyp.Decimal, tavlingKlass.MaxHcpMan.ToString()),
                    new DatabasParameters("@MinHcpKvinna", DataTyp.Decimal, tavlingKlass.MinHcpKvinna.ToString()),
                    new DatabasParameters("@MaxHcpKvinna", DataTyp.Decimal, tavlingKlass.MaxHcpKvinna.ToString()),
                    new DatabasParameters("@MinHcpLag", DataTyp.Decimal, tavlingKlass.MinHcpLag.ToString()),
                    new DatabasParameters("@MaxHcpLag", DataTyp.Decimal, tavlingKlass.MaxHcpLag.ToString()),
                    new DatabasParameters("@MinAlderMan", DataTyp.Int, tavlingKlass.MinAlderMan.ToString()),
                    new DatabasParameters("@MaxAlderMan", DataTyp.Int, tavlingKlass.MaxAlderMan.ToString()),
                    new DatabasParameters("@MinAlderKvinna", DataTyp.Int, tavlingKlass.MinAlderKvinna.ToString()),
                    new DatabasParameters("@MaxAlderKvinna", DataTyp.Int, tavlingKlass.MaxAlderKvinna.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, tavlingKlass.UppdatDatum.ToString())
                };
                DatabasAccess.ExecuteSP("UpdateTavlingKlass", dbParameters);
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
