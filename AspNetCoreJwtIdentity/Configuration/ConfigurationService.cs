using AspNetCoreJwtIdentity.Properties;
using SharedModel.Interfaces.Configuration;

namespace AspNetCoreJwtIdentity.Configuration
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
                    Audience = _configuration.Section<string>(AppSettingsItem.Jwt, "Audience"),
                    Issuer = _configuration.Section<string>(AppSettingsItem.Jwt, "Issuer"),
                    SecretKey = _configuration.Section<string>(AppSettingsItem.Jwt, "SecretKey")

                },
                Token = new TokenSetting
                {
                    DefaultExpireIntervalMinutes = _configuration.Section<int>(AppSettingsItem.Token, "DefaultExpireIntervalMinutes")
                },
                DatabaseSetting = new DatabaseSetting
                {
                    DatabaseName = _configuration.Section<string>(AppSettingsItem.DatabaseSetting, "DatabaseName"),
                    ConnectionString = _configuration.Section<string>(AppSettingsItem.DatabaseSetting, "ConnectionString"),
                    DbVersion = _configuration.Section<Version>(AppSettingsItem.DatabaseSetting, "DbVersion")
                },
                CorsOrigins = _configuration.Section<IEnumerable<CorsOrigin>>(AppSettingsItem.CorsOrigins, null).ToArray(),
            };

            return appSettings;
        }
    }
}
