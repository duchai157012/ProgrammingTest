using Microsoft.AspNetCore.Mvc;
using ProgrammingTest.Application.Interfaces;
using System.Threading.Tasks;

namespace ProgrammingTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationClient _notificationClient;

        public NotificationController(INotificationClient notificationClient)
        {
            _notificationClient = notificationClient;
        }

        [HttpGet("send-random")]
        public async Task<IActionResult> SendRandom()
        {
            var result = await _notificationClient.SendRandomNotificationAsync();
            return Ok(new { response = result });
        }
    }
}
