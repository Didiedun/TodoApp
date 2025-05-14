using MediatR;
using TodoApp.Application.DTOs;

namespace TodoApp.Application.Features.Todos.Commands
{
    public class CreateTodoCommand : IRequest<TodoDto>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}