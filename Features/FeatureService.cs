using Microsoft.Extensions.Configuration;

namespace Features
{
    public class FeatureService : IFeatureService
    {
        private readonly IConfiguration _configuration;

        public FeatureService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool IsEnabled(string feature)
        {
            return bool.TryParse(_configuration[feature], out bool result) && result;
        }
    }
}
