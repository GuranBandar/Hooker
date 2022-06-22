using System.Windows.Forms;

namespace Hooker_GUI.Kontroller
{
    /// <summary>
    /// Kontroll för att spara nyckel, som inte ska visas, till raden i en ComboBox.
    /// </summary>
    public class ComboBoxPar : ComboBox
    {
        private string _visa;
        private object _data;
        private int _id;

        /// <summary>
        /// Identifierar
        /// </summary>
        public int Identifier
        {
            get { return _id; }
        }

        /// <summary>
        /// Visa
        /// </summary>
        public string Visa
        {
            get { return _visa; }
        }

        /// <summary>
        /// data
        /// </summary>
        public object Data
        {
            get { return _data; }
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="identifier">Identifierare</param>
        /// <param name="visa">Visa sträng</param>
        /// <param name="data">Data</param>
        public ComboBoxPar(int identifier, string visa, object data)
        {
            _visa = visa;
            _data = data;
            _id = identifier;
        }

        /// <summary>
        /// Metod som returnerar Visa
        /// </summary>
        /// <returns>Visa</returns>
        public override string ToString()
        {
            return _visa.ToString();
        }

        /// <summary>
        /// Metod som returnerar sökt id
        /// </summary>
        /// <param name="obj">Sökt objekt</param>
        /// <returns>Id</returns>
        public override bool Equals(object obj)
        {
            return _id.Equals(obj);
        }

        /// <summary>
        /// Meotd som returnerar ID:s hashkod
        /// </summary>
        /// <returns>Hashkoden för ID</returns>
        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }
    }

    /// <summary>
    /// Kontroll för att spara nyckel, som inte ska visas, till raden i en ComboBox.
    /// </summary>
    public class ComboBoxKod : ComboBox
    {
        private string _visa;
        private object _data;
        private string _kod;

        /// <summary>
        /// Visa
        /// </summary>
        public string Visa
        {
            get { return _visa; }
        }

        /// <summary>
        /// data
        /// </summary>
        public object Data
        {
            get { return _data; }
        }

        /// <summary>
        /// Kod
        /// </summary>
        public string Kod
        {
            get
            {
                return _kod;
            }
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="kod">Kod</param>
        /// <param name="visa">Visa sträng</param>
        /// <param name="data">Data</param>
        public ComboBoxKod(string kod, string visa, object data)
        {
            _visa = visa;
            _data = data;
            _kod = kod;
        }

        /// <summary>
        /// Metod som returnerar Visa
        /// </summary>
        /// <returns>Visa</returns>
        public override string ToString()
        {
            return _visa.ToString();
        }

        /// <summary>
        /// Metod som returnerar sökt id
        /// </summary>
        /// <param name="obj">Sökt objekt</param>
        /// <returns>Id</returns>
        public override bool Equals(object obj)
        {
            return _kod.Equals(obj);
        }

        /// <summary>
        /// Meotd som returnerar ID:s hashkod
        /// </summary>
        /// <returns>Hashkoden för ID</returns>
        public override int GetHashCode()
        {
            return _kod.GetHashCode();
        }
    }
}
