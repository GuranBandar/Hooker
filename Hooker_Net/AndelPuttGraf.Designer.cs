namespace Hooker_GUI
{
    partial class AndelPuttGraf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AndelPuttGraf));
            this.chaAndelPutt = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbxKnappkontroll = new System.Windows.Forms.GroupBox();
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            ((System.ComponentModel.ISupportInitialize)(this.chaAndelPutt)).BeginInit();
            this.gbxKnappkontroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // chaAndelPutt
            // 
            chartArea1.Name = "ChartArea1";
            this.chaAndelPutt.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chaAndelPutt.Legends.Add(legend1);
            this.chaAndelPutt.Location = new System.Drawing.Point(46, 12);
            this.chaAndelPutt.Name = "chaAndelPutt";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Default";
            this.chaAndelPutt.Series.Add(series1);
            this.chaAndelPutt.Size = new System.Drawing.Size(300, 300);
            this.chaAndelPutt.TabIndex = 3;
            this.chaAndelPutt.Text = "Text_AndelPutt";
            // 
            // gbxKnappkontroll
            // 
            this.gbxKnappkontroll.Controls.Add(this.knappkontroller1);
            this.gbxKnappkontroll.Location = new System.Drawing.Point(-13, 319);
            this.gbxKnappkontroll.Name = "gbxKnappkontroll";
            this.gbxKnappkontroll.Size = new System.Drawing.Size(414, 57);
            this.gbxKnappkontroll.TabIndex = 2;
            this.gbxKnappkontroll.TabStop = false;
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Location = new System.Drawing.Point(-19, 13);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 32);
            this.knappkontroller1.TabIndex = 1;
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // AndelPuttGraf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 364);
            this.Controls.Add(this.gbxKnappkontroll);
            this.Controls.Add(this.chaAndelPutt);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AndelPuttGraf";
            this.Text = "Titel_AndelPuttGraf";
            ((System.ComponentModel.ISupportInitialize)(this.chaAndelPutt)).EndInit();
            this.gbxKnappkontroll.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Hooker_GUI.Kontroller.Knappkontroller knappkontroller1;
        private System.Windows.Forms.GroupBox gbxKnappkontroll;
        private System.Windows.Forms.DataVisualization.Charting.Chart chaAndelPutt;
    }
}