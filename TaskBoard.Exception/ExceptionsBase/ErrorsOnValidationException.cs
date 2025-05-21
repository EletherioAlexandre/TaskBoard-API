using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskBoard.Exception.ExceptionsBase
{
    public class ErrorsOnValidationException : TaskException
    {
        public List<ApplicationErrorFields> Errors { get; set; }

        public ErrorsOnValidationException(List<ApplicationErrorFields> errors) : base("There were validation errors on application layer.")
        {
            Errors = errors;
        }
    }
}
