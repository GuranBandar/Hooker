﻿namespace Hooker_GUI
{
    partial class SpelareInfo
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpelareInfo));
            this.gbxSpelarinfo = new System.Windows.Forms.GroupBox();
            this.txtFederationNo = new System.Windows.Forms.TextBox();
            this.lblFederationNo = new System.Windows.Forms.Label();
            this.cboHemmaBana = new System.Windows.Forms.ComboBox();
            this.txtLopnr = new System.Windows.Forms.TextBox();
            this.cboGolfklubb = new System.Windows.Forms.ComboBox();
            this.txtNamn = new System.Windows.Forms.TextBox();
            this.txtGolfID = new System.Windows.Forms.TextBox();
            this.lblGolfklubb = new System.Windows.Forms.Label();
            this.lblNamn = new System.Windows.Forms.Label();
            this.lblGolfID = new System.Windows.Forms.Label();
            this.lnkMinGolf = new System.Windows.Forms.LinkLabel();
            this.gbxhandicap = new System.Windows.Forms.GroupBox();
            this.txtKlass = new System.Windows.Forms.TextBox();
            this.txtRevDatum = new System.Windows.Forms.TextBox();
            this.txtSpelHcp = new System.Windows.Forms.TextBox();
            this.txtExaktHcp = new System.Windows.Forms.TextBox();
            this.lblKlass = new System.Windows.Forms.Label();
            this.lblRevDatum = new System.Windows.Forms.Label();
            this.lblSpelHcp = new System.Windows.Forms.Label();
            this.lblExaktHcp = new System.Windows.Forms.Label();
            this.gbxLinje = new System.Windows.Forms.GroupBox();
            this.fönsterhanterare1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.gbxKon = new System.Windows.Forms.GroupBox();
            this.rbnKvinna = new System.Windows.Forms.RadioButton();
            this.rbnMan = new System.Windows.Forms.RadioButton();
            this.tangentkontroll1 = new Hooker_GUI.Kontroller.Tangentkontroll();
            this.chaHcplista = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbxSpelarinfo.SuspendLayout();
            this.gbxhandicap.SuspendLayout();
            this.gbxLinje.SuspendLayout();
            this.gbxKon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chaHcplista)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxSpelarinfo
            // 
            this.gbxSpelarinfo.BackColor = System.Drawing.SystemColors.Control;
            this.gbxSpelarinfo.Controls.Add(this.txtFederationNo);
            this.gbxSpelarinfo.Controls.Add(this.lblFederationNo);
            this.gbxSpelarinfo.Controls.Add(this.cboHemmaBana);
            this.gbxSpelarinfo.Controls.Add(this.txtLopnr);
            this.gbxSpelarinfo.Controls.Add(this.cboGolfklubb);
            this.gbxSpelarinfo.Controls.Add(this.txtNamn);
            this.gbxSpelarinfo.Controls.Add(this.txtGolfID);
            this.gbxSpelarinfo.Controls.Add(this.lblGolfklubb);
            this.gbxSpelarinfo.Controls.Add(this.lblNamn);
            this.gbxSpelarinfo.Controls.Add(this.lblGolfID);
            this.gbxSpelarinfo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxSpelarinfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbxSpelarinfo.Location = new System.Drawing.Point(3, 4);
            this.gbxSpelarinfo.Name = "gbxSpelarinfo";
            this.gbxSpelarinfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbxSpelarinfo.Size = new System.Drawing.Size(393, 100);
            this.gbxSpelarinfo.TabIndex = 0;
            this.gbxSpelarinfo.TabStop = false;
            this.gbxSpelarinfo.Text = "Text_Spelare";
            // 
            // txtFederationNo
            // 
            this.txtFederationNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFederationNo.Location = new System.Drawing.Point(338, 42);
            this.txtFederationNo.Name = "txtFederationNo";
            this.txtFederationNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFederationNo.Size = new System.Drawing.Size(49, 20);
            this.txtFederationNo.TabIndex = 4;
            // 
            // lblFederationNo
            // 
            this.lblFederationNo.AutoSize = true;
            this.lblFederationNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFederationNo.Location = new System.Drawing.Point(250, 45);
            this.lblFederationNo.Name = "lblFederationNo";
            this.lblFederationNo.Size = new System.Drawing.Size(123, 14);
            this.lblFederationNo.TabIndex = 101;
            this.lblFederationNo.Text = "Radrubrik_FederationNo";
            // 
            // cboHemmaBana
            // 
            this.cboHemmaBana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHemmaBana.FormattingEnabled = true;
            this.cboHemmaBana.Location = new System.Drawing.Point(251, 68);
            this.cboHemmaBana.Name = "cboHemmaBana";
            this.cboHemmaBana.Size = new System.Drawing.Size(136, 22);
            this.cboHemmaBana.TabIndex = 6;
            // 
            // txtLopnr
            // 
            this.txtLopnr.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLopnr.Location = new System.Drawing.Point(357, 17);
            this.txtLopnr.MaxLength = 3;
            this.txtLopnr.Name = "txtLopnr";
            this.txtLopnr.Size = new System.Drawing.Size(30, 20);
            this.txtLopnr.TabIndex = 3;
            // 
            // cboGolfklubb
            // 
            this.cboGolfklubb.BackColor = System.Drawing.SystemColors.Window;
            this.cboGolfklubb.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboGolfklubb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGolfklubb.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGolfklubb.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboGolfklubb.IntegralHeight = false;
            this.cboGolfklubb.Location = new System.Drawing.Point(78, 68);
            this.cboGolfklubb.Name = "cboGolfklubb";
            this.cboGolfklubb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboGolfklubb.Size = new System.Drawing.Size(147, 22);
            this.cboGolfklubb.Sorted = true;
            this.cboGolfklubb.TabIndex = 5;
            this.cboGolfklubb.SelectedIndexChanged += new System.EventHandler(this.cboGolfklubb_SelectedIndexChanged);
            // 
            // txtNamn
            // 
            this.txtNamn.AcceptsReturn = true;
            this.txtNamn.BackColor = System.Drawing.SystemColors.Window;
            this.txtNamn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNamn.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNamn.Location = new System.Drawing.Point(78, 17);
            this.txtNamn.MaxLength = 0;
            this.txtNamn.Name = "txtNamn";
            this.txtNamn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNamn.Size = new System.Drawing.Size(147, 20);
            this.txtNamn.TabIndex = 1;
            // 
            // txtGolfID
            // 
            this.txtGolfID.AcceptsReturn = true;
            this.txtGolfID.BackColor = System.Drawing.SystemColors.Window;
            this.txtGolfID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGolfID.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGolfID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGolfID.Location = new System.Drawing.Point(300, 17);
            this.txtGolfID.MaxLength = 6;
            this.txtGolfID.Name = "txtGolfID";
            this.txtGolfID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtGolfID.Size = new System.Drawing.Size(50, 20);
            this.txtGolfID.TabIndex = 2;
            // 
            // lblGolfklubb
            // 
            this.lblGolfklubb.BackColor = System.Drawing.SystemColors.Control;
            this.lblGolfklubb.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblGolfklubb.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGolfklubb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGolfklubb.Location = new System.Drawing.Point(8, 72);
            this.lblGolfklubb.Name = "lblGolfklubb";
            this.lblGolfklubb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblGolfklubb.Size = new System.Drawing.Size(73, 17);
            this.lblGolfklubb.TabIndex = 100;
            this.lblGolfklubb.Text = "Radrubrik_Golfklubb";
            // 
            // lblNamn
            // 
            this.lblNamn.BackColor = System.Drawing.SystemColors.Control;
            this.lblNamn.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblNamn.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNamn.Location = new System.Drawing.Point(8, 19);
            this.lblNamn.Name = "lblNamn";
            this.lblNamn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNamn.Size = new System.Drawing.Size(41, 17);
            this.lblNamn.TabIndex = 100;
            this.lblNamn.Text = "Radrubrik_Namn";
            // 
            // lblGolfID
            // 
            this.lblGolfID.BackColor = System.Drawing.SystemColors.Control;
            this.lblGolfID.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblGolfID.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGolfID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGolfID.Location = new System.Drawing.Point(248, 19);
            this.lblGolfID.Name = "lblGolfID";
            this.lblGolfID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblGolfID.Size = new System.Drawing.Size(41, 17);
            this.lblGolfID.TabIndex = 100;
            this.lblGolfID.Text = "Radrubrik_GolfID";
            // 
            // lnkMinGolf
            // 
            this.lnkMinGolf.AutoSize = true;
            this.lnkMinGolf.Location = new System.Drawing.Point(256, 198);
            this.lnkMinGolf.Name = "lnkMinGolf";
            this.lnkMinGolf.Size = new System.Drawing.Size(95, 13);
            this.lnkMinGolf.TabIndex = 11;
            this.lnkMinGolf.TabStop = true;
            this.lnkMinGolf.Text = "Text_Till_Min_Golf";
            this.lnkMinGolf.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMinGolf_LinkClicked);
            // 
            // gbxhandicap
            // 
            this.gbxhandicap.BackColor = System.Drawing.SystemColors.Control;
            this.gbxhandicap.Controls.Add(this.txtKlass);
            this.gbxhandicap.Controls.Add(this.txtRevDatum);
            this.gbxhandicap.Controls.Add(this.txtSpelHcp);
            this.gbxhandicap.Controls.Add(this.txtExaktHcp);
            this.gbxhandicap.Controls.Add(this.lblKlass);
            this.gbxhandicap.Controls.Add(this.lblRevDatum);
            this.gbxhandicap.Controls.Add(this.lblSpelHcp);
            this.gbxhandicap.Controls.Add(this.lblExaktHcp);
            this.gbxhandicap.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxhandicap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbxhandicap.Location = new System.Drawing.Point(3, 110);
            this.gbxhandicap.Name = "gbxhandicap";
            this.gbxhandicap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbxhandicap.Size = new System.Drawing.Size(225, 129);
            this.gbxhandicap.TabIndex = 100;
            this.gbxhandicap.TabStop = false;
            this.gbxhandicap.Text = "Rubrik_Hcp";
            // 
            // txtKlass
            // 
            this.txtKlass.AcceptsReturn = true;
            this.txtKlass.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtKlass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKlass.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKlass.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtKlass.Location = new System.Drawing.Point(120, 90);
            this.txtKlass.MaxLength = 0;
            this.txtKlass.Name = "txtKlass";
            this.txtKlass.ReadOnly = true;
            this.txtKlass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtKlass.Size = new System.Drawing.Size(33, 20);
            this.txtKlass.TabIndex = 100;
            this.txtKlass.TabStop = false;
            this.txtKlass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRevDatum
            // 
            this.txtRevDatum.AcceptsReturn = true;
            this.txtRevDatum.BackColor = System.Drawing.SystemColors.Window;
            this.txtRevDatum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRevDatum.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRevDatum.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRevDatum.Location = new System.Drawing.Point(8, 90);
            this.txtRevDatum.MaxLength = 0;
            this.txtRevDatum.Name = "txtRevDatum";
            this.txtRevDatum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRevDatum.Size = new System.Drawing.Size(89, 20);
            this.txtRevDatum.TabIndex = 8;
            // 
            // txtSpelHcp
            // 
            this.txtSpelHcp.AcceptsReturn = true;
            this.txtSpelHcp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtSpelHcp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSpelHcp.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpelHcp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSpelHcp.Location = new System.Drawing.Point(120, 40);
            this.txtSpelHcp.MaxLength = 0;
            this.txtSpelHcp.Name = "txtSpelHcp";
            this.txtSpelHcp.ReadOnly = true;
            this.txtSpelHcp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSpelHcp.Size = new System.Drawing.Size(40, 20);
            this.txtSpelHcp.TabIndex = 100;
            this.txtSpelHcp.TabStop = false;
            this.txtSpelHcp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtExaktHcp
            // 
            this.txtExaktHcp.AcceptsReturn = true;
            this.txtExaktHcp.BackColor = System.Drawing.SystemColors.Window;
            this.txtExaktHcp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtExaktHcp.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExaktHcp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtExaktHcp.Location = new System.Drawing.Point(8, 40);
            this.txtExaktHcp.MaxLength = 0;
            this.txtExaktHcp.Name = "txtExaktHcp";
            this.txtExaktHcp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtExaktHcp.Size = new System.Drawing.Size(40, 20);
            this.txtExaktHcp.TabIndex = 7;
            // 
            // lblKlass
            // 
            this.lblKlass.BackColor = System.Drawing.SystemColors.Control;
            this.lblKlass.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblKlass.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKlass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblKlass.Location = new System.Drawing.Point(120, 66);
            this.lblKlass.Name = "lblKlass";
            this.lblKlass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblKlass.Size = new System.Drawing.Size(89, 17);
            this.lblKlass.TabIndex = 100;
            this.lblKlass.Text = "Text_Klass";
            // 
            // lblRevDatum
            // 
            this.lblRevDatum.BackColor = System.Drawing.SystemColors.Control;
            this.lblRevDatum.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblRevDatum.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevDatum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRevDatum.Location = new System.Drawing.Point(8, 66);
            this.lblRevDatum.Name = "lblRevDatum";
            this.lblRevDatum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRevDatum.Size = new System.Drawing.Size(105, 17);
            this.lblRevDatum.TabIndex = 100;
            this.lblRevDatum.Text = "Text_Senaste_Revidering";
            // 
            // lblSpelHcp
            // 
            this.lblSpelHcp.BackColor = System.Drawing.SystemColors.Control;
            this.lblSpelHcp.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSpelHcp.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpelHcp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSpelHcp.Location = new System.Drawing.Point(120, 24);
            this.lblSpelHcp.Name = "lblSpelHcp";
            this.lblSpelHcp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSpelHcp.Size = new System.Drawing.Size(81, 17);
            this.lblSpelHcp.TabIndex = 100;
            this.lblSpelHcp.Text = "Text_Spel_Hcp";
            // 
            // lblExaktHcp
            // 
            this.lblExaktHcp.BackColor = System.Drawing.SystemColors.Control;
            this.lblExaktHcp.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblExaktHcp.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExaktHcp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblExaktHcp.Location = new System.Drawing.Point(8, 24);
            this.lblExaktHcp.Name = "lblExaktHcp";
            this.lblExaktHcp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblExaktHcp.Size = new System.Drawing.Size(81, 17);
            this.lblExaktHcp.TabIndex = 100;
            this.lblExaktHcp.Text = "Text_Exakt_Hcp";
            // 
            // gbxLinje
            // 
            this.gbxLinje.Controls.Add(this.fönsterhanterare1);
            this.gbxLinje.Location = new System.Drawing.Point(3, 433);
            this.gbxLinje.Name = "gbxLinje";
            this.gbxLinje.Size = new System.Drawing.Size(410, 35);
            this.gbxLinje.TabIndex = 300;
            this.gbxLinje.TabStop = false;
            // 
            // fönsterhanterare1
            // 
            this.fönsterhanterare1.Location = new System.Drawing.Point(129, 18);
            this.fönsterhanterare1.Name = "fönsterhanterare1";
            this.fönsterhanterare1.Size = new System.Drawing.Size(150, 26);
            this.fönsterhanterare1.TabIndex = 1;
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(-21, 438);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 31);
            this.knappkontroller1.TabIndex = 0;
            this.knappkontroller1.OnKnapp1Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp1ClickEventHandler(this.knappkontroller1_OnKnapp1Click);
            this.knappkontroller1.OnKnapp2Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp2ClickEventHandler(this.knappkontroller1_OnKnapp2Click);
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.knappkontroller1_OnKnapp3Click);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // gbxKon
            // 
            this.gbxKon.BackColor = System.Drawing.SystemColors.Control;
            this.gbxKon.Controls.Add(this.rbnKvinna);
            this.gbxKon.Controls.Add(this.rbnMan);
            this.gbxKon.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxKon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbxKon.Location = new System.Drawing.Point(254, 110);
            this.gbxKon.Name = "gbxKon";
            this.gbxKon.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbxKon.Size = new System.Drawing.Size(108, 65);
            this.gbxKon.TabIndex = 200;
            this.gbxKon.TabStop = false;
            this.gbxKon.Text = "Text_Kon";
            // 
            // rbnKvinna
            // 
            this.rbnKvinna.BackColor = System.Drawing.SystemColors.Control;
            this.rbnKvinna.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbnKvinna.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnKvinna.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbnKvinna.Location = new System.Drawing.Point(16, 40);
            this.rbnKvinna.Name = "rbnKvinna";
            this.rbnKvinna.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbnKvinna.Size = new System.Drawing.Size(89, 17);
            this.rbnKvinna.TabIndex = 10;
            this.rbnKvinna.TabStop = true;
            this.rbnKvinna.Text = "Text_Kvinna";
            this.rbnKvinna.UseVisualStyleBackColor = false;
            // 
            // rbnMan
            // 
            this.rbnMan.BackColor = System.Drawing.SystemColors.Control;
            this.rbnMan.Checked = true;
            this.rbnMan.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbnMan.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnMan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbnMan.Location = new System.Drawing.Point(16, 16);
            this.rbnMan.Name = "rbnMan";
            this.rbnMan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbnMan.Size = new System.Drawing.Size(88, 17);
            this.rbnMan.TabIndex = 9;
            this.rbnMan.TabStop = true;
            this.rbnMan.Text = "Text_Man";
            this.rbnMan.UseVisualStyleBackColor = false;
            // 
            // tangentkontroll1
            // 
            this.tangentkontroll1.Location = new System.Drawing.Point(240, 198);
            this.tangentkontroll1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tangentkontroll1.Name = "tangentkontroll1";
            this.tangentkontroll1.Size = new System.Drawing.Size(150, 19);
            this.tangentkontroll1.TabIndex = 301;
            // 
            // chaHcplista
            // 
            chartArea1.Name = "ChartArea1";
            this.chaHcplista.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chaHcplista.Legends.Add(legend1);
            this.chaHcplista.Location = new System.Drawing.Point(11, 246);
            this.chaHcplista.Name = "chaHcplista";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chaHcplista.Series.Add(series1);
            this.chaHcplista.Size = new System.Drawing.Size(379, 181);
            this.chaHcplista.TabIndex = 302;
            this.chaHcplista.Text = "chart1";
            this.chaHcplista.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chaHcplista_MouseClick);
            this.chaHcplista.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chaHcplista_MouseDoubleClick);
            // 
            // SpelareInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 477);
            this.Controls.Add(this.knappkontroller1);
            this.Controls.Add(this.chaHcplista);
            this.Controls.Add(this.lnkMinGolf);
            this.Controls.Add(this.tangentkontroll1);
            this.Controls.Add(this.gbxKon);
            this.Controls.Add(this.gbxhandicap);
            this.Controls.Add(this.gbxSpelarinfo);
            this.Controls.Add(this.gbxLinje);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SpelareInfo";
            this.Text = "Titel_VisaSpelare";
            this.Load += new System.EventHandler(this.Spelare_Load);
            this.gbxSpelarinfo.ResumeLayout(false);
            this.gbxSpelarinfo.PerformLayout();
            this.gbxhandicap.ResumeLayout(false);
            this.gbxhandicap.PerformLayout();
            this.gbxLinje.ResumeLayout(false);
            this.gbxKon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chaHcplista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.GroupBox gbxSpelarinfo;
        public System.Windows.Forms.ComboBox cboGolfklubb;
        public System.Windows.Forms.TextBox txtNamn;
        public System.Windows.Forms.TextBox txtGolfID;
        public System.Windows.Forms.Label lblGolfklubb;
        public System.Windows.Forms.Label lblNamn;
        public System.Windows.Forms.Label lblGolfID;
        private System.Windows.Forms.LinkLabel lnkMinGolf;
        public System.Windows.Forms.GroupBox gbxhandicap;
        public System.Windows.Forms.TextBox txtKlass;
        public System.Windows.Forms.TextBox txtRevDatum;
        public System.Windows.Forms.TextBox txtSpelHcp;
        public System.Windows.Forms.TextBox txtExaktHcp;
        public System.Windows.Forms.Label lblKlass;
        public System.Windows.Forms.Label lblRevDatum;
        public System.Windows.Forms.Label lblSpelHcp;
        public System.Windows.Forms.Label lblExaktHcp;
        private System.Windows.Forms.GroupBox gbxLinje;
        public System.Windows.Forms.GroupBox gbxKon;
        public System.Windows.Forms.RadioButton rbnKvinna;
        public System.Windows.Forms.RadioButton rbnMan;
        private System.Windows.Forms.TextBox txtLopnr;
        private Hooker_GUI.Kontroller.Tangentkontroll tangentkontroll1;
        private Kontroller.Knappkontroller knappkontroller1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chaHcplista;
        private System.Windows.Forms.ComboBox cboHemmaBana;
        private System.Windows.Forms.Label lblFederationNo;
        private System.Windows.Forms.TextBox txtFederationNo;
        private Kontroller.Fönsterhanterare fönsterhanterare1;
    }
}