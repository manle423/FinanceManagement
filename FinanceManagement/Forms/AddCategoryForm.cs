using FinanceManagement.Services;
using FinanceManagement.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceManagement
{
    public partial class AddCategoryForm : Form
    {
        public Point mouseLocation;

        public AddCategoryForm()
        {
            InitializeComponent();
            this.AcceptButton = btnAdd;
            rdoIncome.Checked = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string categoryType = string.Empty;

                if (rdoExpense.Checked)
                {
                    categoryType = "EXPENSE";
                }
                else if (rdoIncome.Checked)
                {
                    categoryType = "INCOME";
                }

                string name = txtName.Text;
                string description = txtDescription.Text;

                if (!ValidationHelper.IsNotEmpty(name))
                {
                    throw new Exception("Name of category is required");
                }

                bool isAdded = CategoryService.AddCategory(name, categoryType, description);

                if (isAdded)
                {
                    MessageBox.Show("Add Category successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Add Category failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ClearForm()
        {
            txtName.Clear();
            txtDescription.Clear();
        }

        private void AddCategory_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mouse_Down(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void mouse_Move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void rdoExpense_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
