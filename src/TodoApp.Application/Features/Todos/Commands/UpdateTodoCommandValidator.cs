using FluentValidation;

namespace TodoApp.Application.Features.Todos.Commands
{
    public class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand>
    {
        public UpdateTodoCommandValidator()
        {
            RuleFor(v => v.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters");
            
            RuleFor(v => v.Description)
                .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters");
        }
    }
}