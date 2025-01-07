using FluentValidation;
using TodoApi.Entities;
using TodoApi.Interfaces.Services;

namespace TodoApi.Validators;

public class TodoItemValidator : AbstractValidator<TodoItem>
{

    public TodoItemValidator(ITodoItemCategoryService categoryService)
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Descriiption is required.")
            .MaximumLength(100).WithMessage("Title cannot exceed 500 characters.");

        RuleFor(x => x.Priority)
            .IsInEnum();

        RuleFor(x => x.Status)
            .IsInEnum();

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("CategoryId cannot be empty.")
            .MustAsync(async (id, cancellactionToken) => await categoryService.IsExistingCategory(id))
            .WithMessage("Category with the given CategoryId does not exist.");

        RuleFor(x => x.DueDate)
            .GreaterThanOrEqualTo(DateTimeOffset.UtcNow).WithMessage("Due date must be in the future.");
    }
}
