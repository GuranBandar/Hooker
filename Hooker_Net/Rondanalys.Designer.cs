namespace Hooker_GUI
{
    partial class Rondanalys
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rondanalys));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAntal = new System.Windows.Forms.TextBox();
            this.lblAntal = new System.Windows.Forms.Label();
            this.statistikHuvudKontroll1 = new Hooker_GUI.Kontroller.StatistikHuvudKontroll();
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.hanteraFönster1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            this.dgwRondanalys = new System.Windows.Forms.DataGridView();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.txtPoang = new System.Windows.Forms.TextBox();
            this.txtResultat = new System.Windows.Forms.TextBox();
            this.RundaNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GolfklubbNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SummaSlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SlagUt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SlagIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Separator1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SummaPoang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PoangUt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PoangIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Separator2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResEfter3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResEfter6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResEfter9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResEfter12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResEfter15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResEfter18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgwRondanalys)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(-7, 551);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(761, 48);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // txtAntal
            // 
            this.txtAntal.BackColor = System.Drawing.SystemColors.Control;
            this.txtAntal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAntal.Location = new System.Drawing.Point(88, 104);
            this.txtAntal.Name = "txtAntal";
            this.txtAntal.ReadOnly = true;
            this.txtAntal.Size = new System.Drawing.Size(25, 13);
            this.txtAntal.TabIndex = 5;
            this.txtAntal.TabStop = false;
            // 
            // lblAntal
            // 
            this.lblAntal.AutoSize = true;
            this.lblAntal.Location = new System.Drawing.Point(17, 103);
            this.lblAntal.Name = "lblAntal";
            this.lblAntal.Size = new System.Drawing.Size(83, 13);
            this.lblAntal.TabIndex = 4;
            this.lblAntal.Text = "Radrubrik_Antal";
            // 
            // statistikHuvudKontroll1
            // 
            this.statistikHuvudKontroll1.Location = new System.Drawing.Point(7, 1);
            this.statistikHuvudKontroll1.Margin = new System.Windows.Forms.Padding(4);
            this.statistikHuvudKontroll1.Name = "statistikHuvudKontroll1";
            this.statistikHuvudKontroll1.Size = new System.Drawing.Size(725, 104);
            this.statistikHuvudKontroll1.Spelare = null;
            this.statistikHuvudKontroll1.TabIndex = 2;
            this.statistikHuvudKontroll1.OnCboSpelareSelect += new Hooker_GUI.Kontroller.StatistikHuvudKontroll.CboSpelareSelectEventHandler(this.statistikHuvudKontroll1_OnCboSpelareSelect);
            this.statistikHuvudKontroll1.OnCboGolfklubbSelect += new Hooker_GUI.Kontroller.StatistikHuvudKontroll.CboGolfklubbSelectEventHandler(this.statistikHuvudKontroll1_OnCboGolfklubbSelect);
            this.statistikHuvudKontroll1.OnCboHemmabanaSelect += new Hooker_GUI.Kontroller.StatistikHuvudKontroll.CboHemmabanaSelectEventHandler(this.statistikHuvudKontroll1_OnCboHemmabanaSelect);
            this.statistikHuvudKontroll1.OnDtpFromDatumChanged += new Hooker_GUI.Kontroller.StatistikHuvudKontroll.DtpFromDatumChangedEventHandler(this.statistikHuvudKontroll1_OnDtpFromDatumChanged);
            this.statistikHuvudKontroll1.OnDtpTomDatumChanged += new Hooker_GUI.Kontroller.StatistikHuvudKontroll.DtpTomDatumChangedEventHandler(this.statistikHuvudKontroll1_OnDtpTomDatumChanged);
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(324, 560);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 1;
            this.knappkontroller1.OnKnapp0Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp0ClickEventHandler(this.knappkontroller1_OnKnapp0Click);
            this.knappkontroller1.OnKnapp1Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp1ClickEventHandler(this.knappkontroller1_OnKnapp1Click);
            this.knappkontroller1.OnKnapp2Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp2ClickEventHandler(this.knappkontroller1_OnKnapp2Click);
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.knappkontroller1_OnKnapp3Click);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // hanteraFönster1
            // 
            this.hanteraFönster1.Location = new System.Drawing.Point(98, 565);
            this.hanteraFönster1.Name = "hanteraFönster1";
            this.hanteraFönster1.Size = new System.Drawing.Size(150, 17);
            this.hanteraFönster1.TabIndex = 0;
            // 
            // dgwRondanalys
            // 
            this.dgwRondanalys.AllowUserToAddRows = false;
            this.dgwRondanalys.AllowUserToDeleteRows = false;
            this.dgwRondanalys.AllowUserToResizeColumns = false;
            this.dgwRondanalys.AllowUserToResizeRows = false;
            this.dgwRondanalys.BackgroundColor = System.Drawing.Color.White;
            this.dgwRondanalys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwRondanalys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RundaNr,
            this.GolfklubbNr,
            this.Datum,
            this.Bana,
            this.SummaSlag,
            this.SlagUt,
            this.SlagIn,
            this.Separator1,
            this.SummaPoang,
            this.PoangUt,
            this.PoangIn,
            this.Separator2,
            this.ResEfter3,
            this.ResEfter6,
            this.ResEfter9,
            this.ResEfter12,
            this.ResEfter15,
            this.ResEfter18});
            this.dgwRondanalys.Location = new System.Drawing.Point(7, 151);
            this.dgwRondanalys.Name = "dgwRondanalys";
            this.dgwRondanalys.RowTemplate.Height = 24;
            this.dgwRondanalys.Size = new System.Drawing.Size(725, 393);
            this.dgwRondanalys.TabIndex = 6;
            this.dgwRondanalys.DoubleClick += new System.EventHandler(this.dgwRondanalys_DoubleClick);
            // 
            // txtScore
            // 
            this.txtScore.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtScore.Location = new System.Drawing.Point(326, 136);
            this.txtScore.Name = "txtScore";
            this.txtScore.ReadOnly = true;
            this.txtScore.Size = new System.Drawing.Size(98, 20);
            this.txtScore.TabIndex = 0;
            this.txtScore.TabStop = false;
            this.txtScore.Text = "Rubrik_Slag";
            this.txtScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPoang
            // 
            this.txtPoang.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtPoang.Location = new System.Drawing.Point(435, 136);
            this.txtPoang.Name = "txtPoang";
            this.txtPoang.ReadOnly = true;
            this.txtPoang.Size = new System.Drawing.Size(91, 20);
            this.txtPoang.TabIndex = 0;
            this.txtPoang.TabStop = false;
            this.txtPoang.Text = "Rubrik_Poäng";
            this.txtPoang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtResultat
            // 
            this.txtResultat.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtResultat.Location = new System.Drawing.Point(535, 136);
            this.txtResultat.Name = "txtResultat";
            this.txtResultat.ReadOnly = true;
            this.txtResultat.Size = new System.Drawing.Size(181, 20);
            this.txtResultat.TabIndex = 7;
            this.txtResultat.TabStop = false;
            this.txtResultat.Text = "Text_ResultatEfter3";
            this.txtResultat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RundaNr
            // 
            this.RundaNr.HeaderText = "RundaNr";
            this.RundaNr.Name = "RundaNr";
            this.RundaNr.ReadOnly = true;
            this.RundaNr.Visible = false;
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
            this.Datum.ReadOnly = true;
            this.Datum.Width = 80;
            // 
            // Bana
            // 
            this.Bana.HeaderText = "Rubrik_Bana";
            this.Bana.Name = "Bana";
            this.Bana.ReadOnly = true;
            this.Bana.Width = 200;
            // 
            // SummaSlag
            // 
            this.SummaSlag.HeaderText = "Rubrik_Summa";
            this.SummaSlag.Name = "SummaSlag";
            this.SummaSlag.ReadOnly = true;
            this.SummaSlag.Width = 36;
            // 
            // SlagUt
            // 
            this.SlagUt.HeaderText = "Text_Ut";
            this.SlagUt.Name = "SlagUt";
            this.SlagUt.ReadOnly = true;
            this.SlagUt.Width = 30;
            // 
            // SlagIn
            // 
            this.SlagIn.HeaderText = "Text_In";
            this.SlagIn.Name = "SlagIn";
            this.SlagIn.ReadOnly = true;
            this.SlagIn.Width = 30;
            // 
            // Separator1
            // 
            this.Separator1.HeaderText = "";
            this.Separator1.Name = "Separator1";
            this.Separator1.ReadOnly = true;
            this.Separator1.Width = 10;
            // 
            // SummaPoang
            // 
            this.SummaPoang.HeaderText = "Rubrik_Summa";
            this.SummaPoang.Name = "SummaPoang";
            this.SummaPoang.ReadOnly = true;
            this.SummaPoang.Width = 30;
            // 
            // PoangUt
            // 
            this.PoangUt.HeaderText = "Text_Ut";
            this.PoangUt.Name = "PoangUt";
            this.PoangUt.ReadOnly = true;
            this.PoangUt.Width = 30;
            // 
            // PoangIn
            // 
            this.PoangIn.HeaderText = "Text_In";
            this.PoangIn.Name = "PoangIn";
            this.PoangIn.ReadOnly = true;
            this.PoangIn.Width = 30;
            // 
            // Separator2
            // 
            this.Separator2.HeaderText = "";
            this.Separator2.Name = "Separator2";
            this.Separator2.ReadOnly = true;
            this.Separator2.Width = 10;
            // 
            // ResEfter3
            // 
            this.ResEfter3.HeaderText = "Text_3";
            this.ResEfter3.Name = "ResEfter3";
            this.ResEfter3.ReadOnly = true;
            this.ResEfter3.Width = 30;
            // 
            // ResEfter6
            // 
            this.ResEfter6.HeaderText = "Text_6";
            this.ResEfter6.Name = "ResEfter6";
            this.ResEfter6.ReadOnly = true;
            this.ResEfter6.Width = 30;
            // 
            // ResEfter9
            // 
            this.ResEfter9.HeaderText = "Text_9";
            this.ResEfter9.Name = "ResEfter9";
            this.ResEfter9.ReadOnly = true;
            this.ResEfter9.Width = 30;
            // 
            // ResEfter12
            // 
            this.ResEfter12.HeaderText = "Text_12";
            this.ResEfter12.Name = "ResEfter12";
            this.ResEfter12.ReadOnly = true;
            this.ResEfter12.Width = 30;
            // 
            // ResEfter15
            // 
            this.ResEfter15.HeaderText = "Text_15";
            this.ResEfter15.Name = "ResEfter15";
            this.ResEfter15.ReadOnly = true;
            this.ResEfter15.Width = 30;
            // 
            // ResEfter18
            // 
            this.ResEfter18.HeaderText = "Text_18";
            this.ResEfter18.Name = "ResEfter18";
            this.ResEfter18.ReadOnly = true;
            this.ResEfter18.Width = 30;
            // 
            // Rondanalys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 592);
            this.Controls.Add(this.dgwRondanalys);
            this.Controls.Add(this.txtAntal);
            this.Controls.Add(this.lblAntal);
            this.Controls.Add(this.statistikHuvudKontroll1);
            this.Controls.Add(this.knappkontroller1);
            this.Controls.Add(this.hanteraFönster1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.txtPoang);
            this.Controls.Add(this.txtResultat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Rondanalys";
            this.Text = "Titel_Rondanalys";
            this.Load += new System.EventHandler(this.Rondanalys_Load);
            this.Enter += new System.EventHandler(this.Rondanalys_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dgwRondanalys)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hooker_GUI.Kontroller.Fönsterhanterare hanteraFönster1;
        private Hooker_GUI.Kontroller.Knappkontroller knappkontroller1;
        private Hooker_GUI.Kontroller.StatistikHuvudKontroll statistikHuvudKontroll1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAntal;
        private System.Windows.Forms.Label lblAntal;
        private System.Windows.Forms.DataGridView dgwRondanalys;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.TextBox txtPoang;
        private System.Windows.Forms.TextBox txtResultat;
        private System.Windows.Forms.DataGridViewTextBoxColumn RundaNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn GolfklubbNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bana;
        private System.Windows.Forms.DataGridViewTextBoxColumn SummaSlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlagUt;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlagIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Separator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SummaPoang;
        private System.Windows.Forms.DataGridViewTextBoxColumn PoangUt;
        private System.Windows.Forms.DataGridViewTextBoxColumn PoangIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Separator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResEfter3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResEfter6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResEfter9;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResEfter12;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResEfter15;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResEfter18;
    }
}