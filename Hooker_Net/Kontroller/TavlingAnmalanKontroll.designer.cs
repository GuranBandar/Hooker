namespace Hooker_GUI.Kontroller
{
    partial class TavlingAnmalanKontroll
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxAnmälan = new System.Windows.Forms.GroupBox();
            this.dgwAnmalan = new System.Windows.Forms.DataGridView();
            this.SpelarID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anmalan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SpelarNamn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Golfklubb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hcp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Klass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KlassNamn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxAnmälan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAnmalan)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxAnmälan
            // 
            this.gbxAnmälan.Controls.Add(this.dgwAnmalan);
            this.gbxAnmälan.Location = new System.Drawing.Point(3, 3);
            this.gbxAnmälan.Name = "gbxAnmälan";
            this.gbxAnmälan.Size = new System.Drawing.Size(620, 130);
            this.gbxAnmälan.TabIndex = 1;
            this.gbxAnmälan.TabStop = false;
            this.gbxAnmälan.Text = "Text_TavlingAnmalan";
            // 
            // dgwAnmalan
            // 
            this.dgwAnmalan.AllowUserToAddRows = false;
            this.dgwAnmalan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwAnmalan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SpelarID,
            this.Anmalan,
            this.SpelarNamn,
            this.Golfklubb,
            this.Hcp,
            this.Klass,
            this.KlassNamn});
            this.dgwAnmalan.Location = new System.Drawing.Point(4, 17);
            this.dgwAnmalan.Name = "dgwAnmalan";
            this.dgwAnmalan.RowTemplate.Height = 24;
            this.dgwAnmalan.Size = new System.Drawing.Size(613, 117);
            this.dgwAnmalan.TabIndex = 0;
            this.dgwAnmalan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwAnmalan_CellContentClick);
            // 
            // SpelarID
            // 
            this.SpelarID.HeaderText = "SpelarID";
            this.SpelarID.Name = "SpelarID";
            this.SpelarID.ReadOnly = true;
            this.SpelarID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SpelarID.Visible = false;
            this.SpelarID.Width = 20;
            // 
            // Anmalan
            // 
            this.Anmalan.FalseValue = "0";
            this.Anmalan.HeaderText = "Text_Anmalan";
            this.Anmalan.Name = "Anmalan";
            this.Anmalan.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Anmalan.TrueValue = "1";
            this.Anmalan.Width = 75;
            // 
            // SpelarNamn
            // 
            this.SpelarNamn.HeaderText = "Rubrik_Spelare";
            this.SpelarNamn.Name = "SpelarNamn";
            this.SpelarNamn.ReadOnly = true;
            this.SpelarNamn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Golfklubb
            // 
            this.Golfklubb.HeaderText = "Text_Golfklubb";
            this.Golfklubb.Name = "Golfklubb";
            this.Golfklubb.ReadOnly = true;
            this.Golfklubb.Width = 150;
            // 
            // Hcp
            // 
            this.Hcp.HeaderText = "Text_Hcp";
            this.Hcp.Name = "Hcp";
            this.Hcp.ReadOnly = true;
            this.Hcp.Width = 75;
            // 
            // Klass
            // 
            this.Klass.HeaderText = "Text_Klass";
            this.Klass.Name = "Klass";
            this.Klass.Visible = false;
            this.Klass.Width = 10;
            // 
            // KlassNamn
            // 
            this.KlassNamn.HeaderText = "Text_Klass";
            this.KlassNamn.Name = "KlassNamn";
            this.KlassNamn.ReadOnly = true;
            this.KlassNamn.Width = 150;
            // 
            // TavlingAnmalanKontroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxAnmälan);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TavlingAnmalanKontroll";
            this.Size = new System.Drawing.Size(627, 142);
            this.gbxAnmälan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwAnmalan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwAnmalan;
        private System.Windows.Forms.GroupBox gbxAnmälan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpelarID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Anmalan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpelarNamn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Golfklubb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hcp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Klass;
        private System.Windows.Forms.DataGridViewTextBoxColumn KlassNamn;
    }
}
