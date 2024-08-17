using FinanceManagement.Services;
using FinanceManagement.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace FinanceManagement
{
    public partial class frmAddCategory : Form
    {
        public Point mouseLocation;
        string cateType = string.Empty;

        public frmAddCategory()
        {
            InitializeComponent();
            this.AcceptButton = btnAdd;
            this.CancelButton = btnCancel;
            rdoExpense.AutoCheck = true;
            btnClose.TabStop = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string description = txtDescription.Text;

                if (!ValidationHelper.IsNotEmpty(name))
                {
                    throw new Exception("Name of category is required");
                }

                bool isAdded = CategoryService.AddCategory(name, cateType, description);

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
            rdoExpense.Checked = true;
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



        private void grpCateType_Enter(object sender, EventArgs e)
        {
        }

        private void rdoExpense_CheckedChanged(object sender, EventArgs e)
        {
            cateType = "EXPENSE";
        }

        private void rdoIncome_CheckedChanged(object sender, EventArgs e)
        {
            cateType = "INCOME";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
