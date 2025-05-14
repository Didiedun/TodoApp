using MediatR;

namespace TodoApp.Application.Features.Todos.Commands
{
    public class UpdateTodoCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}