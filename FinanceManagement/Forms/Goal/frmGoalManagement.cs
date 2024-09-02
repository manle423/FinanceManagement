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
        string selectedStartDate = DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss");
        string selectedEndDate = DateTime.MaxValue.ToString("yyyy-MM-dd HH:mm:ss");
        decimal selectedStartCurrentAmount = Decimal.MinValue;
        decimal selectedEndCurrentAmount = Decimal.MaxValue;
        decimal selectedStartTargetAmount = Decimal.MinValue;
        decimal selectedEndTargetAmount = Decimal.MaxValue;

        string selectedId = null;
        string selectedName = null;
        string selectedDescription = null;
        string selectedDeadline = null;
        string selectedCurrentAmount = null;
        string selectedTargetAmount = null;
        public frmGoalManagement()
        {
            InitializeComponent();
            
            dtpStartDate.MaxDate = dtpEndDate.Value;
            dtpEndDate.MinDate = dtpStartDate.Value;
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

        private void LoadGoalsBasedOnCriteria()
        {
 
            selectedStartDate = (dtpStartDate.Enabled) ? dtpStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss");

            selectedEndDate = (dtpEndDate.Enabled) ? dtpEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : DateTime.MaxValue.ToString("yyyy-MM-dd HH:mm:ss");
            selectedStartCurrentAmount = (!string.IsNullOrEmpty(txtStartCurrentAmount.Text)) ? decimal.Parse(txtStartCurrentAmount.Text) : Decimal.MinValue;
            selectedEndCurrentAmount = (!string.IsNullOrEmpty(txtEndCurrentAmount.Text)) ? decimal.Parse(txtEndCurrentAmount.Text) : Decimal.MaxValue;
            selectedStartTargetAmount = (!string.IsNullOrEmpty(txtStartTargetAmount.Text)) ? decimal.Parse(txtStartTargetAmount.Text) : Decimal.MinValue;
            selectedEndTargetAmount = (!string.IsNullOrEmpty(txtEndTargetAmount.Text)) ? decimal.Parse(txtEndTargetAmount.Text) : Decimal.MaxValue;

            LoadGoals(userId,selectedStartDate,selectedEndDate,selectedStartCurrentAmount,selectedEndCurrentAmount,selectedStartTargetAmount,selectedEndTargetAmount);
        }
        private void LoadGoals(int userId, string startDate, string endDate, decimal startCurrentAmount, decimal endCurrentAmount, decimal startTargetAmount, decimal endTargetAmount) 
        {
            List<Models.Goal> goals = GoalService.GetAllGoals(userId,startDate,endDate,startTargetAmount,endTargetAmount,startCurrentAmount,endCurrentAmount);
            ConfigureDataGridView(goals);

        }

        private void ConfigureDataGridView(List<Models.Goal> goals)
        {
            dgvGoals.DataSource = goals;
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
            selectedEndDate = (dtpEndDate.Enabled) ? dtpEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : DateTime.MaxValue.ToString("yyyy-MM-dd HH:mm:ss");
            LoadGoalsBasedOnCriteria();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            selectedStartDate = dtpStartDate.Value.ToString();
            dtpEndDate.MinDate = dtpStartDate.Value;
            LoadGoalsBasedOnCriteria();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            selectedEndDate = dtpEndDate.Value.ToString();
            dtpStartDate.MaxDate = dtpEndDate.Value;
            LoadGoalsBasedOnCriteria();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            dtpStartDate.Enabled = (dtpStartDate.Enabled) ? false : true;
            selectedStartDate = (dtpStartDate.Enabled) ? dtpStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss");
            LoadGoalsBasedOnCriteria();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadGoalsBasedOnCriteria();
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

        private void frmGoalManagement_Load(object sender, EventArgs e)
        {
            LoadGoalsBasedOnCriteria();
        }

        private void dgvGoals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // id, user id, name, target_amount, current_maount, deadline, description, createdat, updatedat
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                selectedId = dgvGoals.Rows[e.RowIndex].Cells[0].Value.ToString();
                selectedName = dgvGoals.Rows[e.RowIndex].Cells[2].Value.ToString();
                selectedTargetAmount = dgvGoals.Rows[e.RowIndex].Cells[3].Value.ToString();
                selectedCurrentAmount = dgvGoals.Rows[e.RowIndex].Cells[4].Value.ToString();
                selectedDeadline = dgvGoals.Rows[e.RowIndex].Cells[5].Value.ToString();
                selectedDescription = dgvGoals.Rows[e.RowIndex].Cells[6].Value.ToString();
                // Gán dữ liệu vào các TextBox tương ứng
                
                txtIDUpdate.Text = selectedId;
                txtNameUpdate.Text = selectedName;
                txtTargetAmountUpdate.Text = selectedTargetAmount;
                txtCurrentAmountUpdate.Text = selectedCurrentAmount;
                txtDescriptionUpdate.Text = selectedDescription;
                dtpDeadlineUpdate.Value = DateTime.Parse(selectedDeadline);
             

            }
        }
    }
}
