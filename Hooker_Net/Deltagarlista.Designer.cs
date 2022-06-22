namespace Hooker_GUI
{
    partial class Deltagarlista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Deltagarlista));
            this.gbxKnappkontroll = new System.Windows.Forms.GroupBox();
            this.dgwDeltagarlista = new System.Windows.Forms.DataGridView();
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.fönsterhanterare1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            this.tangentkontroll1 = new Hooker_GUI.Kontroller.Tangentkontroll();
            this.dtpStartdatum = new System.Windows.Forms.DateTimePicker();
            this.lblStartdatum = new System.Windows.Forms.Label();
            this.txtTavlingNamn = new System.Windows.Forms.TextBox();
            this.lblNamn = new System.Windows.Forms.Label();
            this.btnSkapaStartlista = new System.Windows.Forms.Button();
            this.SpelarID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spelarnamn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Golfklubb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hcp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Klassnamn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaBort = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgwDeltagarlista)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxKnappkontroll
            // 
            this.gbxKnappkontroll.Location = new System.Drawing.Point(-7, 381);
            this.gbxKnappkontroll.Name = "gbxKnappkontroll";
            this.gbxKnappkontroll.Size = new System.Drawing.Size(665, 44);
            this.gbxKnappkontroll.TabIndex = 3;
            this.gbxKnappkontroll.TabStop = false;
            this.gbxKnappkontroll.Text = "Text_Blank";
            // 
            // dgwDeltagarlista
            // 
            this.dgwDeltagarlista.AllowUserToAddRows = false;
            this.dgwDeltagarlista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwDeltagarlista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SpelarID,
            this.Nr,
            this.Spelarnamn,
            this.Golfklubb,
            this.Hcp,
            this.Klassnamn,
            this.TaBort});
            this.dgwDeltagarlista.Location = new System.Drawing.Point(13, 59);
            this.dgwDeltagarlista.Name = "dgwDeltagarlista";
            this.dgwDeltagarlista.RowTemplate.Height = 24;
            this.dgwDeltagarlista.Size = new System.Drawing.Size(628, 319);
            this.dgwDeltagarlista.TabIndex = 4;
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(232, 388);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 1;
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.knappkontroller1_OnKnapp3Click);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // fönsterhanterare1
            // 
            this.fönsterhanterare1.Location = new System.Drawing.Point(12, 392);
            this.fönsterhanterare1.Name = "fönsterhanterare1";
            this.fönsterhanterare1.Size = new System.Drawing.Size(150, 18);
            this.fönsterhanterare1.TabIndex = 0;
            // 
            // tangentkontroll1
            // 
            this.tangentkontroll1.Location = new System.Drawing.Point(13, 400);
            this.tangentkontroll1.Margin = new System.Windows.Forms.Padding(4);
            this.tangentkontroll1.Name = "tangentkontroll1";
            this.tangentkontroll1.Size = new System.Drawing.Size(150, 10);
            this.tangentkontroll1.TabIndex = 2;
            // 
            // dtpStartdatum
            // 
            this.dtpStartdatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartdatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartdatum.Location = new System.Drawing.Point(15, 30);
            this.dtpStartdatum.Name = "dtpStartdatum";
            this.dtpStartdatum.Size = new System.Drawing.Size(80, 20);
            this.dtpStartdatum.TabIndex = 7;
            // 
            // lblStartdatum
            // 
            this.lblStartdatum.AutoSize = true;
            this.lblStartdatum.Location = new System.Drawing.Point(12, 9);
            this.lblStartdatum.Name = "lblStartdatum";
            this.lblStartdatum.Size = new System.Drawing.Size(95, 13);
            this.lblStartdatum.TabIndex = 6;
            this.lblStartdatum.Text = "Rubrik_Startdatum";
            // 
            // txtTavlingNamn
            // 
            this.txtTavlingNamn.Location = new System.Drawing.Point(116, 30);
            this.txtTavlingNamn.Name = "txtTavlingNamn";
            this.txtTavlingNamn.Size = new System.Drawing.Size(175, 20);
            this.txtTavlingNamn.TabIndex = 8;
            // 
            // lblNamn
            // 
            this.lblNamn.AutoSize = true;
            this.lblNamn.Location = new System.Drawing.Point(113, 9);
            this.lblNamn.Name = "lblNamn";
            this.lblNamn.Size = new System.Drawing.Size(62, 13);
            this.lblNamn.TabIndex = 5;
            this.lblNamn.Text = "Text_Namn";
            // 
            // btnSkapaStartlista
            // 
            this.btnSkapaStartlista.Location = new System.Drawing.Point(532, 27);
            this.btnSkapaStartlista.Name = "btnSkapaStartlista";
            this.btnSkapaStartlista.Size = new System.Drawing.Size(109, 23);
            this.btnSkapaStartlista.TabIndex = 9;
            this.btnSkapaStartlista.Text = "Knapp_Skapa_Startlista";
            this.btnSkapaStartlista.UseVisualStyleBackColor = true;
            this.btnSkapaStartlista.Click += new System.EventHandler(this.btnSkapaStartlista_Click);
            // 
            // SpelarID
            // 
            this.SpelarID.HeaderText = "Text_SpelareID";
            this.SpelarID.Name = "SpelarID";
            this.SpelarID.Visible = false;
            // 
            // Nr
            // 
            this.Nr.HeaderText = "Text_Nr";
            this.Nr.Name = "Nr";
            this.Nr.ReadOnly = true;
            this.Nr.Visible = false;
            this.Nr.Width = 50;
            // 
            // Spelarnamn
            // 
            this.Spelarnamn.HeaderText = "Rubrik_Spelare";
            this.Spelarnamn.Name = "Spelarnamn";
            this.Spelarnamn.ReadOnly = true;
            this.Spelarnamn.Width = 130;
            // 
            // Golfklubb
            // 
            this.Golfklubb.HeaderText = "Text_Golfklubb";
            this.Golfklubb.Name = "Golfklubb";
            this.Golfklubb.Width = 200;
            // 
            // Hcp
            // 
            this.Hcp.HeaderText = "Text_Exakt_Hcp";
            this.Hcp.Name = "Hcp";
            this.Hcp.ReadOnly = true;
            this.Hcp.Width = 80;
            // 
            // Klassnamn
            // 
            this.Klassnamn.HeaderText = "Text_Klass";
            this.Klassnamn.Name = "Klassnamn";
            this.Klassnamn.ReadOnly = true;
            // 
            // TaBort
            // 
            this.TaBort.FalseValue = "0";
            this.TaBort.HeaderText = "Text_TaBort";
            this.TaBort.Name = "TaBort";
            this.TaBort.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TaBort.TrueValue = "1";
            this.TaBort.Width = 50;
            // 
            // Deltagarlista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 422);
            this.Controls.Add(this.btnSkapaStartlista);
            this.Controls.Add(this.dtpStartdatum);
            this.Controls.Add(this.lblStartdatum);
            this.Controls.Add(this.txtTavlingNamn);
            this.Controls.Add(this.lblNamn);
            this.Controls.Add(this.dgwDeltagarlista);
            this.Controls.Add(this.knappkontroller1);
            this.Controls.Add(this.fönsterhanterare1);
            this.Controls.Add(this.tangentkontroll1);
            this.Controls.Add(this.gbxKnappkontroll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Deltagarlista";
            this.Text = "Titel_Deltagarlista";
            this.Load += new System.EventHandler(this.Deltagarlista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwDeltagarlista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Kontroller.Fönsterhanterare fönsterhanterare1;
        private Kontroller.Knappkontroller knappkontroller1;
        private Kontroller.Tangentkontroll tangentkontroll1;
        private System.Windows.Forms.GroupBox gbxKnappkontroll;
        private System.Windows.Forms.DataGridView dgwDeltagarlista;
        private System.Windows.Forms.DateTimePicker dtpStartdatum;
        private System.Windows.Forms.Label lblStartdatum;
        private System.Windows.Forms.TextBox txtTavlingNamn;
        private System.Windows.Forms.Label lblNamn;
        private System.Windows.Forms.Button btnSkapaStartlista;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpelarID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spelarnamn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Golfklubb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hcp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Klassnamn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TaBort;
    }
}