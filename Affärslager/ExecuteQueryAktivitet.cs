using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Hooker.Datalager;

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
