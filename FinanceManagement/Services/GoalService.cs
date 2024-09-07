using FinanceManagement.Data;
using FinanceManagement.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FinanceManagement.Services
{
    internal class GoalService
    {
        // khai báo 1 lần dbConnection cho dễ dàng sử dụng
        private static readonly DatabaseConnection dbConnection = new DatabaseConnection();

        // Hàm thêm goal
        public static bool AddGoal(Goal goal)
        {
            try
            {

                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    const string query = "INSERT INTO Goals (user_id, name, target_amount, current_amount, deadline, description) " +
                        "VALUES (@user_id, @name,@target_amount, @current_amount, @deadline, @Description)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue ("@user_id", goal.UserId);
                        cmd.Parameters.AddWithValue("@name", goal.Name);
                        cmd.Parameters.AddWithValue("@target_amount", goal.TargetAmount);
                        cmd.Parameters.AddWithValue("@current_amount", goal.CurrentAmount);
                        cmd.Parameters.AddWithValue("@deadline", goal.Deadline);
                        cmd.Parameters.AddWithValue("@description", goal.Description);

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

        // Xoá goal
        public static bool DeleteGoal(Goal goal)
        {
            try
            {

                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    const string deleteQuery = "DELETE FROM Goals WHERE goal_id = @goal_id";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.Add("@goal_id", SqlDbType.Int).Value = goal.Id;

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


        // Cập nhật goal
        public static bool UpdateGoal(Goal goal)
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();

                const string query = "UPDATE Goals SET name = @name, target_amount = @target_amount, current_amount = @current_amount, deadline = @deadline, description = @description, updated_at = @Updated_at WHERE goal_id = @goal_id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@goal_id", goal.Id);
                    cmd.Parameters.AddWithValue("@name", goal.Name);
                    cmd.Parameters.AddWithValue("@target_amount", goal.TargetAmount);
                    cmd.Parameters.AddWithValue("@current_amount", goal.CurrentAmount);
                    cmd.Parameters.AddWithValue("@deadline", goal.Deadline);
                    cmd.Parameters.AddWithValue("@description", goal.Description);
                    cmd.Parameters.AddWithValue("@Updated_at", DateTime.Now);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Lấy ra tất cả goal 
        public static List<Goal> GetAllGoals(int user_id, string startDate = null, string endDate = null, decimal startTargetAmount = Decimal.MinValue, decimal endTargetAmount = Decimal.MaxValue, decimal startCurrentAmount = Decimal.MinValue, decimal endCurrentAmount = Decimal.MaxValue)
        {
            List<Goal> goals = new List<Goal>();
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT goal_id, name, target_amount, current_amount, deadline, description, created_at, updated_at FROM Goals WHERE user_id = @user_id AND " +
                        "target_amount >= @startTargetAmount AND target_amount <= @endTargetAmount AND " +
                        "current_amount >= @startCurrentAmount AND current_amount <= @endCurrentAmount ";
                    if (!string.IsNullOrEmpty(startDate))
                    {
                        query += " AND deadline >= @startDate ";
                    }
                    if (!string.IsNullOrEmpty(endDate))
                    {
                        query += " AND deadline <= @endDate ";
                    }
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", user_id);
                        cmd.Parameters.AddWithValue("@startTargetAmount",startTargetAmount);
                        cmd.Parameters.AddWithValue("@endTargetAmount", endTargetAmount);
                        cmd.Parameters.AddWithValue("@startCurrentAmount", startCurrentAmount);
                        cmd.Parameters.AddWithValue("@endCurrentAmount", endCurrentAmount);
                        if (!string.IsNullOrEmpty(startDate))
                        {
                            cmd.Parameters.AddWithValue("@startDate", startDate);
                        }
                        if (!string.IsNullOrEmpty(endDate))
                        {
                            cmd.Parameters.AddWithValue("@endDate", endDate);
                        }

                        
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                goals.Add(new Goal
                                {
                                    Id = reader.GetInt32(0),
                                    UserId = user_id,
                                    Name = reader.GetString(1),
                                    TargetAmount = reader.GetDecimal(2),
                                    CurrentAmount = reader.GetDecimal(3),
                                    Deadline = reader.GetDateTime(4),
                                    Description = reader.GetString(5),
                                    CreatedAt = reader.GetDateTime(6),
                                    UpdatedAt = reader.GetDateTime(7)
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
            return goals;
        }

        // Lấy ra tất cả goal chưa hoàn thành
        public static List<Goal> GetAllGoalsUncompleted(int user_id, string startDate = null, string endDate = null, decimal startTargetAmount = Decimal.MinValue, decimal endTargetAmount = Decimal.MaxValue, decimal startCurrentAmount = Decimal.MinValue, decimal endCurrentAmount = Decimal.MaxValue)
        {
            List<Goal> goals = new List<Goal>();
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT goal_id, name, target_amount, current_amount, deadline, description, created_at, updated_at FROM Goals WHERE user_id = @user_id AND " +
                        "target_amount >= @startTargetAmount AND target_amount <= @endTargetAmount AND " +
                        "current_amount >= @startCurrentAmount AND current_amount <= @endCurrentAmount " +
                        "AND target_amount > current_amount"; // goal chưa hoàn thành

                    if (!string.IsNullOrEmpty(startDate))
                    {
                        query += " AND deadline >= @startDate ";
                    }
                    if (!string.IsNullOrEmpty(endDate))
                    {
                        query += " AND deadline <= @endDate ";
                    }
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", user_id);
                        cmd.Parameters.AddWithValue("@startTargetAmount", startTargetAmount);
                        cmd.Parameters.AddWithValue("@endTargetAmount", endTargetAmount);
                        cmd.Parameters.AddWithValue("@startCurrentAmount", startCurrentAmount);
                        cmd.Parameters.AddWithValue("@endCurrentAmount", endCurrentAmount);
                        if (!string.IsNullOrEmpty(startDate))
                        {
                            cmd.Parameters.AddWithValue("@startDate", startDate);
                        }
                        if (!string.IsNullOrEmpty(endDate))
                        {
                            cmd.Parameters.AddWithValue("@endDate", endDate);
                        }


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                goals.Add(new Goal
                                {
                                    Id = reader.GetInt32(0),
                                    UserId = user_id,
                                    Name = reader.GetString(1),
                                    TargetAmount = reader.GetDecimal(2),
                                    CurrentAmount = reader.GetDecimal(3),
                                    Deadline = reader.GetDateTime(4),
                                    Description = reader.GetString(5),
                                    CreatedAt = reader.GetDateTime(6),
                                    UpdatedAt = reader.GetDateTime(7)
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
            return goals;
        }

        // Lấy goal theo id
        public static Goal GetGoalById(int id)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    const string query = "SELECT * FROM Goals WHERE goal_id = @goal_id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@goal_id", SqlDbType.Int).Value =id;

                        using (SqlDataReader  reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return new Goal
                                {
                                    Id = reader.GetInt32(0),
                                    UserId = reader.GetInt32(1),
                                    Name = reader.GetString(2),
                                    TargetAmount = reader.GetDecimal(3),
                                    CurrentAmount = reader.GetDecimal(4),
                                    Deadline = reader.GetDateTime(5),
                                    Description = reader.GetString(6),
                                    CreatedAt = reader.GetDateTime(7),
                                    UpdatedAt = reader.GetDateTime(8)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return null;
        }

    }
}
