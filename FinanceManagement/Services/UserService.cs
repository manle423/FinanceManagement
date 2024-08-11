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
        public UserService() { }

        public static bool RegisterUser(string username, string email, string password)
        {
            try
            {
                if (IsUsernameExists(username))
                {
                    throw new Exception("Username is exists please use another username");
                }
                if (IsEmailExists(email))
                {
                    throw new Exception("Email is exists please use another email");
                }

                //Hash the password
                string hashedPassword = HashingHelper.HashPassword(password);

                // Using the DatabaseConnection class to get the connection
                DatabaseConnection dbConnection = new DatabaseConnection();
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    // SQL query to insert the new user
                    string query = "INSERT INTO Users (Username, Email, Password) VALUES (@Username, @Email, @Password)";

                    // Creating SQL command
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Adding parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword); // Use hashed password

                        // Execute the query
                        int result = cmd.ExecuteNonQuery();

                        // If the insertion was successful, result will be greater than 0
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool ValidateUser(string username, string password)
        {
            try
            {
                DatabaseConnection dbConnection = new DatabaseConnection();
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    // SQL query to get the hashed password for the given username
                    string query = "SELECT Password FROM Users WHERE Username = @Username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        // Retrieve the hashed password from the database
                        string storedHash = cmd.ExecuteScalar() as string;

                        // Verify the input password against the stored hash
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

        public static bool IsUsernameExists(string username)
        {
            try
            {
                DatabaseConnection dbConnection = new DatabaseConnection();
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    // Query to check if the username exists
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";

                    // Creating SQL command
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Adding parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@Username", username);

                        // Execute the query and get the result
                        int count = (int)cmd.ExecuteScalar();

                        // Return true if count is greater than 0
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool IsEmailExists(string email)
        {
            try
            {
                DatabaseConnection dbConnection = new DatabaseConnection();
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    // Query to check if the email exists
                    string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";

                    // Creating SQL command
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Adding parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@Email", email);

                        // Execute the query and get the result
                        int count = (int)cmd.ExecuteScalar();

                        // Return true if count is greater than 0
                        return count > 0;
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
