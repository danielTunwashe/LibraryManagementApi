
namespace LibraryMgtApiDomain.Repositories;

public interface INotificationRepository
{
    //Contract for sending notifications. Actual implementation is in Infrastructure layer.
    Task SendNotificationAsync(string message);
}
