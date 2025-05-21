using System;

namespace TaskBoard.Communication.Requests
{
    public class RequestCreateTaskJson
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public int Priority { get; set; }
    }
}
