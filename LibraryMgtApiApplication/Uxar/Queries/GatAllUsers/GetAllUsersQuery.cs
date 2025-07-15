using LibraryMgtApiApplication.Dto;
using MediatR;

namespace LibraryMgtApiApplication.Uxar.Queries.GatAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<CreateUserResponseDto>>
    {

    }
}
