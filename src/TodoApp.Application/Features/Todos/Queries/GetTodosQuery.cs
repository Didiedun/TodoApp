using MediatR;
using TodoApp.Application.DTOs;

namespace TodoApp.Application.Features.Todos.Queries
{
    public class GetTodosQuery : IRequest<IEnumerable<TodoDto>>
    {
    }
}