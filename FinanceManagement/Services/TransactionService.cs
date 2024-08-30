﻿using FinanceManagement.Data;
using FinanceManagement.Models;
using FinanceManagement.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceManagement.Services
{
    internal class TransactionService
    {
        // khai báo 1 lần dbConnection cho dễ dàng sử dụng
        private static readonly DatabaseConnection dbConnection = new DatabaseConnection();

        // Hàm thêm transaction
        public static bool AddTransaction(int userId, int categoryId, decimal amount, 
            DateTime transactionDate, string description)
        {
            try
            {

                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    const string query = "INSERT INTO Transactions (user_id, category_id, amount, transactionDate, description) " +
                        "VALUES (@User_id, @Category_id, @Amount, @TransactionDate, @Description)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@User_id", userId);
                        cmd.Parameters.AddWithValue("@Category_id", categoryId);
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@TransactionDate", transactionDate);
                        cmd.Parameters.AddWithValue("@Description", description);

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
                                    conditions.Add("category_id = " + reader.GetString(0));
                                }

                                if (conditions.Count > 0)
                                {
                                    query += " AND " + string.Join(" OR ", conditions);
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


    }


}
