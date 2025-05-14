using MediatR;
using TodoApp.Application.DTOs;
using TodoApp.Core.Entities;
using TodoApp.Core.Interfaces;

namespace TodoApp.Application.Features.Todos.Commands
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, TodoDto>
    {
        private readonly ITodoRepository _todoRepository;

        public CreateTodoCommandHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<TodoDto> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = new Todo
            {
                Title = request.Title,
                Description = request.Description,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow
            };
            
            var createdTodo = await _todoRepository.AddAsync(todo);
            
            return new TodoDto
            {
                Id = createdTodo.Id,
                Title = createdTodo.Title,
                Description = createdTodo.Description,
                IsCompleted = createdTodo.IsCompleted,
                CreatedAt = createdTodo.CreatedAt,
                CompletedAt = createdTodo.CompletedAt
            };
        }
    }
}