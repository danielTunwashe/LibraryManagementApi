using LibraryMgtApiApplication.Dto;
using MediatR;

namespace LibraryMgtApiApplication.UxarProfile.Queries.GetUsersProfileById
{
    public class GetUserProfileByIdQuery : IRequest<UserProfileResponseDto>
    {
        public GetUserProfileByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
