using System;
using GemensamService;

namespace Hooker.Gemensam
{
    /// <summary>
    /// Summary description for HookerException.
    /// </summary>
    [Serializable]
    public class HookerException : System.Exception
    {
        FelKod _felkod = FelKod.Default;

        /// <summary>
        /// Egenskapen FelKod
        /// </summary>
        public FelKod FelKod
        {
            get
            {
                return _felkod;
            }
            set
            {
                _felkod = value;
            }
        }

		/// <summary>
		/// Defaultkonstruktor
		/// </summary>
		public HookerException() : base("[[Felkod: 0]]")
		{

		}

		/// <summary>
		/// Konstruktor att användas av bla subklasser.
		/// </summary>
		/// <param name="felkod">Felkod</param>
		public HookerException(FelKod felkod) : base ("[[Felkod: " + ((int)felkod).ToString() + ", ]]")
		{
			_felkod = felkod;

		}

		/// <summary>
		/// Konstruktor
		/// </summary>
		/// <param name="ex">Inner exception</param>
		public HookerException(Exception ex) : base(ex.Message, ex)
		{
		}

		/// <summary>
		/// Konstruktor
		/// </summary>
		/// <param name="ex">Inner exception</param>
		/// <param name="felkod">Felkod</param>
        public HookerException(FelKod felkod, Exception ex)
            : base("[[Felkod: " + ((int)felkod).ToString() + ", " + ex.Message + "]]", ex)
		{
			_felkod = felkod;
		}

		/// <summary>
		/// Konstruktor med fler överlagrade parametrar
		/// </summary>
		/// <param name="meddelande">Meddelande</param>
		/// <param name="ex">Inner Exception</param>
		public HookerException(string meddelande, Exception ex) : base("[[Felkod: 0, " + meddelande + "]]", ex)
		{
		}
    }
}
