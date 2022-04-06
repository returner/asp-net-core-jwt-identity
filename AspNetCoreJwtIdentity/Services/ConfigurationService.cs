using AspNetCoreJwtIdentity.Properties;
using SharedModel.Interfaces.Configuration;

namespace AspNetCoreJwtIdentity.Services
{
    public class ConfigurationService
    {
        private readonly IConfiguration _configuration;
        public ConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IAppSettings AppSettings()
        {
            var appSettings = new AppSettings
            {
                Jwt = new JwtSetting
                {
                    Audience = _configuration.GetSection("Jwt:Audience").Get<string>(),
                    Issuer = _configuration.GetSection("Jwt:Issuer").Get<string>(),
                    SecretKey = _configuration.GetSection("Jwt:SecretKey").Get<string>()
                },
                Token = new TokenSetting
                {
                    DefaultExpireIntervalMinutes = _configuration.GetSection("Token:DefaultExpireIntervalMinutes").Get<int>()
                }
            };

            return appSettings;
        }
    }
}
