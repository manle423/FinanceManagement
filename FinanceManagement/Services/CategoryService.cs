using FinanceManagement.Data;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using FinanceManagement.Models;
using System.Collections.Generic;

namespace FinanceManagement.Services
{
    internal class CategoryService
    {
        public CategoryService() { }

        public static bool AddCategory(string name, string type, string description)
        {
            try
            {
                if (IsCategoryExist(name))
                {
                    throw new Exception("Category is exists!!!");
                }

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

        public static bool IsCategoryExist(string name)
        {
            try
            {
                DatabaseConnection dbConnection = new DatabaseConnection();
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    // Query to check if the username exists
                    string query = "SELECT COUNT(*) FROM Categories WHERE Name = @Name";

                    // Creating SQL command
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Adding parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@Name", name);

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

        public static List<Category> GetAllCategories(string type = null)
        {
            List<Category> categories = new List<Category>();

            try
            {
                DatabaseConnection dbConnection = new DatabaseConnection();
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    // SQL query to get categories, with optional filtering by type
                    string query = "SELECT * FROM Categories";
                    if (!string.IsNullOrEmpty(type))
                    {
                        query += " WHERE Type = @Type";
                    }

                    // Creating SQL command
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(type))
                        {
                            // Adding parameter to prevent SQL injection
                            cmd.Parameters.AddWithValue("@Type", type);
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Create a Category object from the data
                                Category category = new Category
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Type = reader.GetString(2),
                                    Description = reader.GetString(3),
                                    CreatedAt = reader.GetDateTime(4),
                                    UpdatedAt = reader.GetDateTime(5),
                                };

                                // Add the Category object to the list
                                categories.Add(category);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return categories;
        }

    }
}
