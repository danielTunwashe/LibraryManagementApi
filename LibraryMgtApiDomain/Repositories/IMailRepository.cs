
namespace LibraryMgtApiDomain.Repositories
{
    public interface IMailRepository
    {
        Task SendEmailAsync(string toEmail, string username, string subject);
    }
}
