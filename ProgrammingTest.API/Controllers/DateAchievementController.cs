using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammingTest.Application.Commands.Auth;
using ProgrammingTest.Application.Queries.DateAchievement;

namespace ProgrammingTest.API.Controllers
{
    [Authorize]
    public class DateAchievementController : Controller
    {
        private readonly IMediator _mediator;

        public DateAchievementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("api/date-achievement")]
        public async Task<IActionResult> GetDateAchievement([FromQuery] DateAchievementQuery query)
        {
            var dateAchievement = await _mediator.Send(query);
            return Ok(dateAchievement);
        }
    }
}
