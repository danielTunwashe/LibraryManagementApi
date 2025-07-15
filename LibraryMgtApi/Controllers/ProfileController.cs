using LibraryMgtApiApplication.UxarProfile.Commands.CreateProfile;
using LibraryMgtApiApplication.UxarProfile.Commands.UpdateProfile;
using LibraryMgtApiApplication.UxarProfile.Queries.GetAllUsersProfile;
using LibraryMgtApiApplication.UxarProfile.Queries.GetUsersProfileById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMgtApi.Controllers
{
    [Route("api/user/profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateProfileForUser([FromBody] CreateProfileCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpGet("GetAllUserProfile")]
        public async Task<ActionResult> GetAllUserProfile()
        {
            var profiles = await _mediator.Send(new GetAllUserProfileQuery());

            return Ok(profiles);
        }


        [HttpGet("GetUserProfileById/{id}")]
        public async Task<ActionResult> GetUserProfileById([FromRoute] int id)
        {
            var profile = await _mediator.Send(new GetUserProfileByIdQuery(id));
            return Ok(profile);
        }


        [HttpPut("UpdateUserProfile/{id}")]
        public async Task<IActionResult> UpdateUserProfile([FromRoute] int id, UpdateUserProfileCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }


    }
}
