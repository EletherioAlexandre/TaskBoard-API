using FluentValidation;
using TaskBoard.Communication.Requests;

namespace TaskBoard.Application.UseCases.Task.Create
{
    public class CreateTaskValidator : AbstractValidator<RequestCreateTaskJson>
    {
        public CreateTaskValidator()
        {
            RuleFor(t => t.Title).NotEmpty().WithMessage("Title is required to create task.");
        }
    }
}
