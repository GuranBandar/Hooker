using System;

namespace Hooker_GUI
{
    partial class SökAnvändare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SökAnvändare));
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.gbxKnapparna = new System.Windows.Forms.GroupBox();
            this.hanteraFönster1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            this.dgwSokAnvandare = new System.Windows.Forms.DataGridView();
            this.lblNamn = new System.Windows.Forms.Label();
            this.txtNamn = new System.Windows.Forms.TextBox();
            this.cboAnvandargrupp = new System.Windows.Forms.ComboBox();
            this.lblAnvandargrupp = new System.Windows.Forms.Label();
            this.AnvandarID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnvandarNamn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Epostadress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Användargrupp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxKnapparna.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSokAnvandare)).BeginInit();
            this.SuspendLayout();
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(87, 9);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 0;
            this.knappkontroller1.OnKnapp1Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp1ClickEventHandler(this.Knappkontroller1_OnKnapp1Click_1);
            this.knappkontroller1.OnKnapp2Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp2ClickEventHandler(this.Knappkontroller1_OnKnapp2Click);
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.Knappkontroller1_OnKnapp3Click);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.Knappkontroller1_OnKnapp4Click);
            // 
            // gbxKnapparna
            // 
            this.gbxKnapparna.Controls.Add(this.hanteraFönster1);
            this.gbxKnapparna.Controls.Add(this.knappkontroller1);
            this.gbxKnapparna.Location = new System.Drawing.Point(-9, 223);
            this.gbxKnapparna.Name = "gbxKnapparna";
            this.gbxKnapparna.Size = new System.Drawing.Size(522, 76);
            this.gbxKnapparna.TabIndex = 1;
            this.gbxKnapparna.TabStop = false;
            // 
            // hanteraFönster1
            // 
            this.hanteraFönster1.Location = new System.Drawing.Point(21, 18);
            this.hanteraFönster1.Name = "hanteraFönster1";
            this.hanteraFönster1.Size = new System.Drawing.Size(62, 10);
            this.hanteraFönster1.TabIndex = 0;
            // 
            // dgwSokAnvandare
            // 
            this.dgwSokAnvandare.AllowUserToAddRows = false;
            this.dgwSokAnvandare.AllowUserToDeleteRows = false;
            this.dgwSokAnvandare.AllowUserToResizeColumns = false;
            this.dgwSokAnvandare.AllowUserToResizeRows = false;
            this.dgwSokAnvandare.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgwSokAnvandare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwSokAnvandare.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AnvandarID,
            this.AnvandarNamn,
            this.Epostadress,
            this.Användargrupp});
            this.dgwSokAnvandare.Location = new System.Drawing.Point(5, 56);
            this.dgwSokAnvandare.Name = "dgwSokAnvandare";
            this.dgwSokAnvandare.RowTemplate.Height = 24;
            this.dgwSokAnvandare.Size = new System.Drawing.Size(490, 161);
            this.dgwSokAnvandare.TabIndex = 11;
            // 
            // lblNamn
            // 
            this.lblNamn.AutoSize = true;
            this.lblNamn.Location = new System.Drawing.Point(10, 17);
            this.lblNamn.Name = "lblNamn";
            this.lblNamn.Size = new System.Drawing.Size(62, 13);
            this.lblNamn.TabIndex = 10;
            this.lblNamn.Text = "Text_Namn";
            // 
            // txtNamn
            // 
            this.txtNamn.Location = new System.Drawing.Point(78, 14);
            this.txtNamn.Name = "txtNamn";
            this.txtNamn.Size = new System.Drawing.Size(177, 20);
            this.txtNamn.TabIndex = 9;
            // 
            // cboAnvandargrupp
            // 
            this.cboAnvandargrupp.FormattingEnabled = true;
            this.cboAnvandargrupp.Location = new System.Drawing.Point(375, 14);
            this.cboAnvandargrupp.Name = "cboAnvandargrupp";
            this.cboAnvandargrupp.Size = new System.Drawing.Size(120, 21);
            this.cboAnvandargrupp.TabIndex = 13;
            // 
            // lblAnvandargrupp
            // 
            this.lblAnvandargrupp.AutoSize = true;
            this.lblAnvandargrupp.Location = new System.Drawing.Point(288, 17);
            this.lblAnvandargrupp.Name = "lblAnvandargrupp";
            this.lblAnvandargrupp.Size = new System.Drawing.Size(132, 13);
            this.lblAnvandargrupp.TabIndex = 12;
            this.lblAnvandargrupp.Text = "Radrubrik_Anvandargrupp";
            // 
            // AnvandarID
            // 
            this.AnvandarID.HeaderText = "AnvandarID";
            this.AnvandarID.Name = "AnvandarID";
            this.AnvandarID.ReadOnly = true;
            this.AnvandarID.Visible = false;
            // 
            // AnvandarNamn
            // 
            this.AnvandarNamn.HeaderText = "Text_AnvandarNamn";
            this.AnvandarNamn.Name = "AnvandarNamn";
            // 
            // Epostadress
            // 
            this.Epostadress.HeaderText = "Text_Epost";
            this.Epostadress.Name = "Epostadress";
            this.Epostadress.Width = 225;
            // 
            // Användargrupp
            // 
            this.Användargrupp.HeaderText = "Text_Anvandargrupp";
            this.Användargrupp.Name = "Användargrupp";
            // 
            // SökAnvändare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 277);
            this.Controls.Add(this.cboAnvandargrupp);
            this.Controls.Add(this.lblAnvandargrupp);
            this.Controls.Add(this.dgwSokAnvandare);
            this.Controls.Add(this.lblNamn);
            this.Controls.Add(this.txtNamn);
            this.Controls.Add(this.gbxKnapparna);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SökAnvändare";
            this.Text = "Titel_SökAnvändare";
            this.Load += new System.EventHandler(this.SökAnvändare_Load);
            this.gbxKnapparna.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwSokAnvandare)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        //private void SökAnvändare_Load(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void Knappkontroller1_OnKnapp1Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Knappkontroller1_OnKnapp0Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Kontroller.Knappkontroller knappkontroller1;
        private System.Windows.Forms.GroupBox gbxKnapparna;
        private System.Windows.Forms.DataGridView dgwSokAnvandare;
        private System.Windows.Forms.Label lblNamn;
        private System.Windows.Forms.TextBox txtNamn;
        private System.Windows.Forms.ComboBox cboAnvandargrupp;
        private System.Windows.Forms.Label lblAnvandargrupp;
        private Kontroller.Fönsterhanterare hanteraFönster1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnvandarID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnvandarNamn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Epostadress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Användargrupp;
    }
}