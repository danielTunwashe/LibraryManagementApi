using MediatR;

namespace LibraryMgtApiApplication.Uxar.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public UpdateUserCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
