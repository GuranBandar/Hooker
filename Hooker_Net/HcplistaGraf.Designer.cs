namespace Hooker_GUI
{
    partial class HcplistaGraf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HcplistaGraf));
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.fönsterhanterare1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            this.gbxKnappBox = new System.Windows.Forms.GroupBox();
            this.chaHcpGraf = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblSpelare = new System.Windows.Forms.Label();
            this.txtPrognosEGA = new System.Windows.Forms.TextBox();
            this.lblPrognosEGA = new System.Windows.Forms.Label();
            this.txtSpelarNamn = new System.Windows.Forms.TextBox();
            this.txtExaktHcp = new System.Windows.Forms.TextBox();
            this.lblExaktHcp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chaHcpGraf)).BeginInit();
            this.SuspendLayout();
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(306, 416);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 1;
            this.knappkontroller1.OnKnapp3Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp3ClickEventHandler(this.knappkontroller1_OnKnapp3Click);
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // fönsterhanterare1
            // 
            this.fönsterhanterare1.Location = new System.Drawing.Point(104, 427);
            this.fönsterhanterare1.Name = "fönsterhanterare1";
            this.fönsterhanterare1.Size = new System.Drawing.Size(150, 11);
            this.fönsterhanterare1.TabIndex = 1;
            // 
            // gbxKnappBox
            // 
            this.gbxKnappBox.Location = new System.Drawing.Point(-12, 407);
            this.gbxKnappBox.Name = "gbxKnappBox";
            this.gbxKnappBox.Size = new System.Drawing.Size(746, 51);
            this.gbxKnappBox.TabIndex = 2;
            this.gbxKnappBox.TabStop = false;
            this.gbxKnappBox.Text = "Text_Blank";
            // 
            // chaHcpGraf
            // 
            chartArea1.AxisY.Maximum = 12D;
            chartArea1.AxisY.Minimum = 7D;
            chartArea1.Name = "ChartArea1";
            this.chaHcpGraf.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chaHcpGraf.Legends.Add(legend1);
            this.chaHcpGraf.Location = new System.Drawing.Point(8, 53);
            this.chaHcpGraf.Name = "chaHcpGraf";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "HcpLine";
            this.chaHcpGraf.Series.Add(series1);
            this.chaHcpGraf.Size = new System.Drawing.Size(699, 348);
            this.chaHcpGraf.TabIndex = 3;
            this.chaHcpGraf.Text = "chart1";
            this.chaHcpGraf.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chaHcpGraf_MouseClick);
            this.chaHcpGraf.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chaHcpGraf_MouseDoubleClick);
            // 
            // lblSpelare
            // 
            this.lblSpelare.AutoSize = true;
            this.lblSpelare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpelare.Location = new System.Drawing.Point(10, 16);
            this.lblSpelare.Name = "lblSpelare";
            this.lblSpelare.Size = new System.Drawing.Size(95, 13);
            this.lblSpelare.TabIndex = 4;
            this.lblSpelare.Text = "Radrubrik_Spelare";
            // 
            // txtPrognosEGA
            // 
            this.txtPrognosEGA.Location = new System.Drawing.Point(556, 12);
            this.txtPrognosEGA.Name = "txtPrognosEGA";
            this.txtPrognosEGA.ReadOnly = true;
            this.txtPrognosEGA.Size = new System.Drawing.Size(33, 20);
            this.txtPrognosEGA.TabIndex = 99;
            // 
            // lblPrognosEGA
            // 
            this.lblPrognosEGA.AutoSize = true;
            this.lblPrognosEGA.Location = new System.Drawing.Point(360, 16);
            this.lblPrognosEGA.Name = "lblPrognosEGA";
            this.lblPrognosEGA.Size = new System.Drawing.Size(95, 13);
            this.lblPrognosEGA.TabIndex = 10;
            this.lblPrognosEGA.Text = "Text_PrognosEGA";
            // 
            // txtSpelarNamn
            // 
            this.txtSpelarNamn.Location = new System.Drawing.Point(87, 12);
            this.txtSpelarNamn.Name = "txtSpelarNamn";
            this.txtSpelarNamn.ReadOnly = true;
            this.txtSpelarNamn.Size = new System.Drawing.Size(100, 20);
            this.txtSpelarNamn.TabIndex = 99;
            // 
            // txtExaktHcp
            // 
            this.txtExaktHcp.Location = new System.Drawing.Point(301, 12);
            this.txtExaktHcp.Name = "txtExaktHcp";
            this.txtExaktHcp.ReadOnly = true;
            this.txtExaktHcp.Size = new System.Drawing.Size(36, 20);
            this.txtExaktHcp.TabIndex = 99;
            // 
            // lblExaktHcp
            // 
            this.lblExaktHcp.AutoSize = true;
            this.lblExaktHcp.Location = new System.Drawing.Point(201, 16);
            this.lblExaktHcp.Name = "lblExaktHcp";
            this.lblExaktHcp.Size = new System.Drawing.Size(106, 13);
            this.lblExaktHcp.TabIndex = 15;
            this.lblExaktHcp.Text = "Radrubrik_ExaktHcp";
            // 
            // HcplistaGraf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 450);
            this.Controls.Add(this.txtExaktHcp);
            this.Controls.Add(this.lblExaktHcp);
            this.Controls.Add(this.txtSpelarNamn);
            this.Controls.Add(this.txtPrognosEGA);
            this.Controls.Add(this.lblPrognosEGA);
            this.Controls.Add(this.lblSpelare);
            this.Controls.Add(this.chaHcpGraf);
            this.Controls.Add(this.fönsterhanterare1);
            this.Controls.Add(this.knappkontroller1);
            this.Controls.Add(this.gbxKnappBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HcplistaGraf";
            this.Text = "Titel_HcplistaGraf";
            this.Load += new System.EventHandler(this.HcplistaGraf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chaHcpGraf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Kontroller.Knappkontroller knappkontroller1;
        private Kontroller.Fönsterhanterare fönsterhanterare1;
        private System.Windows.Forms.GroupBox gbxKnappBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart chaHcpGraf;
        private System.Windows.Forms.Label lblSpelare;
        private System.Windows.Forms.TextBox txtPrognosEGA;
        private System.Windows.Forms.Label lblPrognosEGA;
        private System.Windows.Forms.TextBox txtSpelarNamn;
        private System.Windows.Forms.TextBox txtExaktHcp;
        private System.Windows.Forms.Label lblExaktHcp;
    }
}