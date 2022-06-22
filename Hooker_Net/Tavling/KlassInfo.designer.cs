namespace Hooker_GUI
{
    partial class KlassInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KlassInfo));
            this.cbxOnskemalOmTee = new System.Windows.Forms.CheckBox();
            this.cboKlass = new System.Windows.Forms.ComboBox();
            this.lblKlass = new System.Windows.Forms.Label();
            this.dgwRondinfo = new System.Windows.Forms.DataGridView();
            this.RondID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rondnr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ForstaStartTid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Golfklubb = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BanaNr = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.AntalHal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cut = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtMaxAlderKvinna = new System.Windows.Forms.TextBox();
            this.lblMaxAlderKvinna = new System.Windows.Forms.Label();
            this.txtMaxHcpLag = new System.Windows.Forms.TextBox();
            this.txtMinHcpLag = new System.Windows.Forms.TextBox();
            this.txtMinHcpKvinna = new System.Windows.Forms.TextBox();
            this.txtMaxHcpMan = new System.Windows.Forms.TextBox();
            this.txtMinHcpMan = new System.Windows.Forms.TextBox();
            this.txtMinAlderKvinna = new System.Windows.Forms.TextBox();
            this.txtMaxAlderMan = new System.Windows.Forms.TextBox();
            this.txtMinAlderMan = new System.Windows.Forms.TextBox();
            this.txtMaxHcpKvinna = new System.Windows.Forms.TextBox();
            this.lblMinAlderKvinna = new System.Windows.Forms.Label();
            this.lblMaxAlderMan = new System.Windows.Forms.Label();
            this.lblMinAlderMan = new System.Windows.Forms.Label();
            this.lblMaxHcpLag = new System.Windows.Forms.Label();
            this.lblMinHcpLag = new System.Windows.Forms.Label();
            this.lblMinHcpKvinna = new System.Windows.Forms.Label();
            this.lblMaxHcpKvinna = new System.Windows.Forms.Label();
            this.lblMaxHcpMan = new System.Windows.Forms.Label();
            this.lblMinHcpMan = new System.Windows.Forms.Label();
            this.txtTillaggsavgift = new System.Windows.Forms.TextBox();
            this.txtAnmalningsavgift = new System.Windows.Forms.TextBox();
            this.txtRonder = new System.Windows.Forms.TextBox();
            this.cboTeeKvinna = new System.Windows.Forms.ComboBox();
            this.cboTeeMan = new System.Windows.Forms.ComboBox();
            this.cboKon = new System.Windows.Forms.ComboBox();
            this.cboKlasstyp = new System.Windows.Forms.ComboBox();
            this.cboSpelform = new System.Windows.Forms.ComboBox();
            this.lblTillaggsavgift = new System.Windows.Forms.Label();
            this.lblAnmalningsavgift = new System.Windows.Forms.Label();
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.lblOnskemal = new System.Windows.Forms.Label();
            this.lblTeeKvinna = new System.Windows.Forms.Label();
            this.lblTeeMan = new System.Windows.Forms.Label();
            this.lblKon = new System.Windows.Forms.Label();
            this.lblRonder = new System.Windows.Forms.Label();
            this.lblKlasstyp = new System.Windows.Forms.Label();
            this.lblSpelfom = new System.Windows.Forms.Label();
            this.gbxKnappkontroll = new System.Windows.Forms.GroupBox();
            this.tangentkontroll1 = new Hooker_GUI.Kontroller.Tangentkontroll();
            this.gbxRondinfo = new System.Windows.Forms.GroupBox();
            this.fönsterhanterare1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            ((System.ComponentModel.ISupportInitialize)(this.dgwRondinfo)).BeginInit();
            this.gbxKnappkontroll.SuspendLayout();
            this.gbxRondinfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxOnskemalOmTee
            // 
            this.cbxOnskemalOmTee.AutoSize = true;
            this.cbxOnskemalOmTee.Location = new System.Drawing.Point(655, 71);
            this.cbxOnskemalOmTee.Name = "cbxOnskemalOmTee";
            this.cbxOnskemalOmTee.Size = new System.Drawing.Size(15, 14);
            this.cbxOnskemalOmTee.TabIndex = 10;
            this.cbxOnskemalOmTee.UseVisualStyleBackColor = true;
            // 
            // cboKlass
            // 
            this.cboKlass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKlass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKlass.FormattingEnabled = true;
            this.cboKlass.Location = new System.Drawing.Point(110, 6);
            this.cboKlass.Name = "cboKlass";
            this.cboKlass.Size = new System.Drawing.Size(100, 21);
            this.cboKlass.TabIndex = 1;
            // 
            // lblKlass
            // 
            this.lblKlass.AutoSize = true;
            this.lblKlass.Location = new System.Drawing.Point(10, 10);
            this.lblKlass.Name = "lblKlass";
            this.lblKlass.Size = new System.Drawing.Size(84, 13);
            this.lblKlass.TabIndex = 103;
            this.lblKlass.Text = "Radrubrik_Klass";
            // 
            // dgwRondinfo
            // 
            this.dgwRondinfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwRondinfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RondID,
            this.Rondnr,
            this.Datum,
            this.ForstaStartTid,
            this.Golfklubb,
            this.BanaNr,
            this.AntalHal,
            this.Cut});
            this.dgwRondinfo.Location = new System.Drawing.Point(6, 18);
            this.dgwRondinfo.Name = "dgwRondinfo";
            this.dgwRondinfo.Size = new System.Drawing.Size(673, 139);
            this.dgwRondinfo.TabIndex = 30;
            this.dgwRondinfo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwRondinfo_CellValueChanged);
            this.dgwRondinfo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgwRondinfo_DataError);
            this.dgwRondinfo.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwRondinfo_RowEnter);
            this.dgwRondinfo.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwRondinfo_RowLeave);
            this.dgwRondinfo.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgwRondinfo_UserDeletedRow);
            // 
            // RondID
            // 
            this.RondID.HeaderText = "RondID";
            this.RondID.Name = "RondID";
            this.RondID.Visible = false;
            this.RondID.Width = 150;
            // 
            // Rondnr
            // 
            this.Rondnr.HeaderText = "Text_Rondnr";
            this.Rondnr.Name = "Rondnr";
            this.Rondnr.Width = 45;
            // 
            // Datum
            // 
            this.Datum.HeaderText = "Rubrik_Datum";
            this.Datum.Name = "Datum";
            this.Datum.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Datum.Width = 70;
            // 
            // ForstaStartTid
            // 
            this.ForstaStartTid.HeaderText = "Text_ForstaStart";
            this.ForstaStartTid.Name = "ForstaStartTid";
            this.ForstaStartTid.Width = 85;
            // 
            // Golfklubb
            // 
            this.Golfklubb.HeaderText = "Text_Golfklubb";
            this.Golfklubb.Name = "Golfklubb";
            this.Golfklubb.Width = 150;
            // 
            // BanaNr
            // 
            this.BanaNr.HeaderText = "Rubrik_Bana";
            this.BanaNr.Name = "BanaNr";
            this.BanaNr.Width = 140;
            // 
            // AntalHal
            // 
            this.AntalHal.HeaderText = "Text_AntalHal";
            this.AntalHal.Name = "AntalHal";
            this.AntalHal.Width = 80;
            // 
            // Cut
            // 
            this.Cut.FalseValue = "0";
            this.Cut.HeaderText = "Text_Cut";
            this.Cut.Name = "Cut";
            this.Cut.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Cut.TrueValue = "1";
            this.Cut.Width = 45;
            // 
            // txtMaxAlderKvinna
            // 
            this.txtMaxAlderKvinna.Location = new System.Drawing.Point(570, 196);
            this.txtMaxAlderKvinna.Name = "txtMaxAlderKvinna";
            this.txtMaxAlderKvinna.Size = new System.Drawing.Size(100, 20);
            this.txtMaxAlderKvinna.TabIndex = 20;
            // 
            // lblMaxAlderKvinna
            // 
            this.lblMaxAlderKvinna.AutoSize = true;
            this.lblMaxAlderKvinna.Location = new System.Drawing.Point(470, 200);
            this.lblMaxAlderKvinna.Name = "lblMaxAlderKvinna";
            this.lblMaxAlderKvinna.Size = new System.Drawing.Size(136, 13);
            this.lblMaxAlderKvinna.TabIndex = 0;
            this.lblMaxAlderKvinna.Text = "Radrubrik_MaxAlderKvinna";
            // 
            // txtMaxHcpLag
            // 
            this.txtMaxHcpLag.Location = new System.Drawing.Point(340, 196);
            this.txtMaxHcpLag.Name = "txtMaxHcpLag";
            this.txtMaxHcpLag.Size = new System.Drawing.Size(100, 20);
            this.txtMaxHcpLag.TabIndex = 16;
            // 
            // txtMinHcpLag
            // 
            this.txtMinHcpLag.Location = new System.Drawing.Point(110, 196);
            this.txtMinHcpLag.Name = "txtMinHcpLag";
            this.txtMinHcpLag.Size = new System.Drawing.Size(100, 20);
            this.txtMinHcpLag.TabIndex = 13;
            // 
            // txtMinHcpKvinna
            // 
            this.txtMinHcpKvinna.Location = new System.Drawing.Point(110, 166);
            this.txtMinHcpKvinna.Name = "txtMinHcpKvinna";
            this.txtMinHcpKvinna.Size = new System.Drawing.Size(100, 20);
            this.txtMinHcpKvinna.TabIndex = 12;
            // 
            // txtMaxHcpMan
            // 
            this.txtMaxHcpMan.Location = new System.Drawing.Point(340, 136);
            this.txtMaxHcpMan.Name = "txtMaxHcpMan";
            this.txtMaxHcpMan.Size = new System.Drawing.Size(100, 20);
            this.txtMaxHcpMan.TabIndex = 14;
            // 
            // txtMinHcpMan
            // 
            this.txtMinHcpMan.Location = new System.Drawing.Point(110, 136);
            this.txtMinHcpMan.Name = "txtMinHcpMan";
            this.txtMinHcpMan.Size = new System.Drawing.Size(100, 20);
            this.txtMinHcpMan.TabIndex = 11;
            // 
            // txtMinAlderKvinna
            // 
            this.txtMinAlderKvinna.Location = new System.Drawing.Point(570, 166);
            this.txtMinAlderKvinna.Name = "txtMinAlderKvinna";
            this.txtMinAlderKvinna.Size = new System.Drawing.Size(100, 20);
            this.txtMinAlderKvinna.TabIndex = 19;
            // 
            // txtMaxAlderMan
            // 
            this.txtMaxAlderMan.Location = new System.Drawing.Point(570, 136);
            this.txtMaxAlderMan.Name = "txtMaxAlderMan";
            this.txtMaxAlderMan.Size = new System.Drawing.Size(100, 20);
            this.txtMaxAlderMan.TabIndex = 18;
            // 
            // txtMinAlderMan
            // 
            this.txtMinAlderMan.Location = new System.Drawing.Point(570, 106);
            this.txtMinAlderMan.Name = "txtMinAlderMan";
            this.txtMinAlderMan.Size = new System.Drawing.Size(100, 20);
            this.txtMinAlderMan.TabIndex = 17;
            // 
            // txtMaxHcpKvinna
            // 
            this.txtMaxHcpKvinna.Location = new System.Drawing.Point(340, 166);
            this.txtMaxHcpKvinna.Name = "txtMaxHcpKvinna";
            this.txtMaxHcpKvinna.Size = new System.Drawing.Size(100, 20);
            this.txtMaxHcpKvinna.TabIndex = 15;
            // 
            // lblMinAlderKvinna
            // 
            this.lblMinAlderKvinna.AutoSize = true;
            this.lblMinAlderKvinna.Location = new System.Drawing.Point(470, 170);
            this.lblMinAlderKvinna.Name = "lblMinAlderKvinna";
            this.lblMinAlderKvinna.Size = new System.Drawing.Size(133, 13);
            this.lblMinAlderKvinna.TabIndex = 0;
            this.lblMinAlderKvinna.Text = "Radrubrik_MinAlderKvinna";
            // 
            // lblMaxAlderMan
            // 
            this.lblMaxAlderMan.AutoSize = true;
            this.lblMaxAlderMan.Location = new System.Drawing.Point(470, 140);
            this.lblMaxAlderMan.Name = "lblMaxAlderMan";
            this.lblMaxAlderMan.Size = new System.Drawing.Size(124, 13);
            this.lblMaxAlderMan.TabIndex = 0;
            this.lblMaxAlderMan.Text = "Radrubrik_MaxAlderMan";
            // 
            // lblMinAlderMan
            // 
            this.lblMinAlderMan.AutoSize = true;
            this.lblMinAlderMan.Location = new System.Drawing.Point(470, 110);
            this.lblMinAlderMan.Name = "lblMinAlderMan";
            this.lblMinAlderMan.Size = new System.Drawing.Size(121, 13);
            this.lblMinAlderMan.TabIndex = 0;
            this.lblMinAlderMan.Text = "Radrubrik_MinAlderMan";
            // 
            // lblMaxHcpLag
            // 
            this.lblMaxHcpLag.AutoSize = true;
            this.lblMaxHcpLag.Location = new System.Drawing.Point(240, 200);
            this.lblMaxHcpLag.Name = "lblMaxHcpLag";
            this.lblMaxHcpLag.Size = new System.Drawing.Size(117, 13);
            this.lblMaxHcpLag.TabIndex = 0;
            this.lblMaxHcpLag.Text = "Radrubrik_MaxHcpLag";
            // 
            // lblMinHcpLag
            // 
            this.lblMinHcpLag.AutoSize = true;
            this.lblMinHcpLag.Location = new System.Drawing.Point(10, 200);
            this.lblMinHcpLag.Name = "lblMinHcpLag";
            this.lblMinHcpLag.Size = new System.Drawing.Size(114, 13);
            this.lblMinHcpLag.TabIndex = 0;
            this.lblMinHcpLag.Text = "Radrubrik_MinHcpLag";
            // 
            // lblMinHcpKvinna
            // 
            this.lblMinHcpKvinna.AutoSize = true;
            this.lblMinHcpKvinna.Location = new System.Drawing.Point(10, 170);
            this.lblMinHcpKvinna.Name = "lblMinHcpKvinna";
            this.lblMinHcpKvinna.Size = new System.Drawing.Size(129, 13);
            this.lblMinHcpKvinna.TabIndex = 0;
            this.lblMinHcpKvinna.Text = "Radrubrik_MinHcpKvinna";
            // 
            // lblMaxHcpKvinna
            // 
            this.lblMaxHcpKvinna.AutoSize = true;
            this.lblMaxHcpKvinna.Location = new System.Drawing.Point(240, 170);
            this.lblMaxHcpKvinna.Name = "lblMaxHcpKvinna";
            this.lblMaxHcpKvinna.Size = new System.Drawing.Size(132, 13);
            this.lblMaxHcpKvinna.TabIndex = 0;
            this.lblMaxHcpKvinna.Text = "Radrubrik_MaxHcpKvinna";
            // 
            // lblMaxHcpMan
            // 
            this.lblMaxHcpMan.AutoSize = true;
            this.lblMaxHcpMan.Location = new System.Drawing.Point(240, 140);
            this.lblMaxHcpMan.Name = "lblMaxHcpMan";
            this.lblMaxHcpMan.Size = new System.Drawing.Size(120, 13);
            this.lblMaxHcpMan.TabIndex = 0;
            this.lblMaxHcpMan.Text = "Radrubrik_MaxHcpMan";
            // 
            // lblMinHcpMan
            // 
            this.lblMinHcpMan.AutoSize = true;
            this.lblMinHcpMan.Location = new System.Drawing.Point(10, 140);
            this.lblMinHcpMan.Name = "lblMinHcpMan";
            this.lblMinHcpMan.Size = new System.Drawing.Size(117, 13);
            this.lblMinHcpMan.TabIndex = 0;
            this.lblMinHcpMan.Text = "Radrubrik_MinHcpMan";
            // 
            // txtTillaggsavgift
            // 
            this.txtTillaggsavgift.Location = new System.Drawing.Point(340, 66);
            this.txtTillaggsavgift.Name = "txtTillaggsavgift";
            this.txtTillaggsavgift.Size = new System.Drawing.Size(100, 20);
            this.txtTillaggsavgift.TabIndex = 7;
            // 
            // txtAnmalningsavgift
            // 
            this.txtAnmalningsavgift.Location = new System.Drawing.Point(340, 36);
            this.txtAnmalningsavgift.Name = "txtAnmalningsavgift";
            this.txtAnmalningsavgift.Size = new System.Drawing.Size(100, 20);
            this.txtAnmalningsavgift.TabIndex = 6;
            // 
            // txtRonder
            // 
            this.txtRonder.Location = new System.Drawing.Point(340, 6);
            this.txtRonder.Name = "txtRonder";
            this.txtRonder.Size = new System.Drawing.Size(100, 20);
            this.txtRonder.TabIndex = 5;
            // 
            // cboTeeKvinna
            // 
            this.cboTeeKvinna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTeeKvinna.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTeeKvinna.FormattingEnabled = true;
            this.cboTeeKvinna.Location = new System.Drawing.Point(570, 36);
            this.cboTeeKvinna.Name = "cboTeeKvinna";
            this.cboTeeKvinna.Size = new System.Drawing.Size(100, 21);
            this.cboTeeKvinna.TabIndex = 9;
            // 
            // cboTeeMan
            // 
            this.cboTeeMan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTeeMan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTeeMan.FormattingEnabled = true;
            this.cboTeeMan.Location = new System.Drawing.Point(570, 6);
            this.cboTeeMan.Name = "cboTeeMan";
            this.cboTeeMan.Size = new System.Drawing.Size(100, 21);
            this.cboTeeMan.TabIndex = 8;
            // 
            // cboKon
            // 
            this.cboKon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKon.FormattingEnabled = true;
            this.cboKon.Location = new System.Drawing.Point(110, 96);
            this.cboKon.Name = "cboKon";
            this.cboKon.Size = new System.Drawing.Size(100, 21);
            this.cboKon.TabIndex = 4;
            // 
            // cboKlasstyp
            // 
            this.cboKlasstyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKlasstyp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKlasstyp.FormattingEnabled = true;
            this.cboKlasstyp.Location = new System.Drawing.Point(110, 66);
            this.cboKlasstyp.Name = "cboKlasstyp";
            this.cboKlasstyp.Size = new System.Drawing.Size(100, 21);
            this.cboKlasstyp.TabIndex = 3;
            // 
            // cboSpelform
            // 
            this.cboSpelform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSpelform.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSpelform.FormattingEnabled = true;
            this.cboSpelform.Location = new System.Drawing.Point(110, 36);
            this.cboSpelform.Name = "cboSpelform";
            this.cboSpelform.Size = new System.Drawing.Size(100, 21);
            this.cboSpelform.TabIndex = 2;
            // 
            // lblTillaggsavgift
            // 
            this.lblTillaggsavgift.AutoSize = true;
            this.lblTillaggsavgift.Location = new System.Drawing.Point(240, 70);
            this.lblTillaggsavgift.Name = "lblTillaggsavgift";
            this.lblTillaggsavgift.Size = new System.Drawing.Size(121, 13);
            this.lblTillaggsavgift.TabIndex = 0;
            this.lblTillaggsavgift.Text = "Radrubrik_Tilläggsavgift";
            // 
            // lblAnmalningsavgift
            // 
            this.lblAnmalningsavgift.AutoSize = true;
            this.lblAnmalningsavgift.Location = new System.Drawing.Point(240, 40);
            this.lblAnmalningsavgift.Name = "lblAnmalningsavgift";
            this.lblAnmalningsavgift.Size = new System.Drawing.Size(139, 13);
            this.lblAnmalningsavgift.TabIndex = 0;
            this.lblAnmalningsavgift.Text = "Radrubrik_Anmälningsavgift";
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(289, 8);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(402, 33);
            this.knappkontroller1.TabIndex = 100;
            this.knappkontroller1.OnKnapp1Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp1ClickEventHandler(this.knappkontroller1_OnKnapp1Click);
            this.knappkontroller1.OnKnapp2Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp2ClickEventHandler(this.knappkontroller1_OnKnapp2Click);
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.knappkontroller1_OnKnapp3Click);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // lblOnskemal
            // 
            this.lblOnskemal.AutoSize = true;
            this.lblOnskemal.Location = new System.Drawing.Point(470, 70);
            this.lblOnskemal.Name = "lblOnskemal";
            this.lblOnskemal.Size = new System.Drawing.Size(141, 13);
            this.lblOnskemal.TabIndex = 0;
            this.lblOnskemal.Text = "Radrubrik_OnskemalOmTee";
            // 
            // lblTeeKvinna
            // 
            this.lblTeeKvinna.AutoSize = true;
            this.lblTeeKvinna.Location = new System.Drawing.Point(470, 40);
            this.lblTeeKvinna.Name = "lblTeeKvinna";
            this.lblTeeKvinna.Size = new System.Drawing.Size(111, 13);
            this.lblTeeKvinna.TabIndex = 0;
            this.lblTeeKvinna.Text = "Radrubrik_TeeKvinna";
            // 
            // lblTeeMan
            // 
            this.lblTeeMan.AutoSize = true;
            this.lblTeeMan.Location = new System.Drawing.Point(470, 10);
            this.lblTeeMan.Name = "lblTeeMan";
            this.lblTeeMan.Size = new System.Drawing.Size(99, 13);
            this.lblTeeMan.TabIndex = 0;
            this.lblTeeMan.Text = "Radrubrik_TeeMan";
            // 
            // lblKon
            // 
            this.lblKon.AutoSize = true;
            this.lblKon.Location = new System.Drawing.Point(10, 100);
            this.lblKon.Name = "lblKon";
            this.lblKon.Size = new System.Drawing.Size(78, 13);
            this.lblKon.TabIndex = 0;
            this.lblKon.Text = "Radrubrik_Kon";
            // 
            // lblRonder
            // 
            this.lblRonder.AutoSize = true;
            this.lblRonder.Location = new System.Drawing.Point(240, 10);
            this.lblRonder.Name = "lblRonder";
            this.lblRonder.Size = new System.Drawing.Size(94, 13);
            this.lblRonder.TabIndex = 0;
            this.lblRonder.Text = "Radrubrik_Ronder";
            // 
            // lblKlasstyp
            // 
            this.lblKlasstyp.AutoSize = true;
            this.lblKlasstyp.Location = new System.Drawing.Point(10, 70);
            this.lblKlasstyp.Name = "lblKlasstyp";
            this.lblKlasstyp.Size = new System.Drawing.Size(98, 13);
            this.lblKlasstyp.TabIndex = 0;
            this.lblKlasstyp.Text = "Radrubrik_Klasstyp";
            // 
            // lblSpelfom
            // 
            this.lblSpelfom.AutoSize = true;
            this.lblSpelfom.Location = new System.Drawing.Point(10, 40);
            this.lblSpelfom.Name = "lblSpelfom";
            this.lblSpelfom.Size = new System.Drawing.Size(100, 13);
            this.lblSpelfom.TabIndex = 0;
            this.lblSpelfom.Text = "Radrubrik_Spelform";
            // 
            // gbxKnappkontroll
            // 
            this.gbxKnappkontroll.Controls.Add(this.tangentkontroll1);
            this.gbxKnappkontroll.Controls.Add(this.knappkontroller1);
            this.gbxKnappkontroll.Location = new System.Drawing.Point(-2, 387);
            this.gbxKnappkontroll.Name = "gbxKnappkontroll";
            this.gbxKnappkontroll.Size = new System.Drawing.Size(709, 52);
            this.gbxKnappkontroll.TabIndex = 0;
            this.gbxKnappkontroll.TabStop = false;
            this.gbxKnappkontroll.Text = "Text_Blank";
            // 
            // tangentkontroll1
            // 
            this.tangentkontroll1.Location = new System.Drawing.Point(18, 17);
            this.tangentkontroll1.Name = "tangentkontroll1";
            this.tangentkontroll1.Size = new System.Drawing.Size(150, 10);
            this.tangentkontroll1.TabIndex = 0;
            // 
            // gbxRondinfo
            // 
            this.gbxRondinfo.Controls.Add(this.dgwRondinfo);
            this.gbxRondinfo.Location = new System.Drawing.Point(1, 222);
            this.gbxRondinfo.Name = "gbxRondinfo";
            this.gbxRondinfo.Size = new System.Drawing.Size(703, 163);
            this.gbxRondinfo.TabIndex = 102;
            this.gbxRondinfo.TabStop = false;
            this.gbxRondinfo.Text = "Text_Rondinfo";
            // 
            // fönsterhanterare1
            // 
            this.fönsterhanterare1.Location = new System.Drawing.Point(91, 266);
            this.fönsterhanterare1.Name = "fönsterhanterare1";
            this.fönsterhanterare1.Size = new System.Drawing.Size(150, 150);
            this.fönsterhanterare1.TabIndex = 0;
            // 
            // KlassInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 430);
            this.Controls.Add(this.cbxOnskemalOmTee);
            this.Controls.Add(this.cboKlass);
            this.Controls.Add(this.lblKlass);
            this.Controls.Add(this.txtMaxAlderKvinna);
            this.Controls.Add(this.lblMaxAlderKvinna);
            this.Controls.Add(this.txtMaxHcpLag);
            this.Controls.Add(this.txtMinHcpLag);
            this.Controls.Add(this.txtMinHcpKvinna);
            this.Controls.Add(this.txtMaxHcpMan);
            this.Controls.Add(this.txtMinHcpMan);
            this.Controls.Add(this.txtMinAlderKvinna);
            this.Controls.Add(this.txtMaxAlderMan);
            this.Controls.Add(this.txtMinAlderMan);
            this.Controls.Add(this.txtMaxHcpKvinna);
            this.Controls.Add(this.lblMinAlderKvinna);
            this.Controls.Add(this.lblMaxAlderMan);
            this.Controls.Add(this.lblMinAlderMan);
            this.Controls.Add(this.lblMaxHcpLag);
            this.Controls.Add(this.lblMinHcpLag);
            this.Controls.Add(this.lblMinHcpKvinna);
            this.Controls.Add(this.lblMaxHcpKvinna);
            this.Controls.Add(this.lblMaxHcpMan);
            this.Controls.Add(this.lblMinHcpMan);
            this.Controls.Add(this.txtTillaggsavgift);
            this.Controls.Add(this.txtAnmalningsavgift);
            this.Controls.Add(this.txtRonder);
            this.Controls.Add(this.cboTeeKvinna);
            this.Controls.Add(this.cboTeeMan);
            this.Controls.Add(this.cboKon);
            this.Controls.Add(this.cboKlasstyp);
            this.Controls.Add(this.cboSpelform);
            this.Controls.Add(this.lblTillaggsavgift);
            this.Controls.Add(this.lblAnmalningsavgift);
            this.Controls.Add(this.lblOnskemal);
            this.Controls.Add(this.lblTeeKvinna);
            this.Controls.Add(this.lblTeeMan);
            this.Controls.Add(this.lblKon);
            this.Controls.Add(this.lblRonder);
            this.Controls.Add(this.lblKlasstyp);
            this.Controls.Add(this.lblSpelfom);
            this.Controls.Add(this.gbxKnappkontroll);
            this.Controls.Add(this.gbxRondinfo);
            this.Controls.Add(this.fönsterhanterare1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "KlassInfo";
            this.Text = "Titel_KlassInfo";
            this.Load += new System.EventHandler(this.KlassInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwRondinfo)).EndInit();
            this.gbxKnappkontroll.ResumeLayout(false);
            this.gbxRondinfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Kontroller.Knappkontroller knappkontroller1;
        private System.Windows.Forms.GroupBox gbxKnappkontroll;
        private System.Windows.Forms.Label lblSpelfom;
        private System.Windows.Forms.Label lblKlasstyp;
        private System.Windows.Forms.Label lblRonder;
        private System.Windows.Forms.Label lblKon;
        private System.Windows.Forms.Label lblTeeMan;
        private System.Windows.Forms.Label lblTeeKvinna;
        private System.Windows.Forms.Label lblOnskemal;
        private System.Windows.Forms.Label lblAnmalningsavgift;
        private System.Windows.Forms.Label lblTillaggsavgift;
        private System.Windows.Forms.ComboBox cboSpelform;
        private System.Windows.Forms.ComboBox cboKlasstyp;
        private System.Windows.Forms.ComboBox cboKon;
        private System.Windows.Forms.ComboBox cboTeeMan;
        private System.Windows.Forms.ComboBox cboTeeKvinna;
        private System.Windows.Forms.TextBox txtRonder;
        private System.Windows.Forms.TextBox txtAnmalningsavgift;
        private System.Windows.Forms.TextBox txtTillaggsavgift;
        private System.Windows.Forms.TextBox txtMinAlderKvinna;
        private System.Windows.Forms.TextBox txtMaxAlderMan;
        private System.Windows.Forms.TextBox txtMinAlderMan;
        private System.Windows.Forms.TextBox txtMaxHcpKvinna;
        private System.Windows.Forms.Label lblMinAlderKvinna;
        private System.Windows.Forms.Label lblMaxAlderMan;
        private System.Windows.Forms.Label lblMinAlderMan;
        private System.Windows.Forms.Label lblMaxHcpLag;
        private System.Windows.Forms.Label lblMinHcpLag;
        private System.Windows.Forms.Label lblMinHcpKvinna;
        private System.Windows.Forms.Label lblMaxHcpKvinna;
        private System.Windows.Forms.Label lblMaxHcpMan;
        private System.Windows.Forms.Label lblMinHcpMan;
        private System.Windows.Forms.TextBox txtMinHcpMan;
        private System.Windows.Forms.TextBox txtMaxHcpMan;
        private System.Windows.Forms.TextBox txtMinHcpKvinna;
        private System.Windows.Forms.TextBox txtMinHcpLag;
        private System.Windows.Forms.TextBox txtMaxHcpLag;
        private System.Windows.Forms.TextBox txtMaxAlderKvinna;
        private System.Windows.Forms.Label lblMaxAlderKvinna;
        private System.Windows.Forms.DataGridView dgwRondinfo;
        private System.Windows.Forms.GroupBox gbxRondinfo;
        private System.Windows.Forms.ComboBox cboKlass;
        private System.Windows.Forms.Label lblKlass;
        private Kontroller.Tangentkontroll tangentkontroll1;
        private System.Windows.Forms.CheckBox cbxOnskemalOmTee;
        private Kontroller.Fönsterhanterare fönsterhanterare1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RondID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rondnr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ForstaStartTid;
        private System.Windows.Forms.DataGridViewComboBoxColumn Golfklubb;
        private System.Windows.Forms.DataGridViewComboBoxColumn BanaNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn AntalHal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Cut;

    }
}