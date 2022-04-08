using Entities.Interfaces;

namespace Entities.Models
{

    public class User
    {
        public int Id {get;set;}
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public IEnumerable<Group>? Groups { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
