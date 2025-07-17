
using LibraryMgtApiDomain.Exceptions;
using LibraryMgtApiDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LibraryMgtApiApplication.UxarProfile.Queries.DeleteUserProfile
{
    public class DeleteUserProfileQueryHandler : IRequestHandler<DeleteUserProfileQuery>
    {
        private readonly ILogger<DeleteUserProfileQueryHandler> _logger;    
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUserRepository _userRepository;
        public DeleteUserProfileQueryHandler(ILogger<DeleteUserProfileQueryHandler> logger, 
            IUserProfileRepository userProfileRepository, IUserRepository userRepository)
        {
            _logger = logger;
            _userProfileRepository = userProfileRepository;
            _userRepository = userRepository;
        }

        public async Task Handle(DeleteUserProfileQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Deleting User profile for user with UserId {request.Id}");

            var user = await _userRepository.GetById(request.Id);
            if (user == null)
            {
                throw new NotFoundException(nameof(user),request.Id.ToString());
            }

            await _userProfileRepository.Delete(user.Profile);

        }
    }
}
