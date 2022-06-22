using Hooker_GUI.Kontroller;
using System;

namespace Hooker_GUI
{
    /// <summary>
    /// Klass för Om
    /// </summary>
	public class Om : FormBas
    {

        #region "Windows Form Designer generated code "
        /// <summary>
        /// Om
        /// </summary>
        public Om()
        {
            //This call is required by the Windows Form Designer.
            InitializeComponent();
        }
        //Form overrides dispose to clean up the component list.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Disposing"></param>
        protected override void Dispose(bool Disposing)
        {
            if (Disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(Disposing);
        }

        private System.ComponentModel.IContainer components;
        //Required by the Windows Form Designer
        /// <summary>
        /// 
        /// </summary>
        public System.Windows.Forms.ToolTip ToolTip1;
        /// <summary>
        /// 
        /// </summary>
		public System.Windows.Forms.PictureBox picIcon;
        /// <summary>
        /// 
        /// </summary>
		public System.Windows.Forms.Label lblDescription;
        /// <summary>
        /// 
        /// </summary>
		public System.Windows.Forms.Label lblTitle;
        /// <summary>
        /// 
        /// </summary>
		public System.Windows.Forms.Label _Line1_1;
        /// <summary>
        /// 
        /// </summary>
		public System.Windows.Forms.Label _Line1_0;
        /// <summary>
        /// 
        /// </summary>
        private Hooker_GUI.Kontroller.Knappkontroller knappkontroller1;
        /// <summary>
        /// 
        /// </summary>
		public System.Windows.Forms.Label lblVersion;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Om));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this._Line1_1 = new System.Windows.Forms.Label();
            this._Line1_0 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.picIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picIcon.Cursor = System.Windows.Forms.Cursors.Default;
            this.picIcon.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picIcon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.picIcon.Image = ((System.Drawing.Image)(resources.GetObject("picIcon.Image")));
            this.picIcon.Location = new System.Drawing.Point(16, 12);
            this.picIcon.Name = "picIcon";
            this.picIcon.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.picIcon.Size = new System.Drawing.Size(36, 36);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblDescription.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblDescription.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.White;
            this.lblDescription.Location = new System.Drawing.Point(70, 84);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDescription.Size = new System.Drawing.Size(273, 78);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Tag = "App Description";
            this.lblDescription.Text = "App Description";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(70, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTitle.Size = new System.Drawing.Size(273, 32);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Tag = "Application Title";
            this.lblTitle.Text = "Application Title";
            // 
            // _Line1_1
            // 
            this._Line1_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this._Line1_1.Location = new System.Drawing.Point(15, 169);
            this._Line1_1.Name = "_Line1_1";
            this._Line1_1.Size = new System.Drawing.Size(363, 1);
            this._Line1_1.TabIndex = 5;
            // 
            // _Line1_0
            // 
            this._Line1_0.BackColor = System.Drawing.Color.White;
            this._Line1_0.Location = new System.Drawing.Point(16, 163);
            this._Line1_0.Name = "_Line1_0";
            this._Line1_0.Size = new System.Drawing.Size(362, 1);
            this._Line1_0.TabIndex = 6;
            // 
            // lblVersion
            // 
            this.lblVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblVersion.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(70, 52);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblVersion.Size = new System.Drawing.Size(273, 20);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Tag = "Version";
            this.lblVersion.Text = "Version";
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Location = new System.Drawing.Point(60, 172);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(319, 33);
            this.knappkontroller1.TabIndex = 7;
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // Om
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(391, 210);
            this.Controls.Add(this.knappkontroller1);
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this._Line1_1);
            this.Controls.Add(this._Line1_0);
            this.Controls.Add(this.lblVersion);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(3, 22);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Om";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Tag = "About Hooker";
            this.Text = "Om golfprogrammet";
            this.Load += new System.EventHandler(this.Om_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void Om_Load(object sender, EventArgs e)
        {
            //******************************************
            // Metod:        Form_Load
            //
            // Skapad av:    Göran Härdelin
            // Datum:        2001-04-06
            //
            // Beskrivning:  Visar information om applikationen
            //****************************************
            lblVersion.Text = "Version: " + Systemvariabel.Version;
            lblTitle.Text = Systemvariabel.Applikationsnamn;
            lblDescription.Text = "Applikationen är skriven i " + Systemvariabel.Verktyg;
            lblDescription.Text = lblDescription.Text + "\r\n" + "\r\n" + Systemvariabel.Utvecklare + "\r\n";
            lblDescription.Text = lblDescription.Text + "E-post: " + Systemvariabel.Epostadress + "\r\n";
            lblDescription.Text = lblDescription.Text + "Mobil: " + Systemvariabel.MobilUtvecklare;

            //Deaktivera knappar som inte är aktuella för denna bild
            knappkontroller1.btnKnapp1.Visible = false;
            knappkontroller1.btnKnapp3.Visible = false;
            knappkontroller1.btnKnapp2.Visible = false;
            knappkontroller1.btnKnapp4.Text = "&OK";
        }

        private void knappkontroller1_OnKnapp4Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
