using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json.Linq;

namespace FinanceManagement.Data
{
    internal class DatabaseConnection
    {
        private readonly string _connectionString;

        // Constructor to initialize the connection string
        public DatabaseConnection()
        {
            //_connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            _connectionString = GetConnectionString();
        }

        // Method to get the SQL connection
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public static string GetConnectionString()
        {
            var json = File.ReadAllText("../../config.json");
            var config = JObject.Parse(json);
            return config["ConnectionStrings"]["DefaultConnection"].ToString();
        }
    }
}
