namespace SharedModel.Interfaces.Configuration
{
    public interface IDatabaseSetting
    { 
        string? DatabaseName { get; init; }
        string? ConnectionString { get; init; }
        Version? DbVersion { get; init; }
    }

}