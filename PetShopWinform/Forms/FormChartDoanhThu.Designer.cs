
namespace PetShopWinform.Forms
{
    partial class FormChartDoanhThu
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
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxDoanhThu = new System.Windows.Forms.GroupBox();
            this.radioButtonYear = new System.Windows.Forms.RadioButton();
            this.radioButtonMonth = new System.Windows.Forms.RadioButton();
            this.radioButtonDate = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.groupBoxDoanhThu.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend1);
            this.chartDoanhThu.Location = new System.Drawing.Point(12, 71);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            series1.Legend = "Legend1";
            series1.Name = "DoanhThu";
            series1.YValuesPerPoint = 2;
            this.chartDoanhThu.Series.Add(series1);
            this.chartDoanhThu.Size = new System.Drawing.Size(776, 353);
            this.chartDoanhThu.TabIndex = 17;
            this.chartDoanhThu.Text = "Thống kê theo ngày";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            title1.Name = "TitleChart";
            title1.Text = "Doanh thu";
            this.chartDoanhThu.Titles.Add(title1);
            // 
            // groupBoxDoanhThu
            // 
            this.groupBoxDoanhThu.Controls.Add(this.radioButtonYear);
            this.groupBoxDoanhThu.Controls.Add(this.radioButtonMonth);
            this.groupBoxDoanhThu.Controls.Add(this.radioButtonDate);
            this.groupBoxDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDoanhThu.Location = new System.Drawing.Point(177, 12);
            this.groupBoxDoanhThu.Name = "groupBoxDoanhThu";
            this.groupBoxDoanhThu.Size = new System.Drawing.Size(441, 53);
            this.groupBoxDoanhThu.TabIndex = 18;
            this.groupBoxDoanhThu.TabStop = false;
            this.groupBoxDoanhThu.Text = "Thống kê doanh thu";
            // 
            // radioButtonYear
            // 
            this.radioButtonYear.AutoSize = true;
            this.radioButtonYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonYear.Location = new System.Drawing.Point(296, 19);
            this.radioButtonYear.Name = "radioButtonYear";
            this.radioButtonYear.Size = new System.Drawing.Size(50, 19);
            this.radioButtonYear.TabIndex = 2;
            this.radioButtonYear.TabStop = true;
            this.radioButtonYear.Text = "Year";
            this.radioButtonYear.UseVisualStyleBackColor = true;
            this.radioButtonYear.CheckedChanged += new System.EventHandler(this.radioButtonYear_CheckedChanged);
            // 
            // radioButtonMonth
            // 
            this.radioButtonMonth.AutoSize = true;
            this.radioButtonMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonMonth.Location = new System.Drawing.Point(178, 19);
            this.radioButtonMonth.Name = "radioButtonMonth";
            this.radioButtonMonth.Size = new System.Drawing.Size(60, 19);
            this.radioButtonMonth.TabIndex = 1;
            this.radioButtonMonth.TabStop = true;
            this.radioButtonMonth.Text = "Month";
            this.radioButtonMonth.UseVisualStyleBackColor = true;
            this.radioButtonMonth.CheckedChanged += new System.EventHandler(this.radioButtonMonth_CheckedChanged);
            // 
            // radioButtonDate
            // 
            this.radioButtonDate.AutoSize = true;
            this.radioButtonDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDate.Location = new System.Drawing.Point(63, 19);
            this.radioButtonDate.Name = "radioButtonDate";
            this.radioButtonDate.Size = new System.Drawing.Size(51, 19);
            this.radioButtonDate.TabIndex = 0;
            this.radioButtonDate.TabStop = true;
            this.radioButtonDate.Text = "Date";
            this.radioButtonDate.UseVisualStyleBackColor = true;
            this.radioButtonDate.CheckedChanged += new System.EventHandler(this.radioButtonDate_CheckedChanged);
            // 
            // FormChartDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxDoanhThu);
            this.Controls.Add(this.chartDoanhThu);
            this.Name = "FormChartDoanhThu";
            this.Text = "FormChartDoanhThu";
            this.Load += new System.EventHandler(this.FormChartDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.groupBoxDoanhThu.ResumeLayout(false);
            this.groupBoxDoanhThu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.GroupBox groupBoxDoanhThu;
        private System.Windows.Forms.RadioButton radioButtonYear;
        private System.Windows.Forms.RadioButton radioButtonMonth;
        private System.Windows.Forms.RadioButton radioButtonDate;
    }
}