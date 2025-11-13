using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammingTest.Application.Commands.Auth;
using ProgrammingTest.Application.Queries.DateAchievement;
using ProgrammingTest.Domain.Enums;

namespace ProgrammingTest.API.Controllers
{
    [Authorize]
    public class BodyRecordController : Controller
    {
        private readonly IMediator _mediator;

        public BodyRecordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("api/body-fat-percentage")]
        public async Task<IActionResult> GetBodyFatPercentage([FromQuery] BodyRecordGroupByType type)
        {
            BodyFatPercentageQuery query = new BodyFatPercentageQuery(type);
            var dateAchievement = await _mediator.Send(query);
            return Ok(dateAchievement);
        }
    }
}
