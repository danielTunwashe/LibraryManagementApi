
using MediatR;

namespace LibraryMgtApiApplication.UxarProfile.Queries.DeleteUserProfile
{
    public class DeleteUserProfileQuery : IRequest
    {

        public DeleteUserProfileQuery(int id)
        {
            Id = id;
        }

        public int Id { get;}
    }
}
