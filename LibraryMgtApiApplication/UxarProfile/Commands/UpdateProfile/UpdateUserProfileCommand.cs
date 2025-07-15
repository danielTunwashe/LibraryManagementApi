
using MediatR;

namespace LibraryMgtApiApplication.UxarProfile.Commands.UpdateProfile
{
    public class UpdateUserProfileCommand : IRequest
    {
        public int Id { get; set; }
        public string Bio { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public int UserId { get; set; }
    }

}
