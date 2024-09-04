using FinanceManagement.Forms.Budget;
using FinanceManagement.Services;
using FinanceManagement.Utils;
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
            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;
            dgvGoals.ReadOnly = true;
            dgvGoals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        // Đối tượng trung gian
        Models.Goal goal = new Models.Goal();

        private void GetGoalData()
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
            // id, user id, name, target_amount, current_maount, deadline, description, createdat, updatedat

            // Đưa dữ liệu vào bảng
            dgvGoals.DataSource = goals;

            // Giấu cột user_id
            dgvGoals.Columns["UserId"].Visible = false;

            // Điều chỉnh độ rộng của các cột
            dgvGoals.Columns["Id"].Width = 30;
            dgvGoals.Columns["TargetAmount"].Width = 110;
            dgvGoals.Columns["CurrentAmount"].Width = 110;
            dgvGoals.Columns["Deadline"].Width = 85;
            dgvGoals.Columns["Description"].Width = 200;
            dgvGoals.Columns["CreatedAt"].Width = 85;
            dgvGoals.Columns["UpdatedAt"].Width = 85;
            dgvGoals.Columns["Name"].Width = 120;

            // Chỉnh lại định dạng ngày/tháng/năm
            dgvGoals.Columns["Deadline"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvGoals.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvGoals.Columns["UpdatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Chỉnh lại tiêu đề
            dgvGoals.Columns["Id"].HeaderText = "ID";
            dgvGoals.Columns["TargetAmount"].HeaderText = "Target Amount";
            dgvGoals.Columns["CurrentAmount"].HeaderText = "Current Amount";
            dgvGoals.Columns["Deadline"].HeaderText = "Deadline";
            dgvGoals.Columns["Description"].HeaderText = "Description";
            dgvGoals.Columns["CreatedAt"].HeaderText = "Created At";
            dgvGoals.Columns["UpdatedAt"].HeaderText = "Updated At";

            // Chỉnh màu dựa trên trạng thái hoàn thành goal
            dgvGoals.CellFormatting += (sender, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    decimal currentAmount = Convert.ToDecimal(dgvGoals["CurrentAmount", e.RowIndex].Value);
                    decimal targetAmount = Convert.ToDecimal(dgvGoals["TargetAmount", e.RowIndex].Value);
                    DateTime deadline = DateTime.Parse(dgvGoals["Deadline", e.RowIndex].Value.ToString());
                    
                    // Kiểm tra xem đã quá hạn chưa
                    if (deadline.Date < DateTime.Today && currentAmount < targetAmount)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        
                    }

                    // Kiểm tra xem đã hoàn thành chưa
                    else if (currentAmount > targetAmount)
                    {
                        e.CellStyle.ForeColor = Color.Green;
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Black;
                    }


                    
                }
            };


        }   
        private void pnlControl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtAmountUpdate_TextChanged(object sender, EventArgs e)
        {
            if (txtCurrentAmountUpdate.Text == "")
                return;

            string input = txtCurrentAmountUpdate.Text.Replace(",", "");
            if (decimal.TryParse(input, out decimal value))
            {
                txtCurrentAmountUpdate.Text = string.Format("{0:N0}", value);
                txtCurrentAmountUpdate.SelectionStart = txtCurrentAmountUpdate.Text.Length;
            }
            else
            {
                MessageBox.Show("Please enter a valid number.", "Format error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {


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
            using (frmAddGoal frmAddGoal = new frmAddGoal())
            {

                if (frmAddGoal.ShowDialog() == DialogResult.OK)
                {
                    LoadGoalsBasedOnCriteria();
                }
                
            }
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
            try
            {

                if (!ValidationHelper.IsNotEmpty(txtNameUpdate.Text))
                {

                    throw new Exception("Goal name is required");
                }
                if (!ValidationHelper.IsNotEmpty(txtCurrentAmountUpdate.Text))
                {
                    throw new Exception("Current amount is required");
                }
                if (!ValidationHelper.IsNotEmpty(txtTargetAmountUpdate.Text))
                {
                    throw new Exception("Target amount is required");
                }
                if (!ValidationHelper.IsValidDecimal(txtTargetAmountUpdate.Text))
                {
                    throw new Exception("Target amount input is not valid");
                }
                if (!ValidationHelper.IsValidDecimal(txtCurrentAmountUpdate.Text))
                {
                    throw new Exception("Current amount input is not valid");
                }
                GetGoalData();
                if (GoalService.UpdateGoal(goal))
                {
                    MessageBox.Show("Update goal successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGoalsBasedOnCriteria();
                }
                else
                {
                    throw new Exception("Update failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
            {
                GetGoalData();
                DialogResult check = MessageBox.Show("Are you sure you want to delete this goal?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    if (GoalService.DeleteGoal(goal))
                    {
                        MessageBox.Show("Delete successfully");
                        LoadGoalsBasedOnCriteria();
                    }
                    else
                    {
                        throw new Exception("Error when delete goal");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                // Lấy dữ liệu từ các cột
                selectedId = dgvGoals.Rows[e.RowIndex].Cells[0].Value.ToString();
                selectedName = dgvGoals.Rows[e.RowIndex].Cells[2].Value.ToString();
                selectedTargetAmount = dgvGoals.Rows[e.RowIndex].Cells[3].Value.ToString();
                selectedCurrentAmount = dgvGoals.Rows[e.RowIndex].Cells[4].Value.ToString();
                selectedDeadline = dgvGoals.Rows[e.RowIndex].Cells[5].Value.ToString();
                selectedDescription = dgvGoals.Rows[e.RowIndex].Cells[6].Value.ToString();

                // Cập nhật progress bar
                decimal targetAmount = Convert.ToDecimal(selectedTargetAmount);
                decimal currentAmount = Convert.ToDecimal(selectedCurrentAmount);
                prgGoalTrack.Minimum = 0;
                prgGoalTrack.Maximum = 100;
                int percentage = Convert.ToInt32((currentAmount / targetAmount) * 100);
                percentage = (percentage > 100) ? 100 : percentage;
                prgGoalTrack.Value = percentage;
                lblGoalTrackValue.Text = percentage + "%";

                // Gán dữ liệu vào các TextBox tương ứng
                txtIDUpdate.Text = selectedId;
                txtNameUpdate.Text = selectedName;
                txtTargetAmountUpdate.Text = selectedTargetAmount;
                txtCurrentAmountUpdate.Text = selectedCurrentAmount;
                txtDescriptionUpdate.Text = selectedDescription;
                dtpDeadlineUpdate.Value = DateTime.Parse(selectedDeadline);
             

            }
        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void txtTargetAmountUpdate_TextChanged(object sender, EventArgs e)
        {
            if (txtTargetAmountUpdate.Text == "")
                return;

            string input = txtTargetAmountUpdate.Text.Replace(",", "");
            if (decimal.TryParse(input, out decimal value))
            {
                txtTargetAmountUpdate.Text = string.Format("{0:N0}", value);
                txtTargetAmountUpdate.SelectionStart = txtTargetAmountUpdate.Text.Length;
            }
            else
            {
                MessageBox.Show("Please enter a valid number.", "Format error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void prgGoalTrack_Click(object sender, EventArgs e)
        {

        }
    }
}
