using SharedModel.Interfaces.Configuration;

namespace AspNetCoreJwtIdentity.Configuration
{
    public record DatabaseSetting : IDatabaseSetting
    {
        public string? DatabaseName { get; init; }
        public string? ConnectionString { get; init; }
        public Version? DbVersion { get; init; }
    }
}
