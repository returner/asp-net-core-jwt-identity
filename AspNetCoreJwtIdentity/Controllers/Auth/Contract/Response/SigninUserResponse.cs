namespace AspNetCoreJwtIdentity.Controllers.Auth.Contract.Response
{
    public record SigninUserResponse : IContractResponseBase
    {
        public string? IdToken { get; init; }
        public string? RefreshToken { get; init; }
        public string? AccessToken { get; init; }
        public long ExpiresIn { get; init; }
        public string? TokenType { get; init; }
    }
}
