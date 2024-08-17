using FinanceManagement.Forms;
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
            frmDashboard dashboard = new frmDashboard();
            AddFormToTabPage(dashboard, tabDashboard);

            frmCategoryManagement categoryManagement = new frmCategoryManagement();
            AddFormToTabPage(categoryManagement, tabCategory);
        }

        private void AddFormToTabPage(Form form, TabPage tabPage)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            tabPage.Controls.Add(form);
            form.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tabDashboard_Click(object sender, EventArgs e)
        {
        }

        private void tabCategory_Click(object sender, EventArgs e)
        {
        }

        private void tabCtrlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra tab được chọn và thay đổi tiêu đề Form
            switch (tabCtrlMain.SelectedIndex)
            {
                case 0:
                    lblMain.Text = "Finance Management | Dashboard";
                    break;
                case 1:
                    lblMain.Text = "Finance Management | Category";
                    break;
                default:
                    this.Text = "Finance Management";
                    break;
            }
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
    }
}
