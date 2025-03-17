using LearningApp.Application.Features.Subject.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly IMediator mediator;
        public SubjectController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateSubjectCommand command)
        {
            var subjectId = await mediator.Send(command);
            return Ok(new { id = subjectId });
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateSubjectCommand command)
        {
            var subjectId = await mediator.Send(command);
            return Ok(new { id = subjectId });
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteSubjectCommand command)
        {
            var subjectId = await mediator.Send(command);
            return Ok(new { id = subjectId });
        }
    }
}
