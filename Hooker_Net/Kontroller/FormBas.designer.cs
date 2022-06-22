namespace Hooker_GUI.Kontroller
{
    /// <summary>
    /// Basklass för alla Formulär
    /// </summary>
    partial class FormBas
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
            this.SuspendLayout();
            // 
            // FormBas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "FormBas";
            this.Text = "FormBas";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormBas_KeyPress);
//            this.MouseCaptureChanged += new System.EventHandler(this.FormBas_MouseCaptureChanged);
            this.ResumeLayout(false);

        }

        #endregion
    }
}