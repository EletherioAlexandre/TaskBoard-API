namespace TaskBoard.Communication.Responses
{
    public class ResponseErrorJson
    {
        public string Message { get; set; } = string.Empty;
        public List<ErrorField>? Errors { get; set; }

        public ResponseErrorJson(List<ErrorField> errors, string message)
        {
            Message = message;
            Errors = errors;
        }

        public ResponseErrorJson(string message)
        {
            Message = message;
        }
    }
}
