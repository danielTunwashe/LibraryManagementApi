
using AutoMapper;
using LibraryMgtApiApplication.Dto;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryMgtApiApplication.UxarProfile.Queries.GetAllUsersProfile
{
    public class GetAllUserProfileQueryHandler : IRequestHandler<GetAllUserProfileQuery, IEnumerable<UserProfileResponseDto>>
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllUserProfileQueryHandler> _logger;

        public GetAllUserProfileQueryHandler(IUserProfileRepository userProfileRepository, IMapper mapper, ILogger<GetAllUserProfileQueryHandler> logger)
        {
            _logger = logger;
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserProfileResponseDto>> Handle(GetAllUserProfileQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all user profiles");
            var userProfiles = await _userProfileRepository.GetAll();

            var mappedUserProfiles = _mapper.Map<IEnumerable<UserProfileResponseDto>>(userProfiles);

            return mappedUserProfiles;
        }
    }
}
