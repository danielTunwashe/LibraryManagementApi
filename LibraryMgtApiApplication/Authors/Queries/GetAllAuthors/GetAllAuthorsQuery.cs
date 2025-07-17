
using LibraryMgtApiApplication.Dto;
using MediatR;

namespace LibraryMgtApiApplication.Authors.Queries.GetAllAuthors
{
    public class GetAllAuthorsQuery : IRequest<IEnumerable<GetAllAuthorsResponseDto>>
    {

    }
}
