using LibraryMgtApiApplication.Dto;
using MediatR;

namespace LibraryMgtApiApplication.Uxar.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserResponseDto>
    {
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
