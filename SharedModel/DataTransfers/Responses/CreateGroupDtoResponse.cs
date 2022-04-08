namespace SharedModel.DataTransfers.Responses
{
    public record CreateGroupDtoResponse(int Id, string Name, string? Description, DateTime Created);
}
