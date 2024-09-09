using HMS.Abstraction;

namespace HMS.Services
{
    internal sealed class ConfigurationService : IConfigurationService
    {
        private readonly IConfiguration _configuration;

        public ConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int GetExpiryTimeframeInMinutes()
        {
            int hourlyRate = _configuration.GetValue<int>("Authentication:ExpiryTime");

            return hourlyRate;
        }
    }



}
