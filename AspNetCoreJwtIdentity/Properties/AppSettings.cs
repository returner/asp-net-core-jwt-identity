using SharedModel.Interfaces.Configuration;

namespace AspNetCoreJwtIdentity.Properties
{
    public class AppSettings : IAppSettings
    {
        public IJwtSetting Jwt { get; set; } = null!;
        public ITokenSetting Token { get; set; } = null!;
    }
}
