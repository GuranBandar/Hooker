namespace Hooker_GUI
{
    partial class SystemvariablerInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemvariablerInfo));
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblApplikationsnamn = new System.Windows.Forms.Label();
            this.txtApplikationsnamn = new System.Windows.Forms.TextBox();
            this.txtUtvecklare = new System.Windows.Forms.TextBox();
            this.lblUtvecklare = new System.Windows.Forms.Label();
            this.txtVerktyg = new System.Windows.Forms.TextBox();
            this.lblVerktyg = new System.Windows.Forms.Label();
            this.txtEpostadress = new System.Windows.Forms.TextBox();
            this.lblEpostadress = new System.Windows.Forms.Label();
            this.txtMobilUtvecklare = new System.Windows.Forms.TextBox();
            this.lblMobilUtvecklare = new System.Windows.Forms.Label();
            this.lblWriteToLog = new System.Windows.Forms.Label();
            this.txtMailFrom = new System.Windows.Forms.TextBox();
            this.lblMailFrom = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.cbxWriteToLog = new System.Windows.Forms.CheckBox();
            this.txtMailPassword = new System.Windows.Forms.TextBox();
            this.lblMailPassword = new System.Windows.Forms.Label();
            this.lblWaitCursorFilePath = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbxCursor = new System.Windows.Forms.ComboBox();
            this.gbxMail = new System.Windows.Forms.GroupBox();
            this.lblSmtpHost = new System.Windows.Forms.Label();
            this.txtSmtpHost = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.gbxMail.SuspendLayout();
            this.SuspendLayout();
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(285, 10);
            this.knappkontroller1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(556, 48);
            this.knappkontroller1.TabIndex = 12;
            this.knappkontroller1.OnKnapp1Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp1ClickEventHandler(this.knappkontroller1_OnKnapp1Click);
            this.knappkontroller1.OnKnapp2Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp2ClickEventHandler(this.knappkontroller1_OnKnapp2Click);
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.knappkontroller1_OnKnapp3Click);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.knappkontroller1);
            this.groupBox1.Location = new System.Drawing.Point(-8, 283);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(873, 80);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // lblApplikationsnamn
            // 
            this.lblApplikationsnamn.AutoSize = true;
            this.lblApplikationsnamn.Location = new System.Drawing.Point(29, 16);
            this.lblApplikationsnamn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApplikationsnamn.Name = "lblApplikationsnamn";
            this.lblApplikationsnamn.Size = new System.Drawing.Size(189, 17);
            this.lblApplikationsnamn.TabIndex = 100;
            this.lblApplikationsnamn.Text = "Radrubrik_Applikationsnamn";
            // 
            // txtApplikationsnamn
            // 
            this.txtApplikationsnamn.Location = new System.Drawing.Point(173, 12);
            this.txtApplikationsnamn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtApplikationsnamn.Name = "txtApplikationsnamn";
            this.txtApplikationsnamn.Size = new System.Drawing.Size(255, 22);
            this.txtApplikationsnamn.TabIndex = 1;
            // 
            // txtUtvecklare
            // 
            this.txtUtvecklare.Location = new System.Drawing.Point(173, 57);
            this.txtUtvecklare.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUtvecklare.Name = "txtUtvecklare";
            this.txtUtvecklare.Size = new System.Drawing.Size(255, 22);
            this.txtUtvecklare.TabIndex = 3;
            // 
            // lblUtvecklare
            // 
            this.lblUtvecklare.AutoSize = true;
            this.lblUtvecklare.Location = new System.Drawing.Point(29, 62);
            this.lblUtvecklare.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUtvecklare.Name = "lblUtvecklare";
            this.lblUtvecklare.Size = new System.Drawing.Size(145, 17);
            this.lblUtvecklare.TabIndex = 100;
            this.lblUtvecklare.Text = "Radrubrik_Utvecklare";
            // 
            // txtVerktyg
            // 
            this.txtVerktyg.Location = new System.Drawing.Point(641, 57);
            this.txtVerktyg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVerktyg.Name = "txtVerktyg";
            this.txtVerktyg.Size = new System.Drawing.Size(192, 22);
            this.txtVerktyg.TabIndex = 4;
            // 
            // lblVerktyg
            // 
            this.lblVerktyg.AutoSize = true;
            this.lblVerktyg.Location = new System.Drawing.Point(443, 62);
            this.lblVerktyg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVerktyg.Name = "lblVerktyg";
            this.lblVerktyg.Size = new System.Drawing.Size(126, 17);
            this.lblVerktyg.TabIndex = 100;
            this.lblVerktyg.Text = "Radrubrik_Verktyg";
            // 
            // txtEpostadress
            // 
            this.txtEpostadress.Location = new System.Drawing.Point(173, 103);
            this.txtEpostadress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEpostadress.Name = "txtEpostadress";
            this.txtEpostadress.Size = new System.Drawing.Size(255, 22);
            this.txtEpostadress.TabIndex = 5;
            // 
            // lblEpostadress
            // 
            this.lblEpostadress.AutoSize = true;
            this.lblEpostadress.Location = new System.Drawing.Point(29, 107);
            this.lblEpostadress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEpostadress.Name = "lblEpostadress";
            this.lblEpostadress.Size = new System.Drawing.Size(114, 17);
            this.lblEpostadress.TabIndex = 100;
            this.lblEpostadress.Text = "Radrubrik_Epost";
            // 
            // txtMobilUtvecklare
            // 
            this.txtMobilUtvecklare.Location = new System.Drawing.Point(641, 103);
            this.txtMobilUtvecklare.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMobilUtvecklare.Name = "txtMobilUtvecklare";
            this.txtMobilUtvecklare.Size = new System.Drawing.Size(192, 22);
            this.txtMobilUtvecklare.TabIndex = 6;
            // 
            // lblMobilUtvecklare
            // 
            this.lblMobilUtvecklare.AutoSize = true;
            this.lblMobilUtvecklare.Location = new System.Drawing.Point(443, 107);
            this.lblMobilUtvecklare.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMobilUtvecklare.Name = "lblMobilUtvecklare";
            this.lblMobilUtvecklare.Size = new System.Drawing.Size(178, 17);
            this.lblMobilUtvecklare.TabIndex = 100;
            this.lblMobilUtvecklare.Text = "Radrubrik_MobilUtvecklare";
            // 
            // lblWriteToLog
            // 
            this.lblWriteToLog.AutoSize = true;
            this.lblWriteToLog.Location = new System.Drawing.Point(29, 153);
            this.lblWriteToLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWriteToLog.Name = "lblWriteToLog";
            this.lblWriteToLog.Size = new System.Drawing.Size(152, 17);
            this.lblWriteToLog.TabIndex = 100;
            this.lblWriteToLog.Text = "Radrubrik_WriteToLog";
            // 
            // txtMailFrom
            // 
            this.txtMailFrom.Location = new System.Drawing.Point(173, 213);
            this.txtMailFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMailFrom.Name = "txtMailFrom";
            this.txtMailFrom.Size = new System.Drawing.Size(247, 22);
            this.txtMailFrom.TabIndex = 9;
            // 
            // lblMailFrom
            // 
            this.lblMailFrom.AutoSize = true;
            this.lblMailFrom.Location = new System.Drawing.Point(30, 216);
            this.lblMailFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMailFrom.Name = "lblMailFrom";
            this.lblMailFrom.Size = new System.Drawing.Size(135, 17);
            this.lblMailFrom.TabIndex = 16;
            this.lblMailFrom.Text = "Radrubrik_MailFrom";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(641, 12);
            this.txtVersion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(192, 22);
            this.txtVersion.TabIndex = 2;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(443, 16);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(126, 17);
            this.lblVersion.TabIndex = 18;
            this.lblVersion.Text = "Radrubrik_Version";
            // 
            // cbxWriteToLog
            // 
            this.cbxWriteToLog.AutoSize = true;
            this.cbxWriteToLog.Location = new System.Drawing.Point(173, 151);
            this.cbxWriteToLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxWriteToLog.Name = "cbxWriteToLog";
            this.cbxWriteToLog.Size = new System.Drawing.Size(18, 17);
            this.cbxWriteToLog.TabIndex = 7;
            this.cbxWriteToLog.UseVisualStyleBackColor = true;
            // 
            // txtMailPassword
            // 
            this.txtMailPassword.Location = new System.Drawing.Point(641, 213);
            this.txtMailPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMailPassword.Name = "txtMailPassword";
            this.txtMailPassword.Size = new System.Drawing.Size(192, 22);
            this.txtMailPassword.TabIndex = 10;
            // 
            // lblMailPassword
            // 
            this.lblMailPassword.AutoSize = true;
            this.lblMailPassword.Location = new System.Drawing.Point(443, 217);
            this.lblMailPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMailPassword.Name = "lblMailPassword";
            this.lblMailPassword.Size = new System.Drawing.Size(138, 17);
            this.lblMailPassword.TabIndex = 21;
            this.lblMailPassword.Text = "Radrubrik_Losenord";
            // 
            // lblWaitCursorFilePath
            // 
            this.lblWaitCursorFilePath.AutoSize = true;
            this.lblWaitCursorFilePath.Location = new System.Drawing.Point(443, 151);
            this.lblWaitCursorFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWaitCursorFilePath.Name = "lblWaitCursorFilePath";
            this.lblWaitCursorFilePath.Size = new System.Drawing.Size(199, 17);
            this.lblWaitCursorFilePath.TabIndex = 23;
            this.lblWaitCursorFilePath.Text = "Radrubrik_WaitCursorFilePath";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cbxCursor
            // 
            this.cbxCursor.FormattingEnabled = true;
            this.cbxCursor.Location = new System.Drawing.Point(641, 148);
            this.cbxCursor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxCursor.Name = "cbxCursor";
            this.cbxCursor.Size = new System.Drawing.Size(192, 24);
            this.cbxCursor.TabIndex = 8;
            // 
            // gbxMail
            // 
            this.gbxMail.Controls.Add(this.txtPort);
            this.gbxMail.Controls.Add(this.lblPort);
            this.gbxMail.Controls.Add(this.txtSmtpHost);
            this.gbxMail.Controls.Add(this.lblSmtpHost);
            this.gbxMail.Location = new System.Drawing.Point(-8, 187);
            this.gbxMail.Name = "gbxMail";
            this.gbxMail.Size = new System.Drawing.Size(866, 99);
            this.gbxMail.TabIndex = 101;
            this.gbxMail.TabStop = false;
            this.gbxMail.Text = "Mail parametrar";
            // 
            // lblSmtpHost
            // 
            this.lblSmtpHost.AutoSize = true;
            this.lblSmtpHost.Location = new System.Drawing.Point(40, 69);
            this.lblSmtpHost.Name = "lblSmtpHost";
            this.lblSmtpHost.Size = new System.Drawing.Size(139, 17);
            this.lblSmtpHost.TabIndex = 0;
            this.lblSmtpHost.Text = "Radrubrik_SmtpHost";
            // 
            // txtSmtpHost
            // 
            this.txtSmtpHost.Location = new System.Drawing.Point(181, 67);
            this.txtSmtpHost.Name = "txtSmtpHost";
            this.txtSmtpHost.Size = new System.Drawing.Size(246, 22);
            this.txtSmtpHost.TabIndex = 1;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(451, 70);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(104, 17);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Radrubrik_Port";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(649, 67);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 22);
            this.txtPort.TabIndex = 3;
            // 
            // SystemvariablerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 354);
            this.Controls.Add(this.cbxCursor);
            this.Controls.Add(this.lblWaitCursorFilePath);
            this.Controls.Add(this.txtMailPassword);
            this.Controls.Add(this.lblMailPassword);
            this.Controls.Add(this.cbxWriteToLog);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.txtMailFrom);
            this.Controls.Add(this.lblMailFrom);
            this.Controls.Add(this.lblWriteToLog);
            this.Controls.Add(this.txtMobilUtvecklare);
            this.Controls.Add(this.lblMobilUtvecklare);
            this.Controls.Add(this.txtEpostadress);
            this.Controls.Add(this.lblEpostadress);
            this.Controls.Add(this.txtVerktyg);
            this.Controls.Add(this.lblVerktyg);
            this.Controls.Add(this.txtUtvecklare);
            this.Controls.Add(this.lblUtvecklare);
            this.Controls.Add(this.txtApplikationsnamn);
            this.Controls.Add(this.lblApplikationsnamn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxMail);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "SystemvariablerInfo";
            this.Text = "Titel_SystemvariablerInfo";
            this.Load += new System.EventHandler(this.SystemvariablerInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.gbxMail.ResumeLayout(false);
            this.gbxMail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Kontroller.Knappkontroller knappkontroller1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblApplikationsnamn;
        private System.Windows.Forms.TextBox txtApplikationsnamn;
        private System.Windows.Forms.TextBox txtUtvecklare;
        private System.Windows.Forms.Label lblUtvecklare;
        private System.Windows.Forms.TextBox txtVerktyg;
        private System.Windows.Forms.Label lblVerktyg;
        private System.Windows.Forms.TextBox txtEpostadress;
        private System.Windows.Forms.Label lblEpostadress;
        private System.Windows.Forms.TextBox txtMobilUtvecklare;
        private System.Windows.Forms.Label lblMobilUtvecklare;
        private System.Windows.Forms.Label lblWriteToLog;
        private System.Windows.Forms.TextBox txtMailFrom;
        private System.Windows.Forms.Label lblMailFrom;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.CheckBox cbxWriteToLog;
        private System.Windows.Forms.TextBox txtMailPassword;
        private System.Windows.Forms.Label lblMailPassword;
        private System.Windows.Forms.Label lblWaitCursorFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cbxCursor;
        private System.Windows.Forms.GroupBox gbxMail;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtSmtpHost;
        private System.Windows.Forms.Label lblSmtpHost;
    }
}