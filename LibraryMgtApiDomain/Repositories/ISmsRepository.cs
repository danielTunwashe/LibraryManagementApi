
namespace LibraryMgtApiDomain.Repositories;

public interface ISmsRepository
{
    Task SendUserRegistrationSmsAsync(string phoneNumber, string username, string email);
}
