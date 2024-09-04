using FinanceManagement.Models;
using FinanceManagement.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FinanceManagement.Utils;
using System.Drawing;

namespace FinanceManagement.Forms.Budget
{
    public partial class FrmBudgetManagement : UserControl
    {
        private int _userId = UserSession.Instance.UserId;
        private Models.Budget _budget = new Models.Budget();

        public FrmBudgetManagement()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void FrmBudgetManagement_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void InitializeDataGridView()
        {
            dgvBudgets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBudgets.ReadOnly = true;
            dgvBudgets.CellClick += dgvBudgets_CellClick;
            dgvBudgets.CellFormatting += DgvBudgets_CellFormatting;
        }

        private void LoadForm()
        {
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Format = DateTimePickerFormat.Custom;

            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            dtpEndDate.CustomFormat = "dd/MM/yyyy";

            ClearUpdateField();

            LoadCategories();
            LoadBudgetData();
        }

        private void LoadCategories()
        {
            List<Category> categories = CategoryService.GetAllCategories("expense");

            List<Category> categoriesForUpdate = new List<Category>(categories);

            categories.Insert(0, new Category { Id = 0, Name = "All" });

            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";

            cboCategoryUpdate.DataSource = categoriesForUpdate;
            cboCategoryUpdate.DisplayMember = "Name";
            cboCategoryUpdate.ValueMember = "Id";
        }


        // private void LoadBudgetData(int? categoryId = null)
        // {
        //     List<Models.Budget> budgets = BudgetService.GetAllBudgets(_userId, categoryId);
        //     dgvBudgets.DataSource = budgets;

        //     dgvBudgets.Columns["Id"].HeaderText = "ID";
        //     dgvBudgets.Columns["CategoryName"].HeaderText = "Category Name";
        //     dgvBudgets.Columns["Amount"].HeaderText = "Amount";
        //     dgvBudgets.Columns["StartDate"].HeaderText = "Start Date";
        //     dgvBudgets.Columns["EndDate"].HeaderText = "End Date";

        //     dgvBudgets.Columns["Id"].DisplayIndex = 0;
        //     dgvBudgets.Columns["CategoryName"].DisplayIndex = 1;
        //     dgvBudgets.Columns["Amount"].DisplayIndex = 2;
        //     dgvBudgets.Columns["StartDate"].DisplayIndex = 3;
        //     dgvBudgets.Columns["EndDate"].DisplayIndex = 4;

        //     dgvBudgets.Columns["UserId"].Visible = false;
        //     dgvBudgets.Columns["CategoryId"].Visible = false;
        //     dgvBudgets.Columns["CreatedAt"].Visible = false;
        //     dgvBudgets.Columns["UpdatedAt"].Visible = false;
        // }

        // private void dgvBudgets_CellClick(object sender, DataGridViewCellEventArgs e)
        // {
        //     if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
        //     {
        //         _budget.Id = Convert.ToInt32(dgvBudgets.Rows[e.RowIndex].Cells["Id"].Value);
        //         txtIDUpdate.Text = _budget.Id.ToString();

        //         txtAmountUpdate.Text = dgvBudgets.Rows[e.RowIndex].Cells["Amount"].Value.ToString();
        //         dtpStartDate.Value = Convert.ToDateTime(dgvBudgets.Rows[e.RowIndex].Cells["StartDate"].Value);
        //         dtpEndDate.Value = Convert.ToDateTime(dgvBudgets.Rows[e.RowIndex].Cells["EndDate"].Value);

        //         cboCategoryUpdate.SelectedValue = dgvBudgets.Rows[e.RowIndex].Cells["CategoryId"].Value;
        //     }
        // }

        private void LoadBudgetData(int? categoryId = null)
        {
            List<Models.Budget> budgets = BudgetService.GetAllBudgetsWithTrack(_userId, categoryId);
            dgvBudgets.DataSource = budgets;

            dgvBudgets.Columns["Id"].HeaderText = "ID";
            dgvBudgets.Columns["CategoryName"].HeaderText = "Category Name";
            dgvBudgets.Columns["Amount"].HeaderText = "Budgeted Amount";
            dgvBudgets.Columns["StartDate"].HeaderText = "Start Date";
            dgvBudgets.Columns["EndDate"].HeaderText = "End Date";
            dgvBudgets.Columns["TotalSpent"].HeaderText = "Total Spent";
            dgvBudgets.Columns["RemainingBudget"].HeaderText = "Remaining Budget";
            dgvBudgets.Columns["BudgetProgressPercentage"].HeaderText = "Progress (%)";
            dgvBudgets.Columns["BudgetStatus"].HeaderText = "Status";

            dgvBudgets.Columns["Id"].DisplayIndex = 0;
            dgvBudgets.Columns["CategoryName"].DisplayIndex = 1;
            dgvBudgets.Columns["Amount"].DisplayIndex = 2;
            dgvBudgets.Columns["StartDate"].DisplayIndex = 3;
            dgvBudgets.Columns["EndDate"].DisplayIndex = 4;
            dgvBudgets.Columns["TotalSpent"].DisplayIndex = 5;
            dgvBudgets.Columns["RemainingBudget"].DisplayIndex = 6;
            dgvBudgets.Columns["BudgetProgressPercentage"].DisplayIndex = 7;
            dgvBudgets.Columns["BudgetStatus"].DisplayIndex = 8;

            dgvBudgets.Columns["UserId"].Visible = false;
            dgvBudgets.Columns["CategoryId"].Visible = false;
            dgvBudgets.Columns["CreatedAt"].Visible = false;
            dgvBudgets.Columns["UpdatedAt"].Visible = false;
        }

        private void dgvBudgets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                _budget.Id = Convert.ToInt32(dgvBudgets.Rows[e.RowIndex].Cells["Id"].Value);
                txtIDUpdate.Text = _budget.Id.ToString();

                txtAmountUpdate.Text = dgvBudgets.Rows[e.RowIndex].Cells["Amount"].Value.ToString();
                dtpStartDate.Value = Convert.ToDateTime(dgvBudgets.Rows[e.RowIndex].Cells["StartDate"].Value);
                dtpEndDate.Value = Convert.ToDateTime(dgvBudgets.Rows[e.RowIndex].Cells["EndDate"].Value);

                cboCategoryUpdate.SelectedValue = dgvBudgets.Rows[e.RowIndex].Cells["CategoryId"].Value;

                txtTotalSpent.Text = dgvBudgets.Rows[e.RowIndex].Cells["TotalSpent"].Value.ToString();
                txtRemaining.Text = dgvBudgets.Rows[e.RowIndex].Cells["RemainingBudget"].Value.ToString();

                decimal progressPercentage = Convert.ToDecimal(dgvBudgets.Rows[e.RowIndex].Cells["BudgetProgressPercentage"].Value);

                // Set progress bar value and color
                if (progressPercentage > 100)
                {
                    prgBudgetTrack.Value = 100;
                    prgBudgetTrack.ForeColor = Color.Red;
                }
                else
                {
                    prgBudgetTrack.Value = (int)progressPercentage;
                    prgBudgetTrack.ForeColor = SystemColors.Highlight; // Default color
                }

                lblBudgetTrackValue.Text = $"{progressPercentage:F2}%";

                // Set label color based on budget status
                string budgetStatus = dgvBudgets.Rows[e.RowIndex].Cells["BudgetStatus"].Value.ToString();
                switch (budgetStatus)
                {
                    case "OVER BUDGET":
                        lblBudgetTrackValue.ForeColor = Color.Red;
                        break;
                    case "UNDER BUDGET":
                        lblBudgetTrackValue.ForeColor = Color.Green;
                        break;
                    default:
                        lblBudgetTrackValue.ForeColor = Color.Black;
                        break;
                }
            }
        }

        private void DgvBudgets_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBudgets.Columns[e.ColumnIndex].Name == "Amount" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal amount))
                {
                    e.Value = string.Format("{0:N0}", amount);
                    e.FormattingApplied = true;
                }
            }

            if (dgvBudgets.Columns[e.ColumnIndex].Name == "TotalSpent" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal totalSpent))
                {
                    e.Value = string.Format("{0:N0}", totalSpent);
                    e.FormattingApplied = true;
                }
            }

            if (dgvBudgets.Columns[e.ColumnIndex].Name == "RemainingBudget" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal remaining))
                {
                    e.Value = string.Format("{0:N0}", remaining);
                    e.FormattingApplied = true;
                }
            }

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBudgets.Rows[e.RowIndex];
                string budgetStatus = row.Cells["BudgetStatus"].Value.ToString();

                switch (budgetStatus)
                {
                    case "OVER BUDGET":
                        row.DefaultCellStyle.BackColor = Color.LightPink;
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                        break;
                    case "UNDER BUDGET":
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                        break;
                    default:
                        row.DefaultCellStyle.BackColor = dgvBudgets.DefaultCellStyle.BackColor;
                        row.DefaultCellStyle.ForeColor = dgvBudgets.DefaultCellStyle.ForeColor;
                        break;
                }
            }
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedValue != null)
            {
                int? selectedCategoryId = cboCategory.SelectedValue as int?;
                LoadBudgetData(selectedCategoryId);
            }
        }

        private void GetBudgetDataFromUI()
        {
            _budget.Id = int.Parse(txtIDUpdate.Text);
            _budget.UserId = _userId;
            _budget.CategoryId = int.Parse(cboCategoryUpdate.SelectedValue.ToString());
            _budget.Amount = decimal.Parse(txtAmountUpdate.Text);
            _budget.StartDate = dtpStartDate.Value;
            _budget.EndDate = dtpEndDate.Value;
        }

        private void btnToAddBudget_Click(object sender, EventArgs e)
        {
            using (FrmAddBudget frmAddBudget = new FrmAddBudget())
            {
                if (frmAddBudget.ShowDialog() == DialogResult.OK)
                {
                    LoadForm();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateBudgetData();
                GetBudgetDataFromUI();

                if (BudgetService.UpdateBudget(_budget))
                {
                    ShowMessage("Update Budget successfully", "Notification", MessageBoxIcon.Information);
                    LoadForm();
                }
                else
                {
                    throw new Exception("Update failed");
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                GetBudgetDataFromUI();

                if (!ValidationHelper.IsNotEmpty(txtIDUpdate.Text))
                {
                    throw new Exception("Please choose Budget");
                }

                if (ConfirmDelete())
                {
                    if (BudgetService.DeleteBudget(_budget))
                    {
                        ShowMessage("Delete successfully", "Notification", MessageBoxIcon.Information);
                        LoadForm();
                    }
                    else
                    {
                        throw new Exception("Delete failed");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private bool ConfirmDelete()
        {
            return MessageBox.Show("Are you sure you want to delete this budget?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void ValidateBudgetData()
        {
            if (!ValidationHelper.IsNotEmpty(txtIDUpdate.Text))
            {
                throw new Exception("Please choose Budget to edit");
            }

            if (!ValidationHelper.IsNotEmpty(txtAmountUpdate.Text))
            {
                throw new Exception("Budget amount is required");
            }

            if (!ValidationHelper.IsNotEmpty(cboCategoryUpdate.SelectedValue.ToString()))
            {
                throw new Exception("Budget category is required");
            }
        }

        private void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        private void ShowError(string message)
        {
            ShowMessage($"An error occurred: {message}", "Error", MessageBoxIcon.Error);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void txtAmountUpdate_TextChanged(object sender, EventArgs e)
        {
            if (txtAmountUpdate.Text == "")
                return;

            string input = txtAmountUpdate.Text.Replace(",", "");
            if (decimal.TryParse(input, out decimal value))
            {
                txtAmountUpdate.Text = string.Format("{0:N0}", value);
                txtAmountUpdate.SelectionStart = txtAmountUpdate.Text.Length;
            }
            else
            {
                ShowError("Please enter a valid number.");
            }
        }

        private void ClearUpdateField()
        {
            txtIDUpdate.Clear();
            txtAmountUpdate.Clear();
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;

            cboCategoryUpdate.SelectedIndex = -1;
        }

        private void txtTotalSpent_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalSpent.Text == "")
                return;

            string input = txtTotalSpent.Text.Replace(",", "");
            if (decimal.TryParse(input, out decimal value))
            {
                txtTotalSpent.Text = string.Format("{0:N0}", value);
                txtTotalSpent.SelectionStart = txtTotalSpent.Text.Length;
            }
            else
            {
                ShowError("Please enter a valid number.");
            }
        }

        private void txtRemaining_TextChanged(object sender, EventArgs e)
        {
            if (txtRemaining.Text == "")
                return;

            string input = txtRemaining.Text.Replace(",", "");
            if (decimal.TryParse(input, out decimal value))
            {
                txtRemaining.Text = string.Format("{0:N0}", value);
                txtRemaining.SelectionStart = txtRemaining.Text.Length;
            }
            else
            {
                ShowError("Please enter a valid number.");
            }
        }
    }
}
