using FinanceManagement.Data;
using FinanceManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FinanceManagement.Services
{
    internal class RecurringTransactionService
    {
        private static readonly DatabaseConnection dbConnection = new DatabaseConnection();

        public static int AddRecurringTransaction(RecurringTransaction recurringTransaction)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    const string query = @"INSERT INTO recurring_transactions 
                        (user_id, category_id, amount, start_date, end_date, frequency, description) 
                        VALUES (@UserId, @CategoryId, @Amount, @StartDate, @EndDate, @Frequency, @Description);
                        SELECT SCOPE_IDENTITY();"; // Retrieve the ID of the newly inserted row

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", recurringTransaction.UserId);
                        cmd.Parameters.AddWithValue("@CategoryId", recurringTransaction.CategoryId);
                        cmd.Parameters.AddWithValue("@Amount", recurringTransaction.Amount);
                        cmd.Parameters.AddWithValue("@StartDate", recurringTransaction.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", recurringTransaction.EndDate);
                        cmd.Parameters.AddWithValue("@Frequency", recurringTransaction.Frequency.ToString());
                        cmd.Parameters.AddWithValue("@Description", recurringTransaction.Description);

                        // Get the ID
                        int newId = Convert.ToInt32(cmd.ExecuteScalar());
                        return newId;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public static void CreatePastTransactions(RecurringTransaction recurringTransaction)
        {
            DateTime startDate = recurringTransaction.StartDate;
            DateTime endDate = recurringTransaction.EndDate;
            int transactionCount = 1;

            // Chạy vòng lặp cho đến khi đạt đến ngày kết thúc
            while (startDate <= endDate)
            {
                // Tạo transaction mới cho mỗi tháng hoặc năm dựa trên tần suất
                Models.Transaction newTransaction = new Models.Transaction
                {
                    UserId = recurringTransaction.UserId,
                    CategoryId = recurringTransaction.CategoryId,
                    Amount = recurringTransaction.Amount,
                    TransactionDate = startDate,
                    Description = $"{recurringTransaction.Description} - Giao dịch định kỳ từ ngày {recurringTransaction.StartDate:dd/MM/yyyy}, lần {transactionCount}",
                    RecurringId = recurringTransaction.Id
                };

                // Thêm transaction vào cơ sở dữ liệu
                TransactionService.AddTransaction(newTransaction);

                // Tăng ngày bắt đầu lên một tháng hoặc một năm dựa trên tần suất
                switch (recurringTransaction.Frequency)
                {
                    case eFrequency.Monthly:
                        startDate = startDate.AddMonths(1);
                        break;
                    case eFrequency.Yearly:
                        startDate = startDate.AddYears(1);
                        break;
                }
                transactionCount++;
            }
        }

        public static List<RecurringTransaction> GetAllRecurringTransactions(int userId, int categoryId = -1, string type = null)
        {
            List<RecurringTransaction> recurringTransactions = new List<RecurringTransaction>();

            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT rt.recurring_id, rt.user_id, rt.category_id, c.name AS category_name, rt.amount, rt.start_date, rt.end_date, 
                                     rt.frequency, rt.description, rt.created_at, rt.updated_at, c.type
                                     FROM recurring_transactions rt
                                     JOIN Categories c ON rt.category_id = c.category_id
                                     WHERE rt.user_id = @UserId";

                    if (categoryId != -1)
                    {
                        query += " AND rt.category_id = @CategoryId";
                    }
                    if (!string.IsNullOrEmpty(type))
                    {
                        query += " AND c.type = @Type";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        if (categoryId != -1)
                        {
                            cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                        }
                        if (!string.IsNullOrEmpty(type))
                        {
                            cmd.Parameters.AddWithValue("@Type", type);
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                recurringTransactions.Add(new RecurringTransaction
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("recurring_id")),
                                    UserId = reader.GetInt32(reader.GetOrdinal("user_id")),
                                    CategoryId = reader.GetInt32(reader.GetOrdinal("category_id")),
                                    CategoryName = reader.GetString(reader.GetOrdinal("category_name")),
                                    Amount = reader.GetDecimal(reader.GetOrdinal("amount")),
                                    StartDate = reader.GetDateTime(reader.GetOrdinal("start_date")),
                                    EndDate = reader.GetDateTime(reader.GetOrdinal("end_date")),
                                    Frequency = (eFrequency)Enum.Parse(typeof(eFrequency), reader.GetString(reader.GetOrdinal("frequency"))),
                                    Description = reader.GetString(reader.GetOrdinal("description")),
                                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("created_at")),
                                    UpdatedAt = reader.GetDateTime(reader.GetOrdinal("updated_at"))
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

            return recurringTransactions;
        }

        public static bool UpdateRecurringTransaction(RecurringTransaction recurringTransaction)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    const string query = @"UPDATE recurring_transactions 
                SET category_id = @CategoryId, amount = @Amount, start_date = @StartDate, 
                end_date = @EndDate, frequency = @Frequency, description = @Description,
                updated_at = GETDATE()
                WHERE recurring_id = @Id AND user_id = @UserId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", recurringTransaction.Id);
                        cmd.Parameters.AddWithValue("@UserId", recurringTransaction.UserId);
                        cmd.Parameters.AddWithValue("@CategoryId", recurringTransaction.CategoryId);
                        cmd.Parameters.AddWithValue("@Amount", recurringTransaction.Amount);
                        cmd.Parameters.AddWithValue("@StartDate", recurringTransaction.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", recurringTransaction.EndDate);
                        cmd.Parameters.AddWithValue("@Frequency", recurringTransaction.Frequency.ToString());
                        cmd.Parameters.AddWithValue("@Description", recurringTransaction.Description);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Delete all existing transactions and recreate them
                            DeleteAllTransactions(recurringTransaction.Id);
                            CreatePastTransactions(recurringTransaction);
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool DeleteRecurringTransaction(int id, int userId)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    const string query = "DELETE FROM recurring_transactions WHERE recurring_id = @Id AND user_id = @UserId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@UserId", userId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static void HandleUpdatedTransactions(RecurringTransaction recurringTransaction)
        {
            DateTime originalStartDate = GetOriginalStartDate(recurringTransaction.Id);
            DateTime originalEndDate = GetOriginalEndDate(recurringTransaction.Id);
            DateTime newStartDate = recurringTransaction.StartDate;
            DateTime newEndDate = recurringTransaction.EndDate;
            decimal originalAmount = GetOriginalAmount(recurringTransaction.Id);
            decimal newAmount = recurringTransaction.Amount;

            if (newStartDate != originalStartDate)
            {
                // Case: Start date changed, delete all existing transactions and recreate them
                DeleteAllTransactions(recurringTransaction.Id);
                CreatePastTransactions(recurringTransaction);
            }
            else
            {
                if (newEndDate < originalEndDate)
                {
                    // Case: Reduce end date, delete excess transactions
                    DeleteExcessTransactions(recurringTransaction.Id, newEndDate);
                }
                else if (newEndDate > originalEndDate)
                {
                    // Case: Increase end date, create additional transactions
                    CreateAdditionalTransactions(recurringTransaction, originalEndDate);
                }
            }

            if (newAmount != originalAmount)
            {
                // Case: Amount changed, update all existing transactions
                UpdateTransactionAmounts(recurringTransaction.Id, newAmount);
            }
        }

        private static DateTime GetOriginalStartDate(int recurringId)
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();

                const string query = "SELECT start_date FROM recurring_transactions WHERE recurring_id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", recurringId);
                    return (DateTime)cmd.ExecuteScalar();
                }
            }
        }

        private static DateTime GetOriginalEndDate(int recurringId)
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();

                const string query = "SELECT end_date FROM recurring_transactions WHERE recurring_id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", recurringId);
                    return (DateTime)cmd.ExecuteScalar();
                }
            }
        }

        private static decimal GetOriginalAmount(int recurringId)
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();

                const string query = "SELECT amount FROM recurring_transactions WHERE recurring_id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", recurringId);
                    return (decimal)cmd.ExecuteScalar();
                }
            }
        }

        private static void DeleteAllTransactions(int recurringId)
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();

                const string query = "DELETE FROM transactions WHERE recurring_id = @RecurringId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RecurringId", recurringId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void DeleteExcessTransactions(int recurringId, DateTime newEndDate)
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();

                const string query = "d";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RecurringId", recurringId);
                    cmd.Parameters.AddWithValue("@NewEndDate", newEndDate);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void CreateAdditionalTransactions(RecurringTransaction recurringTransaction, DateTime originalEndDate)
        {
            DateTime startDate = originalEndDate.AddMonths(1); // Start from the next month after the original end date
            DateTime endDate = recurringTransaction.EndDate;
            int transactionCount = 1;

            while (startDate <= endDate)
            {
                Models.Transaction newTransaction = new Models.Transaction
                {
                    UserId = recurringTransaction.UserId,
                    CategoryId = recurringTransaction.CategoryId,
                    Amount = recurringTransaction.Amount,
                    TransactionDate = startDate,
                    Description = $"{recurringTransaction.Description} - Giao dịch định kỳ từ ngày {recurringTransaction.StartDate:dd/MM/yyyy}, lần {transactionCount}",
                    RecurringId = recurringTransaction.Id
                };

                TransactionService.AddTransaction(newTransaction);

                switch (recurringTransaction.Frequency)
                {
                    case eFrequency.Monthly:
                        startDate = startDate.AddMonths(1);
                        break;
                    case eFrequency.Yearly:
                        startDate = startDate.AddYears(1);
                        break;
                }
                transactionCount++;
            }
        }

        private static void UpdateTransactionAmounts(int recurringId, decimal newAmount)
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();

                const string query = "UPDATE transactions SET amount = @NewAmount WHERE recurring_id = @RecurringId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NewAmount", newAmount);
                    cmd.Parameters.AddWithValue("@RecurringId", recurringId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}