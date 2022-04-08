namespace SharedModel.Contract.Response
{
    public record UserResponse
    {
        public int Id { get; set; }
        public string? Username { get; set; }
    }
}
