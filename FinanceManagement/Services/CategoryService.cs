using FinanceManagement.Data;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FinanceManagement.Services
{
    internal class CategoryService
    {
        public CategoryService() { }

        public static bool AddCategory(string name, string type, string description)
        {
            try
            {
                DatabaseConnection dbConnection = new DatabaseConnection();
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    // SQL query to insert the new user
                    string query = "INSERT INTO Categories (Name, Type, Description) VALUES (@Name, @Type, @Description)";

                    // Creating SQL command
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Adding parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@Type", type);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Description", description);

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
    }
}
