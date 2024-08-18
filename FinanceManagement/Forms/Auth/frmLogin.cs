using FinanceManagement.Forms;
using FinanceManagement.Services;
using FinanceManagement.Utils;
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

    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
            AcceptButton = btnLogin;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to exit", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                if (!ValidationHelper.IsNotEmpty(username))
                {
                    throw new Exception("Username is required");
                }

                if (!ValidationHelper.IsNotEmpty(password))
                {
                    throw new Exception("Password is required");
                }

                if (!UserService.ValidateUser(username, password))
                {
                    throw new Exception("Invalid Credentials");
                }
                MessageBox.Show("Login successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //frmDashboard dashboardForm = new frmDashboard();
                //this.Hide();
                //dashboardForm.Show();

                frmMain main = new frmMain();
                this.Hide();
                main.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.TabIndex = 0;
            txtPassword.TabIndex = 1;
            btnClose.TabStop = false;

        }

        private void btnToRegister_Click(object sender, EventArgs e)
        {
            frmRegister registerform = new frmRegister();
            registerform.Show();
            this.Hide();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPass.Checked ? '\0' : '*';
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
