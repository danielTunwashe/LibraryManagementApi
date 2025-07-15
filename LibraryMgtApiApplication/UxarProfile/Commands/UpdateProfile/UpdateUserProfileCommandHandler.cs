
using AutoMapper;
using LibraryMgtApiDomain.Exceptions;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryMgtApiApplication.UxarProfile.Commands.UpdateProfile
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand>
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateUserProfileCommandHandler> _logger;
        public UpdateUserProfileCommandHandler(IUserProfileRepository userProfileRepository, IMapper mapper, ILogger<UpdateUserProfileCommandHandler> logger)
        {
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Updating userprofile with Id: {request.Id}");
            var userProfile = await _userProfileRepository.GetById(request.Id);
            if (userProfile == null)
            {
                _logger.LogError($"UserProfile with Id: {request.Id} not found");
                throw new NotFoundException(nameof(UpdateUserProfileCommand), request.Id.ToString());
            }

            var mappedUserProfile = _mapper.Map(request, userProfile); // Map the request to the existing user profile entity
            
            await _userProfileRepository.Update(mappedUserProfile);

        }
    }
}
