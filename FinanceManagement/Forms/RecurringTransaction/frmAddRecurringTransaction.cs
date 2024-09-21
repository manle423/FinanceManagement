using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinanceManagement.Models;
using FinanceManagement.Services;
using FinanceManagement.Utils;

namespace FinanceManagement.Forms.RecurringTransaction
{
    public partial class frmAddRecurringTransaction : Form
    {
        int userId = UserSession.Instance.UserId;

        public Point mouseLocation;
        public frmAddRecurringTransaction()
        {
            InitializeComponent();
            AcceptButton = btnAdd;
            CancelButton = btnCancel;

            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.MinDate = DateTime.Today;
            dtpEndDate.MaxDate = DateTime.Today.AddYears(10);
            dtpEndDate.Value = DateTime.Today.AddMonths(1);
        }

        private void frmRecurringTransaction_Load(object sender, EventArgs e)
        {
            LoadCategoriesComboBox();
            LoadFrequencyComboBox();
            UpdateEndDateMinimum();
        }

        private void LoadCategoriesComboBox()
        {
            List<Category> categories = CategoryService.GetAllCategories(null);
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
            cboCategory.DataSource = categories;
        }

        private void LoadFrequencyComboBox()
        {
            cboFrequency.DataSource = Enum.GetValues(typeof(eFrequency));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateEndDateMinimum()
        {
            if (cboFrequency.SelectedItem == null) return;

            eFrequency selectedFrequency = (eFrequency)cboFrequency.SelectedItem;
            DateTime minEndDate = dtpStartDate.Value;

            switch (selectedFrequency)
            {
                case eFrequency.Monthly:
                    minEndDate = minEndDate.AddMonths(1);
                    break;
                case eFrequency.Yearly:
                    minEndDate = minEndDate.AddYears(1);
                    break;
            }

            // Ensure the new MinDate doesn't exceed MaxDate
            if (minEndDate > dtpEndDate.MaxDate)
            {
                dtpEndDate.MaxDate = minEndDate;
            }

            dtpEndDate.MinDate = minEndDate;

            // Adjust the current value if it's less than the new MinDate
            if (dtpEndDate.Value < minEndDate)
            {
                dtpEndDate.Value = minEndDate;
            }
        }

        private bool ValidateInput()
        {
            if (cboCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtAmount.Text, out _))
            {
                MessageBox.Show("Please enter a valid amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("Start date cannot be later than end date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            eFrequency selectedFrequency = (eFrequency)cboFrequency.SelectedItem;
            TimeSpan difference = dtpEndDate.Value - dtpStartDate.Value;

            switch (selectedFrequency)
            {
                case eFrequency.Monthly:
                    if (difference.TotalDays < 28)
                    {
                        MessageBox.Show("For monthly recurring transactions, the end date must be at least one month after the start date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    break;
                case eFrequency.Yearly:
                    if (difference.TotalDays < 365)
                    {
                        MessageBox.Show("For yearly recurring transactions, the end date must be at least one year after the start date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    break;
            }

            return true;
        }

        private void ClearForm()
        {
            // Temporarily remove event handlers
            dtpStartDate.ValueChanged -= dtpStartDate_ValueChanged;
            cboFrequency.SelectedIndexChanged -= cboFrequency_SelectedIndexChanged;

            cboCategory.SelectedIndex = -1;
            txtAmount.Clear();
            
            // Reset dates
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.MinDate = DateTime.Today;
            dtpEndDate.MaxDate = DateTime.Today.AddYears(10);
            dtpEndDate.Value = DateTime.Today.AddMonths(1);

            cboFrequency.SelectedIndex = -1;
            txtDescription.Clear();

            // Reattach event handlers
            dtpStartDate.ValueChanged += dtpStartDate_ValueChanged;
            cboFrequency.SelectedIndexChanged += cboFrequency_SelectedIndexChanged;

            // Update end date minimum after resetting values
            UpdateEndDateMinimum();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                {
                    return;
                }

                Models.RecurringTransaction recurringTransaction = new Models.RecurringTransaction
                {
                    UserId = userId,
                    CategoryId = (int)cboCategory.SelectedValue,
                    Amount = decimal.Parse(txtAmount.Text),
                    StartDate = dtpStartDate.Value,
                    EndDate = dtpEndDate.Value,
                    Frequency = (eFrequency)cboFrequency.SelectedItem,
                    Description = txtDescription.Text
                };

                int newRecurringId = RecurringTransactionService.AddRecurringTransaction(recurringTransaction);

                if (newRecurringId > 0)
                {
                    // Set the ID of the newly created recurring transaction
                    recurringTransaction.Id = newRecurringId;

                    // Tạo các giao dịch định kỳ đã qua
                    RecurringTransactionService.CreatePastTransactions(recurringTransaction);

                    MessageBox.Show("Recurring transaction added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to add recurring transaction. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateEndDateMinimum();
        }

        private void cboFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEndDateMinimum();
        }

        private void frmAddRecurringTransaction_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtAmount.Text == "")
                return;

            string input = txtAmount.Text.Replace(",", "");
            if (decimal.TryParse(input, out decimal value))
            {
                txtAmount.Text = string.Format("{0:N0}", value);
                txtAmount.SelectionStart = txtAmount.Text.Length;
            }
            else
            {
                MessageBox.Show("Please enter a valid number.", "Format error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
