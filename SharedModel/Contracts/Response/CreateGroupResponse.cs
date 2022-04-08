namespace SharedModel.Contracts.Response
{
    public record CreateGroupResponse(int Id, string Name, string? Description, DateTime Created);
}
