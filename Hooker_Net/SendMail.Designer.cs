namespace Hooker_GUI
{
    partial class SendMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendMail));
            this.txtMailToAddress = new System.Windows.Forms.TextBox();
            this.txtMailSubject = new System.Windows.Forms.TextBox();
            this.rtbMailBody = new System.Windows.Forms.RichTextBox();
            this.lblToAddress = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblBody = new System.Windows.Forms.Label();
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.gbxKnappkontroll = new System.Windows.Forms.GroupBox();
            this.gbxKnappkontroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMailToAddress
            // 
            this.txtMailToAddress.Location = new System.Drawing.Point(110, 16);
            this.txtMailToAddress.Name = "txtMailToAddress";
            this.txtMailToAddress.Size = new System.Drawing.Size(276, 20);
            this.txtMailToAddress.TabIndex = 1;
            // 
            // txtMailSubject
            // 
            this.txtMailSubject.Location = new System.Drawing.Point(110, 50);
            this.txtMailSubject.Name = "txtMailSubject";
            this.txtMailSubject.Size = new System.Drawing.Size(276, 20);
            this.txtMailSubject.TabIndex = 2;
            // 
            // rtbMailBody
            // 
            this.rtbMailBody.Location = new System.Drawing.Point(110, 86);
            this.rtbMailBody.Name = "rtbMailBody";
            this.rtbMailBody.Size = new System.Drawing.Size(276, 122);
            this.rtbMailBody.TabIndex = 3;
            this.rtbMailBody.Text = "";
            // 
            // lblToAddress
            // 
            this.lblToAddress.AutoSize = true;
            this.lblToAddress.Location = new System.Drawing.Point(12, 18);
            this.lblToAddress.Name = "lblToAddress";
            this.lblToAddress.Size = new System.Drawing.Size(110, 13);
            this.lblToAddress.TabIndex = 4;
            this.lblToAddress.Text = "Radrubrik_ToAddress";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(12, 53);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(95, 13);
            this.lblSubject.TabIndex = 5;
            this.lblSubject.Text = "Radrubrik_Subject";
            // 
            // lblBody
            // 
            this.lblBody.AutoSize = true;
            this.lblBody.Location = new System.Drawing.Point(12, 88);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(83, 13);
            this.lblBody.TabIndex = 6;
            this.lblBody.Text = "Radrubrik_Body";
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(-17, 12);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 7;
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // gbxKnappkontroll
            // 
            this.gbxKnappkontroll.Controls.Add(this.knappkontroller1);
            this.gbxKnappkontroll.Location = new System.Drawing.Point(-6, 214);
            this.gbxKnappkontroll.Name = "gbxKnappkontroll";
            this.gbxKnappkontroll.Size = new System.Drawing.Size(406, 51);
            this.gbxKnappkontroll.TabIndex = 8;
            this.gbxKnappkontroll.TabStop = false;
            this.gbxKnappkontroll.Text = "Text_Blank";
            // 
            // SendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 261);
            this.Controls.Add(this.gbxKnappkontroll);
            this.Controls.Add(this.lblBody);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblToAddress);
            this.Controls.Add(this.rtbMailBody);
            this.Controls.Add(this.txtMailSubject);
            this.Controls.Add(this.txtMailToAddress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SendMail";
            this.Text = "Text_SendMail";
            this.Load += new System.EventHandler(this.SendMail_Load);
            this.gbxKnappkontroll.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMailToAddress;
        private System.Windows.Forms.TextBox txtMailSubject;
        private System.Windows.Forms.RichTextBox rtbMailBody;
        private System.Windows.Forms.Label lblToAddress;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblBody;
        private Kontroller.Knappkontroller knappkontroller1;
        private System.Windows.Forms.GroupBox gbxKnappkontroll;
    }
}