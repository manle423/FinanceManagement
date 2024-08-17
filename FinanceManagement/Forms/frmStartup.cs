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
    public partial class frmStartUp : Form
    {
        public frmStartUp()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pnlTime.Width += 20;
            if (pnlTime.Width > 600)
            {
                timer1.Stop();
                this.Hide();
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
