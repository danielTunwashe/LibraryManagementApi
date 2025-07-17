using LibraryMgtApiApplication.Authors.Commands.CreateAuthor;
using LibraryMgtApiApplication.Authors.Queries.GetAllAuthors;
using LibraryMgtApiApplication.Authors.Queries.GetAuthorById;
using LibraryMgtApiApplication.Authors.Queries.UpdateAuthor;
using LibraryMgtApiApplication.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMgtApi.Controllers
{
    [Route("api/Author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("CreateAuthor")]
        public async Task<ActionResult<CreateAuthorResponseDto>> CreateAuthor([FromBody] CreateAuthorCommand command)
        {
            var createdAuthor = await _mediator.Send(command);
            return Ok(createdAuthor);
        }


        [HttpGet("GetAllAuthors")]
        public async Task<ActionResult<IEnumerable<GetAllAuthorsResponseDto>>> GetAllAuthors()
        {
            var authors = await _mediator.Send(new GetAllAuthorsQuery());
            return Ok(authors);
        }

        [HttpGet("GetAuthorById/{id}")]
        public async Task<ActionResult<GetAuthorByIdResponseDto>> GetAuthorById([FromRoute] int id)
        {
            var author = await _mediator.Send(new GetAuthorByIdQuery(id));
            return Ok(author);
        }

        [HttpPut("UpdateAuthorById/{id}")]
        public async Task<ActionResult<CreateAuthorResponseDto>> UpdateAuthor([FromRoute] int id, UpdateAuthorCommand command)
        {
            command.Id = id;
            var author = await _mediator.Send(command);
            return Ok(author);
        }

    }
}
