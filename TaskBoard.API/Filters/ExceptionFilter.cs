using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TaskBoard.Communication.Responses;
using TaskBoard.Domain.Exceptions;
using TaskBoard.Exception.ExceptionsBase;

namespace TaskBoard.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            switch (context.Exception)
            {
                case ErrorsOnValidationException ex:
                    var errors = ex.Errors.Select(e => new ErrorField
                     {
                         Field = e.Field,
                         Message = e.Message,
                     }).ToList();

                    HandleErrors(errorsList: errors, context: context, message: "There were errors on application layer.");

                    break;

                case InvalidBoardTask ex:
                    errors = ex.Errors.Select(e => new ErrorField
                    {
                        Field = e.Field,
                        Message = e.Message,
                    }).ToList();

                    HandleErrors(errorsList: errors, context: context, message: "There were errors on domain layer.");

                    break;

                default:
                    var errorResponse = new ResponseErrorJson("An unexpected error occurred. Try again later.");
                    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Result = new ObjectResult(errorResponse);
                    break;
            }
        }

        private void HandleErrors(List<ErrorField> errorsList, ExceptionContext context, string message)
        {
            var errorsResponseJson = new ResponseErrorJson(errorsList, message);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(errorsResponseJson);
        }
    }
}
