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
    /// Datalagerklass för EclecticRondDeltagare
    /// </summary>
    public sealed class EclecticRondDeltagareData : AbstractDataLager
    {
        /// <summary>
        /// Hämtar rad från tabellen EclecticRondDeltagare i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="EclecticID">Aktuell EclecticTotal</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticRondDeltagareDS HämtaAllaEclecticRondDeltagare(int RondID)
        {
            EclecticRondDeltagareDS ds = new EclecticRondDeltagareDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticRondDeltagare e WHERE e.RondID = @RondID";
                
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@RondID", DataTyp.Int, RondID.ToString())
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
        /// Hämtar rad från tabellen EclecticRondDeltagare i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="spelarID">Aktuell deltagare</param>
        /// <param name="rondID">Aktuell rond</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public EclecticRondDeltagareDS HämtaEclecticRondDeltagare(int spelarID, int rondID)
        {
            EclecticRondDeltagareDS ds = new EclecticRondDeltagareDS();
            string sql;

            try
            {
                ds.EnforceConstraints = false;
                sql = "SELECT e.* FROM EclecticRondDeltagare e WHERE e.SpelarID = @SpelarID " +
                    "AND e.RondID = @RondID";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@SpelarID", DataTyp.Int, spelarID.ToString()),
                    new DatabasParameters("@RondID", DataTyp.Int, rondID.ToString())
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
        /// Ny EclecticRondDeltagare.
        /// </summary>
        /// <param name="EclecticRondDeltagare">EclecticRondDeltagare</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaNyEclecticRondDeltagare(EclecticRondDeltagare eclecticRondDeltagare, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();

                //for (int i = 0; i < eclecticRond.EclecticRondDeltagare.Length; i++)
                //{
                    sql = "INSERT INTO EclecticRondDeltagare(SpelarID, RondID, ExaktHcp, ErhallnaSlag, " +
                        "Tee, DeltagarDatum, DeltagarUppdatDatum) " +
                        "VALUES " +
                        "(@SpelarID, @RondID, @ExaktHcp, @ErhallnaSlag, @Tee, @DeltagarDatum, @DeltagarUppdatDatum)";
                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@SpelarID", DataTyp.Int, eclecticRondDeltagare.SpelarID.ToString()),
                        new DatabasParameters("@RondID", DataTyp.Int, eclecticRondDeltagare.RondID.ToString()),
                        new DatabasParameters("@ExaktHcp", DataTyp.Decimal, eclecticRondDeltagare.ExaktHcp.ToString()),
                        new DatabasParameters("@ErhallnaSlag", DataTyp.Int, eclecticRondDeltagare.ErhallnaSlag.ToString()),
                        new DatabasParameters("@Tee", DataTyp.Char, eclecticRondDeltagare.Tee.ToString()),
                        new DatabasParameters("@DeltagarDatum", DataTyp.VarChar, eclecticRondDeltagare.DeltagarDatum.ToString()),
                        new DatabasParameters("@DeltagarUppdatDatum", DataTyp.VarChar, eclecticRondDeltagare.DeltagarUppdatDatum.ToString())
                    };
                    DatabasAccess.RunSql(sql, dbParameters);
                //}
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
        /// Spara EclecticRondDeltagare.
        /// </summary>
        /// <param name="EclecticRondDeltagare">EclecticRondDeltagare</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaEclecticRondDeltagare(EclecticRondDeltagare eclecticRondDeltagare, ref string felID, ref string feltext)
        {
            string sql;

            try
            {
                DatabasAccess.SkapaTransaktion();

                //for (int i = 0; i < eclecticRond.EclecticRondDeltagare.Length; i++)
                //{
                    sql = "UPDATE EclecticRondDeltagare " +
                        "SET ExaktHcp = @ExaktHcp, ErhallnaSlag = @ErhallnaSlag, Tee = @Tee, " +
                        "DeltagarDatum = @DeltagarDatum, DeltagarUppdatDatum = @DeltagarUppdatDatum " +
                        "WHERE SpelarID = @SpelarID AND RondID = @RondID";
                    List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                    {
                        new DatabasParameters("@SpelarID", DataTyp.Int, eclecticRondDeltagare.SpelarID.ToString()),
                        new DatabasParameters("@RondID", DataTyp.Int, eclecticRondDeltagare.RondID.ToString()),
                        new DatabasParameters("@ExaktHcp", DataTyp.Decimal, eclecticRondDeltagare.ExaktHcp.ToString()),
                        new DatabasParameters("@ErhallnaSlag", DataTyp.Int, eclecticRondDeltagare.ErhallnaSlag.ToString()),
                        new DatabasParameters("@Tee", DataTyp.Char, eclecticRondDeltagare.Tee.ToString()),
                        new DatabasParameters("@DeltagarDatum", DataTyp.VarChar, eclecticRondDeltagare.DeltagarDatum.ToString()),
                        new DatabasParameters("@DeltagarUppdatDatum", DataTyp.VarChar, eclecticRondDeltagare.DeltagarUppdatDatum.ToString())
                    };
                    DatabasAccess.RunSql(sql, dbParameters);
                //}
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
