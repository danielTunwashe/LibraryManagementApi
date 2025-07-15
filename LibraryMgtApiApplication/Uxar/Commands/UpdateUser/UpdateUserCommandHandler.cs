using AutoMapper;
using LibraryMgtApiDomain.Exceptions;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgtApiApplication.Uxar.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateUserCommandHandler> _logger;
        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, ILogger<UpdateUserCommandHandler> logger)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Updating user with Id: {request.Id}");
            var user = await _userRepository.GetById(request.Id);
            if (user == null) throw new NotFoundException(nameof(UpdateUserCommand), request.Id.ToString());

            user.Email = request.Email; // Update the email field directly
            user.Username = request.Username; // Update the username field directly

            var mappedUser = _mapper.Map(request, user); // Map the request to the existing user entity

            var updated = _userRepository.Update(mappedUser);

        }
    }
}
