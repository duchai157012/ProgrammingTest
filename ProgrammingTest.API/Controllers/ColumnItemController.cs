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
    public class ColumnItemController : Controller
    {
        private readonly IMediator _mediator;

        public ColumnItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("api/input-column-item")]
        public async Task<IActionResult> InputMeal([FromBody] InputColumnItemCommand command)
        {
            var guid = await _mediator.Send(command);
            return Ok(guid);
        }

        [AllowAnonymous]
        [HttpGet("api/all-column-item")]
        public async Task<IActionResult> GetAllColumnItem()
        {
            var query = new AllColumnItemsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
