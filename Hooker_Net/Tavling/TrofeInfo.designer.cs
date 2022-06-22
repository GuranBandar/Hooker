namespace Hooker_GUI
{
    partial class TrofeInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrofeInfo));
            this.txtBana = new System.Windows.Forms.TextBox();
            this.lblBana = new System.Windows.Forms.Label();
            this.txtGolfklubb = new System.Windows.Forms.TextBox();
            this.lblGolfklubb = new System.Windows.Forms.Label();
            this.gbxTotalt = new System.Windows.Forms.GroupBox();
            this.dgwTrofen = new System.Windows.Forms.DataGridView();
            this.Rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spelarnamn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FörstaNio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AndraNio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TredjeNio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FjärdeNio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FemteNio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SjätteNio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SjundeNio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ÅttondeNio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brutto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Netto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxKnappkontrollen = new System.Windows.Forms.GroupBox();
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.txtTavlingStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dtpStartdatum = new System.Windows.Forms.DateTimePicker();
            this.lblStartdatum = new System.Windows.Forms.Label();
            this.txtTavlingNamn = new System.Windows.Forms.TextBox();
            this.lblNamn = new System.Windows.Forms.Label();
            this.fönsterhanterare1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            this.gbxTotalt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTrofen)).BeginInit();
            this.gbxKnappkontrollen.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBana
            // 
            this.txtBana.Location = new System.Drawing.Point(476, 28);
            this.txtBana.Name = "txtBana";
            this.txtBana.ReadOnly = true;
            this.txtBana.Size = new System.Drawing.Size(114, 20);
            this.txtBana.TabIndex = 37;
            // 
            // lblBana
            // 
            this.lblBana.AutoSize = true;
            this.lblBana.Location = new System.Drawing.Point(473, 7);
            this.lblBana.Name = "lblBana";
            this.lblBana.Size = new System.Drawing.Size(59, 13);
            this.lblBana.TabIndex = 36;
            this.lblBana.Text = "Text_Bana";
            // 
            // txtGolfklubb
            // 
            this.txtGolfklubb.Location = new System.Drawing.Point(308, 28);
            this.txtGolfklubb.Name = "txtGolfklubb";
            this.txtGolfklubb.ReadOnly = true;
            this.txtGolfklubb.Size = new System.Drawing.Size(155, 20);
            this.txtGolfklubb.TabIndex = 35;
            // 
            // lblGolfklubb
            // 
            this.lblGolfklubb.AutoSize = true;
            this.lblGolfklubb.Location = new System.Drawing.Point(305, 7);
            this.lblGolfklubb.Name = "lblGolfklubb";
            this.lblGolfklubb.Size = new System.Drawing.Size(79, 13);
            this.lblGolfklubb.TabIndex = 34;
            this.lblGolfklubb.Text = "Text_Golfklubb";
            // 
            // gbxTotalt
            // 
            this.gbxTotalt.Controls.Add(this.dgwTrofen);
            this.gbxTotalt.Location = new System.Drawing.Point(7, 54);
            this.gbxTotalt.Name = "gbxTotalt";
            this.gbxTotalt.Size = new System.Drawing.Size(733, 280);
            this.gbxTotalt.TabIndex = 29;
            this.gbxTotalt.TabStop = false;
            this.gbxTotalt.Text = "Text_Totalt";
            // 
            // dgwTrofen
            // 
            this.dgwTrofen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwTrofen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rank,
            this.Spelarnamn,
            this.FörstaNio,
            this.AndraNio,
            this.TredjeNio,
            this.FjärdeNio,
            this.FemteNio,
            this.SjätteNio,
            this.SjundeNio,
            this.ÅttondeNio,
            this.Brutto,
            this.Netto});
            this.dgwTrofen.Location = new System.Drawing.Point(7, 20);
            this.dgwTrofen.Name = "dgwTrofen";
            this.dgwTrofen.Size = new System.Drawing.Size(720, 254);
            this.dgwTrofen.TabIndex = 0;
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
            // FörstaNio
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FörstaNio.DefaultCellStyle = dataGridViewCellStyle1;
            this.FörstaNio.HeaderText = "Text_FörstaNio";
            this.FörstaNio.Name = "FörstaNio";
            this.FörstaNio.Width = 50;
            // 
            // AndraNio
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AndraNio.DefaultCellStyle = dataGridViewCellStyle2;
            this.AndraNio.HeaderText = "Text_AndraNio";
            this.AndraNio.Name = "AndraNio";
            this.AndraNio.Width = 50;
            // 
            // TredjeNio
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TredjeNio.DefaultCellStyle = dataGridViewCellStyle3;
            this.TredjeNio.HeaderText = "Text_TredjeNio";
            this.TredjeNio.Name = "TredjeNio";
            this.TredjeNio.Width = 50;
            // 
            // FjärdeNio
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FjärdeNio.DefaultCellStyle = dataGridViewCellStyle4;
            this.FjärdeNio.HeaderText = "Text_FjärdeNio";
            this.FjärdeNio.Name = "FjärdeNio";
            this.FjärdeNio.Width = 50;
            // 
            // FemteNio
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FemteNio.DefaultCellStyle = dataGridViewCellStyle5;
            this.FemteNio.HeaderText = "Text_FemteNio";
            this.FemteNio.Name = "FemteNio";
            this.FemteNio.Width = 50;
            // 
            // SjätteNio
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SjätteNio.DefaultCellStyle = dataGridViewCellStyle6;
            this.SjätteNio.HeaderText = "Text_SjätteNio";
            this.SjätteNio.Name = "SjätteNio";
            this.SjätteNio.Width = 50;
            // 
            // SjundeNio
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SjundeNio.DefaultCellStyle = dataGridViewCellStyle7;
            this.SjundeNio.HeaderText = "Text_SjundeNio";
            this.SjundeNio.Name = "SjundeNio";
            this.SjundeNio.Width = 50;
            // 
            // ÅttondeNio
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ÅttondeNio.DefaultCellStyle = dataGridViewCellStyle8;
            this.ÅttondeNio.HeaderText = "Text_ÅttondeNio";
            this.ÅttondeNio.Name = "ÅttondeNio";
            this.ÅttondeNio.Width = 50;
            // 
            // Brutto
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Brutto.DefaultCellStyle = dataGridViewCellStyle9;
            this.Brutto.HeaderText = "Text_Brutto";
            this.Brutto.Name = "Brutto";
            this.Brutto.Width = 50;
            // 
            // Netto
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Netto.DefaultCellStyle = dataGridViewCellStyle10;
            this.Netto.HeaderText = "Text_Netto";
            this.Netto.Name = "Netto";
            this.Netto.Width = 50;
            // 
            // gbxKnappkontrollen
            // 
            this.gbxKnappkontrollen.Controls.Add(this.knappkontroller1);
            this.gbxKnappkontrollen.Location = new System.Drawing.Point(-8, 337);
            this.gbxKnappkontrollen.Name = "gbxKnappkontrollen";
            this.gbxKnappkontrollen.Size = new System.Drawing.Size(754, 49);
            this.gbxKnappkontrollen.TabIndex = 28;
            this.gbxKnappkontrollen.TabStop = false;
            this.gbxKnappkontrollen.Text = "Text_Blank";
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(331, 7);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 0;
            // 
            // txtTavlingStatus
            // 
            this.txtTavlingStatus.Location = new System.Drawing.Point(619, 28);
            this.txtTavlingStatus.Name = "txtTavlingStatus";
            this.txtTavlingStatus.Size = new System.Drawing.Size(71, 20);
            this.txtTavlingStatus.TabIndex = 24;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(616, 7);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(74, 13);
            this.lblStatus.TabIndex = 23;
            this.lblStatus.Text = "Rubrik_Status";
            // 
            // dtpStartdatum
            // 
            this.dtpStartdatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartdatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartdatum.Location = new System.Drawing.Point(7, 28);
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
            this.txtTavlingNamn.Location = new System.Drawing.Point(108, 28);
            this.txtTavlingNamn.Name = "txtTavlingNamn";
            this.txtTavlingNamn.Size = new System.Drawing.Size(175, 20);
            this.txtTavlingNamn.TabIndex = 22;
            // 
            // lblNamn
            // 
            this.lblNamn.AutoSize = true;
            this.lblNamn.Location = new System.Drawing.Point(105, 7);
            this.lblNamn.Name = "lblNamn";
            this.lblNamn.Size = new System.Drawing.Size(62, 13);
            this.lblNamn.TabIndex = 19;
            this.lblNamn.Text = "Text_Namn";
            // 
            // fönsterhanterare1
            // 
            this.fönsterhanterare1.Location = new System.Drawing.Point(74, 340);
            this.fönsterhanterare1.Name = "fönsterhanterare1";
            this.fönsterhanterare1.Size = new System.Drawing.Size(150, 10);
            this.fönsterhanterare1.TabIndex = 27;
            // 
            // TrofeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 383);
            this.Controls.Add(this.txtBana);
            this.Controls.Add(this.lblBana);
            this.Controls.Add(this.txtGolfklubb);
            this.Controls.Add(this.lblGolfklubb);
            this.Controls.Add(this.gbxTotalt);
            this.Controls.Add(this.gbxKnappkontrollen);
            this.Controls.Add(this.fönsterhanterare1);
            this.Controls.Add(this.txtTavlingStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dtpStartdatum);
            this.Controls.Add(this.lblStartdatum);
            this.Controls.Add(this.txtTavlingNamn);
            this.Controls.Add(this.lblNamn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrofeInfo";
            this.Text = "Titel_Trofen";
            this.Load += new System.EventHandler(this.Trofen_Load);
            this.gbxTotalt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwTrofen)).EndInit();
            this.gbxKnappkontrollen.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTavlingStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DateTimePicker dtpStartdatum;
        private System.Windows.Forms.Label lblStartdatum;
        private System.Windows.Forms.TextBox txtTavlingNamn;
        private System.Windows.Forms.Label lblNamn;
        private Kontroller.Fönsterhanterare fönsterhanterare1;
        private System.Windows.Forms.GroupBox gbxKnappkontrollen;
        private Kontroller.Knappkontroller knappkontroller1;
        private System.Windows.Forms.GroupBox gbxTotalt;
        private System.Windows.Forms.DataGridView dgwTrofen;
        private System.Windows.Forms.TextBox txtBana;
        private System.Windows.Forms.Label lblBana;
        private System.Windows.Forms.TextBox txtGolfklubb;
        private System.Windows.Forms.Label lblGolfklubb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spelarnamn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FörstaNio;
        private System.Windows.Forms.DataGridViewTextBoxColumn AndraNio;
        private System.Windows.Forms.DataGridViewTextBoxColumn TredjeNio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FjärdeNio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FemteNio;
        private System.Windows.Forms.DataGridViewTextBoxColumn SjätteNio;
        private System.Windows.Forms.DataGridViewTextBoxColumn SjundeNio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ÅttondeNio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brutto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Netto;
    }
}