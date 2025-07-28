using LibraryMgtApiDomain.Repositories;
using MediatR;

namespace LibraryMgtApiApplication.Uxar.UserRegisterEvent
{
    //Listens for UserRegisteredEvent and calls INotificationService.
    public class UserRegisteredEventHandler : INotificationHandler<UserRegisteredEvent>
    {
        private readonly INotificationRepository _notificationRepository;

        public UserRegisteredEventHandler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
        {
            await _notificationRepository.SendNotificationAsync(notification.Message);
        }
    }
}
