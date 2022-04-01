namespace SharedModel.Interfaces.Configuration
{
    public interface IAppSettings
    {
        IJwtSetting Jwt { get; set; }
        ITokenSetting Token { get; set; }
    }
}