namespace Hooker_GUI
{
    partial class SökBana
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SökBana));
            this.gbxBana = new System.Windows.Forms.GroupBox();
            this.cboDistrikt = new System.Windows.Forms.ComboBox();
            this.cboLand = new System.Windows.Forms.ComboBox();
            this.lblDistrikt = new System.Windows.Forms.Label();
            this.lblLand = new System.Windows.Forms.Label();
            this.lblOrt = new System.Windows.Forms.Label();
            this.lblNamn = new System.Windows.Forms.Label();
            this.txtOrt = new System.Windows.Forms.TextBox();
            this.txtNamn = new System.Windows.Forms.TextBox();
            this.dgwSökBana = new System.Windows.Forms.DataGridView();
            this.lblAntal = new System.Windows.Forms.Label();
            this.txtAntal = new System.Windows.Forms.TextBox();
            this.fönsterhanterare1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.BanaNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GolfklubbNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Golfklubb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Namn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aktuell = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Notering = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distrikt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Land = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxBana.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSökBana)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxBana
            // 
            this.gbxBana.Controls.Add(this.cboDistrikt);
            this.gbxBana.Controls.Add(this.cboLand);
            this.gbxBana.Controls.Add(this.lblDistrikt);
            this.gbxBana.Controls.Add(this.lblLand);
            this.gbxBana.Controls.Add(this.lblOrt);
            this.gbxBana.Controls.Add(this.lblNamn);
            this.gbxBana.Controls.Add(this.txtOrt);
            this.gbxBana.Controls.Add(this.txtNamn);
            this.gbxBana.Location = new System.Drawing.Point(5, 2);
            this.gbxBana.Name = "gbxBana";
            this.gbxBana.Size = new System.Drawing.Size(524, 108);
            this.gbxBana.TabIndex = 1;
            this.gbxBana.TabStop = false;
            this.gbxBana.Text = "Text_Bana";
            // 
            // cboDistrikt
            // 
            this.cboDistrikt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrikt.FormattingEnabled = true;
            this.cboDistrikt.Location = new System.Drawing.Point(266, 80);
            this.cboDistrikt.Name = "cboDistrikt";
            this.cboDistrikt.Size = new System.Drawing.Size(250, 21);
            this.cboDistrikt.Sorted = true;
            this.cboDistrikt.TabIndex = 9;
            // 
            // cboLand
            // 
            this.cboLand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLand.FormattingEnabled = true;
            this.cboLand.Location = new System.Drawing.Point(266, 35);
            this.cboLand.Name = "cboLand";
            this.cboLand.Size = new System.Drawing.Size(250, 21);
            this.cboLand.Sorted = true;
            this.cboLand.TabIndex = 8;
            this.cboLand.SelectedIndexChanged += new System.EventHandler(this.cboLand_SelectedIndexChanged);
            // 
            // lblDistrikt
            // 
            this.lblDistrikt.AutoSize = true;
            this.lblDistrikt.Location = new System.Drawing.Point(266, 63);
            this.lblDistrikt.Name = "lblDistrikt";
            this.lblDistrikt.Size = new System.Drawing.Size(66, 13);
            this.lblDistrikt.TabIndex = 7;
            this.lblDistrikt.Text = "Text_Distrikt";
            // 
            // lblLand
            // 
            this.lblLand.AutoSize = true;
            this.lblLand.Location = new System.Drawing.Point(266, 19);
            this.lblLand.Name = "lblLand";
            this.lblLand.Size = new System.Drawing.Size(58, 13);
            this.lblLand.TabIndex = 6;
            this.lblLand.Text = "Text_Land";
            // 
            // lblOrt
            // 
            this.lblOrt.AutoSize = true;
            this.lblOrt.Location = new System.Drawing.Point(10, 63);
            this.lblOrt.Name = "lblOrt";
            this.lblOrt.Size = new System.Drawing.Size(48, 13);
            this.lblOrt.TabIndex = 3;
            this.lblOrt.Text = "Text_Ort";
            // 
            // lblNamn
            // 
            this.lblNamn.AutoSize = true;
            this.lblNamn.Location = new System.Drawing.Point(10, 19);
            this.lblNamn.Name = "lblNamn";
            this.lblNamn.Size = new System.Drawing.Size(79, 13);
            this.lblNamn.TabIndex = 2;
            this.lblNamn.Text = "Text_Golfklubb";
            // 
            // txtOrt
            // 
            this.txtOrt.Location = new System.Drawing.Point(10, 80);
            this.txtOrt.Name = "txtOrt";
            this.txtOrt.Size = new System.Drawing.Size(250, 20);
            this.txtOrt.TabIndex = 1;
            // 
            // txtNamn
            // 
            this.txtNamn.Location = new System.Drawing.Point(10, 36);
            this.txtNamn.Name = "txtNamn";
            this.txtNamn.Size = new System.Drawing.Size(250, 20);
            this.txtNamn.TabIndex = 0;
            // 
            // dgwSökBana
            // 
            this.dgwSökBana.AllowUserToAddRows = false;
            this.dgwSökBana.AllowUserToDeleteRows = false;
            this.dgwSökBana.AllowUserToResizeColumns = false;
            this.dgwSökBana.AllowUserToResizeRows = false;
            this.dgwSökBana.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgwSökBana.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwSökBana.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BanaNr,
            this.GolfklubbNr,
            this.Golfklubb,
            this.Namn,
            this.Aktuell,
            this.Notering,
            this.Distrikt,
            this.Land});
            this.dgwSökBana.Location = new System.Drawing.Point(5, 143);
            this.dgwSökBana.MultiSelect = false;
            this.dgwSökBana.Name = "dgwSökBana";
            this.dgwSökBana.RowTemplate.Height = 24;
            this.dgwSökBana.Size = new System.Drawing.Size(666, 194);
            this.dgwSökBana.TabIndex = 4;
            this.dgwSökBana.DoubleClick += new System.EventHandler(this.dgwSökBana_DoubleClick);
            // 
            // lblAntal
            // 
            this.lblAntal.AutoSize = true;
            this.lblAntal.Location = new System.Drawing.Point(12, 117);
            this.lblAntal.Name = "lblAntal";
            this.lblAntal.Size = new System.Drawing.Size(83, 13);
            this.lblAntal.TabIndex = 5;
            this.lblAntal.Text = "Radrubrik_Antal";
            // 
            // txtAntal
            // 
            this.txtAntal.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtAntal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAntal.Location = new System.Drawing.Point(62, 118);
            this.txtAntal.Name = "txtAntal";
            this.txtAntal.Size = new System.Drawing.Size(100, 13);
            this.txtAntal.TabIndex = 6;
            // 
            // fönsterhanterare1
            // 
            this.fönsterhanterare1.Location = new System.Drawing.Point(100, 349);
            this.fönsterhanterare1.Name = "fönsterhanterare1";
            this.fönsterhanterare1.Size = new System.Drawing.Size(150, 22);
            this.fönsterhanterare1.TabIndex = 7;
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(256, 343);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 8;
            this.knappkontroller1.OnKnapp1Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp1ClickEventHandler(this.knappkontroller1_OnKnapp1Click);
            this.knappkontroller1.OnKnapp2Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp2ClickEventHandler(this.knappkontroller1_OnKnapp2Click);
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.knappkontroller1_OnKnapp3Click);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // BanaNr
            // 
            this.BanaNr.HeaderText = "Text_BanaNr";
            this.BanaNr.Name = "BanaNr";
            this.BanaNr.Visible = false;
            // 
            // GolfklubbNr
            // 
            this.GolfklubbNr.HeaderText = "Text_GolfklubbNr";
            this.GolfklubbNr.Name = "GolfklubbNr";
            this.GolfklubbNr.Visible = false;
            // 
            // Golfklubb
            // 
            this.Golfklubb.HeaderText = "Text_Golfklubb";
            this.Golfklubb.Name = "Golfklubb";
            this.Golfklubb.Width = 120;
            // 
            // Namn
            // 
            this.Namn.HeaderText = "Text_Namn";
            this.Namn.Name = "Namn";
            this.Namn.Width = 130;
            // 
            // Aktuell
            // 
            this.Aktuell.HeaderText = "Rubrik_Aktuell";
            this.Aktuell.Name = "Aktuell";
            this.Aktuell.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Aktuell.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Aktuell.Width = 60;
            // 
            // Notering
            // 
            this.Notering.HeaderText = "Rubrik_Notering";
            this.Notering.Name = "Notering";
            this.Notering.Width = 130;
            // 
            // Distrikt
            // 
            this.Distrikt.HeaderText = "Text_Distrikt";
            this.Distrikt.Name = "Distrikt";
            this.Distrikt.Width = 80;
            // 
            // Land
            // 
            this.Land.HeaderText = "Text_Land";
            this.Land.Name = "Land";
            this.Land.Width = 80;
            // 
            // SökBana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 377);
            this.Controls.Add(this.knappkontroller1);
            this.Controls.Add(this.txtAntal);
            this.Controls.Add(this.lblAntal);
            this.Controls.Add(this.dgwSökBana);
            this.Controls.Add(this.gbxBana);
            this.Controls.Add(this.fönsterhanterare1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SökBana";
            this.Text = "Titel_SökBana";
            this.Activated += new System.EventHandler(this.SökBana_Activated);
            this.Load += new System.EventHandler(this.SökBana_Load);
            this.gbxBana.ResumeLayout(false);
            this.gbxBana.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSökBana)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxBana;
        private System.Windows.Forms.Label lblOrt;
        private System.Windows.Forms.Label lblNamn;
        private System.Windows.Forms.TextBox txtOrt;
        private System.Windows.Forms.TextBox txtNamn;
        private System.Windows.Forms.Label lblDistrikt;
        private System.Windows.Forms.Label lblLand;
        private System.Windows.Forms.DataGridView dgwSökBana;
        private System.Windows.Forms.Label lblAntal;
        private System.Windows.Forms.TextBox txtAntal;
        private System.Windows.Forms.ComboBox cboDistrikt;
        private System.Windows.Forms.ComboBox cboLand;
        private Hooker_GUI.Kontroller.Fönsterhanterare fönsterhanterare1;
        private Hooker_GUI.Kontroller.Knappkontroller knappkontroller1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BanaNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn GolfklubbNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Golfklubb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Namn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Aktuell;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notering;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distrikt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Land;
    }
}