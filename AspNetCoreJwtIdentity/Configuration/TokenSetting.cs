using SharedModel.Interfaces.Configuration;

namespace AspNetCoreJwtIdentity.Configuration
{
    public record TokenSetting : ITokenSetting
    {
        public int DefaultExpireIntervalMinutes { get; init; }
    }
}
