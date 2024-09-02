using FinanceManagement.Data;
using FinanceManagement.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FinanceManagement.Services
{
    internal class UserService
    {
        // khai báo 1 lần dbConnection cho dễ dàng sử dụng
        private static readonly DatabaseConnection dbConnection = new DatabaseConnection();

        public UserService() { }

        // Đăng ký
        public static bool RegisterUser(string username, string email, string password)
        {
            try
            {
                if (IsUsernameExists(username))
                {
                    throw new Exception("Username already exists, please use another username");
                }
                if (IsEmailExists(email))
                {
                    throw new Exception("Email already exists, please use another email");
                }

                string hashedPassword = HashingHelper.HashPassword(password);

                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Users (Username, Email, Password) VALUES (@Username, @Email, @Password)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);

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

        // Xác thực người dùng
        public static bool ValidateUser(string username, string password)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Password FROM Users WHERE Username = @Username";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        string storedHash = cmd.ExecuteScalar() as string;

                        return HashingHelper.VerifyPassword(password, storedHash);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Lấy ID của người dùng
        public static int GetUserId(string username)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT user_id FROM Users WHERE Username = @Username";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        int userId = (int)cmd.ExecuteScalar();
                        return userId;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        // Kiểm tra xem username đã tồn tại chưa
        private static bool IsUsernameExists(string username)
        {
            return IsFieldExists("Username", username);
        }

        // Kiểm tra xem email đã tồn tại chưa
        private static bool IsEmailExists(string email)
        {
            return IsFieldExists("Email", email);
        }

        // Kiểm tra xem trường dữ liệu nào đó đã tồn tại chưa
        private static bool IsFieldExists(string fieldName, string value)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = $"SELECT COUNT(*) FROM Users WHERE {fieldName} = @{fieldName}";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue($"@{fieldName}", value);
                        return (int)cmd.ExecuteScalar() > 0;
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
