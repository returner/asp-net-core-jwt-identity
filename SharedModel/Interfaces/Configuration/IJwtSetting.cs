namespace SharedModel.Interfaces.Configuration
{
    public interface IJwtSetting
    {
        string? Audience { get; init; }
        string? Issuer { get; init; }
        string? SecretKey { get; init; }
    }
}