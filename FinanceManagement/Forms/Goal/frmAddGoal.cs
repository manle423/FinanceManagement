using FinanceManagement.Models;
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
using System.Transactions;
using System.Windows.Forms;

namespace FinanceManagement.Forms.Goal
{
    public partial class frmAddGoal : Form
    {
        int userId = UserSession.Instance.UserId;
        public frmAddGoal()
        {
            InitializeComponent();
            this.AcceptButton = btnAdd;
            this.CancelButton = btnCancel;
        }

        Models.Goal goal = new Models.Goal();
        private void GetGoalData()
        {
            goal.UserId = userId;
            goal.Deadline = dtpDeadline.Value;
            goal.TargetAmount = decimal.Parse(txtTargetAmount.Text);
            goal.Name = txtName.Text;
            goal.Description = txtDescription.Text;
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtTargetAmount.Clear();
            txtDescription.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (!ValidationHelper.IsNotEmpty(txtTargetAmount.Text))
                {
                    throw new Exception("Target amount is required");
                }
                if (!ValidationHelper.IsNotEmpty(txtName.Text))
                {
                    throw new Exception("Goal name is required");
                }
                GetGoalData();
                bool isAdded = GoalService.AddGoal(goal);

                if (isAdded)
                {
                    MessageBox.Show("Add Goal successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    throw new Exception("Add Goal failed. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddGoal_Load(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
