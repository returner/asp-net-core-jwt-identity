using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public record JwtTokenConfiguration
    {
        public int Id { get; set; }
        public int ExpireIntervalMinutes { get; set; }
    }
}
