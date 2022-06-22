using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Hooker.Dataset;
using GemensamService;

namespace Hooker.Datalager
{
    /// <summary>
    /// Datalagerklass för Ordlista
    /// </summary>
    public sealed class OrdlistaData : AbstractDataLager
    {
        /// <summary>
        /// Hämtar rad från tabellen Ordlista i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="grupp">Aktuell grupp</param>
        /// <param name="text">Aktuell text</param>
        /// <param name="sprakkod">Aktuell språkkod</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public OrdlistaDS HämtaOrdlista(string grupp, string text, string sprakkod)
        {
            OrdlistaDS ordlistaDS = new OrdlistaDS();
            string sql = "SELECT o.* FROM Ordlista o WHERE o.Grupp = @Grupp AND o.Text = @Text " +
                "AND o.Sprakkod = @Sprakkod";

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@Grupp", grupp),
                    new DatabasParameters("@Text", text),
                    new DatabasParameters("@Sprakkod", sprakkod),
                };
                DatabasAccess.FyllEnkeltDataSet(sql, dbParameters, ordlistaDS);
                return ordlistaDS;
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
        /// Hämtar grupprad från tabellen Ordlista i aktuell databas med angiven grupp.
        /// </summary>
        /// <param name="grupp">Aktuell grupp</param>
        /// <param name="sprakkod">Språkkod</param>
        /// <returns>Typat dataset med efterfrågat data</returns>
        public OrdlistaDS HämtaOrdlista(string grupp, string sprakkod)
        {
            OrdlistaDS ordlistaDS = new OrdlistaDS();
            string sql = "SELECT o.* FROM Ordlista o WHERE o.Grupp = @Grupp AND o.Sprakkod = @Sprakkod";

            try
            {
                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@Grupp", grupp),
                    new DatabasParameters("@Sprakkod", sprakkod)
                };
                DatabasAccess.FyllEnkeltDataSet(sql, dbParameters, ordlistaDS);
                return ordlistaDS;
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
    }
}
