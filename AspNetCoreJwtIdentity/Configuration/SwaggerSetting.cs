using SharedModel.Interfaces.Configuration;

namespace AspNetCoreJwtIdentity.Configuration
{
    public record SwaggerSetting : ISwaggerSetting
    {
        public string? Title { get; init; }
        public string? Version { get; init; }
        public string? Description { get; init; }
        public string? Email { get; init; }
        public string? Link { get; init; }
    }

}
