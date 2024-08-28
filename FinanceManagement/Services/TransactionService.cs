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

       
    }


}
