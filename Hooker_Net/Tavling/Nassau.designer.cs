namespace Hooker_GUI
{
    partial class Nassau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nassau));
            this.gbxKnappkontroll = new System.Windows.Forms.GroupBox();
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.fönsterhanterare1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            this.dgwNassau = new System.Windows.Forms.DataGridView();
            this.dtpStartdatum = new System.Windows.Forms.DateTimePicker();
            this.lblStartdatum = new System.Windows.Forms.Label();
            this.txtTavlingNamn = new System.Windows.Forms.TextBox();
            this.lblNamn = new System.Windows.Forms.Label();
            this.txtBana = new System.Windows.Forms.TextBox();
            this.lblBana = new System.Windows.Forms.Label();
            this.txtGolfklubb = new System.Windows.Forms.TextBox();
            this.lblGolfklubb = new System.Windows.Forms.Label();
            this.RondNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.In = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Totalt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Narmast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Langst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxKnappkontroll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwNassau)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxKnappkontroll
            // 
            this.gbxKnappkontroll.Controls.Add(this.knappkontroller1);
            this.gbxKnappkontroll.Controls.Add(this.fönsterhanterare1);
            this.gbxKnappkontroll.Location = new System.Drawing.Point(0, 288);
            this.gbxKnappkontroll.Name = "gbxKnappkontroll";
            this.gbxKnappkontroll.Size = new System.Drawing.Size(729, 44);
            this.gbxKnappkontroll.TabIndex = 28;
            this.gbxKnappkontroll.TabStop = false;
            this.gbxKnappkontroll.Text = "Text_Blank";
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(304, 9);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 4;
            // 
            // fönsterhanterare1
            // 
            this.fönsterhanterare1.Location = new System.Drawing.Point(13, 19);
            this.fönsterhanterare1.Name = "fönsterhanterare1";
            this.fönsterhanterare1.Size = new System.Drawing.Size(150, 10);
            this.fönsterhanterare1.TabIndex = 3;
            // 
            // dgwNassau
            // 
            this.dgwNassau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwNassau.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RondNr,
            this.Ut,
            this.In,
            this.Totalt,
            this.Narmast,
            this.Langst});
            this.dgwNassau.Location = new System.Drawing.Point(7, 66);
            this.dgwNassau.Margin = new System.Windows.Forms.Padding(2);
            this.dgwNassau.Name = "dgwNassau";
            this.dgwNassau.RowTemplate.Height = 24;
            this.dgwNassau.Size = new System.Drawing.Size(706, 197);
            this.dgwNassau.TabIndex = 27;
            // 
            // dtpStartdatum
            // 
            this.dtpStartdatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartdatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartdatum.Location = new System.Drawing.Point(8, 28);
            this.dtpStartdatum.Name = "dtpStartdatum";
            this.dtpStartdatum.Size = new System.Drawing.Size(80, 20);
            this.dtpStartdatum.TabIndex = 21;
            // 
            // lblStartdatum
            // 
            this.lblStartdatum.AutoSize = true;
            this.lblStartdatum.Location = new System.Drawing.Point(4, 7);
            this.lblStartdatum.Name = "lblStartdatum";
            this.lblStartdatum.Size = new System.Drawing.Size(95, 13);
            this.lblStartdatum.TabIndex = 20;
            this.lblStartdatum.Text = "Rubrik_Startdatum";
            // 
            // txtTavlingNamn
            // 
            this.txtTavlingNamn.Location = new System.Drawing.Point(109, 28);
            this.txtTavlingNamn.Name = "txtTavlingNamn";
            this.txtTavlingNamn.Size = new System.Drawing.Size(175, 20);
            this.txtTavlingNamn.TabIndex = 22;
            // 
            // lblNamn
            // 
            this.lblNamn.AutoSize = true;
            this.lblNamn.Location = new System.Drawing.Point(106, 7);
            this.lblNamn.Name = "lblNamn";
            this.lblNamn.Size = new System.Drawing.Size(62, 13);
            this.lblNamn.TabIndex = 19;
            this.lblNamn.Text = "Text_Namn";
            // 
            // txtBana
            // 
            this.txtBana.Location = new System.Drawing.Point(495, 28);
            this.txtBana.Name = "txtBana";
            this.txtBana.ReadOnly = true;
            this.txtBana.Size = new System.Drawing.Size(114, 20);
            this.txtBana.TabIndex = 33;
            // 
            // lblBana
            // 
            this.lblBana.AutoSize = true;
            this.lblBana.Location = new System.Drawing.Point(492, 7);
            this.lblBana.Name = "lblBana";
            this.lblBana.Size = new System.Drawing.Size(59, 13);
            this.lblBana.TabIndex = 32;
            this.lblBana.Text = "Text_Bana";
            // 
            // txtGolfklubb
            // 
            this.txtGolfklubb.Location = new System.Drawing.Point(327, 28);
            this.txtGolfklubb.Name = "txtGolfklubb";
            this.txtGolfklubb.ReadOnly = true;
            this.txtGolfklubb.Size = new System.Drawing.Size(155, 20);
            this.txtGolfklubb.TabIndex = 31;
            // 
            // lblGolfklubb
            // 
            this.lblGolfklubb.AutoSize = true;
            this.lblGolfklubb.Location = new System.Drawing.Point(324, 7);
            this.lblGolfklubb.Name = "lblGolfklubb";
            this.lblGolfklubb.Size = new System.Drawing.Size(79, 13);
            this.lblGolfklubb.TabIndex = 30;
            this.lblGolfklubb.Text = "Text_Golfklubb";
            // 
            // RondNr
            // 
            this.RondNr.HeaderText = "Text_RondNr";
            this.RondNr.Name = "RondNr";
            this.RondNr.Width = 50;
            // 
            // Ut
            // 
            this.Ut.HeaderText = "Text_Ut";
            this.Ut.Name = "Ut";
            this.Ut.Width = 145;
            // 
            // In
            // 
            this.In.HeaderText = "Text_In";
            this.In.Name = "In";
            this.In.Width = 145;
            // 
            // Totalt
            // 
            this.Totalt.HeaderText = "Text_Totalt";
            this.Totalt.Name = "Totalt";
            this.Totalt.Width = 145;
            // 
            // Narmast
            // 
            this.Narmast.HeaderText = "Text_Närmast";
            this.Narmast.Name = "Narmast";
            this.Narmast.Width = 80;
            // 
            // Langst
            // 
            this.Langst.HeaderText = "Text_Längst";
            this.Langst.Name = "Langst";
            this.Langst.Width = 80;
            // 
            // Nassau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 329);
            this.Controls.Add(this.txtBana);
            this.Controls.Add(this.gbxKnappkontroll);
            this.Controls.Add(this.lblBana);
            this.Controls.Add(this.dgwNassau);
            this.Controls.Add(this.txtGolfklubb);
            this.Controls.Add(this.lblGolfklubb);
            this.Controls.Add(this.dtpStartdatum);
            this.Controls.Add(this.lblStartdatum);
            this.Controls.Add(this.txtTavlingNamn);
            this.Controls.Add(this.lblNamn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Nassau";
            this.Text = "Titel_Nassau";
            this.Load += new System.EventHandler(this.Nassau_Load);
            this.gbxKnappkontroll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwNassau)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpStartdatum;
        private System.Windows.Forms.Label lblStartdatum;
        private System.Windows.Forms.TextBox txtTavlingNamn;
        private System.Windows.Forms.Label lblNamn;
        private System.Windows.Forms.DataGridView dgwNassau;
        private System.Windows.Forms.GroupBox gbxKnappkontroll;
        private Kontroller.Fönsterhanterare fönsterhanterare1;
        private Kontroller.Knappkontroller knappkontroller1;
        private System.Windows.Forms.TextBox txtBana;
        private System.Windows.Forms.Label lblBana;
        private System.Windows.Forms.TextBox txtGolfklubb;
        private System.Windows.Forms.Label lblGolfklubb;
        private System.Windows.Forms.DataGridViewTextBoxColumn RondNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ut;
        private System.Windows.Forms.DataGridViewTextBoxColumn In;
        private System.Windows.Forms.DataGridViewTextBoxColumn Totalt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Narmast;
        private System.Windows.Forms.DataGridViewTextBoxColumn Langst;
    }
}