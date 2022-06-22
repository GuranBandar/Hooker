using System;
using System.Collections.Generic;
using System.Text;
using Hooker.Datalager;
using Hooker.Dataset;
using Hooker.Affärsobjekt;

namespace Hooker.Affärslager
{
    /// <summary>
    /// Klass för OrdlistaAktivitet
    /// 
    /// Innehåller alla metoder för klassen OrdlistaAktivitets verksamhetslogik.
    /// </summary>
    public sealed class OrdlistaAktivitet
    {

        /// <summary>
        /// Hämtar rad från tabellen Ordlista i aktuell databas med angiven nyckel.
        /// </summary>
        /// <param name="grupp">Aktuell grupp</param>
        /// <param name="text">Aktuell text</param>
        /// <param name="sprakkod">Språkkod</param>
        /// <returns>Objektlista Ordlista med efterfrågat data</returns>
        public List<Ordlista> HämtaOrdlista(string grupp, string text, string sprakkod)
        {
            OrdlistaDS ordlistaDS = new OrdlistaDS();
            Datalager.OrdlistaData ordlistaData = new Datalager.OrdlistaData();
            ordlistaDS = ordlistaData.HämtaOrdlista(grupp, text, sprakkod);

            List<Ordlista> ordlista = new List<Ordlista>(ordlistaDS.Ordlista.Rows.Count);
            foreach (OrdlistaDS.OrdlistaRow rad in ordlistaDS.Ordlista.Rows)
            {
                ordlista.Add(new Ordlista()
                {
                    Grupp = rad.Grupp,
                    Text = rad.Text,
                    Data = rad.Data,
                    Sprakkod = rad.Sprakkod
                });
            }
            return ordlista;
        }

        /// <summary>
        /// Hämtar grupprad från tabellen Ordlista i aktuell databas med angiven grupp.
        /// </summary>
        /// <param name="grupp">Aktuell grupp</param>
        /// <returns>Objektlista Ordlista med efterfrågat data</returns>
        public List<Ordlista> HämtaOrdlista(string grupp, string sprakkod)
        {
            OrdlistaDS ordlistaDS = new OrdlistaDS();
            Datalager.OrdlistaData ordlistaData= new Datalager.OrdlistaData();
            ordlistaDS = ordlistaData.HämtaOrdlista(grupp, sprakkod);

            List<Ordlista> ordlista = new List<Ordlista>(ordlistaDS.Ordlista.Rows.Count);
            foreach (OrdlistaDS.OrdlistaRow rad in ordlistaDS.Ordlista.Rows)
            {
                ordlista.Add(new Ordlista()
                {
                    Grupp = rad.Grupp,
                    Text = rad.Text,
                    Data = rad.Data,
                    Sprakkod = rad.Sprakkod
                });
            }
            return ordlista;
        }

    }
}
