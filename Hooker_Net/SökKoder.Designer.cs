namespace Hooker_GUI
{
    partial class SökKoder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SökKoder));
            this.gbxKnappkontroll = new System.Windows.Forms.GroupBox();
            this.fönsterhanterare1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.gbxKodtyper = new System.Windows.Forms.GroupBox();
            this.txtArgument = new System.Windows.Forms.TextBox();
            this.lblArgument = new System.Windows.Forms.Label();
            this.lblTyp = new System.Windows.Forms.Label();
            this.cboKodtyper = new System.Windows.Forms.ComboBox();
            this.dgwSökKoder = new System.Windows.Forms.DataGridView();
            this.Typ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Argument = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Värde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxKodtyper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSökKoder)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxKnappkontroll
            // 
            this.gbxKnappkontroll.Location = new System.Drawing.Point(-5, 353);
            this.gbxKnappkontroll.Name = "gbxKnappkontroll";
            this.gbxKnappkontroll.Size = new System.Drawing.Size(657, 56);
            this.gbxKnappkontroll.TabIndex = 1;
            this.gbxKnappkontroll.TabStop = false;
            // 
            // fönsterhanterare1
            // 
            this.fönsterhanterare1.Location = new System.Drawing.Point(43, 371);
            this.fönsterhanterare1.Name = "fönsterhanterare1";
            this.fönsterhanterare1.Size = new System.Drawing.Size(150, 23);
            this.fönsterhanterare1.TabIndex = 1;
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Location = new System.Drawing.Point(213, 362);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 0;
            this.knappkontroller1.OnKnapp1Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp1ClickEventHandler(this.knappkontroller1_OnKnapp1Click);
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.knappkontroller1_OnKnapp3Click);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            this.knappkontroller1.OnKnapp2Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp2ClickEventHandler(this.knappkontroller1_OnKnapp2Click);
            // 
            // gbxKodtyper
            // 
            this.gbxKodtyper.Controls.Add(this.txtArgument);
            this.gbxKodtyper.Controls.Add(this.lblArgument);
            this.gbxKodtyper.Controls.Add(this.lblTyp);
            this.gbxKodtyper.Controls.Add(this.cboKodtyper);
            this.gbxKodtyper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxKodtyper.Location = new System.Drawing.Point(3, 3);
            this.gbxKodtyper.Name = "gbxKodtyper";
            this.gbxKodtyper.Size = new System.Drawing.Size(522, 79);
            this.gbxKodtyper.TabIndex = 0;
            this.gbxKodtyper.TabStop = false;
            this.gbxKodtyper.Text = "Text_Koder";
            // 
            // txtArgument
            // 
            this.txtArgument.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArgument.Location = new System.Drawing.Point(120, 48);
            this.txtArgument.Name = "txtArgument";
            this.txtArgument.Size = new System.Drawing.Size(382, 20);
            this.txtArgument.TabIndex = 3;
            // 
            // lblArgument
            // 
            this.lblArgument.AutoSize = true;
            this.lblArgument.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArgument.Location = new System.Drawing.Point(12, 51);
            this.lblArgument.Name = "lblArgument";
            this.lblArgument.Size = new System.Drawing.Size(104, 13);
            this.lblArgument.TabIndex = 2;
            this.lblArgument.Text = "Radrubrik_Argument";
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
            // cboKodtyper
            // 
            this.cboKodtyper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKodtyper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKodtyper.FormattingEnabled = true;
            this.cboKodtyper.Location = new System.Drawing.Point(120, 19);
            this.cboKodtyper.Name = "cboKodtyper";
            this.cboKodtyper.Size = new System.Drawing.Size(382, 21);
            this.cboKodtyper.Sorted = true;
            this.cboKodtyper.TabIndex = 0;
            this.cboKodtyper.SelectedIndexChanged += new System.EventHandler(this.cboKodtyper_SelectedIndexChanged);
            // 
            // dgwSökKoder
            // 
            this.dgwSökKoder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwSökKoder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Typ,
            this.Argument,
            this.Värde});
            this.dgwSökKoder.Location = new System.Drawing.Point(12, 100);
            this.dgwSökKoder.Name = "dgwSökKoder";
            this.dgwSökKoder.Size = new System.Drawing.Size(613, 242);
            this.dgwSökKoder.TabIndex = 2;
            this.dgwSökKoder.DoubleClick += new System.EventHandler(this.dgwSökKoder_DoubleClick);
            // 
            // Typ
            // 
            this.Typ.HeaderText = "Text_Typ";
            this.Typ.Name = "Typ";
            this.Typ.ReadOnly = true;
            // 
            // Argument
            // 
            this.Argument.HeaderText = "Text_Argument";
            this.Argument.Name = "Argument";
            this.Argument.ReadOnly = true;
            this.Argument.Width = 150;
            // 
            // Värde
            // 
            this.Värde.HeaderText = "Text_Värde";
            this.Värde.Name = "Värde";
            this.Värde.ReadOnly = true;
            this.Värde.Width = 300;
            // 
            // SökKoder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 395);
            this.Controls.Add(this.fönsterhanterare1);
            this.Controls.Add(this.dgwSökKoder);
            this.Controls.Add(this.knappkontroller1);
            this.Controls.Add(this.gbxKodtyper);
            this.Controls.Add(this.gbxKnappkontroll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SökKoder";
            this.Text = "Titel_SökKoder";
            this.Load += new System.EventHandler(this.SökKoder_Load);
            this.Enter += new System.EventHandler(this.SökKoder_Enter);
            this.gbxKodtyper.ResumeLayout(false);
            this.gbxKodtyper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSökKoder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Hooker_GUI.Kontroller.Knappkontroller knappkontroller1;
        private System.Windows.Forms.GroupBox gbxKnappkontroll;
        private System.Windows.Forms.GroupBox gbxKodtyper;
        private System.Windows.Forms.ComboBox cboKodtyper;
        private System.Windows.Forms.DataGridView dgwSökKoder;
        private Hooker_GUI.Kontroller.Fönsterhanterare fönsterhanterare1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Typ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Argument;
        private System.Windows.Forms.DataGridViewTextBoxColumn Värde;
        private System.Windows.Forms.TextBox txtArgument;
        private System.Windows.Forms.Label lblArgument;
        private System.Windows.Forms.Label lblTyp;
    }
}