namespace TaskBoard.Exception.ExceptionsBase
{
    public abstract class TaskBaseException : System.Exception
    {
        protected TaskBaseException(string message) : base(message) { } 
    }
}
