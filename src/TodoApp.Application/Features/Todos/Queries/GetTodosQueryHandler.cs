using MediatR;
using TodoApp.Application.DTOs;
using TodoApp.Core.Interfaces;

namespace TodoApp.Application.Features.Todos.Queries
{
    public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, IEnumerable<TodoDto>>
    {
        private readonly ITodoRepository _todoRepository;

        public GetTodosQueryHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<TodoDto>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            var todos = await _todoRepository.GetAllAsync();
            
            return todos.Select(todo => new TodoDto
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                IsCompleted = todo.IsCompleted,
                CreatedAt = todo.CreatedAt,
                CompletedAt = todo.CompletedAt
            });
        }
    }
}