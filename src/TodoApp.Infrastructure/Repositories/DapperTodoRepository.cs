using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using TodoApp.Core.Entities;
using TodoApp.Core.Interfaces;
using TodoApp.Infrastructure.Persistence;

namespace TodoApp.Infrastructure.Repositories
{
    public class DapperTodoRepository : ITodoRepository
    {
        private readonly DatabaseConnectionFactory _connectionFactory;

        public DapperTodoRepository(DatabaseConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryAsync<Todo>("SELECT * FROM Todos");
        }

        public async Task<Todo?> GetByIdAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Todo>(
                "SELECT * FROM Todos WHERE Id = @Id", 
                new { Id = id });
        }

        public async Task<Todo> AddAsync(Todo todo)
        {
            const string sql = @"
                INSERT INTO Todos (Title, Description, IsCompleted, CreatedAt, CompletedAt) 
                VALUES (@Title, @Description, @IsCompleted, @CreatedAt, @CompletedAt);
                SELECT last_insert_rowid();";
            
            using var connection = _connectionFactory.CreateConnection();
            var id = await connection.ExecuteScalarAsync<int>(sql, todo);
            todo.Id = id;
            return todo;
        }

        public async Task UpdateAsync(Todo todo)
        {
            const string sql = @"
                UPDATE Todos 
                SET Title = @Title, 
                    Description = @Description, 
                    IsCompleted = @IsCompleted, 
                    CompletedAt = @CompletedAt
                WHERE Id = @Id";
            
            using var connection = _connectionFactory.CreateConnection();
            await connection.ExecuteAsync(sql, todo);
        }

        public async Task DeleteAsync(int id)
        {
            const string sql = "DELETE FROM Todos WHERE Id = @Id";
            
            using var connection = _connectionFactory.CreateConnection();
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}