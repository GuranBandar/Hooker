namespace Hooker_GUI
{
    /// <summary>
    /// Klass för MDIFönster
    /// </summary>
    partial class MDIFönster
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIFönster));
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripServerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDatabaseLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menyKontroll1 = new Hooker_GUI.Kontroller.MenyKontroll();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripServerLabel,
            this.toolStripDatabaseLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 711);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(932, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripServerLabel
            // 
            this.toolStripServerLabel.Name = "toolStripServerLabel";
            this.toolStripServerLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripDatabaseLabel
            // 
            this.toolStripDatabaseLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripDatabaseLabel.Name = "toolStripDatabaseLabel";
            this.toolStripDatabaseLabel.Size = new System.Drawing.Size(55, 17);
            this.toolStripDatabaseLabel.Text = "Database";
            this.toolStripDatabaseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menyKontroll1
            // 
            this.menyKontroll1.AutoSize = true;
            this.menyKontroll1.Dock = System.Windows.Forms.DockStyle.Top;
            this.menyKontroll1.Location = new System.Drawing.Point(0, 0);
            this.menyKontroll1.Name = "menyKontroll1";
            this.menyKontroll1.Size = new System.Drawing.Size(932, 24);
            this.menyKontroll1.TabIndex = 4;
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "fileDialog";
            // 
            // MDIFönster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(932, 733);
            this.Controls.Add(this.menyKontroll1);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MDIFönster";
            this.Text = "Hooker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MDIFönster_FormClosed);
            this.Load += new System.EventHandler(this.MDIFönster_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip ToolTip;
        private Hooker_GUI.Kontroller.MenyKontroll menyKontroll1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripDatabaseLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripServerLabel;
        private System.Windows.Forms.OpenFileDialog fileDialog;
    }
}



