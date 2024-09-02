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

namespace FinanceManagement.Forms.Goal
{
    public partial class frmGoalManagement : UserControl
    {
        int userId = UserSession.Instance.UserId;
        string username = UserSession.Instance.Username;
        public frmGoalManagement()
        {
            InitializeComponent();
            // Show goals that have deadline within next week
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddDays(7);
            dtpStartDate.MaxDate = dtpEndDate.Value;
            dtpEndDate.MinDate = dtpStartDate.Value;
            txtStartCurrentAmount.Text = txtStartTargetAmount.Text = "0";
            txtEndTargetAmount.Text = txtEndCurrentAmount.Text = "99999999";
            dgvGoals.ReadOnly = true;
            dgvGoals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        // Đối tượng trung gian
        Models.Goal goal = new Models.Goal();

        private void GetTransactionData()
        {
            goal.Id = int.Parse(txtIDUpdate.Text);
            goal.UserId = userId;
            goal.Deadline = dtpDeadlineUpdate.Value;
            goal.CurrentAmount = decimal.Parse(txtCurrentAmountUpdate.Text);
            goal.TargetAmount = decimal.Parse(txtTargetAmountUpdate.Text);
            goal.Name = txtNameUpdate.Text;
            goal.Description = txtDescriptionUpdate.Text;
        }

        private void pnlControl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            txtStartTargetAmount.Enabled = (txtStartTargetAmount.Enabled) ? false : true;
            txtEndTargetAmount.Enabled = (txtEndTargetAmount.Enabled) ? false : true;
        }

        private void txtAmountUpdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            txtStartCurrentAmount.Enabled = (txtStartCurrentAmount.Enabled) ? false : true;
            txtEndCurrentAmount.Enabled = (txtEndCurrentAmount.Enabled) ? false : true;

        }

        private void label9_Click(object sender, EventArgs e)
        {
            dtpEndDate.Enabled = (dtpEndDate.Enabled) ? false : true;
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            dtpStartDate.Enabled = (dtpStartDate.Enabled) ? false : true;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnReload_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dtpDateUpdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pnlData_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void txtDescriptionUpdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cboCategoryUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtIDUpdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
