
using LibraryMgtApiApplication.Dto;
using MediatR;

namespace LibraryMgtApiApplication.Uxar.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<GetUserByIdResponseDto>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get;}
    }
}
