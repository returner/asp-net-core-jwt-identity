namespace SharedModel.Payloads.Responses
{
    public record CreateGroupDtoResponse(int Id, string Name, string? Description, DateTime Created);
}
