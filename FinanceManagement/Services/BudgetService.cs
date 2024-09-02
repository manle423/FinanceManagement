using FinanceManagement.Data;
using FinanceManagement.Models;
using System;
using System.Collections.Generic;
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

    }
}
