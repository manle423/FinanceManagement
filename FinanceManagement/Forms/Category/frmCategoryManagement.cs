using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceManagement.Forms
{
    public partial class frmCategoryManagement : Form
    {
        public frmCategoryManagement()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnToAddScreen_Click(object sender, EventArgs e)
        {
            frmAddCategory frmAddCategory = new frmAddCategory();
            frmAddCategory.ShowDialog();
        }
    }
}
