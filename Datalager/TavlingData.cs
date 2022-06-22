using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Hooker.Affärsobjekt;
using Hooker.Dataset;
using Hooker.Gemensam;
using GemensamService;

namespace Hooker.Datalager
{
    /// <summary>
    /// Datalagerklass för Tavling
    /// </summary>
    public sealed class TavlingData : AbstractDataLager
    {
        /// <summary>
        /// Hämtar rad från tabellen Tavling i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="tavlingID">Aktuell Tavling</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public TavlingDS HämtaTavling(int tavlingID)
        {
            TavlingDS ds = new TavlingDS();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@tavlingID", DataTyp.Int, tavlingID.ToString())
                };
                DatabasAccess.ExecuteSP("GetTavlingByPrimaryKey", dbParameters, ds);
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
        /// Hämtar alla tävlingar för aktuell period.
        /// </summary>
        /// <param name="fromDatum">From datum</param>
        /// <param name="tomDatum">Tom datum</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public TavlingDS HämtaAllaTavlingar(DateTime fromDatum, DateTime tomDatum)
        {
            TavlingDS ds = new TavlingDS();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@FromDatum", DataTyp.SmallDateTime, fromDatum.ToString()),
                    new DatabasParameters("@TomDatum", DataTyp.SmallDateTime ,tomDatum.ToString())
                };
                DatabasAccess.ExecuteSP("GetTavlingAll", dbParameters, ds);
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
        /// Hämtar alla tävlingar för aktuell period som är pågående eller stängda.
        /// </summary>
        /// <param name="fromDatum">From datum</param>
        /// <param name="tomDatum">Tom datum</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public TavlingDS HämtaAllaStartadeEllerKlaraTavlingar(DateTime fromDatum, DateTime tomDatum)
        {
            TavlingDS ds = new TavlingDS();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@FromDatum", DataTyp.SmallDateTime, fromDatum.ToString()),
                    new DatabasParameters("@TomDatum", DataTyp.SmallDateTime ,tomDatum.ToString())
                };
                DatabasAccess.ExecuteSP("GetTavlingAllaStartadeEllerKlara", dbParameters, ds);
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
        /// Hämtar rad från tabellen Tavling i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="tavlingID">Aktuell Tavling</param>
        /// <returns>Otypat dataset med efterfrågat data</returns>
        public DataSet HämtaTavlingTavlingKlass(int tavlingID)
        {
            DataSet tavlingTavlingKlassDS = new DataSet();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@tavlingID", DataTyp.Int, tavlingID.ToString())
                };
                tavlingTavlingKlassDS = DatabasAccess.ExecuteSP("GetTavlingTavlingKlass", dbParameters);
                tavlingTavlingKlassDS.Tables[0].TableName = "Tavling";
                tavlingTavlingKlassDS.Tables[1].TableName = "TavlingKlass";
                return tavlingTavlingKlassDS;
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
        /// Hämtar alla tävlingsrader för Tavling i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="tavlingID">Aktuell Tavling</param>
        /// <returns>Otypat dataset med efterfrågat data</returns>
        public DataSet HämtaTavlingAllt(int tavlingID)
        {
            DataSet tavlingAllDS = new DataSet();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@tavlingID", DataTyp.Int, tavlingID.ToString())
                };
                tavlingAllDS = DatabasAccess.ExecuteSP("GetTavlingAllByTavlingID", dbParameters);
                tavlingAllDS.Tables[0].TableName = "Tavling";
                tavlingAllDS.Tables[1].TableName = "TavlingKlass";
                tavlingAllDS.Tables[2].TableName = "TavlingDeltagare";
                tavlingAllDS.Tables[3].TableName = "TavlingRond";
                tavlingAllDS.Tables[4].TableName = "TavlingRondResultat";
                tavlingAllDS.Tables[5].TableName = "TavlingStartlista";
                return tavlingAllDS;
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
        /// Hämtar rad från tabellen Tavling i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="sqlSok">Eventuellt where-villkor</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public DataSet SökTavling(string sqlSok)
        {
            DataSet tavlingDS = new DataSet();
            string sql = "SELECT DISTINCT t.TavlingID, t.StartDatum, t.Namn AS TavlingNamn, t.Notering AS Notering, " +
                "k1.Varde AS Spelsätt, k2.Varde AS Speltyp, k3.Varde AS Spelform, k4.Varde AS status " +
                "FROM Tavling t " +
                "LEFT OUTER JOIN TavlingKlass tk ON tk.TavlingID = t.TavlingID " +
                "LEFT OUTER JOIN Koder k1 ON k1.Typ = 13 AND k1.Argument = t.Spelsatt " +
                "LEFT OUTER JOIN Koder k2 ON k2.Typ = 14 AND k2.Argument = t.Speltyp " +
                "LEFT OUTER JOIN Koder k3 ON k3.Typ = 11 AND k3.Argument = tk.Spelform " +
                "LEFT OUTER JOIN Koder k4 ON k4.Typ = 12 AND k4.Argument = t.TavlingStatus " +
                sqlSok.ToString();

            try
            {
                tavlingDS = DatabasAccess.RunSql(sql);
                tavlingDS.Tables[0].TableName = "Tavling";
                return tavlingDS;
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
        /// Kolla hur många anmälda som finns registrerad på aktuell taävling
        /// </summary>
        /// <param name="tavlingID">Aktuellt tavlingID</param>
        /// <returns>Antalet anmälda på aktuell tavling</returns>
        public TavlingDeltagareDS KollaAntaletAnmalda(int tavlingID)
        {
            TavlingDeltagareDS ds = new TavlingDeltagareDS();
            string sql;

            try
            {
                sql = "SELECT * FROM TavlingDeltagare WHERE TavlingID = @TavlingID";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@tavlingID", DataTyp.Int, tavlingID.ToString())
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
        /// Kolla hur många tävlingar som finns registrerad på aktuell spelare
        /// </summary>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <returns>Typat dataset med alla registrerade rundor på spelaren</returns>
        public TavlingDS KollaAntaletTavlingarForSpelare(int spelarID)
        {
            TavlingDS ds = new TavlingDS();
            string sql;

            try
            {
                sql = "SELECT r.* FROM Tavling r WHERE r.SpelarID = @SpelarID";
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
        /// Ta bort angiven Tavling
        /// </summary>
        /// <param name="tavling">Tavlingobjekt</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBortTavling(Tavling tavling, ref string felID, ref string feltext)
        {
            StringBuilder sql = new StringBuilder();
            try
            {
                DatabasAccess.SkapaTransaktion();
                sql.Append("DELETE c FROM TavlingKlass AS c WHERE c.TavlingID = @TavlingID;");
                sql.Append("DELETE c FROM TavlingDeltagare AS c WHERE c.TavlingID = @TavlingID;");
                sql.Append("DELETE c FROM TavlingRond AS c WHERE c.TavlingID = @TavlingID;");
                sql.Append("DELETE FROM Tavling WHERE TavlingID = @TavlingID;") ;

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavling.TavlingID.ToString())
                };

                DatabasAccess.RunSql(sql.ToString(), dbParameters);

                if (tavling.HarTavlingRond())
                {
                    sql = new StringBuilder();
                    sql.Append("DELETE c FROM TavlingRondResultat AS c WHERE c.RondID = @RondID;");
                    sql.Append("DELETE c FROM TavlingStartlista AS c WHERE c.RondID = @RondID;");
                }

                dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RondID", DataTyp.Int, tavling.TavlingRond[0].RondId.ToString())
                };

                DatabasAccess.RunSql(sql.ToString(), dbParameters);
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
        /// Ny Tavling.
        /// </summary>
        /// <param name="Tavling">Tavling</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int SparaNyTavling(Tavling Tavling, ref string felID, ref string feltext)
        {
            int nyttTavlingID;
            DataSet ds = new DataSet();

            try
            {
                DatabasAccess.SkapaTransaktion();
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@Namn", DataTyp.NVarChar,Tavling.Namn),
                    new DatabasParameters("@StartDatum", DataTyp.SmallDateTime, Tavling.StartDatum.ToString()),
                    new DatabasParameters("@TavlingStatus", DataTyp.NChar, Tavling.TavlingStatus),
                    new DatabasParameters("@Spelsatt", DataTyp.NChar, Tavling.Spelsatt),
                    new DatabasParameters("@Speltyp", DataTyp.NChar, Tavling.Speltyp),
                    new DatabasParameters("@OppenFor", DataTyp.NChar, Tavling.OppenFor),
                    new DatabasParameters("@AnmalanTidigast", DataTyp.SmallDateTime, Tavling.AnmalanTidigast.ToString()),
                    new DatabasParameters("@AnmalanSenast", DataTyp.SmallDateTime, Tavling.AnmalanSenast.ToString()),
                    new DatabasParameters("@StartlistaPubliceras", DataTyp.SmallDateTime, Tavling.StartlistaPubliceras.ToString()),
                    new DatabasParameters("@ForstaStart", DataTyp.SmallDateTime, Tavling.ForstaStart.ToString()),
                    new DatabasParameters("@MaxAntalAnmalda", DataTyp.Int, Tavling.MaxAntalAnmalda.ToString()),
                    new DatabasParameters("@PrincipForOveranmalan", DataTyp.NChar, Tavling.PrincipForOveranmalan),
                    new DatabasParameters("@Startavgift", DataTyp.Int, Tavling.Startavgift.ToString()),
                    new DatabasParameters("@Greenfee", DataTyp.Int, Tavling.Greenfee.ToString()),
                    new DatabasParameters("@Prissumma", DataTyp.Int, Tavling.Prissumma.ToString()),
                    new DatabasParameters("@Notering", DataTyp.NVarChar, Tavling.Notering),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, Tavling.UppdatDatum.ToString()),
                    new DatabasParameters("@FleraBanor", DataTyp.NChar, Tavling.FleraBanor),
                    new DatabasParameters("@NassauBett", DataTyp.Int, Tavling.NassauBett.ToString())
                };
                ds = DatabasAccess.ExecuteSP("InsertTavling", dbParameters);

                nyttTavlingID = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
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
            return nyttTavlingID;
        }

        /// <summary>
        /// Sparar i Tavling.
        /// </summary>
        /// <param name="Tavling">Tavling</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaTavling(Tavling Tavling, ref string felID, ref string feltext)
        {

            try
            {
                DatabasAccess.SkapaTransaktion();
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@Namn", DataTyp.VarChar,Tavling.Namn),
                    new DatabasParameters("@StartDatum", DataTyp.SmallDateTime, Tavling.StartDatum.ToString()),
                    new DatabasParameters("@TavlingStatus", DataTyp.NChar, Tavling.TavlingStatus),
                    new DatabasParameters("@Spelsatt", DataTyp.NChar, Tavling.Spelsatt),
                    new DatabasParameters("@Speltyp", DataTyp.NChar, Tavling.Speltyp),
                    new DatabasParameters("@OppenFor", DataTyp.NChar, Tavling.OppenFor),
                    new DatabasParameters("@AnmalanTidigast", DataTyp.SmallDateTime, Tavling.AnmalanTidigast.ToString()),
                    new DatabasParameters("@AnmalanSenast", DataTyp.SmallDateTime, Tavling.AnmalanSenast.ToString()),
                    new DatabasParameters("@StartlistaPubliceras", DataTyp.SmallDateTime, Tavling.StartlistaPubliceras.ToString()),
                    new DatabasParameters("@ForstaStart", DataTyp.SmallDateTime, Tavling.ForstaStart.ToString()),
                    new DatabasParameters("@MaxAntalAnmalda", DataTyp.Int, Tavling.MaxAntalAnmalda.ToString()),
                    new DatabasParameters("@PrincipForOveranmalan", DataTyp.NChar, Tavling.PrincipForOveranmalan),
                    new DatabasParameters("@Startavgift", DataTyp.Int, Tavling.Startavgift.ToString()),
                    new DatabasParameters("@Greenfee", DataTyp.Int, Tavling.Greenfee.ToString()),
                    new DatabasParameters("@Prissumma", DataTyp.Int, Tavling.Prissumma.ToString()),
                    new DatabasParameters("@Notering", DataTyp.VarChar, Tavling.Notering),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, Tavling.UppdatDatum.ToString()),
                    new DatabasParameters("@FleraBanor", DataTyp.NChar, Tavling.FleraBanor),
                    new DatabasParameters("@NassauBett", DataTyp.Int, Tavling.NassauBett.ToString()),
                    new DatabasParameters("@TavlingID", DataTyp.Int, Tavling.TavlingID.ToString())
                };
                DatabasAccess.ExecuteSP("UpdateTavling", dbParameters);
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
