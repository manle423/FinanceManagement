﻿namespace FinanceManagement
{
    partial class frmDashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chtReport = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpReportYear = new System.Windows.Forms.DateTimePicker();
            this.dtpReportMonth = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtReportBudgets = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReportGoals = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalIncome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalExpense = new System.Windows.Forms.TextBox();
            this.txtReportDiff = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chtReport)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chtReport
            // 
            chartArea2.Name = "ChartArea1";
            this.chtReport.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chtReport.Legends.Add(legend2);
            this.chtReport.Location = new System.Drawing.Point(18, 102);
            this.chtReport.Name = "chtReport";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chtReport.Series.Add(series2);
            this.chtReport.Size = new System.Drawing.Size(462, 357);
            this.chtReport.TabIndex = 0;
            this.chtReport.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpReportYear);
            this.panel1.Controls.Add(this.dtpReportMonth);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(174, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 68);
            this.panel1.TabIndex = 1;
            // 
            // dtpReportYear
            // 
            this.dtpReportYear.CustomFormat = "yyyy";
            this.dtpReportYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReportYear.Location = new System.Drawing.Point(253, 27);
            this.dtpReportYear.Name = "dtpReportYear";
            this.dtpReportYear.Size = new System.Drawing.Size(53, 20);
            this.dtpReportYear.TabIndex = 2;
            // 
            // dtpReportMonth
            // 
            this.dtpReportMonth.CustomFormat = "MMMM";
            this.dtpReportMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReportMonth.Location = new System.Drawing.Point(172, 27);
            this.dtpReportMonth.Name = "dtpReportMonth";
            this.dtpReportMonth.Size = new System.Drawing.Size(75, 20);
            this.dtpReportMonth.TabIndex = 1;
            this.dtpReportMonth.ValueChanged += new System.EventHandler(this.dtpReportMonth_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "See report of: ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtReportDiff);
            this.panel2.Controls.Add(this.txtReportBudgets);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtReportGoals);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtTotalExpense);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtTotalIncome);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(498, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(281, 394);
            this.panel2.TabIndex = 2;
            // 
            // txtReportBudgets
            // 
            this.txtReportBudgets.Location = new System.Drawing.Point(15, 275);
            this.txtReportBudgets.Name = "txtReportBudgets";
            this.txtReportBudgets.ReadOnly = true;
            this.txtReportBudgets.Size = new System.Drawing.Size(249, 96);
            this.txtReportBudgets.TabIndex = 5;
            this.txtReportBudgets.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Budgets running out: ";
            // 
            // txtReportGoals
            // 
            this.txtReportGoals.Location = new System.Drawing.Point(15, 139);
            this.txtReportGoals.Name = "txtReportGoals";
            this.txtReportGoals.ReadOnly = true;
            this.txtReportGoals.Size = new System.Drawing.Size(249, 96);
            this.txtReportGoals.TabIndex = 3;
            this.txtReportGoals.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Goals close to achivement: ";
            // 
            // txtTotalIncome
            // 
            this.txtTotalIncome.Location = new System.Drawing.Point(122, 14);
            this.txtTotalIncome.Name = "txtTotalIncome";
            this.txtTotalIncome.ReadOnly = true;
            this.txtTotalIncome.Size = new System.Drawing.Size(130, 20);
            this.txtTotalIncome.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total income: ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Total expense: ";
            this.label5.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtTotalExpense
            // 
            this.txtTotalExpense.Location = new System.Drawing.Point(122, 40);
            this.txtTotalExpense.Name = "txtTotalExpense";
            this.txtTotalExpense.ReadOnly = true;
            this.txtTotalExpense.Size = new System.Drawing.Size(130, 20);
            this.txtTotalExpense.TabIndex = 1;
            this.txtTotalExpense.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtReportDiff
            // 
            this.txtReportDiff.Location = new System.Drawing.Point(122, 66);
            this.txtReportDiff.Name = "txtReportDiff";
            this.txtReportDiff.ReadOnly = true;
            this.txtReportDiff.Size = new System.Drawing.Size(130, 20);
            this.txtReportDiff.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(103, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 18);
            this.label6.TabIndex = 7;
            this.label6.Text = "-";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(103, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 18);
            this.label7.TabIndex = 8;
            this.label7.Text = "=";
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chtReport);
            this.Name = "frmDashboard";
            this.Size = new System.Drawing.Size(800, 520);
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chtReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chtReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpReportYear;
        private System.Windows.Forms.DateTimePicker dtpReportMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox txtReportBudgets;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtReportGoals;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalIncome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalExpense;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReportDiff;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}
