namespace AspNetCoreJwtIdentity.Controllers.Group.Contract.Response
{
    public record CreateGroupResponse(int Id, string Name, string? Description, DateTime Created) : IContractResponseBase;
}
