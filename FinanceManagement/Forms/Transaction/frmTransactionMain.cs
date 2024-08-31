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
using System.Transactions;
using System.Windows.Forms;

namespace FinanceManagement.Forms.Transaction
{

    public partial class frmTransactionMain : UserControl
    {
        int userId = UserSession.Instance.UserId;
        string username = UserSession.Instance.Username;
        string selectedId = null;
        string selectedType = null;
        string selectedDescription = null;
        string selectedAmount = null;
        string selectedTransactionDate =null;
        int selectedCategoryId = -1;
        string selectedStartDate = null;
        string selectedEndDate = null;

        // Đối tượng trung gian
        Models.Transaction transaction = new Models.Transaction();

        private void GetTransactionData()
        {
            transaction.Id = int.Parse(txtIDUpdate.Text);
            transaction.UserId = userId;
            transaction.CategoryId = int.Parse(cboCategoryUpdate.SelectedValue.ToString());
            transaction.Amount = decimal.Parse(txtAmountUpdate.Text);
            transaction.TransactionDate = dtpDateUpdate.Value;
            transaction.Description = txtDescriptionUpdate.Text;
        }

        public frmTransactionMain()
        {
            InitializeComponent();
            //cboType.SelectedIndex = 0;
            //cboCategory.SelectedIndex = 0;
            dtpStartDate.MinDate = DateTime.MinValue;
            dtpStartDate.MaxDate = DateTime.Now;
            dtpEndDate.MaxDate = DateTime.Now;
            dtpEndDate.MinDate = dtpStartDate.Value;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.ReadOnly = true;
        }

        private void btnToAddCate_Click(object sender, EventArgs e)
        {
            using (frmAddTransaction frmAddTransaction = new frmAddTransaction())
            {
                frmAddTransaction.ShowDialog();
            }
        }

        private void cboCateType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmTransactionMain_Load(object sender, EventArgs e)
        {
            LoadCategoriesComboBox(cboCategory);
            LoadTransactionsBasedOnCriteria();

            // Set viewing transactions during last month on default
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = dtpEndDate.MaxDate;

        }

        private void LoadCategoriesComboBox(ComboBox cboCategory)
        {
            List<Category> categories = CategoryService.GetAllCategories(null);
            categories.Insert(0,new Category(-1, "All"));
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
            cboCategory.DataSource = categories;
            
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboType.SelectedIndex = 0;
            LoadTransactionsBasedOnCriteria();
        }

        private void LoadTransactionsBasedOnCriteria()
        {

            selectedCategoryId = int.Parse(cboCategory.SelectedValue.ToString());
            selectedType = GetSelectedCategoryType();
            // Convert DateTime values to strings in a format suitable for SQL queries
            selectedStartDate = dtpStartDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            selectedEndDate = dtpEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            LoadTransactions(this.userId, selectedStartDate, selectedEndDate, selectedCategoryId, selectedType);
        }

        private void LoadTransactions(int user_id, string startDate = null, string endDate = null, int category_id = -1, string type = null)
        {
            List<Models.Transaction> transactions = TransactionService.GetAllTransactions(userId, startDate, endDate, category_id, type);
            //dgvTransactions.DataSource = transactions;
            ConfigureDataGridView(transactions);
        }
        private void ConfigureDataGridView(List<Models.Transaction> transactions)
        {
            // Đưa danh sách Transactions vào dgv
            dgvTransactions.DataSource = transactions;


            // Điều chỉnh độ rộng của các cột
            dgvTransactions.Columns["Id"].Width = 40;

            dgvTransactions.Columns["Amount"].Width = 150;
            dgvTransactions.Columns["TransactionDate"].Width = 100;
            dgvTransactions.Columns["Description"].Width = 200;
            dgvTransactions.Columns["CreatedAt"].Width = 100;
            dgvTransactions.Columns["UpdatedAt"].Width = 100;

            // Chỉnh lại tiêu đề
            dgvTransactions.Columns["Id"].HeaderText = "ID";
            dgvTransactions.Columns["CategoryId"].HeaderText = "Category";
            dgvTransactions.Columns["Amount"].HeaderText = "Amount";
            dgvTransactions.Columns["TransactionDate"].HeaderText = "Date";
            dgvTransactions.Columns["Description"].HeaderText = "Description";
            dgvTransactions.Columns["CreatedAt"].HeaderText = "Created At";
            dgvTransactions.Columns["UpdatedAt"].HeaderText = "Updated At";

            // Chỉnh lại định dạng ngày/tháng/năm
            dgvTransactions.Columns["TransactionDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvTransactions.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvTransactions.Columns["UpdatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Giấu đi userId
            dgvTransactions.Columns["UserId"].Visible = false;

            if (dgvTransactions.Columns["CategoryName"] == null)
            {
                // Thêm cột Category Name
                DataGridViewTextBoxColumn categoryNameColumn = new DataGridViewTextBoxColumn();
                categoryNameColumn.Name = "CategoryName";
                categoryNameColumn.HeaderText = "Category";
                dgvTransactions.Columns.Add(categoryNameColumn);
                dgvTransactions.Columns["CategoryName"].DisplayIndex = 1;
                dgvTransactions.Columns["CategoryName"].Width = 100;
            }

            // Đưa các Catergory Name vào dgv
            dgvTransactions.DataBindingComplete += (sender, e) =>
            {
                foreach (DataGridViewRow row in dgvTransactions.Rows)
                {
                    int categoryId = Convert.ToInt32(row.Cells["CategoryId"].Value);
                    row.Cells["CategoryName"].Value = CategoryService.GetCategoryName(categoryId);
                }
            };

            // Giấu cột CategoryId (cột này có index 3)
            dgvTransactions.Columns["CategoryId"].Visible = false;
        }

        private void AddCategoryColumn()
        {

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

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            selectedStartDate = dtpStartDate.Value.ToString();
            dtpEndDate.MinDate = dtpStartDate.Value;
            LoadTransactionsBasedOnCriteria();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            selectedEndDate = dtpEndDate.Value.ToString();
            dtpStartDate.MaxDate = dtpEndDate.Value;
            LoadTransactionsBasedOnCriteria();
        }

        private void dgvTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void dgvTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                //MessageBox.Show(e.ColumnIndex.ToString());
                selectedId = dgvTransactions.Rows[e.RowIndex].Cells[1].Value.ToString();
                LoadCategoriesComboBox(cboCategoryUpdate);
                cboCategoryUpdate.SelectedValue = dgvTransactions.Rows[e.RowIndex].Cells[3].Value.ToString(); // hidden column
                cboCategoryUpdate.Text = dgvTransactions.Rows[e.RowIndex].Cells[0].Value.ToString();
                //MessageBox.Show(cboCategoryUpdate.SelectedValue.ToString());
                
                selectedAmount = dgvTransactions.Rows[e.RowIndex].Cells[4].Value.ToString();
                selectedTransactionDate = dgvTransactions.Rows[e.RowIndex].Cells[5].Value.ToString();
                selectedDescription = dgvTransactions.Rows[e.RowIndex].Cells[6].Value.ToString();

                // Gán dữ liệu vào các TextBox tương ứng
                txtIDUpdate.Text = selectedId;
                txtAmountUpdate.Text = selectedAmount;
                txtDescriptionUpdate.Text = selectedDescription;
                dtpDateUpdate.Value = DateTime.Parse(selectedTransactionDate.ToString());

                
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pnlData_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlControl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (!ValidationHelper.IsNotEmpty(txtAmountUpdate.Text))
                {
                    
                    throw new Exception("Transaction amount is required");
                }
                if (!ValidationHelper.IsNotEmpty(transaction.CategoryId.ToString()))
                {
                    throw new Exception("Transaction category is required");
                }
                GetTransactionData();
                if (TransactionService.UpdateTransaction(transaction))
                {
                    MessageBox.Show("Update transaction successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTransactionsBasedOnCriteria();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                GetTransactionData();
                DialogResult check = MessageBox.Show("Are you sure you want to delete this transaction?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    if (TransactionService.DeleteTransaction(transaction))
                    {
                        MessageBox.Show("Delete successfully");
                        LoadTransactionsBasedOnCriteria();
                    }
                    else
                    {
                        throw new Exception("Error when delete category");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCategory.SelectedIndex = 0;
            LoadTransactionsBasedOnCriteria() ;
        }
    }
}
