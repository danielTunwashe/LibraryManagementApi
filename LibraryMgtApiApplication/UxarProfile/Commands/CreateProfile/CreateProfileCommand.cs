using LibraryMgtApiApplication.Dto;
using MediatR;

namespace LibraryMgtApiApplication.UxarProfile.Commands.CreateProfile
{
    public class CreateProfileCommand : IRequest<CreateProfileResponseDto>
    {
        public string Bio { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public int UserId { get; set; }
    }
}
