using Hooker.Affärslager;
using Hooker.Affärsobjekt;
using Hooker_GUI.Kontroller;
using System;
using System.Collections.Generic;

namespace Hooker_GUI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SystemvariablerInfo : FormBas
    {
        public bool NySystemvariabel { get; set; }

        /// <summary>
        /// Objekt för Systemvariabler
        /// </summary>
        public Systemvariabler Systemvariabler { get; set; }

        public List<Cursors> Cursors { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SystemvariablerInfo()
        {
            FormsLaddar = true;
            InitializeComponent();
            this.Hämta();
            FyllCursorCombo();
        }

        /// <summary>
        /// Initera ett Systemvariabelobjekt för varje gång klassen exekveras, infon kan ju vara uppdaterad
        /// </summary>
        public Systemvariabler InitieraSystemvariabler()
        {
            try
            {
                //Finns en Systemvariabel, läs nu aktuell systemvariabel för att uppdatera objektet 
                //if (Systemvariabel!= null)
                //{
                //Systemvariabler systemvariabler = Systemvariabel;
                SystemvariablerAktivitet systemvariablerAktivitet = new SystemvariablerAktivitet();
                Systemvariabler systemvariabel = systemvariablerAktivitet.Hämta();
                if (systemvariabel != null)
                {
                    Systemvariabel.Applikationsnamn = systemvariabel.Applikationsnamn;
                    Systemvariabel.Epostadress = systemvariabel.Epostadress;
                    Systemvariabel.MailFrom = systemvariabel.MailFrom;
                    Systemvariabel.MailPassword = systemvariabel.MailPassword;
                    Systemvariabel.MobilUtvecklare = systemvariabel.MobilUtvecklare;
                    Systemvariabel.Utvecklare = systemvariabel.Utvecklare;
                    Systemvariabel.Verktyg = systemvariabel.Verktyg;
                    Systemvariabel.Version = systemvariabel.Version;
                    Systemvariabel.WriteToLog = systemvariabel.WriteToLog;
                    Systemvariabel.WaitCursorImageID = systemvariabel.WaitCursorImageID;
                    Systemvariabel.SmtpHost = systemvariabel.SmtpHost;
                    Systemvariabel.Port = systemvariabel.Port;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Systemvariabler;
        }


        /// <summary>
        /// 
        /// </summary>
        private void Hämta()
        {
            SystemvariablerAktivitet systemvariablerAktivitet = new SystemvariablerAktivitet();
            Systemvariabler = systemvariablerAktivitet.Hämta();

            if (Systemvariabler == null)
            {
                NySystemvariabel = true;
            }
            else
            {
                txtApplikationsnamn.Text = Systemvariabler.Applikationsnamn;
                txtVersion.Text = Systemvariabler.Version;
                txtUtvecklare.Text = Systemvariabler.Utvecklare;
                txtVerktyg.Text = Systemvariabler.Verktyg;
                txtEpostadress.Text = Systemvariabler.Epostadress;
                txtMobilUtvecklare.Text = Systemvariabler.MobilUtvecklare;
                switch (Systemvariabler.WriteToLog)
                {
                    case "0":
                        cbxWriteToLog.Checked = false;
                        break;
                    case "1":
                        cbxWriteToLog.Checked = true;
                        break;
                }
                txtMailFrom.Text = Systemvariabler.MailFrom;
                txtMailPassword.Text = Systemvariabler.MailPassword;
                txtSmtpHost.Text = Systemvariabel.SmtpHost;
                txtPort.Text = Systemvariabel.Port;
            }
        }

        /// <summary>
        /// Fyll Systemvariablerobjektet från formuläret
        /// </summary>
        private void FyllObjektet()
        {
            Systemvariabler = new Systemvariabler();
            CursorsAktivitet cursorsAktivitet = new CursorsAktivitet();

            Systemvariabler.Applikationsnamn = txtApplikationsnamn.Text.ToString().Trim();
            Systemvariabler.Version = txtVersion.Text;
            Systemvariabler.Utvecklare = txtUtvecklare.Text;
            Systemvariabler.Verktyg = txtVerktyg.Text;
            Systemvariabler.Epostadress = txtEpostadress.Text;
            Systemvariabler.MobilUtvecklare = txtMobilUtvecklare.Text;
            Systemvariabler.WriteToLog = (cbxWriteToLog.Checked) ? "1" : "0";
            Systemvariabler.MailFrom = txtMailFrom.Text;
            Systemvariabler.MailPassword = txtMailPassword.Text;
            Systemvariabler.WaitCursorImageID = ((ComboBoxPar)cbxCursor.SelectedItem).Identifier.ToString();
            Systemvariabel.SmtpHost = txtSmtpHost.Text;
            Systemvariabel.Port = txtPort.Text;
        }

        /// <summary>
        /// Hämta aktuella Cursor ikoner.
        /// </summary>
        private void FyllCursorCombo()
        {
            List<Cursors> cursors = null;
            CursorsAktivitet cursorsAktivitet = new CursorsAktivitet();

            try
            {
                //Typ = 1 är Distriktkoder
                cursors = cursorsAktivitet.Hämta();

                if (cursors.Count > 0)
                {
                    cbxCursor.Items.Clear();
                    cbxCursor.Items.Add(new ComboBoxPar(0, "", ""));
                    foreach (Cursors rad in cursors)
                    {
                        cbxCursor.Items.Add(new ComboBoxPar(rad.CursorID, rad.Cursornamn.ToString(), rad));
                    }

                    if (Systemvariabler != null)
                    {
                        cbxCursor.SelectedItem = int.Parse(Systemvariabler.WaitCursorImageID.ToString());
                    }
                    cbxCursor.DisplayMember = "visa";
                }
            }
            catch (Exception ex)
            {
                HanteraUndantag(ex);
            }
        }
    }
}
