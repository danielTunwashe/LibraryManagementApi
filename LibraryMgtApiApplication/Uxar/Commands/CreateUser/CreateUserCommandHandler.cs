using AutoMapper;
using LibraryMgtApiApplication.Dto;
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryMgtApiApplication.Uxar.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<CreateUserCommandHandler> _logger;
        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository, ILogger<CreateUserCommandHandler> logger)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _logger = logger;
        }

        async Task<CreateUserResponseDto> IRequestHandler<CreateUserCommand, CreateUserResponseDto>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Creating user with Name: {request.Username}");

            //First map the CreateUserCommand to User
            var mappedUser = _mapper.Map<User>(request);
            //Then send 2ru the abstraction to perform the database logic..
            var user = await _userRepository.Create(mappedUser);  
            //
            var newMappedUser = _mapper.Map<CreateUserResponseDto>(mappedUser);

            return newMappedUser;
        }
    }
}
