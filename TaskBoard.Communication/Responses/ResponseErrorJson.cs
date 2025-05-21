namespace TaskBoard.Communication.Responses
{
    public class ResponseErrorJson
    {
        public List<ErrorField>? Errors { get; set; }

        public ResponseErrorJson(List<ErrorField> errors)
        {
            Errors = errors;
        }
    }
}
