using System;
using System.Windows.Forms;

namespace Hooker_GUI.Kontroller
{
    /// <summary>
    /// Summary description for Knappkontroller.
    /// </summary>
    public class Knappkontroller : System.Windows.Forms.UserControl
    {
        /// <summary>
        /// Lyssnare för tryck på Knapp0
        /// </summary>
        public delegate void Knapp0ClickEventHandler(object sender, EventArgs e);
        /// <summary>
        /// Händelsehanterare för tryck på Knapp0
        /// </summary>
        public event Knapp0ClickEventHandler OnKnapp0Click;

        /// <summary>
        /// Lyssnare för tryck på Knapp1
        /// </summary>
        public delegate void Knapp1ClickEventHandler(object sender, EventArgs e);
        /// <summary>
        /// Händelsehanterare för tryck på Knapp1
        /// </summary>
        public event Knapp1ClickEventHandler OnKnapp1Click;

        /// <summary>
        /// Lyssnare för tryck på Knapp2
        /// </summary>
        public delegate void Knapp2ClickEventHandler(object sender, EventArgs e);
        /// <summary>
        /// Händelsehanterare för tryck på Knapp2
        /// </summary>
        public event Knapp2ClickEventHandler OnKnapp2Click;

        /// <summary>
        /// Lyssnare för tryck på Knapp3
        /// </summary>
        public delegate void Knapp3ClickEventHandler(object sender, EventArgs e);
        /// <summary>
        /// Händelsehanterare för tryck på Knapp3
        /// </summary>
        public event Knapp3ClickEventHandler OnKnapp3Click;

        /// <summary>
        /// Lyssnare för tryck på Knapp4
        /// </summary>
        public delegate void Knapp4ClickEventHandler(object sender, EventArgs e);
        /// <summary>
        /// Händelsehanterare för tryck på Knapp4
        /// </summary>
        public event Knapp4ClickEventHandler OnKnapp4Click;

        /// <summary>
        /// Knapp1
        /// </summary>
        public Button btnKnapp1;
        /// <summary>
        /// Knapp2
        /// </summary>
        public Button btnKnapp2;
        /// <summary>
        /// Knapp3
        /// </summary>
        public Button btnKnapp3;
        /// <summary>
        /// Knapp4
        /// </summary>
        public Button btnKnapp4;
        /// <summary>
        /// Knapp0
        /// </summary>
        public Button btnKnapp0;

        public string Button4Text { get { return btnKnapp4.Text; } set { btnKnapp4.Text = value; } }

        public Button Button4 { get { return btnKnapp4; } }

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// Konstruktor
        /// </summary>
		public Knappkontroller()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.btnKnapp4 = new System.Windows.Forms.Button();
            this.btnKnapp2 = new System.Windows.Forms.Button();
            this.btnKnapp3 = new System.Windows.Forms.Button();
            this.btnKnapp1 = new System.Windows.Forms.Button();
            this.btnKnapp0 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKnapp4
            // 
            this.btnKnapp4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKnapp4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnKnapp4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnKnapp4.Location = new System.Drawing.Point(336, 5);
            this.btnKnapp4.Name = "btnKnapp4";
            this.btnKnapp4.Size = new System.Drawing.Size(75, 23);
            this.btnKnapp4.TabIndex = 4;
            this.btnKnapp4.Text = "Knapp4";
            this.btnKnapp4.Click += new System.EventHandler(this.cmdKnapp4_Click);
            // 
            // btnKnapp2
            // 
            this.btnKnapp2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKnapp2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnKnapp2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnKnapp2.Location = new System.Drawing.Point(180, 5);
            this.btnKnapp2.Name = "btnKnapp2";
            this.btnKnapp2.Size = new System.Drawing.Size(75, 23);
            this.btnKnapp2.TabIndex = 2;
            this.btnKnapp2.Text = "Knapp2";
            this.btnKnapp2.Click += new System.EventHandler(this.cmdKnapp2_Click);
            // 
            // btnKnapp3
            // 
            this.btnKnapp3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKnapp3.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnKnapp3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnKnapp3.Location = new System.Drawing.Point(258, 5);
            this.btnKnapp3.Name = "btnKnapp3";
            this.btnKnapp3.Size = new System.Drawing.Size(75, 23);
            this.btnKnapp3.TabIndex = 3;
            this.btnKnapp3.Text = "Knapp3";
            this.btnKnapp3.Click += new System.EventHandler(this.cmdKnapp3_Click);
            // 
            // btnKnapp1
            // 
            this.btnKnapp1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKnapp1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnKnapp1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnKnapp1.Location = new System.Drawing.Point(102, 5);
            this.btnKnapp1.Name = "btnKnapp1";
            this.btnKnapp1.Size = new System.Drawing.Size(75, 23);
            this.btnKnapp1.TabIndex = 1;
            this.btnKnapp1.Text = "Knapp1";
            this.btnKnapp1.Click += new System.EventHandler(this.cmdKnapp1_Click);
            // 
            // btnKnapp0
            // 
            this.btnKnapp0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKnapp0.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnKnapp0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnKnapp0.Location = new System.Drawing.Point(21, 5);
            this.btnKnapp0.Name = "btnKnapp0";
            this.btnKnapp0.Size = new System.Drawing.Size(75, 23);
            this.btnKnapp0.TabIndex = 5;
            this.btnKnapp0.Text = "Knapp0";
            this.btnKnapp0.Click += new System.EventHandler(this.btnKnapp0_Click);
            // 
            // Knappkontroller
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.btnKnapp0);
            this.Controls.Add(this.btnKnapp1);
            this.Controls.Add(this.btnKnapp3);
            this.Controls.Add(this.btnKnapp4);
            this.Controls.Add(this.btnKnapp2);
            this.Name = "Knappkontroller";
            this.Size = new System.Drawing.Size(417, 33);
            this.ResumeLayout(false);

        }
        #endregion

        private void cmdKnapp0_Click(object sender, EventArgs e)
        {
            if (OnKnapp0Click != null)
            {
                OnKnapp0Click(this, null);
            }
        }

        private void cmdKnapp1_Click(object sender, EventArgs e)
        {
            if (OnKnapp1Click != null)
            {
                OnKnapp1Click(this, null);
            }
        }

        private void cmdKnapp2_Click(object sender, EventArgs e)
        {
            if (OnKnapp2Click != null)
            {
                OnKnapp2Click(this, null);
            }
        }

        private void cmdKnapp3_Click(object sender, EventArgs e)
        {
            if (OnKnapp3Click != null)
            {
                OnKnapp3Click(this, null);
            }
        }

        private void cmdKnapp4_Click(object sender, EventArgs e)
        {
            if (OnKnapp4Click != null)
            {
                OnKnapp4Click(this, null);
            }
        }

        private void btnKnapp0_Click(object sender, EventArgs e)
        {
            if (OnKnapp0Click != null)
            {
                OnKnapp0Click(this, null);
            }
        }
    }
}
