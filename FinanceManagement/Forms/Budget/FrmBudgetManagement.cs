using FinanceManagement.Models;
using FinanceManagement.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FinanceManagement.Utils;

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

            LoadCategories();
            LoadBudgetData();
        }

        private void LoadCategories()
        {
            List<Category> categories = CategoryService.GetAllCategories();

            List<Category> categoriesForUpdate = new List<Category>(categories);

            categories.Insert(0, new Category { Id = 0, Name = "All" });

            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";

            cboCategoryUpdate.DataSource = categoriesForUpdate;
            cboCategoryUpdate.DisplayMember = "Name";
            cboCategoryUpdate.ValueMember = "Id";
        }


        private void LoadBudgetData(int? categoryId = null)
        {
            List<Models.Budget> budgets = BudgetService.GetAllBudgets(_userId, categoryId);
            dgvBudgets.DataSource = budgets;

            dgvBudgets.Columns["Id"].HeaderText = "ID";
            dgvBudgets.Columns["CategoryName"].HeaderText = "Category Name";
            dgvBudgets.Columns["Amount"].HeaderText = "Amount";
            dgvBudgets.Columns["StartDate"].HeaderText = "Start Date";
            dgvBudgets.Columns["EndDate"].HeaderText = "End Date";

            dgvBudgets.Columns["Id"].DisplayIndex = 0;
            dgvBudgets.Columns["CategoryName"].DisplayIndex = 1;
            dgvBudgets.Columns["Amount"].DisplayIndex = 2;
            dgvBudgets.Columns["StartDate"].DisplayIndex = 3;
            dgvBudgets.Columns["EndDate"].DisplayIndex = 4;

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
    }
}
