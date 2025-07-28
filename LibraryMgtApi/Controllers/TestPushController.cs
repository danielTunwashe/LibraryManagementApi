using LibraryMgtApiDomain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMgtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestPushController : ControllerBase
    {
        private readonly INotificationRepository _notificationRepository;

        public TestPushController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        [HttpGet("ping")]
        public async Task<IActionResult> Ping()
        {
            await _notificationRepository.SendNotificationAsync("🚀 Test push from backend");
            return Ok("Push sent");
        }
    }
}
