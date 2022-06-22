namespace Hooker_GUI
{
    partial class SökRunda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SökRunda));
            this.gbxKnappkontroll = new System.Windows.Forms.GroupBox();
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.hanteraFönster1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            this.dgwSökRunda = new System.Windows.Forms.DataGridView();
            this.lblAntal = new System.Windows.Forms.Label();
            this.txtAntal = new System.Windows.Forms.TextBox();
            this.statistikHuvudKontroll1 = new Hooker_GUI.Kontroller.StatistikHuvudKontroll();
            this.RundaNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GolfklubbNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spelare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Poäng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Slag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notering = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxKnappkontroll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSökRunda)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxKnappkontroll
            // 
            this.gbxKnappkontroll.Controls.Add(this.knappkontroller1);
            this.gbxKnappkontroll.Controls.Add(this.hanteraFönster1);
            this.gbxKnappkontroll.Location = new System.Drawing.Point(126, 335);
            this.gbxKnappkontroll.Name = "gbxKnappkontroll";
            this.gbxKnappkontroll.Size = new System.Drawing.Size(680, 54);
            this.gbxKnappkontroll.TabIndex = 100;
            this.gbxKnappkontroll.TabStop = false;
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(247, 12);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 1;
            this.knappkontroller1.OnKnapp1Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp1ClickEventHandler(this.knappkontroller1_OnKnapp1Click);
            this.knappkontroller1.OnKnapp2Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp2ClickEventHandler(this.knappkontroller1_OnKnapp2Click);
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.knappkontroller1_OnKnapp3Click);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // hanteraFönster1
            // 
            this.hanteraFönster1.Location = new System.Drawing.Point(76, 19);
            this.hanteraFönster1.Name = "hanteraFönster1";
            this.hanteraFönster1.Size = new System.Drawing.Size(150, 19);
            this.hanteraFönster1.TabIndex = 105;
            // 
            // dgwSökRunda
            // 
            this.dgwSökRunda.AllowUserToAddRows = false;
            this.dgwSökRunda.AllowUserToDeleteRows = false;
            this.dgwSökRunda.AllowUserToResizeColumns = false;
            this.dgwSökRunda.AllowUserToResizeRows = false;
            this.dgwSökRunda.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgwSökRunda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwSökRunda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RundaNr,
            this.GolfklubbNr,
            this.Datum,
            this.Spelare,
            this.Bana,
            this.Poäng,
            this.Slag,
            this.Notering});
            this.dgwSökRunda.Location = new System.Drawing.Point(12, 135);
            this.dgwSökRunda.Name = "dgwSökRunda";
            this.dgwSökRunda.RowTemplate.Height = 24;
            this.dgwSökRunda.Size = new System.Drawing.Size(774, 191);
            this.dgwSökRunda.TabIndex = 10;
            this.dgwSökRunda.DoubleClick += new System.EventHandler(this.dgwSökRunda_DoubleClick);
            // 
            // lblAntal
            // 
            this.lblAntal.AutoSize = true;
            this.lblAntal.Location = new System.Drawing.Point(19, 110);
            this.lblAntal.Name = "lblAntal";
            this.lblAntal.Size = new System.Drawing.Size(83, 13);
            this.lblAntal.TabIndex = 103;
            this.lblAntal.Text = "Radrubrik_Antal";
            // 
            // txtAntal
            // 
            this.txtAntal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAntal.Location = new System.Drawing.Point(87, 110);
            this.txtAntal.Name = "txtAntal";
            this.txtAntal.ReadOnly = true;
            this.txtAntal.Size = new System.Drawing.Size(100, 13);
            this.txtAntal.TabIndex = 104;
            this.txtAntal.TabStop = false;
            // 
            // statistikHuvudKontroll1
            // 
            this.statistikHuvudKontroll1.Location = new System.Drawing.Point(12, 5);
            this.statistikHuvudKontroll1.Name = "statistikHuvudKontroll1";
            this.statistikHuvudKontroll1.Size = new System.Drawing.Size(725, 104);
            this.statistikHuvudKontroll1.Spelare = null;
            this.statistikHuvudKontroll1.TabIndex = 105;
            // 
            // RundaNr
            // 
            this.RundaNr.HeaderText = "RundaNr";
            this.RundaNr.Name = "RundaNr";
            this.RundaNr.ReadOnly = true;
            this.RundaNr.Visible = false;
            this.RundaNr.Width = 70;
            // 
            // GolfklubbNr
            // 
            this.GolfklubbNr.HeaderText = "GolfklubbNr";
            this.GolfklubbNr.Name = "GolfklubbNr";
            this.GolfklubbNr.ReadOnly = true;
            this.GolfklubbNr.Visible = false;
            // 
            // Datum
            // 
            this.Datum.HeaderText = "Rubrik_Datum";
            this.Datum.Name = "Datum";
            this.Datum.Width = 70;
            // 
            // Spelare
            // 
            this.Spelare.HeaderText = "Rubrik_Spelare";
            this.Spelare.Name = "Spelare";
            this.Spelare.Width = 70;
            // 
            // Bana
            // 
            this.Bana.HeaderText = "Rubrik_Bana";
            this.Bana.Name = "Bana";
            this.Bana.Width = 200;
            // 
            // Poäng
            // 
            this.Poäng.HeaderText = "Rubrik_Poäng";
            this.Poäng.Name = "Poäng";
            this.Poäng.Width = 40;
            // 
            // Slag
            // 
            this.Slag.HeaderText = "Rubrik_Slag";
            this.Slag.Name = "Slag";
            this.Slag.Width = 40;
            // 
            // Notering
            // 
            this.Notering.HeaderText = "Rubrik_Notering";
            this.Notering.Name = "Notering";
            this.Notering.Width = 320;
            // 
            // SökRunda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 381);
            this.Controls.Add(this.statistikHuvudKontroll1);
            this.Controls.Add(this.txtAntal);
            this.Controls.Add(this.lblAntal);
            this.Controls.Add(this.dgwSökRunda);
            this.Controls.Add(this.gbxKnappkontroll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SökRunda";
            this.Text = "Titel_SökRunda";
            this.Activated += new System.EventHandler(this.SökRunda_Activated);
            this.Load += new System.EventHandler(this.SökRunda_Load);
            this.gbxKnappkontroll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwSökRunda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxKnappkontroll;
        private System.Windows.Forms.DataGridView dgwSökRunda;
        private System.Windows.Forms.Label lblAntal;
        private System.Windows.Forms.TextBox txtAntal;
        private Hooker_GUI.Kontroller.Fönsterhanterare hanteraFönster1;
        private Hooker_GUI.Kontroller.Knappkontroller knappkontroller1;
        private Kontroller.StatistikHuvudKontroll statistikHuvudKontroll1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RundaNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn GolfklubbNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spelare;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bana;
        private System.Windows.Forms.DataGridViewTextBoxColumn Poäng;
        private System.Windows.Forms.DataGridViewTextBoxColumn Slag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notering;
    }
}