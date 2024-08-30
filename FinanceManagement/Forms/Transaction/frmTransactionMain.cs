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
using System.Transactions;
using System.Windows.Forms;

namespace FinanceManagement.Forms.Transaction
{

    public partial class frmTransactionMain : UserControl
    {
        int userId = UserSession.Instance.UserId;
        string username = UserSession.Instance.Username;

        string selectedType = null;
        int selectedCategoryId = -1;
        string selectedStartDate = null;
        string selectedEndDate = null;
        public frmTransactionMain()
        {
            InitializeComponent();
            cboType.SelectedIndex = 0;
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

        }

        private void cboCateType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmTransactionMain_Load(object sender, EventArgs e)
        {
            LoadCategoriesComboBox();
            LoadTransactionsBasedOnCriteria();

        }

        private void LoadCategoriesComboBox()
        {
            List<Category> categories = CategoryService.GetAllCategories(null);
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
            cboCategory.DataSource = categories;
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = dtpEndDate.MaxDate;

        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            dgvTransactions.Columns["TransactionDate"].HeaderText = "Transaction Date";
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
                // Add a new column for Category Name
                DataGridViewTextBoxColumn categoryNameColumn = new DataGridViewTextBoxColumn();
                categoryNameColumn.Name = "CategoryName";
                categoryNameColumn.HeaderText = "Category";
                dgvTransactions.Columns.Add(categoryNameColumn);
                dgvTransactions.Columns["CategoryName"].DisplayIndex = 1;
                dgvTransactions.Columns["CategoryName"].Width = 100;
            }

            // Populate CategoryName column with category names
            dgvTransactions.DataBindingComplete += (sender, e) =>
            {
                foreach (DataGridViewRow row in dgvTransactions.Rows)
                {
                    int categoryId = Convert.ToInt32(row.Cells["CategoryId"].Value);
                    row.Cells["CategoryName"].Value = CategoryService.GetCategoryName(categoryId);
                }
            };

            // Hide the original CategoryId column
            dgvTransactions.Columns["CategoryId"].Visible = false;
        }

        private void AddCategoryColumn()
        {

        }

        private string GetSelectedCategoryType()
        {
            switch (cboCategory.SelectedIndex)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pnlData_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
