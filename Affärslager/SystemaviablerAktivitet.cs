using Hooker.Aff�rsobjekt;
using Hooker.Datalager;
using Hooker.Dataset;
using System;

namespace Hooker.Aff�rslager
{
    /// <summary>
    /// Klass f�r Systemvariabler
    /// 
    /// Inneh�ller alla metoder f�r klassen Systemvariabler verksamhetslogik.
    /// </summary>
    public sealed class SystemvariablerAktivitet
    {
        /// <summary>
        /// H�mta fr�n databasen
        /// </summary>
        /// <returns>Systemvariabler objektet</returns>
        public Systemvariabler H�mta()
        {
            //kolla i databasen
            SystemvariablerData systemvariablerData;
            SystemvariablerDS systemvariablerDS = new SystemvariablerDS();
            Systemvariabler systemvariabler = null;
            try
            {
                systemvariablerData = new SystemvariablerData();
                systemvariablerDS = systemvariablerData.H�mta();
                if (systemvariablerDS.Systemvariabler.Count == 0)
                {
                    return systemvariabler;
                }
                else
                {
                    //L�sningen lyckades, skapa nu systemvaribelobjektet
                    systemvariabler = new Systemvariabler();
                    systemvariabler.Applikationsnamn = systemvariablerDS.Systemvariabler[0].Applikationsnamn.ToString();
                    systemvariabler.Version = systemvariablerDS.Systemvariabler[0].Version.ToString();
                    systemvariabler.Utvecklare = systemvariablerDS.Systemvariabler[0].Utvecklare.ToString();
                    systemvariabler.Verktyg = systemvariablerDS.Systemvariabler[0].Verktyg.ToString();
                    systemvariabler.Epostadress = systemvariablerDS.Systemvariabler[0].Epostadress.ToString();
                    systemvariabler.MobilUtvecklare = systemvariablerDS.Systemvariabler[0].MobilUtvecklare;
                    systemvariabler.WriteToLog = systemvariablerDS.Systemvariabler[0].WriteToLog.ToString();
                    systemvariabler.MailFrom = systemvariablerDS.Systemvariabler[0].MailFrom.ToString();
                    systemvariabler.MailPassword = systemvariablerDS.Systemvariabler[0].MailPassword.ToString();
                    systemvariabler.WaitCursorImageID = systemvariablerDS.Systemvariabler[0].WaitCursorImageID.ToString();
                    systemvariabler.SmtpHost = systemvariablerDS.Systemvariabler[0].SmtpHost.ToString();
                    systemvariabler.Port = systemvariablerDS.Systemvariabler[0].Port.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return systemvariabler;

        }

        /// <summary>
        /// Sparar alla f�r�ndringar i Systemvariabler i databasen 
        /// </summary>
        /// <param name="anvandare">Aktuell anv�ndare</param>
        /// <param name="nySpelare">Ny spelare, true or false</param>
        /// <param name="felID">Felmeddelande i Ordlistan som ska visas</param>
        /// <param name="feltext">Ev kompletterande felmeddelande som returneras</param>
        public void Spara(Systemvariabler systemvariabler, bool nySystemvariabel, ref string felID, ref string feltext)
        {
            SystemvariablerData systemvariablerData = new SystemvariablerData();
            if (nySystemvariabel)
            {
                systemvariablerData.SparaNySystemvariabel(systemvariabler, ref felID, ref feltext);
            }
            else
            {
                systemvariablerData.SparaSystemvariabel(systemvariabler, ref felID, ref feltext);
            }
        }
    }
}