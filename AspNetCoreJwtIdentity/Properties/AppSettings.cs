using SharedModel.Interfaces.Configuration;

namespace AspNetCoreJwtIdentity.Properties
{
    public record AppSettings : IAppSettings
    {
        public IJwtSetting? Jwt { get; init; }
        public ITokenSetting? Token { get; init; }
        public IDatabaseSetting? DatabaseSetting { get; init; }
        public IEnumerable<ICorsOrigin?>? CorsOrigins { get; init; }
        public ISwaggerSetting? Swagger { get; init; }
    }

}
