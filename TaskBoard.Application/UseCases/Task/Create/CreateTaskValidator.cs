using FluentValidation;
using TaskBoard.Communication.Requests;
using TaskBoard.Domain.Enums;

namespace TaskBoard.Application.UseCases.Task.Create
{
    public class CreateTaskValidator : AbstractValidator<RequestCreateTaskJson>
    {
        public CreateTaskValidator()
        {
            RuleFor(t => t.Title).NotEmpty().WithMessage("Title is required to create task.");
            RuleFor(t => t.Priority).Must(p => Enum.IsDefined(typeof(TaskPriority), p)).WithMessage("Invalid priority");
        }
    }
}
