using System;
using System.Collections.Generic;
using System.Data;
using Hooker.Affärsobjekt;
using Hooker.Dataset;
using Hooker.Datalager;
using Hooker.Gemensam;

namespace Hooker.Affärslager
{
    /// <summary>
    /// Klass för Redovisning
    /// 
    /// Innehåller alla metoder för klassen Redovisning verksamhetslogik.
    /// </summary>
    public sealed class RedovisningAktivitet : SökVillkor
    {
        /// <summary>
        ///     Skapar söksträng för sök i databasen, anropar sök och sätter värden för
        ///     aktuella Redovisningar i klassen.
        /// </summary>
        /// <param name="typ">Typ av Redovisning som ska hämtas</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <param name="fromDatum">Ev from datum</param>
        /// <param name="tomDatum">Ev tom datum</param>
        /// <returns>Objektlista med Redovisning</returns>
        public List<Redovisning> SökRedovisning(string typ, string spelarID, DateTime fromDatum, DateTime tomDatum)
        {
            DataSet redovisningDS = new DataSet();
            RedovisningData redovisningData = new RedovisningData();
            List<Redovisning> redovisning = null;
            string sqlSok = "";
            string sql = "";
            short antArgument;

            try
            {
                antArgument = 0;

                if (!string.IsNullOrEmpty(typ) & typ != "00")
                { //  om typ angivits
                    WhereFörSträng(typ, "re.typ ", ref sqlSok, ref antArgument, "= ");
                }

                if (!string.IsNullOrEmpty(spelarID.ToString()) & spelarID != "0")
                {
                    WhereFörInteger(spelarID, "re.SpelarID", ref sqlSok, ref antArgument, " = ");
                }

                if (!string.IsNullOrEmpty(fromDatum.ToString()))
                {
                    WhereFörSträng(fromDatum, "re.Datum", ref sqlSok, ref antArgument, " >= ");
                }

                if (!string.IsNullOrEmpty(tomDatum.ToString()))
                {
                    WhereFörSträng(tomDatum, "re.Datum", ref sqlSok, ref antArgument, " < ");
                }

                // Om inga argument finns så ska inte "WHERE" vara med i select satsen
                if (antArgument > 0)
                {
                    sql = " WHERE " + sqlSok;
                }

                redovisningDS = redovisningData.SökRedovisning(sql);
                if (redovisningDS.Tables["Redovisning"].Rows.Count > 0)
                {
                    redovisning = new List<Redovisning>(redovisningDS.Tables["Redovisning"].Rows.Count);
                    foreach (DataRow rad in redovisningDS.Tables["Redovisning"].Rows)
                    {
                        redovisning.Add(new Redovisning()
                        {
                            TransNr = (int)rad["TransNr"],
                            Typ = rad["Typ"].ToString(),
                            Typnamn = rad["Typnamn"].ToString(),
                            Datum = (DateTime)rad["Datum"],
                            RundaNr = (int)rad["RundaNr"],
                            SpelarID = (int)rad["SpelarID"],
                            Belopp = (decimal)rad["Belopp"],
                            Notering = rad["Notering"].ToString()
                        });
                    }
                }
                return redovisning;
            }
            catch (HookerException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new HookerException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Hämtar Redovisning för angivet TransNr
        /// </summary>
        /// <param name="transNr">TransNr</param>
        /// <returns>Redovisningaobjekt</returns>
        public Redovisning HämtaRedovisning(int transNr)
        {
            RedovisningData redovisningData = new RedovisningData();
            RedovisningDS redovisningDS = redovisningData.HämtaRedovisning(transNr);
            Redovisning redovisning = new Redovisning();
            redovisning.TransNr = redovisningDS.Redovisning[0].TransNr;
            redovisning.Typ = redovisningDS.Redovisning[0].Typ.Trim();
            redovisning.Datum = redovisningDS.Redovisning[0].Datum;
            redovisning.RundaNr = redovisningDS.Redovisning[0].RundaNr;
            redovisning.SpelarID = redovisningDS.Redovisning[0].SpelarID;
            redovisning.Belopp = redovisningDS.Redovisning[0].Belopp;
            redovisning.Notering = redovisningDS.Redovisning[0].Notering;
            redovisning.UppdatDatum = redovisningDS.Redovisning[0].UppdatDatum;
            return redovisning;
        }

        /// <summary>
        /// Sparar alla förändringar i rundans Redovisning i databasen 
        /// </summary>
        /// <param name="runda">Aktuell runda</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void Spara(Runda runda, ref string felID, ref string feltext)
        {
            Datalager.RedovisningData redovisningData = new Datalager.RedovisningData();

            //Börja med att ta bort alla som fanns tidigare för att sedan spara nya
            redovisningData.TaBortRedovisningRunda(runda.RundaNr, ref felID, ref feltext);

            for (int i = 0; i < runda.Redovisning.Length; i++)
            {
                runda.Redovisning[i].RundaNr = runda.RundaNr;
                redovisningData.SparaNyRedovisning(runda.Redovisning[i], ref felID, ref feltext);
            }
        }

        /// <summary>
        /// Sparar alla förändringar i rundans Redovisning i databasen 
        /// </summary>
        /// <param name="redovisning">Aktuell runda</param>
        /// <param name="nyRedovisning">Ny runda, true or false</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public int Spara(Redovisning redovisning, bool nyRedovisning, ref string felID, ref string feltext)
        {
            int nyttTransNr = 0;
            bool kollaOK = Kolla(redovisning, ref felID, ref feltext);

            if (kollaOK)
            {
                Datalager.RedovisningData redovisningData = new Datalager.RedovisningData();

                if (nyRedovisning)
                {
                    nyttTransNr = redovisningData.SparaNyRedovisning(redovisning, ref felID, ref feltext);
                }
                else
                {
                    redovisningData.SparaRedovisning(redovisning, ref felID, ref feltext);
                }
            }
            else
            {
                throw new HookerException();
            }
            return nyttTransNr;
        }

        /// <summary>
        /// Ta bort Redovisning i databasen 
        /// </summary>
        /// <param name="redovisning">Aktuell redovisning</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void TaBort(Redovisning redovisning, ref string felID, ref string feltext)
        {
            RedovisningData redovisningData = new RedovisningData();
            redovisningData.TaBortRedovisningTrans(redovisning, ref felID, ref feltext);
        }

        /// <summary>
        /// Metoden kollar informationen innan uppdatering ska göras
        /// </summary>
        /// <param name="redovisning">Dataset med informationen som ska kollas</param>
        /// <param name="felID">Ev felID som returneras</param>
        /// <param name="felmeddelande">Ev felmeddelande som returneras</param>
        private bool Kolla(Redovisning redovisning, ref string felID, ref string felmeddelande)
        {
            if (redovisning.SpelarID == 0)
            {
                felID = "SPELAREMISSING";
                felmeddelande = "";
                return false;
            }
            if (redovisning.Typ == "")
            {
                felID = "TRANSTYPMISSING";
                felmeddelande = "";
                return false;
            }
            if (redovisning.Belopp == 0)
            {
                felID = "BELOPPMISSING";
                felmeddelande = "";
                return false;
            }
            return true;
        }
    }
}
