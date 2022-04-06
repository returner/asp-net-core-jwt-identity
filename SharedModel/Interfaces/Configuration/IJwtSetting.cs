namespace SharedModel.Interfaces.Configuration
{
    public interface IJwtSetting
    {
        string Audience { get; set; }
        string Issuer { get; set; }
        string SecretKey { get; set; }
    }
}