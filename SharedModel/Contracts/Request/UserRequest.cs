namespace SharedModel.Contract.Request
{
    public record UserRequest(string Username, string Password, string? GroupName);
}
