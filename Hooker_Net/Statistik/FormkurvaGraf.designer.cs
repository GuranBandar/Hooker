namespace Hooker_GUI
{
    partial class FormkurvaGraf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormkurvaGraf));
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.chaFormkurva = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbxKnappkontroll = new System.Windows.Forms.GroupBox();
            this.hanteraFönster1 = new Hooker_GUI.Kontroller.Fönsterhanterare();
            this.lblPrognosEGA = new System.Windows.Forms.Label();
            this.txtPrognosEGA = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chaFormkurva)).BeginInit();
            this.gbxKnappkontroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(132, 9);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 0;
            // 
            // chaFormkurva
            // 
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.Title = "Runda";
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.Title = "Poäng";
            chartArea1.Name = "Formen";
            this.chaFormkurva.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.Name = "Formkurva";
            this.chaFormkurva.Legends.Add(legend1);
            this.chaFormkurva.Location = new System.Drawing.Point(12, 18);
            this.chaFormkurva.Name = "chaFormkurva";
            series1.ChartArea = "Formen";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Formkurva";
            series1.Name = "Series1";
            this.chaFormkurva.Series.Add(series1);
            this.chaFormkurva.Size = new System.Drawing.Size(520, 300);
            this.chaFormkurva.TabIndex = 1;
            this.chaFormkurva.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chaFormkurva_MouseClick);
            this.chaFormkurva.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chaFormkurva_MouseDoubleClick);
            // 
            // gbxKnappkontroll
            // 
            this.gbxKnappkontroll.Controls.Add(this.knappkontroller1);
            this.gbxKnappkontroll.Location = new System.Drawing.Point(-5, 376);
            this.gbxKnappkontroll.Name = "gbxKnappkontroll";
            this.gbxKnappkontroll.Size = new System.Drawing.Size(549, 49);
            this.gbxKnappkontroll.TabIndex = 2;
            this.gbxKnappkontroll.TabStop = false;
            // 
            // hanteraFönster1
            // 
            this.hanteraFönster1.Location = new System.Drawing.Point(27, 335);
            this.hanteraFönster1.Name = "hanteraFönster1";
            this.hanteraFönster1.Size = new System.Drawing.Size(150, 11);
            this.hanteraFönster1.TabIndex = 5;
            // 
            // lblPrognosEGA
            // 
            this.lblPrognosEGA.AutoSize = true;
            this.lblPrognosEGA.Location = new System.Drawing.Point(141, 349);
            this.lblPrognosEGA.Name = "lblPrognosEGA";
            this.lblPrognosEGA.Size = new System.Drawing.Size(95, 13);
            this.lblPrognosEGA.TabIndex = 6;
            this.lblPrognosEGA.Text = "Text_PrognosEGA";
            // 
            // txtPrognosEGA
            // 
            this.txtPrognosEGA.Location = new System.Drawing.Point(347, 347);
            this.txtPrognosEGA.Name = "txtPrognosEGA";
            this.txtPrognosEGA.ReadOnly = true;
            this.txtPrognosEGA.Size = new System.Drawing.Size(33, 20);
            this.txtPrognosEGA.TabIndex = 7;
            // 
            // FormkurvaGraf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 419);
            this.Controls.Add(this.txtPrognosEGA);
            this.Controls.Add(this.lblPrognosEGA);
            this.Controls.Add(this.hanteraFönster1);
            this.Controls.Add(this.chaFormkurva);
            this.Controls.Add(this.gbxKnappkontroll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormkurvaGraf";
            this.Text = "Titel_Formkurva";
            this.Load += new System.EventHandler(this.FormkurvaGraf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chaFormkurva)).EndInit();
            this.gbxKnappkontroll.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Kontroller.Knappkontroller knappkontroller1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chaFormkurva;
        private System.Windows.Forms.GroupBox gbxKnappkontroll;
        private Kontroller.Fönsterhanterare hanteraFönster1;
        private System.Windows.Forms.Label lblPrognosEGA;
        private System.Windows.Forms.TextBox txtPrognosEGA;
    }
}