namespace Hooker_GUI.Kontroller
{
    partial class RundaNotering
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RundaNotering));
            this.txtNotering = new System.Windows.Forms.TextBox();
            this.lblNotering = new System.Windows.Forms.Label();
            this.btnSparaOStäng = new System.Windows.Forms.Button();
            this.btnSpara = new System.Windows.Forms.Button();
            this.btnAvbryt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNotering
            // 
            this.txtNotering.Location = new System.Drawing.Point(90, 14);
            this.txtNotering.MaxLength = 120;
            this.txtNotering.Name = "txtNotering";
            this.txtNotering.Size = new System.Drawing.Size(401, 20);
            this.txtNotering.TabIndex = 1;
            // 
            // lblNotering
            // 
            this.lblNotering.AutoSize = true;
            this.lblNotering.Location = new System.Drawing.Point(14, 17);
            this.lblNotering.Name = "lblNotering";
            this.lblNotering.Size = new System.Drawing.Size(99, 13);
            this.lblNotering.TabIndex = 0;
            this.lblNotering.Text = "Radrubrik_Notering";
            // 
            // btnSparaOStäng
            // 
            this.btnSparaOStäng.Location = new System.Drawing.Point(239, 40);
            this.btnSparaOStäng.Name = "btnSparaOStäng";
            this.btnSparaOStäng.Size = new System.Drawing.Size(80, 23);
            this.btnSparaOStäng.TabIndex = 2;
            this.btnSparaOStäng.Text = "Knapp_Spara_o_Stäng";
            this.btnSparaOStäng.UseVisualStyleBackColor = true;
            this.btnSparaOStäng.Click += new System.EventHandler(this.btnSparaOStäng_Click);
            // 
            // btnSpara
            // 
            this.btnSpara.Location = new System.Drawing.Point(325, 40);
            this.btnSpara.Name = "btnSpara";
            this.btnSpara.Size = new System.Drawing.Size(80, 23);
            this.btnSpara.TabIndex = 3;
            this.btnSpara.Text = "Knapp_Spara";
            this.btnSpara.UseVisualStyleBackColor = true;
            this.btnSpara.Click += new System.EventHandler(this.btnSpara_Click);
            // 
            // btnAvbryt
            // 
            this.btnAvbryt.Location = new System.Drawing.Point(411, 40);
            this.btnAvbryt.Name = "btnAvbryt";
            this.btnAvbryt.Size = new System.Drawing.Size(80, 23);
            this.btnAvbryt.TabIndex = 4;
            this.btnAvbryt.Text = "Knapp_Avbryt";
            this.btnAvbryt.UseVisualStyleBackColor = true;
            this.btnAvbryt.Click += new System.EventHandler(this.btnAvbryt_Click);
            // 
            // RundaNotering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 70);
            this.Controls.Add(this.btnAvbryt);
            this.Controls.Add(this.btnSpara);
            this.Controls.Add(this.btnSparaOStäng);
            this.Controls.Add(this.txtNotering);
            this.Controls.Add(this.lblNotering);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RundaNotering";
            this.Text = "Rubrik_Notering";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNotering;
        private System.Windows.Forms.Label lblNotering;
        private System.Windows.Forms.Button btnSparaOStäng;
        private System.Windows.Forms.Button btnSpara;
        private System.Windows.Forms.Button btnAvbryt;
    }
}
