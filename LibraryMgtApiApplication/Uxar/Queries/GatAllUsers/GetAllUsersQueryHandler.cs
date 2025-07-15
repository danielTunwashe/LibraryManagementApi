
using AutoMapper;
using LibraryMgtApiApplication.Dto;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryMgtApiApplication.Uxar.Queries.GatAllUsers
{
    internal class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<CreateUserResponseDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllUsersQueryHandler> _logger;
        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper, ILogger<GetAllUsersQueryHandler> logger)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CreateUserResponseDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting all users");
            var users = await _userRepository.GetAll();

            if (users == null)
            {
                _logger.LogWarning("No users found");
                return await Task.FromResult(Enumerable.Empty<CreateUserResponseDto>());
            }

            var mappedUsers = _mapper.Map<IEnumerable<CreateUserResponseDto>>(users);

            return mappedUsers;
        }
    }
}
