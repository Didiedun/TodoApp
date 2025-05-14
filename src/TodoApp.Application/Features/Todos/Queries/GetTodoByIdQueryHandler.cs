using MediatR;
using TodoApp.Application.DTOs;
using TodoApp.Core.Interfaces;

namespace TodoApp.Application.Features.Todos.Queries
{
    public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, TodoDto>
    {
        private readonly ITodoRepository _todoRepository;

        public GetTodoByIdQueryHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<TodoDto> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            var todo = await _todoRepository.GetByIdAsync(request.Id);
            
            if (todo == null)
            {
                throw new KeyNotFoundException($"Todo with ID {request.Id} not found");
            }
            
            return new TodoDto
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                IsCompleted = todo.IsCompleted,
                CreatedAt = todo.CreatedAt,
                CompletedAt = todo.CompletedAt
            };
        }
    }
}
