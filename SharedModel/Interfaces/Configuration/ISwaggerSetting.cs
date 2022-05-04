namespace SharedModel.Interfaces.Configuration
{
    public interface ISwaggerSetting
    {
        string? Title { get; init; }
        string? Version { get; init; }
        string? Description { get; init; }
        string? Email { get; init; }
        string? Link { get; init; }
    }
}