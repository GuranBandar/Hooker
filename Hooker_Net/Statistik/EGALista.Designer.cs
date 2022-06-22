namespace Hooker_GUI
{
    partial class EGALista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EGALista));
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.hanteraFönster1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            this.lblExaktHcp = new System.Windows.Forms.Label();
            this.txtExaktHcp = new System.Windows.Forms.TextBox();
            this.Hcpres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Poang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spelhcp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Par = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hcprond = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Slope = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RundaNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwEGALista = new System.Windows.Forms.DataGridView();
            this.cboSpelare = new System.Windows.Forms.ComboBox();
            this.lblSpelarNamn = new System.Windows.Forms.Label();
            this.txtPrognosEGA = new System.Windows.Forms.TextBox();
            this.lblPrognosEGA = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwEGALista)).BeginInit();
            this.SuspendLayout();
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(371, 583);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 3;
            this.knappkontroller1.OnKnapp0Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp0ClickEventHandler(this.knappkontroller1_OnKnapp0Click);
            this.knappkontroller1.OnKnapp1Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp1ClickEventHandler(this.knappkontroller1_OnKnapp1Click);
            this.knappkontroller1.OnKnapp2Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp2ClickEventHandler(this.knappkontroller1_OnKnapp2Click);
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.knappkontroller1_OnKnapp3Click);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // hanteraFönster1
            // 
            this.hanteraFönster1.Location = new System.Drawing.Point(23, 592);
            this.hanteraFönster1.Name = "hanteraFönster1";
            this.hanteraFönster1.Size = new System.Drawing.Size(86, 12);
            this.hanteraFönster1.TabIndex = 4;
            // 
            // lblExaktHcp
            // 
            this.lblExaktHcp.AutoSize = true;
            this.lblExaktHcp.Location = new System.Drawing.Point(229, 22);
            this.lblExaktHcp.Name = "lblExaktHcp";
            this.lblExaktHcp.Size = new System.Drawing.Size(106, 13);
            this.lblExaktHcp.TabIndex = 112;
            this.lblExaktHcp.Text = "Radrubrik_ExaktHcp";
            // 
            // txtExaktHcp
            // 
            this.txtExaktHcp.Location = new System.Drawing.Point(294, 18);
            this.txtExaktHcp.Name = "txtExaktHcp";
            this.txtExaktHcp.ReadOnly = true;
            this.txtExaktHcp.Size = new System.Drawing.Size(36, 20);
            this.txtExaktHcp.TabIndex = 113;
            // 
            // Hcpres
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Hcpres.DefaultCellStyle = dataGridViewCellStyle1;
            this.Hcpres.HeaderText = "Rubrik_HcpRes";
            this.Hcpres.Name = "Hcpres";
            this.Hcpres.ReadOnly = true;
            this.Hcpres.Width = 45;
            // 
            // Poang
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Poang.DefaultCellStyle = dataGridViewCellStyle2;
            this.Poang.HeaderText = "Rubrik_Poäng";
            this.Poang.Name = "Poang";
            this.Poang.ReadOnly = true;
            this.Poang.Width = 45;
            // 
            // Spelhcp
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Spelhcp.DefaultCellStyle = dataGridViewCellStyle3;
            this.Spelhcp.HeaderText = "Text_Spel_Hcp";
            this.Spelhcp.Name = "Spelhcp";
            this.Spelhcp.ReadOnly = true;
            this.Spelhcp.Width = 50;
            // 
            // Par
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Par.DefaultCellStyle = dataGridViewCellStyle4;
            this.Par.HeaderText = "Rubrik_Par";
            this.Par.Name = "Par";
            this.Par.ReadOnly = true;
            this.Par.Width = 40;
            // 
            // Hcprond
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Hcprond.DefaultCellStyle = dataGridViewCellStyle5;
            this.Hcprond.HeaderText = "Text_Hcprond";
            this.Hcprond.Name = "Hcprond";
            this.Hcprond.Width = 50;
            // 
            // CR
            // 
            this.CR.HeaderText = "Text_CR";
            this.CR.Name = "CR";
            this.CR.ReadOnly = true;
            this.CR.Width = 40;
            // 
            // Slope
            // 
            this.Slope.HeaderText = "Text_Slope";
            this.Slope.Name = "Slope";
            this.Slope.ReadOnly = true;
            this.Slope.Width = 50;
            // 
            // Bana
            // 
            this.Bana.HeaderText = "Rubrik_Bana";
            this.Bana.Name = "Bana";
            this.Bana.ReadOnly = true;
            this.Bana.Width = 275;
            // 
            // Datum
            // 
            this.Datum.HeaderText = "Rubrik_Datum";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            this.Datum.Width = 70;
            // 
            // Nr
            // 
            this.Nr.HeaderText = "Rubrik_Nr";
            this.Nr.Name = "Nr";
            this.Nr.ReadOnly = true;
            this.Nr.Width = 40;
            // 
            // RundaNr
            // 
            this.RundaNr.HeaderText = "RundaNr";
            this.RundaNr.Name = "RundaNr";
            this.RundaNr.Visible = false;
            // 
            // dgwEGALista
            // 
            this.dgwEGALista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwEGALista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RundaNr,
            this.Nr,
            this.Datum,
            this.Bana,
            this.Slope,
            this.CR,
            this.Hcprond,
            this.Par,
            this.Spelhcp,
            this.Poang,
            this.Hcpres});
            this.dgwEGALista.Location = new System.Drawing.Point(12, 59);
            this.dgwEGALista.Name = "dgwEGALista";
            this.dgwEGALista.Size = new System.Drawing.Size(776, 518);
            this.dgwEGALista.TabIndex = 2;
            this.dgwEGALista.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgwEGALista_MouseDown);
            // 
            // cboSpelare
            // 
            this.cboSpelare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSpelare.FormattingEnabled = true;
            this.cboSpelare.Location = new System.Drawing.Point(91, 18);
            this.cboSpelare.Name = "cboSpelare";
            this.cboSpelare.Size = new System.Drawing.Size(131, 21);
            this.cboSpelare.TabIndex = 1;
            this.cboSpelare.SelectedIndexChanged += new System.EventHandler(this.cboSpelare_SelectedIndexChanged);
            // 
            // lblSpelarNamn
            // 
            this.lblSpelarNamn.AutoSize = true;
            this.lblSpelarNamn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpelarNamn.Location = new System.Drawing.Point(16, 22);
            this.lblSpelarNamn.Name = "lblSpelarNamn";
            this.lblSpelarNamn.Size = new System.Drawing.Size(95, 13);
            this.lblSpelarNamn.TabIndex = 106;
            this.lblSpelarNamn.Text = "Radrubrik_Spelare";
            // 
            // txtPrognosEGA
            // 
            this.txtPrognosEGA.Location = new System.Drawing.Point(597, 18);
            this.txtPrognosEGA.Name = "txtPrognosEGA";
            this.txtPrognosEGA.ReadOnly = true;
            this.txtPrognosEGA.Size = new System.Drawing.Size(33, 20);
            this.txtPrognosEGA.TabIndex = 115;
            // 
            // lblPrognosEGA
            // 
            this.lblPrognosEGA.AutoSize = true;
            this.lblPrognosEGA.Location = new System.Drawing.Point(368, 22);
            this.lblPrognosEGA.Name = "lblPrognosEGA";
            this.lblPrognosEGA.Size = new System.Drawing.Size(95, 13);
            this.lblPrognosEGA.TabIndex = 114;
            this.lblPrognosEGA.Text = "Text_PrognosEGA";
            // 
            // EGALista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 622);
            this.Controls.Add(this.txtPrognosEGA);
            this.Controls.Add(this.lblPrognosEGA);
            this.Controls.Add(this.txtExaktHcp);
            this.Controls.Add(this.lblExaktHcp);
            this.Controls.Add(this.cboSpelare);
            this.Controls.Add(this.lblSpelarNamn);
            this.Controls.Add(this.hanteraFönster1);
            this.Controls.Add(this.knappkontroller1);
            this.Controls.Add(this.dgwEGALista);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EGALista";
            this.Text = "Titel_EGALista";
            this.Load += new System.EventHandler(this.EGALista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwEGALista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Kontroller.Knappkontroller knappkontroller1;
        private Kontroller.Fönsterhanterare hanteraFönster1;
        private System.Windows.Forms.Label lblExaktHcp;
        private System.Windows.Forms.TextBox txtExaktHcp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hcpres;
        private System.Windows.Forms.DataGridViewTextBoxColumn Poang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spelhcp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Par;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hcprond;
        private System.Windows.Forms.DataGridViewTextBoxColumn CR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Slope;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bana;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nr;
        private System.Windows.Forms.DataGridViewTextBoxColumn RundaNr;
        private System.Windows.Forms.DataGridView dgwEGALista;
        private System.Windows.Forms.ComboBox cboSpelare;
        private System.Windows.Forms.Label lblSpelarNamn;
        private System.Windows.Forms.TextBox txtPrognosEGA;
        private System.Windows.Forms.Label lblPrognosEGA;
    }
}