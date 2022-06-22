namespace Hooker_GUI
{
    partial class SökRedovisning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SökRedovisning));
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.gbxKnappkontroll = new System.Windows.Forms.GroupBox();
            this.fönsterhanterare1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            this.gbxRedovisningstyper = new System.Windows.Forms.GroupBox();
            this.ddnSpelare = new System.Windows.Forms.ComboBox();
            this.lblSpelare = new System.Windows.Forms.Label();
            this.dtpTomDatum = new System.Windows.Forms.DateTimePicker();
            this.lblTomDatum = new System.Windows.Forms.Label();
            this.dtpFromDatum = new System.Windows.Forms.DateTimePicker();
            this.lblFromDatum = new System.Windows.Forms.Label();
            this.lblTyp = new System.Windows.Forms.Label();
            this.ddnRedovisningstyper = new System.Windows.Forms.ComboBox();
            this.dgwSökRedovisning = new System.Windows.Forms.DataGridView();
            this.TransNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RundaNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Typ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Belopp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notering = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxKnappkontroll.SuspendLayout();
            this.gbxRedovisningstyper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSökRedovisning)).BeginInit();
            this.SuspendLayout();
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Location = new System.Drawing.Point(218, 7);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 11;
            this.knappkontroller1.OnKnapp1Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp1ClickEventHandler(this.knappkontroller1_OnKnapp1Click);
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.knappkontroller1_OnKnapp3Click);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            this.knappkontroller1.OnKnapp2Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp2ClickEventHandler(this.knappkontroller1_OnKnapp2Click);
            // 
            // gbxKnappkontroll
            // 
            this.gbxKnappkontroll.Controls.Add(this.fönsterhanterare1);
            this.gbxKnappkontroll.Controls.Add(this.knappkontroller1);
            this.gbxKnappkontroll.Location = new System.Drawing.Point(-5, 355);
            this.gbxKnappkontroll.Name = "gbxKnappkontroll";
            this.gbxKnappkontroll.Size = new System.Drawing.Size(657, 56);
            this.gbxKnappkontroll.TabIndex = 10;
            this.gbxKnappkontroll.TabStop = false;
            // 
            // fönsterhanterare1
            // 
            this.fönsterhanterare1.Location = new System.Drawing.Point(23, 13);
            this.fönsterhanterare1.Name = "fönsterhanterare1";
            this.fönsterhanterare1.Size = new System.Drawing.Size(150, 21);
            this.fönsterhanterare1.TabIndex = 12;
            // 
            // gbxRedovisningstyper
            // 
            this.gbxRedovisningstyper.Controls.Add(this.ddnSpelare);
            this.gbxRedovisningstyper.Controls.Add(this.lblSpelare);
            this.gbxRedovisningstyper.Controls.Add(this.dtpTomDatum);
            this.gbxRedovisningstyper.Controls.Add(this.lblTomDatum);
            this.gbxRedovisningstyper.Controls.Add(this.dtpFromDatum);
            this.gbxRedovisningstyper.Controls.Add(this.lblFromDatum);
            this.gbxRedovisningstyper.Controls.Add(this.lblTyp);
            this.gbxRedovisningstyper.Controls.Add(this.ddnRedovisningstyper);
            this.gbxRedovisningstyper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxRedovisningstyper.Location = new System.Drawing.Point(3, 3);
            this.gbxRedovisningstyper.Name = "gbxRedovisningstyper";
            this.gbxRedovisningstyper.Size = new System.Drawing.Size(621, 79);
            this.gbxRedovisningstyper.TabIndex = 0;
            this.gbxRedovisningstyper.TabStop = false;
            this.gbxRedovisningstyper.Text = "Text_Redovisning";
            // 
            // ddnSpelare
            // 
            this.ddnSpelare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddnSpelare.FormattingEnabled = true;
            this.ddnSpelare.Location = new System.Drawing.Point(120, 50);
            this.ddnSpelare.Name = "ddnSpelare";
            this.ddnSpelare.Size = new System.Drawing.Size(121, 21);
            this.ddnSpelare.TabIndex = 2;
            this.ddnSpelare.SelectedIndexChanged += new System.EventHandler(this.ddnSpelare_SelectedIndexChanged);
            // 
            // lblSpelare
            // 
            this.lblSpelare.AutoSize = true;
            this.lblSpelare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpelare.Location = new System.Drawing.Point(12, 53);
            this.lblSpelare.Name = "lblSpelare";
            this.lblSpelare.Size = new System.Drawing.Size(95, 13);
            this.lblSpelare.TabIndex = 9;
            this.lblSpelare.Text = "Radrubrik_Spelare";
            // 
            // dtpTomDatum
            // 
            this.dtpTomDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTomDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTomDatum.Location = new System.Drawing.Point(523, 50);
            this.dtpTomDatum.Name = "dtpTomDatum";
            this.dtpTomDatum.Size = new System.Drawing.Size(85, 20);
            this.dtpTomDatum.TabIndex = 3;
            this.dtpTomDatum.ValueChanged += new System.EventHandler(this.dtpTomDatum_ValueChanged);
            // 
            // lblTomDatum
            // 
            this.lblTomDatum.AutoSize = true;
            this.lblTomDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTomDatum.Location = new System.Drawing.Point(432, 53);
            this.lblTomDatum.Name = "lblTomDatum";
            this.lblTomDatum.Size = new System.Drawing.Size(111, 13);
            this.lblTomDatum.TabIndex = 6;
            this.lblTomDatum.Text = "Radrubrik_TomDatum";
            // 
            // dtpFromDatum
            // 
            this.dtpFromDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDatum.Location = new System.Drawing.Point(523, 20);
            this.dtpFromDatum.Name = "dtpFromDatum";
            this.dtpFromDatum.Size = new System.Drawing.Size(85, 20);
            this.dtpFromDatum.TabIndex = 1;
            this.dtpFromDatum.ValueChanged += new System.EventHandler(this.dtpFromDatum_ValueChanged);
            // 
            // lblFromDatum
            // 
            this.lblFromDatum.AutoSize = true;
            this.lblFromDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDatum.Location = new System.Drawing.Point(432, 23);
            this.lblFromDatum.Name = "lblFromDatum";
            this.lblFromDatum.Size = new System.Drawing.Size(113, 13);
            this.lblFromDatum.TabIndex = 5;
            this.lblFromDatum.Text = "Radrubrik_FromDatum";
            // 
            // lblTyp
            // 
            this.lblTyp.AutoSize = true;
            this.lblTyp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTyp.Location = new System.Drawing.Point(12, 23);
            this.lblTyp.Name = "lblTyp";
            this.lblTyp.Size = new System.Drawing.Size(77, 13);
            this.lblTyp.TabIndex = 1;
            this.lblTyp.Text = "Radrubrik_Typ";
            // 
            // ddnRedovisningstyper
            // 
            this.ddnRedovisningstyper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddnRedovisningstyper.FormattingEnabled = true;
            this.ddnRedovisningstyper.Location = new System.Drawing.Point(120, 19);
            this.ddnRedovisningstyper.Name = "ddnRedovisningstyper";
            this.ddnRedovisningstyper.Size = new System.Drawing.Size(294, 21);
            this.ddnRedovisningstyper.TabIndex = 0;
            this.ddnRedovisningstyper.SelectedIndexChanged += new System.EventHandler(this.ddnRedovisningstyper_SelectedIndexChanged);
            // 
            // dgwSökRedovisning
            // 
            this.dgwSökRedovisning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwSökRedovisning.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransNr,
            this.RundaNr,
            this.Typ,
            this.Datum,
            this.Belopp,
            this.Notering});
            this.dgwSökRedovisning.Location = new System.Drawing.Point(18, 100);
            this.dgwSökRedovisning.Name = "dgwSökRedovisning";
            this.dgwSökRedovisning.Size = new System.Drawing.Size(606, 249);
            this.dgwSökRedovisning.TabIndex = 4;
            this.dgwSökRedovisning.DoubleClick += new System.EventHandler(this.dgwSökRedovisning_DoubleClick);
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
            this.Belopp.HeaderText = "Rubrik_Belopp";
            this.Belopp.Name = "Belopp";
            this.Belopp.Width = 75;
            // 
            // Notering
            // 
            this.Notering.HeaderText = "Rubrik_Notering";
            this.Notering.Name = "Notering";
            this.Notering.Width = 300;
            // 
            // SökRedovisning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 395);
            this.Controls.Add(this.dgwSökRedovisning);
            this.Controls.Add(this.gbxRedovisningstyper);
            this.Controls.Add(this.gbxKnappkontroll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SökRedovisning";
            this.Text = "Titel_SökRedovisning";
            this.Load += new System.EventHandler(this.SökRedovisning_Load);
            this.Activated += new System.EventHandler(this.SökRedovisning_Activated);
            this.gbxKnappkontroll.ResumeLayout(false);
            this.gbxRedovisningstyper.ResumeLayout(false);
            this.gbxRedovisningstyper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSökRedovisning)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Hooker_GUI.Kontroller.Knappkontroller knappkontroller1;
        private System.Windows.Forms.GroupBox gbxKnappkontroll;
        private System.Windows.Forms.GroupBox gbxRedovisningstyper;
        private System.Windows.Forms.Label lblTyp;
        private System.Windows.Forms.ComboBox ddnRedovisningstyper;
        private System.Windows.Forms.DateTimePicker dtpTomDatum;
        private System.Windows.Forms.Label lblTomDatum;
        private System.Windows.Forms.DateTimePicker dtpFromDatum;
        private System.Windows.Forms.Label lblFromDatum;
        private System.Windows.Forms.ComboBox ddnSpelare;
        private System.Windows.Forms.Label lblSpelare;
        private System.Windows.Forms.DataGridView dgwSökRedovisning;
        private Hooker_GUI.Kontroller.Fönsterhanterare fönsterhanterare1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn RundaNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Typ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Belopp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notering;
    }
}