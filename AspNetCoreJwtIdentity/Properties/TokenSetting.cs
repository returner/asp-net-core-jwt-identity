using SharedModel.Interfaces.Configuration;

namespace AspNetCoreJwtIdentity.Properties
{
    public record TokenSetting : ITokenSetting
    {
        public int DefaultExpireIntervalMinutes {get; init; }
    }
}
