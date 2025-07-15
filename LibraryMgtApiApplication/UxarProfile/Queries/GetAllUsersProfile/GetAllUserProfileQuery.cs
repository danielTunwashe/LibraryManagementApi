using LibraryMgtApiApplication.Dto;
using LibraryMgtApiDomain.Entities;
using MediatR;

namespace LibraryMgtApiApplication.UxarProfile.Queries.GetAllUsersProfile
{
    public class GetAllUserProfileQuery : IRequest<IEnumerable<UserProfileResponseDto>>
    {

    }
}
