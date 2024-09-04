using FinanceManagement.Data;
using FinanceManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceManagement.Services
{
    internal class BudgetService
    {
        // khai báo 1 lần dbConnection cho dễ dàng sử dụng
        private static readonly DatabaseConnection dbConnection = new DatabaseConnection();
        // Hàm thêm budget
        public static bool AddBudget(
            int userId,
            int categoryId,
            double amount,
            DateTime startDate,
            DateTime endDate)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    const string query = "INSERT INTO Budgets (user_id, category_id, amount, start_date, end_date) VALUES (@UserId, @CategoryId, @Amount, @StartDate, @EndDate)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@StartDate", startDate);
                        cmd.Parameters.AddWithValue("@EndDate", endDate);

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

        // Hàm lấy toàn bộ dữ liệu của Budget
        public static List<Budget> GetAllBudgets(int userId, int? categoryId = null)
        {
            List<Budget> budgets = new List<Budget>();

            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT b.*, c.Name AS CategoryName
                        FROM Budgets b
                        INNER JOIN Categories c ON b.Category_Id = c.category_id
                        WHERE b.User_id = @UserId";

                    if (categoryId.HasValue)
                    {
                        query += " AND b.Category_Id = @CategoryId";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);

                        if (categoryId.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@CategoryId", categoryId.Value);
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                budgets.Add(new Budget
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Budget_id")),
                                    UserId = reader.GetInt32(reader.GetOrdinal("User_id")),
                                    CategoryId = reader.GetInt32(reader.GetOrdinal("Category_Id")),
                                    Amount = reader.GetDecimal(reader.GetOrdinal("Amount")),
                                    StartDate = reader.GetDateTime(reader.GetOrdinal("Start_date")),
                                    EndDate = reader.GetDateTime(reader.GetOrdinal("End_date")),
                                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("Created_at")),
                                    UpdatedAt = reader.GetDateTime(reader.GetOrdinal("Updated_at")),
                                    CategoryName = reader.GetString(reader.GetOrdinal("CategoryName"))
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

            return budgets;
        }

        public static List<Budget> GetAllBudgetsWithTrack(int userId, int? categoryId = null)
        {
            List<Budget> budgets = new List<Budget>();

            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            b.budget_id,
                            b.user_id,
                            b.category_id,
                            c.name AS category_name,
                            b.amount AS budgeted_amount,
                            b.start_date,
                            b.end_date,
                            b.created_at,
                            b.updated_at,
                            COALESCE(SUM(t.amount), 0) AS total_spent,
                            (b.amount - COALESCE(SUM(t.amount), 0)) AS remaining_budget,
                            ROUND((COALESCE(SUM(t.amount), 0) / b.amount) * 100, 2) AS budget_progress_percentage,
                            CASE 
                                WHEN COALESCE(SUM(t.amount), 0) >= b.amount THEN 'OVER BUDGET'
                                WHEN COALESCE(SUM(t.amount), 0) < b.amount THEN 'UNDER BUDGET'
                                ELSE 'ON TRACK'
                            END AS budget_status
                        FROM 
                            budgets b
                        LEFT JOIN 
                            transactions t ON b.category_id = t.category_id 
                            AND b.user_id = t.user_id
                            AND t.transaction_date BETWEEN b.start_date AND b.end_date
                        JOIN 
                            categories c ON b.category_id = c.category_id
                        WHERE b.user_id = @UserId";

                    if (categoryId.HasValue)
                    {
                        query += " AND b.category_id = @CategoryId";
                    }

                    query += " GROUP BY b.budget_id, b.user_id, b.category_id, c.name, b.amount, b.start_date, b.end_date, b.created_at, b.updated_at";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);

                        if (categoryId.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@CategoryId", categoryId.Value);
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                budgets.Add(new Budget
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("budget_id")),
                                    UserId = reader.GetInt32(reader.GetOrdinal("user_id")),
                                    CategoryId = reader.GetInt32(reader.GetOrdinal("category_id")),
                                    Amount = reader.GetDecimal(reader.GetOrdinal("budgeted_amount")),
                                    StartDate = reader.GetDateTime(reader.GetOrdinal("start_date")),
                                    EndDate = reader.GetDateTime(reader.GetOrdinal("end_date")),
                                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("created_at")),
                                    UpdatedAt = reader.GetDateTime(reader.GetOrdinal("updated_at")),
                                    CategoryName = reader.GetString(reader.GetOrdinal("category_name")),
                                    TotalSpent = reader.GetDecimal(reader.GetOrdinal("total_spent")),
                                    RemainingBudget = reader.GetDecimal(reader.GetOrdinal("remaining_budget")),
                                    BudgetProgressPercentage = reader.GetDecimal(reader.GetOrdinal("budget_progress_percentage")),
                                    BudgetStatus = reader.GetString(reader.GetOrdinal("budget_status"))
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

            return budgets;
        }

        // Hàm xoá budget
        public static bool DeleteBudget(Budget budget)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    const string deleteQuery = "DELETE FROM Budgets WHERE budget_id = @budget_id";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.Add("@budget_id", SqlDbType.Int).Value = budget.Id;

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

        // Hàm cập nhật budget
        public static bool UpdateBudget(Budget budget)
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();

                const string query = "UPDATE Budgets SET category_id = @Category_id, amount = @Amount, start_date = @Start_Date, end_date = @End_Date, updated_at = @Updated_at WHERE budget_id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", budget.Id);
                    cmd.Parameters.AddWithValue("@Category_id", budget.CategoryId);
                    cmd.Parameters.AddWithValue("@Amount", budget.Amount);
                    cmd.Parameters.AddWithValue("@Start_Date", budget.StartDate);
                    cmd.Parameters.AddWithValue("@End_date", budget.EndDate);
                    cmd.Parameters.AddWithValue("@Updated_at", DateTime.Now);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Hàm lấy budget
        public static Budget GetCurrentBudget(int userId, int categoryId, DateTime transactionDate)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            b.budget_id,
                            b.amount AS budgeted_amount,
                            COALESCE(SUM(t.amount), 0) AS total_spent
                        FROM 
                            budgets b
                        LEFT JOIN 
                            transactions t ON b.category_id = t.category_id 
                            AND b.user_id = t.user_id
                            AND t.transaction_date BETWEEN b.start_date AND b.end_date
                        WHERE 
                            b.user_id = @UserId
                            AND b.category_id = @CategoryId
                            AND @TransactionDate BETWEEN b.start_date AND b.end_date
                        GROUP BY 
                            b.budget_id, b.amount";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                        cmd.Parameters.AddWithValue("@TransactionDate", transactionDate);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Budget
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("budget_id")),
                                    Amount = reader.GetDecimal(reader.GetOrdinal("budgeted_amount")),
                                    TotalSpent = reader.GetDecimal(reader.GetOrdinal("total_spent"))
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
    }
}
