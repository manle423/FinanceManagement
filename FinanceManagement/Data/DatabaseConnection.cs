using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace FinanceManagement.Data
{
    internal class DatabaseConnection
    {
        private readonly string _connectionString;

        // Constructor to initialize the connection string
        public DatabaseConnection()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        // Method to get the SQL connection
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
