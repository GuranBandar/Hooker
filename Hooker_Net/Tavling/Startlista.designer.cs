namespace Hooker_GUI
{
    partial class Startlista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Startlista));
            this.dtpStartdatum = new System.Windows.Forms.DateTimePicker();
            this.lblStartdatum = new System.Windows.Forms.Label();
            this.txtTavlingNamn = new System.Windows.Forms.TextBox();
            this.lblNamn = new System.Windows.Forms.Label();
            this.dgwStartlista = new System.Windows.Forms.DataGridView();
            this.SpelarID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RondID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RondNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BollNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Starttid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HålNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spelarnamn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Golfklubb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExaktHcp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErhallnaSlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.fönsterhanterare1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            this.gbxKnappkontroll = new System.Windows.Forms.GroupBox();
            this.cboRondnr = new System.Windows.Forms.ComboBox();
            this.lblRondnr = new System.Windows.Forms.Label();
            this.txtGolfklubb = new System.Windows.Forms.TextBox();
            this.lblGolfklubb = new System.Windows.Forms.Label();
            this.lblBana = new System.Windows.Forms.Label();
            this.txtBana = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgwStartlista)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpStartdatum
            // 
            this.dtpStartdatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartdatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartdatum.Location = new System.Drawing.Point(15, 30);
            this.dtpStartdatum.Name = "dtpStartdatum";
            this.dtpStartdatum.Size = new System.Drawing.Size(80, 20);
            this.dtpStartdatum.TabIndex = 22;
            // 
            // lblStartdatum
            // 
            this.lblStartdatum.AutoSize = true;
            this.lblStartdatum.Location = new System.Drawing.Point(12, 9);
            this.lblStartdatum.Name = "lblStartdatum";
            this.lblStartdatum.Size = new System.Drawing.Size(95, 13);
            this.lblStartdatum.TabIndex = 21;
            this.lblStartdatum.Text = "Rubrik_Startdatum";
            // 
            // txtTavlingNamn
            // 
            this.txtTavlingNamn.Location = new System.Drawing.Point(109, 30);
            this.txtTavlingNamn.Name = "txtTavlingNamn";
            this.txtTavlingNamn.ReadOnly = true;
            this.txtTavlingNamn.Size = new System.Drawing.Size(155, 20);
            this.txtTavlingNamn.TabIndex = 23;
            // 
            // lblNamn
            // 
            this.lblNamn.AutoSize = true;
            this.lblNamn.Location = new System.Drawing.Point(106, 9);
            this.lblNamn.Name = "lblNamn";
            this.lblNamn.Size = new System.Drawing.Size(69, 13);
            this.lblNamn.TabIndex = 20;
            this.lblNamn.Text = "Text_Tävling";
            // 
            // dgwStartlista
            // 
            this.dgwStartlista.AllowUserToAddRows = false;
            this.dgwStartlista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwStartlista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SpelarID,
            this.RondID,
            this.RondNr,
            this.BollNr,
            this.Starttid,
            this.HålNr,
            this.Spelarnamn,
            this.Golfklubb,
            this.ExaktHcp,
            this.ErhallnaSlag,
            this.Tee});
            this.dgwStartlista.Location = new System.Drawing.Point(13, 59);
            this.dgwStartlista.Name = "dgwStartlista";
            this.dgwStartlista.RowTemplate.Height = 24;
            this.dgwStartlista.Size = new System.Drawing.Size(628, 319);
            this.dgwStartlista.TabIndex = 19;
            // 
            // SpelarID
            // 
            this.SpelarID.HeaderText = "Text_SpelareID";
            this.SpelarID.Name = "SpelarID";
            this.SpelarID.Visible = false;
            // 
            // RondID
            // 
            this.RondID.HeaderText = "Text_RondID";
            this.RondID.Name = "RondID";
            this.RondID.Visible = false;
            // 
            // RondNr
            // 
            this.RondNr.HeaderText = "Text_RondNr";
            this.RondNr.Name = "RondNr";
            this.RondNr.ReadOnly = true;
            this.RondNr.Visible = false;
            this.RondNr.Width = 50;
            // 
            // BollNr
            // 
            this.BollNr.HeaderText = "Text_BollNr";
            this.BollNr.Name = "BollNr";
            this.BollNr.Width = 50;
            // 
            // Starttid
            // 
            this.Starttid.HeaderText = "Text_Starttid";
            this.Starttid.Name = "Starttid";
            this.Starttid.ReadOnly = true;
            this.Starttid.Width = 50;
            // 
            // HålNr
            // 
            this.HålNr.HeaderText = "Rubrik_Hål";
            this.HålNr.Name = "HålNr";
            this.HålNr.Width = 30;
            // 
            // Spelarnamn
            // 
            this.Spelarnamn.HeaderText = "Rubrik_Spelare";
            this.Spelarnamn.Name = "Spelarnamn";
            this.Spelarnamn.ReadOnly = true;
            this.Spelarnamn.Width = 110;
            // 
            // Golfklubb
            // 
            this.Golfklubb.HeaderText = "Text_Golfklubb";
            this.Golfklubb.Name = "Golfklubb";
            this.Golfklubb.ReadOnly = true;
            this.Golfklubb.Width = 170;
            // 
            // ExaktHcp
            // 
            this.ExaktHcp.HeaderText = "Text_Exakt_Hcp";
            this.ExaktHcp.Name = "ExaktHcp";
            this.ExaktHcp.ReadOnly = true;
            this.ExaktHcp.Width = 60;
            // 
            // ErhallnaSlag
            // 
            this.ErhallnaSlag.HeaderText = "Text_Spel_Hcp";
            this.ErhallnaSlag.Name = "ErhallnaSlag";
            this.ErhallnaSlag.ReadOnly = true;
            this.ErhallnaSlag.Width = 50;
            // 
            // Tee
            // 
            this.Tee.HeaderText = "Text_Tee";
            this.Tee.Name = "Tee";
            this.Tee.Width = 40;
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(232, 388);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 17;
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.knappkontroller1_OnKnapp3Click);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // fönsterhanterare1
            // 
            this.fönsterhanterare1.Location = new System.Drawing.Point(12, 392);
            this.fönsterhanterare1.Name = "fönsterhanterare1";
            this.fönsterhanterare1.Size = new System.Drawing.Size(150, 18);
            this.fönsterhanterare1.TabIndex = 16;
            // 
            // gbxKnappkontroll
            // 
            this.gbxKnappkontroll.Location = new System.Drawing.Point(-7, 381);
            this.gbxKnappkontroll.Name = "gbxKnappkontroll";
            this.gbxKnappkontroll.Size = new System.Drawing.Size(665, 44);
            this.gbxKnappkontroll.TabIndex = 18;
            this.gbxKnappkontroll.TabStop = false;
            this.gbxKnappkontroll.Text = "Text_Blank";
            // 
            // cboRondnr
            // 
            this.cboRondnr.FormattingEnabled = true;
            this.cboRondnr.Location = new System.Drawing.Point(275, 30);
            this.cboRondnr.Name = "cboRondnr";
            this.cboRondnr.Size = new System.Drawing.Size(72, 21);
            this.cboRondnr.TabIndex = 25;
            this.cboRondnr.SelectedIndexChanged += new System.EventHandler(this.cboRondnr_SelectedIndexChanged);
            // 
            // lblRondnr
            // 
            this.lblRondnr.AutoSize = true;
            this.lblRondnr.Location = new System.Drawing.Point(275, 9);
            this.lblRondnr.Name = "lblRondnr";
            this.lblRondnr.Size = new System.Drawing.Size(69, 13);
            this.lblRondnr.TabIndex = 24;
            this.lblRondnr.Text = "Text_Rondnr";
            // 
            // txtGolfklubb
            // 
            this.txtGolfklubb.Location = new System.Drawing.Point(359, 30);
            this.txtGolfklubb.Name = "txtGolfklubb";
            this.txtGolfklubb.ReadOnly = true;
            this.txtGolfklubb.Size = new System.Drawing.Size(155, 20);
            this.txtGolfklubb.TabIndex = 27;
            // 
            // lblGolfklubb
            // 
            this.lblGolfklubb.AutoSize = true;
            this.lblGolfklubb.Location = new System.Drawing.Point(356, 9);
            this.lblGolfklubb.Name = "lblGolfklubb";
            this.lblGolfklubb.Size = new System.Drawing.Size(79, 13);
            this.lblGolfklubb.TabIndex = 26;
            this.lblGolfklubb.Text = "Text_Golfklubb";
            // 
            // lblBana
            // 
            this.lblBana.AutoSize = true;
            this.lblBana.Location = new System.Drawing.Point(524, 9);
            this.lblBana.Name = "lblBana";
            this.lblBana.Size = new System.Drawing.Size(59, 13);
            this.lblBana.TabIndex = 28;
            this.lblBana.Text = "Text_Bana";
            // 
            // txtBana
            // 
            this.txtBana.Location = new System.Drawing.Point(527, 30);
            this.txtBana.Name = "txtBana";
            this.txtBana.ReadOnly = true;
            this.txtBana.Size = new System.Drawing.Size(114, 20);
            this.txtBana.TabIndex = 29;
            // 
            // Startlista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 422);
            this.Controls.Add(this.txtBana);
            this.Controls.Add(this.lblBana);
            this.Controls.Add(this.txtGolfklubb);
            this.Controls.Add(this.lblGolfklubb);
            this.Controls.Add(this.cboRondnr);
            this.Controls.Add(this.lblRondnr);
            this.Controls.Add(this.dtpStartdatum);
            this.Controls.Add(this.lblStartdatum);
            this.Controls.Add(this.txtTavlingNamn);
            this.Controls.Add(this.lblNamn);
            this.Controls.Add(this.dgwStartlista);
            this.Controls.Add(this.knappkontroller1);
            this.Controls.Add(this.fönsterhanterare1);
            this.Controls.Add(this.gbxKnappkontroll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Startlista";
            this.Text = "Titel_Startlista";
            this.Load += new System.EventHandler(this.Startlista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwStartlista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpStartdatum;
        private System.Windows.Forms.Label lblStartdatum;
        private System.Windows.Forms.TextBox txtTavlingNamn;
        private System.Windows.Forms.Label lblNamn;
        private System.Windows.Forms.DataGridView dgwStartlista;
        private Kontroller.Knappkontroller knappkontroller1;
        private Kontroller.Fönsterhanterare fönsterhanterare1;
        private System.Windows.Forms.GroupBox gbxKnappkontroll;
        private System.Windows.Forms.ComboBox cboRondnr;
        private System.Windows.Forms.Label lblRondnr;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpelarID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RondID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RondNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn BollNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Starttid;
        private System.Windows.Forms.DataGridViewTextBoxColumn HålNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spelarnamn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Golfklubb;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExaktHcp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErhallnaSlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tee;
        private System.Windows.Forms.TextBox txtGolfklubb;
        private System.Windows.Forms.Label lblGolfklubb;
        private System.Windows.Forms.Label lblBana;
        private System.Windows.Forms.TextBox txtBana;
    }
}