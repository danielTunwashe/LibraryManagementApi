using LibraryMgtApiApplication.Uxar.Commands.CreateUser;
using LibraryMgtApiApplication.Uxar.Commands.DeleteUser;
using LibraryMgtApiApplication.Uxar.Commands.UpdateUser;
using LibraryMgtApiApplication.Uxar.Queries.GatAllUsers;
using LibraryMgtApiApplication.Uxar.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMgtApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult> GrtUserById([FromRoute] int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(user);
        }


        [HttpGet("GetAllUsers")]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());

            return Ok(users);
        }


        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, UpdateUserCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id, DeleteUserCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
