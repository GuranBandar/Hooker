using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Hooker.Affärsobjekt;
using Hooker.Dataset;
using Hooker.Datalager;
using Hooker.Gemensam;

namespace Hooker.Affärslager
{
    /// <summary>
    /// Klass för BanaHal
    /// </summary>
    public sealed class BanaHalAktivitet
    {

        /// <summary>
        /// Metoden kollar informationen innan uppdatering ska göras
        /// </summary>
        /// <param name="bana">Objekt med informationen som ska kollas</param>
        /// <param name="felID">Felmeddelande i Orslistan som ska visas</param>
        /// <param name="felmeddelande">Ev kompletterande felmeddelande som returneras</param>
        public bool Kolla(Bana bana, ref string felID, ref string felmeddelande)
        {
            int hcp = 0;
            Hooker.Affärslager.KoderAktivitet koderAktivitet = new KoderAktivitet();

            // hämta först min och max för längd, en rimlighetskontroll ska göras av längden
            Koder koder = koderAktivitet.HämtaKoder((int)Kodtabell.Max_och_min, "1");
            if (koder != null)
            {
                for (int i = 0; i < bana.BanaHal.Length; i++)
                {
                    if (bana.BanaHal[i].LangdVit > 0)
                    {
                        if (bana.BanaHal[i].LangdVit > Convert.ToInt16(koder.IntervallMax) ||
                            bana.BanaHal[i].LangdVit < Convert.ToInt16(koder.IntervallMin))
                        {
                            felID = "HOLELENWRONG";
                            felmeddelande = "Hålnr = " + bana.BanaHal[i].HalNr.ToString();
                            return false;
                        }
                    }
                    if (bana.BanaHal[i].LangdGul > 0)
                    {
                        if (bana.BanaHal[i].LangdGul > Convert.ToInt16(koder.IntervallMax) ||
                            bana.BanaHal[i].LangdGul < Convert.ToInt16(koder.IntervallMin))
                        {
                            felID = "HOLELENWRONG";
                            felmeddelande = "Hålnr = " + bana.BanaHal[i].HalNr.ToString();
                            return false;
                        }
                    }
                    if (bana.BanaHal[i].LangdBla > 0)
                    {
                        if (bana.BanaHal[i].LangdBla > Convert.ToInt16(koder.IntervallMax) ||
                            bana.BanaHal[i].LangdBla < Convert.ToInt16(koder.IntervallMin))
                        {
                            felID = "HOLELENWRONG";
                            felmeddelande = "Hålnr = " + bana.BanaHal[i].HalNr.ToString();
                            return false;
                        }
                    }
                    if (bana.BanaHal[i].LangdRod > 0)
                    {
                        if (bana.BanaHal[i].LangdRod > Convert.ToInt16(koder.IntervallMax) ||
                            bana.BanaHal[i].LangdRod < Convert.ToInt16(koder.IntervallMin))
                        {
                            felID = "HOLELENWRONG";
                            felmeddelande = "Hålnr = " + bana.BanaHal[i].HalNr.ToString();
                            return false;
                        }
                    }
                    if (bana.BanaHal[i].Par < 3 || bana.BanaHal[i].Par > 6)
                    {
                        felID = "HOLEPARWRONG";
                        felmeddelande = "Hålnr = " + bana.BanaHal[i].HalNr.ToString();
                        return false;
                    }
                    if (bana.BanaHal[i].Hcp == 0 || bana.BanaHal[i].Hcp > 18)
                    {
                        felID = "HOLEINDWRONG";
                        felmeddelande = "Hålnr = " + bana.BanaHal[i].HalNr.ToString();
                        return false;
                    }
                    hcp = hcp + bana.BanaHal[i].Hcp;
                }

                // summan av hålens hcp ska vara 171
                if (hcp != 171)
                {
                    felID = "BANINDWRONG";
                    felmeddelande = "";
                    return false;
                }
            }
            else
            {
                felID = "KODMINMAXMISSING";
                felmeddelande = "";
                return false;
            }

            return true;
        }
    }
}
