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
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtpReportMonth_ValueChanged(object sender, EventArgs e)
        {
            DateTime reportMonth = dtpReportMonth.Value;
            DateTime reportYear = dtpReportYear.Value;
            List<decimal> sumAmountReports = TransactionService.GetDifferenceMonth(userId, reportMonth, reportYear);
            decimal sumIncome = sumAmountReports[0];
            decimal sumExpense = sumAmountReports[1];
            decimal difference = sumIncome-sumExpense;
            txtTotalIncome.Text = sumIncome.ToString();
            txtTotalExpense.Text = sumExpense.ToString();
            txtReportDiff.Text = difference.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
