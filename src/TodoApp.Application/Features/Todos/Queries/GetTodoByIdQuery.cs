using MediatR;
using TodoApp.Application.DTOs;

namespace TodoApp.Application.Features.Todos.Queries
{
    public class GetTodoByIdQuery : IRequest<TodoDto>
    {
        public int Id { get; set; }
    }
}