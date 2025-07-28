using LibraryMgtApiDomain.Entities;
using LibraryMgtApiDomain.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace LibraryMgtApiInfrastructure.Repositories;

public class NotificationRepository : INotificationRepository
{
    //This is where SignalR is used to broadcast the message to connected clients
    private readonly IHubContext<NotificationHub> _hubContext;

    public NotificationRepository(IHubContext<NotificationHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendNotificationAsync(string message)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
    }
}
