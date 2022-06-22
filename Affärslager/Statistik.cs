using System;
using System.Collections.Generic;
using System.Data;
using Hooker.Affärsobjekt;
using Hooker.Datalager;
using Hooker.Dataset;
using Hooker.Gemensam;

namespace Hooker.Affärslager
{
    /// <summary>
    /// Affärslagerklass för statistiken
    /// </summary>
    public sealed class Statistik : SökVillkor
    {
        /// <summary>
        /// Hämtar data för aktuell Bananalys
        /// </summary>
        /// <param name="golfklubbNr">Golfklubbnummer</param>
        /// <param name="banaNr">Bananummer</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <param name="fromDatum">Ev from datum</param>
        /// <param name="tomDatum">Ev tom datum</param>
        /// <param name="hcprond">Ev markering för hcprond</param>
        /// <param name="niohalsrond">Ev markering för niohålsrond</param>
        /// <param name="sallskapsrond">Ev markering för sällskapsrond</param>
        /// <param name="tavlingsrond">Ev markering för tävlingsrond</param>
        /// <returns>Otypat dataset med efterfrågat data</returns>
        public DataSet Bananalys(string golfklubbNr, string banaNr, string spelarID, DateTime fromDatum, 
            DateTime tomDatum, bool hcprond, bool niohalsrond, bool sallskapsrond, bool tavlingsrond)
        {
            DataSet bananalysDS = new DataSet();
            Datalager.Statistik statistik = new Datalager.Statistik();
            string sql;
            try
            {
                sql = SkapaSökvillkor(golfklubbNr, banaNr, spelarID, fromDatum, tomDatum, hcprond, niohalsrond,
                    sallskapsrond, tavlingsrond);
                bananalysDS = statistik.Bananalys(sql);
                return bananalysDS;
            }
            catch (HookerException)
            {
                throw;
            }
        }

        /// <summary>
        /// Hämta de senaste 25 rundorna för spelaren
        /// </summary>
        /// <param name="spelarID">Aktuellt spelarID</param>
        public DataSet EGALista(string spelarID)
        {
            DataSet rundaDS = new DataSet();
            Datalager.Statistik statistik = new Datalager.Statistik();

            rundaDS = statistik.EGALista(spelarID);
            return rundaDS;
        }

        /// <summary>
        /// Hämtar data för aktuell Ekonomianalys
        /// </summary>
        /// <param name="redovisningsTyp">RedovisningsTyp</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <param name="fromDatum">Ev from datum</param>
        /// <param name="tomDatum">Ev tom datum</param>
        /// <param name="detaljerad">Ev markering för detaljerad redovisning</param>
        /// <param name="summerad">Ev markering för summerad redovisning</param>
        /// <returns>Otypat dataset med efterfrågat data</returns>
        public DataSet Ekonomianalys(string redovisningsTyp, string spelarID, DateTime fromDatum, DateTime tomDatum, 
            bool detaljerad, bool summerad)
        {
            DataSet ekonomianalysDS = new DataSet();
            Datalager.Statistik statistik = new Datalager.Statistik();
            string sql;
            try
            {
                sql = SkapaSökvillkor(redovisningsTyp, spelarID, fromDatum, tomDatum, detaljerad, summerad);
                ekonomianalysDS = statistik.Ekonomianalys(sql, detaljerad);
                return ekonomianalysDS;
            }
            catch (HookerException)
            {
                throw;
            }
        }

        /// <summary>
        /// Hämtar data för aktuell Gruppanalys
        /// </summary>
        /// <param name="golfklubbNr">Golfklubbnummer</param>
        /// <param name="banaNr">Bananummer</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <param name="fromDatum">Ev from datum</param>
        /// <param name="tomDatum">Ev tom datum</param>
        /// <param name="hcprond">Ev markering för hcprond</param>
        /// <param name="niohalsrond">Ev markering för niohålsrond</param>
        /// <param name="sallskapsrond">Ev markering för sällskapsrond</param>
        /// <param name="tavlingsrond">Ev markering för tävlingsrond</param>
        /// <returns>Otypat dataset med efterfrågat data</returns>
        public DataSet Gruppanalys(string golfklubbNr, string banaNr, string spelarID, DateTime fromDatum, 
            DateTime tomDatum, bool hcprond,bool niohalsrond, bool sallskapsrond, bool tavlingsrond)
        {
            DataSet gruppanalysDS = new DataSet();
            Datalager.Statistik statistik = new Datalager.Statistik();
            string sql;
            try
            {
                sql = SkapaSökvillkor(golfklubbNr, banaNr, spelarID, fromDatum, tomDatum, hcprond, niohalsrond,
                    sallskapsrond, tavlingsrond);
                gruppanalysDS = statistik.Gruppanalys(sql);
                return gruppanalysDS;
            }
            catch (HookerException)
            {
                throw;
            }
        }

        /// <summary>
        ///     Hämtar data för aktuell Puttstatistik
        /// </summary>
        /// <param name="golfklubbNr">Golfklubbnummer</param>
        /// <param name="banaNr">Bananummer</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <param name="fromDatum">Ev from datum</param>
        /// <param name="tomDatum">Ev tom datum</param>
        /// <param name="hcprond">Ev markering för hcprond</param>
        /// <param name="niohalsrond">Ev markering för niohålsrond</param>
        /// <param name="sallskapsrond">Ev markering för sällskapsrond</param>
        /// <param name="tavlingsrond">Ev markering för tävlingsrond</param>
        /// <returns>Otypat dataset med efterfrågat data</returns>
        public DataSet Puttstatistik(string golfklubbNr, string banaNr, string spelarID, 
            DateTime fromDatum, DateTime tomDatum, bool hcprond, bool niohalsrond, bool sallskapsrond, 
            bool tavlingsrond)
        {
            DataSet puttstatistikDS = new DataSet();
            Datalager.Statistik statistik = new Datalager.Statistik();
            string sql;
            try
            {
                sql = SkapaSökvillkor(golfklubbNr, banaNr, spelarID, fromDatum, tomDatum, hcprond, niohalsrond,
                    sallskapsrond, tavlingsrond);
                puttstatistikDS = statistik.Puttstatistik(sql);
                return puttstatistikDS;
            }
            catch (HookerException)
            {
                throw;
            }
        }

        /// <summary>
        /// Hämtar data för aktuell Rondanalys
        /// </summary>
        /// <param name="golfklubbNr">Golfklubbnummer</param>
        /// <param name="banaNr">Bananummer</param>
        /// <param name="spelarID">Aktuellt spelarID</param>
        /// <param name="fromDatum">Ev from datum</param>
        /// <param name="tomDatum">Ev tom datum</param>
        /// <param name="hcprond">Ev markering för hcprond</param>
        /// <param name="niohalsrond">Ev markering för niohålsrond</param>
        /// <param name="sallskapsrond">Ev markering för sällskapsrond</param>
        /// <param name="tavlingsrond">Ev markering för tävlingsrond</param>
        /// <returns>Otypat dataset med efterfrågat data</returns>
        public DataSet Rondanalys(string golfklubbNr, string banaNr, string spelarID, DateTime fromDatum, 
            DateTime tomDatum, bool hcprond, bool niohalsrond, bool sallskapsrond, bool tavlingsrond)
        {
            DataSet rondanalysDS = new DataSet();
            Datalager.Statistik statistik = new Datalager.Statistik();
            string sql;
            try
            {
                sql = SkapaSökvillkor(golfklubbNr, banaNr, spelarID, fromDatum, tomDatum, hcprond, niohalsrond,
                    sallskapsrond, tavlingsrond);
                rondanalysDS = statistik.Rondanalys(sql);
                return rondanalysDS;
            }
            catch (HookerException)
            {
                throw;
            }
        }
    }
}
