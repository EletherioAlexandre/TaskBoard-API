namespace TaskBoard.Exception.ExceptionsBase
{
    public class ErrorsOnValidationException : TaskBaseException
    {
        public List<ApplicationErrorFields> Errors { get; set; }

        public ErrorsOnValidationException(List<ApplicationErrorFields> errors) : base("There were validation errors on application layer.")
        {
            Errors = errors;
        }
    }
}
