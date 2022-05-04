using SharedModel.Interfaces.Configuration;

namespace AspNetCoreJwtIdentity.Properties
{
    public record AppSettings : IAppSettings
    {
        public IJwtSetting Jwt { get; init; } = null!;
        public ITokenSetting Token { get; init; } = null!;
        public IDatabaseSetting DatabaseSetting { get; init; } = null!;
        public IEnumerable<ICorsOrigin> CorsOrigins { get; init; } = null!;
    }

}
