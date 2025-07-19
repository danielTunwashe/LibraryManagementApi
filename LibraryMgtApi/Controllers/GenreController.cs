using LibraryMgtApiApplication.Dto;
using LibraryMgtApiApplication.Genreses.Queries.GetGenreById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMgtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetGenreById/{id}")]
        public async Task<ActionResult<GenreResponseDto>> GetGenreById([FromRoute] int id)
        {
            var genre = await _mediator.Send(new GetGenreByIdQuery(id));
            return Ok(genre);
        }

    }
}
