using Microsoft.AspNetCore.Mvc;

namespace TaskBoard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] object request)
        {
            return Created();
        }
    }
}
