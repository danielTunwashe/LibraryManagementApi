using LibraryMgtApiApplication.AssignGenresToBook;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMgtApi.Controllers
{
    [Route("api/assign-genres")]
    [ApiController]
    public class BookGenreController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookGenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("assign-genres")]
        public async Task<IActionResult> AssignGenresToBook([FromBody] AssignGenresToBookCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
