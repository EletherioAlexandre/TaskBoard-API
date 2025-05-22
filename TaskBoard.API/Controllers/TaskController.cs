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
        [ProducesResponseType(typeof(ResponseCreateTaskJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] RequestCreateTaskJson request)
        {
            ResponseCreateTaskJson response = _useCase.Execute(request);

            return CreatedAtAction(nameof(GetById), new { id = response.Id },
            new ResponseCreateTaskJson
            {
                Id = response.Id,
                Title = response.Title,
            });
        }

        [HttpGet]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return Ok(id);
        }
    }
}
