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

namespace FinanceManagement
{
    public partial class frmDashboard : UserControl
    {
        int userId = UserSession.Instance.UserId;
        string username = UserSession.Instance.Username;
        List<decimal> sumAmountReports = null;
        List<Models.Goal> unfinishedGoals = null;
        public frmDashboard()
        {
            InitializeComponent();
            txtCompletionRate.Text = "80";
            dtpReportMonth.Value = DateTime.Now;
            dtpReportYear.Value = DateTime.Now;
            

        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
           
            DateTime reportYear = dtpReportYear.Value;
            if (dtpReportMonth.Checked == false)
            { // Tính tổng kết năm
                sumAmountReports = TransactionService.GetDifferenceYear(userId, reportYear);
                unfinishedGoals = GoalService.GetAllGoalsUncompleted(userId, reportYear.Year.ToString() + "-01-01", reportYear.Year.ToString() + "-12-31");
            }
            else // Tổng kết tháng
            {
                DateTime reportMonth = dtpReportMonth.Value;
                string strMonthYear = reportYear.Year.ToString() + '-' + reportMonth.Month.ToString();
                string daysInMonth = DateTime.DaysInMonth(reportYear.Year, reportMonth.Month).ToString();
                sumAmountReports = TransactionService.GetDifferenceMonth(userId, reportMonth, reportYear);
                unfinishedGoals = GoalService.GetAllGoalsUncompleted(userId, strMonthYear + "-01", strMonthYear + "-" + daysInMonth);
            }

            decimal sumIncome = sumAmountReports[0];
            decimal sumExpense = sumAmountReports[1];
            decimal difference = sumIncome - sumExpense;
            txtTotalIncome.Text = sumIncome.ToString();
            txtTotalExpense.Text = sumExpense.ToString();
            txtReportDiff.Text = difference.ToString();

            txtReportGoals.Clear();
            foreach (Models.Goal goal in unfinishedGoals)
            {
                double completion = ((double)goal.CurrentAmount / (double)goal.TargetAmount) * 100;
                if (completion > Convert.ToInt32(txtCompletionRate.Text))
                {
                    txtReportGoals.Text += goal.ToString() + "\n";
                }

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
            frmDashboard_Load(sender, e);
        }
    }
}
