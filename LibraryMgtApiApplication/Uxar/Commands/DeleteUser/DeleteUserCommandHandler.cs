

using AutoMapper;
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Exceptions;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryMgtApiApplication.Uxar.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<DeleteUserCommandHandler> _logger;
        private readonly IMapper _mapper;
        public DeleteUserCommandHandler(IUserRepository userRepository, ILogger<DeleteUserCommandHandler> logger, IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Deleting user with Id: {request.Id}");
            var user = await _userRepository.GetById(request.Id);
            if (user == null) throw new NotFoundException(nameof(User), request.Id.ToString());

            await _userRepository.Delete(user);
        }
    }
}
