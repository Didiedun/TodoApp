using MediatR;
using TodoApp.Core.Interfaces;

namespace TodoApp.Application.Features.Todos.Commands
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, bool>
    {
        private readonly ITodoRepository _todoRepository;

        public DeleteTodoCommandHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<bool> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await _todoRepository.GetByIdAsync(request.Id);
            
            if (todo == null)
            {
                throw new KeyNotFoundException($"Todo with ID {request.Id} not found");
            }
            
            await _todoRepository.DeleteAsync(request.Id);
            
            return true;
        }
    }
}