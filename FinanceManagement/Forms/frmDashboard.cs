using FinanceManagement.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinanceManagement
{
    public partial class frmDashboard : UserControl
    {
        int userId = UserSession.Instance.UserId;
        string username = UserSession.Instance.Username;
        List<decimal> sumAmountReports = null;
        List<Models.Goal> unfinishedGoals = null;
        List<Models.Budget> closeBudgets = null;
        // Create a series for "Income" column
        Series incomeSeries = new Series("Income");
        // Create a series for "Expense" column
        Series expenseSeries = new Series("Expense");
        public frmDashboard()
        {
            InitializeComponent();
            txtCompletionRate.Text = "80";
            txtBudgetRemainingPercent.Text = "20";
            dtpReportMonth.Value = DateTime.Now;
            dtpReportYear.Value = DateTime.Now;

            
            //incomeSeries.Points.AddY(Convert.ToDouble(txtTotalIncome.Text));
            incomeSeries.Color = System.Drawing.Color.Green; // Color for Income column

            
            //expenseSeries.Points.AddY(Convert.ToDouble(txtTotalExpense.Text));
            expenseSeries.Color = System.Drawing.Color.Blue; // Color for Expense column

            chtIncomeExpense.Series.Add(incomeSeries);
            chtIncomeExpense.Series.Add(expenseSeries);
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
           
            DateTime reportYear = dtpReportYear.Value;
            double percent = Convert.ToDouble(txtBudgetRemainingPercent.Text) / 100.0;
            if (dtpReportMonth.Checked == false)
            { // Tính tổng kết năm
                sumAmountReports = TransactionService.GetDifferenceYear(userId, reportYear);
                unfinishedGoals = GoalService.GetAllGoalsUncompleted(userId, reportYear.Year.ToString() + "-01-01", reportYear.Year.ToString() + "-12-31");
                closeBudgets = BudgetService.GetCloseBudgetsWithTrack(userId, new DateTime(reportYear.Year,1,1), new DateTime(reportYear.Year,12,31),percent);
            }
            else // Tổng kết tháng
            {
                DateTime reportMonth = dtpReportMonth.Value;
                string strMonthYear = reportYear.Year.ToString() + '-' + reportMonth.Month.ToString();
                string daysInMonth = DateTime.DaysInMonth(reportYear.Year, reportMonth.Month).ToString();
                sumAmountReports = TransactionService.GetDifferenceMonth(userId, reportMonth, reportYear);
                unfinishedGoals = GoalService.GetAllGoalsUncompleted(userId, strMonthYear + "-01", strMonthYear + "-" + daysInMonth);
                closeBudgets = BudgetService.GetCloseBudgetsWithTrack(userId, 
                    new DateTime(reportYear.Year,reportMonth.Month , 1), 
                    new DateTime(reportYear.Year, reportMonth.Month, int.Parse(daysInMonth)), 
                    percent);
            }

            // Hiển thị tổng thu/chi
            decimal sumIncome = sumAmountReports[0];
            decimal sumExpense = sumAmountReports[1];
            decimal difference = sumIncome - sumExpense;
            txtTotalIncome.Text = sumIncome.ToString();
            txtTotalExpense.Text = sumExpense.ToString();
            txtReportDiff.Text = difference.ToString();

            // Hiển thị các goal sắp đạt chỉ tiêu
            txtReportGoals.Clear();
            foreach (Models.Goal goal in unfinishedGoals)
            {
                double completion = ((double)goal.CurrentAmount / (double)goal.TargetAmount) * 100;
                if (completion > Convert.ToDouble(txtCompletionRate.Text))
                {
                    txtReportGoals.Text += $"{goal.Name} - {goal.Deadline.ToShortDateString()} - {goal.TargetAmount - goal.CurrentAmount} needed\n";
                }

            }

            // Hiển thị các khoản ngân sách sắp cạn kiệt
            txtReportBudgets.Clear();
            foreach (Models.Budget budget in closeBudgets)
            {
                txtReportBudgets.Text += $"{budget.CategoryName} - {budget.EndDate.ToShortDateString()} - {budget.RemainingBudget} left\n";
            }

            // Cập nhật đồ thị
            // Update the data points of the series with new values from text boxes
            if (double.TryParse(txtTotalIncome.Text, out double incomeValue))
            {
                incomeSeries.Points.Clear(); // Clear existing points
                incomeSeries.Points.AddY(incomeValue);
            }

            if (double.TryParse(txtTotalExpense.Text, out double expenseValue))
            {
                expenseSeries.Points.Clear(); // Clear existing points
                expenseSeries.Points.AddY(expenseValue);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtpReportMonth_ValueChanged(object sender, EventArgs e)
        {
            frmDashboard_Load(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dtpReportYear_ValueChanged(object sender, EventArgs e)
        {
            //dtpReportMonth.MinDate = new DateTime(dtpReportYear.Value.Year, 1, 1);
            //dtpReportMonth.MaxDate = new DateTime(dtpReportYear.Value.Year, 12, 31);
            frmDashboard_Load(sender,e);

            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCompletionRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void Reload_Click(object sender, EventArgs e)
        {
            frmDashboard_Load(sender, e);
        }
    }
}
