namespace Hooker_GUI
{
    partial class DatabaseQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseQuery));
            this.tabQueryResult = new System.Windows.Forms.TabControl();
            this.tabResult = new System.Windows.Forms.TabPage();
            this.dgvResultTab = new System.Windows.Forms.DataGridView();
            this.tabMessages = new System.Windows.Forms.TabPage();
            this.lbxMessages = new System.Windows.Forms.ListBox();
            this.rtbQuery = new System.Windows.Forms.RichTextBox();
            this.hanteraFönster1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            this.gbxKnappkontroller = new System.Windows.Forms.GroupBox();
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.lbxTabeller = new System.Windows.Forms.ListBox();
            this.tabQueryResult.SuspendLayout();
            this.tabResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultTab)).BeginInit();
            this.tabMessages.SuspendLayout();
            this.gbxKnappkontroller.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabQueryResult
            // 
            this.tabQueryResult.Controls.Add(this.tabResult);
            this.tabQueryResult.Controls.Add(this.tabMessages);
            this.tabQueryResult.Location = new System.Drawing.Point(12, 199);
            this.tabQueryResult.Name = "tabQueryResult";
            this.tabQueryResult.SelectedIndex = 0;
            this.tabQueryResult.Size = new System.Drawing.Size(814, 399);
            this.tabQueryResult.TabIndex = 4;
            // 
            // tabResult
            // 
            this.tabResult.Controls.Add(this.dgvResultTab);
            this.tabResult.Location = new System.Drawing.Point(4, 22);
            this.tabResult.Name = "tabResult";
            this.tabResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabResult.Size = new System.Drawing.Size(806, 373);
            this.tabResult.TabIndex = 0;
            this.tabResult.Text = "Result";
            this.tabResult.UseVisualStyleBackColor = true;
            // 
            // dgvResultTab
            // 
            this.dgvResultTab.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResultTab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultTab.Location = new System.Drawing.Point(6, 6);
            this.dgvResultTab.Name = "dgvResultTab";
            this.dgvResultTab.Size = new System.Drawing.Size(794, 361);
            this.dgvResultTab.TabIndex = 0;
            // 
            // tabMessages
            // 
            this.tabMessages.Controls.Add(this.lbxMessages);
            this.tabMessages.Location = new System.Drawing.Point(4, 22);
            this.tabMessages.Name = "tabMessages";
            this.tabMessages.Padding = new System.Windows.Forms.Padding(3);
            this.tabMessages.Size = new System.Drawing.Size(806, 373);
            this.tabMessages.TabIndex = 1;
            this.tabMessages.Text = "Messages";
            this.tabMessages.UseVisualStyleBackColor = true;
            // 
            // lbxMessages
            // 
            this.lbxMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbxMessages.FormattingEnabled = true;
            this.lbxMessages.Location = new System.Drawing.Point(7, 7);
            this.lbxMessages.Name = "lbxMessages";
            this.lbxMessages.Size = new System.Drawing.Size(904, 195);
            this.lbxMessages.TabIndex = 0;
            // 
            // rtbQuery
            // 
            this.rtbQuery.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbQuery.Location = new System.Drawing.Point(12, 12);
            this.rtbQuery.Name = "rtbQuery";
            this.rtbQuery.Size = new System.Drawing.Size(804, 158);
            this.rtbQuery.TabIndex = 1;
            this.rtbQuery.Text = "";
            this.rtbQuery.TextChanged += new System.EventHandler(this.rtbQuery_TextChanged);
            // 
            // hanteraFönster1
            // 
            this.hanteraFönster1.Location = new System.Drawing.Point(105, 19);
            this.hanteraFönster1.Name = "hanteraFönster1";
            this.hanteraFönster1.Size = new System.Drawing.Size(150, 12);
            this.hanteraFönster1.TabIndex = 0;
            // 
            // gbxKnappkontroller
            // 
            this.gbxKnappkontroller.Controls.Add(this.knappkontroller1);
            this.gbxKnappkontroller.Controls.Add(this.hanteraFönster1);
            this.gbxKnappkontroller.Location = new System.Drawing.Point(-8, 604);
            this.gbxKnappkontroller.Name = "gbxKnappkontroller";
            this.gbxKnappkontroller.Size = new System.Drawing.Size(854, 48);
            this.gbxKnappkontroller.TabIndex = 5;
            this.gbxKnappkontroller.TabStop = false;
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Location = new System.Drawing.Point(368, 12);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(466, 33);
            this.knappkontroller1.TabIndex = 1;
            this.knappkontroller1.OnKnapp2Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp2ClickEventHandler(this.knappkontroller1_OnKnapp2Click);
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.knappkontroller1_OnKnapp3Click);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // lbxTabeller
            // 
            this.lbxTabeller.FormattingEnabled = true;
            this.lbxTabeller.Location = new System.Drawing.Point(92, 42);
            this.lbxTabeller.Name = "lbxTabeller";
            this.lbxTabeller.Size = new System.Drawing.Size(120, 95);
            this.lbxTabeller.TabIndex = 6;
            this.lbxTabeller.Visible = false;
            // 
            // DatabaseQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 655);
            this.Controls.Add(this.lbxTabeller);
            this.Controls.Add(this.gbxKnappkontroller);
            this.Controls.Add(this.tabQueryResult);
            this.Controls.Add(this.rtbQuery);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DatabaseQuery";
            this.Text = "Titel_DatabaseQuery";
            this.Load += new System.EventHandler(this.DatabaseQuery_Load);
            this.tabQueryResult.ResumeLayout(false);
            this.tabResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultTab)).EndInit();
            this.tabMessages.ResumeLayout(false);
            this.gbxKnappkontroller.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabQueryResult;
        private System.Windows.Forms.TabPage tabResult;
        private System.Windows.Forms.TabPage tabMessages;
        private System.Windows.Forms.RichTextBox rtbQuery;
        private System.Windows.Forms.DataGridView dgvResultTab;
        private System.Windows.Forms.ListBox lbxMessages;
        private Kontroller.Fönsterhanterare hanteraFönster1;
        private System.Windows.Forms.GroupBox gbxKnappkontroller;
        private Kontroller.Knappkontroller knappkontroller1;
        private System.Windows.Forms.ListBox lbxTabeller;
    }
}

