using FinanceManagement.Forms;
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

namespace FinanceManagement
{
    public partial class frmMain : Form
    {
        public Point mouseLocation;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ShowUserControl(new frmDashboard());
            btnClose.TabStop = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to exit", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void tabDashboard_Click(object sender, EventArgs e)
        {
        }

        private void tabCategory_Click(object sender, EventArgs e)
        {
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
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

        private void UpdateMainContent(UserControl control, string headerText)
        {
            ShowUserControl(control);
            lblMain.Text = headerText;
        }

        private void ShowUserControl(UserControl control)
        {
            pnlContent.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(control);
        }

        private void btnToDashBoard_Click(object sender, EventArgs e)
        {
            UpdateMainContent(new frmDashboard(), "Finance Management | Dashboard");
        }

        private void btnToCategory_Click(object sender, EventArgs e)
        {
            UpdateMainContent(new frmCategoryManagement(), "Finance Management | Category");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to log out?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                this.Hide();
                frmLogin frmLogin = new frmLogin();
                frmLogin.Show();

                // Remove session
                UserSession.Instance.ClearSession();
            }
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
