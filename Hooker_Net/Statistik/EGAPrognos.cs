using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Hooker.Affärslager;

namespace Hooker.Gemensam
{
    /// <summary>
    /// Beräknar EGA Hcp Prognos
    /// </summary>
    public class EGAPrognos
    {
        private DataSet EGAListaDS { get; set; }

        /// <summary>
        /// SpelarID
        /// </summary>
        public int SpelarID { get; set; }

        /// <summary>
        /// Prognosticerat HCP
        /// </summary>
        public decimal HcpResultat { get; set; }

        /// <summary>
        /// Beräknar EGA hcp prognos
        /// </summary>
        /// <returns>EGA prognos</returns>
        public decimal UtförHcpPrognos()
        {
            HcpResultat = 0;
            Statistik statistik = new Statistik();

            if (SpelarID.ToString() == null)
                return HcpResultat;

            EGAListaDS = new DataSet();
            EGAListaDS = statistik.EGALista(SpelarID.ToString());

            if (EGAListaDS.Tables["EGALista"].Rows.Count < 8)
            {
                return HcpResultat;
            }
            DataTable topEight = TopDataRow(EGAListaDS.Tables["EGALista"]);
            List<EightRounds> eights = new List<EightRounds>(8);
            for (int i = 0; i < 8; i++)
            {
                eights.Add(new EightRounds()
                {
                    RundaNr = topEight.Rows[i]["RundaNr"].ToString(),
                    Poäng = Convert.ToInt32(topEight.Rows[i]["Poäng"]),
                    Hcp = (113 / Convert.ToDecimal(topEight.Rows[i]["Slope Herrar"]) *
                        (Convert.ToInt32(topEight.Rows[i]["Par"]) +
                        Convert.ToInt32(topEight.Rows[i]["Spelhcp"]) -
                        (Convert.ToInt32(topEight.Rows[i]["Poäng"]) - 36) -
                        Convert.ToDecimal(topEight.Rows[i]["CR Herrar"]) - 0))
                });
            }

            foreach (EightRounds eight in eights)
            {
                HcpResultat += eight.Hcp;
            }

            return (HcpResultat / 8);
        }

        ///// <summary>
        ///// Sorterar listan på poäng i fallande ordning
        ///// </summary>
        ///// <param name="dt">DataTable som ska sorteras</param>
        ///// <returns>Sorterad DataTable</returns>
        //private DataTable TopDataRow(DataTable dt)
        //{
        //    DataView view = new DataView(dt);
        //    view.Sort = "Poäng DESC";
        //    DataTable dtn = view.ToTable();
        //    return dtn;
        //}

        /// <summary>
        /// Sorterar listan på poäng i fallande ordning, men bara Hcpronder
        /// </summary>
        /// <param name="dt">DataTable som ska sorteras</param>
        /// <returns>Sorterad DataTable</returns>
        public DataTable TopDataRow(DataTable dt)
        {
            var result = dt.AsEnumerable().Take(20)
                .Where(myRow => myRow["Hcp"].ToString() == "X" ||
                myRow["Slope Herrar"].ToString() != "0" ||
                myRow["CR Herrar"].ToString() != "0" ||
                myRow["Slope Damer"].ToString() != "0" ||
                myRow["CR Damer"].ToString() != "0")
                ;
            DataTable dtRes = result.CopyToDataTable();
            DataTable dtTop = dtRes.Rows.OfType<DataRow>().ToList().CopyToDataTable();
            DataView view = new DataView(dtTop);
            view.Sort = "Poäng DESC";
            DataTable dtn = view.ToTable();
            return dtn;
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal class EightRounds
        {
            /// <summary>
            /// RundaNe
            /// </summary>
            public string RundaNr { get; set; }

            /// <summary>
            /// Poäng på rundan
            /// </summary>
            public int Poäng { get; set; }

            /// <summary>
            /// Beräknat Hcp för rundan
            /// </summary>
            public decimal Hcp { get; set; }
        }
    }
}
