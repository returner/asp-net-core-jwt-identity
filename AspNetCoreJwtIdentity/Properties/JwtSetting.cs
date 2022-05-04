using SharedModel.Interfaces.Configuration;

namespace AspNetCoreJwtIdentity.Properties
{
    public record JwtSetting : IJwtSetting
    {
        public string SecretKey { get; init; } = null!;
        public string Issuer { get; init; } = null!;
        public string Audience { get; init; } = null!;
    }
}
