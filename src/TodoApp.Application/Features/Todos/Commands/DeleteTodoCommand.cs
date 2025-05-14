using MediatR;

namespace TodoApp.Application.Features.Todos.Commands
{
    public class DeleteTodoCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}