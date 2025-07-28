using MediatR;

namespace LibraryMgtApiApplication.Uxar.UserRegisterEvent;

public class UserRegisteredEvent : INotification
{
    public UserRegisteredEvent(string message)
    {
        Message = message;
    }

    public string Message { get; }
}
