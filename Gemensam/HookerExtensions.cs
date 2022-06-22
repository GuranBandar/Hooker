using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Hooker.Gemensam
{
    /// <summary>
    /// Class for all Extension methods
    /// </summary>
    public static class HookerExtensions
    {
        /// <summary>
        /// DateTime är inte en nullable typ, därför sätter jag minimum vad sql:en gillar
        /// </summary>
        /// <returns>DateTime min value</returns>
        public static DateTime DatumMinValue()
        {
            return new DateTime(1900, 01, 01, 12, 0, 0);
        }

        /// <summary>
        /// Ersätter elaka kommatecken i decimaltal med punkt, databasen vill ha det så.
        /// </summary>
        /// <param name="text">talet, på vilket punkten ska ersättas med kommatecken</param>
        /// <returns>talet, i strängformat, med punkten utbytt mot kommatecken</returns>
        public static string BytUtPunkt(this string text)
        {
            string resultat = "";
            string tempstr;

            for (int i = 0; i < text.Length; i++)
            {
                tempstr = text.Substring(i, 1);

                switch (tempstr)
                {
                    case ".":
                        resultat = resultat + ",";
                        break;
                    default:
                        resultat = resultat + tempstr;
                        break;
                }
            }
            return resultat;
        }

        /// <summary>
        /// Ersätter elaka kommatecken i decimaltal med punkt, databasen vill ha det så.
        /// </summary>
        /// <param name="text">talet, på vilket punkten ska ersättas med kommatecken</param>
        /// <returns>talet, i strängformat, med punkten utbytt mot kommatecken</returns>
        public static string BytUtKomma(this string text)
        {
            string resultat = "";
            string tempstr;

            for (int i = 0; i < text.Length; i++)
            {
                tempstr = text.Substring(i, 1);

                switch (tempstr)
                {
                    case ",":
                        resultat = resultat + ".";
                        break;
                    default:
                        resultat = resultat + tempstr;
                        break;
                }
            }
            return resultat;
        }

        /// <summary>
        /// Metoden kontrollerar om inparametern är av typen int
        /// </summary>
        /// <param name="indata">Indata som ska kontrolleras</param>
        /// <returns>True om OK, annars false</returns>
        public static bool ÄrEnInt(this string indata)
        {
            if (indata == null)
            {
                return false;
            }

            int nummer;
            try
            {
                nummer = int.Parse(indata);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Metoden kontrollerar om inparametern är en icke-negativ decimal
        /// </summary>
        /// <param name="indata">Indata som ska kontrolleras</param>
        /// <returns>True om OK, annars false</returns>
        public static bool ÄrEnIckeNegativDecimal(this string indata)
        {
            decimal nummer = -1;
            try
            {
                if (!(indata == null))
                {
                    nummer = decimal.Parse(indata);
                }
            }
            catch
            {
                return false;
            }

            if (nummer < 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Metoden kontrollerar om inparametern är en decimal
        /// </summary>
        /// <param name="indata">Indata som ska kontrolleras</param>
        /// <returns>True om OK, annars false</returns>
        public static bool ÄrEnDecimal(this string indata)
        {
            if (indata == null)
            {
                return false;
            }

            decimal nummer;
            try
            {
                if (!(indata == null))
                {
                    nummer = decimal.Parse(indata);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Metoden kontrollerar om inparametern är ett OK-datum
        /// </summary>
        /// <param name="indata">Indata som ska kontrolleras</param>
        /// <returns>True om OK, annars false</returns>
        public static bool ÄrEttOKDatum(this string indata)
        {
            DateTime datum;
            try
            {
                if (!(indata == null))
                {
                    datum = DateTime.Parse(indata);
                }
            }
            catch
            {
                return false;
            }

            if (DateTime.Parse(indata.ToString()) > DateTime.Today)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Konverterar en Enum till en int
        /// </summary>
        /// <param name="enumValue">Enumen som ska konverteras</param>
        /// <returns>En int</returns>
        public static int EnumToInt(this Enum enumValue)
        {
            return Convert.ToInt32(enumValue);
        }

        /// <summary>
        /// Konverterar en sträng till en TimeSpan
        /// </summary>
        /// <param name="timeString">Sträng som ska konverteras</param>
        /// <returns>En TimeSpan</returns>
        public static TimeSpan ConvertToTimeSpan(this string timeString)
        {
            string format = "g";
            CultureInfo culture = CultureInfo.CurrentCulture;
            TimeSpan timeSpan = new TimeSpan();

            try
            {
                timeSpan = TimeSpan.ParseExact(timeString, format, culture);
            }
            catch (FormatException fex)
            {
                throw fex;
            }
            catch (OverflowException oex)
            {
                throw oex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return timeSpan;
        }

        /// <summary>
        /// Sätt blå färg om sämre än par, röd om bättre än par annars svart
        /// </summary>
        /// <param name="antalSlag">Antal slag</param>
        /// <param name="par">Hålets par</param>
        /// <param name="slag">True om slag annars poäng</param>
        /// <returns></returns>
        public static Color SättFärg(this int antalSlag, int par, bool slag)
        {
            if (slag)
            { 
                if (antalSlag == 0)
                {
                    return Color.Black;
                }
                else if (antalSlag == par)
                {
                    return Color.Black;
                }
                else if (antalSlag > par)
                {
                    return Color.Blue;
                }
                else if (antalSlag == par -1)
                {
                    return Color.Red;
                }
                else
                {
                    return Color.Green;
                }
            }
            else
            {
                if (antalSlag == 0)
                {
                    return Color.Black;
                }
                else if (antalSlag == par)
                {
                    return Color.Black;
                }
                else if (antalSlag < par)
                {
                    return Color.Blue;
                }
                else if (antalSlag == par - 1)
                {
                    return Color.Red;
                }
                else
                {
                    return Color.Green;
                }
            }
        }

        /// <summary>
        /// Hitta matchande RundNr för aktuell rad
        /// </summary>
        /// <param name="rowIndex">radindex</param>
        /// <param name="dgv"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static int FindMatchingRow(this int rowIndex, DataGridView dgv, string searchValue)
        {
            //int rowIndex = -1;

            DataGridViewRow row = dgv.Rows.Cast<DataGridViewRow>()
                .Where(r => r.Cells["RundaNr"].Value.ToString().Equals(searchValue))
                .First();

            rowIndex = row.Index;
            return rowIndex;
        }

        /// <summary>
        /// Formaterar tal för presentation, typen styr hur. Följande typer finns:
        /// 
        ///     N   (Nollutfyllnad ett tecken)
        ///     N4  (Nollutfyllnad fyra tecken)   
        ///     ND1 (Nollutfyllnad med en decimal)
        ///     ND2 (Nollutfylld och tusenseparerad)
        ///     NT  (Nollutfyllnad ett tecken)
        ///     D   (Ingen nollutfyllnad)
        ///     DD2 (Ingen nollutfyllnad och två decimaler)
        ///     T   (Tusenseparerad utan komma)
        ///     TK  (Tusenseparerad med komma)
        ///     P1  (Procent med en decimal)
        /// </summary>
        /// <param name="typ">Typ av formatering</param>
        /// <param name="tal">Talet som ska formateras</param>
        /// <returns>Formaterat tal returneras</returns>
        public static string Formatera(this string typ, decimal tal)
        {
            switch (typ)
            {
                case "N":
                    return tal.ToString("0");
                case "N4":
                    return tal.ToString("0000");
                case "ND1":
                    return tal.ToString("0.0");
                case "ND2":
                    return tal.ToString("0.00");
                case "D":
                    return tal.ToString("###");
                case "DD2":
                    return tal.ToString("#.##");
                case "NT":
                    return tal.ToString("# ##0");
                case "T":
                    return tal.ToString("# ###");
                case "TK":
                    return tal.ToString("#,###");
                case "P1":
                    return tal.ToString("#0.##%");
                default:
                    return tal.ToString("# ###.#");
            }
        }

        /// <summary>
        /// Formaterar datum för presentation, typen styr hur. Följande typer finns:
        /// 
        ///     STD (Standard YYYY-MM-DD)   
        ///     SDS (Short Date String)
        ///     LDS (Long Date tring)
        /// </summary>
        /// <param name="typ">Typ av formatering</param>
        /// <param name="datum">Datumet som ska formateras</param>
        /// <returns>Formaterat tal returneras</returns>
        public static string Formatera(this string typ, DateTime datum)
        {
            switch (typ)
            {
                case "STD":
                    return datum.ToString("yyyy-MM-dd");
                case "SDS":
                    return datum.ToShortDateString();
                case "LDS":
                    return datum.ToLongDateString();
                default:
                    return datum.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// Byta ut elaka nullvärden mot blankt
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns>string, blanke eller värde</returns>
        public static string GetText(this DataRow row, string columnName)
        {
            if (row.IsNull(columnName))
                return string.Empty;

            return row[columnName] as string ?? string.Empty;
        }

        /// <summary>
        /// Kolla ranking
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<U> Rank<T, TKey, U>(this IEnumerable<T> source, Func<T, TKey> keySelector, Func<T, int, U> selector)
        {
            if (!source.Any())
            {
                yield break;
            }

            int itemCount = 0;
            T[] ordered = source.OrderByDescending(keySelector).ToArray();
            TKey previous = keySelector(ordered[0]);
            int rank = 1;
            foreach (T t in ordered)
            {
                itemCount += 1;
                TKey current = keySelector(t);
                if (!current.Equals(previous))
                {
                    rank = itemCount;
                }
                yield return selector(t, rank);
                previous = current;
            }
        }

        /// <summary>
        /// Kolla om värde är mellan eller lika med min och max
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <returns>true or false</returns>
        public static bool IsWithin(this int value, decimal minimum, decimal maximum)
        {
            return value >= minimum && value <= maximum;
        }

        /// <summary>
        /// Checkar vid fel i dataset
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ds"></param>
        /// <returns>message</returns>
        public static string CheckForErrors(this string message, DataSet ds)
        {
            string errorMessage = string.Empty;
            if (!ds.HasErrors)
            {
                //DataSet1.Merge(DataSet2);
            }
            else
            {
                errorMessage = PrintRowErrs(ds);
            }
            return errorMessage;
        }

        /// <summary>
        /// Hämta N senaste i en Objektlista
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IEnumerable<T> LastN<T>(this IList<T> list, int n)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            if (list.Count - n < 0)
            {
                n = list.Count;
            }

            for (var i = list.Count - n; i < list.Count; i++)
            {
                yield return list[i];
            }
        }

        /// <summary>
        /// Om fel i någon rad i datasetet
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns>Felmeddelande</returns>
        private static string PrintRowErrs(DataSet dataSet)
        {
            string rowError = string.Empty;
            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row.HasErrors)
                    {
                        rowError = row.RowError;
                    }
                }
            }
            return rowError;
        }

        /// <summary>
        /// Extension method to return if the control is in design mode
        /// </summary>
        /// <param name="control">Control to examine</param>
        /// <returns>True if in design mode, otherwise false</returns>
        public static bool IsInDesignMode(this System.Windows.Forms.Control control)
        {
            return ResolveDesignMode(control);
        }

        /// <summary>
        /// Method to test if the control or it's parent is in design mode
        /// </summary>
        /// <param name="control">Control to examine</param>
        /// <returns>True if in design mode, otherwise false</returns>
        private static bool ResolveDesignMode(System.Windows.Forms.Control control)
        {
            System.Reflection.PropertyInfo designModeProperty;
            bool designMode;

            // Get the protected property
            designModeProperty = control.GetType().GetProperty(
                                    "DesignMode",
                                    System.Reflection.BindingFlags.Instance
                                    | System.Reflection.BindingFlags.NonPublic);

            // Get the controls DesignMode value
            designMode = (bool)designModeProperty.GetValue(control, null);

            // Test the parent if it exists
            if (control.Parent != null)
            {
                designMode |= ResolveDesignMode(control.Parent);
            }

            return designMode;
        }
    }
}
