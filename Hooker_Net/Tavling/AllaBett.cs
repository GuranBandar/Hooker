using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker.Gemensam;
using Hooker_GUI.Kontroller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Hooker_GUI
{
    /// <summary>
    /// Fönsterklass för alla bett
    /// </summary>
    public partial class AllaBett : FormBas
    {
        #region Egenskapeer
        /// <summary>
        /// Objekt för Tävling
        /// </summary>
        public Tavling Tavling { get; set; }
        #endregion

        /// <summary>
        /// Defaultkonstruktor
        /// </summary>
        public AllaBett()
        {
            InitializeComponent(); //C:\aSynkfolder\CloudStation\aGit\Hooker\Hooker_Net\Tavling\AllaBett.cs
        }
        #region Publika metoder
        /// <summary>
        /// Visar Alla bett
        /// </summary>
        public void VisaAllaBett()
        {
            Bana bana = null;
            BanaAktivitet banaAktivitet = new BanaAktivitet();
            GolfklubbAktivitet golfklubbAktivitet = new GolfklubbAktivitet();
            dtpStartdatum.Text = ("STD").Formatera(DateTime.Parse(Tavling.StartDatum.ToShortDateString()));
            txtTavlingNamn.Text = Tavling.Namn;

            if (Tavling.FleraBanor == "0")
            {
                lblBana.Visible = true;
                lblGolfklubb.Visible = true;
                TavlingRond tavlingRond = Tavling.TavlingRond.Single(p => p.RondNr == 1);
                bana = banaAktivitet.HämtaBana(Tavling.TavlingRond[0].BanaNr);

                if (bana != null)
                {
                    Golfklubb golfklubb = golfklubbAktivitet.HämtaGolfklubb(bana.GolfklubbNr);
                    txtGolfklubb.Text = golfklubb.GolfklubbNamn;
                    txtBana.Text = bana.BanaNamn;
                }
            }
            else
            {
                lblBana.Visible = false;
                lblGolfklubb.Visible = false;
                txtGolfklubb.Visible = false;
                txtBana.Visible = false;
            }

            FyllListan();
        }
        #endregion

        #region Privata metoder
        /// <summary>
        ///     Alla texter hämtas och knapparna initieras
        /// </summary>
        private void InitieraTexter()
        {
            this.Text = Översätt("Text", this.Text);

            foreach (System.Windows.Forms.Control cc in this.Controls)
            {
                if (cc.Controls.Count == 0)
                {
                    if (cc.Name.StartsWith("lbl") | cc.Name.StartsWith("gbx") | cc.Name.StartsWith("btn"))
                    {
                        cc.Text = Översätt("Text", cc.Text);
                    }
                }
                else
                {
                    if (cc.Name.StartsWith("gbx"))
                    {
                        cc.Text = Översätt("Text", cc.Text);
                    }
                    for (int i = 0; i < cc.Controls.Count; i++)
                    {
                        if (cc.Controls[i].Name.StartsWith("lbl"))
                        {
                            cc.Controls[i].Text = Översätt("Text", cc.Controls[i].Text);
                        }
                    }
                }
            }

            for (int i = 0; i < dgwAllaBett.Columns.Count; i++)
            {
                dgwAllaBett.Columns[i].HeaderText = Översätt("Text", dgwAllaBett.Columns[i].HeaderText);
            }

            knappkontroller1.btnKnapp0.Visible = false;
            knappkontroller1.btnKnapp1.Visible = false;
            knappkontroller1.btnKnapp2.Visible = false;
            knappkontroller1.btnKnapp3.Visible = false;
            knappkontroller1.btnKnapp4.Text = Översätt("Text", "Knapp_Avbryt");
        }

        /// <summary>
        /// Fyll listan med alla bett
        /// </summary>
        private void FyllListan()
        {
            TavlingRondResultatAktivitet tavlingRondResultatAktivitet = new TavlingRondResultatAktivitet();
            try
            {
                DataSet nassauDS = tavlingRondResultatAktivitet.HämtaNassau(Tavling.TavlingID);
                int totalen = 0;
                int totalenUt = 0;
                int totalenIn = 0;
                int totalenTot = 0;
                int totalenLong = 0;
                int totalenNear = 0;
                int totalenBuck = 0;

                if (nassauDS.Tables["Nassau"].Rows.Count == 0)
                {
                    return;
                }

                var deltagare = nassauDS.Tables["Nassau"].AsEnumerable()
                            .Select(row => new
                            {
                                spelarnamn = row.Field<string>("Spelarnamn"),
                                spelarID = row.Field<int>("SpelarID")
                            })
                            .Distinct();

                List<SpelareOchBett> spelarBett = new List<SpelareOchBett>(deltagare.Count());
                foreach (var spelare in deltagare.ToList())
                {
                    spelarBett.Add(new SpelareOchBett()
                    {
                        Spelarenamn = spelare.spelarnamn,
                        SpelarID = spelare.spelarID,
                        Frontnine = 0,
                        Backnine = 0,
                        Total = 0,
                        Longest = 0,
                        Nearest = 0,
                        Rank = 0,
                        Bucklan = 0
                    });
                }

                TavlingRond tavlingRond = new TavlingRond();
                List<TavlingRond> antalRundor = Tavling.TavlingRond.ToList();
                int antalSpelade = tavlingRond.AntalSpelade(antalRundor);

                if (antalSpelade > 0)
                {
                    this.ReggaAllaBett(spelarBett, nassauDS, antalSpelade);
                    this.KollaBucklan(spelarBett);
                }

                int i = 0;
                foreach (SpelareOchBett spelare in spelarBett)
                {
                    dgwAllaBett.Rows.Add();
                    dgwAllaBett.Rows[i].Cells["Spelare"].Value = spelare.Spelarenamn;
                    dgwAllaBett.Rows[i].Cells["Ut"].Value = ("DD2").Formatera(spelare.Frontnine);
                    dgwAllaBett.Rows[i].Cells["In"].Value = ("DD2").Formatera(spelare.Backnine);
                    dgwAllaBett.Rows[i].Cells["Totalt"].Value = ("DD2").Formatera(spelare.Total);
                    dgwAllaBett.Rows[i].Cells["Langst"].Value = ("D").Formatera(spelare.Longest);
                    dgwAllaBett.Rows[i].Cells["Narmast"].Value = ("D").Formatera(spelare.Nearest);
                    dgwAllaBett.Rows[i].Cells["Bucklan"].Value = ("D").Formatera(spelare.Bucklan);
                    dgwAllaBett.Rows[i].Cells["Summa"].Value = ("T").Formatera(spelare.Frontnine + spelare.Backnine + spelare.Total +
                        spelare.Longest + spelare.Nearest + spelare.Bucklan);
                    dgwAllaBett.Rows[i].Cells["Summa"].Style.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

                    totalenUt = totalenUt + (int)spelare.Frontnine;
                    totalenIn = totalenIn + (int)spelare.Backnine;
                    totalenTot = totalenTot + (int)spelare.Total;
                    totalenLong = totalenLong + (int)spelare.Longest;
                    totalenNear = totalenNear + (int)spelare.Nearest;
                    totalenBuck = totalenBuck + (int)spelare.Bucklan;
                    totalen = totalen + (int)(spelare.Frontnine + spelare.Backnine + spelare.Total +
                        spelare.Longest + spelare.Nearest + spelare.Bucklan);
                    i++;
                }

                //Och så har vi en Grand Total
                dgwAllaBett.Rows.Add();
                dgwAllaBett.Rows[i].Cells["Spelare"].Value = "Totalt";
                dgwAllaBett.Rows[i].Cells["Ut"].Value = ("DD2").Formatera(totalenUt);
                dgwAllaBett.Rows[i].Cells["In"].Value = ("DD2").Formatera(totalenIn);
                dgwAllaBett.Rows[i].Cells["Totalt"].Value = ("DD2").Formatera(totalenTot);
                dgwAllaBett.Rows[i].Cells["Langst"].Value = ("D").Formatera(totalenLong);
                dgwAllaBett.Rows[i].Cells["Narmast"].Value = ("D").Formatera(totalenNear);
                dgwAllaBett.Rows[i].Cells["Bucklan"].Value = ("D").Formatera(totalenBuck);
                dgwAllaBett.Rows[i].Cells["Summa"].Value = ("T").Formatera(totalen);
                dgwAllaBett.Rows[i].Cells["Summa"].Style.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spelarBett"></param>
        /// <param name="nassauDS"></param>
        private void ReggaAllaBett(List<SpelareOchBett> spelarBett, DataSet nassauDS, int antalSpelade)
        {
            int antalSomSkaDela = 0;
            decimal belopp = 0;
            int beloppLN = 0;
            decimal beloppAttDela = Tavling.NassauBett;


            for (int i = 1; i < antalSpelade + 1; i++)
            {
                // Regga alla resultat ut 
                var RondresultatUt = (from resultatUt in nassauDS.Tables["Nassau"].AsEnumerable()
                                      where resultatUt.Field<int>("RondNr") == i
                                      orderby resultatUt["RondresultatUt"] descending
                                      select resultatUt);

                List<string> listSpelareUt = new List<string>();
                string längst = string.Empty;
                string närmast = string.Empty;
                int resUt = 0;
                int j = 0;
                foreach (var resultat in RondresultatUt.ToList())
                {
                    if (j == 0)
                    {
                        resUt = Convert.ToInt32(resultat["RondresultatUt"]);
                        listSpelareUt.Add(resultat["Spelarnamn"].ToString());
                        längst = resultat["Langst"].ToString();
                        närmast = resultat["Narmast"].ToString();
                        j++;
                    }
                    else if (resUt == Convert.ToInt32(resultat["RondresultatUt"]))
                    {
                        listSpelareUt.Add(resultat["Spelarnamn"].ToString());
                    }
                }

                beloppLN = Tavling.NassauBett * Tavling.TavlingDeltagare.Count();
                //Kan ju vara så att ingen lyckades träffa

                if (längst != string.Empty)
                {
                    SpelareOchBett spelare = spelarBett.Find(x => x.Spelarenamn == längst);
                    spelare.Longest = spelare.Longest + beloppLN;
                }

                if (närmast != string.Empty)
                {
                    SpelareOchBett spelare = spelarBett.Find(x => x.Spelarenamn == närmast);
                    spelare.Nearest = spelare.Nearest + beloppLN;
                }

                //Räkna nu hur många som ska dela på bettet
                antalSomSkaDela = listSpelareUt.Count();
                belopp = (beloppAttDela / antalSomSkaDela) * Tavling.TavlingDeltagare.Count();

                //Uppdatera nu Spelare och Bett med belopp
                for (int a = 0; a < antalSomSkaDela; a++)
                {
                    SpelareOchBett spelare = spelarBett.Find(x => x.Spelarenamn == listSpelareUt[a]);
                    spelare.Frontnine = spelare.Frontnine + belopp;
                }
            }

            for (int i = 1; i < antalSpelade + 1; i++)
            {
                // Regga alla resultat in 
                var RondresultatIn = (from resultatIn in nassauDS.Tables["Nassau"].AsEnumerable()
                                      where resultatIn.Field<int>("RondNr") == i
                                      orderby resultatIn["RondresultatIn"] descending
                                      select resultatIn);

                List<string> listSpelareIn = new List<string>();
                int resIn = 0;
                int j = 0;
                foreach (var resultat in RondresultatIn.ToList())
                {
                    if (j == 0)
                    {
                        resIn = Convert.ToInt32(resultat["RondresultatIn"]);
                        listSpelareIn.Add(resultat["Spelarnamn"].ToString());
                        j++;
                    }
                    else if (resIn == Convert.ToInt32(resultat["RondresultatIn"]))
                    {
                        listSpelareIn.Add(resultat["Spelarnamn"].ToString());
                    }
                }

                //Räkna nu hur många som ska dela på bettet
                antalSomSkaDela = listSpelareIn.Count();
                belopp = (beloppAttDela / antalSomSkaDela) * Tavling.TavlingDeltagare.Count();

                //Uppdatera nu Spelare och Bett med belopp
                for (int a = 0; a < antalSomSkaDela; a++)
                {
                    SpelareOchBett spelare = spelarBett.Find(x => x.Spelarenamn == listSpelareIn[a]);
                    spelare.Backnine = spelare.Backnine + belopp;
                }
            }

            for (int i = 1; i < antalSpelade + 1; i++)
            {
                // Regga alla resultat Totalt 
                var RondresultatTotalt = (from resultatTotalt in nassauDS.Tables["Nassau"].AsEnumerable()
                                          where resultatTotalt.Field<int>("RondNr") == i
                                          orderby resultatTotalt["RondresultatTot"] descending
                                          select resultatTotalt);

                List<string> listSpelareTotalt = new List<string>();
                int resTotalt = 0;
                int j = 0;
                foreach (var resultat in RondresultatTotalt.ToList())
                {
                    if (j == 0)
                    {
                        resTotalt = Convert.ToInt32(resultat["RondresultatTot"]);
                        listSpelareTotalt.Add(resultat["Spelarnamn"].ToString());
                        j++;
                    }
                    else if (resTotalt == Convert.ToInt32(resultat["RondresultatTot"]))
                    {
                        listSpelareTotalt.Add(resultat["Spelarnamn"].ToString());
                    }
                }

                //Räkna nu hur många som ska dela på bettet
                antalSomSkaDela = listSpelareTotalt.Count();
                belopp = (beloppAttDela / antalSomSkaDela) * Tavling.TavlingDeltagare.Count();

                //Uppdatera nu Spelare och Bett med belopp
                for (int a = 0; a < antalSomSkaDela; a++)
                {
                    SpelareOchBett spelare = spelarBett.Find(x => x.Spelarenamn == listSpelareTotalt[a]);
                    spelare.Total = spelare.Total + belopp;
                }
            }
        }

        /// <summary>
        /// Kolla vilka som ska ha pengar när det gäller Bucklan
        /// </summary>
        /// <param name="spelarBett"></param>
        private void KollaBucklan(List<SpelareOchBett> spelarBett)
        {
            TavlingRondResultatAktivitet tavlingRondResultatAktivitet = new TavlingRondResultatAktivitet();
            List<Ranking> ranking = tavlingRondResultatAktivitet.HämtaTrofen(Tavling);
            int i = 0;
            int rank = 0;
            int platssiffra = 0;
            int antalSomSkaDela = 0;
            int[] bucklanPris;
            SpelareOchBett spelare = null;

            if (ranking != null)
            {
                foreach (Ranking rankinglista in ranking.OrderBy(x => x.Placeringssiffra - x.SämstaPlacering))
                {
                    spelare = spelarBett.Find(x => x.SpelarID == rankinglista.SpelarID);
                    if (platssiffra < rankinglista.Placeringssiffra - rankinglista.SämstaPlacering)
                    {
                        rank++;
                        spelare.Rank = i + 1;
                    }
                    else
                    {
                        spelare.Rank = rank;
                    }
                    platssiffra = rankinglista.Placeringssiffra - rankinglista.SämstaPlacering;
                    i++;
                }
            }

            //Kör lite fulkod här då det är lite svårt att få till en bra formel
            //Hur många ska få pris, kan vara delad plats
            switch (Tavling.TavlingDeltagare.Count())
            {
                case 6:
                    antalSomSkaDela = spelarBett.Count(x => x.Rank < 3);
                    break;
                default:
                    antalSomSkaDela = spelarBett.Count(x => x.Rank < 4);
                    break;
            }

            bucklanPris = new int[antalSomSkaDela];

            switch (Tavling.TavlingDeltagare.Count())
            {
                case 6:
                    bucklanPris[0] = 400;
                    bucklanPris[1] = 200;
                    break;
                case 7:
                    bucklanPris[0] = 400;
                    bucklanPris[1] = 200;
                    bucklanPris[2] = 100;
                    break;
                case 8:
                    bucklanPris[0] = 500;
                    bucklanPris[1] = 200;
                    bucklanPris[2] = 100;
                    break;
                case 9:
                    bucklanPris[0] = 500;
                    bucklanPris[1] = 300;
                    bucklanPris[2] = 100;
                    break;
                default:
                    break;
            }

            int pris;
            int ant = 0;

            //Fördela nu priserna
            for (int r = 0; r < antalSomSkaDela; r++)
            {
                List<string> spelareSomSkaHaPris = (from s in spelarBett
                                                    where s.Rank == r + 1
                                                    orderby s.Rank
                                                    select s.Spelarenamn).ToList();
                if (spelareSomSkaHaPris.Count == 0)
                {
                    //Alla som ska har fått pris
                    return;
                }

                pris = 0;

                //Hur många ska dela på priset?
                ant += spelarBett.Where(x => x.Rank == r + 1).Count();

                //Vilken placering är det nu?
                int placering = (from s in spelarBett
                                 where s.Rank == r + 1
                                 select s.Rank).FirstOrDefault();

                //Vad blir prissumman för placeringen
                for (int p = 0; p < ant; p++)
                {
                    pris += bucklanPris[p];
                    bucklanPris[p] = 0;
                }

                for (int s = 0; s < spelareSomSkaHaPris.Count; s++)
                {
                    spelare = spelarBett.Find(x => x.Spelarenamn == spelareSomSkaHaPris[s]);
                    spelare.Bucklan = pris / spelarBett.Where(x => x.Rank == r + 1).Count();
                }
            }
        }

        private void AllaBett_Load(object sender, EventArgs e)
        {
            InitieraTexter();
        }

        private class SpelareOchBett
        {
            public string Spelarenamn { get; set; }
            public int SpelarID { get; set; }
            public decimal Frontnine { get; set; }
            public decimal Backnine { get; set; }
            public decimal Total { get; set; }
            public int Longest { get; set; }
            public int Nearest { get; set; }
            public int Rank { get; set; }
            public int Bucklan { get; set; }
        }
    }
}
