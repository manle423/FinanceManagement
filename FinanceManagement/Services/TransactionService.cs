using FinanceManagement.Data;
using FinanceManagement.Models;
using FinanceManagement.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinanceManagement.Services
{
    internal class TransactionService
    {
        // khai báo 1 lần dbConnection cho dễ dàng sử dụng
        private static readonly DatabaseConnection dbConnection = new DatabaseConnection();

        

        

        // Hàm thêm transaction
        public static bool AddTransaction(Transaction transaction)
        {
            try
            {
                // Kiểm tra ngân sách hiện tại
                Budget currentBudget = BudgetService.GetCurrentBudget(transaction.UserId, transaction.CategoryId, transaction.TransactionDate);
                
                if (currentBudget != null)
                {
                    decimal newTotalSpent = currentBudget.TotalSpent + transaction.Amount;
                    decimal budgetPercentage = (newTotalSpent / currentBudget.Amount) * 100;

                    if (budgetPercentage > 150)
                    {
                        MessageBox.Show("Warning: This transaction will exceed 150% of the budget for this category.", "Budget Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else if (budgetPercentage > 100)
                    {
                        DialogResult result = MessageBox.Show($"This transaction will exceed the budget for this category by {budgetPercentage - 100:F2}%. Do you want to proceed?", "Budget Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.No)
                        {
                            return false;
                        }
                    }
                }

                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    const string query = "INSERT INTO Transactions (user_id, category_id, amount, transaction_date, description) " +
                        "VALUES (@User_id, @Category_id, @Amount, @TransactionDate, @Description)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@User_id", transaction.UserId);
                        cmd.Parameters.AddWithValue("@Category_id", transaction.CategoryId);
                        cmd.Parameters.AddWithValue("@Amount", transaction.Amount);
                        cmd.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate);
                        cmd.Parameters.AddWithValue("@Description", transaction.Description);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Lấy ra tất cả transaction
        public static List<Transaction> GetAllTransactions(int user_id, string startdate = null, string enddate = null, int category_id = -1, string type = null)
        {
            List<Transaction> transactions = new List<Transaction>();

            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT transaction_id, category_id, amount, transaction_date, description, created_at, updated_at FROM Transactions WHERE user_id = '"+user_id+"'";
                    if (category_id != -1)
                    {
                        query += " AND category_id = @category_id";

                    }
                    else if (!string.IsNullOrEmpty(type))
                    {
                        string categoryQuery = "SELECT * FROM Categories WHERE type = @type";


                        using (SqlCommand cmd = new SqlCommand(categoryQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@type", type);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                List<string> conditions = new List<string>();

                                while (reader.Read())
                                {
                                    conditions.Add("category_id = " + reader.GetInt32(0));
                                }

                                if (conditions.Count > 0)
                                {
                                    query += " AND (" + string.Join(" OR ", conditions) + ")";
                                }

                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(startdate) && !string.IsNullOrEmpty(enddate))
                    {
                        query += " AND transaction_date >= @startdate AND transaction_date <= @enddate";
                        
                    }
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (category_id != -1)
                        {
                            cmd.Parameters.AddWithValue("@category_id", category_id);
                        }
                        if (!string.IsNullOrEmpty(startdate) && !string.IsNullOrEmpty(enddate))
                        {
                            cmd.Parameters.AddWithValue("@startdate", startdate);
                            cmd.Parameters.AddWithValue("@enddate", enddate);

                        }
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                transactions.Add(new Transaction
                                {
                                    Id = reader.GetInt32(0),
                                    UserId = user_id,
                                    CategoryId = reader.GetInt32(1),
                                    Amount = reader.GetDecimal(2),
                                    TransactionDate = reader.GetDateTime(3),
                                    Description = reader.GetString(4),
                                    CreatedAt = reader.GetDateTime(5),
                                    UpdatedAt = reader.GetDateTime(6),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return transactions;
        }

        // Xoá transaction
        public static bool DeleteTransaction(Transaction transaction)
        {
            try
            {

                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    const string deleteQuery = "DELETE FROM Transactions WHERE transaction_id = @transaction_id";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.Add("@transaction_id", SqlDbType.Int).Value = transaction.Id;

                        return deleteCmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Cập nhật transaction
        public static bool UpdateTransaction(Transaction transaction)
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();

                const string query = "UPDATE Transactions SET category_id = @Category_id, amount = @Amount, transaction_date = @Transaction_date, Description = @Description, updated_at = @Updated_at WHERE transaction_id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", transaction.Id);
                    cmd.Parameters.AddWithValue("@Category_id", transaction.CategoryId);
                    cmd.Parameters.AddWithValue("@Amount", transaction.Amount);
                    cmd.Parameters.AddWithValue("@Transaction_date", transaction.TransactionDate);
                    cmd.Parameters.AddWithValue("@Description", transaction.Description);
                    cmd.Parameters.AddWithValue("@Updated_at", DateTime.Now);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Tính tổng tiền các transaction
        public static decimal GetSumAmount(List<Transaction> transactions)
        {
            decimal sumAmount = 0;
            foreach (Transaction transaction in transactions)
            {
                sumAmount += transaction.Amount;
            }
            return sumAmount;
        }

        // Lấy kết quả tính lời lãi trong tháng
        public static List<decimal> GetDifferenceMonth(int user_id, DateTime month, DateTime year)
        {
            List <decimal> res = new List<decimal>();
            DateTime startDate = new DateTime(year.Year, month.Month, 1);
            DateTime endDate = new DateTime(year.Year, month.Month, DateTime.DaysInMonth(year.Year,month.Month));
            List<Transaction> transactionsIncome = GetAllTransactions(user_id,startDate.ToString(),endDate.ToString(),-1,"Income");
            List<Transaction> transactionsExpense = GetAllTransactions(user_id, startDate.ToString(), endDate.ToString(), -1, "Expense");
            decimal sumIncome = GetSumAmount(transactionsIncome);
            decimal sumExpense = GetSumAmount(transactionsExpense);
            MessageBox.Show("Start: " + startDate + " End: " + endDate);
            res.Add(sumIncome);
            res.Add(sumExpense);
            return res;
        }
    }


}
