using GemensamService;

namespace Hooker.Datalager
{
    /// <summary>
    /// 
    /// </summary>
    public class AbstractDataLager
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        protected IDatabasAccess DatabasAccess { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Databas { get; set; }
        #endregion

        /// <summary>
        /// Konstruktor
        /// </summary>
        public AbstractDataLager()
        {
            DatabasFabrik fabriken = new DatabasFabrik();
            DatabasAccess = fabriken.GetDatabase();
        }
    }
}
