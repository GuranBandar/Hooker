namespace Hooker_GUI
{
    partial class HcplistaSpelare
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HcplistaSpelare));
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.gbxSpelarinfo = new System.Windows.Forms.GroupBox();
            this.txtExaktHcp = new System.Windows.Forms.TextBox();
            this.lblExaktHcp = new System.Windows.Forms.Label();
            this.dtpTomDatum = new System.Windows.Forms.DateTimePicker();
            this.lblTomDatum = new System.Windows.Forms.Label();
            this.dtpFromDatum = new System.Windows.Forms.DateTimePicker();
            this.lblFromDatum = new System.Windows.Forms.Label();
            this.cboSpelare = new System.Windows.Forms.ComboBox();
            this.lblSpelare = new System.Windows.Forms.Label();
            this.dgwHcplista = new System.Windows.Forms.DataGridView();
            this.Radnr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Typ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RundaNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hcp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NyttHcp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlusMinus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notering = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxSpelarinfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwHcplista)).BeginInit();
            this.SuspendLayout();
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(277, 417);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 1;
            this.knappkontroller1.OnKnapp0Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp0ClickEventHandler(this.knappkontroller1_OnKnapp0Click);
            this.knappkontroller1.OnKnapp1Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp1ClickEventHandler(this.knappkontroller1_OnKnapp1Click);
            this.knappkontroller1.OnKnapp2Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp2ClickEventHandler(this.knappkontroller1_OnKnapp2Click);
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.knappkontroller1_OnKnapp3Click);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // gbxSpelarinfo
            // 
            this.gbxSpelarinfo.Controls.Add(this.txtExaktHcp);
            this.gbxSpelarinfo.Controls.Add(this.lblExaktHcp);
            this.gbxSpelarinfo.Controls.Add(this.dtpTomDatum);
            this.gbxSpelarinfo.Controls.Add(this.lblTomDatum);
            this.gbxSpelarinfo.Controls.Add(this.dtpFromDatum);
            this.gbxSpelarinfo.Controls.Add(this.lblFromDatum);
            this.gbxSpelarinfo.Controls.Add(this.cboSpelare);
            this.gbxSpelarinfo.Controls.Add(this.lblSpelare);
            this.gbxSpelarinfo.Location = new System.Drawing.Point(12, 12);
            this.gbxSpelarinfo.Name = "gbxSpelarinfo";
            this.gbxSpelarinfo.Size = new System.Drawing.Size(682, 55);
            this.gbxSpelarinfo.TabIndex = 2;
            this.gbxSpelarinfo.TabStop = false;
            this.gbxSpelarinfo.Text = "Text_Spelare";
            // 
            // txtExaktHcp
            // 
            this.txtExaktHcp.Location = new System.Drawing.Point(294, 19);
            this.txtExaktHcp.Name = "txtExaktHcp";
            this.txtExaktHcp.Size = new System.Drawing.Size(36, 20);
            this.txtExaktHcp.TabIndex = 11;
            // 
            // lblExaktHcp
            // 
            this.lblExaktHcp.AutoSize = true;
            this.lblExaktHcp.Location = new System.Drawing.Point(229, 23);
            this.lblExaktHcp.Name = "lblExaktHcp";
            this.lblExaktHcp.Size = new System.Drawing.Size(106, 13);
            this.lblExaktHcp.TabIndex = 10;
            this.lblExaktHcp.Text = "Radrubrik_ExaktHcp";
            // 
            // dtpTomDatum
            // 
            this.dtpTomDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTomDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTomDatum.Location = new System.Drawing.Point(585, 19);
            this.dtpTomDatum.Name = "dtpTomDatum";
            this.dtpTomDatum.Size = new System.Drawing.Size(85, 20);
            this.dtpTomDatum.TabIndex = 9;
            this.dtpTomDatum.ValueChanged += new System.EventHandler(this.dtpTomDatum_ValueChanged);
            // 
            // lblTomDatum
            // 
            this.lblTomDatum.AutoSize = true;
            this.lblTomDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTomDatum.Location = new System.Drawing.Point(518, 23);
            this.lblTomDatum.Name = "lblTomDatum";
            this.lblTomDatum.Size = new System.Drawing.Size(111, 13);
            this.lblTomDatum.TabIndex = 8;
            this.lblTomDatum.Text = "Radrubrik_TomDatum";
            // 
            // dtpFromDatum
            // 
            this.dtpFromDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDatum.Location = new System.Drawing.Point(410, 19);
            this.dtpFromDatum.Name = "dtpFromDatum";
            this.dtpFromDatum.Size = new System.Drawing.Size(85, 20);
            this.dtpFromDatum.TabIndex = 7;
            this.dtpFromDatum.ValueChanged += new System.EventHandler(this.dtpFromDatum_ValueChanged);
            // 
            // lblFromDatum
            // 
            this.lblFromDatum.AutoSize = true;
            this.lblFromDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDatum.Location = new System.Drawing.Point(343, 23);
            this.lblFromDatum.Name = "lblFromDatum";
            this.lblFromDatum.Size = new System.Drawing.Size(113, 13);
            this.lblFromDatum.TabIndex = 6;
            this.lblFromDatum.Text = "Radrubrik_FromDatum";
            // 
            // cboSpelare
            // 
            this.cboSpelare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSpelare.FormattingEnabled = true;
            this.cboSpelare.Location = new System.Drawing.Point(91, 19);
            this.cboSpelare.Name = "cboSpelare";
            this.cboSpelare.Size = new System.Drawing.Size(131, 21);
            this.cboSpelare.TabIndex = 5;
            this.cboSpelare.SelectedIndexChanged += new System.EventHandler(this.cboSpelare_SelectedIndexChanged);
            // 
            // lblSpelare
            // 
            this.lblSpelare.AutoSize = true;
            this.lblSpelare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpelare.Location = new System.Drawing.Point(16, 23);
            this.lblSpelare.Name = "lblSpelare";
            this.lblSpelare.Size = new System.Drawing.Size(95, 13);
            this.lblSpelare.TabIndex = 4;
            this.lblSpelare.Text = "Radrubrik_Spelare";
            // 
            // dgwHcplista
            // 
            this.dgwHcplista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwHcplista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Radnr,
            this.Typ,
            this.RundaNr,
            this.Datum,
            this.Hcp,
            this.NyttHcp,
            this.PlusMinus,
            this.Notering});
            this.dgwHcplista.Location = new System.Drawing.Point(13, 84);
            this.dgwHcplista.Name = "dgwHcplista";
            this.dgwHcplista.Size = new System.Drawing.Size(681, 327);
            this.dgwHcplista.TabIndex = 3;
            // 
            // Radnr
            // 
            this.Radnr.HeaderText = "Rubrik_Nr";
            this.Radnr.Name = "Radnr";
            this.Radnr.ReadOnly = true;
            this.Radnr.Width = 40;
            // 
            // Typ
            // 
            this.Typ.HeaderText = "Text_Typ";
            this.Typ.Name = "Typ";
            this.Typ.ReadOnly = true;
            this.Typ.Width = 50;
            // 
            // RundaNr
            // 
            this.RundaNr.HeaderText = "Text_Runda";
            this.RundaNr.Name = "RundaNr";
            this.RundaNr.ReadOnly = true;
            this.RundaNr.Visible = false;
            // 
            // Datum
            // 
            this.Datum.HeaderText = "Rubrik_Datum";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            this.Datum.Width = 120;
            // 
            // Hcp
            // 
            this.Hcp.HeaderText = "Text_Hcp";
            this.Hcp.Name = "Hcp";
            this.Hcp.ReadOnly = true;
            this.Hcp.Width = 50;
            // 
            // NyttHcp
            // 
            this.NyttHcp.HeaderText = "Rubrik_NyttHcp";
            this.NyttHcp.Name = "NyttHcp";
            this.NyttHcp.ReadOnly = true;
            this.NyttHcp.Width = 50;
            // 
            // PlusMinus
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PlusMinus.DefaultCellStyle = dataGridViewCellStyle1;
            this.PlusMinus.HeaderText = "Rubrik_PlusMinus";
            this.PlusMinus.Name = "PlusMinus";
            this.PlusMinus.ReadOnly = true;
            this.PlusMinus.Width = 50;
            // 
            // Notering
            // 
            this.Notering.HeaderText = "Rubrik_Notering";
            this.Notering.Name = "Notering";
            this.Notering.ReadOnly = true;
            this.Notering.Width = 250;
            // 
            // HcplistaSpelare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 450);
            this.Controls.Add(this.dgwHcplista);
            this.Controls.Add(this.gbxSpelarinfo);
            this.Controls.Add(this.knappkontroller1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HcplistaSpelare";
            this.Text = "Titel_HcplistaInfo";
            this.Load += new System.EventHandler(this.HcplistaSpelare_Load);
            this.gbxSpelarinfo.ResumeLayout(false);
            this.gbxSpelarinfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwHcplista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Kontroller.Knappkontroller knappkontroller1;
        private System.Windows.Forms.GroupBox gbxSpelarinfo;
        private System.Windows.Forms.ComboBox cboSpelare;
        private System.Windows.Forms.Label lblSpelare;
        private System.Windows.Forms.DateTimePicker dtpFromDatum;
        private System.Windows.Forms.Label lblFromDatum;
        private System.Windows.Forms.DateTimePicker dtpTomDatum;
        private System.Windows.Forms.Label lblTomDatum;
        private System.Windows.Forms.DataGridView dgwHcplista;
        private System.Windows.Forms.TextBox txtExaktHcp;
        private System.Windows.Forms.Label lblExaktHcp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Radnr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Typ;
        private System.Windows.Forms.DataGridViewTextBoxColumn RundaNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hcp;
        private System.Windows.Forms.DataGridViewTextBoxColumn NyttHcp;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlusMinus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notering;
    }
}