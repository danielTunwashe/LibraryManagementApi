
using AutoMapper;
using LibraryMgtApiApplication.Dto;
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Exceptions;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryMgtApiApplication.UxarProfile.Queries.GetUsersProfileById
{
    public class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileByIdQuery, UserProfileResponseDto>
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserProfileByIdQueryHandler> _logger;
        public GetUserProfileByIdQueryHandler(IUserProfileRepository userProfileRepository, IMapper mapper, ILogger<GetUserProfileByIdQueryHandler> logger)
        {
            _logger = logger;
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
        }

        public async Task<UserProfileResponseDto> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching user profile with ID: {Id}", request.Id);
            var userProfile = await _userProfileRepository.GetById(request.Id);
            if (userProfile == null)
            {
                throw new NotFoundException(nameof(UserProfile), request.Id.ToString());
            }
            var mappedUserProfile = _mapper.Map<UserProfileResponseDto>(userProfile);
            return mappedUserProfile;

        }
    }
}
