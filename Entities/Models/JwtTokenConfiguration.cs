namespace Entities.Interfaces
{
    public record JwtTokenConfiguration
    {
        public int Id { get; set; }
        public int ExpireIntervalMinutes { get; set; }
    }
}
