using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammingTest.Application.Commands.Auth;
using ProgrammingTest.Application.Commands.InputMeal;
using ProgrammingTest.Application.Queries.DateAchievement;
using ProgrammingTest.Application.Queries.ExerciseRecord;
using ProgrammingTest.Application.Queries.InputMeal;

namespace ProgrammingTest.API.Controllers
{
    [Authorize]
    public class ExercisesController : Controller
    {
        private readonly IMediator _mediator;

        public ExercisesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/input-exercises")]
        public async Task<IActionResult> InputExercises([FromBody] InputExerciseCommand command)
        {
            var guid = await _mediator.Send(command);
            return Ok(guid);
        }

        [HttpGet("api/exercises-record")]
        public async Task<IActionResult> GetExercisesRecord()
        {
            var query = new ExerciseRecordQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
