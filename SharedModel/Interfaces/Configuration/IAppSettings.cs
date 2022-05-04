namespace SharedModel.Interfaces.Configuration
{
    public interface IAppSettings
    {
        IJwtSetting? Jwt { get; init; }
        ITokenSetting? Token { get; init; }
        IDatabaseSetting? DatabaseSetting { get; init; }
        IEnumerable<ICorsOrigin?>? CorsOrigins { get; init; }
        ISwaggerSetting? Swagger { get; init; }
    }
}