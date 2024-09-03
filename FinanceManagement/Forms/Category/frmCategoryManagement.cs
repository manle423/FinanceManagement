using FinanceManagement.Models;
using FinanceManagement.Services;
using FinanceManagement.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FinanceManagement.Forms
{
    public partial class frmCategoryManagement : UserControl
    {
        string selectedId = "";
        string selectedName = "";
        string selectedType = "";
        string selectedDescription = "";

        public frmCategoryManagement()
        {
            InitializeComponent();
            cboCateType.SelectedIndex = 0;
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategories.ReadOnly = true;

        }

        private void cboCateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCategoriesBasedOnType();
        }

        private void btnToAddCate_Click(object sender, EventArgs e)
        {
            using (frmAddCategory frmAddCategory = new frmAddCategory())
            {
                if (frmAddCategory.ShowDialog() == DialogResult.OK)
                {
                    LoadCategoriesBasedOnType();
                }
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

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                selectedId = dgvCategories.Rows[e.RowIndex].Cells[0].Value.ToString();
                selectedName = dgvCategories.Rows[e.RowIndex].Cells[1].Value.ToString();
                selectedType = dgvCategories.Rows[e.RowIndex].Cells[2].Value.ToString();
                selectedDescription = dgvCategories.Rows[e.RowIndex].Cells[3].Value.ToString();

                // Gán dữ liệu vào các TextBox tương ứng
                txtIDUpdate.Text = selectedId;
                txtNameUpdate.Text = selectedName;
                txtDescriptionUpdate.Text = selectedDescription;

                if (cboCateTypeUpdate.Items.Contains(selectedType))
                {
                    cboCateTypeUpdate.SelectedItem = selectedType;
                }
                else
                {
                    cboCateTypeUpdate.Text = selectedType;
                }

            }
        }

        private void cboCateTypeUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidationHelper.IsNotEmpty(txtIDUpdate.Text))
                {
                    throw new Exception("Please choose Category");
                }
                DialogResult check = MessageBox.Show("Are you sure you want to delete this category?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    int id = int.Parse(selectedId);
                    if (CategoryService.DeleteCategory(id))
                    {
                        MessageBox.Show("Delete successfully");
                        ClearUpdateField();
                        LoadCategoriesBasedOnType();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtIDUpdate.Text);
                string nameUpdate = txtNameUpdate.Text.Trim();
                string cateTypeUpdate = cboCateTypeUpdate.SelectedItem.ToString();
                string descriptionUpdate = txtDescriptionUpdate.Text.Trim();

                if (!ValidationHelper.IsNotEmpty(id.ToString()))
                {
                    throw new Exception("Please choose Category for update");
                }

                if (!ValidationHelper.IsNotEmpty(nameUpdate))
                {
                    throw new Exception("Name of category is required");
                }

                if (CategoryService.UpdateCategory(id, nameUpdate, cateTypeUpdate, descriptionUpdate))
                {
                    MessageBox.Show("Update category successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearUpdateField();
                    LoadCategoriesBasedOnType();
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

        private void ClearUpdateField()
        {
            txtIDUpdate.Clear();
            txtNameUpdate.Clear();
            txtDescriptionUpdate.Clear();
        }
    }
}
