namespace Hooker_GUI
{
    partial class SökTävling
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SökTävling));
            this.gbxTävlingar = new System.Windows.Forms.GroupBox();
            this.txtTavlingNamn = new System.Windows.Forms.TextBox();
            this.cboSpelsatt = new System.Windows.Forms.ComboBox();
            this.lblTavlingNamn = new System.Windows.Forms.Label();
            this.dtpTomDatum = new System.Windows.Forms.DateTimePicker();
            this.lblTomDatum = new System.Windows.Forms.Label();
            this.dtpFromDatum = new System.Windows.Forms.DateTimePicker();
            this.lblFromDatum = new System.Windows.Forms.Label();
            this.cboSpeltyper = new System.Windows.Forms.ComboBox();
            this.lblSpeltyp = new System.Windows.Forms.Label();
            this.lblSpelsatt = new System.Windows.Forms.Label();
            this.dgwSökTävling = new System.Windows.Forms.DataGridView();
            this.TavlingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Namn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notering = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spelform = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxKnappkontroll = new System.Windows.Forms.GroupBox();
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.fönsterhanterare1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            this.gbxTävlingar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSökTävling)).BeginInit();
            this.gbxKnappkontroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxTävlingar
            // 
            this.gbxTävlingar.Controls.Add(this.txtTavlingNamn);
            this.gbxTävlingar.Controls.Add(this.cboSpelsatt);
            this.gbxTävlingar.Controls.Add(this.lblTavlingNamn);
            this.gbxTävlingar.Controls.Add(this.dtpTomDatum);
            this.gbxTävlingar.Controls.Add(this.lblTomDatum);
            this.gbxTävlingar.Controls.Add(this.dtpFromDatum);
            this.gbxTävlingar.Controls.Add(this.lblFromDatum);
            this.gbxTävlingar.Controls.Add(this.cboSpeltyper);
            this.gbxTävlingar.Controls.Add(this.lblSpeltyp);
            this.gbxTävlingar.Controls.Add(this.lblSpelsatt);
            this.gbxTävlingar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxTävlingar.Location = new System.Drawing.Point(3, 3);
            this.gbxTävlingar.Name = "gbxTävlingar";
            this.gbxTävlingar.Size = new System.Drawing.Size(621, 79);
            this.gbxTävlingar.TabIndex = 0;
            this.gbxTävlingar.TabStop = false;
            this.gbxTävlingar.Text = "Text_TavlingInfo";
            // 
            // txtTavlingNamn
            // 
            this.txtTavlingNamn.Location = new System.Drawing.Point(88, 18);
            this.txtTavlingNamn.Name = "txtTavlingNamn";
            this.txtTavlingNamn.Size = new System.Drawing.Size(331, 20);
            this.txtTavlingNamn.TabIndex = 1;
            // 
            // cboSpelsatt
            // 
            this.cboSpelsatt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSpelsatt.FormattingEnabled = true;
            this.cboSpelsatt.Location = new System.Drawing.Point(298, 49);
            this.cboSpelsatt.Name = "cboSpelsatt";
            this.cboSpelsatt.Size = new System.Drawing.Size(121, 21);
            this.cboSpelsatt.TabIndex = 3;
            // 
            // lblTavlingNamn
            // 
            this.lblTavlingNamn.AutoSize = true;
            this.lblTavlingNamn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTavlingNamn.Location = new System.Drawing.Point(18, 21);
            this.lblTavlingNamn.Name = "lblTavlingNamn";
            this.lblTavlingNamn.Size = new System.Drawing.Size(87, 13);
            this.lblTavlingNamn.TabIndex = 0;
            this.lblTavlingNamn.Text = "Radrubrik_Namn";
            // 
            // dtpTomDatum
            // 
            this.dtpTomDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTomDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTomDatum.Location = new System.Drawing.Point(523, 50);
            this.dtpTomDatum.Name = "dtpTomDatum";
            this.dtpTomDatum.Size = new System.Drawing.Size(85, 20);
            this.dtpTomDatum.TabIndex = 5;
            this.dtpTomDatum.ValueChanged += new System.EventHandler(this.dtpTomDatum_ValueChanged);
            // 
            // lblTomDatum
            // 
            this.lblTomDatum.AutoSize = true;
            this.lblTomDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTomDatum.Location = new System.Drawing.Point(432, 53);
            this.lblTomDatum.Name = "lblTomDatum";
            this.lblTomDatum.Size = new System.Drawing.Size(111, 13);
            this.lblTomDatum.TabIndex = 0;
            this.lblTomDatum.Text = "Radrubrik_TomDatum";
            // 
            // dtpFromDatum
            // 
            this.dtpFromDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDatum.Location = new System.Drawing.Point(523, 20);
            this.dtpFromDatum.Name = "dtpFromDatum";
            this.dtpFromDatum.Size = new System.Drawing.Size(85, 20);
            this.dtpFromDatum.TabIndex = 4;
            this.dtpFromDatum.ValueChanged += new System.EventHandler(this.dtpFromDatum_ValueChanged);
            // 
            // lblFromDatum
            // 
            this.lblFromDatum.AutoSize = true;
            this.lblFromDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDatum.Location = new System.Drawing.Point(432, 23);
            this.lblFromDatum.Name = "lblFromDatum";
            this.lblFromDatum.Size = new System.Drawing.Size(113, 13);
            this.lblFromDatum.TabIndex = 0;
            this.lblFromDatum.Text = "Radrubrik_FromDatum";
            // 
            // cboSpeltyper
            // 
            this.cboSpeltyper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSpeltyper.FormattingEnabled = true;
            this.cboSpeltyper.Location = new System.Drawing.Point(88, 49);
            this.cboSpeltyper.Name = "cboSpeltyper";
            this.cboSpeltyper.Size = new System.Drawing.Size(121, 21);
            this.cboSpeltyper.TabIndex = 2;
            // 
            // lblSpeltyp
            // 
            this.lblSpeltyp.AutoSize = true;
            this.lblSpeltyp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeltyp.Location = new System.Drawing.Point(18, 53);
            this.lblSpeltyp.Name = "lblSpeltyp";
            this.lblSpeltyp.Size = new System.Drawing.Size(94, 13);
            this.lblSpeltyp.TabIndex = 0;
            this.lblSpeltyp.Text = "Radrubrik_Speltyp";
            // 
            // lblSpelsatt
            // 
            this.lblSpelsatt.AutoSize = true;
            this.lblSpelsatt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpelsatt.Location = new System.Drawing.Point(228, 53);
            this.lblSpelsatt.Name = "lblSpelsatt";
            this.lblSpelsatt.Size = new System.Drawing.Size(97, 13);
            this.lblSpelsatt.TabIndex = 0;
            this.lblSpelsatt.Text = "Radrubrik_Spelsatt";
            // 
            // dgwSökTävling
            // 
            this.dgwSökTävling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwSökTävling.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TavlingID,
            this.Datum,
            this.Namn,
            this.Notering,
            this.Spelform,
            this.Status});
            this.dgwSökTävling.Location = new System.Drawing.Point(18, 100);
            this.dgwSökTävling.Name = "dgwSökTävling";
            this.dgwSökTävling.RowTemplate.Height = 24;
            this.dgwSökTävling.Size = new System.Drawing.Size(606, 249);
            this.dgwSökTävling.TabIndex = 10;
            this.dgwSökTävling.DoubleClick += new System.EventHandler(this.dgwSökTävling_DoubleClick);
            // 
            // TavlingID
            // 
            this.TavlingID.HeaderText = "Text_TavlingID";
            this.TavlingID.Name = "TavlingID";
            this.TavlingID.Visible = false;
            this.TavlingID.Width = 25;
            // 
            // Datum
            // 
            this.Datum.HeaderText = "Rubrik_Datum";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            this.Datum.Width = 75;
            // 
            // Namn
            // 
            this.Namn.HeaderText = "Text_Namn";
            this.Namn.Name = "Namn";
            this.Namn.ReadOnly = true;
            this.Namn.Width = 150;
            // 
            // Notering
            // 
            this.Notering.HeaderText = "Rubrik_Notering";
            this.Notering.Name = "Notering";
            this.Notering.ReadOnly = true;
            this.Notering.Width = 150;
            // 
            // Spelform
            // 
            this.Spelform.HeaderText = "Text_Spelform";
            this.Spelform.Name = "Spelform";
            this.Spelform.ReadOnly = true;
            this.Spelform.Width = 85;
            // 
            // Status
            // 
            this.Status.HeaderText = "Rubrik_Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 75;
            // 
            // gbxKnappkontroll
            // 
            this.gbxKnappkontroll.Controls.Add(this.knappkontroller1);
            this.gbxKnappkontroll.Controls.Add(this.fönsterhanterare1);
            this.gbxKnappkontroll.Location = new System.Drawing.Point(-5, 355);
            this.gbxKnappkontroll.Name = "gbxKnappkontroll";
            this.gbxKnappkontroll.Size = new System.Drawing.Size(657, 56);
            this.gbxKnappkontroll.TabIndex = 0;
            this.gbxKnappkontroll.TabStop = false;
            this.gbxKnappkontroll.Text = "Text_Blank";
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(217, 10);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 13;
            this.knappkontroller1.OnKnapp0Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp0ClickEventHandler(this.knappkontroller1_OnKnapp0Click);
            this.knappkontroller1.OnKnapp1Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp1ClickEventHandler(this.knappkontroller1_OnKnapp1Click);
            this.knappkontroller1.OnKnapp2Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp2ClickEventHandler(this.knappkontroller1_OnKnapp2Click);
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.knappkontroller1_OnKnapp3Click);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // fönsterhanterare1
            // 
            this.fönsterhanterare1.Location = new System.Drawing.Point(23, 13);
            this.fönsterhanterare1.Name = "fönsterhanterare1";
            this.fönsterhanterare1.Size = new System.Drawing.Size(150, 21);
            this.fönsterhanterare1.TabIndex = 12;
            // 
            // SökTävling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 395);
            this.Controls.Add(this.gbxTävlingar);
            this.Controls.Add(this.dgwSökTävling);
            this.Controls.Add(this.gbxKnappkontroll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SökTävling";
            this.Text = "Titel_SökTävling";
            this.Activated += new System.EventHandler(this.SökTävling_Activated);
            this.Load += new System.EventHandler(this.SökTävling_Load);
            this.gbxTävlingar.ResumeLayout(false);
            this.gbxTävlingar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSökTävling)).EndInit();
            this.gbxKnappkontroll.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Kontroller.Fönsterhanterare fönsterhanterare1;
        private System.Windows.Forms.GroupBox gbxKnappkontroll;
        private System.Windows.Forms.DataGridView dgwSökTävling;
        private System.Windows.Forms.Label lblTavlingNamn;
        private System.Windows.Forms.DateTimePicker dtpTomDatum;
        private System.Windows.Forms.Label lblTomDatum;
        private System.Windows.Forms.GroupBox gbxTävlingar;
        private System.Windows.Forms.DateTimePicker dtpFromDatum;
        private System.Windows.Forms.Label lblFromDatum;
        private System.Windows.Forms.Label lblSpeltyp;
        private System.Windows.Forms.ComboBox cboSpeltyper;
        private System.Windows.Forms.Label lblSpelsatt;
        private System.Windows.Forms.ComboBox cboSpelsatt;
        private Kontroller.Knappkontroller knappkontroller1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TavlingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Namn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notering;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spelform;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.TextBox txtTavlingNamn;

    }
}