using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Hooker.Dataset;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using GemensamService;

namespace Hooker.Datalager
{
    /// <summary>
    /// Datalagerklass för Systemvariabler
    /// </summary>
    public sealed class SystemvariablerData : AbstractDataLager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SystemvariablerDS Hämta()
        {
            SystemvariablerDS systemvariablerDS = new SystemvariablerDS();
            string sql = "SELECT * FROM Systemvariabler";

            try
            {
                DatabasAccess.FyllEnkeltDataSet(sql, systemvariablerDS);
                return systemvariablerDS; 
            }
            catch (SqlException sex)
            {
                throw sex;
            }
            finally
            {
                DatabasAccess.Dispose();
            }

        }

        /// <summary>
        /// Ny Systemvariabler.
        /// </summary>
        /// <param name="systemvariabler">Systemvariabler</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaNySystemvariabel(Systemvariabler systemvariabler, ref string felID, ref string feltext)
        {
            string sql;
            DatabasAccess.SkapaTransaktion();

            try
            {
                sql = "INSERT INTO Systemvariabler(Applikationsnamn, Version, Utvecklare, Verktyg, Epostadress, " +
                    "MobilUtvecklare, WriteToLog, MailFrom, MailPassword, WaitCursorImageID," +
                    " SmtpHost, Port)" +
                    "VALUES " +
                    "(@Applikationsnamn, @Version, @Utvecklare, @Verktyg, @Epostadress, @MobilUtvecklare, " +
                    "@WriteToLog, @MailFrom, @MailPassword, @WaitCursorImageID, @SmtpHost, @Port)";

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@Applikationsnamn", DataTyp.VarChar, systemvariabler.Applikationsnamn.ToString()),
                    new DatabasParameters("@Version", DataTyp.VarChar, systemvariabler.Version.ToString()),
                    new DatabasParameters("@Utvecklare", DataTyp.VarChar, systemvariabler.Utvecklare.ToString()),
                    new DatabasParameters("@Verktyg", DataTyp.VarChar, systemvariabler.Verktyg.ToString()),
                    new DatabasParameters("@Epostadress", DataTyp.VarChar, systemvariabler.Epostadress.ToString()),
                    new DatabasParameters("@MobilUtvecklare", DataTyp.VarChar, systemvariabler.MobilUtvecklare.ToString()),
                    new DatabasParameters("@WriteToLog", DataTyp.Char, systemvariabler.WriteToLog.ToString()),
                    new DatabasParameters("@MailFrom", DataTyp.VarChar, systemvariabler.MailFrom.ToString()),
                    new DatabasParameters("@MailPassword", DataTyp.VarChar, systemvariabler.MailPassword.ToString()),
                    new DatabasParameters("@WaitCursorImageID", DataTyp.VarChar, systemvariabler.WaitCursorImageID.ToString()),
                    new DatabasParameters("@SmtpHost", DataTyp.VarChar, systemvariabler.SmtpHost.ToString()),
                    new DatabasParameters("@Port", DataTyp.Char, systemvariabler.Port.ToString())
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
        /// Sparar i Systemvariabler.
        /// </summary>
        /// <param name="systemvariabler">Systemvariabler</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void SparaSystemvariabel(Systemvariabler systemvariabler, ref string felID, ref string feltext)
        {
            string sql;
            DatabasAccess.SkapaTransaktion();

            try
            {
                sql = "UPDATE Systemvariabler " +
                    "SET Applikationsnamn = @Applikationsnamn, Version = @Version, Utvecklare = @Utvecklare, " +
                    "Verktyg = @Verktyg, Epostadress = @Epostadress, MobilUtvecklare = @MobilUtvecklare, " +
                    "WriteToLog = @WriteToLog, MailFrom = @MailFrom, " +
                    "MailPassword = @MailPassword, WaitCursorImageID = @WaitCursorImageID, " +
                    "SmtpHost = @SmtpHost, Port = @Port";
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@Applikationsnamn", DataTyp.VarChar, systemvariabler.Applikationsnamn.ToString()),
                    new DatabasParameters("@Version", DataTyp.VarChar, systemvariabler.Version.ToString()),
                    new DatabasParameters("@Utvecklare", DataTyp.VarChar, systemvariabler.Utvecklare.ToString()),
                    new DatabasParameters("@Verktyg", DataTyp.VarChar, systemvariabler.Verktyg.ToString()),
                    new DatabasParameters("@Epostadress", DataTyp.VarChar, systemvariabler.Epostadress.ToString()),
                    new DatabasParameters("@MobilUtvecklare", DataTyp.VarChar, systemvariabler.MobilUtvecklare.ToString()),
                    new DatabasParameters("@WriteToLog", DataTyp.Char, systemvariabler.WriteToLog.ToString()),
                    new DatabasParameters("@MailFrom", DataTyp.VarChar, systemvariabler.MailFrom.ToString()),
                    new DatabasParameters("@MailPassword", DataTyp.VarChar, systemvariabler.MailPassword.ToString()),
                    new DatabasParameters("@WaitCursorImageID", DataTyp.VarChar, systemvariabler.WaitCursorImageID.ToString()),
                    new DatabasParameters("@SmtpHost", DataTyp.VarChar, systemvariabler.SmtpHost.ToString()),
                    new DatabasParameters("@Port", DataTyp.Char, systemvariabler.Port.ToString())
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
