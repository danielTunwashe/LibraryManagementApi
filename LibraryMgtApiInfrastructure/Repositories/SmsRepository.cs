
using LibraryMgtApiDomain.CustomSmsEntity;
using LibraryMgtApiDomain.Repositories;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace LibraryMgtApiInfrastructure.Repositories;

public class SmsRepository : ISmsRepository
{
    private readonly HttpClient _httpClient;
    private readonly SmsSettings _smsSettings;
    public SmsRepository(HttpClient httpClient, IOptions<SmsSettings> smsSettings)
    {
        _httpClient = httpClient;
        _smsSettings = smsSettings.Value;   
    }
    public async Task SendUserRegistrationSmsAsync(string phoneNumber, string username, string email)
    {
        string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "DynamicSmsTemplate/Templates", "UserRegistrationSmsTemplate.txt");
        string smsTemplate = await File.ReadAllTextAsync(templatePath);

        // Replace placeholders
        smsTemplate = smsTemplate.Replace("{{Username}}", username);
        smsTemplate = smsTemplate.Replace("{{Email}}", email);

        var payload = new
        {
            to = phoneNumber,
            from = _smsSettings.Sender,
            sms = smsTemplate,
            type = "plain",
            channel = "generic",
            api_key = _smsSettings.ApiKey
        };

        var response = await _httpClient.PostAsJsonAsync("https://api.ng.termii.com/api/sms/send", payload);
        response.EnsureSuccessStatusCode();

    }
}
