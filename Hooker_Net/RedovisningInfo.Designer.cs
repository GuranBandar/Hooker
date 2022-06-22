namespace Hooker_GUI
{
    partial class RedovisningInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedovisningInfo));
            this.txtRundaNr = new System.Windows.Forms.TextBox();
            this.lblRundanr = new System.Windows.Forms.Label();
            this.txtBelopp = new System.Windows.Forms.TextBox();
            this.lblBelopp = new System.Windows.Forms.Label();
            this.txtNotering = new System.Windows.Forms.TextBox();
            this.lblNotering = new System.Windows.Forms.Label();
            this.gbxRedovisning = new System.Windows.Forms.GroupBox();
            this.cboRedovisningtyper = new System.Windows.Forms.ComboBox();
            this.lblTyp = new System.Windows.Forms.Label();
            this.gbxKnappkontoll = new System.Windows.Forms.GroupBox();
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.cboSpelare = new System.Windows.Forms.ComboBox();
            this.lblSpelare = new System.Windows.Forms.Label();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.lblDatum = new System.Windows.Forms.Label();
            this.gbxRedovisning.SuspendLayout();
            this.gbxKnappkontoll.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRundaNr
            // 
            this.txtRundaNr.Enabled = false;
            this.txtRundaNr.Location = new System.Drawing.Point(306, 109);
            this.txtRundaNr.Name = "txtRundaNr";
            this.txtRundaNr.Size = new System.Drawing.Size(60, 20);
            this.txtRundaNr.TabIndex = 14;
            // 
            // lblRundanr
            // 
            this.lblRundanr.AutoSize = true;
            this.lblRundanr.Location = new System.Drawing.Point(229, 113);
            this.lblRundanr.Name = "lblRundanr";
            this.lblRundanr.Size = new System.Drawing.Size(100, 13);
            this.lblRundanr.TabIndex = 8;
            this.lblRundanr.Text = "Radrubrik_Rundanr";
            // 
            // txtBelopp
            // 
            this.txtBelopp.Location = new System.Drawing.Point(133, 109);
            this.txtBelopp.Name = "txtBelopp";
            this.txtBelopp.Size = new System.Drawing.Size(60, 20);
            this.txtBelopp.TabIndex = 13;
            // 
            // lblBelopp
            // 
            this.lblBelopp.AutoSize = true;
            this.lblBelopp.Location = new System.Drawing.Point(23, 113);
            this.lblBelopp.Name = "lblBelopp";
            this.lblBelopp.Size = new System.Drawing.Size(92, 13);
            this.lblBelopp.TabIndex = 7;
            this.lblBelopp.Text = "Radrubrik_Belopp";
            // 
            // txtNotering
            // 
            this.txtNotering.Location = new System.Drawing.Point(133, 149);
            this.txtNotering.Name = "txtNotering";
            this.txtNotering.Size = new System.Drawing.Size(293, 20);
            this.txtNotering.TabIndex = 15;
            // 
            // lblNotering
            // 
            this.lblNotering.AutoSize = true;
            this.lblNotering.Location = new System.Drawing.Point(23, 152);
            this.lblNotering.Name = "lblNotering";
            this.lblNotering.Size = new System.Drawing.Size(99, 13);
            this.lblNotering.TabIndex = 6;
            this.lblNotering.Text = "Radrubrik_Notering";
            // 
            // gbxRedovisning
            // 
            this.gbxRedovisning.Controls.Add(this.cboRedovisningtyper);
            this.gbxRedovisning.Controls.Add(this.lblTyp);
            this.gbxRedovisning.Location = new System.Drawing.Point(13, 13);
            this.gbxRedovisning.Name = "gbxRedovisning";
            this.gbxRedovisning.Size = new System.Drawing.Size(420, 43);
            this.gbxRedovisning.TabIndex = 5;
            this.gbxRedovisning.TabStop = false;
            this.gbxRedovisning.Text = "Text_Redovisning";
            // 
            // cboRedovisningtyper
            // 
            this.cboRedovisningtyper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRedovisningtyper.IntegralHeight = false;
            this.cboRedovisningtyper.Location = new System.Drawing.Point(122, 15);
            this.cboRedovisningtyper.Name = "cboRedovisningtyper";
            this.cboRedovisningtyper.Size = new System.Drawing.Size(293, 21);
            this.cboRedovisningtyper.TabIndex = 10;
            // 
            // lblTyp
            // 
            this.lblTyp.AutoSize = true;
            this.lblTyp.Location = new System.Drawing.Point(12, 22);
            this.lblTyp.Name = "lblTyp";
            this.lblTyp.Size = new System.Drawing.Size(77, 13);
            this.lblTyp.TabIndex = 0;
            this.lblTyp.Text = "Radrubrik_Typ";
            // 
            // gbxKnappkontoll
            // 
            this.gbxKnappkontoll.Controls.Add(this.knappkontroller1);
            this.gbxKnappkontoll.Location = new System.Drawing.Point(-40, 187);
            this.gbxKnappkontoll.Name = "gbxKnappkontoll";
            this.gbxKnappkontoll.Size = new System.Drawing.Size(541, 48);
            this.gbxKnappkontoll.TabIndex = 0;
            this.gbxKnappkontoll.TabStop = false;
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(60, 15);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 16;
            this.knappkontroller1.OnKnapp1Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp1ClickEventHandler(this.knappkontroller1_OnKnapp1Click);
            this.knappkontroller1.OnKnapp2Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp2ClickEventHandler(this.knappkontroller1_OnKnapp2Click);
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.knappkontroller1_OnKnapp3Click);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // cboSpelare
            // 
            this.cboSpelare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSpelare.FormattingEnabled = true;
            this.cboSpelare.Location = new System.Drawing.Point(304, 66);
            this.cboSpelare.Name = "cboSpelare";
            this.cboSpelare.Size = new System.Drawing.Size(121, 21);
            this.cboSpelare.TabIndex = 12;
            // 
            // lblSpelare
            // 
            this.lblSpelare.AutoSize = true;
            this.lblSpelare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpelare.Location = new System.Drawing.Point(225, 69);
            this.lblSpelare.Name = "lblSpelare";
            this.lblSpelare.Size = new System.Drawing.Size(95, 13);
            this.lblSpelare.TabIndex = 14;
            this.lblSpelare.Text = "Radrubrik_Spelare";
            // 
            // dtpDatum
            // 
            this.dtpDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatum.Location = new System.Drawing.Point(133, 66);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(80, 20);
            this.dtpDatum.TabIndex = 11;
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatum.Location = new System.Drawing.Point(23, 69);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(90, 13);
            this.lblDatum.TabIndex = 13;
            this.lblDatum.Text = "Radrubrik_Datum";
            // 
            // RedovisningInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 236);
            this.Controls.Add(this.cboSpelare);
            this.Controls.Add(this.lblSpelare);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.gbxKnappkontoll);
            this.Controls.Add(this.txtRundaNr);
            this.Controls.Add(this.lblRundanr);
            this.Controls.Add(this.txtBelopp);
            this.Controls.Add(this.lblBelopp);
            this.Controls.Add(this.txtNotering);
            this.Controls.Add(this.lblNotering);
            this.Controls.Add(this.gbxRedovisning);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RedovisningInfo";
            this.Text = "Titel_Redovisning";
            this.Load += new System.EventHandler(this.RedovisningInfo_Load);
            this.gbxRedovisning.ResumeLayout(false);
            this.gbxRedovisning.PerformLayout();
            this.gbxKnappkontoll.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRundaNr;
        private System.Windows.Forms.Label lblRundanr;
        private System.Windows.Forms.TextBox txtBelopp;
        private System.Windows.Forms.Label lblBelopp;
        private System.Windows.Forms.TextBox txtNotering;
        private System.Windows.Forms.Label lblNotering;
        private System.Windows.Forms.GroupBox gbxRedovisning;
        private System.Windows.Forms.Label lblTyp;
        private System.Windows.Forms.GroupBox gbxKnappkontoll;
        private Hooker_GUI.Kontroller.Knappkontroller knappkontroller1;
        private System.Windows.Forms.ComboBox cboSpelare;
        private System.Windows.Forms.Label lblSpelare;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.Label lblDatum;
        public System.Windows.Forms.ComboBox cboRedovisningtyper;
    }
}