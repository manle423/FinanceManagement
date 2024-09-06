using FinanceManagement.Models;
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

namespace FinanceManagement.Forms.RecurringTransaction
{
    public partial class frmRecurringTransactionManagement : UserControl
    {
        private int userId = UserSession.Instance.UserId;
        public int selectedCategoryId;
        public string selectedType;

        public frmRecurringTransactionManagement()
        {
            InitializeComponent();
        }

        private void LoadTypeComboBox()
        {
            cboType.SelectedIndex = 0;
        }

        private void LoadRecurringTransactions()
        {
            selectedCategoryId = (int)cboCategory.SelectedValue;
            selectedType = GetSelectedCategoryType();
            List<Models.RecurringTransaction> recurringTransactions = RecurringTransactionService.GetAllRecurringTransactions(userId, selectedCategoryId, selectedType);
            ConfigureDataGridView(recurringTransactions);
        }

        private string GetSelectedCategoryType()
        {
            switch (cboType.SelectedIndex)
            {
                case 0:
                    return null;
                case 1:
                    return "EXPENSE";
                case 2:
                    return "INCOME";
                default:
                    return null;
            }
        }

        private void ConfigureDataGridView(List<Models.RecurringTransaction> recurringTransactions)
        {
            if (recurringTransactions == null || recurringTransactions.Count == 0)
            {
                MessageBox.Show("No recurring transactions found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvRecurringTransactions.DataSource = null;
                return;
            }

            dgvRecurringTransactions.DataSource = recurringTransactions;

            // Hide unnecessary columns
            dgvRecurringTransactions.Columns["UserId"].Visible = false;
            dgvRecurringTransactions.Columns["CategoryId"].Visible = false;
            dgvRecurringTransactions.Columns["CreatedAt"].Visible = false;
            dgvRecurringTransactions.Columns["UpdatedAt"].Visible = false;

            // Rename and reorder columns
            dgvRecurringTransactions.Columns["Id"].HeaderText = "ID";
            dgvRecurringTransactions.Columns["CategoryName"].HeaderText = "Category";
            dgvRecurringTransactions.Columns["Amount"].HeaderText = "Amount";
            dgvRecurringTransactions.Columns["StartDate"].HeaderText = "Start Date";
            dgvRecurringTransactions.Columns["EndDate"].HeaderText = "End Date";
            dgvRecurringTransactions.Columns["Frequency"].HeaderText = "Frequency";
            dgvRecurringTransactions.Columns["Description"].HeaderText = "Description";

            // Set column order
            dgvRecurringTransactions.Columns["Id"].DisplayIndex = 0;
            dgvRecurringTransactions.Columns["CategoryName"].DisplayIndex = 1;
            dgvRecurringTransactions.Columns["Amount"].DisplayIndex = 2;
            dgvRecurringTransactions.Columns["StartDate"].DisplayIndex = 3;
            dgvRecurringTransactions.Columns["EndDate"].DisplayIndex = 4;
            dgvRecurringTransactions.Columns["Frequency"].DisplayIndex = 5;
            dgvRecurringTransactions.Columns["Description"].DisplayIndex = 6;

            // Set column widths
            dgvRecurringTransactions.Columns["Id"].Width = 50;
            dgvRecurringTransactions.Columns["CategoryName"].Width = 100;
            dgvRecurringTransactions.Columns["Amount"].Width = 100;
            dgvRecurringTransactions.Columns["StartDate"].Width = 100;
            dgvRecurringTransactions.Columns["EndDate"].Width = 100;
            dgvRecurringTransactions.Columns["Frequency"].Width = 80;
            dgvRecurringTransactions.Columns["Description"].Width = 200;

            // Set date format
            dgvRecurringTransactions.Columns["StartDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvRecurringTransactions.Columns["EndDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Set number format for Amount
            dgvRecurringTransactions.Columns["Amount"].DefaultCellStyle.Format = "N0";
            dgvRecurringTransactions.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }



        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedIndex != -1)
            {
                LoadRecurringTransactions();
            }
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex != 0)
            {
                LoadRecurringTransactions();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadRecurringTransactions();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (frmAddRecurringTransaction frm = new frmAddRecurringTransaction())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadRecurringTransactions();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                Models.RecurringTransaction updatedTransaction = new Models.RecurringTransaction
                {
                    Id = int.Parse(txtIDUpdate.Text),
                    UserId = userId,
                    CategoryId = (int)cboCategoryUpdate.SelectedValue,
                    Amount = decimal.Parse(txtAmountUpdate.Text),
                    StartDate = dtpStartDate.Value,
                    EndDate = dtpEndDate.Value,
                    Frequency = (eFrequency)Enum.Parse(typeof(eFrequency), cboFrequency.SelectedItem.ToString()),
                    Description = txtDescriptionUpdate.Text
                };

                if (RecurringTransactionService.UpdateRecurringTransaction(updatedTransaction))
                {
                    MessageBox.Show("Recurring transaction updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRecurringTransactions();
                    ClearUpdateFields();
                }
                else
                {
                    MessageBox.Show("Failed to update recurring transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIDUpdate.Text))
            {
                int id = int.Parse(txtIDUpdate.Text);
                DialogResult result = MessageBox.Show("Are you sure you want to delete this recurring transaction?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    if (RecurringTransactionService.DeleteRecurringTransaction(id, userId))
                    {
                        MessageBox.Show("Recurring transaction deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRecurringTransactions();
                        ClearUpdateFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete recurring transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a recurring transaction to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (!ValidationHelper.IsNotEmpty(txtAmountUpdate.Text))
            {
                MessageBox.Show("Please enter an amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!ValidationHelper.IsValidDecimal(txtAmountUpdate.Text))
            {
                MessageBox.Show("Please enter a valid amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cboCategoryUpdate.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cboFrequency.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a frequency.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!ValidationHelper.IsStartDateLessThanEndDate(dtpStartDate.Value, dtpEndDate.Value))
            {
                MessageBox.Show("Start date must be earlier than or equal to the end date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;
            eFrequency selectedFrequency = (eFrequency)Enum.Parse(typeof(eFrequency), cboFrequency.SelectedItem.ToString());

            if (selectedFrequency == eFrequency.Yearly)
            {
                if (endDate < startDate.AddYears(1))
                {
                    MessageBox.Show("For yearly frequency, the duration must be at least one year.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else if (selectedFrequency == eFrequency.Monthly)
            {
                if (endDate < startDate.AddMonths(1))
                {
                    MessageBox.Show("For monthly frequency, the duration must be at least one month.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void ClearUpdateFields()
        {
            txtIDUpdate.Clear();
            txtAmountUpdate.Clear();
            cboCategoryUpdate.SelectedIndex = -1;
            cboFrequency.SelectedIndex = -1;
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
            txtDescriptionUpdate.Clear();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void cboCategoryUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvRecurringTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgvRecurringTransactions.Rows[e.RowIndex];
                Models.RecurringTransaction selectedTransaction = (Models.RecurringTransaction)row.DataBoundItem;
                LoadCategoriesComboBox(cboCategoryUpdate);
                // Populate the textboxes and other controls with the selected transaction data
                txtIDUpdate.Text = selectedTransaction.Id.ToString();
                txtAmountUpdate.Text = selectedTransaction.Amount.ToString("N0");
                dtpStartDate.Value = selectedTransaction.StartDate;
                dtpEndDate.Value = selectedTransaction.EndDate;
                cboCategoryUpdate.SelectedValue = selectedTransaction.CategoryId;
                cboFrequency.SelectedItem = selectedTransaction.Frequency.ToString();
                txtDescriptionUpdate.Text = selectedTransaction.Description;


                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void dgvRecurringTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlData_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmRecurringTransactionManagement_Load(object sender, EventArgs e)
        {
            LoadCategoriesComboBox(cboCategory);
            LoadTypeComboBox();
            LoadFrequencyComboBox();
            LoadRecurringTransactions();

            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Format = DateTimePickerFormat.Custom;

            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            dtpEndDate.CustomFormat = "dd/MM/yyyy";
        }

        public void LoadCategoriesComboBox(ComboBox cboCategory)
        {
            List<Category> categories = CategoryService.GetAllCategories(null);
            categories.Insert(0, new Category(-1, "All"));
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
            cboCategory.DataSource = categories;
        }

        private void LoadFrequencyComboBox()
        {
            cboFrequency.Items.Clear();
            cboFrequency.Items.AddRange(Enum.GetNames(typeof(eFrequency)));
        }
    }
}
