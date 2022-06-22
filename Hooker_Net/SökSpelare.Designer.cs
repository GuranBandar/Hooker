namespace Hooker_GUI
{
    partial class SökSpelare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SökSpelare));
            this.hanteraFönster1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            this.lblNamn = new System.Windows.Forms.Label();
            this.txtNamn = new System.Windows.Forms.TextBox();
            this.txtLopnr = new System.Windows.Forms.TextBox();
            this.txtGolfID = new System.Windows.Forms.TextBox();
            this.lblGolfID = new System.Windows.Forms.Label();
            this.dgwSokSpelare = new System.Windows.Forms.DataGridView();
            this.SpelarID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Namn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GolfID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hcp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Golfklubb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hemmabana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSokSpelare)).BeginInit();
            this.SuspendLayout();
            // 
            // hanteraFönster1
            // 
            this.hanteraFönster1.Location = new System.Drawing.Point(289, 51);
            this.hanteraFönster1.Name = "hanteraFönster1";
            this.hanteraFönster1.Size = new System.Drawing.Size(150, 150);
            this.hanteraFönster1.TabIndex = 1;
            // 
            // lblNamn
            // 
            this.lblNamn.AutoSize = true;
            this.lblNamn.Location = new System.Drawing.Point(12, 9);
            this.lblNamn.Name = "lblNamn";
            this.lblNamn.Size = new System.Drawing.Size(62, 13);
            this.lblNamn.TabIndex = 4;
            this.lblNamn.Text = "Text_Namn";
            // 
            // txtNamn
            // 
            this.txtNamn.Location = new System.Drawing.Point(12, 26);
            this.txtNamn.Name = "txtNamn";
            this.txtNamn.Size = new System.Drawing.Size(250, 20);
            this.txtNamn.TabIndex = 3;
            // 
            // txtLopnr
            // 
            this.txtLopnr.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLopnr.Location = new System.Drawing.Point(487, 26);
            this.txtLopnr.MaxLength = 3;
            this.txtLopnr.Name = "txtLopnr";
            this.txtLopnr.Size = new System.Drawing.Size(30, 20);
            this.txtLopnr.TabIndex = 6;
            // 
            // txtGolfID
            // 
            this.txtGolfID.AcceptsReturn = true;
            this.txtGolfID.BackColor = System.Drawing.SystemColors.Window;
            this.txtGolfID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGolfID.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGolfID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGolfID.Location = new System.Drawing.Point(430, 26);
            this.txtGolfID.MaxLength = 6;
            this.txtGolfID.Name = "txtGolfID";
            this.txtGolfID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtGolfID.Size = new System.Drawing.Size(50, 20);
            this.txtGolfID.TabIndex = 5;
            // 
            // lblGolfID
            // 
            this.lblGolfID.AutoSize = true;
            this.lblGolfID.Location = new System.Drawing.Point(427, 9);
            this.lblGolfID.Name = "lblGolfID";
            this.lblGolfID.Size = new System.Drawing.Size(64, 13);
            this.lblGolfID.TabIndex = 7;
            this.lblGolfID.Text = "Text_GolfID";
            // 
            // dgwSokSpelare
            // 
            this.dgwSokSpelare.AllowUserToAddRows = false;
            this.dgwSokSpelare.AllowUserToDeleteRows = false;
            this.dgwSokSpelare.AllowUserToResizeColumns = false;
            this.dgwSokSpelare.AllowUserToResizeRows = false;
            this.dgwSokSpelare.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgwSokSpelare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwSokSpelare.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SpelarID,
            this.Namn,
            this.GolfID,
            this.Hcp,
            this.Golfklubb,
            this.Hemmabana});
            this.dgwSokSpelare.Location = new System.Drawing.Point(12, 63);
            this.dgwSokSpelare.Name = "dgwSokSpelare";
            this.dgwSokSpelare.RowTemplate.Height = 24;
            this.dgwSokSpelare.Size = new System.Drawing.Size(505, 220);
            this.dgwSokSpelare.TabIndex = 8;
            this.dgwSokSpelare.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // SpelarID
            // 
            this.SpelarID.HeaderText = "Column1";
            this.SpelarID.Name = "SpelarID";
            this.SpelarID.ReadOnly = true;
            this.SpelarID.Visible = false;
            // 
            // Namn
            // 
            this.Namn.HeaderText = "Text_Namn";
            this.Namn.Name = "Namn";
            // 
            // GolfID
            // 
            this.GolfID.HeaderText = "Text_GolfID";
            this.GolfID.Name = "GolfID";
            this.GolfID.Width = 80;
            // 
            // Hcp
            // 
            this.Hcp.HeaderText = "Text_Hcp";
            this.Hcp.Name = "Hcp";
            this.Hcp.Width = 40;
            // 
            // Golfklubb
            // 
            this.Golfklubb.HeaderText = "Text_Golfklubb";
            this.Golfklubb.Name = "Golfklubb";
            this.Golfklubb.Width = 120;
            // 
            // Hemmabana
            // 
            this.Hemmabana.HeaderText = "Text_Hemmabana";
            this.Hemmabana.Name = "Hemmabana";
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(105, 289);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 9;
            this.knappkontroller1.OnKnapp0Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp0ClickEventHandler(this.Knappkontroller1_OnKnapp0Click);
            this.knappkontroller1.OnKnapp1Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp1ClickEventHandler(this.Knappkontroller1_OnKnapp1Click_1);
            this.knappkontroller1.OnKnapp2Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp2ClickEventHandler(this.Knappkontroller1_OnKnapp2Click_1);
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.Knappkontroller1_OnKnapp3Click_1);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.Knappkontroller1_OnKnapp4Click_1);
            // 
            // SökSpelare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 332);
            this.Controls.Add(this.knappkontroller1);
            this.Controls.Add(this.dgwSokSpelare);
            this.Controls.Add(this.lblGolfID);
            this.Controls.Add(this.txtLopnr);
            this.Controls.Add(this.txtGolfID);
            this.Controls.Add(this.lblNamn);
            this.Controls.Add(this.txtNamn);
            this.Controls.Add(this.hanteraFönster1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SökSpelare";
            this.Text = "Titel_SökSpelare";
            this.Load += new System.EventHandler(this.SökSpelare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwSokSpelare)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hooker_GUI.Kontroller.Fönsterhanterare hanteraFönster1;
        private System.Windows.Forms.Label lblNamn;
        private System.Windows.Forms.TextBox txtNamn;
        private System.Windows.Forms.TextBox txtLopnr;
        private System.Windows.Forms.TextBox txtGolfID;
        private System.Windows.Forms.Label lblGolfID;
        private System.Windows.Forms.DataGridView dgwSokSpelare;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpelarID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Namn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GolfID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hcp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Golfklubb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hemmabana;
        private Kontroller.Knappkontroller knappkontroller1;
    }
}