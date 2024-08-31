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
using FinanceManagement.Forms;
using FinanceManagement.Models;
using FinanceManagement.Services;
using FinanceManagement.Utils;

namespace FinanceManagement.Forms.Transaction
{
    public partial class frmAddTransaction : Form
    {
        int userId = UserSession.Instance.UserId;
        string username = UserSession.Instance.Username;
        public frmAddTransaction()
        {
            InitializeComponent();
        }

        private void frmAddTransaction_Load(object sender, EventArgs e)
        {
            LoadCategoriesComboBox(cboCategory);
        }
        public void LoadCategoriesComboBox(ComboBox cboCategory)
        {
            List<Category> categories = CategoryService.GetAllCategories(null);
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
            cboCategory.DataSource = categories;
        }

        private void ClearForm()
        {
            txtAmount.Clear();
            txtDescription.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (!ValidationHelper.IsNotEmpty(txtAmount.Text))
                {
                    throw new Exception("Transaction amount is required");
                }

                DateTime transactionDate = dtpTransactionDate.Value;
                int categoryId = int.Parse(cboCategory.SelectedValue.ToString());
                decimal amount = decimal.Parse(txtAmount.Text);
                string description = txtDescription.Text;

                bool isAdded = TransactionService.AddTransaction(userId,categoryId,amount,transactionDate,description);

                if (isAdded)
                {
                    MessageBox.Show("Add Transaction successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    throw new Exception("Add Transaction failed. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
