namespace Hooker_GUI.Kontroller
{
    partial class StatistikHuvudKontroll
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
            this.gbxSpelarinfo = new System.Windows.Forms.GroupBox();
            this.cboHemmabana = new System.Windows.Forms.ComboBox();
            this.lblTyp = new System.Windows.Forms.Label();
            this.ddnRedovisningstyper = new System.Windows.Forms.ComboBox();
            this.cboGolfklubb = new System.Windows.Forms.ComboBox();
            this.dtpTomDatum = new System.Windows.Forms.DateTimePicker();
            this.lblTomDatum = new System.Windows.Forms.Label();
            this.dtpFromDatum = new System.Windows.Forms.DateTimePicker();
            this.lblFromDatum = new System.Windows.Forms.Label();
            this.cboSpelare = new System.Windows.Forms.ComboBox();
            this.lblSpelare = new System.Windows.Forms.Label();
            this.lblGolfklubb = new System.Windows.Forms.Label();
            this.rbnNiohålsrond = new System.Windows.Forms.RadioButton();
            this.rbnHcprond = new System.Windows.Forms.RadioButton();
            this.rbnSällskapsrond = new System.Windows.Forms.RadioButton();
            this.rbnTävlingsrond = new System.Windows.Forms.RadioButton();
            this.gbxRondTyp = new System.Windows.Forms.GroupBox();
            this.gbxRedovisningsinfo = new System.Windows.Forms.GroupBox();
            this.rbnDetaljerad = new System.Windows.Forms.RadioButton();
            this.rbnSummerad = new System.Windows.Forms.RadioButton();
            this.gbxSpelarinfo.SuspendLayout();
            this.gbxRondTyp.SuspendLayout();
            this.gbxRedovisningsinfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxSpelarinfo
            // 
            this.gbxSpelarinfo.Controls.Add(this.cboHemmabana);
            this.gbxSpelarinfo.Controls.Add(this.lblTyp);
            this.gbxSpelarinfo.Controls.Add(this.ddnRedovisningstyper);
            this.gbxSpelarinfo.Controls.Add(this.cboGolfklubb);
            this.gbxSpelarinfo.Controls.Add(this.dtpTomDatum);
            this.gbxSpelarinfo.Controls.Add(this.lblTomDatum);
            this.gbxSpelarinfo.Controls.Add(this.dtpFromDatum);
            this.gbxSpelarinfo.Controls.Add(this.lblFromDatum);
            this.gbxSpelarinfo.Controls.Add(this.cboSpelare);
            this.gbxSpelarinfo.Controls.Add(this.lblSpelare);
            this.gbxSpelarinfo.Controls.Add(this.lblGolfklubb);
            this.gbxSpelarinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxSpelarinfo.Location = new System.Drawing.Point(3, 3);
            this.gbxSpelarinfo.Name = "gbxSpelarinfo";
            this.gbxSpelarinfo.Size = new System.Drawing.Size(510, 90);
            this.gbxSpelarinfo.TabIndex = 100;
            this.gbxSpelarinfo.TabStop = false;
            this.gbxSpelarinfo.Text = "Text_Spelare";
            // 
            // cboHemmabana
            // 
            this.cboHemmabana.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboHemmabana.FormattingEnabled = true;
            this.cboHemmabana.Location = new System.Drawing.Point(215, 55);
            this.cboHemmabana.Name = "cboHemmabana";
            this.cboHemmabana.Size = new System.Drawing.Size(120, 21);
            this.cboHemmabana.TabIndex = 3;
            this.cboHemmabana.SelectedIndexChanged += new System.EventHandler(this.cboHemmabana_SelectedIndexChanged);
            // 
            // lblTyp
            // 
            this.lblTyp.AutoSize = true;
            this.lblTyp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTyp.Location = new System.Drawing.Point(7, 58);
            this.lblTyp.Name = "lblTyp";
            this.lblTyp.Size = new System.Drawing.Size(77, 13);
            this.lblTyp.TabIndex = 0;
            this.lblTyp.Text = "Radrubrik_Typ";
            // 
            // ddnRedovisningstyper
            // 
            this.ddnRedovisningstyper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddnRedovisningstyper.FormattingEnabled = true;
            this.ddnRedovisningstyper.Location = new System.Drawing.Point(77, 55);
            this.ddnRedovisningstyper.Name = "ddnRedovisningstyper";
            this.ddnRedovisningstyper.Size = new System.Drawing.Size(185, 21);
            this.ddnRedovisningstyper.TabIndex = 2;
            this.ddnRedovisningstyper.SelectedIndexChanged += new System.EventHandler(this.ddnRedovisningstyper_SelectedIndexChanged);
            // 
            // cboGolfklubb
            // 
            this.cboGolfklubb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGolfklubb.FormattingEnabled = true;
            this.cboGolfklubb.Location = new System.Drawing.Point(77, 55);
            this.cboGolfklubb.Name = "cboGolfklubb";
            this.cboGolfklubb.Size = new System.Drawing.Size(131, 21);
            this.cboGolfklubb.TabIndex = 2;
            this.cboGolfklubb.SelectedIndexChanged += new System.EventHandler(this.cboGolfklubb_SelectedIndexChanged);
            // 
            // dtpTomDatum
            // 
            this.dtpTomDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTomDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTomDatum.Location = new System.Drawing.Point(405, 55);
            this.dtpTomDatum.Name = "dtpTomDatum";
            this.dtpTomDatum.Size = new System.Drawing.Size(85, 20);
            this.dtpTomDatum.TabIndex = 4;
            this.dtpTomDatum.ValueChanged += new System.EventHandler(this.dtpTomDatum_ValueChanged);
            // 
            // lblTomDatum
            // 
            this.lblTomDatum.AutoSize = true;
            this.lblTomDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTomDatum.Location = new System.Drawing.Point(338, 58);
            this.lblTomDatum.Name = "lblTomDatum";
            this.lblTomDatum.Size = new System.Drawing.Size(111, 13);
            this.lblTomDatum.TabIndex = 0;
            this.lblTomDatum.Text = "Radrubrik_TomDatum";
            // 
            // dtpFromDatum
            // 
            this.dtpFromDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDatum.Location = new System.Drawing.Point(405, 19);
            this.dtpFromDatum.Name = "dtpFromDatum";
            this.dtpFromDatum.Size = new System.Drawing.Size(85, 20);
            this.dtpFromDatum.TabIndex = 3;
            this.dtpFromDatum.ValueChanged += new System.EventHandler(this.dtpFromDatum_ValueChanged);
            // 
            // lblFromDatum
            // 
            this.lblFromDatum.AutoSize = true;
            this.lblFromDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDatum.Location = new System.Drawing.Point(338, 22);
            this.lblFromDatum.Name = "lblFromDatum";
            this.lblFromDatum.Size = new System.Drawing.Size(113, 13);
            this.lblFromDatum.TabIndex = 0;
            this.lblFromDatum.Text = "Radrubrik_FromDatum";
            // 
            // cboSpelare
            // 
            this.cboSpelare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSpelare.FormattingEnabled = true;
            this.cboSpelare.Location = new System.Drawing.Point(77, 19);
            this.cboSpelare.Name = "cboSpelare";
            this.cboSpelare.Size = new System.Drawing.Size(131, 21);
            this.cboSpelare.TabIndex = 1;
            this.cboSpelare.SelectedIndexChanged += new System.EventHandler(this.cboSpelare_SelectedIndexChanged);
            // 
            // lblSpelare
            // 
            this.lblSpelare.AutoSize = true;
            this.lblSpelare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpelare.Location = new System.Drawing.Point(7, 22);
            this.lblSpelare.Name = "lblSpelare";
            this.lblSpelare.Size = new System.Drawing.Size(95, 13);
            this.lblSpelare.TabIndex = 0;
            this.lblSpelare.Text = "Radrubrik_Spelare";
            // 
            // lblGolfklubb
            // 
            this.lblGolfklubb.AutoSize = true;
            this.lblGolfklubb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGolfklubb.Location = new System.Drawing.Point(7, 58);
            this.lblGolfklubb.Name = "lblGolfklubb";
            this.lblGolfklubb.Size = new System.Drawing.Size(104, 13);
            this.lblGolfklubb.TabIndex = 0;
            this.lblGolfklubb.Text = "Radrubrik_Golfklubb";
            // 
            // rbnNiohålsrond
            // 
            this.rbnNiohålsrond.AutoSize = true;
            this.rbnNiohålsrond.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnNiohålsrond.Location = new System.Drawing.Point(121, 58);
            this.rbnNiohålsrond.Name = "rbnNiohålsrond";
            this.rbnNiohålsrond.Size = new System.Drawing.Size(108, 17);
            this.rbnNiohålsrond.TabIndex = 100;
            this.rbnNiohålsrond.Text = "Text_Niohålsrond";
            this.rbnNiohålsrond.UseVisualStyleBackColor = true;
            this.rbnNiohålsrond.CheckedChanged += new System.EventHandler(this.rbnNiohålsrond_CheckedChanged);
            // 
            // rbnHcprond
            // 
            this.rbnHcprond.AutoSize = true;
            this.rbnHcprond.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnHcprond.Location = new System.Drawing.Point(121, 23);
            this.rbnHcprond.Name = "rbnHcprond";
            this.rbnHcprond.Size = new System.Drawing.Size(93, 17);
            this.rbnHcprond.TabIndex = 6;
            this.rbnHcprond.Text = "Text_Hcprond";
            this.rbnHcprond.UseVisualStyleBackColor = true;
            this.rbnHcprond.CheckedChanged += new System.EventHandler(this.rbnHcprond_CheckedChanged);
            // 
            // rbnSällskapsrond
            // 
            this.rbnSällskapsrond.AutoSize = true;
            this.rbnSällskapsrond.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnSällskapsrond.Location = new System.Drawing.Point(14, 59);
            this.rbnSällskapsrond.Name = "rbnSällskapsrond";
            this.rbnSällskapsrond.Size = new System.Drawing.Size(118, 17);
            this.rbnSällskapsrond.TabIndex = 7;
            this.rbnSällskapsrond.Text = "Text_Sällskapsrond";
            this.rbnSällskapsrond.UseVisualStyleBackColor = true;
            this.rbnSällskapsrond.CheckedChanged += new System.EventHandler(this.rbnSällskapsrond_CheckedChanged);
            // 
            // rbnTävlingsrond
            // 
            this.rbnTävlingsrond.AutoSize = true;
            this.rbnTävlingsrond.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnTävlingsrond.Location = new System.Drawing.Point(14, 23);
            this.rbnTävlingsrond.Name = "rbnTävlingsrond";
            this.rbnTävlingsrond.Size = new System.Drawing.Size(113, 17);
            this.rbnTävlingsrond.TabIndex = 5;
            this.rbnTävlingsrond.Text = "Text_Tävlingsrond";
            this.rbnTävlingsrond.UseVisualStyleBackColor = true;
            this.rbnTävlingsrond.CheckedChanged += new System.EventHandler(this.rbnTävlingsrond_CheckedChanged);
            // 
            // gbxRondTyp
            // 
            this.gbxRondTyp.Controls.Add(this.rbnNiohålsrond);
            this.gbxRondTyp.Controls.Add(this.rbnHcprond);
            this.gbxRondTyp.Controls.Add(this.rbnTävlingsrond);
            this.gbxRondTyp.Controls.Add(this.rbnSällskapsrond);
            this.gbxRondTyp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxRondTyp.Location = new System.Drawing.Point(519, 3);
            this.gbxRondTyp.Name = "gbxRondTyp";
            this.gbxRondTyp.Size = new System.Drawing.Size(203, 90);
            this.gbxRondTyp.TabIndex = 100;
            this.gbxRondTyp.TabStop = false;
            this.gbxRondTyp.Text = "Text_Rondinformation";
            // 
            // gbxRedovisningsinfo
            // 
            this.gbxRedovisningsinfo.Controls.Add(this.rbnDetaljerad);
            this.gbxRedovisningsinfo.Controls.Add(this.rbnSummerad);
            this.gbxRedovisningsinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxRedovisningsinfo.Location = new System.Drawing.Point(519, 3);
            this.gbxRedovisningsinfo.Name = "gbxRedovisningsinfo";
            this.gbxRedovisningsinfo.Size = new System.Drawing.Size(203, 90);
            this.gbxRedovisningsinfo.TabIndex = 100;
            this.gbxRedovisningsinfo.TabStop = false;
            this.gbxRedovisningsinfo.Text = "Text_Redovisningsinformation";
            // 
            // rbnDetaljerad
            // 
            this.rbnDetaljerad.AutoSize = true;
            this.rbnDetaljerad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnDetaljerad.Location = new System.Drawing.Point(14, 23);
            this.rbnDetaljerad.Name = "rbnDetaljerad";
            this.rbnDetaljerad.Size = new System.Drawing.Size(159, 17);
            this.rbnDetaljerad.TabIndex = 6;
            this.rbnDetaljerad.Text = "Text_DetaljeradRedovisning";
            this.rbnDetaljerad.UseVisualStyleBackColor = true;
            this.rbnDetaljerad.CheckedChanged += new System.EventHandler(this.rbnDetaljerad_CheckedChanged);
            // 
            // rbnSummerad
            // 
            this.rbnSummerad.AutoSize = true;
            this.rbnSummerad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnSummerad.Location = new System.Drawing.Point(14, 59);
            this.rbnSummerad.Name = "rbnSummerad";
            this.rbnSummerad.Size = new System.Drawing.Size(161, 17);
            this.rbnSummerad.TabIndex = 7;
            this.rbnSummerad.Text = "Text_SummeradRedovisning";
            this.rbnSummerad.UseVisualStyleBackColor = true;
            this.rbnSummerad.CheckedChanged += new System.EventHandler(this.rbnSummerad_CheckedChanged);
            // 
            // StatistikHuvudKontroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxRedovisningsinfo);
            this.Controls.Add(this.gbxRondTyp);
            this.Controls.Add(this.gbxSpelarinfo);
            this.Name = "StatistikHuvudKontroll";
            this.Size = new System.Drawing.Size(725, 104);
            this.gbxSpelarinfo.ResumeLayout(false);
            this.gbxSpelarinfo.PerformLayout();
            this.gbxRondTyp.ResumeLayout(false);
            this.gbxRondTyp.PerformLayout();
            this.gbxRedovisningsinfo.ResumeLayout(false);
            this.gbxRedovisningsinfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxSpelarinfo;
        private System.Windows.Forms.DateTimePicker dtpTomDatum;
        private System.Windows.Forms.Label lblTomDatum;
        private System.Windows.Forms.DateTimePicker dtpFromDatum;
        private System.Windows.Forms.Label lblFromDatum;
        private System.Windows.Forms.ComboBox cboSpelare;
        private System.Windows.Forms.Label lblSpelare;
        private System.Windows.Forms.Label lblGolfklubb;
        private System.Windows.Forms.RadioButton rbnNiohålsrond;
        private System.Windows.Forms.RadioButton rbnHcprond;
        private System.Windows.Forms.RadioButton rbnSällskapsrond;
        private System.Windows.Forms.RadioButton rbnTävlingsrond;
        private System.Windows.Forms.GroupBox gbxRondTyp;
        private System.Windows.Forms.ComboBox cboGolfklubb;
        private System.Windows.Forms.Label lblTyp;
        private System.Windows.Forms.ComboBox ddnRedovisningstyper;
        private System.Windows.Forms.GroupBox gbxRedovisningsinfo;
        private System.Windows.Forms.RadioButton rbnDetaljerad;
        private System.Windows.Forms.RadioButton rbnSummerad;
        private System.Windows.Forms.ComboBox cboHemmabana;
    }
}
