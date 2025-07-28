
namespace LibraryMgtApiDomain.CustomSmsEntity
{
    public class SmsSettings
    {
        public string Provider { get; set; } = default!;
        public string ApiKey { get; set; } = default!;
        public string Sender { get; set; } = default!;
    }
}
