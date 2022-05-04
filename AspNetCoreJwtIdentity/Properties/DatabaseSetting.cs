using SharedModel.Interfaces.Configuration;

namespace AspNetCoreJwtIdentity.Properties
{
    public record DatabaseSetting : IDatabaseSetting
    {
        public string DatabaseName { get; init; } = null!;
        public string ConnectionString { get; init; } = null!;
        public Version DbVersion { get; init; } = null!;
    }
}
