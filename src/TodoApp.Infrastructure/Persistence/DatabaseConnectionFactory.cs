using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace TodoApp.Infrastructure.Persistence
{
    public class DatabaseConnectionFactory
    {
        private readonly string _connectionString;

        public DatabaseConnectionFactory(IConfiguration configuration)
        {
            // Fix: Add null check and provide default value if needed
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? 
                                "Data Source=todoapp.db";
        }

        public IDbConnection CreateConnection()
        {
            return new SqliteConnection(_connectionString);
        }
    }
}