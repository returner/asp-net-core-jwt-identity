using Entities.Interfaces;

namespace Entities.Models
{
    public class UserPool
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<User>? Users { get; set; }
        public JwtTokenConfiguration? JwtTokenConfiguration { get; set; }
    }
}
