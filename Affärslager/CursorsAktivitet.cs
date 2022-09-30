using Hooker.Affärsobjekt;
using Hooker.Datalager;
using System;
using System.Collections.Generic;
using System.Data;

namespace Hooker.Affärslager
{
    public sealed class CursorsAktivitet
    {
        /// <summary>
        /// Hämta från databasen
        /// </summary>
        /// <returns>Systemvariabler objektet</returns>
        public List<Cursors> Hämta()
        {
            //kolla i databasen
            CursorsData cursorsData;
            DataSet cursorsDS = new DataSet();
            List<Cursors> cursors = null;
            try
            {
                cursorsData = new CursorsData();
                cursorsDS = cursorsData.Hämta();
                if (cursorsDS.Tables[0].Rows.Count == 0)
                {
                    return cursors;
                }
                cursors = new List<Cursors>(cursorsDS.Tables[0].Rows.Count);
                foreach (DataRow row in cursorsDS.Tables[0].Rows)
                {
                    cursors.Add(new Cursors()
                    {
                        CursorID = (int)row["CursorID"],
                        Cursornamn = row["Cursornamn"].ToString(),
                        CursorImage = (byte[])row["CursorImage"]
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cursors;
        }

        /// <summary>
        /// Hämta aktuell Cursor från databasen
        /// </summary>
        /// <returns>Cursor objektet</returns>
        public Cursors Hämta(int cursorID)
        {
            //kolla i databasen
            CursorsData cursorsData;
            DataSet cursorsDS = new DataSet();
            Cursors cursors = null;
            try
            {
                cursorsData = new CursorsData();
                cursorsDS = cursorsData.Hämta(cursorID);
                if (cursorsDS.Tables[0].Rows.Count == 0)
                {
                    return cursors;
                }
                cursors = new Cursors();
                cursors.CursorID = (int)cursorsDS.Tables[0].Rows[0]["CursorID"];
                cursors.Cursornamn = cursorsDS.Tables[0].Rows[0]["Cursornamn"].ToString();
                cursors.CursorImage = (byte[])cursorsDS.Tables[0].Rows[0]["CursorImage"];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cursors;
        }
    }
}
