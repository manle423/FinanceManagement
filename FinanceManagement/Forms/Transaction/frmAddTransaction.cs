using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using FinanceManagement.Forms;
using FinanceManagement.Models;
using FinanceManagement.Services;
using FinanceManagement.Utils;

namespace FinanceManagement.Forms.Transaction
{
    public partial class frmAddTransaction : Form
    {
        int userId = UserSession.Instance.UserId;
        string username = UserSession.Instance.Username;
        public frmAddTransaction()
        {
            InitializeComponent();
            this.AcceptButton = btnAdd;
            this.CancelButton = btnCancel;

        }


        private void frmAddTransaction_Load(object sender, EventArgs e)
        {
            LoadCategoriesComboBox(cboCategory);
            LoadGoalsComboBox(cboGoal);


        }
        public void LoadCategoriesComboBox(ComboBox cboCategory)
        {
            List<Category> categories = CategoryService.GetAllCategories(null);
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
            cboCategory.DataSource = categories;
        }

        public void LoadGoalsComboBox(ComboBox cboGoal)
        {
            List<Models.Goal> goals = GoalService.GetAllGoals(userId);
            cboGoal.DisplayMember = "Name";
            cboGoal.ValueMember = "Id";
            cboGoal.DataSource = goals;
        }

        private void ClearForm()
        {
            txtAmount.Clear();
            txtDescription.Clear();
            txtAmountToGoal.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboGoal.Enabled = (CategoryService.GetCategoryType(int.Parse(cboCategory.SelectedValue.ToString())).ToLower() == "income") ? true : false;
            txtAmountToGoal.Enabled = cboGoal.Enabled;
        }

        Models.Transaction transaction = new Models.Transaction();
        private void GetTransactionData()
        {
            transaction.UserId = userId;
            transaction.CategoryId = int.Parse(cboCategory.SelectedValue.ToString());
            transaction.Amount = decimal.Parse(txtAmount.Text);
            transaction.TransactionDate = dtpTransactionDate.Value;
            transaction.Description = txtDescription.Text;
        }

        Models.Goal goal = new Models.Goal();
        private void GetGoalData(int id)
        {
            goal = GoalService.GetGoalById(id);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (!ValidationHelper.IsNotEmpty(txtAmount.Text))
                {
                    throw new Exception("Transaction amount is required");
                }
               

                GetTransactionData();
                if (cboGoal.Enabled)
                {
                    decimal amountToGoal = decimal.Parse(txtAmountToGoal.Text);
                    if (transaction.Amount < amountToGoal)
                    {
                        throw new Exception("Goal amount exceed transaction amount");
                    }
                    GetGoalData(int.Parse(cboGoal.SelectedValue.ToString()));
                    goal.CurrentAmount += amountToGoal;
                    transaction.Amount -= amountToGoal;
                    transaction.Description += $" ({amountToGoal} has been deducted from this transaction for goal {goal.Name})";
                   
                }

                bool isAdded = TransactionService.AddTransaction(transaction);

                if (isAdded)
                {
                    if (cboGoal.Enabled)
                    {
                        bool isGoalAdded = GoalService.UpdateGoal(goal);
                        if (isGoalAdded)
                        {
                            MessageBox.Show("Add Transaction successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        throw new Exception("Update Goal amount failed. Please try again.");
                    }
                    ClearForm();
                }
                else
                {
                    throw new Exception("Add Transaction failed. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboGoal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
