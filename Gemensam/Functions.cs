using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hooker.Gemensam
{
    /// <summary>
    /// 
    /// </summary>
    public class Functions
    {

        /// <summary>
        /// To Bool
        /// </summary>
        public static Func<object, bool> ToBool = val => val == DBNull.Value ? false : (bool)val;

        /// <summary>
        /// To string
        /// </summary>
        public static Func<object, string> ToStr = x => x == DBNull.Value ? "" : x.ToString();

        /// <summary>
        /// To int
        /// </summary>
        public static Func<object, int> ToInt = c => c == DBNull.Value ? 0 : (int)c;
    }
}
