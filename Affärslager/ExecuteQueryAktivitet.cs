using Hooker.Datalager;
using System.Data;

namespace Hooker.Affärslager
{
    /// <summary>
    /// 
    /// </summary>
    public class ExecuteQueryAktivitet
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet ExecuteQuery(string sql)
        {
            ExecuteQueryData eqd = new ExecuteQueryData();
            DataSet queryResult = eqd.ExecuteQuery(sql);
            return queryResult;
        }

    }
}
