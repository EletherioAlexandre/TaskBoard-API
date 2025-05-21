namespace TaskBoard.Exception.ExceptionsBase
{
    public abstract class TaskException : System.Exception
    {
        protected TaskException(string message) : base(message) { } 
    }
}
