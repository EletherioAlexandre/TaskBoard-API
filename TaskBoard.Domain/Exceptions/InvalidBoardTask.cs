namespace TaskBoard.Domain.Exceptions
{
    public class InvalidBoardTask : System.Exception
    {
        public List<ErrorDomainField> Errors { get; set; }

        public InvalidBoardTask(List<ErrorDomainField> errors) : base("There were validation errors on the BoardTask entity.")
        {
            Errors = errors;
        }
    }
}
