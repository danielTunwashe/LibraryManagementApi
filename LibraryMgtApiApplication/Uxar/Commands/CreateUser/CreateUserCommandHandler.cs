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
        private readonly IMailRepository _mailRepository;
        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository, ILogger<CreateUserCommandHandler> logger, IMailRepository mailRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _logger = logger;
            _mailRepository = mailRepository;
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

            await _mailRepository.SendEmailAsync(request.Email, request.Username, "Welcome to Library Mgt System – Your Account Is Ready!");

            return newMappedUser;
        }
    }
}
