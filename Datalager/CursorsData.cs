using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using GemensamService;

namespace Hooker.Datalager
{
    /// <summary>
    /// Datalagerklass för Cursors
    /// </summary>
    public sealed class CursorsData : AbstractDataLager
    {
        /// <summary>
        /// Hämta Cursosrs från databasen
        /// </summary>
        /// <returns></returns>
        public DataSet Hämta()
        {
            DataSet cursorsDS = new DataSet();
            string sql = "SELECT * FROM Cursors";

            try
            {
                cursorsDS = DatabasAccess.RunSql(sql);
                cursorsDS.Tables[0].TableName = "Cursors";
                return cursorsDS;
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
        /// Hämta aktuell Cursor från databasen
        /// </summary>
        /// <returns>Cursor objektet</returns>
        public DataSet Hämta(int cursorID)
        {
            DataSet cursorsDS = new DataSet();
            string sql = "SELECT * FROM Cursors WHERE CursorID = " + cursorID;

            try
            {
                //List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                //{
                //    new DatabasParameters("@CursorID", cursorID.ToString())
                //};
                //DatabasAccess.FyllEnkeltDataSet(sql, cursorsDS);
                cursorsDS = DatabasAccess.RunSql(sql);
                cursorsDS.Tables[0].TableName = "Cursors";
                return cursorsDS;
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