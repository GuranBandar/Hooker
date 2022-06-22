namespace Hooker_GUI
{
    partial class R2A
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(R2A));
            this.gbxTotalt = new System.Windows.Forms.GroupBox();
            this.dgwR2A = new System.Windows.Forms.DataGridView();
            this.txtTavlingStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dtpStartdatum = new System.Windows.Forms.DateTimePicker();
            this.lblStartdatum = new System.Windows.Forms.Label();
            this.txtTavlingNamn = new System.Windows.Forms.TextBox();
            this.lblNamn = new System.Windows.Forms.Label();
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.fönsterhanterare1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            this.Rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spelarnamn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Totalt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxTotalt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwR2A)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxTotalt
            // 
            this.gbxTotalt.Controls.Add(this.dgwR2A);
            this.gbxTotalt.Location = new System.Drawing.Point(6, 53);
            this.gbxTotalt.Name = "gbxTotalt";
            this.gbxTotalt.Size = new System.Drawing.Size(594, 224);
            this.gbxTotalt.TabIndex = 39;
            this.gbxTotalt.TabStop = false;
            this.gbxTotalt.Text = "Text_Totalt";
            // 
            // dgwR2A
            // 
            this.dgwR2A.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwR2A.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rank,
            this.Spelarnamn,
            this.R1,
            this.R2,
            this.R3,
            this.R4,
            this.R5,
            this.R6,
            this.Totalt});
            this.dgwR2A.Location = new System.Drawing.Point(6, 19);
            this.dgwR2A.Name = "dgwR2A";
            this.dgwR2A.Size = new System.Drawing.Size(579, 195);
            this.dgwR2A.TabIndex = 0;
            // 
            // txtTavlingStatus
            // 
            this.txtTavlingStatus.Location = new System.Drawing.Point(323, 30);
            this.txtTavlingStatus.Name = "txtTavlingStatus";
            this.txtTavlingStatus.Size = new System.Drawing.Size(146, 20);
            this.txtTavlingStatus.TabIndex = 36;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(320, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(74, 13);
            this.lblStatus.TabIndex = 35;
            this.lblStatus.Text = "Rubrik_Status";
            // 
            // dtpStartdatum
            // 
            this.dtpStartdatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartdatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartdatum.Location = new System.Drawing.Point(9, 30);
            this.dtpStartdatum.Name = "dtpStartdatum";
            this.dtpStartdatum.Size = new System.Drawing.Size(80, 20);
            this.dtpStartdatum.TabIndex = 33;
            // 
            // lblStartdatum
            // 
            this.lblStartdatum.AutoSize = true;
            this.lblStartdatum.Location = new System.Drawing.Point(6, 9);
            this.lblStartdatum.Name = "lblStartdatum";
            this.lblStartdatum.Size = new System.Drawing.Size(95, 13);
            this.lblStartdatum.TabIndex = 32;
            this.lblStartdatum.Text = "Rubrik_Startdatum";
            // 
            // txtTavlingNamn
            // 
            this.txtTavlingNamn.Location = new System.Drawing.Point(110, 30);
            this.txtTavlingNamn.Name = "txtTavlingNamn";
            this.txtTavlingNamn.Size = new System.Drawing.Size(175, 20);
            this.txtTavlingNamn.TabIndex = 34;
            // 
            // lblNamn
            // 
            this.lblNamn.AutoSize = true;
            this.lblNamn.Location = new System.Drawing.Point(107, 9);
            this.lblNamn.Name = "lblNamn";
            this.lblNamn.Size = new System.Drawing.Size(62, 13);
            this.lblNamn.TabIndex = 31;
            this.lblNamn.Text = "Text_Namn";
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(174, 283);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 40;
            // 
            // fönsterhanterare1
            // 
            this.fönsterhanterare1.Location = new System.Drawing.Point(19, 296);
            this.fönsterhanterare1.Name = "fönsterhanterare1";
            this.fönsterhanterare1.Size = new System.Drawing.Size(150, 10);
            this.fönsterhanterare1.TabIndex = 41;
            // 
            // Rank
            // 
            this.Rank.HeaderText = "Rubrik_Placering";
            this.Rank.Name = "Rank";
            this.Rank.Width = 60;
            // 
            // Spelarnamn
            // 
            this.Spelarnamn.HeaderText = "Rubrik_Spelare";
            this.Spelarnamn.Name = "Spelarnamn";
            // 
            // R1
            // 
            this.R1.HeaderText = "Text_R1";
            this.R1.Name = "R1";
            this.R1.Width = 50;
            // 
            // R2
            // 
            this.R2.HeaderText = "Text_R2";
            this.R2.Name = "R2";
            this.R2.Width = 50;
            // 
            // R3
            // 
            this.R3.HeaderText = "Text_R3";
            this.R3.Name = "R3";
            this.R3.Width = 50;
            // 
            // R4
            // 
            this.R4.HeaderText = "Text_R4";
            this.R4.Name = "R4";
            this.R4.Width = 50;
            // 
            // R5
            // 
            this.R5.HeaderText = "Text_R5";
            this.R5.Name = "R5";
            this.R5.Width = 50;
            // 
            // R6
            // 
            this.R6.HeaderText = "Text_R6";
            this.R6.Name = "R6";
            this.R6.Width = 50;
            // 
            // Totalt
            // 
            this.Totalt.HeaderText = "Text_Totalt";
            this.Totalt.Name = "Totalt";
            this.Totalt.Width = 50;
            // 
            // R2A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 318);
            this.Controls.Add(this.fönsterhanterare1);
            this.Controls.Add(this.knappkontroller1);
            this.Controls.Add(this.gbxTotalt);
            this.Controls.Add(this.txtTavlingStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dtpStartdatum);
            this.Controls.Add(this.lblStartdatum);
            this.Controls.Add(this.txtTavlingNamn);
            this.Controls.Add(this.lblNamn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "R2A";
            this.Text = "Titel_R2A";
            this.Load += new System.EventHandler(this.R2A_Load);
            this.gbxTotalt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwR2A)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxTotalt;
        private System.Windows.Forms.DataGridView dgwR2A;
        private System.Windows.Forms.TextBox txtTavlingStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DateTimePicker dtpStartdatum;
        private System.Windows.Forms.Label lblStartdatum;
        private System.Windows.Forms.TextBox txtTavlingNamn;
        private System.Windows.Forms.Label lblNamn;
        private Kontroller.Knappkontroller knappkontroller1;
        private Kontroller.Fönsterhanterare fönsterhanterare1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spelarnamn;
        private System.Windows.Forms.DataGridViewTextBoxColumn R1;
        private System.Windows.Forms.DataGridViewTextBoxColumn R2;
        private System.Windows.Forms.DataGridViewTextBoxColumn R3;
        private System.Windows.Forms.DataGridViewTextBoxColumn R4;
        private System.Windows.Forms.DataGridViewTextBoxColumn R5;
        private System.Windows.Forms.DataGridViewTextBoxColumn R6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Totalt;
    }
}