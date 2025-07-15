
using MediatR;

namespace LibraryMgtApiApplication.Uxar.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        
    
    }
}
