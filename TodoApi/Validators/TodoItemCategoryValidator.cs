using FluentValidation;
using TodoApi.Entities;

namespace TodoApi.Validators;

public class TodoItemCategoryValidator : AbstractValidator<TodoItemCategory>
{
    public TodoItemCategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(20).WithMessage("Name cannot exceed 20 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Descriiption is required.")
            .MaximumLength(100).WithMessage("Title cannot exceed 500 characters.");
    }
}
