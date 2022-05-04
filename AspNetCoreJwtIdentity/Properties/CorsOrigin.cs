using SharedModel.Interfaces.Configuration;

namespace AspNetCoreJwtIdentity.Properties
{
    public record CorsOrigin : ICorsOrigin
    {
        public string Origin { get; init; } = null!;
        public string Name { get; init; } = null!;
    }
}
