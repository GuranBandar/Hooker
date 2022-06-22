namespace Hooker_GUI
{
    partial class Rondgraf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rondgraf));
            this.chaRondgraf = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbxKnappkontroll = new System.Windows.Forms.GroupBox();
            this.knappkontroller1 = new Hooker_GUI.Kontroller.Knappkontroller();
            ((System.ComponentModel.ISupportInitialize)(this.chaRondgraf)).BeginInit();
            this.gbxKnappkontroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // chaRondgraf
            // 
            chartArea1.Name = "ChartArea1";
            this.chaRondgraf.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            this.chaRondgraf.Legends.Add(legend1);
            this.chaRondgraf.Location = new System.Drawing.Point(13, 13);
            this.chaRondgraf.Name = "chaRondgraf";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.CustomProperties = "DrawSideBySide=False";
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Resultat mot par";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chaRondgraf.Series.Add(series1);
            this.chaRondgraf.Size = new System.Drawing.Size(528, 265);
            this.chaRondgraf.TabIndex = 2;
            this.chaRondgraf.Text = "Text_ResultatEfter3";
            // 
            // gbxKnappkontroll
            // 
            this.gbxKnappkontroll.Controls.Add(this.knappkontroller1);
            this.gbxKnappkontroll.Location = new System.Drawing.Point(-5, 284);
            this.gbxKnappkontroll.Name = "gbxKnappkontroll";
            this.gbxKnappkontroll.Size = new System.Drawing.Size(566, 52);
            this.gbxKnappkontroll.TabIndex = 1;
            this.gbxKnappkontroll.TabStop = false;
            // 
            // knappkontroller1
            // 
            this.knappkontroller1.Button4Text = "Knapp4";
            this.knappkontroller1.Location = new System.Drawing.Point(135, 10);
            this.knappkontroller1.Name = "knappkontroller1";
            this.knappkontroller1.Size = new System.Drawing.Size(417, 33);
            this.knappkontroller1.TabIndex = 0;
            this.knappkontroller1.OnKnapp4Click += new Hooker_GUI.Kontroller.Knappkontroller.Knapp4ClickEventHandler(this.knappkontroller1_OnKnapp4Click);
            // 
            // Rondgraf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 328);
            this.Controls.Add(this.chaRondgraf);
            this.Controls.Add(this.gbxKnappkontroll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Rondgraf";
            this.Text = "Titel_Rondgraf";
            this.Load += new System.EventHandler(this.Rondgraf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chaRondgraf)).EndInit();
            this.gbxKnappkontroll.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxKnappkontroll;
        private Hooker_GUI.Kontroller.Knappkontroller knappkontroller1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chaRondgraf;
    }
}