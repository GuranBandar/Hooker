namespace Hooker_GUI.Kontroller
{
    partial class TavlingKlassKontroll
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
            this.dgwKlassinfo = new System.Windows.Forms.DataGridView();
            this.Klass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Klasser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Namn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spelform = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Klasstyp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ronder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxKlasser = new System.Windows.Forms.GroupBox();
            this.fönsterhanterare1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            ((System.ComponentModel.ISupportInitialize)(this.dgwKlassinfo)).BeginInit();
            this.gbxKlasser.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgwKlassinfo
            // 
            this.dgwKlassinfo.AllowUserToAddRows = false;
            this.dgwKlassinfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwKlassinfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Klass,
            this.Klasser,
            this.Namn,
            this.Spelform,
            this.Klasstyp,
            this.Ronder});
            this.dgwKlassinfo.Location = new System.Drawing.Point(4, 17);
            this.dgwKlassinfo.Name = "dgwKlassinfo";
            this.dgwKlassinfo.RowTemplate.Height = 24;
            this.dgwKlassinfo.Size = new System.Drawing.Size(613, 117);
            this.dgwKlassinfo.TabIndex = 0;
            this.dgwKlassinfo.DoubleClick += new System.EventHandler(this.dgwKlassinfo_DoubleClick);
            // 
            // Klass
            // 
            this.Klass.HeaderText = "Text_Klass";
            this.Klass.Name = "Klass";
            this.Klass.ReadOnly = true;
            this.Klass.Visible = false;
            // 
            // Klasser
            // 
            this.Klasser.HeaderText = "Text_Klasser";
            this.Klasser.Name = "Klasser";
            this.Klasser.ReadOnly = true;
            this.Klasser.Width = 60;
            // 
            // Namn
            // 
            this.Namn.HeaderText = "Text_Namn";
            this.Namn.Name = "Namn";
            this.Namn.ReadOnly = true;
            this.Namn.Width = 200;
            // 
            // Spelform
            // 
            this.Spelform.HeaderText = "Text_Spelform";
            this.Spelform.Name = "Spelform";
            this.Spelform.ReadOnly = true;
            // 
            // Klasstyp
            // 
            this.Klasstyp.HeaderText = "Text_Klasstyp";
            this.Klasstyp.Name = "Klasstyp";
            this.Klasstyp.ReadOnly = true;
            // 
            // Ronder
            // 
            this.Ronder.HeaderText = "Text_Ronder";
            this.Ronder.Name = "Ronder";
            this.Ronder.ReadOnly = true;
            this.Ronder.Width = 60;
            // 
            // gbxKlasser
            // 
            this.gbxKlasser.Controls.Add(this.fönsterhanterare1);
            this.gbxKlasser.Location = new System.Drawing.Point(3, 3);
            this.gbxKlasser.Name = "gbxKlasser";
            this.gbxKlasser.Size = new System.Drawing.Size(620, 130);
            this.gbxKlasser.TabIndex = 6;
            this.gbxKlasser.TabStop = false;
            this.gbxKlasser.Text = "Text_Klassinfo";
            // 
            // fönsterhanterare1
            // 
            this.fönsterhanterare1.Location = new System.Drawing.Point(296, 85);
            this.fönsterhanterare1.Name = "fönsterhanterare1";
            this.fönsterhanterare1.Size = new System.Drawing.Size(150, 15);
            this.fönsterhanterare1.TabIndex = 0;
            // 
            // TavlingKlassKontroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgwKlassinfo);
            this.Controls.Add(this.gbxKlasser);
            this.Name = "TavlingKlassKontroll";
            this.Size = new System.Drawing.Size(627, 142);
            ((System.ComponentModel.ISupportInitialize)(this.dgwKlassinfo)).EndInit();
            this.gbxKlasser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwKlassinfo;
        private System.Windows.Forms.GroupBox gbxKlasser;
        private Fönsterhanterare fönsterhanterare1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Klass;
        private System.Windows.Forms.DataGridViewTextBoxColumn Klasser;
        private System.Windows.Forms.DataGridViewTextBoxColumn Namn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spelform;
        private System.Windows.Forms.DataGridViewTextBoxColumn Klasstyp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ronder;
    }
}
