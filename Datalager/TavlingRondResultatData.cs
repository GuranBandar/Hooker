using GemensamService;
using Hooker.Affärsobjekt;
using Hooker.Dataset;
using Hooker.Gemensam;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Hooker.Datalager
{
    /// <summary>
    /// Datalagerklass för TavlingRondResultat
    /// </summary>
    public sealed class TavlingRondResultatData : AbstractDataLager
    {
        /// <summary>
        /// Hämtar poster i tabellen TavlingRondResultat
        /// </summary>
        /// <param name="rondID">Aktuell rond</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <returns>Typat dataset med aktuell information</returns>
        public TavlingRondResultatDS HämtaTavlingRondResultat(int rondID, int spelarID)
        {
            TavlingRondResultatDS ds = new TavlingRondResultatDS();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RondID", DataTyp.Int, rondID.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, spelarID.ToString())
                };
                DatabasAccess.ExecuteSP("GetTavlingRondResultatForRondIDAndSpelarID", dbParameters, ds);
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
        /// Hämtar poster i tabellen TavlingRondResultat
        /// </summary>
        /// <param name="tavlingID">Aktuell tävlingID</param>
        /// <param name="rondNr">Aktuell rond</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <returns>Typat dataset med aktuell information</returns>
        public TavlingRondResultatDS HämtaTavlingRondResultatForSpelare(int tavlingID, int rondNr, int spelarID)
        {
            TavlingRondResultatDS ds = new TavlingRondResultatDS();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingID.ToString()),
                    new DatabasParameters("@RondNr", DataTyp.Int, rondNr.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, spelarID.ToString())
                };
                DatabasAccess.ExecuteSP("GetTavlingRondResultatForSpelare", dbParameters, ds);
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
        /// Hämtar rad i tabellen TavlingRondResultat
        /// </summary>
        /// <param name="rondID">Aktuell rond</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <param name="halnr">Aktuellt hålnr</param>
        /// <returns>Typat dataset med aktuell information</returns>
        public TavlingRondResultatDS HämtaTavlingRondResultat(int rondID, int spelarID, int halnr)
        {
            TavlingRondResultatDS ds = new TavlingRondResultatDS();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RondID", DataTyp.Int, rondID.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, spelarID.ToString()),
                    new DatabasParameters("@HalNr", DataTyp.Int, halnr.ToString())
                };
                DatabasAccess.ExecuteSP("GetTavlingRondResultatForRondIDAndSpelarIDAndHalNr", dbParameters, ds);
                return ds;
            }
            catch (HookerException hex)
            {
                throw hex;
            }
            catch (Exception ex)
            {
                this.CheckForErrors(ds);
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
        /// Hämta resultatlistan för aktuell tävling och rond
        /// </summary>
        /// <param name="tavlingID">TavlingID</param>
        /// <param name="klass">Aktuell tävlingsklass</param>
        /// <param name="rondNr">Aktuellt rondNr</param>
        /// <param name="slag">Om slag, true eller false</param>
        /// <returns>Otypat dataset med begärd information</returns>
        public DataSet HämtaResultatlista(int tavlingID, string klass, int rondNr, bool slag)
        {
            DataSet resultatlistaDS = new DataSet();
            string procedureName;

            try
            {
                if (slag)
                {
                    procedureName = "GetResultatlistaSlag";
                }
                else
                {
                    procedureName = "GetResultatlistaPoang";
                }

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingID.ToString()),
                    new DatabasParameters("@RondNr", DataTyp.Int, rondNr.ToString()),
                    new DatabasParameters("@Klass", DataTyp.NChar, klass)
                };
                resultatlistaDS = DatabasAccess.ExecuteSP(procedureName, dbParameters);
                resultatlistaDS.Tables[0].TableName = "Resultatlista";
                return resultatlistaDS;
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
        /// Hämta tävlingresultat för spelare
        /// </summary>
        /// <param name="tavlingID">Aktuellt TavlingID</param>
        /// <param name="spelarID">Aktuellt SpelarID</param>
        /// <returns>DataSet med TavlingResultat</returns>
        public DataSet HämtaTavlingResultatForSpelare(int tavlingID, int spelarID)
        {
            DataSet tavlingresultatDS = new DataSet();
            StringBuilder sql = new StringBuilder();

            try
            {
                sql.Append("SELECT trr.RondID, tr.RondNr, trr.SpelarID, ts.ExaktHcp, ts.ErhallnaSlag, trr.HalNr, ");
                sql.Append("trr.AntalSlag, trr.AntalPoang ");
                sql.Append("FROM TavlingRondResultat trr ");
                sql.Append("INNER JOIN TavlingRond tr ON tr.RondID = trr.RondID ");
                sql.Append("INNER JOIN TavlingStartlista ts ON ts.SpelarID = trr.SpelarID ");
                sql.Append("AND ts.RondID = trr.RondID ");
                sql.Append("WHERE tr.TavlingID = @TavlingID ");
                sql.Append("AND trr.SpelarID = @SpelarID ");
                sql.Append("ORDER BY tr.RondNr, trr.HalNr");

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingID.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, spelarID.ToString())
                };
                tavlingresultatDS = DatabasAccess.FyllDataSet(sql.ToString(), dbParameters);
                tavlingresultatDS.Tables[0].TableName = "TavlingResultat";
                return tavlingresultatDS;
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
        /// Hämta Nassauresultat för aktuell tävling
        /// </summary>
        /// <param name="tavlingID">TavlingID</param>
        /// <returns>Otypat dataset med begärd information</returns>
        public DataSet HämtaNassau(int tavlingID)
        {
            DataSet nassauDS = new DataSet();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingID.ToString())
                };
                nassauDS = DatabasAccess.ExecuteSP("GetNassau", dbParameters);
                nassauDS.Tables[0].TableName = "Nassau";
                return nassauDS;
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
        /// Hämta Troféresultat för aktuell tävling
        /// </summary>
        /// <param name="tavlingID">TavlingID</param>
        /// <returns>Otypat dataset med begärd information</returns>
        public DataSet HämtaTrofen(int tavlingID)
        {
            DataSet trofenDS = new DataSet();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingID.ToString())
                };
                trofenDS = DatabasAccess.ExecuteSP("GetTrofen", dbParameters);
                trofenDS.Tables[0].TableName = "Resultatlista";
                //trofenDS.Tables[1].TableName = "Ranking";
                return trofenDS;
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
        /// Hämta R2A
        /// </summary>
        /// <param name="tavlingID">TavlingID</param>
        /// <returns>Otypat dataset med begärd information</returns>
        public DataSet HämtaR2A(int tavlingID)
        {
            DataSet r2aDS = new DataSet();

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@TavlingID", DataTyp.Int, tavlingID.ToString())
                };
                r2aDS = DatabasAccess.ExecuteSP("GetR2A", dbParameters);
                r2aDS.Tables[0].TableName = "R2A";
                r2aDS.Tables[1].TableName = "Ranking";
                return r2aDS;
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
        /// Initierar tabellen TavlingRondResultat med en anmäld spelare
        /// </summary>
        /// <param name="tavlingRondResultat">Aktuellt objekt</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void InitieraTavlingRondResultat(TavlingRondResultat tavlingRondResultat, ref string felID, ref string feltext)
        {
            try
            {
                DatabasAccess.SkapaTransaktion();
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RondID", DataTyp.Int, tavlingRondResultat.RondId.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, tavlingRondResultat.SpelarID.ToString()),
                    new DatabasParameters("@HalNr", DataTyp.Int, tavlingRondResultat.HalNr.ToString()),
                    new DatabasParameters("@AntalSlag", DataTyp.Int, tavlingRondResultat.AntalSlag.ToString()),
                    new DatabasParameters("@AntalPoang", DataTyp.Int, tavlingRondResultat.AntalPoang.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, DateTime.Today.Date.ToString())
                };
                DatabasAccess.ExecuteSP("InsertTavlingRondResultat", dbParameters);
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
            finally
            {
                if (DatabasAccess != null)
                {
                    DatabasAccess.Dispose();
                }
            }
        }

        /// <summary>
        /// Spara TavlingRondResultat med en anmäld spelare
        /// </summary>
        /// <param name="tavlingRondResultat">Aktuellt objekt</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaTavlingRondResultat(TavlingRondResultat tavlingRondResultat, ref string felID, ref string feltext)
        {
            try
            {
                DatabasAccess.SkapaTransaktion();
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RondID", DataTyp.Int, tavlingRondResultat.RondId.ToString()),
                    new DatabasParameters("@SpelarID", DataTyp.Int, tavlingRondResultat.SpelarID.ToString()),
                    new DatabasParameters("@HalNr", DataTyp.Int, tavlingRondResultat.HalNr.ToString()),
                    new DatabasParameters("@AntalSlag", DataTyp.Int, tavlingRondResultat.AntalSlag.ToString()),
                    new DatabasParameters("@AntalPoang", DataTyp.Int, tavlingRondResultat.AntalPoang.ToString()),
                    new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, DateTime.Today.Date.ToString())
                };
                DatabasAccess.ExecuteSP("UpdateTavlingRondResultat", dbParameters);
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
            finally
            {
                if (DatabasAccess != null)
                {
                    DatabasAccess.Dispose();
                }
            }
        }

        /// <summary>
        /// Ta bort rader ur tabellen TavlingRondResultat för en spelare och tävling
        /// </summary>
        /// <param name="rondID">Aktuellt rondID</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBort(int rondID, int spelarID, ref string felID, ref string feltext)
        {
            string sql;
            try
            {
                sql = "	DELETE FROM TavlingRondResultat WHERE RondID = @RondID AND SpelarID = @SpelarID";
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
            finally
            {
                if (DatabasAccess != null)
                {
                    DatabasAccess.Dispose();
                }
            }
        }

        /// <summary>
        /// Spara i tabellen TavlingRondResultat med en anmäld spelare
        /// </summary>
        /// <param name="tavling">Aktuellt objekt</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void Spara(Tavling tavling, ref string felID, ref string feltext)
        {
            try
            {
                DatabasAccess.SkapaTransaktion();

                for (int i = 0; i < tavling.TavlingRondResultat.Length; i++)
                {
                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@RondID", DataTyp.Int, tavling.TavlingRondResultat[i].RondId.ToString()),
                        new DatabasParameters("@SpelarID", DataTyp.Int, tavling.TavlingRondResultat[i].SpelarID.ToString()),
                        new DatabasParameters("@HalNr", DataTyp.Int, tavling.TavlingRondResultat[i].HalNr.ToString()),
                        new DatabasParameters("@AntalSlag", DataTyp.Int, tavling.TavlingRondResultat[i].AntalSlag.ToString()),
                        new DatabasParameters("@AntalPoang", DataTyp.Int, tavling.TavlingRondResultat[i].AntalPoang.ToString()),
                        new DatabasParameters("@UppdatDatum", DataTyp.SmallDateTime, DateTime.Today.Date.ToString())
                    };
                    DatabasAccess.ExecuteSP("UpdateTavlingRondResultat", dbParameters);
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
            finally
            {
                if (DatabasAccess != null)
                {
                    DatabasAccess.Dispose();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        private void CheckForErrors(DataSet ds)
        {
            if (!ds.HasErrors)
            {
                //DataSet1.Merge(DataSet2);
            }
            else
            {
                PrintRowErrs(ds);
            }
        }

        private void PrintRowErrs(DataSet dataSet)
        {
            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row.HasErrors)
                    {
                        Console.WriteLine(row.RowError);
                    }
                }
            }
        }
    }
}
