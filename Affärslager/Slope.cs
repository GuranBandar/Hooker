using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using System;
using System.Collections.Generic;

namespace Hooker.Affärslager
{
    /// <summary>
    /// Klass för Slope
    /// 
    /// Innehåller alla metoder för klassen Slopes verksamhetslogik.
    /// </summary>
    public static class Slope
    {
        /// <summary>
        /// Räknar ut erhållna slag för spelare med exakt handikap. Banan ska 
        /// också ha CR (Course Rating) och slopevärde, går inte annars. Finns inte
        /// CR eller slope för banan ska hcp sättas enligt gammalt, ett hcp ?,5 ger
        /// höjning närmast hela och hcp ?,4 sänkning närmast hela.
        /// 
        /// Formeln är (enligt Svensk Golf):
		/// erhållnaSlag = Course rating(CR) - par + exakt handicap * slope / 113
        /// 
        /// </summary>
        /// <param name="cr">Banans CR (Course Rating)</param>
        /// <param name="slope">Banans slopevärde</param>
        /// <param name="par">Banans Par</param>
        /// <param name="exaktHcp">Spelarens exakta handicap</param>
        /// <param name="felID">Meddelande om att vilka/-en uppgift som saknas eller
		/// är felaktig till Felhantering</param>
        /// <returns>Det antal slag aktuell spelare har på aktuell bana</returns>
        public static int RäknaUtErhållnaSlag(decimal cr, int slope, int par, decimal exaktHcp,
            ref string felID)
        {
            int erhallnaSlag = 0;

            //finns inget CR och Slope ska exaktHcp avrundas till närmast heltal
            if (cr == 0 || slope == 0)
            {
                erhallnaSlag = Convert.ToInt16(exaktHcp);
                return erhallnaSlag;
            }
            if (par.ToString().Length == 0)
            {
                felID = "BANPARMISSING";
                throw new HookerException();
            }

            erhallnaSlag = Convert.ToInt16((cr - par + exaktHcp) * slope / 113);
            return erhallnaSlag;
        }

        /// <summary>
        /// Räkna ut erhållna slag enligt SGF:s formel
        /// </summary>
        /// <param name="cr"></param>
        /// <param name="slope"></param>
        /// <param name="par"></param>
        /// <param name="exaktHcp"></param>
        /// <returns></returns>
        public static int RäknaUtErhållnaSlag(decimal cr, int slope, int par, decimal exaktHcp)
        {
            int erhallnaSlag = 0;

            //finns inget CR och Slope ska exaktHcp avrundas till närmast heltal
            if (cr == 0 || slope == 0)
            {
                erhallnaSlag = Convert.ToInt16(exaktHcp);
                return erhallnaSlag;
            }

            erhallnaSlag = Convert.ToInt16((cr - par + exaktHcp) * slope / 113);
            return erhallnaSlag;
        }

        /// <summary>
        /// Räknar ut spelarens poäng på aktuellt hål.
        /// </summary>
        /// <param name="erhallnaSlag">Spelarens erhållna slag (= Spelarens hcp för Banan)</param>
        /// <param name="slag">Antalet slag på hålet</param>
        /// <param name="par">Paret på hålet</param>
        /// <param name="hcp">Hålets handicap</param>
        /// <param name="felID">Meddelande om att vilka/-en uppgift som saknas eller
        /// är felaktig till Felhantering</param>
        /// <returns>Antalet poäng på hålet</returns>
        public static int RäknaUtAntalPoäng(int erhallnaSlag, int slag, int par, int hcp, ref string felID)
        {
            int antalPoang = 0;
            //int antalSlag = 0;
            int mittPar = 0;

            if (slag > 0)
            {
                //Kolla först att all data finns
                if (erhallnaSlag.ToString().Length == 0)
                {
                    felID = "ERHSLAGMISSING";
                    throw new HookerException();
                }
                if (slag.ToString().Length == 0)
                {
                    felID = "ANTSLAGMISSING";
                    throw new HookerException();
                }
                if (par.ToString().Length == 0)
                {
                    felID = "HOLEPARMISSING";
                    throw new HookerException();
                }
                if (hcp.ToString().Length == 0)
                {
                    felID = "HOLEHCPMISSING";
                    throw new HookerException();
                }

                //Nu ska det gå att räkna ut antalet poäng på hålet
                //  1.  Börja med att sätta mittPar lika med par
                //  2.  Om hcp är mindre eller lika med antalet erhållna slag plussa mitt par med ett
                //  2.  Dra 18 från erhållna slag
                //  3.  Kör en ny snurra från steg 2
                mittPar = par;

                while (hcp <= erhallnaSlag)
                {
                    mittPar++;
                    erhallnaSlag = erhallnaSlag - 18;
                }

                antalPoang = 2 + (mittPar - slag);

                //Mindre än noll poäng går inte att få
                if (antalPoang < 0)
                {
                    antalPoang = 0;
                }
            }
            return antalPoang;
        }

        /// <summary>
        /// Sätt klass för spelare med exakthandikap. Klassen hämtas från tabellen Koder.
        /// </summary>
        /// <param name="exaktHcp">spelarens exakta handicap</param>
        /// <param name="felID">Meddelande om att vilka/-en uppgift som saknas eller
		/// är felaktig till Felhantering</param>
        /// <returns>exakt hcp översatt till hcp-grupp</returns>
        public static string SättKlass(decimal exaktHcp, ref string felID)
        {
            string klass = "0";
            List<Koder> koder;
            Affärslager.KoderAktivitet koderAktivitet = new KoderAktivitet();

            try
            {
                //Alla hcp-gupper hämtas fråm Koder
                koder = koderAktivitet.SökKoder((int)Kodtabell.Handicapklasser, "");

                if (koder != null)
                {
                    int i = 0;

                    while (exaktHcp >= koder[i].IntervallMax)
                    {
                        i++;
                    }
                    klass = koder[i].Argument;
                }
            }
            catch (Exception ex)
            {
                throw new HookerException(ex);
            }
            return klass;
        }
    }
}

