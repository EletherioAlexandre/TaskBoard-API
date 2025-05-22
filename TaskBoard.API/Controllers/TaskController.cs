using Microsoft.AspNetCore.Mvc;
using TaskBoard.Application.UseCases.Task.Create;
using TaskBoard.Communication.Requests;
using TaskBoard.Communication.Responses;

namespace TaskBoard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly CreateTaskUseCase _useCase;

        public TaskController(CreateTaskUseCase useCase)
        {
            _useCase = useCase;
        }
        [HttpPost]
        public IActionResult Create([FromBody] RequestCreateTaskJson request)
        {
            ResponseCreateTaskJson response = _useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
