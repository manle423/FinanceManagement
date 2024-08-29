using FinanceManagement.Data;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using FinanceManagement.Models;
using System.Collections.Generic;
using FinanceManagement.Utils;
using System.Data;

namespace FinanceManagement.Services
{

    // Hàm thêm category
    internal class RecurringTransactions
    {
        // khai báo 1 lần dbConnection cho dễ dàng sử dụng
        private static readonly DatabaseConnection dbConnection = new DatabaseConnection();
        public static List<Recurring> GetAllRecurring(string type = null)
        {
            List<Recurring> recurring = new List<Recurring>();

            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM Recurring";
                    if (!string.IsNullOrEmpty(type))
                    {
                        query += " WHERE Type = @Type";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(type))
                        {
                            cmd.Parameters.AddWithValue("@Type", type);
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                recurring.Add(new Recurring
                                {
                                    recurring_id = reader.GetInt32(0),
                                    user_id = reader.GetInt32(1),
                                    category_id = reader.GetInt32(2),
                                    amount = reader.GetDouble(3),
                                    start_date = reader.GetDateTime(4),
                                    end_date = reader.GetDateTime(5),
                                    frequency = reader.GetString(6),
                                    description = reader.GetString(7),
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

            return recurring;
        }


    }
}
