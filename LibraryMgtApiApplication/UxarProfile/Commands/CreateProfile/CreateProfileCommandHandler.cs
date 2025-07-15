using AutoMapper;
using LibraryMgtApiApplication.Dto;
using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryMgtApiApplication.UxarProfile.Commands.CreateProfile
{
    public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, CreateProfileResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly ILogger<CreateProfileCommandHandler> _logger;  

        public CreateProfileCommandHandler(IMapper mapper, IUserProfileRepository userProfileRepository, ILogger<CreateProfileCommandHandler> logger)
        {
            _mapper = mapper;
            _userProfileRepository = userProfileRepository;
            _logger = logger;
        }
        
        public async Task<CreateProfileResponseDto> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating UserProfile for user with Phone Number: ", request.PhoneNumber);

            var mappedUser = _mapper.Map<UserProfile>(request);

            var createdUserProfile = await _userProfileRepository.Create(mappedUser);

            var newMappedUserProfile = _mapper.Map<CreateProfileResponseDto>(createdUserProfile);

            return newMappedUserProfile;

        }
    }
}
