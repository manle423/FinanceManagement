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
using System.Xml.Linq;

namespace FinanceManagement.Forms.Budget
{
    public partial class FrmAddBudget : Form
    {
        public Point mouseLocation;

        public FrmAddBudget()
        {
            InitializeComponent();
            AcceptButton = btnAdd;
            CancelButton = btnCancel;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAddBudget_Load(object sender, EventArgs e)
        {
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Format = DateTimePickerFormat.Custom;

            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            dtpEndDate.CustomFormat = "dd/MM/yyyy";

            LoadCategories();
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAddBudget_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ClearForm()
        {
            cboCategory.SelectedItem = -1;
            txtAmount.Clear();
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = UserSession.Instance.UserId;
                int categoryId = (int)cboCategory.SelectedValue;
                double amount = double.Parse(txtAmount.Text);
                DateTime startDate = dtpStartDate.Value;
                DateTime endDate = dtpEndDate.Value;

                if (!ValidationHelper.IsNotEmpty(amount.ToString()))
                {
                    throw new Exception("Amount is required");
                }

                if (!ValidationHelper.IsStartDateLessThanEndDate(startDate, endDate))
                {
                    throw new Exception("Start Date must be less than End Date.");    
                }

                bool isAdded = BudgetService.AddBudget(userId, categoryId, amount, startDate, endDate);

                if (isAdded)
                {
                    MessageBox.Show("Add Budget successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    throw new Exception("Add Budget failed. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            List<Category> categories = CategoryService.GetAllCategories();
            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
            cboCategory.SelectedIndex = 0;
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
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
