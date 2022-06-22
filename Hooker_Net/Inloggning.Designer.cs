namespace Hooker_GUI
{
    /// <summary>
    /// Klass för Inloggning
    /// </summary>
    partial class Inloggning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inloggning));
            this.txtAnvandarnamn = new System.Windows.Forms.TextBox();
            this.lblAnvandarnamn = new System.Windows.Forms.Label();
            this.lblLosenord = new System.Windows.Forms.Label();
            this.txtLosenord = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAvbryt = new System.Windows.Forms.Button();
            this.lblMeddelande = new System.Windows.Forms.Label();
            this.btnNy = new System.Windows.Forms.Button();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // txtAnvandarnamn
            // 
            this.txtAnvandarnamn.Location = new System.Drawing.Point(220, 80);
            this.txtAnvandarnamn.Margin = new System.Windows.Forms.Padding(2);
            this.txtAnvandarnamn.Name = "txtAnvandarnamn";
            this.txtAnvandarnamn.Size = new System.Drawing.Size(144, 20);
            this.txtAnvandarnamn.TabIndex = 0;
            // 
            // lblAnvandarnamn
            // 
            this.lblAnvandarnamn.AutoSize = true;
            this.lblAnvandarnamn.Location = new System.Drawing.Point(60, 82);
            this.lblAnvandarnamn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAnvandarnamn.Name = "lblAnvandarnamn";
            this.lblAnvandarnamn.Size = new System.Drawing.Size(131, 13);
            this.lblAnvandarnamn.TabIndex = 1;
            this.lblAnvandarnamn.Text = "Radrubrik_Anvandarnamn";
            // 
            // lblLosenord
            // 
            this.lblLosenord.AutoSize = true;
            this.lblLosenord.Location = new System.Drawing.Point(60, 125);
            this.lblLosenord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLosenord.Name = "lblLosenord";
            this.lblLosenord.Size = new System.Drawing.Size(103, 13);
            this.lblLosenord.TabIndex = 3;
            this.lblLosenord.Text = "Radrubrik_Losenord";
            // 
            // txtLosenord
            // 
            this.txtLosenord.Location = new System.Drawing.Point(219, 122);
            this.txtLosenord.Margin = new System.Windows.Forms.Padding(2);
            this.txtLosenord.Name = "txtLosenord";
            this.txtLosenord.PasswordChar = '*';
            this.txtLosenord.Size = new System.Drawing.Size(144, 20);
            this.txtLosenord.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(291, 168);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAvbryt
            // 
            this.btnAvbryt.Location = new System.Drawing.Point(207, 168);
            this.btnAvbryt.Name = "btnAvbryt";
            this.btnAvbryt.Size = new System.Drawing.Size(75, 23);
            this.btnAvbryt.TabIndex = 5;
            this.btnAvbryt.Text = "Avbryt";
            this.btnAvbryt.UseVisualStyleBackColor = true;
            this.btnAvbryt.Click += new System.EventHandler(this.btnAvbryt_Click);
            // 
            // lblMeddelande
            // 
            this.lblMeddelande.AutoSize = true;
            this.lblMeddelande.Location = new System.Drawing.Point(60, 42);
            this.lblMeddelande.Name = "lblMeddelande";
            this.lblMeddelande.Size = new System.Drawing.Size(0, 13);
            this.lblMeddelande.TabIndex = 7;
            // 
            // btnNy
            // 
            this.btnNy.Location = new System.Drawing.Point(126, 168);
            this.btnNy.Name = "btnNy";
            this.btnNy.Size = new System.Drawing.Size(75, 23);
            this.btnNy.TabIndex = 5;
            this.btnNy.Text = "&Ny";
            this.btnNy.UseVisualStyleBackColor = true;
            this.btnNy.Click += new System.EventHandler(this.btnNy_Click);
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(12, 218);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(0, 13);
            this.lblDatabase.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(-9, 197);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 64);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // Inloggning
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 251);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.lblMeddelande);
            this.Controls.Add(this.btnNy);
            this.Controls.Add(this.btnAvbryt);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblLosenord);
            this.Controls.Add(this.txtLosenord);
            this.Controls.Add(this.lblAnvandarnamn);
            this.Controls.Add(this.txtAnvandarnamn);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.Name = "Inloggning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Titel_Inloggning";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Inloggning_FormClosed);
            this.Load += new System.EventHandler(this.Inloggning_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAnvandarnamn;
        private System.Windows.Forms.Label lblAnvandarnamn;
        private System.Windows.Forms.Label lblLosenord;
        private System.Windows.Forms.TextBox txtLosenord;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAvbryt;
        private System.Windows.Forms.Label lblMeddelande;
        private System.Windows.Forms.Button btnNy;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}