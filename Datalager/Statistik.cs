using System.Data;
using System.Text;
using Hooker.Gemensam;
using GemensamService;
using System.Collections.Generic;

namespace Hooker.Datalager
{
    /// <summary>
    /// Datalagerklass för all Statistik
    /// </summary>
    public sealed class Statistik : AbstractDataLager
    {
        /// <summary>
        /// Skapar statistiken för Bananlysen
        /// </summary>
        /// <param name="sqlSok">Aktuellt where-villkor</param>
        /// <returns>Otypat dataset med efterfrågat resultat</returns>
        public DataSet Bananalys(string sqlSok)
        {
            _ = new DataSet();
            StringBuilder sql = new StringBuilder();

            try
            {
                sql.Append("SELECT r.SpelarID, r.BanaNr, rh.HalNr, ");
                sql.Append("SUM(rh.AntalSlag) AS 'Slag', SUM(rh.AntalPoang) AS 'Poäng', SUM(rh.AntalPuttar) AS 'Puttar', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par THEN + 1 END) AS 'Antal Par', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag < bh.Par THEN + 1 END) AS 'Antal Birdie', ");
                sql.Append("SUM(CASE WHEN rh.FwTraff = 'X' THEN + 1 END) AS 'Antal FW', ");
                sql.Append("SUM(CASE WHEN rh.GrTraff = 'X' THEN + 1 END) AS 'Antal GR', ");
                sql.Append("COUNT(r.RundaNr) AS 'Antal Rundor' ");
                sql.Append("FROM Runda r ");
                sql.Append("INNER JOIN RundaHal rh ON r.RundaNr = rh.RundaNr ");
                sql.Append("INNER JOIN BanaHal bh ON bh.BanaNr = r.BanaNr AND bh.HalNr = rh.HalNr");
                sql.Append(sqlSok.ToString());
                sql.Append(" GROUP BY r.SpelarID, r.BanaNr, rh.HalNr ");
                sql.Append("ORDER BY r.BanaNr, rh.HalNr");
                DataSet bananalysDS = DatabasAccess.RunSql(sql.ToString());
                bananalysDS.Tables[0].TableName = "Bananalys";
                return bananalysDS;
            }
            catch (HookerException hex)
            {
                throw hex;
            }
            finally
            {
                if (DatabasAccess != null)
                {
                    DatabasAccess.Dispose();
                }
            }
        }

        /// <summary>
        /// Hämta rundor för EGA listan
        /// </summary>
        /// <returns>Otypat dataset med efterfrågat resultat</returns>
        public DataSet EGALista(string spelarID)
        {
            _ = new DataSet();
            StringBuilder sql = new StringBuilder();
            try
            {
                sql.Append("SELECT r.RundaNr, r.SpelarID AS 'SpelarID', r.Datum AS 'Datum', ");
                sql.Append("CONCAT(g.GolfklubbNamn, ' - ', b.Namn) AS 'Bana', ");
                sql.Append("b.SlopeHerrarGul AS 'Slope Herrar', b.CrHerrarGul AS 'CR Herrar',");
                sql.Append("b.SlopeDamerRod AS 'Slope Damer', b.CrDamerRod AS 'CR Damer', ");
                sql.Append("r.ErhallnaSlag AS 'Spelhcp', r.Hcprond AS 'Hcp', ");
                sql.Append("SUM(bh.Par) AS 'Par', SUM(rh.AntalPoang) AS 'Poäng' ");
                sql.Append("FROM Runda r ");
                sql.Append("INNER JOIN RundaHal rh ON r.RundaNr = rh.RundaNr ");
                sql.Append("INNER JOIN Bana b ON b.BanaNr = r.BanaNr ");
                sql.Append("INNER JOIN BanaHal bh ON bh.BanaNr = b.BanaNr And bh.Halnr = rh.HalNr ");
                sql.Append("INNER JOIN Golfklubb g ON g.GolfklubbNr = b.GolfklubbNr ");
                sql.Append("WHERE r.SpelarID = @SpelarID ");
                sql.Append("GROUP BY r.RundaNr, r.SpelarID, g.GolfklubbNamn, b.Namn, r.Datum, b.SlopeHerrarGul, ");
                sql.Append("b.CrHerrarGul, b.SlopeDamerRod, b.CrDamerRod, r.ErhallnaSlag, r.Hcprond ");
                sql.Append("ORDER BY r.Datum DESC;");
//                sql.Append("LIMIT 25; ");

                List<DatabasParameters> dbParameters = new List<DatabasParameters>()
                {
                    new DatabasParameters("@SpelarID", DataTyp.String, spelarID)
                };
                DataSet egaListaDS = DatabasAccess.FyllDataSet(sql.ToString(), dbParameters);
                egaListaDS.Tables[0].TableName = "EGALista";
                return egaListaDS;
            }
            catch (HookerException hex)
            {
                throw hex;
            }
            finally
            {
                if (DatabasAccess != null)
                {
                    DatabasAccess.Dispose();
                }
            }
        }

            /// <summary>
            /// Skapar statistiken för Ekonomianlysen (två olika selecter blev det)
            /// </summary>
            /// <param name="sqlSok">Aktuellt where-villkor</param>
            /// <param name="detaljerad">Detaljerad, true eller false</param>
            /// <returns>Otypat dataset med efterfrågat resultat</returns>
        public DataSet Ekonomianalys(string sqlSok, bool detaljerad)
        {
            _ = new DataSet();
            StringBuilder sql = new StringBuilder();

            try
            {
                //Skapa sql:en
                if (detaljerad)
                {
                    sql.Append("SELECT re.TransNr, re.Typ, re.Datum, re.RundaNr, re.SpelarID, re.Belopp, s.Namn, k.Varde AS Typnamn, ");
                    sql.Append("CASE WHEN r.Notering IS NOT NULL THEN r.Notering ");
                    sql.Append("WHEN re.Notering IS NOT NULL THEN re.Notering ");
                    sql.Append("ELSE '' END AS Notering ");
                    sql.Append("FROM Redovisning re ");
                    sql.Append("INNER JOIN Koder k ON k.Typ = 10 AND k.Argument = re.Typ ");
                    sql.Append("INNER JOIN Spelare s ON re.SpelarID = s.SpelarID ");
                    sql.Append("LEFT OUTER JOIN Runda r ON re.RundaNr = r.RundaNr");
                    sql.Append(sqlSok);
                    sql.Append(" ORDER BY Typnamn, s.Namn, re.Datum");
                }
                else
                {
                    sql.Append("SELECT re.Typ, re.SpelarID, s.Namn, k.Varde AS Typnamn, SUM(re.Belopp) AS Belopp ");
                    sql.Append("FROM Redovisning re ");
                    sql.Append("INNER JOIN Koder k ON k.Typ = 10 AND k.Argument = re.Typ ");
                    sql.Append("INNER JOIN Spelare s ON re.SpelarID = s.SpelarID ");
                    sql.Append(sqlSok);
                    sql.Append("GROUP BY re.Typ, re.SpelarID, s.Namn, k.Varde ");
                    sql.Append("ORDER BY Typnamn, s.Namn");
                }
                DataSet ekonomianalysDS = DatabasAccess.RunSql(sql.ToString());
                ekonomianalysDS.Tables[0].TableName = "Ekonomianalys";
                return ekonomianalysDS;
            }
            catch (HookerException hex)
            {
                throw hex;
            }
            finally
            {
                if (DatabasAccess != null)
                {
                    DatabasAccess.Dispose();
                }
            }
        }

        /// <summary>
        /// Skapar statistiken för Gruppanlysen (blev en lång en med fyra Union)
        /// </summary>
        /// <param name="sqlSok">Aktuellt where-villkor</param>
        /// <returns>Otypat dataset med efterfrågat resultat</returns>
        public DataSet Gruppanalys(string sqlSok)
        {
            _ = new DataSet();
            StringBuilder sql = new StringBuilder();

            try
            {
                sql.Append("SELECT r.SpelarID, bh.Par, ");
                sql.Append("SUM(rh.AntalSlag) AS 'Slag', SUM(rh.AntalPoang) AS 'Poäng', SUM(rh.AntalPuttar) AS 'Puttar', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par - 2 THEN + 1 END) AS 'Antal Eagle', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par - 1  THEN + 1 END) AS 'Antal Birdie', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par THEN + 1 END) AS 'Antal Par', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par + 1 THEN + 1 END) AS 'Antal Bogey', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par + 2 THEN + 1 END) AS 'Antal Dubbelbogey', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par + 3 THEN + 1 END) AS 'Antal Trippelbogey', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag > bh.Par + 3 THEN + 1 END) AS 'Antal Andra', ");
                sql.Append("SUM(CASE WHEN rh.FwTraff = 'X' THEN + 1 END) AS 'Antal FW', ");
                sql.Append("SUM(CASE WHEN rh.GrTraff = 'X' THEN + 1 END) AS 'Antal GR', ");
                sql.Append("COUNT(r.RundaNr) AS 'Antal hål' ");
                sql.Append("FROM Runda r ");
                sql.Append("INNER JOIN RundaHal rh ON r.RundaNr = rh.RundaNr ");
                sql.Append("INNER JOIN BanaHal bh ON bh.BanaNr = r.BanaNr AND bh.HalNr = rh.HalNr ");
                sql.Append("INNER JOIN Bana b ON b.BanaNr = r.BanaNr ");
                sql.Append("INNER JOIN Golfklubb g ON g.GolfklubbNr = b.GolfklubbNr");
                sql.Append(sqlSok.ToString());
                sql.Append(" AND bh.Par = 3");
                sql.Append(" GROUP BY r.SpelarID, bh.Par ");
                sql.Append("UNION ");
                sql.Append("SELECT r.SpelarID, bh.Par, ");
                sql.Append("SUM(rh.AntalSlag) AS 'Slag', SUM(rh.AntalPoang) AS 'Poäng', SUM(rh.AntalPuttar) AS 'Puttar', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par - 2 THEN + 1 END) AS 'Antal Eagle', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par - 1  THEN + 1 END) AS 'Antal Birdie', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par THEN + 1 END) AS 'Antal Par', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par + 1 THEN + 1 END) AS 'Antal Bogey', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par + 2 THEN + 1 END) AS 'Antal Dubbelbogey', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par + 3 THEN + 1 END) AS 'Antal Trippelbogey', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag > bh.Par + 3 THEN + 1 END) AS 'Antal Andra', ");
                sql.Append("SUM(CASE WHEN rh.FwTraff = 'X' THEN + 1 END) AS 'Antal FW', ");
                sql.Append("SUM(CASE WHEN rh.GrTraff = 'X' THEN + 1 END) AS 'Antal GR', ");
                sql.Append("COUNT(r.RundaNr) AS 'Antal hål' ");
                sql.Append("FROM Runda r ");
                sql.Append("INNER JOIN RundaHal rh ON r.RundaNr = rh.RundaNr ");
                sql.Append("INNER JOIN BanaHal bh ON bh.BanaNr = r.BanaNr AND bh.HalNr = rh.HalNr ");
                sql.Append("INNER JOIN Bana b ON b.BanaNr = r.BanaNr ");
                sql.Append("INNER JOIN Golfklubb g ON g.GolfklubbNr = b.GolfklubbNr");
                sql.Append(sqlSok.ToString());
                sql.Append(" AND bh.Par = 4");
                sql.Append(" GROUP BY r.SpelarID, bh.Par ");
                sql.Append("UNION ");
                sql.Append("SELECT r.SpelarID, bh.Par, ");
                sql.Append("SUM(rh.AntalSlag) AS 'Slag', SUM(rh.AntalPoang) AS 'Poäng', SUM(rh.AntalPuttar) AS 'Puttar', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par - 2 THEN + 1 END) AS 'Antal Eagle', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par - 1  THEN + 1 END) AS 'Antal Birdie', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par THEN + 1 END) AS 'Antal Par', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par + 1 THEN + 1 END) AS 'Antal Bogey', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par + 2 THEN + 1 END) AS 'Antal Dubbelbogey', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par + 3 THEN + 1 END) AS 'Antal Trippelbogey', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag > bh.Par + 3 THEN + 1 END) AS 'Antal Andra', ");
                sql.Append("SUM(CASE WHEN rh.FwTraff = 'X' THEN + 1 END) AS 'Antal FW', ");
                sql.Append("SUM(CASE WHEN rh.GrTraff = 'X' THEN + 1 END) AS 'Antal GR', ");
                sql.Append("COUNT(r.RundaNr) AS 'Antal hål' ");
                sql.Append("FROM Runda r ");
                sql.Append("INNER JOIN RundaHal rh ON r.RundaNr = rh.RundaNr ");
                sql.Append("INNER JOIN BanaHal bh ON bh.BanaNr = r.BanaNr AND bh.HalNr = rh.HalNr ");
                sql.Append("INNER JOIN Bana b ON b.BanaNr = r.BanaNr ");
                sql.Append("INNER JOIN Golfklubb g ON g.GolfklubbNr = b.GolfklubbNr");
                sql.Append(sqlSok.ToString());
                sql.Append(" AND bh.Par = 5");
                sql.Append(" GROUP BY r.SpelarID, bh.Par ");
                sql.Append("UNION ");
                sql.Append("SELECT r.SpelarID, 9, ");
                sql.Append("SUM(rh.AntalSlag) AS 'Slag', SUM(rh.AntalPoang) AS 'Poäng', SUM(rh.AntalPuttar) AS 'Puttar', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par - 2 THEN + 1 END) AS 'Antal Eagle', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par - 1  THEN + 1 END) AS 'Antal Birdie', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par THEN + 1 END) AS 'Antal Par', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par + 1 THEN + 1 END) AS 'Antal Bogey', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par + 2 THEN + 1 END) AS 'Antal Dubbelbogey', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag = bh.Par + 3 THEN + 1 END) AS 'Antal Trippelbogey', ");
                sql.Append("SUM(CASE WHEN rh.AntalSlag > bh.Par + 3 THEN + 1 END) AS 'Antal Andra', ");
                sql.Append("SUM(CASE WHEN rh.FwTraff = 'X' THEN + 1 END) AS 'Antal FW', ");
                sql.Append("SUM(CASE WHEN rh.GrTraff = 'X' THEN + 1 END) AS 'Antal GR', ");
                sql.Append("COUNT(r.RundaNr) AS 'Antal hål' ");
                sql.Append("FROM Runda r ");
                sql.Append("INNER JOIN RundaHal rh ON r.RundaNr = rh.RundaNr ");
                sql.Append("INNER JOIN BanaHal bh ON bh.BanaNr = r.BanaNr AND bh.HalNr = rh.HalNr ");
                sql.Append("INNER JOIN Bana b ON b.BanaNr = r.BanaNr ");
                sql.Append("INNER JOIN Golfklubb g ON g.GolfklubbNr = b.GolfklubbNr");
                sql.Append(sqlSok.ToString());
                sql.Append(" GROUP BY r.SpelarID; ");
                sql.Append("SELECT COUNT(r.RundaNr) AS 'Antal rundor' ");
                sql.Append("FROM Runda r ");
                sql.Append("INNER JOIN Bana b ON b.BanaNr = r.BanaNr ");
                sql.Append("INNER JOIN Golfklubb g ON g.GolfklubbNr = b.GolfklubbNr");
                sql.Append(sqlSok.ToString() + ";");
                DataSet gruppanalysDS = DatabasAccess.RunSql(sql.ToString());
                gruppanalysDS.Tables[0].TableName = "Gruppanalys";
                gruppanalysDS.Tables[1].TableName = "Antal";
                return gruppanalysDS;
            }
            catch (HookerException hex)
            {
                throw hex;
            }
            finally
            {
                if (DatabasAccess != null)
                {
                    DatabasAccess.Dispose();
                }
            }
        }

        /// <summary>
        ///     Skapar statistiken för puttningen (blev ocksp en lång en med fyra Union)
        /// </summary>
        /// <param name="sqlSok">Aktuellt where-villkor</param>
        /// <returns>Otypat dataset med efterfrågat resultat</returns>
        public DataSet Puttstatistik(string sqlSok)
        {
            _ = new DataSet();
            StringBuilder sql = new StringBuilder();

            try
            {
                sql.Append("SELECT r.SpelarID, bh.Par, ");
                sql.Append("SUM(rh.AntalPuttar) AS 'Antal puttar', ");
                sql.Append("SUM(rh.AntalSlag) AS 'Antal slag', ");
                sql.Append("SUM(CASE WHEN rh.AntalPuttar = 0 THEN + 1 END) AS 'Antal 0 puttar', ");
                sql.Append("SUM(CASE WHEN rh.AntalPuttar = 1 THEN + 1 END) AS 'Antal 1 puttar', ");
                sql.Append("SUM(CASE WHEN rh.AntalPuttar = 2 THEN + 1 END) AS 'Antal 2 puttar', ");
                sql.Append("SUM(CASE WHEN rh.AntalPuttar = 3 THEN + 1 END) AS 'Antal 3 puttar', ");
                sql.Append("SUM(CASE WHEN rh.AntalPuttar > 3 THEN + 1 END) AS 'Antal fler puttar', ");
                sql.Append("COUNT(r.RundaNr) AS 'Antal hål' ");
                sql.Append("FROM Runda r ");
                sql.Append("INNER JOIN RundaHal rh ON r.RundaNr = rh.RundaNr ");
                sql.Append("INNER JOIN BanaHal bh ON bh.BanaNr = r.BanaNr AND bh.HalNr = rh.HalNr ");
                sql.Append("INNER JOIN Bana b ON b.BanaNr = r.BanaNr ");
                sql.Append("INNER JOIN Golfklubb g ON g.GolfklubbNr = b.GolfklubbNr");
                sql.Append(sqlSok.ToString());
                sql.Append(" AND bh.Par = 3");
                sql.Append(" GROUP BY r.SpelarID, bh.Par ");
                sql.Append("UNION ");
                sql.Append("SELECT r.SpelarID, bh.Par, ");
                sql.Append("SUM(rh.AntalPuttar) AS 'Antal puttar', ");
                sql.Append("SUM(rh.AntalSlag) AS 'Antal slag', ");
                sql.Append("SUM(CASE WHEN rh.AntalPuttar = 0 THEN + 1 END) AS 'Antal 0 puttar', ");
                sql.Append("SUM(CASE WHEN rh.AntalPuttar = 1 THEN + 1 END) AS 'Antal 1 puttar', ");
                sql.Append("SUM(CASE WHEN rh.AntalPuttar = 2 THEN + 1 END) AS 'Antal 2 puttar', ");
                sql.Append("SUM(CASE WHEN rh.AntalPuttar = 3 THEN + 1 END) AS 'Antal 3 puttar', ");
                sql.Append("SUM(CASE WHEN rh.AntalPuttar > 3 THEN + 1 END) AS 'Antal fler puttar', ");
                sql.Append("COUNT(r.RundaNr) AS 'Antal hål' ");
                sql.Append("FROM Runda r ");
                sql.Append("INNER JOIN RundaHal rh ON r.RundaNr = rh.RundaNr ");
                sql.Append("INNER JOIN BanaHal bh ON bh.BanaNr = r.BanaNr AND bh.HalNr = rh.HalNr ");
                sql.Append("INNER JOIN Bana b ON b.BanaNr = r.BanaNr ");
                sql.Append("INNER JOIN Golfklubb g ON g.GolfklubbNr = b.GolfklubbNr");
                sql.Append(sqlSok.ToString());
                sql.Append(" AND bh.Par = 4");
                sql.Append(" GROUP BY r.SpelarID, bh.Par ");
                sql.Append("UNION ");
                sql.Append("SELECT r.SpelarID, bh.Par, ");
                sql.Append("SUM(rh.AntalPuttar) AS 'Antal puttar', ");
                sql.Append("SUM(rh.AntalSlag) AS 'Antal slag', ");
                sql.Append("SUM(CASE WHEN rh.AntalPuttar = 0 THEN + 1 END) AS 'Antal 0 puttar', ");
                sql.Append("SUM(CASE WHEN rh.AntalPuttar = 1 THEN + 1 END) AS 'Antal 1 puttar', ");
                sql.Append("SUM(CASE WHEN rh.AntalPuttar = 2 THEN + 1 END) AS 'Antal 2 puttar', ");
                sql.Append("SUM(CASE WHEN rh.AntalPuttar = 3 THEN + 1 END) AS 'Antal 3 puttar', ");
                sql.Append("SUM(CASE WHEN rh.AntalPuttar > 3 THEN + 1 END) AS 'Antal fler puttar', ");
                sql.Append("COUNT(r.RundaNr) AS 'Antal hål' ");
                sql.Append("FROM Runda r ");
                sql.Append("INNER JOIN RundaHal rh ON r.RundaNr = rh.RundaNr ");
                sql.Append("INNER JOIN BanaHal bh ON bh.BanaNr = r.BanaNr AND bh.HalNr = rh.HalNr ");
                sql.Append("INNER JOIN Bana b ON b.BanaNr = r.BanaNr ");
                sql.Append("INNER JOIN Golfklubb g ON g.GolfklubbNr = b.GolfklubbNr");
                sql.Append(sqlSok.ToString());
                sql.Append(" AND bh.Par = 5");
                sql.Append(" GROUP BY r.SpelarID, bh.Par ");
                sql.Append("UNION ");
                sql.Append("SELECT r.SpelarID, 9, ");
                sql.Append("SUM(rh.AntalPuttar) AS 'Antal puttar', ");
                sql.Append("SUM(rh.AntalSlag) AS 'Antal slag', ");
                sql.Append("SUM(CASE WHEN rh.AntalPuttar = 0 THEN + 1 END) AS 'Antal 0 puttar', ");
                sql.Append("SUM(CASE WHEN rh.AntalPuttar = 1 THEN + 1 END) AS 'Antal 1 puttar', ");
                sql.Append("SUM(CASE WHEN rh.AntalPuttar = 2 THEN + 1 END) AS 'Antal 2 puttar', ");
                sql.Append("SUM(CASE WHEN rh.AntalPuttar = 3 THEN + 1 END) AS 'Antal 3 puttar', ");
                sql.Append("SUM(CASE WHEN rh.AntalPuttar > 3 THEN + 1 END) AS 'Antal fler puttar', ");
                sql.Append("COUNT(r.RundaNr) AS 'Antal hål' ");
                sql.Append("FROM Runda r ");
                sql.Append("INNER JOIN RundaHal rh ON r.RundaNr = rh.RundaNr ");
                sql.Append("INNER JOIN BanaHal bh ON bh.BanaNr = r.BanaNr AND bh.HalNr = rh.HalNr ");
                sql.Append("INNER JOIN Bana b ON b.BanaNr = r.BanaNr ");
                sql.Append("INNER JOIN Golfklubb g ON g.GolfklubbNr = b.GolfklubbNr");
                sql.Append(sqlSok.ToString());
                sql.Append(" GROUP BY r.SpelarID; ");
                sql.Append("SELECT COUNT(r.RundaNr) AS 'Antal rundor' ");
                sql.Append("FROM Runda r ");
                sql.Append("INNER JOIN Bana b ON b.BanaNr = r.BanaNr ");
                sql.Append("INNER JOIN Golfklubb g ON g.GolfklubbNr = b.GolfklubbNr");
                sql.Append(sqlSok.ToString() + ";");
                DataSet puttstatistikDS = DatabasAccess.RunSql(sql.ToString());
                puttstatistikDS.Tables[0].TableName = "Puttstatistik";
                puttstatistikDS.Tables[1].TableName = "Antal";
                return puttstatistikDS;
            }
            catch (HookerException hex)
            {
                throw hex;
            }
            finally
            {
                if (DatabasAccess != null)
                {
                    DatabasAccess.Dispose();
                }
            }
        }

        /// <summary>
        /// Skapar statistiken för Rondanlysen
        /// </summary>
        /// <param name="sqlSok">Aktuellt where-villkor</param>
        /// <returns>Otypat dataset med efterfrågat resultat</returns>
        public DataSet Rondanalys(string sqlSok)
        {
            _ = new DataSet();
            StringBuilder sql = new StringBuilder();

            try
            {
                sql.Append("SELECT r.SpelarID AS 'SpelarID', g.GolfklubbNr, r.BanaNr AS 'BanaNr', r.RundaNr AS 'RundaNr', ");
                sql.Append("r.Datum AS 'Datum', g.GolfklubbNamn AS 'Golfklubb', b.Namn AS 'BanaNamn', b.Aktuell, ");
                sql.Append("SUM(rh.AntalSlag) AS 'Slag', SUM(rh.AntalPoang) AS 'Poäng', ");
                sql.Append("SUM(CASE WHEN rh.HalNr < 10 THEN rh.AntalSlag END) AS 'Slag Ut', ");
                sql.Append("SUM(CASE WHEN rh.HalNr > 9 THEN rh.AntalSlag END) AS 'Slag In', ");
                sql.Append("SUM(CASE WHEN rh.HalNr < 10 THEN rh.AntalPoang END) AS 'Poäng Ut', ");
                sql.Append("SUM(CASE WHEN rh.HalNr > 9 THEN rh.AntalPoang END) AS 'Poäng In', ");
	            sql.Append("SUM(CASE WHEN rh.HalNr < 4 THEN rh.AntalPoang END) AS 'Res efter 3', ");
	            sql.Append("SUM(CASE WHEN rh.HalNr < 7 THEN rh.AntalPoang END) AS 'Res efter 6', ");
	            sql.Append("SUM(CASE WHEN rh.HalNr < 10 THEN rh.AntalPoang END) AS 'Res efter 9', ");
	            sql.Append("SUM(CASE WHEN rh.HalNr < 13 THEN rh.AntalPoang END) AS 'Res efter 12', ");
	            sql.Append("SUM(CASE WHEN rh.HalNr < 16 THEN rh.AntalPoang END) AS 'Res efter 15', ");
	            sql.Append("SUM(CASE WHEN rh.HalNr < 19 THEN rh.AntalPoang END) AS 'Res efter 18' ");
                sql.Append("FROM Runda r ");
                sql.Append("INNER JOIN RundaHal rh ON r.RundaNr = rh.RundaNr ");
                sql.Append("INNER JOIN Bana b ON b.BanaNr = r.BanaNr ");
                sql.Append("INNER JOIN Golfklubb g ON g.GolfklubbNr = b.GolfklubbNr");
                sql.Append(sqlSok.ToString());
                sql.Append(" GROUP BY r.SpelarID, g.GolfklubbNr, r.BanaNr, r.RundaNr, r.Datum, g.GolfklubbNamn, b.Namn, b.Aktuell ");
                sql.Append("ORDER BY r.Datum, r.RundaNr");
                DataSet rondanalysDS = DatabasAccess.RunSql(sql.ToString());
                rondanalysDS.Tables[0].TableName = "Rondanalys";
                return rondanalysDS;
            }
            catch (HookerException hex)
            {
                throw hex;
            }
            finally
            {
                if (DatabasAccess != null)
                {
                    DatabasAccess.Dispose();
                }
            }
        }
 
    }
}
