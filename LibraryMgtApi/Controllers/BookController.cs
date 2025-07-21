using LibraryMgtApiApplication.Books.Queries.filterBookByQueryParameters;
using LibraryMgtApiApplication.Books.Queries.GetAllListOfBooksForAuthor;
using LibraryMgtApiApplication.Books.Queries.GetListOfBooksBasedOnAuthorAndGenre;
using LibraryMgtApiApplication.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMgtApi.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("filterBookByQueryParameters")]
        public async Task<ActionResult<IEnumerable<filteredBookResponseDto>>> filterBookByQueryParameters([FromQuery] string? title, [FromQuery] string? authorName, [FromQuery] string? genreName)
        {
            var filteredBook = await _mediator.Send(new filterBookByQueryParametersQuery(title,authorName,genreName));
            return Ok(filteredBook);
        }


        [HttpGet("GetAllListOfBooksForAuthor")]
        public async Task<ActionResult<IEnumerable<GetAllListOfBooksForAuthorResponseDto>>> GetAllListOfBooksForAuthor([FromQuery] string authorName)
        {
            var authorListOfBooks = await _mediator.Send(new GetAllListOfBooksForAuthorQuery(authorName));
            return Ok(authorListOfBooks);
        }


        [HttpGet("GetListOfBooksBasedOnAuthorAndGenre")]
        public async Task<ActionResult<IEnumerable<GetAllListOfBooksForAuthorResponseDto>>> GetListOfBooksBasedOnAuthorAndGenre([FromQuery] string? authorName, [FromQuery] string? genreName)
        {
            var listOfBooks = await _mediator.Send(new GetListOfBooksBasedOnAuthorAndGenreQuery(authorName, genreName));
            return Ok(listOfBooks);
        }

    }
}
