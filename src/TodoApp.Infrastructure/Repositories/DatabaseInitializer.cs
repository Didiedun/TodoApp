using System.Data;
using Dapper;

namespace TodoApp.Infrastructure.Persistence
{
    public class DatabaseInitializer
    {
        private readonly DatabaseConnectionFactory _connectionFactory;

        public DatabaseInitializer(DatabaseConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Initialize()
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();
            
            // Create Todos table if it doesn't exist
            const string createTableSql = @"
                CREATE TABLE IF NOT EXISTS Todos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    Description TEXT,
                    IsCompleted INTEGER NOT NULL,
                    CreatedAt TEXT NOT NULL,
                    CompletedAt TEXT
                );";
            
            connection.Execute(createTableSql);
        }
    }
}