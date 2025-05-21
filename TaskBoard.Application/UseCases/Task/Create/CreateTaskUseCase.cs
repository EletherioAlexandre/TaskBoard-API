using FluentValidation;
using TaskBoard.Communication.Requests;
using TaskBoard.Communication.Responses;
using TaskBoard.Domain.Entities;
using TaskBoard.Domain.Enums;
using TaskBoard.Exception.ExceptionsBase;

namespace TaskBoard.Application.UseCases.Task.Create
{
    public class CreateTaskUseCase
    {
        private readonly IValidator<RequestCreateTaskJson> _validator;

        public CreateTaskUseCase(IValidator<RequestCreateTaskJson> validator)
        {
            _validator = validator;
        }
        public ResponseCreateTaskJson Execute(RequestCreateTaskJson request)
        {
            Validate(request);

            BoardTask Task = new BoardTask(request.Title, request.Description, (TaskPriority)request.Priority);

            return new ResponseCreateTaskJson
            {
                Id = Task.Id,
                Title = Task.Title,
            };
        }

        public void Validate(RequestCreateTaskJson request)
        {
            var result = _validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => new ApplicationErrorFields
                {
                    Field = e.PropertyName,
                    Message = e.ErrorMessage
                }).ToList();

                throw new ErrorsOnValidationException(errors);
            }
        }
    }
}
