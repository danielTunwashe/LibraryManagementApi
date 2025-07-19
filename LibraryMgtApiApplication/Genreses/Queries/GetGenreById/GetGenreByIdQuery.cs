
using LibraryMgtApiApplication.Dto;
using MediatR;

namespace LibraryMgtApiApplication.Genreses.Queries.GetGenreById
{
    public class GetGenreByIdQuery : IRequest<GenreResponseDto>
    {
        public GetGenreByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get;  }
    }
}
