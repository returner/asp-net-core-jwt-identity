using SharedModel.Interfaces.Configuration;

namespace AspNetCoreJwtIdentity.Configuration
{
    public record CorsOrigin : ICorsOrigin
    {
        public string? Origin { get; init; }
        public string? Name { get; init; }
    }
}
