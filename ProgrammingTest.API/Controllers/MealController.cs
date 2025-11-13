using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammingTest.Application.Commands.Auth;
using ProgrammingTest.Application.Commands.InputMeal;
using ProgrammingTest.Application.Queries.DateAchievement;
using ProgrammingTest.Application.Queries.InputMeal;

namespace ProgrammingTest.API.Controllers
{
    [Authorize]
    public class MealController : Controller
    {
        private readonly IMediator _mediator;

        public MealController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/input-meal")]
        public async Task<IActionResult> InputMeal([FromBody] InputMealCommand command)
        {
            var guid = await _mediator.Send(command);
            return Ok(guid);
        }

        [HttpGet("api/meal-history")]
        public async Task<IActionResult> GetMealHistory()
        {
            var query = new MealHistoryQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
