using System;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceManagement.Forms
{
    public partial class frmDashboard : Form
    {
        public Point mouseLocation;

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnAddCate_Click(object sender, EventArgs e)
        {
            frmCategoryManagement frmCategoryManagement = new frmCategoryManagement();
            frmCategoryManagement.Show();
        }

        private void mouse_Down(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void mouse_Move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }
    }
}
