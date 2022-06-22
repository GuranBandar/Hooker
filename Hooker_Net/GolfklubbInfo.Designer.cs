namespace Hooker_GUI
{
    partial class GolfklubbInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GolfklubbInfo));
            this.gbxBanor = new System.Windows.Forms.GroupBox();
            this.dgwBanor = new System.Windows.Forms.DataGridView();
            this.BanaNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BanaNamn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aktuell = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Par = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LängdGul = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LängdRöd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lnkHemsida = new System.Windows.Forms.LinkLabel();
            this.txtHemsida = new System.Windows.Forms.TextBox();
            this.lblHemsida = new System.Windows.Forms.Label();
            this.txtEpost = new System.Windows.Forms.TextBox();
            this.lblEpost = new System.Windows.Forms.Label();
            this.txtTelKansli = new System.Windows.Forms.TextBox();
            this.lblKansli = new System.Windows.Forms.Label();
            this.txtAdressOrt = new System.Windows.Forms.TextBox();
            this.lblBokningen = new System.Windows.Forms.Label();
            this.txtTelBokning = new System.Windows.Forms.TextBox();
            this.txtAdressBesok = new System.Windows.Forms.TextBox();
            this.lblTelefonnr = new System.Windows.Forms.Label();
            this.lblAdress = new System.Windows.Forms.Label();
            this.txtGolfklubbNamn = new System.Windows.Forms.TextBox();
            this.cboDistrikt = new System.Windows.Forms.ComboBox();
            this.lblBanaNamn = new System.Windows.Forms.Label();
            this.lblDistrikt = new System.Windows.Forms.Label();
            this.cboLand = new System.Windows.Forms.ComboBox();
            this.lblLand = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbxAdressinfo = new System.Windows.Forms.GroupBox();
            this.txtNotering = new System.Windows.Forms.TextBox();
            this.lblNotering = new System.Windows.Forms.Label();
            this.fönsterhanterare1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.gbxBanor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwBanor)).BeginInit();
            this.gbxAdressinfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxBanor
            // 
            this.gbxBanor.Controls.Add(this.dgwBanor);
            this.gbxBanor.Location = new System.Drawing.Point(9, 226);
            this.gbxBanor.Name = "gbxBanor";
            this.gbxBanor.Size = new System.Drawing.Size(506, 116);
            this.gbxBanor.TabIndex = 234;
            this.gbxBanor.TabStop = false;
            this.gbxBanor.Text = "Rubrik_Banor";
            // 
            // dgwBanor
            // 
            this.dgwBanor.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgwBanor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwBanor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BanaNr,
            this.BanaNamn,
            this.Aktuell,
            this.Par,
            this.LängdGul,
            this.LängdRöd});
            this.dgwBanor.Location = new System.Drawing.Point(6, 20);
            this.dgwBanor.Name = "dgwBanor";
            this.dgwBanor.ReadOnly = true;
            this.dgwBanor.Size = new System.Drawing.Size(494, 80);
            this.dgwBanor.TabIndex = 100;
            this.dgwBanor.DoubleClick += new System.EventHandler(this.dgwBanor_DoubleClick);
            // 
            // BanaNr
            // 
            this.BanaNr.HeaderText = "BanaNr";
            this.BanaNr.Name = "BanaNr";
            this.BanaNr.ReadOnly = true;
            this.BanaNr.Visible = false;
            // 
            // BanaNamn
            // 
            this.BanaNamn.HeaderText = "Text_Namn";
            this.BanaNamn.Name = "BanaNamn";
            this.BanaNamn.ReadOnly = true;
            this.BanaNamn.Width = 150;
            // 
            // Aktuell
            // 
            this.Aktuell.HeaderText = "Rubrik_Aktuell";
            this.Aktuell.Name = "Aktuell";
            this.Aktuell.ReadOnly = true;
            this.Aktuell.Width = 50;
            // 
            // Par
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Par.DefaultCellStyle = dataGridViewCellStyle1;
            this.Par.HeaderText = "Rubrik_Par";
            this.Par.Name = "Par";
            this.Par.ReadOnly = true;
            this.Par.Width = 60;
            // 
            // LängdGul
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.LängdGul.DefaultCellStyle = dataGridViewCellStyle2;
            this.LängdGul.HeaderText = "Rubrik_LangdGul";
            this.LängdGul.Name = "LängdGul";
            this.LängdGul.ReadOnly = true;
            this.LängdGul.Width = 85;
            // 
            // LängdRöd
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.LängdRöd.DefaultCellStyle = dataGridViewCellStyle3;
            this.LängdRöd.HeaderText = "Rubrik_LangdRod";
            this.LängdRöd.Name = "LängdRöd";
            this.LängdRöd.ReadOnly = true;
            this.LängdRöd.Width = 85;
            // 
            // lnkHemsida
            // 
            this.lnkHemsida.AutoSize = true;
            this.lnkHemsida.Location = new System.Drawing.Point(412, 130);
            this.lnkHemsida.Name = "lnkHemsida";
            this.lnkHemsida.Size = new System.Drawing.Size(88, 13);
            this.lnkHemsida.TabIndex = 230;
            this.lnkHemsida.TabStop = true;
            this.lnkHemsida.Text = "Text_TillHemsida";
            this.lnkHemsida.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHemsida_LinkClicked);
            // 
            // txtHemsida
            // 
            this.txtHemsida.Location = new System.Drawing.Point(272, 165);
            this.txtHemsida.Name = "txtHemsida";
            this.txtHemsida.Size = new System.Drawing.Size(238, 20);
            this.txtHemsida.TabIndex = 9;
            // 
            // lblHemsida
            // 
            this.lblHemsida.AutoSize = true;
            this.lblHemsida.Location = new System.Drawing.Point(272, 149);
            this.lblHemsida.Name = "lblHemsida";
            this.lblHemsida.Size = new System.Drawing.Size(85, 13);
            this.lblHemsida.TabIndex = 218;
            this.lblHemsida.Text = "Rubrik_Hemsida";
            // 
            // txtEpost
            // 
            this.txtEpost.Location = new System.Drawing.Point(15, 166);
            this.txtEpost.Name = "txtEpost";
            this.txtEpost.Size = new System.Drawing.Size(230, 20);
            this.txtEpost.TabIndex = 8;
            // 
            // lblEpost
            // 
            this.lblEpost.AutoSize = true;
            this.lblEpost.Location = new System.Drawing.Point(18, 149);
            this.lblEpost.Name = "lblEpost";
            this.lblEpost.Size = new System.Drawing.Size(71, 13);
            this.lblEpost.TabIndex = 223;
            this.lblEpost.Text = "Rubrik_Epost";
            // 
            // txtTelKansli
            // 
            this.txtTelKansli.Location = new System.Drawing.Point(379, 125);
            this.txtTelKansli.Name = "txtTelKansli";
            this.txtTelKansli.Size = new System.Drawing.Size(131, 20);
            this.txtTelKansli.TabIndex = 7;
            // 
            // lblKansli
            // 
            this.lblKansli.AutoSize = true;
            this.lblKansli.Location = new System.Drawing.Point(272, 128);
            this.lblKansli.Name = "lblKansli";
            this.lblKansli.Size = new System.Drawing.Size(87, 13);
            this.lblKansli.TabIndex = 219;
            this.lblKansli.Text = "Radrubrik_Kansli";
            // 
            // txtAdressOrt
            // 
            this.txtAdressOrt.Location = new System.Drawing.Point(15, 125);
            this.txtAdressOrt.Name = "txtAdressOrt";
            this.txtAdressOrt.Size = new System.Drawing.Size(230, 20);
            this.txtAdressOrt.TabIndex = 5;
            // 
            // lblBokningen
            // 
            this.lblBokningen.AutoSize = true;
            this.lblBokningen.Location = new System.Drawing.Point(272, 101);
            this.lblBokningen.Name = "lblBokningen";
            this.lblBokningen.Size = new System.Drawing.Size(110, 13);
            this.lblBokningen.TabIndex = 222;
            this.lblBokningen.Text = "Radrubrik_Bokningen";
            // 
            // txtTelBokning
            // 
            this.txtTelBokning.Location = new System.Drawing.Point(379, 99);
            this.txtTelBokning.Name = "txtTelBokning";
            this.txtTelBokning.Size = new System.Drawing.Size(131, 20);
            this.txtTelBokning.TabIndex = 6;
            // 
            // txtAdressBesok
            // 
            this.txtAdressBesok.Location = new System.Drawing.Point(15, 99);
            this.txtAdressBesok.Name = "txtAdressBesok";
            this.txtAdressBesok.Size = new System.Drawing.Size(230, 20);
            this.txtAdressBesok.TabIndex = 4;
            // 
            // lblTelefonnr
            // 
            this.lblTelefonnr.AutoSize = true;
            this.lblTelefonnr.Location = new System.Drawing.Point(376, 82);
            this.lblTelefonnr.Name = "lblTelefonnr";
            this.lblTelefonnr.Size = new System.Drawing.Size(89, 13);
            this.lblTelefonnr.TabIndex = 220;
            this.lblTelefonnr.Text = "Rubrik_Telefonnr";
            // 
            // lblAdress
            // 
            this.lblAdress.AutoSize = true;
            this.lblAdress.Location = new System.Drawing.Point(15, 82);
            this.lblAdress.Name = "lblAdress";
            this.lblAdress.Size = new System.Drawing.Size(76, 13);
            this.lblAdress.TabIndex = 221;
            this.lblAdress.Text = "Rubrik_Adress";
            // 
            // txtGolfklubbNamn
            // 
            this.txtGolfklubbNamn.Location = new System.Drawing.Point(83, 11);
            this.txtGolfklubbNamn.Name = "txtGolfklubbNamn";
            this.txtGolfklubbNamn.Size = new System.Drawing.Size(301, 20);
            this.txtGolfklubbNamn.TabIndex = 1;
            // 
            // cboDistrikt
            // 
            this.cboDistrikt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrikt.FormattingEnabled = true;
            this.cboDistrikt.Location = new System.Drawing.Point(338, 40);
            this.cboDistrikt.Name = "cboDistrikt";
            this.cboDistrikt.Size = new System.Drawing.Size(172, 21);
            this.cboDistrikt.Sorted = true;
            this.cboDistrikt.TabIndex = 3;
            this.cboDistrikt.SelectedIndexChanged += new System.EventHandler(this.cboDistrikt_SelectedIndexChanged);
            // 
            // lblBanaNamn
            // 
            this.lblBanaNamn.AutoSize = true;
            this.lblBanaNamn.Location = new System.Drawing.Point(14, 14);
            this.lblBanaNamn.Name = "lblBanaNamn";
            this.lblBanaNamn.Size = new System.Drawing.Size(87, 13);
            this.lblBanaNamn.TabIndex = 116;
            this.lblBanaNamn.Text = "Radrubrik_Namn";
            // 
            // lblDistrikt
            // 
            this.lblDistrikt.AutoSize = true;
            this.lblDistrikt.Location = new System.Drawing.Point(263, 43);
            this.lblDistrikt.Name = "lblDistrikt";
            this.lblDistrikt.Size = new System.Drawing.Size(91, 13);
            this.lblDistrikt.TabIndex = 117;
            this.lblDistrikt.Text = "Radrubrik_Distrikt";
            // 
            // cboLand
            // 
            this.cboLand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLand.FormattingEnabled = true;
            this.cboLand.Location = new System.Drawing.Point(83, 40);
            this.cboLand.Name = "cboLand";
            this.cboLand.Size = new System.Drawing.Size(164, 21);
            this.cboLand.Sorted = true;
            this.cboLand.TabIndex = 2;
            this.cboLand.SelectedIndexChanged += new System.EventHandler(this.cboLand_SelectedIndexChanged);
            // 
            // lblLand
            // 
            this.lblLand.AutoSize = true;
            this.lblLand.Location = new System.Drawing.Point(14, 43);
            this.lblLand.Name = "lblLand";
            this.lblLand.Size = new System.Drawing.Size(83, 13);
            this.lblLand.TabIndex = 111;
            this.lblLand.Text = "Radrubrik_Land";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(-2, 341);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 41);
            this.groupBox1.TabIndex = 232;
            this.groupBox1.TabStop = false;
            // 
            // gbxAdressinfo
            // 
            this.gbxAdressinfo.Controls.Add(this.txtNotering);
            this.gbxAdressinfo.Controls.Add(this.lblNotering);
            this.gbxAdressinfo.Controls.Add(this.fönsterhanterare1);
            this.gbxAdressinfo.Controls.Add(this.lnkHemsida);
            this.gbxAdressinfo.Location = new System.Drawing.Point(9, 67);
            this.gbxAdressinfo.Name = "gbxAdressinfo";
            this.gbxAdressinfo.Size = new System.Drawing.Size(506, 153);
            this.gbxAdressinfo.TabIndex = 233;
            this.gbxAdressinfo.TabStop = false;
            this.gbxAdressinfo.Text = "Text_Blank";
            // 
            // txtNotering
            // 
            this.txtNotering.Location = new System.Drawing.Point(82, 126);
            this.txtNotering.Name = "txtNotering";
            this.txtNotering.Size = new System.Drawing.Size(291, 20);
            this.txtNotering.TabIndex = 10;
            // 
            // lblNotering
            // 
            this.lblNotering.AutoSize = true;
            this.lblNotering.Location = new System.Drawing.Point(9, 129);
            this.lblNotering.Name = "lblNotering";
            this.lblNotering.Size = new System.Drawing.Size(99, 13);
            this.lblNotering.TabIndex = 231;
            this.lblNotering.Text = "Radrubrik_Notering";
            // 
            // fönsterhanterare1
            // 
            this.fönsterhanterare1.Location = new System.Drawing.Point(53, 137);
            this.fönsterhanterare1.Name = "fönsterhanterare1";
            this.fönsterhanterare1.Size = new System.Drawing.Size(150, 10);
            this.fönsterhanterare1.TabIndex = 0;
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(98, 348);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 20;
            this.knappkontroller1.OnKnapp0Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp0ClickEventHandler(this.knappkontroller1_OnKnapp0Click_1);
            this.knappkontroller1.OnKnapp1Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp1ClickEventHandler(this.knappkontroller1_OnKnapp1Click);
            this.knappkontroller1.OnKnapp2Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp2ClickEventHandler(this.knappkontroller1_OnKnapp2Click);
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.knappkontroller1_OnKnapp3Click);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // GolfklubbInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 382);
            this.Controls.Add(this.gbxBanor);
            this.Controls.Add(this.knappkontroller1);
            this.Controls.Add(this.txtHemsida);
            this.Controls.Add(this.lblHemsida);
            this.Controls.Add(this.txtEpost);
            this.Controls.Add(this.lblEpost);
            this.Controls.Add(this.txtTelKansli);
            this.Controls.Add(this.lblKansli);
            this.Controls.Add(this.txtAdressOrt);
            this.Controls.Add(this.lblBokningen);
            this.Controls.Add(this.txtTelBokning);
            this.Controls.Add(this.txtAdressBesok);
            this.Controls.Add(this.lblTelefonnr);
            this.Controls.Add(this.lblAdress);
            this.Controls.Add(this.txtGolfklubbNamn);
            this.Controls.Add(this.cboDistrikt);
            this.Controls.Add(this.lblBanaNamn);
            this.Controls.Add(this.lblDistrikt);
            this.Controls.Add(this.cboLand);
            this.Controls.Add(this.lblLand);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxAdressinfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GolfklubbInfo";
            this.Text = "Text_GolfklubbInfo";
            this.Load += new System.EventHandler(this.GolfklubbInfo_Load);
            this.gbxBanor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwBanor)).EndInit();
            this.gbxAdressinfo.ResumeLayout(false);
            this.gbxAdressinfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGolfklubbNamn;
        private System.Windows.Forms.ComboBox cboDistrikt;
        private System.Windows.Forms.Label lblBanaNamn;
        private System.Windows.Forms.Label lblDistrikt;
        private System.Windows.Forms.ComboBox cboLand;
        private System.Windows.Forms.Label lblLand;
        private System.Windows.Forms.LinkLabel lnkHemsida;
        private System.Windows.Forms.TextBox txtHemsida;
        private System.Windows.Forms.Label lblHemsida;
        private System.Windows.Forms.TextBox txtEpost;
        private System.Windows.Forms.Label lblEpost;
        private System.Windows.Forms.TextBox txtTelKansli;
        private System.Windows.Forms.Label lblKansli;
        private System.Windows.Forms.TextBox txtAdressOrt;
        private System.Windows.Forms.Label lblBokningen;
        private System.Windows.Forms.TextBox txtTelBokning;
        private System.Windows.Forms.TextBox txtAdressBesok;
        private System.Windows.Forms.Label lblTelefonnr;
        private System.Windows.Forms.Label lblAdress;
        private Kontroller.Knappkontroller knappkontroller1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbxAdressinfo;
        private Kontroller.Fönsterhanterare fönsterhanterare1;
        private System.Windows.Forms.GroupBox gbxBanor;
        private System.Windows.Forms.DataGridView dgwBanor;
        private System.Windows.Forms.DataGridViewTextBoxColumn BanaNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn BanaNamn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Aktuell;
        private System.Windows.Forms.DataGridViewTextBoxColumn Par;
        private System.Windows.Forms.DataGridViewTextBoxColumn LängdGul;
        private System.Windows.Forms.DataGridViewTextBoxColumn LängdRöd;
        private System.Windows.Forms.TextBox txtNotering;
        private System.Windows.Forms.Label lblNotering;
    }
}