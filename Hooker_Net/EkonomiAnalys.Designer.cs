namespace Hooker_GUI
{
    partial class EkonomiAnalys
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EkonomiAnalys));
            this.statistikHuvudKontroll1 = new Hooker_GUI.Kontroller.StatistikHuvudKontroll();
            this.gbxKnappkontroller = new System.Windows.Forms.GroupBox();
            this.fönsterhanterare1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.dgwEkonomiAnalys = new System.Windows.Forms.DataGridView();
            this.TransNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RundaNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Typ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Belopp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spelare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notering = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxKnappkontroller.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwEkonomiAnalys)).BeginInit();
            this.SuspendLayout();
            // 
            // statistikHuvudKontroll1
            // 
            this.statistikHuvudKontroll1.Location = new System.Drawing.Point(2, 2);
            this.statistikHuvudKontroll1.Name = "statistikHuvudKontroll1";
            this.statistikHuvudKontroll1.Size = new System.Drawing.Size(725, 104);
            this.statistikHuvudKontroll1.TabIndex = 1;
            this.statistikHuvudKontroll1.OnCboSpelareSelect += new Hooker_GUI.Kontroller.StatistikHuvudKontroll.CboSpelareSelectEventHandler(this.statistikHuvudKontroll1_OnCboSpelareSelect);
            this.statistikHuvudKontroll1.OnDdnRedovisningsSelect += new Hooker_GUI.Kontroller.StatistikHuvudKontroll.DdnRedovisningsSelectEventHandler(this.statistikHuvudKontroll1_OnDdnRedovisningsSelect);
            this.statistikHuvudKontroll1.OnDtpFromDatumChanged += new Hooker_GUI.Kontroller.StatistikHuvudKontroll.DtpFromDatumChangedEventHandler(this.statistikHuvudKontroll1_OnDtpFromDatumChanged);
            this.statistikHuvudKontroll1.OnDtpTomDatumChanged += new Hooker_GUI.Kontroller.StatistikHuvudKontroll.DtpTomDatumChangedEventHandler(this.statistikHuvudKontroll1_OnDtpTomDatumChanged);
            // 
            // gbxKnappkontroller
            // 
            this.gbxKnappkontroller.Controls.Add(this.fönsterhanterare1);
            this.gbxKnappkontroller.Controls.Add(this.knappkontroller1);
            this.gbxKnappkontroller.Location = new System.Drawing.Point(-4, 442);
            this.gbxKnappkontroller.Name = "gbxKnappkontroller";
            this.gbxKnappkontroller.Size = new System.Drawing.Size(745, 45);
            this.gbxKnappkontroller.TabIndex = 2;
            this.gbxKnappkontroller.TabStop = false;
            // 
            // fönsterhanterare1
            // 
            this.fönsterhanterare1.Location = new System.Drawing.Point(29, 17);
            this.fönsterhanterare1.Name = "fönsterhanterare1";
            this.fönsterhanterare1.Size = new System.Drawing.Size(150, 19);
            this.fönsterhanterare1.TabIndex = 0;
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Location = new System.Drawing.Point(314, 10);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 0;
            this.knappkontroller1.OnKnapp1Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp1ClickEventHandler(this.knappkontroller1_OnKnapp1Click);
            this.knappkontroller1.OnKnapp2Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp2ClickEventHandler(this.knappkontroller1_OnKnapp2Click);
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.knappkontroller1_OnKnapp3Click);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // dgwEkonomiAnalys
            // 
            this.dgwEkonomiAnalys.AllowUserToAddRows = false;
            this.dgwEkonomiAnalys.AllowUserToDeleteRows = false;
            this.dgwEkonomiAnalys.BackgroundColor = System.Drawing.Color.White;
            this.dgwEkonomiAnalys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwEkonomiAnalys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransNr,
            this.RundaNr,
            this.Typ,
            this.Datum,
            this.Belopp,
            this.Spelare,
            this.Notering});
            this.dgwEkonomiAnalys.Location = new System.Drawing.Point(12, 112);
            this.dgwEkonomiAnalys.Name = "dgwEkonomiAnalys";
            this.dgwEkonomiAnalys.Size = new System.Drawing.Size(705, 324);
            this.dgwEkonomiAnalys.TabIndex = 5;
            this.dgwEkonomiAnalys.DoubleClick += new System.EventHandler(this.dgwEkonomiAnalys_DoubleClick);
            // 
            // TransNr
            // 
            this.TransNr.HeaderText = "Text_TransNr";
            this.TransNr.Name = "TransNr";
            this.TransNr.Visible = false;
            // 
            // RundaNr
            // 
            this.RundaNr.HeaderText = "Text_RundaNr";
            this.RundaNr.Name = "RundaNr";
            this.RundaNr.Visible = false;
            // 
            // Typ
            // 
            this.Typ.HeaderText = "Text_Typ";
            this.Typ.Name = "Typ";
            this.Typ.Width = 85;
            // 
            // Datum
            // 
            this.Datum.HeaderText = "Rubrik_Datum";
            this.Datum.Name = "Datum";
            this.Datum.Width = 75;
            // 
            // Belopp
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Belopp.DefaultCellStyle = dataGridViewCellStyle1;
            this.Belopp.HeaderText = "Rubrik_Belopp";
            this.Belopp.Name = "Belopp";
            this.Belopp.Width = 75;
            // 
            // Spelare
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Spelare.DefaultCellStyle = dataGridViewCellStyle2;
            this.Spelare.HeaderText = "Rubrik_Spelare";
            this.Spelare.Name = "Spelare";
            // 
            // Notering
            // 
            this.Notering.HeaderText = "Rubrik_Notering";
            this.Notering.Name = "Notering";
            this.Notering.Width = 300;
            // 
            // EkonomiAnalys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 486);
            this.Controls.Add(this.dgwEkonomiAnalys);
            this.Controls.Add(this.gbxKnappkontroller);
            this.Controls.Add(this.statistikHuvudKontroll1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EkonomiAnalys";
            this.Text = "Titel_EkonomiAnalys";
            this.Load += new System.EventHandler(this.EkonomiAnalys_Load);
            this.gbxKnappkontroller.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwEkonomiAnalys)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Hooker_GUI.Kontroller.StatistikHuvudKontroll statistikHuvudKontroll1;
        private System.Windows.Forms.GroupBox gbxKnappkontroller;
        private Hooker_GUI.Kontroller.Fönsterhanterare fönsterhanterare1;
        private Hooker_GUI.Kontroller.Knappkontroller knappkontroller1;
        private System.Windows.Forms.DataGridView dgwEkonomiAnalys;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn RundaNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Typ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Belopp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spelare;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notering;
    }
}