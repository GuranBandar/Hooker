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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(219, 10);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 39);
            this.knappkontroller1.TabIndex = 12;
            this.knappkontroller1.OnKnapp1Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp1ClickEventHandler(this.knappkontroller1_OnKnapp1Click);
            this.knappkontroller1.OnKnapp2Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp2ClickEventHandler(this.knappkontroller1_OnKnapp2Click);
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.knappkontroller1_OnKnapp3Click);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.knappkontroller1);
            this.groupBox1.Location = new System.Drawing.Point(-6, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 78);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // lblApplikationsnamn
            // 
            this.lblApplikationsnamn.AutoSize = true;
            this.lblApplikationsnamn.Location = new System.Drawing.Point(22, 13);
            this.lblApplikationsnamn.Name = "lblApplikationsnamn";
            this.lblApplikationsnamn.Size = new System.Drawing.Size(142, 13);
            this.lblApplikationsnamn.TabIndex = 100;
            this.lblApplikationsnamn.Text = "Radrubrik_Applikationsnamn";
            // 
            // txtApplikationsnamn
            // 
            this.txtApplikationsnamn.Location = new System.Drawing.Point(130, 10);
            this.txtApplikationsnamn.Name = "txtApplikationsnamn";
            this.txtApplikationsnamn.Size = new System.Drawing.Size(192, 20);
            this.txtApplikationsnamn.TabIndex = 1;
            // 
            // txtUtvecklare
            // 
            this.txtUtvecklare.Location = new System.Drawing.Point(130, 46);
            this.txtUtvecklare.Name = "txtUtvecklare";
            this.txtUtvecklare.Size = new System.Drawing.Size(192, 20);
            this.txtUtvecklare.TabIndex = 3;
            // 
            // lblUtvecklare
            // 
            this.lblUtvecklare.AutoSize = true;
            this.lblUtvecklare.Location = new System.Drawing.Point(22, 50);
            this.lblUtvecklare.Name = "lblUtvecklare";
            this.lblUtvecklare.Size = new System.Drawing.Size(111, 13);
            this.lblUtvecklare.TabIndex = 100;
            this.lblUtvecklare.Text = "Radrubrik_Utvecklare";
            // 
            // txtVerktyg
            // 
            this.txtVerktyg.Location = new System.Drawing.Point(481, 46);
            this.txtVerktyg.Name = "txtVerktyg";
            this.txtVerktyg.Size = new System.Drawing.Size(145, 20);
            this.txtVerktyg.TabIndex = 4;
            // 
            // lblVerktyg
            // 
            this.lblVerktyg.AutoSize = true;
            this.lblVerktyg.Location = new System.Drawing.Point(332, 50);
            this.lblVerktyg.Name = "lblVerktyg";
            this.lblVerktyg.Size = new System.Drawing.Size(95, 13);
            this.lblVerktyg.TabIndex = 100;
            this.lblVerktyg.Text = "Radrubrik_Verktyg";
            // 
            // txtEpostadress
            // 
            this.txtEpostadress.Location = new System.Drawing.Point(130, 84);
            this.txtEpostadress.Name = "txtEpostadress";
            this.txtEpostadress.Size = new System.Drawing.Size(192, 20);
            this.txtEpostadress.TabIndex = 5;
            // 
            // lblEpostadress
            // 
            this.lblEpostadress.AutoSize = true;
            this.lblEpostadress.Location = new System.Drawing.Point(22, 87);
            this.lblEpostadress.Name = "lblEpostadress";
            this.lblEpostadress.Size = new System.Drawing.Size(86, 13);
            this.lblEpostadress.TabIndex = 100;
            this.lblEpostadress.Text = "Radrubrik_Epost";
            // 
            // txtMobilUtvecklare
            // 
            this.txtMobilUtvecklare.Location = new System.Drawing.Point(481, 84);
            this.txtMobilUtvecklare.Name = "txtMobilUtvecklare";
            this.txtMobilUtvecklare.Size = new System.Drawing.Size(145, 20);
            this.txtMobilUtvecklare.TabIndex = 6;
            // 
            // lblMobilUtvecklare
            // 
            this.lblMobilUtvecklare.AutoSize = true;
            this.lblMobilUtvecklare.Location = new System.Drawing.Point(332, 87);
            this.lblMobilUtvecklare.Name = "lblMobilUtvecklare";
            this.lblMobilUtvecklare.Size = new System.Drawing.Size(136, 13);
            this.lblMobilUtvecklare.TabIndex = 100;
            this.lblMobilUtvecklare.Text = "Radrubrik_MobilUtvecklare";
            // 
            // lblWriteToLog
            // 
            this.lblWriteToLog.AutoSize = true;
            this.lblWriteToLog.Location = new System.Drawing.Point(22, 124);
            this.lblWriteToLog.Name = "lblWriteToLog";
            this.lblWriteToLog.Size = new System.Drawing.Size(115, 13);
            this.lblWriteToLog.TabIndex = 100;
            this.lblWriteToLog.Text = "Radrubrik_WriteToLog";
            // 
            // txtMailFrom
            // 
            this.txtMailFrom.Location = new System.Drawing.Point(130, 157);
            this.txtMailFrom.Name = "txtMailFrom";
            this.txtMailFrom.Size = new System.Drawing.Size(186, 20);
            this.txtMailFrom.TabIndex = 9;
            // 
            // lblMailFrom
            // 
            this.lblMailFrom.AutoSize = true;
            this.lblMailFrom.Location = new System.Drawing.Point(22, 161);
            this.lblMailFrom.Name = "lblMailFrom";
            this.lblMailFrom.Size = new System.Drawing.Size(101, 13);
            this.lblMailFrom.TabIndex = 16;
            this.lblMailFrom.Text = "Radrubrik_MailFrom";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(481, 10);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(145, 20);
            this.txtVersion.TabIndex = 2;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(332, 13);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(94, 13);
            this.lblVersion.TabIndex = 18;
            this.lblVersion.Text = "Radrubrik_Version";
            // 
            // cbxWriteToLog
            // 
            this.cbxWriteToLog.AutoSize = true;
            this.cbxWriteToLog.Location = new System.Drawing.Point(130, 123);
            this.cbxWriteToLog.Name = "cbxWriteToLog";
            this.cbxWriteToLog.Size = new System.Drawing.Size(15, 14);
            this.cbxWriteToLog.TabIndex = 7;
            this.cbxWriteToLog.UseVisualStyleBackColor = true;
            // 
            // txtMailPassword
            // 
            this.txtMailPassword.Location = new System.Drawing.Point(481, 157);
            this.txtMailPassword.Name = "txtMailPassword";
            this.txtMailPassword.Size = new System.Drawing.Size(145, 20);
            this.txtMailPassword.TabIndex = 10;
            // 
            // lblMailPassword
            // 
            this.lblMailPassword.AutoSize = true;
            this.lblMailPassword.Location = new System.Drawing.Point(332, 161);
            this.lblMailPassword.Name = "lblMailPassword";
            this.lblMailPassword.Size = new System.Drawing.Size(103, 13);
            this.lblMailPassword.TabIndex = 21;
            this.lblMailPassword.Text = "Radrubrik_Losenord";
            // 
            // lblWaitCursorFilePath
            // 
            this.lblWaitCursorFilePath.AutoSize = true;
            this.lblWaitCursorFilePath.Location = new System.Drawing.Point(332, 123);
            this.lblWaitCursorFilePath.Name = "lblWaitCursorFilePath";
            this.lblWaitCursorFilePath.Size = new System.Drawing.Size(149, 13);
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
            this.cbxCursor.Location = new System.Drawing.Point(481, 120);
            this.cbxCursor.Name = "cbxCursor";
            this.cbxCursor.Size = new System.Drawing.Size(145, 21);
            this.cbxCursor.TabIndex = 8;
            // 
            // SystemvariablerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 241);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SystemvariablerInfo";
            this.Text = "Titel_SystemvariablerInfo";
            this.Load += new System.EventHandler(this.SystemvariablerInfo_Load);
            this.groupBox1.ResumeLayout(false);
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
    }
}