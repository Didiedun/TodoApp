using MediatR;
using TodoApp.Core.Interfaces;

namespace TodoApp.Application.Features.Todos.Commands
{
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, bool>
    {
        private readonly ITodoRepository _todoRepository;

        public UpdateTodoCommandHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<bool> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await _todoRepository.GetByIdAsync(request.Id);
            
            if (todo == null)
            {
                throw new KeyNotFoundException($"Todo with ID {request.Id} not found");
            }
            
            todo.Title = request.Title;
            todo.Description = request.Description;
            
            // Check if we're completing the todo
            if (!todo.IsCompleted && request.IsCompleted)
            {
                todo.CompletedAt = DateTime.UtcNow;
            }
            else if (todo.IsCompleted && !request.IsCompleted)
            {
                todo.CompletedAt = null;
            }
            
            todo.IsCompleted = request.IsCompleted;
            
            await _todoRepository.UpdateAsync(todo);
            
            return true;
        }
    }
}