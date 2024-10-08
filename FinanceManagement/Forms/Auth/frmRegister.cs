﻿using FinanceManagement.Services;
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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
            AcceptButton = btnRegister;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            btnClose.TabStop = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                string confirm = txtConfirm.Text;

                if (!ValidationHelper.IsNotEmpty(username))
                {
                    throw new Exception("Username is required");
                }

                if (!ValidationHelper.IsValidEmail(email))
                {
                    throw new Exception("Invalid Email");
                }

                if (!ValidationHelper.IsValidPassword(password))
                {
                    throw new Exception("Password is not valid");
                }

                if (confirm != password)
                {
                    throw new Exception("Password does not match");
                }

                bool isRegistered = UserService.RegisterUser(username, email, password);

                if (isRegistered)
                {
                    MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    frmLogin loginForm = new frmLogin();
                    loginForm.Show();
                }
                else
                {
                    MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnToLoginForm_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            this.Hide();
            loginForm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to exit", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPass.Checked ? '\0' : '*';
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkShowConf_CheckedChanged(object sender, EventArgs e)
        {
            txtConfirm.PasswordChar = chkShowConf.Checked ? '\0' : '*';
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
