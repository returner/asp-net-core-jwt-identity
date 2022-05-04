namespace AspNetCoreJwtIdentity.Controllers.Group.Contract.Response
{
    public record GetGroupResponse : IContractResponseBase
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public string? Description { get; init; }
        public DateTime Created { get; init; }
        public DateTime Updated { get; init; }
    }
}
