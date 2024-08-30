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
    internal class CategoryService
    {
        // khai báo 1 lần dbConnection cho dễ dàng sử dụng
        private static readonly DatabaseConnection dbConnection = new DatabaseConnection();

        // Hàm thêm category
        public static bool AddCategory(string name, string type, string description)
        {
            try
            {
                if (IsCategoryExist(name))
                {
                    throw new Exception("Category already exists!");
                }

                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    const string query = "INSERT INTO Categories (Name, Type, Description) VALUES (@Name, @Type, @Description)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Type", type);
                        cmd.Parameters.AddWithValue("@Name", name);
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

        // Kiểm tra liệu category đã tồn tại hay chưa
        public static bool IsCategoryExist(string name)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    const string query = "SELECT COUNT(*) FROM Categories WHERE Name = @Name";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);

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

        // Lấy ra tất cả category
        public static List<Category> GetAllCategories(string type = null)
        {
            List<Category> categories = new List<Category>();

            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM Categories";
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
                                categories.Add(new Category
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Type = StringHelper.CapitalizeFirstLetter(reader.GetString(2)),
                                    Description = reader.GetString(3),
                                    CreatedAt = reader.GetDateTime(4),
                                    UpdatedAt = reader.GetDateTime(5),
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

            return categories;
        }

        // Xoá category
        public static bool DeleteCategory(int id)
        {
            try
            {
                if (IsCategoryReferenced(id))
                {
                    throw new Exception("Category is related to other tables!");
                }

                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    const string deleteQuery = "DELETE FROM Categories WHERE Category_id = @CategoryId";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = id;

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

        // Kiểm tra khoá ngoại
        public static bool IsCategoryReferenced(int id)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    const string checkQuery = @"
                        SELECT COUNT(*) FROM 
                        (
                            SELECT Category_id FROM Transactions WHERE Category_id = @CategoryId
                            UNION ALL
                            SELECT Category_id FROM Budgets WHERE Category_id = @CategoryId
                            UNION ALL
                            SELECT Category_id FROM Recurring_Transactions WHERE Category_id = @CategoryId
                        ) AS RefCategories";

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = id;
                        return (int)checkCmd.ExecuteScalar() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Cập nhật category
        public static bool UpdateCategory(int id, string name, string type, string description)
        {
            try
            {
                if (IsDuplicateCategoryName(id, name))
                {
                    throw new Exception("Category name already exists for another category!");
                }

                return ExecuteUpdateCategory(id, name, type, description);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Kiểm tra xem category đã tồn tại tên này ngoài nó hay chưa
        private static bool IsDuplicateCategoryName(int id, string name)
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();

                const string checkQuery = "SELECT COUNT(*) FROM Categories WHERE Name = @Name AND Category_id != @Id";

                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Name", name);
                    checkCmd.Parameters.AddWithValue("@Id", id);

                    return (int)checkCmd.ExecuteScalar() > 0;
                }
            }
        }

        // Thực hiện cập nhật
        private static bool ExecuteUpdateCategory(int id, string name, string type, string description)
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();

                const string query = "UPDATE Categories SET Name = @Name, Type = @Type, Description = @Description WHERE Category_id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Type", type);
                    cmd.Parameters.AddWithValue("@Description", description);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Lấy tên của category khi có id (sử dụng khi hiển thị trong các bảng có khóa ngoại) 
        public static string GetCategoryName(int id)
        {
            string result = "";
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();
                const string query = "SELECT name FROM Categories WHERE category_id = @category_id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@category_id", id);
                    object categoryName = command.ExecuteScalar();
                    if (categoryName != null)
                    {
                        result = categoryName.ToString();
                    }
                    MessageBox.Show(result);
                }
            }
            return result;
        }

    }
}
