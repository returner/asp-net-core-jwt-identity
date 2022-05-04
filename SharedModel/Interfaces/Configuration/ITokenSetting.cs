namespace SharedModel.Interfaces.Configuration
{
    public interface ITokenSetting
    { 
        int DefaultExpireIntervalMinutes { get; init; }
    }

}