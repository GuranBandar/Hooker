namespace Hooker_GUI
{
    partial class KoderInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KoderInfo));
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.gbxKnappkontoll = new System.Windows.Forms.GroupBox();
            this.gbxKoder = new System.Windows.Forms.GroupBox();
            this.txtArgument = new System.Windows.Forms.TextBox();
            this.cboKodtyper = new System.Windows.Forms.ComboBox();
            this.lblArgument = new System.Windows.Forms.Label();
            this.lblTyp = new System.Windows.Forms.Label();
            this.lblVarde = new System.Windows.Forms.Label();
            this.txtVarde = new System.Windows.Forms.TextBox();
            this.lblMinvarde = new System.Windows.Forms.Label();
            this.txtMinvarde = new System.Windows.Forms.TextBox();
            this.txtMaxvarde = new System.Windows.Forms.TextBox();
            this.lblMaxvarde = new System.Windows.Forms.Label();
            this.gbxKnappkontoll.SuspendLayout();
            this.gbxKoder.SuspendLayout();
            this.SuspendLayout();
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(113, 7);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 6;
            this.knappkontroller1.OnKnapp1Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp1ClickEventHandler(this.knappkontroller1_OnKnapp1Click);
            this.knappkontroller1.OnKnapp2Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp2ClickEventHandler(this.knappkontroller1_OnKnapp2Click);
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.knappkontroller1_OnKnapp3Click);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // gbxKnappkontoll
            // 
            this.gbxKnappkontoll.Controls.Add(this.knappkontroller1);
            this.gbxKnappkontoll.Location = new System.Drawing.Point(-8, 226);
            this.gbxKnappkontoll.Name = "gbxKnappkontoll";
            this.gbxKnappkontoll.Size = new System.Drawing.Size(541, 53);
            this.gbxKnappkontoll.TabIndex = 5;
            this.gbxKnappkontoll.TabStop = false;
            // 
            // gbxKoder
            // 
            this.gbxKoder.Controls.Add(this.txtArgument);
            this.gbxKoder.Controls.Add(this.cboKodtyper);
            this.gbxKoder.Controls.Add(this.lblArgument);
            this.gbxKoder.Controls.Add(this.lblTyp);
            this.gbxKoder.Location = new System.Drawing.Point(13, 13);
            this.gbxKoder.Name = "gbxKoder";
            this.gbxKoder.Size = new System.Drawing.Size(420, 78);
            this.gbxKoder.TabIndex = 0;
            this.gbxKoder.TabStop = false;
            this.gbxKoder.Text = "Text_Koder";
            // 
            // txtArgument
            // 
            this.txtArgument.Location = new System.Drawing.Point(121, 47);
            this.txtArgument.Name = "txtArgument";
            this.txtArgument.Size = new System.Drawing.Size(293, 20);
            this.txtArgument.TabIndex = 1;
            // 
            // cboKodtyper
            // 
            this.cboKodtyper.Enabled = false;
            this.cboKodtyper.FormattingEnabled = true;
            this.cboKodtyper.Location = new System.Drawing.Point(121, 15);
            this.cboKodtyper.Name = "cboKodtyper";
            this.cboKodtyper.Size = new System.Drawing.Size(293, 21);
            this.cboKodtyper.TabIndex = 0;
            this.cboKodtyper.TabStop = false;
            // 
            // lblArgument
            // 
            this.lblArgument.AutoSize = true;
            this.lblArgument.Location = new System.Drawing.Point(11, 50);
            this.lblArgument.Name = "lblArgument";
            this.lblArgument.Size = new System.Drawing.Size(104, 13);
            this.lblArgument.TabIndex = 0;
            this.lblArgument.Text = "Radrubrik_Argument";
            // 
            // lblTyp
            // 
            this.lblTyp.AutoSize = true;
            this.lblTyp.Location = new System.Drawing.Point(11, 20);
            this.lblTyp.Name = "lblTyp";
            this.lblTyp.Size = new System.Drawing.Size(77, 13);
            this.lblTyp.TabIndex = 0;
            this.lblTyp.Text = "Radrubrik_Typ";
            // 
            // lblVarde
            // 
            this.lblVarde.AutoSize = true;
            this.lblVarde.Location = new System.Drawing.Point(27, 113);
            this.lblVarde.Name = "lblVarde";
            this.lblVarde.Size = new System.Drawing.Size(87, 13);
            this.lblVarde.TabIndex = 0;
            this.lblVarde.Text = "Radrubrik_Värde";
            // 
            // txtVarde
            // 
            this.txtVarde.Location = new System.Drawing.Point(134, 110);
            this.txtVarde.Name = "txtVarde";
            this.txtVarde.Size = new System.Drawing.Size(293, 20);
            this.txtVarde.TabIndex = 2;
            // 
            // lblMinvarde
            // 
            this.lblMinvarde.AutoSize = true;
            this.lblMinvarde.Location = new System.Drawing.Point(30, 157);
            this.lblMinvarde.Name = "lblMinvarde";
            this.lblMinvarde.Size = new System.Drawing.Size(103, 13);
            this.lblMinvarde.TabIndex = 0;
            this.lblMinvarde.Text = "Radrubrik_Minvärde";
            // 
            // txtMinvarde
            // 
            this.txtMinvarde.Location = new System.Drawing.Point(134, 153);
            this.txtMinvarde.Name = "txtMinvarde";
            this.txtMinvarde.Size = new System.Drawing.Size(100, 20);
            this.txtMinvarde.TabIndex = 3;
            // 
            // txtMaxvarde
            // 
            this.txtMaxvarde.Location = new System.Drawing.Point(327, 153);
            this.txtMaxvarde.Name = "txtMaxvarde";
            this.txtMaxvarde.Size = new System.Drawing.Size(100, 20);
            this.txtMaxvarde.TabIndex = 4;
            // 
            // lblMaxvarde
            // 
            this.lblMaxvarde.AutoSize = true;
            this.lblMaxvarde.Location = new System.Drawing.Point(244, 157);
            this.lblMaxvarde.Name = "lblMaxvarde";
            this.lblMaxvarde.Size = new System.Drawing.Size(106, 13);
            this.lblMaxvarde.TabIndex = 0;
            this.lblMaxvarde.Text = "Radrubrik_Maxvärde";
            // 
            // KoderInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 264);
            this.Controls.Add(this.txtMaxvarde);
            this.Controls.Add(this.lblMaxvarde);
            this.Controls.Add(this.txtMinvarde);
            this.Controls.Add(this.lblMinvarde);
            this.Controls.Add(this.txtVarde);
            this.Controls.Add(this.lblVarde);
            this.Controls.Add(this.gbxKoder);
            this.Controls.Add(this.gbxKnappkontoll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KoderInfo";
            this.Text = "Titel_Koder";
            this.Load += new System.EventHandler(this.Koder_Load);
            this.gbxKnappkontoll.ResumeLayout(false);
            this.gbxKoder.ResumeLayout(false);
            this.gbxKoder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hooker_GUI.Kontroller.Knappkontroller knappkontroller1;
        private System.Windows.Forms.GroupBox gbxKnappkontoll;
        private System.Windows.Forms.GroupBox gbxKoder;
        private System.Windows.Forms.TextBox txtArgument;
        private System.Windows.Forms.ComboBox cboKodtyper;
        private System.Windows.Forms.Label lblArgument;
        private System.Windows.Forms.Label lblTyp;
        private System.Windows.Forms.Label lblVarde;
        private System.Windows.Forms.TextBox txtVarde;
        private System.Windows.Forms.Label lblMinvarde;
        private System.Windows.Forms.TextBox txtMinvarde;
        private System.Windows.Forms.TextBox txtMaxvarde;
        private System.Windows.Forms.Label lblMaxvarde;
    }
}