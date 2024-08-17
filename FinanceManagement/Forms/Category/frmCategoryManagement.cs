using FinanceManagement.Models;
using FinanceManagement.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FinanceManagement.Forms
{
    public partial class frmCategoryManagement : UserControl
    {
        public frmCategoryManagement()
        {
            InitializeComponent();
            cboCateType.SelectedIndex = 0;
        }

        private void cboCateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCategoriesBasedOnType();
        }

        private void btnToAddCate_Click(object sender, EventArgs e)
        {
            using (frmAddCategory frmAddCategory = new frmAddCategory())
            {
                frmAddCategory.ShowDialog();
            }
        }

        private void frmCategoryManagement_Load(object sender, EventArgs e)
        {
            LoadCategoriesBasedOnType();
        }

        private void LoadCategoriesBasedOnType()
        {
            string type = GetSelectedCategoryType();
            LoadCategories(type);
        }

        private string GetSelectedCategoryType()
        {
            switch (cboCateType.SelectedIndex)
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

        private void LoadCategories(string type = null)
        {
            List<Category> categories = CategoryService.GetAllCategories(type);

            ConfigureDataGridView(categories);
        }

        private void ConfigureDataGridView(List<Category> categories)
        {
            dgvCategories.DataSource = categories;

            // Điều chỉnh độ rộng của các cột
            dgvCategories.Columns["Id"].Width = 20;
            dgvCategories.Columns["Name"].Width = 150;
            dgvCategories.Columns["Type"].Width = 100;
            dgvCategories.Columns["Description"].Width = 200;
            dgvCategories.Columns["CreatedAt"].Width = 100;
            dgvCategories.Columns["UpdatedAt"].Width = 100;

            // Chỉnh lại tiêu đề
            dgvCategories.Columns["Id"].HeaderText = "ID";
            dgvCategories.Columns["Name"].HeaderText = "Category Name";
            dgvCategories.Columns["Type"].HeaderText = "Category Type";
            dgvCategories.Columns["Description"].HeaderText = "Description";
            dgvCategories.Columns["CreatedAt"].HeaderText = "Created At";
            dgvCategories.Columns["UpdatedAt"].HeaderText = "Updated At";

            // Chỉnh lại định dạng ngày/tháng/năm
            dgvCategories.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvCategories.Columns["UpdatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadCategoriesBasedOnType();
        }
    }
}
