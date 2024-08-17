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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        }

        private void btnToAddCate_Click(object sender, EventArgs e)
        {
            frmAddCategory frmAddCategory = new frmAddCategory();
            frmAddCategory.ShowDialog();
        }

        private void frmCategoryManagement_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            // Lấy danh sách các Category từ CategoryService
            List<Category> categories = CategoryService.GetAllCategories();

            dgvCategories.DataSource = categories;

            // Điều chỉnh độ rộng của các cột
            dgvCategories.Columns["Id"].Width = 20;
            dgvCategories.Columns["Name"].Width = 100;
            dgvCategories.Columns["Type"].Width = 100;
            dgvCategories.Columns["Description"].Width = 200;
            dgvCategories.Columns["CreatedAt"].Width = 100;
            dgvCategories.Columns["UpdatedAt"].Width = 100;

            // Tùy chỉnh tiêu đề cột nếu cần
            dgvCategories.Columns["Id"].HeaderText = "ID";
            dgvCategories.Columns["Name"].HeaderText = "Category Name";
            dgvCategories.Columns["Type"].HeaderText = "Category Type";
            dgvCategories.Columns["Description"].HeaderText = "Description";
            dgvCategories.Columns["CreatedAt"].HeaderText = "Created At";
            dgvCategories.Columns["UpdatedAt"].HeaderText = "Updated At";

            dgvCategories.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvCategories.Columns["UpdatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadCategories();
        }
    }
}
