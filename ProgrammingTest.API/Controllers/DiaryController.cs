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
    public class DiaryController : Controller
    {
        private readonly IMediator _mediator;

        public DiaryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/input-diary")]
        public async Task<IActionResult> InputExercises([FromBody] InputDiaryCommand command)
        {
            var guid = await _mediator.Send(command);
            return Ok(guid);
        }

        [HttpGet("api/diary-history")]
        public async Task<IActionResult> GetDiaryHistory()
        {
            var query = new DiaryHistoryQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
