using FinanceManagement.Models;
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
using FinanceManagement.Utils;

namespace FinanceManagement.Forms.Budget
{
    public partial class FrmBudgetManagement : UserControl
    {
        int userId = UserSession.Instance.UserId;
        string selectedId = "";
        string selectedCategory = "";
        string selectedAmount = "";
        DateTime selectedStartDate = DateTime.MinValue;
        DateTime selectedEndDate = DateTime.MinValue;

        public FrmBudgetManagement()
        {
            InitializeComponent();
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

        private void LoadForm()
        {
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Format = DateTimePickerFormat.Custom;

            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            dtpEndDate.CustomFormat = "dd/MM/yyyy";

            LoadBudgetData();
            LoadCategories();
            LoadCategoriesInUpdateView();
        }

        private void FrmBudgetManagement_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadBudgetData(int? categoryId = null)
        {
            List<FinanceManagement.Models.Budget> budgets = BudgetService.GetAllBudgets(userId);

            dgvBudgets.DataSource = budgets;

            dgvBudgets.Columns["Id"].HeaderText = "ID";
            //dgvBudgets.Columns["UserId"].HeaderText = "User ID";
            //dgvBudgets.Columns["CategoryId"].HeaderText = "Category ID";
            dgvBudgets.Columns["CategoryName"].HeaderText = "Category Name";
            dgvBudgets.Columns["Amount"].HeaderText = "Amount";
            dgvBudgets.Columns["StartDate"].HeaderText = "Start Date";
            dgvBudgets.Columns["EndDate"].HeaderText = "End Date";
            //dgvBudgets.Columns["CreatedAt"].HeaderText = "Created At";
            //dgvBudgets.Columns["UpdatedAt"].HeaderText = "Updated At";

            // Set the order of columns
            dgvBudgets.Columns["Id"].DisplayIndex = 0;
            dgvBudgets.Columns["CategoryName"].DisplayIndex = 1;
            dgvBudgets.Columns["Amount"].DisplayIndex = 2;
            dgvBudgets.Columns["StartDate"].DisplayIndex = 3;
            dgvBudgets.Columns["EndDate"].DisplayIndex = 4;

            //Hide column that is not neccessary
            dgvBudgets.Columns["UserId"].Visible = false;
            dgvBudgets.Columns["CategoryId"].Visible = false;
            dgvBudgets.Columns["CreatedAt"].Visible = false;
            dgvBudgets.Columns["UpdatedAt"].Visible = false;
        }



        private void dgvBudgets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                selectedId = dgvBudgets.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                selectedCategory = dgvBudgets.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();
                selectedAmount = dgvBudgets.Rows[e.RowIndex].Cells["Amount"].Value.ToString();
                selectedStartDate = Convert.ToDateTime(dgvBudgets.Rows[e.RowIndex].Cells["StartDate"].Value);
                selectedEndDate = Convert.ToDateTime(dgvBudgets.Rows[e.RowIndex].Cells["EndDate"].Value);

                // Gán dữ liệu vào các TextBox tương ứng
                txtIDUpdate.Text = selectedId;
                txtAmountUpdate.Text = selectedAmount;
                dtpStartDate.Value = selectedStartDate;
                dtpEndDate.Value = selectedEndDate;

                if (cboCategoryUpdate.Items.Contains(selectedCategory))
                {
                    cboCategoryUpdate.SelectedItem = selectedCategory;
                }
                else
                {
                    cboCategoryUpdate.Text = selectedCategory;
                }
            }
        }

        private void dgvBudgets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlControl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? selectedCategoryId = cboCategory.SelectedValue as int?;

            LoadBudgetData(selectedCategoryId);
        }

        private void LoadCategories()
        {
            List<Category> categories = CategoryService.GetAllCategories();

            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
        }

        private void LoadCategoriesInUpdateView()
        {
            List<Category> categories = CategoryService.GetAllCategories();

            cboCategoryUpdate.DataSource = categories;
            cboCategoryUpdate.DisplayMember = "Name";
            cboCategoryUpdate.ValueMember = "Id";
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
                MessageBox.Show("Please enter a valid number.", "Format error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
