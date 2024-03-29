﻿namespace Hooker_GUI
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
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            this.chaFormkurva = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbxKnappkontroll = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSnittSlag = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chaFormkurva)).BeginInit();
            this.gbxKnappkontroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // knappkontroller1
            // 
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
            this.chaFormkurva.Location = new System.Drawing.Point(12, 15);
            this.chaFormkurva.Name = "chaFormkurva";
            series1.ChartArea = "Formen";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Formkurva";
            series1.Name = "Series1";
            this.chaFormkurva.Series.Add(series1);
            this.chaFormkurva.Size = new System.Drawing.Size(520, 300);
            this.chaFormkurva.TabIndex = 1;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hcp enligt bästa 10 av senaste 20 rundor:";
            // 
            // lblSnittSlag
            // 
            this.lblSnittSlag.AutoSize = true;
            this.lblSnittSlag.Location = new System.Drawing.Point(365, 350);
            this.lblSnittSlag.Name = "lblSnittSlag";
            this.lblSnittSlag.Size = new System.Drawing.Size(35, 13);
            this.lblSnittSlag.TabIndex = 4;
            this.lblSnittSlag.Text = "label2";
            // 
            // FormkurvaGraf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 419);
            this.Controls.Add(this.lblSnittSlag);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chaFormkurva);
            this.Controls.Add(this.gbxKnappkontroll);
            this.Name = "FormkurvaGraf";
            this.Text = "Titel_FormkurvaGraf";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSnittSlag;
    }
}