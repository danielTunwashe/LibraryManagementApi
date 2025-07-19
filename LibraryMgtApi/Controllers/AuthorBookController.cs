using LibraryMgtApiApplication.AuthorBooks.Commands.CreateNewBookForAuthor;
using LibraryMgtApiApplication.AuthorBooks.Commands.UpdateBookByIdForAuthor;
using LibraryMgtApiApplication.AuthorBooks.Queries.DeleteBookByIdForAuthor;
using LibraryMgtApiApplication.AuthorBooks.Queries.GetBookByIdForAuthor;
using LibraryMgtApiApplication.Books.Queries.GetAllBooksForAuthor;
using LibraryMgtApiApplication.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMgtApi.Controllers
{
    [Route("api/author/{authorId}/books")]
    [ApiController]
    public class AuthorBookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorBookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateNewBookForAuthor")]
        public async Task<ActionResult<CreateNewBookForAuthorResponseDto>> CreateNewBookForAuthor([FromRoute] int authorId, [FromBody] CreateNewBookForAuthorCommand command)
        {
            command.AuthorId = authorId;    
            var book = await _mediator.Send(command);
            return Ok(book);
        }


        [HttpGet("GetAllBooksForAuthor")]
        public async Task<ActionResult<IEnumerable<CreateNewBookForAuthorResponseDto>>> GetAllBooksForAuthor([FromRoute] int authorId)
        {
            var booksForAuthor = await _mediator.Send(new GetAllBooksForAuthorQuery(authorId));
            return Ok(booksForAuthor);
        }


        [HttpPut("UpdateBookByIdForAuthor/{id}")]
        public async Task<IActionResult> UpdateBookByIdForAuthor([FromRoute] int id, [FromRoute] int authorId, UpdateBookByIdForAuthorCommand command)
        {
            command.AuthorId = authorId;
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }


        [HttpGet("GetBookByIdForAuthor/{id}")]
        public async Task<ActionResult<GetBookByIdForAuthorResponseDto>> GetBookByIdForAuthor([FromRoute] int id, [FromRoute] int authorId)
        {
            var book = await _mediator.Send(new GetBookByIdForAuthorQuery(id,authorId)); 
            return Ok(book);
        }


        [HttpDelete("DeleteBookByIdForAuthor/{id}")]
        public async Task<IActionResult> DeleteBookByIdForAuthor([FromRoute] int id, [FromRoute] int authorId)
        {
            await _mediator.Send(new DeleteBookByIdForAuthorQuery(id, authorId));
            return NoContent();
        }

    }
}
