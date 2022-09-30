using Hooker.Gemensam;
using System.Data;

namespace Hooker.Datalager
{
    /// <summary>
    /// 
    /// </summary>
    public class ExecuteQueryData : AbstractDataLager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet ExecuteQuery(string sql)
        {
            DataSet queryResult = new DataSet();

            try
            {
                queryResult = DatabasAccess.RunSql(sql); ;
                return queryResult;
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
    }
}
